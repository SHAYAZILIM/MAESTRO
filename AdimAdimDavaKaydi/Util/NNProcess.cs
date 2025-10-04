using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.Util
{
    public static class NNProcess
    {
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
                case "AV001_TDI_BIL_CELSE":
                    NN_BELGE_CELSE celsem = new NN_BELGE_CELSE();
                    celsem.BELGE_ID = belge.ID;
                    celsem.CELSE_ID = ((AV001_TDI_BIL_CELSE)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_CELSEProvider.Save(celsem);
                    break;
                case "AV001_TD_BIL_FOY":
                    NN_BELGE_DAVA davam = new NN_BELGE_DAVA();
                    davam.BELGE_ID = belge.ID;
                    davam.DAVA_FOY_ID = ((AV001_TD_BIL_FOY)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_DAVAProvider.Save(davam);
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
                case "AV001_TI_BIL_HACIZ":
                    NN_BELGE_HACIZ haczim = new NN_BELGE_HACIZ();
                    haczim.BELGE_ID = belge.ID;
                    haczim.HACIZ_ID = ((AV001_TI_BIL_HACIZ)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_HACIZProvider.Save(haczim);
                    break;
                case "AV001_TD_BIL_HAZIRLIK":
                    NN_BELGE_HAZIRLIK hazirlik = new NN_BELGE_HAZIRLIK();
                    hazirlik.BELGE_ID = belge.ID;
                    hazirlik.HAZIRLIK_ID = ((AV001_TD_BIL_HAZIRLIK)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_HAZIRLIKProvider.Save(hazirlik);
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
                    AvukatProLib2.Data.DataRepository.NN_IS_BELGEProvider.Save(isim);
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
                    AvukatProLib2.Data.DataRepository.NN_BELGE_RUCUProvider.Save(rucum);
                    break;

                case "AV001_TDI_BIL_RUCU_TARAF":
                    NN_BELGE_RUCU_TARAF rucuTarafim = new NN_BELGE_RUCU_TARAF();
                    rucuTarafim.BELGE_ID = belge.ID;
                    rucuTarafim.RUCU_TARAF_ID = ((AV001_TDI_BIL_RUCU_TARAF)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_RUCU_TARAFProvider.Save(rucuTarafim);
                    break;

                case "AV001_TDIE_BIL_SABLON_RAPOR":
                    NN_BELGE_SABLON_RAPOR sablonum = new NN_BELGE_SABLON_RAPOR();
                    sablonum.BELGE_ID = belge.ID;
                    sablonum.SABLON_RAPOR_ID = ((AV001_TDIE_BIL_SABLON_RAPOR)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_SABLON_RAPORProvider.Save(sablonum);
                    break;

                case "AV001_TI_BIL_SATIS":
                    NN_BELGE_SATIS satisim = new NN_BELGE_SATIS();
                    satisim.BELGE_ID = belge.ID;
                    satisim.SATIS_ID = ((AV001_TI_BIL_SATIS)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_SATISProvider.Save(satisim);
                    break;

                case "AV001_TDI_BIL_SOZLESME":
                    NN_BELGE_SOZLESME sozlesmem = new NN_BELGE_SOZLESME();
                    sozlesmem.BELGE_ID = belge.ID;
                    sozlesmem.SOZLESME_ID = ((AV001_TDI_BIL_SOZLESME)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_SOZLESMEProvider.Save(sozlesmem);
                    break;

                case "AV001_TDI_BIL_SOZLESME_TARAF":
                    NN_BELGE_SOZLESME_TARAF sozlesmeTarafim = new NN_BELGE_SOZLESME_TARAF();
                    sozlesmeTarafim.BELGE_ID = belge.ID;
                    sozlesmeTarafim.SOZLESME_TARAF_ID = ((AV001_TDI_BIL_SOZLESME_TARAF)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_SOZLESME_TARAFProvider.Save(sozlesmeTarafim);
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
                    AvukatProLib2.Data.DataRepository.NN_BELGE_TEBLIGATProvider.Save(tebligatim);
                    break;

                case "AV001_TDI_BIL_TEBLIGAT_MUHATAP":
                    NN_BELGE_TEBLIGAT_MUHATAB tebligatMuhatabim = new NN_BELGE_TEBLIGAT_MUHATAB();
                    tebligatMuhatabim.BELGE_ID = belge.ID;
                    tebligatMuhatabim.TEBLIGAT_MUHATAB_ID = ((AV001_TDI_BIL_TEBLIGAT_MUHATAP)Record).ID;
                    AvukatProLib2.Data.DataRepository.NN_BELGE_TEBLIGAT_MUHATABProvider.Save(tebligatMuhatabim);
                    break;

                default:
                    break;
            }
        }

        public static void SaveIs(AV001_TDI_BIL_IS myIs, IEntity Record)
        {
            IEntity MyRecord;
            if (Record == null)
                return;
            string Tablo = Record.TableName;
            switch (Tablo)
            {
                case "AV001_TD_BIL_ARA_KARAR":
                    NN_IS_ARAKARAR arakarar = new NN_IS_ARAKARAR();
                    arakarar.IS_ID = myIs.ID;
                    arakarar.ARAKARAR_ID = ((AV001_TD_BIL_ARA_KARAR)Record).ID;
                    MyRecord = AvukatProLib2.Data.DataRepository.NN_IS_ARAKARARProvider.GetByIS_IDARAKARAR_ID(myIs.ID,
                                                                                                              ((
                                                                                                               AV001_TD_BIL_ARA_KARAR
                                                                                                               )Record)
                                                                                                                  .ID);
                    if (Record == null)
                    {
                        AvukatProLib2.Data.DataRepository.NN_IS_ARAKARARProvider.Save(arakarar);
                    }

                    break;
                case "AV001_TDIE_BIL_BELGE":
                    NN_IS_BELGE belgem = new NN_IS_BELGE();
                    belgem.IS_ID = myIs.ID;
                    belgem.BELGE_ID = ((AV001_TDIE_BIL_BELGE)Record).ID;
                    MyRecord = AvukatProLib2.Data.DataRepository.NN_IS_BELGEProvider.GetByIS_IDBELGE_ID(myIs.ID,
                                                                                                        ((
                                                                                                         AV001_TDIE_BIL_BELGE
                                                                                                         )Record).ID);
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
                case "AV001_TD_BIL_CELSE":
                    NN_IS_CELSE celsem = new NN_IS_CELSE();
                    celsem.IS_ID = myIs.ID;
                    celsem.IS_IDSource = myIs;
                    DataRepository.AV001_TD_BIL_CELSEProvider.DeepLoad((AV001_TD_BIL_CELSE)Record, false,
                                                                       DeepLoadType.IncludeChildren,
                                                                       typeof(AV001_TD_BIL_FOY));

                    celsem.CELSE_ID = ((AV001_TD_BIL_CELSE)Record).ID;
                    celsem.CELSE_IDSource = (AV001_TD_BIL_CELSE)Record;
                    AvukatProLib2.Data.DataRepository.NN_IS_CELSEProvider.DeepSave(celsem);
                    NN_IS_DAVA_FOY davamc = new NN_IS_DAVA_FOY();
                    davamc.IS_IDSource = myIs;
                    davamc.IS_ID = myIs.ID;
                    davamc.DAVA_FOY_IDSource = ((AV001_TD_BIL_CELSE)Record).DAVA_FOY_IDSource;
                    davamc.DAVA_FOY_ID = (((AV001_TD_BIL_CELSE)Record).DAVA_FOY_IDSource).ID;
                    MyRecord = AvukatProLib2.Data.DataRepository.NN_IS_DAVA_FOYProvider.GetByIS_IDDAVA_FOY_ID(myIs.ID,
                                                                                                              davamc.
                                                                                                                  DAVA_FOY_ID);
                    if (MyRecord == null)
                    {
                        AvukatProLib2.Data.DataRepository.NN_IS_DAVA_FOYProvider.DeepSave(davamc);
                        AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_ISProvider.DeepLoad(myIs);
                        AvukatProLib2.Data.DataRepository.NN_IS_CARIProvider.DeepSave(myIs.NN_IS_CARICollection);//ARCH
                    }
                    break;
                case "AV001_TD_BIL_FOY":
                    NN_IS_DAVA_FOY davam = new NN_IS_DAVA_FOY();
                    davam.IS_IDSource = myIs;
                    davam.IS_ID = myIs.ID;
                    davam.DAVA_FOY_IDSource = ((AV001_TD_BIL_FOY)Record);
                    davam.DAVA_FOY_ID = ((AV001_TD_BIL_FOY)Record).ID;
                    MyRecord = AvukatProLib2.Data.DataRepository.NN_IS_DAVA_FOYProvider.GetByIS_IDDAVA_FOY_ID(myIs.ID,
                                                                                                              davam.
                                                                                                                  DAVA_FOY_ID);
                    if (MyRecord == null)
                    {
                        AvukatProLib2.Data.DataRepository.NN_IS_DAVA_FOYProvider.DeepSave(davam);
                        AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_ISProvider.DeepLoad(myIs);
                        AvukatProLib2.Data.DataRepository.NN_IS_CARIProvider.DeepSave(myIs.NN_IS_CARICollection);//ARCH
                    }
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
                    //AV001_TDI_BIL_GORUSME
                    NN_IS_GORUSME gorusmem = new NN_IS_GORUSME();
                    gorusmem.IS_ID = myIs.ID;
                    gorusmem.IS_IDSource = myIs;
                    gorusmem.GORUSME_ID = ((AV001_TDI_BIL_GORUSME)Record).ID;
                    gorusmem.GORUSME_IDSource = (AV001_TDI_BIL_GORUSME)Record;
                    DataRepository.AV001_TDI_BIL_GORUSMEProvider.DeepLoad((AV001_TDI_BIL_GORUSME)Record, false,
                                                                          DeepLoadType.IncludeChildren,
                                                                          typeof(AV001_TD_BIL_FOY),
                                                                          typeof(AV001_TI_BIL_FOY));
                    AvukatProLib2.Data.DataRepository.NN_IS_GORUSMEProvider.DeepSave(gorusmem);

                    if ((Record as AV001_TDI_BIL_GORUSME).DAVA_FOY_IDSource != null)
                    {
                        NN_IS_DAVA_FOY davamgc = new NN_IS_DAVA_FOY();
                        davamgc.IS_IDSource = myIs;
                        davamgc.IS_ID = myIs.ID;
                        davamgc.DAVA_FOY_IDSource = ((AV001_TDI_BIL_GORUSME)Record).DAVA_FOY_IDSource;
                        davamgc.DAVA_FOY_ID = (((AV001_TDI_BIL_GORUSME)Record).DAVA_FOY_IDSource).ID;
                        MyRecord =
                            AvukatProLib2.Data.DataRepository.NN_IS_DAVA_FOYProvider.GetByIS_IDDAVA_FOY_ID(myIs.ID,
                                                                                                           davamgc.
                                                                                                               DAVA_FOY_ID);
                        if (MyRecord == null)
                        {
                            AvukatProLib2.Data.DataRepository.NN_IS_DAVA_FOYProvider.DeepSave(davamgc);
                            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_ISProvider.DeepLoad(myIs);
                            AvukatProLib2.Data.DataRepository.NN_IS_CARIProvider.DeepSave(myIs.NN_IS_CARICollection);//ARCH
                        }
                    }
                    else if ((Record as AV001_TDI_BIL_GORUSME).ICRA_FOY_IDSource != null)
                    {
                        NN_IS_ICRA_FOY icramg = new NN_IS_ICRA_FOY();
                        icramg.IS_ID = myIs.ID;
                        icramg.ICRA_FOY_ID = ((AV001_TDI_BIL_GORUSME)Record).ICRA_FOY_IDSource.ID;
                        MyRecord =
                            AvukatProLib2.Data.DataRepository.NN_IS_ICRA_FOYProvider.GetByIS_IDICRA_FOY_ID(myIs.ID,
                                                                                                           icramg.
                                                                                                               ICRA_FOY_ID);
                        if (MyRecord == null)
                        {
                            AvukatProLib2.Data.DataRepository.NN_IS_ICRA_FOYProvider.DeepSave(icramg);
                        }
                    }

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
                    //hazirlik.HAZIRLIK_IDSource = ((AV001_TD_BIL_HAZIRLIK)Record);
                    hazirlik.HAZIRLIK_ID = ((AV001_TD_BIL_HAZIRLIK)Record).ID;
                    //MyRecord = AvukatProLib2.Data.DataRepository.NN_IS_DAVA_FOYProvider.GetByIS_IDDAVA_FOY_ID(myIs.ID, hazirlik.HAZIRLIK_ID);
                    MyRecord = AvukatProLib2.Data.DataRepository.NN_IS_HAZIRLIKProvider.GetByIS_IDHAZIRLIK_ID(myIs.ID,
                                                                                                              ((
                                                                                                               AV001_TD_BIL_HAZIRLIK
                                                                                                               )Record)
                                                                                                                  .ID);
                    if (MyRecord == null)
                        AvukatProLib2.Data.DataRepository.NN_IS_HAZIRLIKProvider.Save(hazirlik);
                    //if (MyRecord == null)
                    //{
                    //    AvukatProLib2.Data.DataRepository.NN_IS_DAVA_FOYProvider.DeepSave(hazirlik);
                    //    AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_ISProvider.DeepLoad(myIs);
                    //}
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
                    MyRecord = AvukatProLib2.Data.DataRepository.NN_IS_ICRA_FOYProvider.GetByIS_IDICRA_FOY_ID(myIs.ID,
                                                                                                              ((
                                                                                                               AV001_TI_BIL_FOY
                                                                                                               )Record)
                                                                                                                  .ID);
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
                    if (
                        ((AV001_TDI_BIL_SOZLESME)Record).NN_IS_SOZLESMECollection.FindAll(NN_IS_SOZLESMEColumn.IS_ID,
                                                                                           myIs.ID).Count == 0)
                    {
                        NN_IS_SOZLESME sozlesmem = new NN_IS_SOZLESME();
                        sozlesmem.IS_ID = myIs.ID;
                        sozlesmem.SOZLESME_ID = ((AV001_TDI_BIL_SOZLESME)Record).ID;
                        AvukatProLib2.Data.DataRepository.NN_IS_SOZLESMEProvider.Save(sozlesmem);
                    }
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
    }
}