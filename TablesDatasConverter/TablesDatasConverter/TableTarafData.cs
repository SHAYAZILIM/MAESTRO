using AvukatProLib2.Entities;
using System.Collections.Generic;
using Dt = AvukatProLib2.Data.DataRepository;

using Ent = AvukatProLib2.Entities;

namespace TablesDatasConverter
{
    public static class TableTarafData
    {
        public static int ConvertSozlesmeTarafToIsTaraf(TDI_KOD_SOZLESME_TARAF_SIFAT sifat)
        {
            switch (sifat.TARAF_SIFAT.Trim())
            {
                case "ÝHTAR EDEN": return 1; 
                case "FESÝH EDEN": return 1; 
                case "ÝTÝRAZ EDEN": return 1; 
                case "AZÝL EDEN": return 1; 
                case "ÝSTÝFA EDEN": return 1; 
                case "SÖZLEÞME TARAFI": return 1; 
                case "KEFÝL OLAN": return 1; 
                case "TANIK": return 1; 
                case "TESPÝT ÝSTEYEN": return 1; 
                case "REHÝN EDEN": return 1; 
                case "HÝBE EDEN": return 1; 
                case "TEMLÝK EDEN": return 1; 
                case "ALACAKLI": return 1; 
                case "PROTESTO EDEN": return 1; 
                case "VASÝYET EDEN": return 1; 
                case "FERAGAT EDEN": return 1; 
                case "EVLATLIK VEREN": return 1; 
                case "EMANET EDEN": return 1; 
                case "ÝBRA EDEN": return 1; 
                case "TAAHHÜT EDEN": return 1; 
                case "VEKÝL EDEN": return 1; 
                case "SULH OLAN": return 1; 
                case "MUVAFAKAT EDEN": return 1; 
                case "MUHATAP": return 1; 
                case "ÝHTAR EDÝLEN": return 1; 
                case "FESÝH EDÝLEN": return 1; 
                case "ÝTÝRAZ EDÝLEN": return 1; 
                case "AZÝL EDÝLEN": return 1; 
                case "SÖZLEÞME YAPAN": return 1; 
                case "KEFALET ALAN": return 1; 
                case "TESPÝT ÝSTENEN": return 1; 
                case "REHÝN ALAN": return 1; 
                case "HÝBE ALAN": return 1; 
                case "TEMELLÜK EDEN": return 1; 
                case "BORÇLU": return 1; 
                case "PROTESTO OLUNAN": return 1; 
                case "VASÝYET OLUNAN": return 1; 
                case "EVLATLIK ALAN": return 1; 
                case "EVLATLIK OLAN": return 1; 
                case "EMANET ALAN": return 1; 
                case "ÝBRA OLUNAN": return 1; 
                case "TAAHHÜT ALAN": return 1; 
                case "VEKÝL OLAN": return 1; 
                case "SULH OLAN 2": return 1; 
                case "MUVAFAKAT ALAN": return 1; 
                case "KÝRACI": return 1; 
                case "KÝRALAYAN": return 1; 
                case "KEÞÝDECÝ": return 1; 
                case "REHÝN EDÝLEN": return 1; 
                case "REHÝN VEREN": return 1; 
                case "KREDÝ VEREN": return 1; 
                case "KREDÝ ALAN": return 1;
                default: break;
                    
            }
            return 1;
        }

        public static List<Taraf> GetAV001_TD_BIL_DAVA_NEDENTaraf(Ent.AV001_TD_BIL_DAVA_NEDEN Record)
        {
            List<Taraf> returnValues = new List<Taraf>();
            if (Record.AV001_TD_BIL_DAVA_NEDEN_TARAFCollection.Count == 0)
            {
                Dt.AV001_TD_BIL_DAVA_NEDENProvider.DeepLoad(Record, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_DAVA_NEDEN_TARAF>));
            }

            Dt.AV001_TD_BIL_DAVA_NEDEN_TARAFProvider.DeepLoad(Record.AV001_TD_BIL_DAVA_NEDEN_TARAFCollection, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<Ent.AV001_TD_BIL_DAVA_NEDEN_TARAF> lstTaraflar = Record.AV001_TD_BIL_DAVA_NEDEN_TARAFCollection;
            for (int i = 0; i < lstTaraflar.Count; i++)
            {
                Taraf trft = GetTaraf("AV001_TD_BIL_DAVA_NEDEN", lstTaraflar[i].TARAF_CARI_IDSource, lstTaraflar[i].TARAF_SIFAT_IDSource, lstTaraflar[i], new TDI_KOD_IS_TARAF(), false, lstTaraflar[i].ID);
                returnValues.Add(trft);
            }
            return returnValues;
        }

        public static List<Taraf> GetAV001_TD_BIL_FOYTaraf(Ent.AV001_TD_BIL_FOY Record)
        {
            List<Taraf> returnValues = new List<Taraf>();
            if (Record.AV001_TD_BIL_FOY_TARAFCollection.Count == 0)
            {
                Dt.AV001_TD_BIL_FOYProvider.DeepLoad(Record, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_FOY_TARAF>));
            }

            Dt.AV001_TD_BIL_FOY_TARAFProvider.DeepLoad(Record.AV001_TD_BIL_FOY_TARAFCollection, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<Ent.AV001_TD_BIL_FOY_TARAF> lstTaraflar = Record.AV001_TD_BIL_FOY_TARAFCollection;
            if (Record.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
            {
                Dt.AV001_TD_BIL_FOYProvider.DeepLoad(Record, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT>));
            }

            Dt.AV001_TD_BIL_FOY_SORUMLU_AVUKATProvider.DeepLoad(Record.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT> lstSorumlular = Record.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection;
            for (int i = 0; i < lstSorumlular.Count; i++)
            {
                Taraf trfs = GetTaraf("AV001_TD_BIL_FOY", lstSorumlular[i].SORUMLU_AVUKAT_CARI_IDSource, Dt.TDIE_KOD_TARAF_SIFATProvider.GetByID(1), lstSorumlular[i], new TDI_KOD_IS_TARAF(), true, lstSorumlular[i].ID);
                returnValues.Add(trfs);
            }
            for (int i = 0; i < lstTaraflar.Count; i++)
            {
                Taraf trft = GetTaraf("AV001_TD_BIL_FOY", lstTaraflar[i].CARI_IDSource, lstTaraflar[i].TARAF_SIFAT_IDSource, lstTaraflar[i], new TDI_KOD_IS_TARAF(), false, lstTaraflar[i].ID);
                returnValues.Add(trft);
            }
            return returnValues;
        }

        public static List<Taraf> GetAV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENTaraf(Ent.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN Record)
        {
            List<Taraf> returnValues = new List<Taraf>();
            if (Record.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAFCollection.Count == 0)
            {
                Dt.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENProvider.DeepLoad(Record, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAF>));
            }

            Dt.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAFProvider.DeepLoad(Record.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAFCollection, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<Ent.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAF> lstTaraflar = Record.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAFCollection;
            for (int i = 0; i < lstTaraflar.Count; i++)
            {
                Taraf trft = GetTaraf("AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN", lstTaraflar[i].TARAF_CARI_IDSource, lstTaraflar[i].TARAF_SIFAT_IDSource, lstTaraflar[i], new TDI_KOD_IS_TARAF(), false, lstTaraflar[i].ID);
                returnValues.Add(trft);
            }
            return returnValues;
        }

        public static List<Taraf> GetAV001_TD_BIL_HAZIRLIKTaraf(Ent.AV001_TD_BIL_HAZIRLIK Record)
        {
            List<Taraf> returnValues = new List<Taraf>();
            if (Record.AV001_TD_BIL_HAZIRLIK_TARAFCollection.Count == 0)
            {
                Dt.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(Record, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_HAZIRLIK_TARAF>));
            }

            Dt.AV001_TD_BIL_HAZIRLIK_TARAFProvider.DeepLoad(Record.AV001_TD_BIL_HAZIRLIK_TARAFCollection, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<Ent.AV001_TD_BIL_HAZIRLIK_TARAF> lstTaraflar = Record.AV001_TD_BIL_HAZIRLIK_TARAFCollection;
            if (Record.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection.Count == 0)
            {
                Dt.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(Record, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_HAZIRLIK_SORUMLU>));
            }

            Dt.AV001_TD_BIL_HAZIRLIK_SORUMLUProvider.DeepLoad(Record.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<AV001_TD_BIL_HAZIRLIK_SORUMLU> lstSorumlular = Record.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection;
            for (int i = 0; i < lstSorumlular.Count; i++)
            {
                Taraf trfs = GetTaraf("AV001_TD_BIL_HAZIRLIK", lstSorumlular[i].CARI_IDSource, Dt.TDIE_KOD_TARAF_SIFATProvider.GetByID(1), lstSorumlular[i], new TDI_KOD_IS_TARAF(), true, lstTaraflar[i].ID);
                returnValues.Add(trfs);
            }
            for (int i = 0; i < lstTaraflar.Count; i++)
            {
                Taraf trft = GetTaraf("AV001_TD_BIL_HAZIRLIK", lstTaraflar[i].CARI_IDSource, lstTaraflar[i].TARAF_SIFAT_IDSource, lstTaraflar[i], new TDI_KOD_IS_TARAF(), false, lstTaraflar[i].ID);
                returnValues.Add(trft);
            }
            return returnValues;
        }

        public static List<Taraf> GetAV001_TD_BIL_MAHKEME_HUKUMTaraf(Ent.AV001_TD_BIL_MAHKEME_HUKUM Record)
        {
            List<Taraf> returnValues = new List<Taraf>();
            if (Record.AV001_TD_BIL_MAHKEME_HUKUM_TARAFCollection.Count == 0)
            {
                Dt.AV001_TD_BIL_MAHKEME_HUKUMProvider.DeepLoad(Record, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_MAHKEME_HUKUM_TARAF>));
            }

            Dt.AV001_TD_BIL_MAHKEME_HUKUM_TARAFProvider.DeepLoad(Record.AV001_TD_BIL_MAHKEME_HUKUM_TARAFCollection, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<Ent.AV001_TD_BIL_MAHKEME_HUKUM_TARAF> lstTaraflar = Record.AV001_TD_BIL_MAHKEME_HUKUM_TARAFCollection;
            for (int i = 0; i < lstTaraflar.Count; i++)
            {
                Taraf trft = GetTaraf("AV001_TD_BIL_MAHKEME_HUKUM", lstTaraflar[i].TARAF_CARI_IDSource, Dt.TDIE_KOD_TARAF_SIFATProvider.GetByID(1), lstTaraflar[i], new TDI_KOD_IS_TARAF(), false, lstTaraflar[i].ID);
                returnValues.Add(trft);
            }
            return returnValues;
        }

        public static List<Taraf> GetAV001_TD_BIL_TEMYIZTaraf(Ent.AV001_TD_BIL_TEMYIZ Record)
        {
            List<Taraf> returnValues = new List<Taraf>();
            if (Record.AV001_TD_BIL_TEMYIZ_TARAFCollection.Count == 0)
            {
                Dt.AV001_TD_BIL_TEMYIZProvider.DeepLoad(Record, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_TEMYIZ_TARAF>));
            }

            Dt.AV001_TD_BIL_TEMYIZ_TARAFProvider.DeepLoad(Record.AV001_TD_BIL_TEMYIZ_TARAFCollection, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<Ent.AV001_TD_BIL_TEMYIZ_TARAF> lstTaraflar = Record.AV001_TD_BIL_TEMYIZ_TARAFCollection;
            for (int i = 0; i < lstTaraflar.Count; i++)
            {
                Taraf trft = GetTaraf("AV001_TD_BIL_TEMYIZ", lstTaraflar[i].CARI_IDSource, Dt.TDIE_KOD_TARAF_SIFATProvider.GetByID(1), lstTaraflar[i], new TDI_KOD_IS_TARAF(), false, lstTaraflar[i].ID);
                returnValues.Add(trft);
            }
            return returnValues;
        }

        public static List<Taraf> GetAV001_TD_BIL_UZLASMATaraf(Ent.AV001_TD_BIL_UZLASMA Record)
        {
            List<Taraf> returnValues = new List<Taraf>();
            if (Record.AV001_TD_BIL_UZLASMA_TARAFCollection.Count == 0)
            {
                Dt.AV001_TD_BIL_UZLASMAProvider.DeepLoad(Record, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_UZLASMA_TARAF>));
            }

            Dt.AV001_TD_BIL_UZLASMA_TARAFProvider.DeepLoad(Record.AV001_TD_BIL_UZLASMA_TARAFCollection, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<Ent.AV001_TD_BIL_UZLASMA_TARAF> lstTaraflar = Record.AV001_TD_BIL_UZLASMA_TARAFCollection;
            for (int i = 0; i < lstTaraflar.Count; i++)
            {
                Taraf trft = GetTaraf("AV001_TD_BIL_UZLASMA", lstTaraflar[i].TARAF_CARI_IDSource, lstTaraflar[i].TARAF_SIFAT_IDSource, lstTaraflar[i], new TDI_KOD_IS_TARAF(), false, lstTaraflar[i].ID);
                returnValues.Add(trft);
            }
            return returnValues;
        }

        public static List<Taraf> GetAV001_TDI_BIL_IHTIYATI_TEDBIRTaraf(Ent.AV001_TDI_BIL_IHTIYATI_TEDBIR Record)
        {
            List<Taraf> returnValues = new List<Taraf>();
            if (Record.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection.Count == 0)
            {
                Dt.AV001_TDI_BIL_IHTIYATI_TEDBIRProvider.DeepLoad(Record, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF>));
            }

            Dt.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFProvider.DeepLoad(Record.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<Ent.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF> lstTaraflar = Record.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection;
            for (int i = 0; i < lstTaraflar.Count; i++)
            {
                Taraf trft = GetTaraf("AV001_TDI_BIL_IHTIYATI_TEDBIR", lstTaraflar[i].ICRA_CARI_TARAF_IDSource, lstTaraflar[i].ICRA_TARAF_SIFAT_IDSource, lstTaraflar[i], new TDI_KOD_IS_TARAF(), false, lstTaraflar[i].ID);
                returnValues.Add(trft);
            }
            return returnValues;
        }

        public static List<Taraf> GetAV001_TDI_BIL_ISTaraf(Ent.AV001_TDI_BIL_IS Record)
        {
            List<Taraf> returnValues = new List<Taraf>();
            if (Record.AV001_TDI_BIL_IS_TARAFCollection.Count == 0)
            {
                Dt.AV001_TDI_BIL_ISProvider.DeepLoad(Record, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_IS_TARAF>));
            }

            Dt.AV001_TDI_BIL_IS_TARAFProvider.DeepLoad(Record.AV001_TDI_BIL_IS_TARAFCollection, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<Ent.AV001_TDI_BIL_IS_TARAF> lstTaraflar = Record.AV001_TDI_BIL_IS_TARAFCollection;
            for (int i = 0; i < lstTaraflar.Count; i++)
            {
                Taraf trft = GetTaraf("AV001_TDI_BIL_IS", lstTaraflar[i].CARI_IDSource, Dt.TDIE_KOD_TARAF_SIFATProvider.GetByID(1), lstTaraflar[i], lstTaraflar[i].IS_TARAF_IDSource, false, lstTaraflar[i].ID);
                returnValues.Add(trft);
            }
            return returnValues;
        }

        public static List<Taraf> GetAV001_TDI_BIL_KIYMETLI_EVRAKTaraf(Ent.AV001_TDI_BIL_KIYMETLI_EVRAK Record)
        {
            List<Taraf> returnValues = new List<Taraf>();
            if (Record.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection.Count == 0)
            {
                Dt.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepLoad(Record, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF>));
            }

            Dt.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFProvider.DeepLoad(Record.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<Ent.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF> lstTaraflar = Record.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection;
            for (int i = 0; i < lstTaraflar.Count; i++)
            {
                Taraf trft = GetTaraf("AV001_TDI_BIL_KIYMETLI_EVRAK", lstTaraflar[i].TARAF_CARI_IDSource, Dt.TDIE_KOD_TARAF_SIFATProvider.GetByID(1), lstTaraflar[i], new TDI_KOD_IS_TARAF(), false, lstTaraflar[i].ID);
                returnValues.Add(trft);
            }
            return returnValues;
        }

        public static List<Taraf> GetAV001_TDI_BIL_RUCUTaraf(Ent.AV001_TDI_BIL_RUCU Record)
        {
            List<Taraf> returnValues = new List<Taraf>();
            if (Record.AV001_TDI_BIL_RUCU_TARAFCollection.Count == 0)
            {
                Dt.AV001_TDI_BIL_RUCUProvider.DeepLoad(Record, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_RUCU_TARAF>));
            }

            Dt.AV001_TDI_BIL_RUCU_TARAFProvider.DeepLoad(Record.AV001_TDI_BIL_RUCU_TARAFCollection, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<Ent.AV001_TDI_BIL_RUCU_TARAF> lstTaraflar = Record.AV001_TDI_BIL_RUCU_TARAFCollection;
            if (Record.AV001_TDI_BIL_RUCU_SORUMLUCollection.Count == 0)
            {
                Dt.AV001_TDI_BIL_RUCUProvider.DeepLoad(Record, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_RUCU_SORUMLU>));
            }

            Dt.AV001_TDI_BIL_RUCU_SORUMLUProvider.DeepLoad(Record.AV001_TDI_BIL_RUCU_SORUMLUCollection, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<AV001_TDI_BIL_RUCU_SORUMLU> lstSorumlular = Record.AV001_TDI_BIL_RUCU_SORUMLUCollection;
            for (int i = 0; i < lstSorumlular.Count; i++)
            {
                Taraf trfs = GetTaraf("AV001_TDI_BIL_RUCU", lstSorumlular[i].CARI_IDSource, Dt.TDIE_KOD_TARAF_SIFATProvider.GetByID(1), lstSorumlular[i], new TDI_KOD_IS_TARAF(), true, lstTaraflar[i].ID);
                returnValues.Add(trfs);
            }
            for (int i = 0; i < lstTaraflar.Count; i++)
            {
                Taraf trft = GetTaraf("AV001_TDI_BIL_RUCU", lstTaraflar[i].CARI_IDSource, lstTaraflar[i].TARAF_SIFAT_IDSource, lstTaraflar[i], new TDI_KOD_IS_TARAF(), false, lstTaraflar[i].ID);
                returnValues.Add(trft);
            }
            return returnValues;
        }

        public static List<Taraf> GetAV001_TDI_BIL_SOZLESMETaraf(Ent.AV001_TDI_BIL_SOZLESME Record)
        {
            List<Taraf> returnValues = new List<Taraf>();
            if (Record.AV001_TDI_BIL_SOZLESME_TARAFCollection.Count == 0)
            {
                Dt.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(Record, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME_TARAF>));
            }

            Dt.AV001_TDI_BIL_SOZLESME_TARAFProvider.DeepLoad(Record.AV001_TDI_BIL_SOZLESME_TARAFCollection, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF), typeof(TDI_KOD_SOZLESME_TARAF_SIFAT));
            TList<Ent.AV001_TDI_BIL_SOZLESME_TARAF> lstTaraflar = Record.AV001_TDI_BIL_SOZLESME_TARAFCollection;
            if (Record.AV001_TDI_BIL_SOZLESME_SORUMLUCollection.Count == 0)
            {
                Dt.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(Record, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME_SORUMLU>));
            }

            Dt.AV001_TDI_BIL_SOZLESME_SORUMLUProvider.DeepLoad(Record.AV001_TDI_BIL_SOZLESME_SORUMLUCollection, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<AV001_TDI_BIL_SOZLESME_SORUMLU> lstSorumlular = Record.AV001_TDI_BIL_SOZLESME_SORUMLUCollection;
            for (int i = 0; i < lstSorumlular.Count; i++)
            {
                Taraf trfs = GetTaraf("AV001_TDI_BIL_SOZLESME", lstSorumlular[i].SORUMLU_CARI_IDSource, Dt.TDIE_KOD_TARAF_SIFATProvider.GetByID(1), lstSorumlular[i], new TDI_KOD_IS_TARAF(), true, lstTaraflar[i].ID);
                returnValues.Add(trfs);
            }
            for (int i = 0; i < lstTaraflar.Count; i++)
            {
                Taraf trft = GetTaraf("AV001_TDI_BIL_SOZLESME", lstTaraflar[i].CARI_IDSource, lstTaraflar[i].TARAF_SIFAT_IDSource, lstTaraflar[i], new TDI_KOD_IS_TARAF(), false, lstTaraflar[i].ID);
                returnValues.Add(trft);
            }
            return returnValues;
        }

        public static List<Taraf> GetAV001_TDI_BIL_TEBLIGAT_MUHATAPTaraf(AV001_TDI_BIL_TEBLIGAT_MUHATAP Record)
        {
            List<Taraf> returnValues = new List<Taraf>();
            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_TEBLIGAT_MUHATAPProvider.DeepLoad(Record, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));
            Taraf trftM = GetTaraf("AV001_TDI_BIL_TEBLIGAT_MUHATAP", Record.MUHATAP_CARI_IDSource, new TDIE_KOD_TARAF_SIFAT(), Record, new TDI_KOD_IS_TARAF(), false, Record.ID);
            returnValues.Add(trftM);
            Taraf trftA = GetTaraf("AV001_TDI_BIL_TEBLIGAT_MUHATAP", Record.ALAN_CARI_IDSource, new TDIE_KOD_TARAF_SIFAT(), Record, new TDI_KOD_IS_TARAF(), false, Record.ID);
            returnValues.Add(trftA);
            return returnValues;
        }

        public static List<Taraf> GetAV001_TDI_BIL_TEMINAT_MEKTUPTaraf(Ent.AV001_TDI_BIL_TEMINAT_MEKTUP Record)
        {
            List<Taraf> returnValues = new List<Taraf>();
            if (Record.AV001_TDI_BIL_TEMINAT_MEKTUP_TARAFCollection.Count == 0)
            {
                Dt.AV001_TDI_BIL_TEMINAT_MEKTUPProvider.DeepLoad(Record, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_TEMINAT_MEKTUP_TARAF>));
            }

            Dt.AV001_TDI_BIL_TEMINAT_MEKTUP_TARAFProvider.DeepLoad(Record.AV001_TDI_BIL_TEMINAT_MEKTUP_TARAFCollection, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<Ent.AV001_TDI_BIL_TEMINAT_MEKTUP_TARAF> lstTaraflar = Record.AV001_TDI_BIL_TEMINAT_MEKTUP_TARAFCollection;
            for (int i = 0; i < lstTaraflar.Count; i++)
            {
                Taraf trft = GetTaraf("AV001_TDI_BIL_TEMINAT_MEKTUP", lstTaraflar[i].TARAF_CARI_IDSource, Dt.TDIE_KOD_TARAF_SIFATProvider.GetByID(1), lstTaraflar[i], new TDI_KOD_IS_TARAF(), false, lstTaraflar[i].ID);
                returnValues.Add(trft);
            }
            return returnValues;
        }

        public static List<Taraf> GetAV001_TDI_BIL_TEMSILTaraf(Ent.AV001_TDI_BIL_TEMSIL Record)
        {
            List<Taraf> returnValues = new List<Taraf>();
            if (Record.AV001_TDI_BIL_TEMSIL_TARAFCollection.Count == 0)
            {
                Dt.AV001_TDI_BIL_TEMSILProvider.DeepLoad(Record, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_TEMSIL_TARAF>));
            }

            Dt.AV001_TDI_BIL_TEMSIL_TARAFProvider.DeepLoad(Record.AV001_TDI_BIL_TEMSIL_TARAFCollection, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<Ent.AV001_TDI_BIL_TEMSIL_TARAF> lstTaraflar = Record.AV001_TDI_BIL_TEMSIL_TARAFCollection;
            for (int i = 0; i < lstTaraflar.Count; i++)
            {
                Taraf trft = GetTaraf("AV001_TDI_BIL_TEMSIL", lstTaraflar[i].TARAF_CARI_IDSource, Dt.TDIE_KOD_TARAF_SIFATProvider.GetByID(1), lstTaraflar[i], new TDI_KOD_IS_TARAF(), false, lstTaraflar[i].ID);
                returnValues.Add(trft);
            }
            return returnValues;
        }

        public static List<Taraf> GetAV001_TDI_BIL_TESPITTaraf(Ent.AV001_TDI_BIL_TESPIT Record)
        {
            List<Taraf> returnValues = new List<Taraf>();
            if (Record.AV001_TDI_BIL_TESPIT_TARAFCollection.Count == 0)
            {
                Dt.AV001_TDI_BIL_TESPITProvider.DeepLoad(Record, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_TESPIT_TARAF>));
            }

            Dt.AV001_TDI_BIL_TESPIT_TARAFProvider.DeepLoad(Record.AV001_TDI_BIL_TESPIT_TARAFCollection, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<Ent.AV001_TDI_BIL_TESPIT_TARAF> lstTaraflar = Record.AV001_TDI_BIL_TESPIT_TARAFCollection;
            for (int i = 0; i < lstTaraflar.Count; i++)
            {
                Taraf trft = GetTaraf("AV001_TDI_BIL_TESPIT", lstTaraflar[i].TESPIT_YAPILAN_TARAF_IDSource, Dt.TDIE_KOD_TARAF_SIFATProvider.GetByID(1), lstTaraflar[i], new TDI_KOD_IS_TARAF(), false, lstTaraflar[i].ID);
                returnValues.Add(trft);
            }
            return returnValues;
        }

        public static List<Taraf> GetAV001_TDIE_BIL_ASAMATaraf(Ent.AV001_TDIE_BIL_ASAMA Record)
        {
            List<Taraf> returnValues = new List<Taraf>();
            if (Record.AV001_TDIE_BIL_ASAMA_TARAFCollection.Count == 0)
            {
                Dt.AV001_TDIE_BIL_ASAMAProvider.DeepLoad(Record, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_ASAMA_TARAF>));
            }

            Dt.AV001_TDIE_BIL_ASAMA_TARAFProvider.DeepLoad(Record.AV001_TDIE_BIL_ASAMA_TARAFCollection, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<Ent.AV001_TDIE_BIL_ASAMA_TARAF> lstTaraflar = Record.AV001_TDIE_BIL_ASAMA_TARAFCollection;
            if (Record.AV001_TDIE_BIL_ASAMA_SORUMLUCollection.Count == 0)
            {
                Dt.AV001_TDIE_BIL_ASAMAProvider.DeepLoad(Record, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_ASAMA_SORUMLU>));
            }

            Dt.AV001_TDIE_BIL_ASAMA_SORUMLUProvider.DeepLoad(Record.AV001_TDIE_BIL_ASAMA_SORUMLUCollection, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<AV001_TDIE_BIL_ASAMA_SORUMLU> lstSorumlular = Record.AV001_TDIE_BIL_ASAMA_SORUMLUCollection;
            for (int i = 0; i < lstSorumlular.Count; i++)
            {
                Taraf trfs = GetTaraf("AV001_TDIE_BIL_ASAMA", lstSorumlular[i].CARI_IDSource, Dt.TDIE_KOD_TARAF_SIFATProvider.GetByID(1), lstSorumlular[i], new TDI_KOD_IS_TARAF(), true, lstTaraflar[i].ID);
                returnValues.Add(trfs);
            }
            for (int i = 0; i < lstTaraflar.Count; i++)
            {
                Taraf trft = GetTaraf("AV001_TDIE_BIL_ASAMA", lstTaraflar[i].CARI_IDSource, lstTaraflar[i].SIFAT_IDSource, lstTaraflar[i], new TDI_KOD_IS_TARAF(), false, lstTaraflar[i].ID);
                returnValues.Add(trft);
            }
            return returnValues;
        }

        public static List<Taraf> GetAV001_TDIE_BIL_BELGETaraf(Ent.AV001_TDIE_BIL_BELGE Record)
        {
            List<Taraf> returnValues = new List<Taraf>();
            if (Record.AV001_TDIE_BIL_BELGE_TARAFCollection.Count == 0)
            {
                Dt.AV001_TDIE_BIL_BELGEProvider.DeepLoad(Record, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_BELGE_TARAF>));
            }

            Dt.AV001_TDIE_BIL_BELGE_TARAFProvider.DeepLoad(Record.AV001_TDIE_BIL_BELGE_TARAFCollection, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<Ent.AV001_TDIE_BIL_BELGE_TARAF> lstTaraflar = Record.AV001_TDIE_BIL_BELGE_TARAFCollection;
            if (Record.AV001_TDIE_BIL_BELGE_SORUMLUCollection.Count == 0)
            {
                Dt.AV001_TDIE_BIL_BELGEProvider.DeepLoad(Record, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_BELGE_SORUMLU>));
            }

            Dt.AV001_TDIE_BIL_BELGE_SORUMLUProvider.DeepLoad(Record.AV001_TDIE_BIL_BELGE_SORUMLUCollection, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<AV001_TDIE_BIL_BELGE_SORUMLU> lstSorumlular = Record.AV001_TDIE_BIL_BELGE_SORUMLUCollection;
            for (int i = 0; i < lstSorumlular.Count; i++)
            {
                Taraf trfs = GetTaraf("AV001_TDIE_BIL_BELGE", lstSorumlular[i].CARI_IDSource, Dt.TDIE_KOD_TARAF_SIFATProvider.GetByID(1), lstSorumlular[i], new TDI_KOD_IS_TARAF(), true, lstTaraflar[i].ID);
                returnValues.Add(trfs);
            }
            for (int i = 0; i < lstTaraflar.Count; i++)
            {
                Taraf trft = GetTaraf("AV001_TDIE_BIL_BELGE", lstTaraflar[i].CARI_IDSource, lstTaraflar[i].SIFAT_IDSource, lstTaraflar[i], new TDI_KOD_IS_TARAF(), false, lstTaraflar[i].ID);
                returnValues.Add(trft);
            }
            return returnValues;
        }

        public static List<Taraf> GetAV001_TI_BIL_ALACAK_NEDENTaraf(Ent.AV001_TI_BIL_ALACAK_NEDEN Record)
        {
            List<Taraf> returnValues = new List<Taraf>();
            if (Record.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Count == 0)
            {
                Dt.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(Record, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>));
            }

            Dt.AV001_TI_BIL_ALACAK_NEDEN_TARAFProvider.DeepLoad(Record.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<Ent.AV001_TI_BIL_ALACAK_NEDEN_TARAF> lstTaraflar = Record.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection;
            for (int i = 0; i < lstTaraflar.Count; i++)
            {
                Taraf trft = GetTaraf("AV001_TI_BIL_ALACAK_NEDEN", lstTaraflar[i].TARAF_CARI_IDSource, lstTaraflar[i].TARAF_SIFAT_IDSource, lstTaraflar[i], new TDI_KOD_IS_TARAF(), false, lstTaraflar[i].ID);
                returnValues.Add(trft);
            }
            return returnValues;
        }

        public static List<Taraf> GetAV001_TI_BIL_DAVA_OZETTaraf(Ent.AV001_TI_BIL_DAVA_OZET Record)
        {
            List<Taraf> returnValues = new List<Taraf>();
            if (Record.AV001_TI_BIL_DAVA_OZET_TARAFCollection.Count == 0)
            {
                Dt.AV001_TI_BIL_DAVA_OZETProvider.DeepLoad(Record, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_DAVA_OZET_TARAF>));
            }

            Dt.AV001_TI_BIL_DAVA_OZET_TARAFProvider.DeepLoad(Record.AV001_TI_BIL_DAVA_OZET_TARAFCollection, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<Ent.AV001_TI_BIL_DAVA_OZET_TARAF> lstTaraflar = Record.AV001_TI_BIL_DAVA_OZET_TARAFCollection;
            for (int i = 0; i < lstTaraflar.Count; i++)
            {
                Taraf trft = GetTaraf("AV001_TI_BIL_DAVA_OZET", lstTaraflar[i].DAVA_TARAF_IDSource, lstTaraflar[i].DAVA_TARAF_SIFAT_IDSource, lstTaraflar[i], new TDI_KOD_IS_TARAF(), false, lstTaraflar[i].ID);
                returnValues.Add(trft);
            }
            return returnValues;
        }

        public static List<Taraf> GetAV001_TI_BIL_FOYTaraf(Ent.AV001_TI_BIL_FOY Record)
        {
            List<Taraf> returnValues = new List<Taraf>();
            if (Record.AV001_TI_BIL_FOY_TARAFCollection.Count == 0)
            {
                Dt.AV001_TI_BIL_FOYProvider.DeepLoad(Record, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>));
            }

            Dt.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(Record.AV001_TI_BIL_FOY_TARAFCollection, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<Ent.AV001_TI_BIL_FOY_TARAF> lstTaraflar = Record.AV001_TI_BIL_FOY_TARAFCollection;
            if (Record.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
            {
                Dt.AV001_TI_BIL_FOYProvider.DeepLoad(Record, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
            }

            Dt.AV001_TI_BIL_FOY_SORUMLU_AVUKATProvider.DeepLoad(Record.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT> lstSorumlular = Record.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection;
            for (int i = 0; i < lstSorumlular.Count; i++)
            {
                Taraf trfs = GetTaraf("AV001_TI_BIL_FOY", lstSorumlular[i].SORUMLU_AVUKAT_CARI_IDSource, Dt.TDIE_KOD_TARAF_SIFATProvider.GetByID(1), lstSorumlular[i], new TDI_KOD_IS_TARAF(), true, lstSorumlular[i].ID);
                returnValues.Add(trfs);
            }
            for (int i = 0; i < lstTaraflar.Count; i++)
            {
                Taraf trft = GetTaraf("AV001_TI_BIL_FOY", lstTaraflar[i].CARI_IDSource, lstTaraflar[i].TARAF_SIFAT_IDSource, lstTaraflar[i], new TDI_KOD_IS_TARAF(), false, lstTaraflar[i].ID);
                returnValues.Add(trft);
            }
            return returnValues;
        }

        public static List<Taraf> GetAV001_TI_BIL_GAYRIMENKULTaraf(Ent.AV001_TI_BIL_GAYRIMENKUL Record)
        {
            List<Taraf> returnValues = new List<Taraf>();
            if (Record.AV001_TI_BIL_GAYRIMENKUL_TARAFCollection.Count == 0)
            {
                Dt.AV001_TI_BIL_GAYRIMENKULProvider.DeepLoad(Record, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_GAYRIMENKUL_TARAF>));
            }

            Dt.AV001_TI_BIL_GAYRIMENKUL_TARAFProvider.DeepLoad(Record.AV001_TI_BIL_GAYRIMENKUL_TARAFCollection, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<Ent.AV001_TI_BIL_GAYRIMENKUL_TARAF> lstTaraflar = Record.AV001_TI_BIL_GAYRIMENKUL_TARAFCollection;
            for (int i = 0; i < lstTaraflar.Count; i++)
            {
                Taraf trft = GetTaraf("AV001_TI_BIL_GAYRIMENKUL", lstTaraflar[i].TARAF_CARI_IDSource, Dt.TDIE_KOD_TARAF_SIFATProvider.GetByID(1), lstTaraflar[i], new TDI_KOD_IS_TARAF(), false, lstTaraflar[i].ID);
                returnValues.Add(trft);
            }
            return returnValues;
        }

        public static List<Taraf> GetAV001_TI_BIL_IHTIYATI_HACIZTaraf(Ent.AV001_TI_BIL_IHTIYATI_HACIZ Record)
        {
            List<Taraf> returnValues = new List<Taraf>();
            if (Record.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection.Count == 0)
            {
                Dt.AV001_TI_BIL_IHTIYATI_HACIZProvider.DeepLoad(Record, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_IHTIYATI_HACIZ_TARAF>));
            }

            Dt.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFProvider.DeepLoad(Record.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<Ent.AV001_TI_BIL_IHTIYATI_HACIZ_TARAF> lstTaraflar = Record.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection;
            for (int i = 0; i < lstTaraflar.Count; i++)
            {
                Taraf trft = GetTaraf("AV001_TI_BIL_IHTIYATI_HACIZ", lstTaraflar[i].ICRA_CARI_TARAF_IDSource, lstTaraflar[i].TARAF_SIFAT_IDSource, lstTaraflar[i], new TDI_KOD_IS_TARAF(), false, lstTaraflar[i].ID);
                returnValues.Add(trft);
            }
            return returnValues;
        }

        public static Taraf GetTaraf(string modulTablo, Ent.AV001_TDI_BIL_CARI cari, Ent.TDIE_KOD_TARAF_SIFAT sifat, Ent.IEntity taraf, Ent.TDI_KOD_IS_TARAF isTaraf, bool isSorumlu, int tarafId)
        {
            Taraf trf = new Taraf();

            trf.TARAF = taraf;
            trf.SIFAT = sifat;
            trf.CARI = cari;
            if (cari != null)
            {
                trf.Ad = cari.AD;
                trf.CariId = cari.ID;
            }
            if (sifat != null)
            {
                trf.SifatId = sifat.ID;
                trf.Sifat = sifat.SIFAT;
            }
            trf.Id = tarafId;
            trf.MainTable = modulTablo;
            trf.Table = taraf.TableName;
            trf.IS_TARAF = isTaraf;
            trf.IsSorumlu = isSorumlu;
            return trf;
        }

        public static Taraf GetTaraf(string modulTablo, Ent.AV001_TDI_BIL_CARI cari, Ent.TDI_KOD_SOZLESME_TARAF_SIFAT sifat, Ent.IEntity taraf, Ent.TDI_KOD_IS_TARAF isTaraf, bool isSorumlu, int tarafId)
        {
            Taraf trf = new Taraf();
            trf.SozlesmeTarafimi = true;

            trf.TARAF = taraf;
            trf.SozlesmeSifat = sifat;
            trf.CARI = cari;
            if (cari != null)
            {
                trf.Ad = cari.AD;
                trf.CariId = cari.ID;
            }
            if (sifat != null)
            {
                trf.SifatId = ConvertSozlesmeTarafToIsTaraf(sifat);
                trf.SozlesmeSifati = sifat.TARAF_SIFAT;
            }
            trf.Id = tarafId;
            trf.MainTable = modulTablo;
            trf.Table = taraf.TableName;
            trf.IS_TARAF = isTaraf;
            trf.IsSorumlu = isSorumlu;
            return trf;
        }

        public static List<Taraf> GetTaraf(Ent.IEntity Record)
        {
            string tableName = Record.TableName;
            switch (tableName)
            {
                case "AV001_TD_BIL_DAVA_NEDEN":
                    return GetAV001_TD_BIL_DAVA_NEDENTaraf((Ent.AV001_TD_BIL_DAVA_NEDEN)Record);
                    

                case "AV001_TD_BIL_FOY":
                    return GetAV001_TD_BIL_FOYTaraf((Ent.AV001_TD_BIL_FOY)Record);
                    

                case "AV001_TD_BIL_HAZIRLIK":
                    return GetAV001_TD_BIL_HAZIRLIKTaraf((Ent.AV001_TD_BIL_HAZIRLIK)Record);
                    

                case "AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN":
                    return GetAV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENTaraf((Ent.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN)Record);
                    

                case "AV001_TD_BIL_MAHKEME_HUKUM":
                    return GetAV001_TD_BIL_MAHKEME_HUKUMTaraf((Ent.AV001_TD_BIL_MAHKEME_HUKUM)Record);
                    

                case "AV001_TD_BIL_TEMYIZ":
                    return GetAV001_TD_BIL_TEMYIZTaraf((Ent.AV001_TD_BIL_TEMYIZ)Record);
                    

                case "AV001_TD_BIL_UZLASMA":
                    return GetAV001_TD_BIL_UZLASMATaraf((Ent.AV001_TD_BIL_UZLASMA)Record);
                    

                case "AV001_TDI_BIL_IHTIYATI_TEDBIR":
                    return GetAV001_TDI_BIL_IHTIYATI_TEDBIRTaraf((Ent.AV001_TDI_BIL_IHTIYATI_TEDBIR)Record);
                    

                case "AV001_TDI_BIL_IS":
                    return GetAV001_TDI_BIL_ISTaraf((Ent.AV001_TDI_BIL_IS)Record);
                    

                case "AV001_TDI_BIL_KIYMETLI_EVRAK":
                    return GetAV001_TDI_BIL_KIYMETLI_EVRAKTaraf((Ent.AV001_TDI_BIL_KIYMETLI_EVRAK)Record);
                    

                case "AV001_TDI_BIL_RUCU":
                    return GetAV001_TDI_BIL_RUCUTaraf((Ent.AV001_TDI_BIL_RUCU)Record);
                    

                case "AV001_TDI_BIL_SOZLESME":
                    return GetAV001_TDI_BIL_SOZLESMETaraf((Ent.AV001_TDI_BIL_SOZLESME)Record);
                    

                case "AV001_TDI_BIL_TEMINAT_MEKTUP":
                    return GetAV001_TDI_BIL_TEMINAT_MEKTUPTaraf((Ent.AV001_TDI_BIL_TEMINAT_MEKTUP)Record);
                    

                case "AV001_TDI_BIL_TEMSIL":
                    return GetAV001_TDI_BIL_TEMSILTaraf((Ent.AV001_TDI_BIL_TEMSIL)Record);
                    

                case "AV001_TDI_BIL_TESPIT":
                    return GetAV001_TDI_BIL_TESPITTaraf((Ent.AV001_TDI_BIL_TESPIT)Record);
                    

                case "AV001_TDIE_BIL_ASAMA":
                    return GetAV001_TDIE_BIL_ASAMATaraf((Ent.AV001_TDIE_BIL_ASAMA)Record);
                    

                case "AV001_TDIE_BIL_BELGE":
                    return GetAV001_TDIE_BIL_BELGETaraf((Ent.AV001_TDIE_BIL_BELGE)Record);
                    

                case "AV001_TI_BIL_ALACAK_NEDEN":
                    return GetAV001_TI_BIL_ALACAK_NEDENTaraf((Ent.AV001_TI_BIL_ALACAK_NEDEN)Record);
                    

                case "AV001_TI_BIL_DAVA_OZET":
                    return GetAV001_TI_BIL_DAVA_OZETTaraf((Ent.AV001_TI_BIL_DAVA_OZET)Record);
                    

                case "AV001_TI_BIL_FOY":
                    return GetAV001_TI_BIL_FOYTaraf((Ent.AV001_TI_BIL_FOY)Record);
                    

                case "AV001_TI_BIL_GAYRIMENKUL":
                    return GetAV001_TI_BIL_GAYRIMENKULTaraf((Ent.AV001_TI_BIL_GAYRIMENKUL)Record);
                    

                case "AV001_TI_BIL_IHTIYATI_HACIZ":
                    return GetAV001_TI_BIL_IHTIYATI_HACIZTaraf((Ent.AV001_TI_BIL_IHTIYATI_HACIZ)Record);
                    

                case "AV001_TDI_BIL_TEBLIGAT_MUHATAP":
                    return GetAV001_TDI_BIL_TEBLIGAT_MUHATAPTaraf((Ent.AV001_TDI_BIL_TEBLIGAT_MUHATAP)Record);
                    

                default:
                    return new List<Taraf>();
                    
            }
        }

        public static Ent.TList<Ent.AV001_TD_BIL_DAVA_NEDEN_TARAF> SetAV001_TD_BIL_DAVA_NEDENTaraf(List<Taraf> lstTrf, Ent.AV001_TD_BIL_DAVA_NEDEN Record)
        {
            Ent.TList<Ent.AV001_TD_BIL_DAVA_NEDEN_TARAF> lstTaraflar = new Ent.TList<Ent.AV001_TD_BIL_DAVA_NEDEN_TARAF>();
            Dt.AV001_TD_BIL_DAVA_NEDEN_TARAFProvider.DeepLoad(lstTaraflar, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));

            for (int i = 0; i < lstTrf.Count; i++)
            {
                if (lstTrf[i].IsSorumlu)
                {
                }
                else
                {
                    Ent.AV001_TD_BIL_DAVA_NEDEN_TARAF taraf = new Ent.AV001_TD_BIL_DAVA_NEDEN_TARAF();
                    taraf.TARAF_CARI_ID = lstTrf[i].CariId;
                    taraf.DAVA_NEDEN_ID = Record.ID;
                    taraf.TARAF_SIFAT_ID = lstTrf[i].SifatId;
                    lstTaraflar.Add(taraf);
                }
            }

            Record.AV001_TD_BIL_DAVA_NEDEN_TARAFCollection.AddRange(lstTaraflar);
            return lstTaraflar;
        }

        public static Ent.TList<Ent.AV001_TD_BIL_FOY_TARAF> SetAV001_TD_BIL_FOYTaraf(List<Taraf> lstTrf, Ent.AV001_TD_BIL_FOY Record)
        {
            Ent.TList<Ent.AV001_TD_BIL_FOY_TARAF> lstTaraflar = new Ent.TList<Ent.AV001_TD_BIL_FOY_TARAF>();
            Dt.AV001_TD_BIL_FOY_TARAFProvider.DeepLoad(lstTaraflar, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<Ent.AV001_TD_BIL_FOY_SORUMLU_AVUKAT> lstSorumlular = new TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT>();
            Dt.AV001_TD_BIL_FOY_SORUMLU_AVUKATProvider.DeepLoad(lstSorumlular, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));

            for (int i = 0; i < lstTrf.Count; i++)
            {
                if (lstTrf[i].IsSorumlu)
                {
                    Ent.AV001_TD_BIL_FOY_SORUMLU_AVUKAT sorumlusu = new Ent.AV001_TD_BIL_FOY_SORUMLU_AVUKAT();
                    sorumlusu.SORUMLU_AVUKAT_CARI_ID = lstTrf[i].CariId;
                    sorumlusu.DAVA_FOY_ID = Record.ID;

                    lstSorumlular.Add(sorumlusu);
                }
                else
                {
                    Ent.AV001_TD_BIL_FOY_TARAF taraf = new Ent.AV001_TD_BIL_FOY_TARAF();
                    taraf.CARI_ID = lstTrf[i].CariId;
                    taraf.DAVA_FOY_ID = Record.ID;
                    taraf.TARAF_SIFAT_ID = lstTrf[i].SifatId;
                    lstTaraflar.Add(taraf);
                }
            }

            Record.AV001_TD_BIL_FOY_TARAFCollection.AddRange(lstTaraflar);
            return lstTaraflar;
        }

        public static Ent.TList<Ent.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAF> SetAV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENTaraf(List<Taraf> lstTrf, Ent.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN Record)
        {
            Ent.TList<Ent.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAF> lstTaraflar = new Ent.TList<Ent.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAF>();
            Dt.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAFProvider.DeepLoad(lstTaraflar, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));

            for (int i = 0; i < lstTrf.Count; i++)
            {
                if (lstTrf[i].IsSorumlu)
                {
                }
                else
                {
                    Ent.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAF taraf = new Ent.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAF();
                    taraf.TARAF_CARI_ID = lstTrf[i].CariId;
                    taraf.SIKAYET_NEDEN_ID = Record.ID;
                    taraf.TARAF_SIFAT_ID = lstTrf[i].SifatId;
                    lstTaraflar.Add(taraf);
                }
            }

            Record.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAFCollection.AddRange(lstTaraflar);
            return lstTaraflar;
        }

        public static Ent.TList<Ent.AV001_TD_BIL_HAZIRLIK_TARAF> SetAV001_TD_BIL_HAZIRLIKTaraf(List<Taraf> lstTrf, Ent.AV001_TD_BIL_HAZIRLIK Record)
        {
            Ent.TList<Ent.AV001_TD_BIL_HAZIRLIK_TARAF> lstTaraflar = new Ent.TList<Ent.AV001_TD_BIL_HAZIRLIK_TARAF>();
            Dt.AV001_TD_BIL_HAZIRLIK_TARAFProvider.DeepLoad(lstTaraflar, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<Ent.AV001_TD_BIL_HAZIRLIK_SORUMLU> lstSorumlular = new TList<AV001_TD_BIL_HAZIRLIK_SORUMLU>();
            Dt.AV001_TD_BIL_HAZIRLIK_SORUMLUProvider.DeepLoad(lstSorumlular, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));

            for (int i = 0; i < lstTrf.Count; i++)
            {
                if (lstTrf[i].IsSorumlu)
                {
                    Ent.AV001_TD_BIL_HAZIRLIK_SORUMLU sorumlusu = new Ent.AV001_TD_BIL_HAZIRLIK_SORUMLU();
                    sorumlusu.CARI_ID = lstTrf[i].CariId;
                    sorumlusu.HAZIRLIK_ID = Record.ID;

                    lstSorumlular.Add(sorumlusu);
                }
                else
                {
                    Ent.AV001_TD_BIL_HAZIRLIK_TARAF taraf = new Ent.AV001_TD_BIL_HAZIRLIK_TARAF();
                    taraf.CARI_ID = lstTrf[i].CariId;
                    taraf.HAZIRLIK_ID = Record.ID;
                    taraf.TARAF_SIFAT_ID = lstTrf[i].SifatId;
                    lstTaraflar.Add(taraf);
                }
            }

            Record.AV001_TD_BIL_HAZIRLIK_TARAFCollection.AddRange(lstTaraflar);
            return lstTaraflar;
        }

        public static Ent.TList<Ent.AV001_TD_BIL_MAHKEME_HUKUM_TARAF> SetAV001_TD_BIL_MAHKEME_HUKUMTaraf(List<Taraf> lstTrf, Ent.AV001_TD_BIL_MAHKEME_HUKUM Record)
        {
            Ent.TList<Ent.AV001_TD_BIL_MAHKEME_HUKUM_TARAF> lstTaraflar = new Ent.TList<Ent.AV001_TD_BIL_MAHKEME_HUKUM_TARAF>();
            Dt.AV001_TD_BIL_MAHKEME_HUKUM_TARAFProvider.DeepLoad(lstTaraflar, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));

            for (int i = 0; i < lstTrf.Count; i++)
            {
                if (lstTrf[i].IsSorumlu)
                {
                }
                else
                {
                    Ent.AV001_TD_BIL_MAHKEME_HUKUM_TARAF taraf = new Ent.AV001_TD_BIL_MAHKEME_HUKUM_TARAF();
                    taraf.TARAF_CARI_ID = lstTrf[i].CariId;
                    taraf.MAHKEME_HUKUM_ID = Record.ID;
                    lstTaraflar.Add(taraf);
                }
            }

            Record.AV001_TD_BIL_MAHKEME_HUKUM_TARAFCollection.AddRange(lstTaraflar);
            return lstTaraflar;
        }

        public static Ent.TList<Ent.AV001_TD_BIL_TEMYIZ_TARAF> SetAV001_TD_BIL_TEMYIZTaraf(List<Taraf> lstTrf, Ent.AV001_TD_BIL_TEMYIZ Record)
        {
            Ent.TList<Ent.AV001_TD_BIL_TEMYIZ_TARAF> lstTaraflar = new Ent.TList<Ent.AV001_TD_BIL_TEMYIZ_TARAF>();
            Dt.AV001_TD_BIL_TEMYIZ_TARAFProvider.DeepLoad(lstTaraflar, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));

            for (int i = 0; i < lstTrf.Count; i++)
            {
                if (lstTrf[i].IsSorumlu)
                {
                }
                else
                {
                    Ent.AV001_TD_BIL_TEMYIZ_TARAF taraf = new Ent.AV001_TD_BIL_TEMYIZ_TARAF();
                    taraf.CARI_ID = lstTrf[i].CariId;
                    taraf.TEMYIZ_ID = Record.ID;
                    lstTaraflar.Add(taraf);
                }
            }

            Record.AV001_TD_BIL_TEMYIZ_TARAFCollection.AddRange(lstTaraflar);
            return lstTaraflar;
        }

        public static Ent.TList<Ent.AV001_TD_BIL_UZLASMA_TARAF> SetAV001_TD_BIL_UZLASMATaraf(List<Taraf> lstTrf, Ent.AV001_TD_BIL_UZLASMA Record)
        {
            Ent.TList<Ent.AV001_TD_BIL_UZLASMA_TARAF> lstTaraflar = new Ent.TList<Ent.AV001_TD_BIL_UZLASMA_TARAF>();
            Dt.AV001_TD_BIL_UZLASMA_TARAFProvider.DeepLoad(lstTaraflar, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));

            for (int i = 0; i < lstTrf.Count; i++)
            {
                if (lstTrf[i].IsSorumlu)
                {
                }
                else
                {
                    Ent.AV001_TD_BIL_UZLASMA_TARAF taraf = new Ent.AV001_TD_BIL_UZLASMA_TARAF();
                    taraf.TARAF_CARI_ID = lstTrf[i].CariId;
                    taraf.UZLASMA_ID = Record.ID;
                    taraf.TARAF_SIFAT_ID = lstTrf[i].SifatId;
                    lstTaraflar.Add(taraf);
                }
            }

            Record.AV001_TD_BIL_UZLASMA_TARAFCollection.AddRange(lstTaraflar);
            return lstTaraflar;
        }

        public static Ent.TList<Ent.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF> SetAV001_TDI_BIL_IHTIYATI_TEDBIRTaraf(List<Taraf> lstTrf, Ent.AV001_TDI_BIL_IHTIYATI_TEDBIR Record)
        {
            Ent.TList<Ent.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF> lstTaraflar = new Ent.TList<Ent.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF>();
            Dt.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFProvider.DeepLoad(lstTaraflar, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));

            for (int i = 0; i < lstTrf.Count; i++)
            {
                if (lstTrf[i].IsSorumlu)
                {
                }
                else
                {
                    Ent.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF taraf = new Ent.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF();
                    taraf.ICRA_CARI_TARAF_ID = lstTrf[i].CariId;
                    taraf.IHTIYATI_TEDBIR_ID = Record.ID;
                    taraf.ICRA_TARAF_SIFAT_ID = lstTrf[i].SifatId;
                    lstTaraflar.Add(taraf);
                }
            }

            Record.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection.AddRange(lstTaraflar);
            return lstTaraflar;
        }

        public static Ent.TList<Ent.AV001_TDI_BIL_IS_TARAF> SetAV001_TDI_BIL_ISTaraf(List<Taraf> lstTrf, Ent.AV001_TDI_BIL_IS Record)
        {
            Ent.TList<Ent.AV001_TDI_BIL_IS_TARAF> lstTaraflar = new Ent.TList<Ent.AV001_TDI_BIL_IS_TARAF>();
            Dt.AV001_TDI_BIL_IS_TARAFProvider.DeepLoad(lstTaraflar, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));

            for (int i = 0; i < lstTrf.Count; i++)
            {
                if (lstTrf[i].IsSorumlu)
                {
                }
                else
                {
                    Ent.AV001_TDI_BIL_IS_TARAF taraf = new Ent.AV001_TDI_BIL_IS_TARAF();
                    taraf.CARI_ID = lstTrf[i].CariId;
                    taraf.IS_ID = Record.ID;
                    taraf.IS_TARAF_ID = lstTrf[i].SifatId;
                    lstTaraflar.Add(taraf);
                }
            }

            Record.AV001_TDI_BIL_IS_TARAFCollection.AddRange(lstTaraflar);
            return lstTaraflar;
        }

        public static Ent.TList<Ent.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF> SetAV001_TDI_BIL_KIYMETLI_EVRAKTaraf(List<Taraf> lstTrf, Ent.AV001_TDI_BIL_KIYMETLI_EVRAK Record)
        {
            Ent.TList<Ent.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF> lstTaraflar = new Ent.TList<Ent.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF>();
            Dt.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFProvider.DeepLoad(lstTaraflar, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));

            for (int i = 0; i < lstTrf.Count; i++)
            {
                if (lstTrf[i].IsSorumlu)
                {
                }
                else
                {
                    Ent.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF taraf = new Ent.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF();
                    taraf.TARAF_CARI_ID = lstTrf[i].CariId;
                    taraf.KIYMETLI_EVRAK_ID = Record.ID;
                    lstTaraflar.Add(taraf);
                }
            }

            Record.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection.AddRange(lstTaraflar);
            return lstTaraflar;
        }

        public static Ent.TList<Ent.AV001_TDI_BIL_RUCU_TARAF> SetAV001_TDI_BIL_RUCUTaraf(List<Taraf> lstTrf, Ent.AV001_TDI_BIL_RUCU Record)
        {
            Ent.TList<Ent.AV001_TDI_BIL_RUCU_TARAF> lstTaraflar = new Ent.TList<Ent.AV001_TDI_BIL_RUCU_TARAF>();
            Dt.AV001_TDI_BIL_RUCU_TARAFProvider.DeepLoad(lstTaraflar, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<Ent.AV001_TDI_BIL_RUCU_SORUMLU> lstSorumlular = new TList<AV001_TDI_BIL_RUCU_SORUMLU>();
            Dt.AV001_TDI_BIL_RUCU_SORUMLUProvider.DeepLoad(lstSorumlular, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));

            for (int i = 0; i < lstTrf.Count; i++)
            {
                if (lstTrf[i].IsSorumlu)
                {
                    Ent.AV001_TDI_BIL_RUCU_SORUMLU sorumlusu = new Ent.AV001_TDI_BIL_RUCU_SORUMLU();
                    sorumlusu.CARI_ID = lstTrf[i].CariId;
                    sorumlusu.RUCU_ID = Record.ID;

                    lstSorumlular.Add(sorumlusu);
                }
                else
                {
                    Ent.AV001_TDI_BIL_RUCU_TARAF taraf = new Ent.AV001_TDI_BIL_RUCU_TARAF();
                    taraf.CARI_ID = lstTrf[i].CariId;
                    taraf.RUCU_ID = Record.ID;
                    taraf.TARAF_SIFAT_ID = lstTrf[i].SifatId;
                    lstTaraflar.Add(taraf);
                }
            }

            Record.AV001_TDI_BIL_RUCU_TARAFCollection.AddRange(lstTaraflar);
            return lstTaraflar;
        }

        public static Ent.TList<Ent.AV001_TDI_BIL_SOZLESME_TARAF> SetAV001_TDI_BIL_SOZLESMETaraf(List<Taraf> lstTrf, Ent.AV001_TDI_BIL_SOZLESME Record)
        {
            Ent.TList<Ent.AV001_TDI_BIL_SOZLESME_TARAF> lstTaraflar = new Ent.TList<Ent.AV001_TDI_BIL_SOZLESME_TARAF>();
            Dt.AV001_TDI_BIL_SOZLESME_TARAFProvider.DeepLoad(lstTaraflar, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<Ent.AV001_TDI_BIL_SOZLESME_SORUMLU> lstSorumlular = new TList<AV001_TDI_BIL_SOZLESME_SORUMLU>();
            Dt.AV001_TDI_BIL_SOZLESME_SORUMLUProvider.DeepLoad(lstSorumlular, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));

            for (int i = 0; i < lstTrf.Count; i++)
            {
                if (lstTrf[i].IsSorumlu)
                {
                    Ent.AV001_TDI_BIL_SOZLESME_SORUMLU sorumlusu = new Ent.AV001_TDI_BIL_SOZLESME_SORUMLU();
                    sorumlusu.SORUMLU_CARI_ID = lstTrf[i].CariId;
                    sorumlusu.SOZLESME_ID = Record.ID;

                    lstSorumlular.Add(sorumlusu);
                }
                else
                {
                    Ent.AV001_TDI_BIL_SOZLESME_TARAF taraf = new Ent.AV001_TDI_BIL_SOZLESME_TARAF();
                    taraf.CARI_ID = lstTrf[i].CariId;
                    taraf.SOZLESME_ID = Record.ID;
                    taraf.TARAF_SIFAT_ID = lstTrf[i].SifatId;
                    lstTaraflar.Add(taraf);
                }
            }

            Record.AV001_TDI_BIL_SOZLESME_TARAFCollection.AddRange(lstTaraflar);
            return lstTaraflar;
        }

        public static Ent.TList<Ent.AV001_TDI_BIL_TEMINAT_MEKTUP_TARAF> SetAV001_TDI_BIL_TEMINAT_MEKTUPTaraf(List<Taraf> lstTrf, Ent.AV001_TDI_BIL_TEMINAT_MEKTUP Record)
        {
            Ent.TList<Ent.AV001_TDI_BIL_TEMINAT_MEKTUP_TARAF> lstTaraflar = new Ent.TList<Ent.AV001_TDI_BIL_TEMINAT_MEKTUP_TARAF>();
            Dt.AV001_TDI_BIL_TEMINAT_MEKTUP_TARAFProvider.DeepLoad(lstTaraflar, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));

            for (int i = 0; i < lstTrf.Count; i++)
            {
                if (lstTrf[i].IsSorumlu)
                {
                }
                else
                {
                    Ent.AV001_TDI_BIL_TEMINAT_MEKTUP_TARAF taraf = new Ent.AV001_TDI_BIL_TEMINAT_MEKTUP_TARAF();
                    taraf.TARAF_CARI_ID = lstTrf[i].CariId;
                    taraf.TEMINAT_MEKTUP_ID = Record.ID;
                    lstTaraflar.Add(taraf);
                }
            }

            Record.AV001_TDI_BIL_TEMINAT_MEKTUP_TARAFCollection.AddRange(lstTaraflar);
            return lstTaraflar;
        }

        public static Ent.TList<Ent.AV001_TDI_BIL_TEMSIL_TARAF> SetAV001_TDI_BIL_TEMSILTaraf(List<Taraf> lstTrf, Ent.AV001_TDI_BIL_TEMSIL Record)
        {
            Ent.TList<Ent.AV001_TDI_BIL_TEMSIL_TARAF> lstTaraflar = new Ent.TList<Ent.AV001_TDI_BIL_TEMSIL_TARAF>();
            Dt.AV001_TDI_BIL_TEMSIL_TARAFProvider.DeepLoad(lstTaraflar, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));

            for (int i = 0; i < lstTrf.Count; i++)
            {
                if (lstTrf[i].IsSorumlu)
                {
                }
                else
                {
                    Ent.AV001_TDI_BIL_TEMSIL_TARAF taraf = new Ent.AV001_TDI_BIL_TEMSIL_TARAF();
                    taraf.TARAF_CARI_ID = lstTrf[i].CariId;
                    taraf.TEMSIL_ID = Record.ID;
                    lstTaraflar.Add(taraf);
                }
            }

            Record.AV001_TDI_BIL_TEMSIL_TARAFCollection.AddRange(lstTaraflar);
            return lstTaraflar;
        }

        public static Ent.TList<Ent.AV001_TDI_BIL_TESPIT_TARAF> SetAV001_TDI_BIL_TESPITTaraf(List<Taraf> lstTrf, Ent.AV001_TDI_BIL_TESPIT Record)
        {
            Ent.TList<Ent.AV001_TDI_BIL_TESPIT_TARAF> lstTaraflar = new Ent.TList<Ent.AV001_TDI_BIL_TESPIT_TARAF>();
            Dt.AV001_TDI_BIL_TESPIT_TARAFProvider.DeepLoad(lstTaraflar, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));

            for (int i = 0; i < lstTrf.Count; i++)
            {
                if (lstTrf[i].IsSorumlu)
                {
                }
                else
                {
                    Ent.AV001_TDI_BIL_TESPIT_TARAF taraf = new Ent.AV001_TDI_BIL_TESPIT_TARAF();
                    taraf.TESPIT_YAPILAN_TARAF_ID = lstTrf[i].CariId;
                    taraf.TESPIT_ID = Record.ID;
                    lstTaraflar.Add(taraf);
                }
            }

            Record.AV001_TDI_BIL_TESPIT_TARAFCollection.AddRange(lstTaraflar);
            return lstTaraflar;
        }

        public static Ent.TList<Ent.AV001_TDIE_BIL_ASAMA_TARAF> SetAV001_TDIE_BIL_ASAMATaraf(List<Taraf> lstTrf, Ent.AV001_TDIE_BIL_ASAMA Record)
        {
            Ent.TList<Ent.AV001_TDIE_BIL_ASAMA_TARAF> lstTaraflar = new Ent.TList<Ent.AV001_TDIE_BIL_ASAMA_TARAF>();
            Dt.AV001_TDIE_BIL_ASAMA_TARAFProvider.DeepLoad(lstTaraflar, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<Ent.AV001_TDIE_BIL_ASAMA_SORUMLU> lstSorumlular = new TList<AV001_TDIE_BIL_ASAMA_SORUMLU>();
            Dt.AV001_TDIE_BIL_ASAMA_SORUMLUProvider.DeepLoad(lstSorumlular, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));

            for (int i = 0; i < lstTrf.Count; i++)
            {
                if (lstTrf[i].IsSorumlu)
                {
                    Ent.AV001_TDIE_BIL_ASAMA_SORUMLU sorumlusu = new Ent.AV001_TDIE_BIL_ASAMA_SORUMLU();
                    sorumlusu.CARI_ID = lstTrf[i].CariId;
                    sorumlusu.ASAMA_ID = Record.ID;

                    lstSorumlular.Add(sorumlusu);
                }
                else
                {
                    Ent.AV001_TDIE_BIL_ASAMA_TARAF taraf = new Ent.AV001_TDIE_BIL_ASAMA_TARAF();
                    taraf.CARI_ID = lstTrf[i].CariId;
                    taraf.ASAMA_ID = Record.ID;
                    taraf.SIFAT_ID = lstTrf[i].SifatId;
                    lstTaraflar.Add(taraf);
                }
            }

            Record.AV001_TDIE_BIL_ASAMA_TARAFCollection.AddRange(lstTaraflar);
            return lstTaraflar;
        }

        public static Ent.TList<Ent.AV001_TDIE_BIL_BELGE_TARAF> SetAV001_TDIE_BIL_BELGETaraf(List<Taraf> lstTrf, Ent.AV001_TDIE_BIL_BELGE Record)
        {
            Ent.TList<Ent.AV001_TDIE_BIL_BELGE_TARAF> lstTaraflar = new Ent.TList<Ent.AV001_TDIE_BIL_BELGE_TARAF>();
            Dt.AV001_TDIE_BIL_BELGE_TARAFProvider.DeepLoad(lstTaraflar, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<Ent.AV001_TDIE_BIL_BELGE_SORUMLU> lstSorumlular = new TList<AV001_TDIE_BIL_BELGE_SORUMLU>();
            Dt.AV001_TDIE_BIL_BELGE_SORUMLUProvider.DeepLoad(lstSorumlular, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));

            for (int i = 0; i < lstTrf.Count; i++)
            {
                if (lstTrf[i].IsSorumlu)
                {
                    Ent.AV001_TDIE_BIL_BELGE_SORUMLU sorumlusu = new Ent.AV001_TDIE_BIL_BELGE_SORUMLU();
                    sorumlusu.CARI_ID = lstTrf[i].CariId;
                    sorumlusu.BELGE_ID = Record.ID;

                    lstSorumlular.Add(sorumlusu);
                }
                else
                {
                    if (!Record.AV001_TDIE_BIL_BELGE_TARAFCollection.Exists(vi => vi.CARI_ID == lstTrf[i].CariId))
                    {
                        Ent.AV001_TDIE_BIL_BELGE_TARAF taraf = new Ent.AV001_TDIE_BIL_BELGE_TARAF();
                        taraf.CARI_ID = lstTrf[i].CariId;
                        taraf.BELGE_ID = Record.ID;
                        taraf.KODU = lstTrf[i].Kodu;
                        taraf.SIFAT_ID = lstTrf[i].SifatId;
                        lstTaraflar.Add(taraf);
                    }
                }
            }

            Record.AV001_TDIE_BIL_BELGE_TARAFCollection.AddRange(lstTaraflar);
            return lstTaraflar;
        }

        public static Ent.TList<Ent.AV001_TDIE_BIL_PROJE_TARAF> SetAV001_TDIE_BIL_PROJETaraf(List<Taraf> lstTrf, Ent.AV001_TDIE_BIL_PROJE Record)
        {
            Ent.TList<Ent.AV001_TDIE_BIL_PROJE_TARAF> lstTaraflar = new Ent.TList<Ent.AV001_TDIE_BIL_PROJE_TARAF>();
            Dt.AV001_TDIE_BIL_PROJE_TARAFProvider.DeepLoad(lstTaraflar, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<Ent.AV001_TDIE_BIL_PROJE_SORUMLU> lstSorumlular = new TList<AV001_TDIE_BIL_PROJE_SORUMLU>();
            Dt.AV001_TDIE_BIL_PROJE_SORUMLUProvider.DeepLoad(lstSorumlular, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));

            for (int i = 0; i < lstTrf.Count; i++)
            {
                if (lstTrf[i].IsSorumlu)
                {
                    Ent.AV001_TDIE_BIL_PROJE_SORUMLU sorumlusu = new Ent.AV001_TDIE_BIL_PROJE_SORUMLU();
                    sorumlusu.CARI_ID = lstTrf[i].CariId;
                    sorumlusu.PROJE_ID = Record.ID;

                    lstSorumlular.Add(sorumlusu);
                }
                else
                {
                    Ent.AV001_TDIE_BIL_PROJE_TARAF taraf = new Ent.AV001_TDIE_BIL_PROJE_TARAF();
                    taraf.CARI_ID = lstTrf[i].CariId;
                    taraf.PROJE_ID = Record.ID;
                    lstTaraflar.Add(taraf);
                }
            }

            Record.AV001_TDIE_BIL_PROJE_TARAFCollection.AddRange(lstTaraflar);
            return lstTaraflar;
        }

        public static Ent.TList<Ent.AV001_TI_BIL_ALACAK_NEDEN_TARAF> SetAV001_TI_BIL_ALACAK_NEDENTaraf(List<Taraf> lstTrf, Ent.AV001_TI_BIL_ALACAK_NEDEN Record)
        {
            Ent.TList<Ent.AV001_TI_BIL_ALACAK_NEDEN_TARAF> lstTaraflar = new Ent.TList<Ent.AV001_TI_BIL_ALACAK_NEDEN_TARAF>();
            Dt.AV001_TI_BIL_ALACAK_NEDEN_TARAFProvider.DeepLoad(lstTaraflar, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));

            for (int i = 0; i < lstTrf.Count; i++)
            {
                if (lstTrf[i].IsSorumlu)
                {
                }
                else
                {
                    Ent.AV001_TI_BIL_ALACAK_NEDEN_TARAF taraf = new Ent.AV001_TI_BIL_ALACAK_NEDEN_TARAF();
                    taraf.TARAF_CARI_ID = lstTrf[i].CariId;
                    taraf.ICRA_ALACAK_NEDEN_ID = Record.ID;
                    taraf.TARAF_SIFAT_ID = lstTrf[i].SifatId;
                    lstTaraflar.Add(taraf);
                }
            }

            Record.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.AddRange(lstTaraflar);
            return lstTaraflar;
        }

        public static Ent.TList<Ent.AV001_TI_BIL_DAVA_OZET_TARAF> SetAV001_TI_BIL_DAVA_OZETTaraf(List<Taraf> lstTrf, Ent.AV001_TI_BIL_DAVA_OZET Record)
        {
            Ent.TList<Ent.AV001_TI_BIL_DAVA_OZET_TARAF> lstTaraflar = new Ent.TList<Ent.AV001_TI_BIL_DAVA_OZET_TARAF>();
            Dt.AV001_TI_BIL_DAVA_OZET_TARAFProvider.DeepLoad(lstTaraflar, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));

            for (int i = 0; i < lstTrf.Count; i++)
            {
                if (lstTrf[i].IsSorumlu)
                {
                }
                else
                {
                    Ent.AV001_TI_BIL_DAVA_OZET_TARAF taraf = new Ent.AV001_TI_BIL_DAVA_OZET_TARAF();
                    taraf.DAVA_TARAF_ID = lstTrf[i].CariId;
                    taraf.DAVA_OZET_ID = Record.ID;
                    taraf.DAVA_TARAF_SIFAT_ID = lstTrf[i].SifatId;
                    lstTaraflar.Add(taraf);
                }
            }

            Record.AV001_TI_BIL_DAVA_OZET_TARAFCollection.AddRange(lstTaraflar);
            return lstTaraflar;
        }

        public static Ent.TList<Ent.AV001_TI_BIL_FOY_TARAF> SetAV001_TI_BIL_FOYTaraf(List<Taraf> lstTrf, Ent.AV001_TI_BIL_FOY Record)
        {
            Ent.TList<Ent.AV001_TI_BIL_FOY_TARAF> lstTaraflar = new Ent.TList<Ent.AV001_TI_BIL_FOY_TARAF>();
            Dt.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(lstTaraflar, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));
            TList<Ent.AV001_TI_BIL_FOY_SORUMLU_AVUKAT> lstSorumlular = new TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>();
            Dt.AV001_TI_BIL_FOY_SORUMLU_AVUKATProvider.DeepLoad(lstSorumlular, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));

            for (int i = 0; i < lstTrf.Count; i++)
            {
                if (lstTrf[i].IsSorumlu)
                {
                    Ent.AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumlusu = new Ent.AV001_TI_BIL_FOY_SORUMLU_AVUKAT();
                    sorumlusu.SORUMLU_AVUKAT_CARI_ID = lstTrf[i].CariId;
                    sorumlusu.ICRA_FOY_ID = Record.ID;

                    lstSorumlular.Add(sorumlusu);
                }
                else
                {
                    Ent.AV001_TI_BIL_FOY_TARAF taraf = new Ent.AV001_TI_BIL_FOY_TARAF();
                    taraf.CARI_ID = lstTrf[i].CariId;
                    taraf.ICRA_FOY_ID = Record.ID;
                    taraf.TARAF_SIFAT_ID = lstTrf[i].SifatId;
                    lstTaraflar.Add(taraf);
                }
            }

            Record.AV001_TI_BIL_FOY_TARAFCollection.AddRange(lstTaraflar);
            return lstTaraflar;
        }

        public static Ent.TList<Ent.AV001_TI_BIL_GAYRIMENKUL_TARAF> SetAV001_TI_BIL_GAYRIMENKULTaraf(List<Taraf> lstTrf, Ent.AV001_TI_BIL_GAYRIMENKUL Record)
        {
            Ent.TList<Ent.AV001_TI_BIL_GAYRIMENKUL_TARAF> lstTaraflar = new Ent.TList<Ent.AV001_TI_BIL_GAYRIMENKUL_TARAF>();
            Dt.AV001_TI_BIL_GAYRIMENKUL_TARAFProvider.DeepLoad(lstTaraflar, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));

            for (int i = 0; i < lstTrf.Count; i++)
            {
                if (lstTrf[i].IsSorumlu)
                {
                }
                else
                {
                    Ent.AV001_TI_BIL_GAYRIMENKUL_TARAF taraf = new Ent.AV001_TI_BIL_GAYRIMENKUL_TARAF();
                    taraf.TARAF_CARI_ID = lstTrf[i].CariId;
                    taraf.GAYRI_MENKUL_ID = Record.ID;
                    lstTaraflar.Add(taraf);
                }
            }

            Record.AV001_TI_BIL_GAYRIMENKUL_TARAFCollection.AddRange(lstTaraflar);
            return lstTaraflar;
        }

        public static Ent.TList<Ent.AV001_TI_BIL_IHTIYATI_HACIZ_TARAF> SetAV001_TI_BIL_IHTIYATI_HACIZTaraf(List<Taraf> lstTrf, Ent.AV001_TI_BIL_IHTIYATI_HACIZ Record)
        {
            Ent.TList<Ent.AV001_TI_BIL_IHTIYATI_HACIZ_TARAF> lstTaraflar = new Ent.TList<Ent.AV001_TI_BIL_IHTIYATI_HACIZ_TARAF>();
            Dt.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFProvider.DeepLoad(lstTaraflar, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT), typeof(TDI_KOD_IS_TARAF));

            for (int i = 0; i < lstTrf.Count; i++)
            {
                if (lstTrf[i].IsSorumlu)
                {
                }
                else
                {
                    Ent.AV001_TI_BIL_IHTIYATI_HACIZ_TARAF taraf = new Ent.AV001_TI_BIL_IHTIYATI_HACIZ_TARAF();
                    taraf.ICRA_CARI_TARAF_ID = lstTrf[i].CariId;
                    taraf.IHTIYATI_HACIZ_ID = Record.ID;
                    taraf.TARAF_SIFAT_ID = lstTrf[i].SifatId;
                    lstTaraflar.Add(taraf);
                }
            }

            Record.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection.AddRange(lstTaraflar);
            return lstTaraflar;
        }

        public static object SetTaraf(List<Taraf> lstTrf, Ent.IEntity Record)
        {
            string tableName = Record.TableName;
            switch (tableName)
            {
                case "AV001_TD_BIL_DAVA_NEDEN":
                    return SetAV001_TD_BIL_DAVA_NEDENTaraf(lstTrf, (Ent.AV001_TD_BIL_DAVA_NEDEN)Record);
                    

                case "AV001_TD_BIL_FOY":
                    return SetAV001_TD_BIL_FOYTaraf(lstTrf, (Ent.AV001_TD_BIL_FOY)Record);
                    

                case "AV001_TD_BIL_HAZIRLIK":
                    return SetAV001_TD_BIL_HAZIRLIKTaraf(lstTrf, (Ent.AV001_TD_BIL_HAZIRLIK)Record);
                    

                case "AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN":
                    return SetAV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENTaraf(lstTrf, (Ent.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN)Record);
                    

                case "AV001_TD_BIL_MAHKEME_HUKUM":
                    return SetAV001_TD_BIL_MAHKEME_HUKUMTaraf(lstTrf, (Ent.AV001_TD_BIL_MAHKEME_HUKUM)Record);
                    

                case "AV001_TD_BIL_TEMYIZ":
                    return SetAV001_TD_BIL_TEMYIZTaraf(lstTrf, (Ent.AV001_TD_BIL_TEMYIZ)Record);
                    

                case "AV001_TD_BIL_UZLASMA":
                    return SetAV001_TD_BIL_UZLASMATaraf(lstTrf, (Ent.AV001_TD_BIL_UZLASMA)Record);
                    

                case "AV001_TDI_BIL_IHTIYATI_TEDBIR":
                    return SetAV001_TDI_BIL_IHTIYATI_TEDBIRTaraf(lstTrf, (Ent.AV001_TDI_BIL_IHTIYATI_TEDBIR)Record);
                    

                case "AV001_TDI_BIL_IS":
                    return SetAV001_TDI_BIL_ISTaraf(lstTrf, (Ent.AV001_TDI_BIL_IS)Record);
                    

                case "AV001_TDI_BIL_KIYMETLI_EVRAK":
                    return SetAV001_TDI_BIL_KIYMETLI_EVRAKTaraf(lstTrf, (Ent.AV001_TDI_BIL_KIYMETLI_EVRAK)Record);
                    

                case "AV001_TDI_BIL_RUCU":
                    return SetAV001_TDI_BIL_RUCUTaraf(lstTrf, (Ent.AV001_TDI_BIL_RUCU)Record);
                    

                case "AV001_TDI_BIL_SOZLESME":
                    return SetAV001_TDI_BIL_SOZLESMETaraf(lstTrf, (Ent.AV001_TDI_BIL_SOZLESME)Record);
                    

                case "AV001_TDI_BIL_TEMINAT_MEKTUP":
                    return SetAV001_TDI_BIL_TEMINAT_MEKTUPTaraf(lstTrf, (Ent.AV001_TDI_BIL_TEMINAT_MEKTUP)Record);
                    

                case "AV001_TDI_BIL_TEMSIL":
                    return SetAV001_TDI_BIL_TEMSILTaraf(lstTrf, (Ent.AV001_TDI_BIL_TEMSIL)Record);
                    

                case "AV001_TDI_BIL_TESPIT":
                    return SetAV001_TDI_BIL_TESPITTaraf(lstTrf, (Ent.AV001_TDI_BIL_TESPIT)Record);
                    

                case "AV001_TDIE_BIL_ASAMA":
                    return SetAV001_TDIE_BIL_ASAMATaraf(lstTrf, (Ent.AV001_TDIE_BIL_ASAMA)Record);
                    

                case "AV001_TDIE_BIL_BELGE":
                    return SetAV001_TDIE_BIL_BELGETaraf(lstTrf, (Ent.AV001_TDIE_BIL_BELGE)Record);
                    

                case "AV001_TDIE_BIL_PROJE":
                    return SetAV001_TDIE_BIL_PROJETaraf(lstTrf, (Ent.AV001_TDIE_BIL_PROJE)Record);
                    

                case "AV001_TI_BIL_ALACAK_NEDEN":
                    return SetAV001_TI_BIL_ALACAK_NEDENTaraf(lstTrf, (Ent.AV001_TI_BIL_ALACAK_NEDEN)Record);
                    

                case "AV001_TI_BIL_DAVA_OZET":
                    return SetAV001_TI_BIL_DAVA_OZETTaraf(lstTrf, (Ent.AV001_TI_BIL_DAVA_OZET)Record);
                    

                case "AV001_TI_BIL_FOY":
                    return SetAV001_TI_BIL_FOYTaraf(lstTrf, (Ent.AV001_TI_BIL_FOY)Record);
                    

                case "AV001_TI_BIL_GAYRIMENKUL":
                    return SetAV001_TI_BIL_GAYRIMENKULTaraf(lstTrf, (Ent.AV001_TI_BIL_GAYRIMENKUL)Record);
                    

                case "AV001_TI_BIL_IHTIYATI_HACIZ":
                    return SetAV001_TI_BIL_IHTIYATI_HACIZTaraf(lstTrf, (Ent.AV001_TI_BIL_IHTIYATI_HACIZ)Record);
                    

                default:
                    return new List<Taraf>();
                    
            }
        }
    }
}