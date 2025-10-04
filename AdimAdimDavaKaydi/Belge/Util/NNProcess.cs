using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AdimAdimDavaKaydi.Belge.Util
{
    public class NNProcess
    {
        public static List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE> GetBelgeler(IEntity record, bool direkBaglimi)
        {
            if (record == null)
            {
                return new List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE>();
            }
            string Tablo = record.TableName;
            List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE> belgeList = new List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE>();
            switch (Tablo)
            {
                case "AV001_TD_BIL_ARA_KARAR":
                    break;

                case "AV001_TDIE_BIL_BELGE":
                    foreach (NN_BELGE_BELGE nn in DataRepository.NN_BELGE_BELGEProvider.GetByBELGE_ID(((AV001_TDIE_BIL_BELGE)record).ID))
                        belgeList.Add(BelgeUtil.Inits._BelgeGetir != null ? BelgeUtil.Inits._BelgeGetir.Single(item => item.ID == nn.TO_BELGE_ID) : BelgeUtil.Inits.context.per_AV001_TDIE_BIL_BELGEs.Single(item => item.ID == nn.TO_BELGE_ID));
                    return belgeList;

                case "AV001_TDI_BIL_CARI":
                    foreach (NN_BELGE_CARI nn in DataRepository.NN_BELGE_CARIProvider.GetByCARI_ID(((AV001_TDI_BIL_CARI)record).ID))
                        belgeList.Add(BelgeUtil.Inits._BelgeGetir != null ? BelgeUtil.Inits._BelgeGetir.Single(item => item.ID == nn.BELGE_ID) : BelgeUtil.Inits.context.per_AV001_TDIE_BIL_BELGEs.Single(item => item.ID == nn.BELGE_ID));
                    return belgeList;

                case "AV001_TDI_BIL_CELSE":
                    break;

                case "AV001_TD_BIL_FOY":
                    if (direkBaglimi)
                    {
                        return GetDirekBagliBelgeler(((AV001_TD_BIL_FOY)record).ID, record.TableName);
                    }
                    var list = DataRepository.NN_BELGE_DAVAProvider.GetByDAVA_FOY_ID(((AV001_TD_BIL_FOY)record).ID);
                    foreach (NN_BELGE_DAVA nn in list)
                    {
                        if (BelgeUtil.Inits._BelgeGetir == null)
                            BelgeUtil.Inits._BelgeGetir = BelgeUtil.Inits.context.per_AV001_TDIE_BIL_BELGEs.ToList();
                        var belge = BelgeUtil.Inits._BelgeGetir.Find(vi => vi.ID == nn.BELGE_ID);
                        if (belge != null)
                            belgeList.Add(belge);
                    }
                    return belgeList;

                case "AV001_TDIE_BIL_PROJE":
                    var listProje = DataRepository.AV001_TDIE_BIL_PROJE_BELGEProvider.GetByPROJE_ID(((AV001_TDIE_BIL_PROJE)record).ID);
                    foreach (AV001_TDIE_BIL_PROJE_BELGE nn in listProje)
                    {
                        if (BelgeUtil.Inits._BelgeGetir == null)
                            BelgeUtil.Inits._BelgeGetir = BelgeUtil.Inits.context.per_AV001_TDIE_BIL_BELGEs.ToList();
                        var belge = BelgeUtil.Inits._BelgeGetir.Find(vi => vi.ID == nn.BELGE_ID);
                        if (belge != null)
                            belgeList.Add(belge);
                    }
                    return belgeList;

                case "AV001_TD_BIL_DAVA_NEDEN":
                    break;

                case "AV001_TD_BIL_FOY_TARAF":
                    break;

                case "AV001_TDI_BIL_GORUSME":
                    break;

                case "AV001_TI_BIL_HACIZ":
                    break;

                case "AV001_TD_BIL_HAZIRLIK":
                    if (direkBaglimi)
                    {
                        return GetDirekBagliBelgeler(((AV001_TD_BIL_HAZIRLIK)record).ID, record.TableName);
                    }
                    var listHazirlik = DataRepository.NN_BELGE_HAZIRLIKProvider.GetByHAZIRLIK_ID(((AV001_TD_BIL_HAZIRLIK)record).ID);
                    foreach (NN_BELGE_HAZIRLIK nn in listHazirlik)
                    {
                        if (BelgeUtil.Inits._BelgeGetir == null)
                            BelgeUtil.Inits._BelgeGetir = BelgeUtil.Inits.context.per_AV001_TDIE_BIL_BELGEs.ToList();
                        var belge = BelgeUtil.Inits._BelgeGetir.Find(vi => vi.ID == nn.BELGE_ID);
                        if (belge != null)
                            belgeList.Add(belge);
                    }
                    return belgeList;

                case "AV001_TD_BIL_HAZIRLIK_TARAF":

                    break;

                case "AV001_TI_BIL_FOY":

                    if (direkBaglimi)
                    {
                        return GetDirekBagliBelgeler(((AV001_TI_BIL_FOY)record).ID, record.TableName);
                    }
                    var listIcra = DataRepository.NN_BELGE_ICRAProvider.GetByICRA_FOY_ID(((AV001_TI_BIL_FOY)record).ID);
                    foreach (NN_BELGE_ICRA nn in listIcra)
                    {
                        if (BelgeUtil.Inits._BelgeGetir == null)
                            BelgeUtil.Inits._BelgeGetir = BelgeUtil.Inits.context.per_AV001_TDIE_BIL_BELGEs.ToList();
                        var belge = BelgeUtil.Inits._BelgeGetir.Find(vi => vi.ID == nn.BELGE_ID);
                        if (belge != null)
                            belgeList.Add(belge);
                    }
                    return belgeList;

                case "AV001_TI_BIL_FOY_TARAF":

                    break;

                case "AV001_TDI_BIL_IS":
                    foreach (NN_IS_BELGE nn in DataRepository.NN_IS_BELGEProvider.GetByIS_ID(((AV001_TDI_BIL_IS)record).ID))
                        belgeList.Add(BelgeUtil.Inits._BelgeGetir != null ? BelgeUtil.Inits._BelgeGetir.Single(item => item.ID == nn.BELGE_ID) : BelgeUtil.Inits.context.per_AV001_TDIE_BIL_BELGEs.Single(item => item.ID == nn.BELGE_ID));
                    return belgeList;

                case "AV001_TDI_BIL_IS_GOREV":

                    break;

                case "AV001_TDI_BIL_IS_TARAF":

                    break;

                case "AV001_TDIE_BIL_KLAVYE_MOUSE_MAKRO":

                    break;

                case "AV001_TDIE_BIL_MESAJ":

                    break;

                case "AV001_TDI_BIL_MUHASEBE":

                    break;

                case "AV001_TDI_BIL_RUCU":
                    if (direkBaglimi)
                    {
                        return GetDirekBagliBelgeler(((AV001_TDI_BIL_RUCU)record).ID, record.TableName);
                    }
                    foreach (NN_BELGE_RUCU nn in DataRepository.NN_BELGE_RUCUProvider.GetByRUCU_ID(((AV001_TDI_BIL_RUCU)record).ID))
                        belgeList.Add(BelgeUtil.Inits._BelgeGetir != null ? BelgeUtil.Inits._BelgeGetir.Single(item => item.ID == nn.BELGE_ID) : BelgeUtil.Inits.context.per_AV001_TDIE_BIL_BELGEs.Single(item => item.ID == nn.BELGE_ID));
                    return belgeList;

                case "AV001_TDI_BIL_RUCU_TARAF":

                    break;

                case "AV001_TDIE_BIL_SABLON_RAPOR":

                    break;

                case "AV001_TI_BIL_SATIS":

                    break;

                case "AV001_TDI_BIL_SOZLESME":
                    if (direkBaglimi)
                    {
                        return GetDirekBagliBelgeler(((AV001_TDI_BIL_SOZLESME)record).ID, record.TableName);
                    }

                    #region ARCH

                    //var listSoz = DataRepository.NN_BELGE_SOZLESMEProvider.GetByICRA_FOY_ID(((AV001_TI_BIL_FOY)record).ID);
                    var listSoz = DataRepository.NN_BELGE_SOZLESMEProvider.GetBySOZLESME_ID(((AV001_TDI_BIL_SOZLESME)record).ID);
                    foreach (NN_BELGE_SOZLESME nn in listSoz)
                    {
                        if (BelgeUtil.Inits._BelgeGetir == null)
                            BelgeUtil.Inits._BelgeGetir = BelgeUtil.Inits.context.per_AV001_TDIE_BIL_BELGEs.ToList();
                        var belge = BelgeUtil.Inits._BelgeGetir.Find(vi => vi.ID == nn.BELGE_ID);
                        if (belge != null)
                            belgeList.Add(belge);
                    }

                    #endregion ARCH

                    break;

                case "AV001_TDI_BIL_SOZLESME_TARAF":

                    break;

                case "AV001_TI_BIL_TAAHHUT_ODEME":

                    break;

                case "AV001_TDI_BIL_TEBLIGAT":
                    if (direkBaglimi)
                    {
                        return GetDirekBagliBelgeler(((AV001_TDI_BIL_TEBLIGAT)record).ID, record.TableName);
                    }
                    foreach (NN_BELGE_TEBLIGAT nn in DataRepository.NN_BELGE_TEBLIGATProvider.GetByTEBLIGAT_ID(((AV001_TDI_BIL_TEBLIGAT)record).ID))
                        belgeList.Add(BelgeUtil.Inits._BelgeGetir != null ? BelgeUtil.Inits._BelgeGetir.Single(item => item.ID == nn.BELGE_ID) : BelgeUtil.Inits.context.per_AV001_TDIE_BIL_BELGEs.Single(item => item.ID == nn.BELGE_ID));
                    return belgeList;

                case "AV001_TDI_BIL_TEBLIGAT_MUHATAP":

                    break;

                default:
                    break;
            }
            return belgeList;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="belge"></param>
        /// <param name="Record"></param>
        public static void SaveBelge(AV001_TDIE_BIL_BELGE belge, IEntity Record)
        {
            IEntity MyRecord;
            if (Record == null)
            {
                return;
            }
            string Tablo = Record.TableName;
            switch (Tablo)
            {
                case "AV001_TD_BIL_ARA_KARAR":
                    NN_BELGE_ARAKARAR arakarar = new NN_BELGE_ARAKARAR();
                    arakarar.BELGE_ID = belge.ID;
                    arakarar.ARAKARAR_ID = ((AV001_TD_BIL_ARA_KARAR)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_ARAKARARProvider.Save(arakarar);

                    AV001_TDIE_BIL_BELGE_ILISKI iliski = new AV001_TDIE_BIL_BELGE_ILISKI();
                    iliski.BELGE_ID = belge.ID;
                    iliski.TABLE_NAME = Record.TableName;
                    iliski.VALUE = arakarar.ARAKARAR_ID;
                    AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_BELGE_ILISKIProvider.Save(iliski);

                    if (((AV001_TD_BIL_ARA_KARAR)Record).DAVA_FOY_ID.HasValue)
                    {
                        NN_BELGE_DAVA davaBelgesi = new NN_BELGE_DAVA();
                        davaBelgesi.BELGE_ID = belge.ID;
                        davaBelgesi.DAVA_FOY_ID = ((AV001_TD_BIL_ARA_KARAR)Record).DAVA_FOY_ID.Value;
                        AvukatProLib2.Data.DataRepository.NN_BELGE_DAVAProvider.Save(davaBelgesi);
                    }

                    break;

                case "AV001_TDIE_BIL_BELGE":
                    NN_BELGE_BELGE belgem = new NN_BELGE_BELGE();
                    belgem.BELGE_ID = belge.ID;
                    belgem.TO_BELGE_ID = ((AV001_TDIE_BIL_BELGE)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_BELGEProvider.Save(belgem);
                    break;

                case "AV001_TDI_BIL_CARI":
                    NN_BELGE_CARI carim = new NN_BELGE_CARI();
                    carim.BELGE_ID = belge.ID;
                    carim.CARI_ID = ((AV001_TDI_BIL_CARI)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_CARIProvider.Save(carim);
                    break;

                case "AV001_TD_BIL_CELSE":

                    NN_BELGE_CELSE celsem = new NN_BELGE_CELSE();
                    celsem.BELGE_ID = belge.ID;
                    celsem.CELSE_ID = ((AV001_TD_BIL_CELSE)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_CELSEProvider.Save(celsem);

                    AV001_TDIE_BIL_BELGE_ILISKI iliskiCelse = new AV001_TDIE_BIL_BELGE_ILISKI();
                    iliskiCelse.BELGE_ID = belge.ID;
                    iliskiCelse.TABLE_NAME = Record.TableName;
                    iliskiCelse.VALUE = celsem.CELSE_ID;
                    AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_BELGE_ILISKIProvider.Save(iliskiCelse);

                    if (((AV001_TD_BIL_CELSE)Record).DAVA_FOY_ID.HasValue)
                    {
                        NN_BELGE_DAVA davaBelgesi = new NN_BELGE_DAVA();
                        davaBelgesi.BELGE_ID = belge.ID;
                        davaBelgesi.DAVA_FOY_ID = ((AV001_TD_BIL_CELSE)Record).DAVA_FOY_ID.Value;
                        AvukatProLib2.Data.DataRepository.NN_BELGE_DAVAProvider.Save(davaBelgesi);
                    }

                    break;

                case "AV001_TDI_BIL_FATURA":
                    NN_FATURA_BELGE faturam = new NN_FATURA_BELGE();
                    faturam.BELGE_ID = belge.ID;
                    faturam.FATURA_ID = ((AV001_TDI_BIL_FATURA)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_FATURA_BELGEProvider.Save(faturam);
                    break;

                case "AV001_TDI_BIL_KIYMETLI_EVRAK":
                    NN_BELGE_KIYMETLI_EVRAK kiymetliEvr = new NN_BELGE_KIYMETLI_EVRAK();
                    kiymetliEvr.BELGE_ID = belge.ID;
                    kiymetliEvr.KIYMETLI_EVRAK_ID = ((AV001_TDI_BIL_KIYMETLI_EVRAK)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_KIYMETLI_EVRAKProvider.Save(kiymetliEvr);
                    break;

                case "AV001_TD_BIL_FOY":
                    NN_BELGE_DAVA davam = new NN_BELGE_DAVA();
                    davam.BELGE_ID = belge.ID;
                    davam.DAVA_FOY_ID = ((AV001_TD_BIL_FOY)Record).ID;
                    MyRecord = AvukatProLib2.Data.DataRepository.NN_BELGE_DAVAProvider.GetByBELGE_IDDAVA_FOY_ID(
                        belge.ID, ((AV001_TD_BIL_FOY)Record).ID);
                    if (MyRecord == null)
                    {
                        AvukatProLib2.Data.DataRepository.NN_BELGE_DAVAProvider.Save(davam);
                    }
                    else
                    {
                        AvukatProLib2.Data.DataRepository.NN_BELGE_DAVAProvider.Save((NN_BELGE_DAVA)MyRecord);
                    }
                    SaveToBelgeIliski(belge, "AV001_TD_BIL_FOY", davam.DAVA_FOY_ID);

                    break;

                case "AV001_TD_BIL_DAVA_NEDEN":
                    NN_BELGE_DAVA_NEDEN davaNedenim = new NN_BELGE_DAVA_NEDEN();
                    davaNedenim.BELGE_ID = belge.ID;
                    davaNedenim.DAVA_NEDEN_ID = ((AV001_TD_BIL_DAVA_NEDEN)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_DAVA_NEDENProvider.Save(davaNedenim);
                    break;

                case "AV001_TD_BIL_FOY_TARAF":
                    NN_BELGE_DAVA_TARAF foyTaraf = new NN_BELGE_DAVA_TARAF();
                    foyTaraf.BELGE_ID = belge.ID;
                    foyTaraf.DAVA_TARAF_ID = ((AV001_TD_BIL_FOY_TARAF)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_DAVA_TARAFProvider.Save(foyTaraf);
                    break;

                case "AV001_TDI_BIL_GORUSME":
                    NN_BELGE_GORUSME gorusmem = new NN_BELGE_GORUSME();
                    gorusmem.BELGE_ID = belge.ID;
                    gorusmem.GORUSME_ID = ((AV001_TDI_BIL_GORUSME)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_GORUSMEProvider.Save(gorusmem);
                    break;

                case "AV001_TI_BIL_HACIZ_MASTER":
                    NN_BELGE_HACIZ haczim = new NN_BELGE_HACIZ();
                    haczim.BELGE_ID = belge.ID;
                    haczim.HACIZ_ID = ((AV001_TI_BIL_HACIZ_MASTER)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_HACIZProvider.Save(haczim);

                    AV001_TDIE_BIL_BELGE_ILISKI iliskiHaciz = new AV001_TDIE_BIL_BELGE_ILISKI();
                    iliskiHaciz.BELGE_ID = belge.ID;
                    iliskiHaciz.TABLE_NAME = Record.TableName;
                    iliskiHaciz.VALUE = haczim.HACIZ_ID;
                    AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_BELGE_ILISKIProvider.Save(iliskiHaciz);

                    if (((AV001_TI_BIL_HACIZ_MASTER)Record).ICRA_FOY_ID.HasValue)
                    {
                        NN_BELGE_ICRA icraBelgesi = new NN_BELGE_ICRA();
                        icraBelgesi.BELGE_ID = belge.ID;
                        icraBelgesi.ICRA_FOY_ID = ((AV001_TI_BIL_HACIZ_MASTER)Record).ICRA_FOY_ID.Value;
                        AvukatProLib2.Data.DataRepository.NN_BELGE_ICRAProvider.Save(icraBelgesi);
                    }

                    break;

                case "AV001_TD_BIL_HAZIRLIK":
                    NN_BELGE_HAZIRLIK hazirlikim = new NN_BELGE_HAZIRLIK();
                    hazirlikim.BELGE_ID = belge.ID;
                    hazirlikim.HAZIRLIK_ID = ((AV001_TD_BIL_HAZIRLIK)Record).ID;
                    MyRecord =
                        AvukatProLib2.Data.DataRepository.NN_BELGE_HAZIRLIKProvider.GetByBELGE_IDHAZIRLIK_ID(belge.ID,
                                                                                                             ((
                                                                                                              AV001_TD_BIL_HAZIRLIK
                                                                                                              )Record).
                                                                                                                 ID);
                    if (MyRecord == null)
                    {
                        AvukatProLib2.Data.DataRepository.NN_BELGE_HAZIRLIKProvider.Save(hazirlikim);
                    }
                    else
                    {
                        AvukatProLib2.Data.DataRepository.NN_BELGE_HAZIRLIKProvider.Save((NN_BELGE_HAZIRLIK)MyRecord);
                    }
                    SaveToBelgeIliski(belge, "AV001_TD_BIL_HAZIRLIK", hazirlikim.HAZIRLIK_ID);
                    break;

                case "AV001_TD_BIL_HAZIRLIK_TARAF":
                    NN_BELGE_HAZIRLIK_TARAF hazTarafim = new NN_BELGE_HAZIRLIK_TARAF();
                    hazTarafim.BELGE_ID = belge.ID;
                    hazTarafim.HAZIRLIK_TARAF_ID = ((AV001_TD_BIL_HAZIRLIK_TARAF)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_HAZIRLIK_TARAFProvider.Save(hazTarafim);
                    break;

                case "AV001_TI_BIL_FOY":
                    NN_BELGE_ICRA icram = new NN_BELGE_ICRA();
                    icram.BELGE_ID = belge.ID;
                    icram.ICRA_FOY_ID = ((AV001_TI_BIL_FOY)Record).ID;
                    MyRecord = AvukatProLib2.Data.DataRepository.NN_BELGE_ICRAProvider.GetByBELGE_IDICRA_FOY_ID(
                        belge.ID, ((AV001_TI_BIL_FOY)Record).ID);
                    if (MyRecord == null)
                    {
                        AvukatProLib2.Data.DataRepository.NN_BELGE_ICRAProvider.Save(icram);
                    }
                    else
                    {
                        AvukatProLib2.Data.DataRepository.NN_BELGE_ICRAProvider.Save((NN_BELGE_ICRA)MyRecord);
                    }
                    SaveToBelgeIliski(belge, "AV001_TI_BIL_FOY", icram.ICRA_FOY_ID);
                    break;

                case "AV001_TI_BIL_FOY_TARAF":
                    NN_BELGE_ICRA_TARAF icraTarafim = new NN_BELGE_ICRA_TARAF();
                    icraTarafim.BELGE_ID = belge.ID;
                    icraTarafim.ICRA_TARAF_ID = ((AV001_TI_BIL_FOY_TARAF)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_ICRA_TARAFProvider.Save(icraTarafim);
                    break;

                case "AV001_TDI_BIL_IS":
                    NN_IS_BELGE isim = new NN_IS_BELGE();
                    isim.BELGE_ID = belge.ID;
                    isim.IS_ID = ((AV001_TDI_BIL_IS)Record).ID;
                    MyRecord = AvukatProLib2.Data.DataRepository.NN_IS_BELGEProvider.GetByIS_IDBELGE_ID(belge.ID,
                                                                                                        ((
                                                                                                         AV001_TDI_BIL_IS
                                                                                                         )Record).ID);
                    if (MyRecord == null)
                    {
                        AvukatProLib2.Data.DataRepository.NN_IS_BELGEProvider.Save(isim);
                    }
                    else
                    {
                        AvukatProLib2.Data.DataRepository.NN_IS_BELGEProvider.Save((NN_IS_BELGE)MyRecord);
                    }
                    SaveToBelgeIliski(belge, "AV001_TDI_BIL_IS", isim.IS_ID);

                    break;

                case "AV001_TDI_BIL_IS_GOREV":
                    NN_BELGE_IS_GOREV isGorevim = new NN_BELGE_IS_GOREV();
                    isGorevim.BELGE_ID = belge.ID;
                    isGorevim.IS_GOREV_ID = ((AV001_TDI_BIL_IS_GOREV)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_IS_GOREVProvider.Save(isGorevim);
                    break;

                case "AV001_TDI_BIL_IS_TARAF":
                    NN_BELGE_IS_TARAF isTarafim = new NN_BELGE_IS_TARAF();
                    isTarafim.BELGE_ID = belge.ID;
                    isTarafim.IS_TARAF_ID = ((AV001_TDI_BIL_IS_TARAF)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_IS_TARAFProvider.Save(isTarafim);
                    break;

                case "AV001_TDIE_BIL_KLAVYE_MOUSE_MAKRO":
                    NN_BELGE_MAKRO makrom = new NN_BELGE_MAKRO();
                    makrom.BELGE_ID = belge.ID;
                    makrom.MAKRO_ID = ((AV001_TDIE_BIL_KLAVYE_MOUSE_MAKRO)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_MAKROProvider.Save(makrom);
                    break;

                case "AV001_TDIE_BIL_MESAJ":
                    NN_BELGE_MESAJ mesajim = new NN_BELGE_MESAJ();
                    mesajim.BELGE_ID = belge.ID;
                    mesajim.MESAJ_ID = ((AV001_TDIE_BIL_MESAJ)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_MESAJProvider.Save(mesajim);
                    break;

                case "AV001_TDI_BIL_MUHASEBE":
                    NN_BELGE_MUHASEBE muhasebem = new NN_BELGE_MUHASEBE();
                    muhasebem.BELGE_ID = belge.ID;
                    muhasebem.MUHASEBE_ID = ((AV001_TDI_BIL_MUHASEBE)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_MUHASEBEProvider.Save(muhasebem);
                    break;

                case "AV001_TDI_BIL_RUCU":
                    NN_BELGE_RUCU rucum = new NN_BELGE_RUCU();
                    rucum.BELGE_ID = belge.ID;
                    rucum.RUCU_ID = ((AV001_TDI_BIL_RUCU)Record).ID;
                    MyRecord = AvukatProLib2.Data.DataRepository.NN_BELGE_RUCUProvider.GetByBELGE_IDRUCU_ID(belge.ID,
                                                                                                            ((
                                                                                                             AV001_TDI_BIL_RUCU
                                                                                                             )Record).
                                                                                                                ID);
                    if (MyRecord == null)
                    {
                        AvukatProLib2.Data.DataRepository.NN_BELGE_RUCUProvider.Save(rucum);
                    }
                    else
                    {
                        AvukatProLib2.Data.DataRepository.NN_BELGE_RUCUProvider.Save((NN_BELGE_RUCU)MyRecord);
                    }
                    SaveToBelgeIliski(belge, "AV001_TDI_BIL_RUCU", rucum.RUCU_ID);

                    break;

                case "AV001_TDI_BIL_RUCU_TARAF":
                    NN_BELGE_RUCU_TARAF rucuTarafim = new NN_BELGE_RUCU_TARAF();
                    rucuTarafim.BELGE_ID = belge.ID;
                    rucuTarafim.RUCU_TARAF_ID = ((AV001_TDI_BIL_RUCU_TARAF)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_RUCU_TARAFProvider.Save(rucuTarafim);
                    break;

                case "AV001_TDI_BIL_TEMSIL":
                    NN_BELGE_TEMSIL temsilBelgem = new NN_BELGE_TEMSIL();
                    temsilBelgem.BELGE_ID = belge.ID;
                    temsilBelgem.TEMSIL_ID = ((AV001_TDI_BIL_TEMSIL)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_TEMSILProvider.Save(temsilBelgem);
                    break;

                case "AV001_TDIE_BIL_SABLON_RAPOR":
                    NN_BELGE_SABLON_RAPOR sablonum = new NN_BELGE_SABLON_RAPOR();
                    sablonum.BELGE_ID = belge.ID;
                    sablonum.SABLON_RAPOR_ID = ((AV001_TDIE_BIL_SABLON_RAPOR)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_SABLON_RAPORProvider.Save(sablonum);
                    break;

                case "AV001_TI_BIL_SATIS_MASTER":

                    NN_BELGE_SATIS satisim = new NN_BELGE_SATIS();
                    satisim.BELGE_ID = belge.ID;
                    satisim.SATIS_ID = ((AV001_TI_BIL_SATIS_MASTER)Record).ID;
                    MyRecord = AvukatProLib2.Data.DataRepository.NN_BELGE_SATISProvider.GetByBELGE_IDSATIS_ID(belge.ID,
                                                                                                              ((
                                                                                                               AV001_TI_BIL_SATIS_MASTER
                                                                                                               )Record)
                                                                                                                  .ID);
                    if (MyRecord == null)
                    {
                        AvukatProLib2.Data.DataRepository.NN_BELGE_SATISProvider.Save(satisim);
                    }
                    else
                    {
                        AvukatProLib2.Data.DataRepository.NN_BELGE_SATISProvider.Save((NN_BELGE_SATIS)MyRecord);
                    }
                    SaveToBelgeIliski(belge, "AV001_TI_BIL_SATIS_MASTER", satisim.SATIS_ID);

                    break;

                case "AV001_TDI_BIL_SOZLESME":
                    NN_BELGE_SOZLESME sozlesmem = new NN_BELGE_SOZLESME();
                    sozlesmem.BELGE_ID = belge.ID;
                    sozlesmem.SOZLESME_ID = ((AV001_TDI_BIL_SOZLESME)Record).ID;
                    MyRecord =
                        AvukatProLib2.Data.DataRepository.NN_BELGE_SOZLESMEProvider.GetByBELGE_IDSOZLESME_ID(belge.ID,
                                                                                                             ((
                                                                                                              AV001_TDI_BIL_SOZLESME
                                                                                                              )Record).
                                                                                                                 ID);
                    if (MyRecord == null)
                    {
                        AvukatProLib2.Data.DataRepository.NN_BELGE_SOZLESMEProvider.Save(sozlesmem);
                    }
                    else
                    {
                        AvukatProLib2.Data.DataRepository.NN_BELGE_SOZLESMEProvider.Save((NN_BELGE_SOZLESME)MyRecord);
                    }
                    SaveToBelgeIliski(belge, "AV001_TDI_BIL_SOZLESME", sozlesmem.SOZLESME_ID);

                    AV001_TDIE_BIL_BELGE_ILISKI iliskiSozlesme = new AV001_TDIE_BIL_BELGE_ILISKI();
                    iliskiSozlesme.BELGE_ID = belge.ID;
                    iliskiSozlesme.TABLE_NAME = Record.TableName;
                    iliskiSozlesme.VALUE = sozlesmem.SOZLESME_ID;
                    AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_BELGE_ILISKIProvider.Save(iliskiSozlesme);

                    if (((AV001_TDI_BIL_SOZLESME)Record).DAVA_FOY_ID.HasValue)
                    {
                        NN_BELGE_DAVA davaBelgesi = new NN_BELGE_DAVA();
                        davaBelgesi.BELGE_ID = belge.ID;
                        davaBelgesi.DAVA_FOY_ID = ((AV001_TDI_BIL_SOZLESME)Record).DAVA_FOY_ID.Value;
                        AvukatProLib2.Data.DataRepository.NN_BELGE_DAVAProvider.Save(davaBelgesi);
                    }

                    if (((AV001_TDI_BIL_SOZLESME)Record).ICRA_FOY_ID.HasValue)
                    {
                        NN_BELGE_ICRA icraBelgesi = new NN_BELGE_ICRA();
                        icraBelgesi.BELGE_ID = belge.ID;
                        icraBelgesi.ICRA_FOY_ID = ((AV001_TDI_BIL_SOZLESME)Record).ICRA_FOY_ID.Value;
                        AvukatProLib2.Data.DataRepository.NN_BELGE_ICRAProvider.Save(icraBelgesi);
                    }

                    break;

                case "AV001_TDI_BIL_SOZLESME_TARAF":
                    NN_BELGE_SOZLESME_TARAF sozlesmeTarafim = new NN_BELGE_SOZLESME_TARAF();
                    sozlesmeTarafim.BELGE_ID = belge.ID;
                    sozlesmeTarafim.SOZLESME_TARAF_ID = ((AV001_TDI_BIL_SOZLESME_TARAF)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_SOZLESME_TARAFProvider.Save(sozlesmeTarafim);

                    AV001_TDIE_BIL_BELGE_ILISKI iliskiSozlesmeTaraf = new AV001_TDIE_BIL_BELGE_ILISKI();
                    iliskiSozlesmeTaraf.BELGE_ID = belge.ID;
                    iliskiSozlesmeTaraf.TABLE_NAME = Record.TableName;
                    iliskiSozlesmeTaraf.VALUE = sozlesmeTarafim.SOZLESME_TARAF_ID;
                    AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_BELGE_ILISKIProvider.Save(iliskiSozlesmeTaraf);

                    if (((AV001_TDI_BIL_SOZLESME_TARAF)Record).SOZLESME_IDSource.DAVA_FOY_ID.HasValue)
                    {
                        NN_BELGE_DAVA davaBelgesi = new NN_BELGE_DAVA();
                        davaBelgesi.BELGE_ID = belge.ID;
                        davaBelgesi.DAVA_FOY_ID =
                            ((AV001_TDI_BIL_SOZLESME_TARAF)Record).SOZLESME_IDSource.DAVA_FOY_ID.Value;
                        AvukatProLib2.Data.DataRepository.NN_BELGE_DAVAProvider.Save(davaBelgesi);
                    }

                    if (((AV001_TDI_BIL_SOZLESME_TARAF)Record).SOZLESME_IDSource.ICRA_FOY_ID.HasValue)
                    {
                        NN_BELGE_ICRA icraBelgesi = new NN_BELGE_ICRA();
                        icraBelgesi.BELGE_ID = belge.ID;
                        icraBelgesi.ICRA_FOY_ID =
                            ((AV001_TDI_BIL_SOZLESME_TARAF)Record).SOZLESME_IDSource.ICRA_FOY_ID.Value;
                        AvukatProLib2.Data.DataRepository.NN_BELGE_ICRAProvider.Save(icraBelgesi);
                    }

                    break;

                case "AV001_TI_BIL_TAAHHUT_ODEME":
                    NN_BELGE_TAAHHUT tahutum = new NN_BELGE_TAAHHUT();
                    tahutum.BELGE_ID = belge.ID;
                    tahutum.TAAHHUT_ID = ((AV001_TI_BIL_TAAHHUT_ODEME)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_TAAHHUTProvider.Save(tahutum);
                    break;

                case "AV001_TDI_BIL_TEBLIGAT":
                    NN_BELGE_TEBLIGAT tebligatim = new NN_BELGE_TEBLIGAT();
                    tebligatim.BELGE_ID = belge.ID;
                    tebligatim.TEBLIGAT_ID = ((AV001_TDI_BIL_TEBLIGAT)Record).ID;
                    MyRecord =
                        AvukatProLib2.Data.DataRepository.NN_BELGE_TEBLIGATProvider.GetByBELGE_IDTEBLIGAT_ID(belge.ID,
                                                                                                             ((
                                                                                                              AV001_TDI_BIL_TEBLIGAT
                                                                                                              )Record).
                                                                                                                 ID);

                    //AvukatProLib2.Data.DataRepository.NN_BELGE_TEBLIGATProvider.Save(tebligatim);

                    if (MyRecord == null)
                    {
                        AvukatProLib2.Data.DataRepository.NN_BELGE_TEBLIGATProvider.Save(tebligatim);
                    }
                    else
                    {
                        AvukatProLib2.Data.DataRepository.NN_BELGE_TEBLIGATProvider.Save((NN_BELGE_TEBLIGAT)MyRecord);
                    }
                    SaveToBelgeIliski(belge, "AV001_TDI_BIL_TEBLIGAT", tebligatim.TEBLIGAT_ID);

                    break;

                case "AV001_TDI_BIL_TEBLIGAT_MUHATAP":
                    NN_BELGE_TEBLIGAT_MUHATAB tebligatMuhatabim = new NN_BELGE_TEBLIGAT_MUHATAB();
                    tebligatMuhatabim.BELGE_ID = belge.ID;
                    tebligatMuhatabim.TEBLIGAT_MUHATAB_ID = ((AV001_TDI_BIL_TEBLIGAT_MUHATAP)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_TEBLIGAT_MUHATABProvider.DeepSave(tebligatMuhatabim);
                    break;

                case "AV001_TDIE_BIL_PROJE":
                    AV001_TDIE_BIL_PROJE_BELGE projeBelge = new AV001_TDIE_BIL_PROJE_BELGE();
                    projeBelge.BELGE_ID = belge.ID;
                    projeBelge.PROJE_ID = ((AV001_TDIE_BIL_PROJE)Record).ID;
                    MyRecord =
                        AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_PROJE_BELGEProvider.GetByPROJE_IDBELGE_ID(
                            ((AV001_TDIE_BIL_PROJE)Record).ID, belge.ID);

                    if (MyRecord == null)
                    {
                        AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_PROJE_BELGEProvider.Save(projeBelge);
                    }
                    break;

                default:
                    break;
            }
        }

        public static void SaveBelge(AV001_TDIE_BIL_BELGE belge, string tableName, int id)
        {
            IEntity MyRecord;
            IEntity Record;
            string Tablo = tableName;
            switch (Tablo)
            {
                case "AV001_TD_BIL_ARA_KARAR":
                    NN_BELGE_ARAKARAR arakarar = new NN_BELGE_ARAKARAR();
                    arakarar.BELGE_ID = belge.ID;
                    arakarar.ARAKARAR_ID = id;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_ARAKARARProvider.Save(arakarar);

                    AV001_TDIE_BIL_BELGE_ILISKI iliski = new AV001_TDIE_BIL_BELGE_ILISKI();
                    iliski.BELGE_ID = belge.ID;
                    iliski.TABLE_NAME = tableName;
                    iliski.VALUE = arakarar.ARAKARAR_ID;
                    AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_BELGE_ILISKIProvider.Save(iliski);
                    Record = DataRepository.AV001_TD_BIL_ARA_KARARProvider.GetByID(id);
                    if (((AV001_TD_BIL_ARA_KARAR)Record).DAVA_FOY_ID.HasValue)
                    {
                        NN_BELGE_DAVA davaBelgesi = new NN_BELGE_DAVA();
                        davaBelgesi.BELGE_ID = belge.ID;
                        davaBelgesi.DAVA_FOY_ID = ((AV001_TD_BIL_ARA_KARAR)Record).DAVA_FOY_ID.Value;
                        AvukatProLib2.Data.DataRepository.NN_BELGE_DAVAProvider.Save(davaBelgesi);
                    }

                    break;

                case "AV001_TDIE_BIL_BELGE":
                    NN_BELGE_BELGE belgem = new NN_BELGE_BELGE();
                    belgem.BELGE_ID = belge.ID;
                    belgem.TO_BELGE_ID = id;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_BELGEProvider.Save(belgem);
                    break;

                case "AV001_TDI_BIL_CARI":
                    NN_BELGE_CARI carim = new NN_BELGE_CARI();
                    carim.BELGE_ID = belge.ID;
                    carim.CARI_ID = id;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_CARIProvider.Save(carim);
                    break;

                case "AV001_TDI_BIL_CELSE":

                    NN_BELGE_CELSE celsem = new NN_BELGE_CELSE();
                    celsem.BELGE_ID = belge.ID;
                    celsem.CELSE_ID = id;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_CELSEProvider.Save(celsem);

                    AV001_TDIE_BIL_BELGE_ILISKI iliskiCelse = new AV001_TDIE_BIL_BELGE_ILISKI();
                    iliskiCelse.BELGE_ID = belge.ID;
                    iliskiCelse.TABLE_NAME = tableName;
                    iliskiCelse.VALUE = celsem.CELSE_ID;
                    AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_BELGE_ILISKIProvider.Save(iliskiCelse);
                    Record = DataRepository.AV001_TDI_BIL_CELSEProvider.GetByID(id);

                    if (((AV001_TDI_BIL_CELSE)Record).DAVA_FOY_ID.HasValue)
                    {
                        NN_BELGE_DAVA davaBelgesi = new NN_BELGE_DAVA();
                        davaBelgesi.BELGE_ID = belge.ID;
                        davaBelgesi.DAVA_FOY_ID = ((AV001_TDI_BIL_CELSE)Record).DAVA_FOY_ID.Value;
                        AvukatProLib2.Data.DataRepository.NN_BELGE_DAVAProvider.Save(davaBelgesi);
                    }

                    if (((AV001_TDI_BIL_CELSE)Record).ICRA_FOY_ID.HasValue)
                    {
                        NN_BELGE_ICRA icraBelgesi = new NN_BELGE_ICRA();
                        icraBelgesi.BELGE_ID = belge.ID;
                        icraBelgesi.ICRA_FOY_ID = ((AV001_TDI_BIL_CELSE)Record).ICRA_FOY_ID.Value;
                        AvukatProLib2.Data.DataRepository.NN_BELGE_ICRAProvider.Save(icraBelgesi);
                    }

                    break;

                case "AV001_TD_BIL_FOY":
                    NN_BELGE_DAVA davam = new NN_BELGE_DAVA();
                    davam.BELGE_ID = belge.ID;
                    davam.DAVA_FOY_ID = id;
                    MyRecord = AvukatProLib2.Data.DataRepository.NN_BELGE_DAVAProvider.GetByBELGE_IDDAVA_FOY_ID(
                        belge.ID, id);
                    if (MyRecord == null)
                    {
                        AvukatProLib2.Data.DataRepository.NN_BELGE_DAVAProvider.Save(davam);
                    }
                    else
                    {
                        AvukatProLib2.Data.DataRepository.NN_BELGE_DAVAProvider.Save((NN_BELGE_DAVA)MyRecord);
                    }
                    SaveToBelgeIliski(belge, "AV001_TD_BIL_FOY", davam.DAVA_FOY_ID);

                    break;

                case "AV001_TD_BIL_DAVA_NEDEN":
                    NN_BELGE_DAVA_NEDEN davaNedenim = new NN_BELGE_DAVA_NEDEN();
                    davaNedenim.BELGE_ID = belge.ID;
                    davaNedenim.DAVA_NEDEN_ID = id;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_DAVA_NEDENProvider.Save(davaNedenim);
                    break;

                case "AV001_TD_BIL_FOY_TARAF":
                    NN_BELGE_DAVA_TARAF foyTaraf = new NN_BELGE_DAVA_TARAF();
                    foyTaraf.BELGE_ID = belge.ID;
                    foyTaraf.DAVA_TARAF_ID = id;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_DAVA_TARAFProvider.Save(foyTaraf);
                    break;

                case "AV001_TDI_BIL_GORUSME":
                    NN_BELGE_GORUSME gorusmem = new NN_BELGE_GORUSME();
                    gorusmem.BELGE_ID = belge.ID;
                    gorusmem.GORUSME_ID = id;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_GORUSMEProvider.Save(gorusmem);
                    break;

                case "AV001_TI_BIL_HACIZ":
                    NN_BELGE_HACIZ haczim = new NN_BELGE_HACIZ();
                    haczim.BELGE_ID = belge.ID;
                    haczim.HACIZ_ID = id;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_HACIZProvider.Save(haczim);

                    AV001_TDIE_BIL_BELGE_ILISKI iliskiHaciz = new AV001_TDIE_BIL_BELGE_ILISKI();
                    iliskiHaciz.BELGE_ID = belge.ID;
                    iliskiHaciz.TABLE_NAME = tableName;
                    iliskiHaciz.VALUE = haczim.HACIZ_ID;
                    AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_BELGE_ILISKIProvider.Save(iliskiHaciz);
                    Record = DataRepository.AV001_TI_BIL_HACIZProvider.GetByID(id);

                    if (((AV001_TI_BIL_HACIZ)Record).ICRA_FOY_ID.HasValue)
                    {
                        NN_BELGE_ICRA icraBelgesi = new NN_BELGE_ICRA();
                        icraBelgesi.BELGE_ID = belge.ID;
                        icraBelgesi.ICRA_FOY_ID = ((AV001_TI_BIL_HACIZ)Record).ICRA_FOY_ID.Value;
                        AvukatProLib2.Data.DataRepository.NN_BELGE_ICRAProvider.Save(icraBelgesi);
                    }

                    break;

                case "AV001_TD_BIL_HAZIRLIK":
                    NN_BELGE_HAZIRLIK hazirlikim = new NN_BELGE_HAZIRLIK();
                    hazirlikim.BELGE_ID = belge.ID;
                    hazirlikim.HAZIRLIK_ID = id;
                    MyRecord =
                        AvukatProLib2.Data.DataRepository.NN_BELGE_HAZIRLIKProvider.GetByBELGE_IDHAZIRLIK_ID(belge.ID,
                                                                                                             id);
                    if (MyRecord == null)
                    {
                        AvukatProLib2.Data.DataRepository.NN_BELGE_HAZIRLIKProvider.Save(hazirlikim);
                    }
                    else
                    {
                        AvukatProLib2.Data.DataRepository.NN_BELGE_HAZIRLIKProvider.Save((NN_BELGE_HAZIRLIK)MyRecord);
                    }
                    SaveToBelgeIliski(belge, "AV001_TD_BIL_HAZIRLIK", hazirlikim.HAZIRLIK_ID);
                    break;

                case "AV001_TD_BIL_HAZIRLIK_TARAF":
                    NN_BELGE_HAZIRLIK_TARAF hazTarafim = new NN_BELGE_HAZIRLIK_TARAF();
                    hazTarafim.BELGE_ID = belge.ID;
                    hazTarafim.HAZIRLIK_TARAF_ID = id;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_HAZIRLIK_TARAFProvider.Save(hazTarafim);
                    break;

                case "AV001_TI_BIL_FOY":
                    NN_BELGE_ICRA icram = new NN_BELGE_ICRA();
                    icram.BELGE_ID = belge.ID;
                    icram.ICRA_FOY_ID = id;
                    MyRecord = AvukatProLib2.Data.DataRepository.NN_BELGE_ICRAProvider.GetByBELGE_IDICRA_FOY_ID(
                        belge.ID, id);
                    if (MyRecord == null)
                    {
                        AvukatProLib2.Data.DataRepository.NN_BELGE_ICRAProvider.Save(icram);
                    }
                    else
                    {
                        AvukatProLib2.Data.DataRepository.NN_BELGE_ICRAProvider.Save((NN_BELGE_ICRA)MyRecord);
                    }
                    SaveToBelgeIliski(belge, "AV001_TI_BIL_FOY", icram.ICRA_FOY_ID);
                    break;

                case "AV001_TI_BIL_FOY_TARAF":
                    NN_BELGE_ICRA_TARAF icraTarafim = new NN_BELGE_ICRA_TARAF();
                    icraTarafim.BELGE_ID = belge.ID;
                    icraTarafim.ICRA_TARAF_ID = id;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_ICRA_TARAFProvider.Save(icraTarafim);
                    break;

                case "AV001_TDI_BIL_IS":
                    NN_IS_BELGE isim = new NN_IS_BELGE();
                    isim.BELGE_ID = belge.ID;
                    isim.IS_ID = id;
                    MyRecord = AvukatProLib2.Data.DataRepository.NN_IS_BELGEProvider.GetByIS_IDBELGE_ID(belge.ID, id);
                    if (MyRecord == null)
                    {
                        AvukatProLib2.Data.DataRepository.NN_IS_BELGEProvider.Save(isim);
                    }
                    else
                    {
                        AvukatProLib2.Data.DataRepository.NN_IS_BELGEProvider.Save((NN_IS_BELGE)MyRecord);
                    }
                    SaveToBelgeIliski(belge, "AV001_TDI_BIL_IS", isim.IS_ID);

                    break;

                case "AV001_TDI_BIL_IS_GOREV":
                    NN_BELGE_IS_GOREV isGorevim = new NN_BELGE_IS_GOREV();
                    isGorevim.BELGE_ID = belge.ID;
                    isGorevim.IS_GOREV_ID = id;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_IS_GOREVProvider.Save(isGorevim);
                    break;

                case "AV001_TDI_BIL_IS_TARAF":
                    NN_BELGE_IS_TARAF isTarafim = new NN_BELGE_IS_TARAF();
                    isTarafim.BELGE_ID = belge.ID;
                    isTarafim.IS_TARAF_ID = id;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_IS_TARAFProvider.Save(isTarafim);
                    break;

                case "AV001_TDIE_BIL_KLAVYE_MOUSE_MAKRO":
                    NN_BELGE_MAKRO makrom = new NN_BELGE_MAKRO();
                    makrom.BELGE_ID = belge.ID;
                    makrom.MAKRO_ID = id;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_MAKROProvider.Save(makrom);
                    break;

                case "AV001_TDIE_BIL_MESAJ":
                    NN_BELGE_MESAJ mesajim = new NN_BELGE_MESAJ();
                    mesajim.BELGE_ID = belge.ID;
                    mesajim.MESAJ_ID = id;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_MESAJProvider.Save(mesajim);
                    break;

                case "AV001_TDI_BIL_MUHASEBE":
                    NN_BELGE_MUHASEBE muhasebem = new NN_BELGE_MUHASEBE();
                    muhasebem.BELGE_ID = belge.ID;
                    muhasebem.MUHASEBE_ID = id;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_MUHASEBEProvider.Save(muhasebem);
                    break;

                case "AV001_TDI_BIL_RUCU":
                    NN_BELGE_RUCU rucum = new NN_BELGE_RUCU();
                    rucum.BELGE_ID = belge.ID;
                    rucum.RUCU_ID = id;
                    MyRecord = AvukatProLib2.Data.DataRepository.NN_BELGE_RUCUProvider.GetByBELGE_IDRUCU_ID(belge.ID, id);
                    if (MyRecord == null)
                    {
                        AvukatProLib2.Data.DataRepository.NN_BELGE_RUCUProvider.Save(rucum);
                    }
                    else
                    {
                        AvukatProLib2.Data.DataRepository.NN_BELGE_RUCUProvider.Save((NN_BELGE_RUCU)MyRecord);
                    }
                    SaveToBelgeIliski(belge, "AV001_TDI_BIL_RUCU", rucum.RUCU_ID);

                    break;

                case "AV001_TDI_BIL_RUCU_TARAF":
                    NN_BELGE_RUCU_TARAF rucuTarafim = new NN_BELGE_RUCU_TARAF();
                    rucuTarafim.BELGE_ID = belge.ID;
                    rucuTarafim.RUCU_TARAF_ID = id;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_RUCU_TARAFProvider.Save(rucuTarafim);
                    break;

                case "AV001_TDIE_BIL_SABLON_RAPOR":
                    NN_BELGE_SABLON_RAPOR sablonum = new NN_BELGE_SABLON_RAPOR();
                    sablonum.BELGE_ID = belge.ID;
                    sablonum.SABLON_RAPOR_ID = id;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_SABLON_RAPORProvider.Save(sablonum);
                    break;

                case "AV001_TI_BIL_SATIS":

                    NN_BELGE_SATIS satisim = new NN_BELGE_SATIS();
                    satisim.BELGE_ID = belge.ID;
                    satisim.SATIS_ID = id;
                    MyRecord = AvukatProLib2.Data.DataRepository.NN_BELGE_SATISProvider.GetByBELGE_IDSATIS_ID(belge.ID,
                                                                                                              id);
                    if (MyRecord == null)
                    {
                        AvukatProLib2.Data.DataRepository.NN_BELGE_SATISProvider.Save(satisim);
                    }
                    else
                    {
                        AvukatProLib2.Data.DataRepository.NN_BELGE_SATISProvider.Save((NN_BELGE_SATIS)MyRecord);
                    }
                    SaveToBelgeIliski(belge, "AV001_TI_BIL_SATIS", satisim.SATIS_ID);

                    break;

                case "AV001_TDI_BIL_SOZLESME":
                    NN_BELGE_SOZLESME sozlesmem = new NN_BELGE_SOZLESME();
                    sozlesmem.BELGE_ID = belge.ID;
                    sozlesmem.SOZLESME_ID = id;
                    MyRecord =
                        AvukatProLib2.Data.DataRepository.NN_BELGE_SOZLESMEProvider.GetByBELGE_IDSOZLESME_ID(belge.ID,
                                                                                                             id);
                    if (MyRecord == null)
                    {
                        AvukatProLib2.Data.DataRepository.NN_BELGE_SOZLESMEProvider.Save(sozlesmem);
                    }
                    else
                    {
                        AvukatProLib2.Data.DataRepository.NN_BELGE_SOZLESMEProvider.Save((NN_BELGE_SOZLESME)MyRecord);
                    }
                    SaveToBelgeIliski(belge, "AV001_TDI_BIL_SOZLESME", sozlesmem.SOZLESME_ID);

                    AV001_TDIE_BIL_BELGE_ILISKI iliskiSozlesme = new AV001_TDIE_BIL_BELGE_ILISKI();
                    iliskiSozlesme.BELGE_ID = belge.ID;
                    iliskiSozlesme.TABLE_NAME = tableName;
                    iliskiSozlesme.VALUE = sozlesmem.SOZLESME_ID;
                    AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_BELGE_ILISKIProvider.Save(iliskiSozlesme);
                    Record = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID(id);
                    if (((AV001_TDI_BIL_SOZLESME)Record).DAVA_FOY_ID.HasValue)
                    {
                        NN_BELGE_DAVA davaBelgesi = new NN_BELGE_DAVA();
                        davaBelgesi.BELGE_ID = belge.ID;
                        davaBelgesi.DAVA_FOY_ID = ((AV001_TDI_BIL_SOZLESME)Record).DAVA_FOY_ID.Value;
                        AvukatProLib2.Data.DataRepository.NN_BELGE_DAVAProvider.Save(davaBelgesi);
                    }

                    if (((AV001_TDI_BIL_SOZLESME)Record).ICRA_FOY_ID.HasValue)
                    {
                        NN_BELGE_ICRA icraBelgesi = new NN_BELGE_ICRA();
                        icraBelgesi.BELGE_ID = belge.ID;
                        icraBelgesi.ICRA_FOY_ID = ((AV001_TDI_BIL_SOZLESME)Record).ICRA_FOY_ID.Value;
                        AvukatProLib2.Data.DataRepository.NN_BELGE_ICRAProvider.Save(icraBelgesi);
                    }

                    break;

                case "AV001_TDI_BIL_SOZLESME_TARAF":
                    NN_BELGE_SOZLESME_TARAF sozlesmeTarafim = new NN_BELGE_SOZLESME_TARAF();
                    sozlesmeTarafim.BELGE_ID = belge.ID;
                    sozlesmeTarafim.SOZLESME_TARAF_ID = id;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_SOZLESME_TARAFProvider.Save(sozlesmeTarafim);

                    AV001_TDIE_BIL_BELGE_ILISKI iliskiSozlesmeTaraf = new AV001_TDIE_BIL_BELGE_ILISKI();
                    iliskiSozlesmeTaraf.BELGE_ID = belge.ID;
                    iliskiSozlesmeTaraf.TABLE_NAME = tableName;
                    iliskiSozlesmeTaraf.VALUE = sozlesmeTarafim.SOZLESME_TARAF_ID;
                    AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_BELGE_ILISKIProvider.Save(iliskiSozlesmeTaraf);

                    Record = DataRepository.AV001_TDI_BIL_SOZLESME_TARAFProvider.GetByID(id);
                    if (((AV001_TDI_BIL_SOZLESME_TARAF)Record).SOZLESME_IDSource.DAVA_FOY_ID.HasValue)
                    {
                        NN_BELGE_DAVA davaBelgesi = new NN_BELGE_DAVA();
                        davaBelgesi.BELGE_ID = belge.ID;
                        davaBelgesi.DAVA_FOY_ID =
                            ((AV001_TDI_BIL_SOZLESME_TARAF)Record).SOZLESME_IDSource.DAVA_FOY_ID.Value;
                        AvukatProLib2.Data.DataRepository.NN_BELGE_DAVAProvider.Save(davaBelgesi);
                    }

                    if (((AV001_TDI_BIL_SOZLESME_TARAF)Record).SOZLESME_IDSource.ICRA_FOY_ID.HasValue)
                    {
                        Record = DataRepository.AV001_TDI_BIL_SOZLESME_TARAFProvider.GetByID(id);
                        NN_BELGE_ICRA icraBelgesi = new NN_BELGE_ICRA();
                        icraBelgesi.BELGE_ID = belge.ID;
                        icraBelgesi.ICRA_FOY_ID =
                            ((AV001_TDI_BIL_SOZLESME_TARAF)Record).SOZLESME_IDSource.ICRA_FOY_ID.Value;
                        AvukatProLib2.Data.DataRepository.NN_BELGE_ICRAProvider.Save(icraBelgesi);
                    }

                    break;

                case "AV001_TI_BIL_TAAHHUT_ODEME":
                    NN_BELGE_TAAHHUT tahutum = new NN_BELGE_TAAHHUT();
                    tahutum.BELGE_ID = belge.ID;
                    tahutum.TAAHHUT_ID = id;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_TAAHHUTProvider.Save(tahutum);
                    break;

                case "AV001_TDI_BIL_TEBLIGAT":

                    NN_BELGE_TEBLIGAT tebligatim = new NN_BELGE_TEBLIGAT();
                    tebligatim.BELGE_ID = belge.ID;
                    tebligatim.TEBLIGAT_ID = id;
                    MyRecord =
                        AvukatProLib2.Data.DataRepository.NN_BELGE_TEBLIGATProvider.GetByBELGE_IDTEBLIGAT_ID(belge.ID,
                                                                                                             id);
                    if (MyRecord == null)
                    {
                        AvukatProLib2.Data.DataRepository.NN_BELGE_TEBLIGATProvider.Save(tebligatim);
                    }
                    else
                    {
                        AvukatProLib2.Data.DataRepository.NN_BELGE_TEBLIGATProvider.Save((NN_BELGE_TEBLIGAT)MyRecord);
                    }
                    SaveToBelgeIliski(belge, "AV001_TDI_BIL_TEBLIGAT", tebligatim.TEBLIGAT_ID);

                    break;

                case "AV001_TDI_BIL_TEBLIGAT_MUHATAP":
                    NN_BELGE_TEBLIGAT_MUHATAB tebligatMuhatabim = new NN_BELGE_TEBLIGAT_MUHATAB();
                    tebligatMuhatabim.BELGE_ID = belge.ID;
                    tebligatMuhatabim.TEBLIGAT_MUHATAB_ID = id;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_TEBLIGAT_MUHATABProvider.DeepSave(tebligatMuhatabim);
                    break;

                default:
                    break;
            }
        }

        public static void SaveIs(AV001_TDI_BIL_IS myIs, IEntity Record)
        {
            IEntity MyRecord;
            string Tablo = Record.TableName;
            switch (Tablo)
            {
                case "AV001_TD_BIL_ARA_KARAR":
                    NN_IS_ARAKARAR arakarar = new NN_IS_ARAKARAR();
                    arakarar.IS_ID = myIs.ID;
                    arakarar.ARAKARAR_ID = ((AV001_TD_BIL_ARA_KARAR)Record).ID;
                    MyRecord = AvukatProLib2.Data.DataRepository.NN_IS_ARAKARARProvider.GetByIS_IDARAKARAR_ID(myIs.ID, ((AV001_TD_BIL_ARA_KARAR)Record).ID);
                    if (Record == null)
                    {
                        AvukatProLib2.Data.DataRepository.NN_IS_ARAKARARProvider.Save(arakarar);
                    }

                    break;

                case "AV001_TDIE_BIL_BELGE":
                    NN_IS_BELGE belgem = new NN_IS_BELGE();
                    belgem.IS_ID = myIs.ID;
                    belgem.BELGE_ID = ((AV001_TDIE_BIL_BELGE)Record).ID;
                    MyRecord = AvukatProLib2.Data.DataRepository.NN_IS_BELGEProvider.GetByIS_IDBELGE_ID(myIs.ID, ((AV001_TDIE_BIL_BELGE)Record).ID);
                    if (MyRecord == null)
                    {
                        AvukatProLib2.Data.DataRepository.NN_IS_BELGEProvider.Save(belgem);
                    }
                    break;

                case "AV001_TDI_BIL_CARI":
                    NN_IS_CARI carim = new NN_IS_CARI();
                    carim.IS_ID = myIs.ID;
                    carim.CARI_ID = ((AV001_TDI_BIL_CARI)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_IS_CARIProvider.Save(carim);
                    break;

                case "AV001_TDI_BIL_CELSE":
                    NN_IS_CELSE celsem = new NN_IS_CELSE();
                    celsem.IS_ID = myIs.ID;
                    celsem.CELSE_ID = ((AV001_TDI_BIL_CELSE)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_IS_CELSEProvider.Save(celsem);
                    break;

                case "AV001_TD_BIL_FOY":
                    NN_IS_DAVA_FOY davam = new NN_IS_DAVA_FOY();
                    davam.IS_ID = myIs.ID;
                    davam.DAVA_FOY_ID = ((AV001_TD_BIL_FOY)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_IS_DAVA_FOYProvider.Save(davam);
                    break;

                case "AV001_TD_BIL_DAVA_NEDEN":
                    NN_IS_DAVA_NEDEN davaNedenim = new NN_IS_DAVA_NEDEN();
                    davaNedenim.IS_ID = myIs.ID;
                    davaNedenim.DAVA_NEDEN_ID = ((AV001_TD_BIL_DAVA_NEDEN)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_IS_DAVA_NEDENProvider.Save(davaNedenim);
                    break;

                //case "AV001_TD_BIL_FOY_TARAF":
                //    NN_IS_DAVA_TARAF foyTaraf = new NN_IS_DAVA_TARAF();
                //    foyTaraf.IS_ID = myIs.ID;
                //    foyTaraf.DAVA_TARAF_ID = ((AV001_TD_BIL_FOY_TARAF)Record).ID;
                //    AvukatProLib2.Data.DataRepository.NN_IS_DAVA_TARAFProvider.Save(foyTaraf);
                //    break;
                case "AV001_TDI_BIL_GORUSME":
                    NN_IS_GORUSME gorusmem = new NN_IS_GORUSME();
                    gorusmem.IS_ID = myIs.ID;
                    gorusmem.GORUSME_ID = ((AV001_TDI_BIL_GORUSME)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_IS_GORUSMEProvider.Save(gorusmem);
                    break;

                case "AV001_TI_BIL_HACIZ":
                    NN_IS_HACIZ haczim = new NN_IS_HACIZ();
                    haczim.IS_ID = myIs.ID;
                    haczim.HACIZ_ID = ((AV001_TI_BIL_HACIZ)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_IS_HACIZProvider.Save(haczim);
                    break;

                case "AV001_TD_BIL_HAZIRLIK":
                    NN_IS_HAZIRLIK hazirlik = new NN_IS_HAZIRLIK();
                    hazirlik.IS_ID = myIs.ID;
                    hazirlik.HAZIRLIK_ID = ((AV001_TD_BIL_HAZIRLIK)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_IS_HAZIRLIKProvider.Save(hazirlik);
                    break;

                case "AV001_TD_BIL_HAZIRLIK_TARAF":
                    NN_IS_HAZIRLIK_TARAF hazTarafim = new NN_IS_HAZIRLIK_TARAF();
                    hazTarafim.IS_ID = myIs.ID;
                    hazTarafim.HAZIRLIK_TARAF_ID = ((AV001_TD_BIL_HAZIRLIK_TARAF)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_IS_HAZIRLIK_TARAFProvider.Save(hazTarafim);
                    break;

                case "AV001_TI_BIL_FOY":
                    NN_IS_ICRA_FOY icram = new NN_IS_ICRA_FOY();
                    icram.IS_ID = myIs.ID;
                    icram.ICRA_FOY_ID = ((AV001_TI_BIL_FOY)Record).ID;
                    MyRecord = AvukatProLib2.Data.DataRepository.NN_IS_ICRA_FOYProvider.GetByIS_IDICRA_FOY_ID(myIs.ID, ((AV001_TI_BIL_FOY)Record).ID);
                    if (MyRecord == null)
                    {
                        AvukatProLib2.Data.DataRepository.NN_IS_ICRA_FOYProvider.Save(icram);
                    }
                    break;

                case "AV001_TI_BIL_FOY_TARAF":
                    NN_IS_ICRA_TARAF icraTarafim = new NN_IS_ICRA_TARAF();
                    icraTarafim.IS_ID = myIs.ID;
                    icraTarafim.ICRA_TARAF_ID = ((AV001_TI_BIL_FOY_TARAF)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_IS_ICRA_TARAFProvider.Save(icraTarafim);
                    break;

                //case "AV001_TDI_BIL_IS_GOREV":
                //    NN_IS_IS_GOREV isGorevim = new NN_IS_IS_GOREV();
                //    isGorevim.IS_ID = myIs.ID;
                //    isGorevim.IS_GOREV_ID = ((AV001_TDI_BIL_IS_GOREV)Record).ID;
                //    AvukatProLib2.Data.DataRepository.NN_IS_IS_GOREVProvider.Save(isGorevim);
                //    break;

                //case "AV001_TDIE_BIL_KLAVYE_MOUSE_MAKRO":
                //    NN_IS_MAKRO makrom = new NN_IS_MAKRO();
                //    makrom.IS_ID = myIs.ID;
                //    makrom.MAKRO_ID = ((AV001_TDIE_BIL_KLAVYE_MOUSE_MAKRO)Record).ID;
                //    AvukatProLib2.Data.DataRepository.NN_IS_MAKROProvider.Save(makrom);
                //    break;

                case "AV001_TDIE_BIL_MESAJ":
                    NN_IS_MESAJ mesajim = new NN_IS_MESAJ();
                    mesajim.IS_ID = myIs.ID;
                    mesajim.MESAJ_ID = ((AV001_TDIE_BIL_MESAJ)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_IS_MESAJProvider.Save(mesajim);
                    break;

                case "AV001_TDI_BIL_MUHASEBE":
                    NN_IS_MUHASEBE muhasebem = new NN_IS_MUHASEBE();
                    muhasebem.IS_ID = myIs.ID;
                    muhasebem.MUHASEBE_ID = ((AV001_TDI_BIL_MUHASEBE)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_IS_MUHASEBEProvider.Save(muhasebem);
                    break;

                case "AV001_TDI_BIL_RUCU":
                    NN_IS_RUCU rucum = new NN_IS_RUCU();
                    rucum.IS_ID = myIs.ID;
                    rucum.RUCU_ID = ((AV001_TDI_BIL_RUCU)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_IS_RUCUProvider.Save(rucum);
                    break;

                case "AV001_TDI_BIL_RUCU_TARAF":
                    NN_IS_RUCU_TARAF rucuTarafim = new NN_IS_RUCU_TARAF();
                    rucuTarafim.IS_ID = myIs.ID;
                    rucuTarafim.RUCU_TARAF_ID = ((AV001_TDI_BIL_RUCU_TARAF)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_IS_RUCU_TARAFProvider.Save(rucuTarafim);
                    break;

                //case "AV001_TDIE_BIL_SABLON_RAPOR":
                //    NN_IS_SABLON_RAPOR sablonum = new NN_IS_SABLON_RAPOR();
                //    sablonum.IS_ID = myIs.ID;
                //    sablonum.SABLON_RAPOR_ID = ((AV001_TDIE_BIL_SABLON_RAPOR)Record).ID;
                //    AvukatProLib2.Data.DataRepository.NN_IS_SABLON_RAPORProvider.Save(sablonum);
                //    break;

                case "AV001_TI_BIL_SATIS":
                    NN_IS_SATIS satisim = new NN_IS_SATIS();
                    satisim.IS_ID = myIs.ID;
                    satisim.SATIS_ID = ((AV001_TI_BIL_SATIS)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_IS_SATISProvider.Save(satisim);
                    break;

                case "AV001_TDI_BIL_SOZLESME":
                    NN_IS_SOZLESME sozlesmem = new NN_IS_SOZLESME();
                    sozlesmem.IS_ID = myIs.ID;
                    sozlesmem.SOZLESME_ID = ((AV001_TDI_BIL_SOZLESME)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_IS_SOZLESMEProvider.Save(sozlesmem);
                    break;

                case "AV001_TDI_BIL_SOZLESME_TARAF":
                    NN_IS_SOZLESME_TARAF sozlesmeTarafim = new NN_IS_SOZLESME_TARAF();
                    sozlesmeTarafim.IS_ID = myIs.ID;
                    sozlesmeTarafim.SOZLESME_TARAF_ID = ((AV001_TDI_BIL_SOZLESME_TARAF)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_IS_SOZLESME_TARAFProvider.Save(sozlesmeTarafim);
                    break;

                case "AV001_TI_BIL_TAAHHUT_ODEME":
                    NN_IS_TAAHHUT tahutum = new NN_IS_TAAHHUT();
                    tahutum.IS_ID = myIs.ID;
                    tahutum.TAAHHUT_ID = ((AV001_TI_BIL_TAAHHUT_ODEME)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_IS_TAAHHUTProvider.Save(tahutum);
                    break;

                case "AV001_TDI_BIL_TEBLIGAT":
                    NN_IS_TEBLIGAT tebligatim = new NN_IS_TEBLIGAT();
                    tebligatim.IS_ID = myIs.ID;
                    tebligatim.TEBLIGAT_ID = ((AV001_TDI_BIL_TEBLIGAT)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_IS_TEBLIGATProvider.Save(tebligatim);
                    foreach (var item in ((AV001_TDI_BIL_TEBLIGAT)Record).AV001_TDIE_BIL_BELGECollection_From_NN_BELGE_TEBLIGAT)
                    {
                        SaveIs(myIs, item);
                    }
                    break;

                case "AV001_TDI_BIL_TEBLIGAT_MUHATAP":
                    NN_IS_TEBLIGAT_MUHATAB tebligatMuhatabim = new NN_IS_TEBLIGAT_MUHATAB();
                    tebligatMuhatabim.IS_ID = myIs.ID;
                    tebligatMuhatabim.TEBLIGAT_MUHATAB_ID = ((AV001_TDI_BIL_TEBLIGAT_MUHATAP)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_IS_TEBLIGAT_MUHATABProvider.Save(tebligatMuhatabim);
                    break;

                default:
                    break;
            }
        }

        public static void SaveToBelgeIliski(AV001_TDIE_BIL_BELGE belge, string tablo, int id)
        {
            bool saved = false;

            TList<AV001_TDIE_BIL_BELGE_ILISKI> iliskiler = AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_BELGE_ILISKIProvider.GetByBELGE_ID(belge.ID);
            for (int i = 0; i < iliskiler.Count; i++)
            {
                if (iliskiler[i].VALUE.Value == id)
                {
                    iliskiler[i].BELGE_ID = belge.ID;

                    iliskiler[i].TABLE_NAME = tablo;
                    iliskiler[i].VALUE = id;
                    AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_BELGE_ILISKIProvider.Save(iliskiler[i]);
                    saved = true;
                }
            }

            if (!saved)
            {
                AV001_TDIE_BIL_BELGE_ILISKI iliski = new AV001_TDIE_BIL_BELGE_ILISKI();
                iliski.BELGE_ID = belge.ID;

                iliski.GIZLILIK_ID = 1;
                iliski.TABLE_NAME = tablo;
                iliski.VALUE = id;
                AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_BELGE_ILISKIProvider.Save(iliski);
                belge.AV001_TDIE_BIL_BELGE_ILISKICollection.Add(iliski);
            }
        }

        private static List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE> GetDirekBagliBelgeler(int id, string TABLO)
        {
            List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE> iliskiliBelgeler = new List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE>();

            TList<AV001_TDIE_BIL_BELGE_ILISKI> BELGELER = AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_BELGE_ILISKIProvider.Find(string.Format("VALUE='{0}' AND TABLO='{1}'", id, TABLO));
            if (BELGELER != null)
            {
                foreach (AV001_TDIE_BIL_BELGE_ILISKI iliski in BELGELER)
                    iliskiliBelgeler.Add(BelgeUtil.Inits._BelgeGetir != null ? BelgeUtil.Inits._BelgeGetir.Single(item => item.ID == iliski.BELGE_ID) : BelgeUtil.Inits.context.per_AV001_TDIE_BIL_BELGEs.Single(item => item.ID == iliski.BELGE_ID));
            }
            return iliskiliBelgeler;
        }
    }
}