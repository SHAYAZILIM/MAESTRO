using AvukatProLib2.Data;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;
using System;
using System.Collections.Generic;

//using Inits = AdimAdimDavaKaydi.Util.Inits;
//TODO: hata verdi kim yaptý dedim 4 kere baðýrdým cvp gelmedi ve bende comment ettim --THSN--

namespace AvukatProLib.Rapor.RaporSource
{
    internal class RSIcraGenel : Util.IRaporSource
    {
        #region Settings

        public bool EnableChart
        {
            get { return false; }
        }

        public bool EnableGrid
        {
            get { return true; }
        }

        public bool EnablePivot
        {
            get { return true; }
        }

        public bool EnablePrintChart
        {
            get { return false; }
        }

        public bool EnablePrintList
        {
            get { return false; }
        }

        public bool EnablePrintPivot
        {
            get { return false; }
        }

        public bool EnableSaveChart
        {
            get { return false; }
        }

        public bool EnableSaveList
        {
            get { return false; }
        }

        public bool EnableSavePivot
        {
            get { return false; }
        }

        public string Groups
        {
            get { return "Ýcra"; }
        }

        public string MenuName
        {
            get { return "Ýcra Hesaplý Kapsamlý Genel"; }
        }

        public string Title
        {
            get { return "Title"; }
        }

        #endregion Settings

        private object _MyDataSource;

        public object MyDataSource
        {
            get
            {
                if (_MyDataSource != null)
                    return _MyDataSource;
                else
                {
                    _MyDataSource = DataRepository.R_TI_BIL_HESAPLI_KAPSAMLI_TARAF_VE_SORUMLULUProvider.GetAll();
                    return _MyDataSource;
                }
            }
        }

        public GridColumn[] GetGridColumns()
        {
            #region Field & Properties

            GridColumn colCARI_ADI = new GridColumn();
            colCARI_ADI.VisibleIndex = 0;
            colCARI_ADI.FieldName = "CARI_ADI";
            colCARI_ADI.Name = "colCARI_ADI";
            colCARI_ADI.Visible = true;

            GridColumn colCARI_ID = new GridColumn();
            colCARI_ID.VisibleIndex = 1;
            colCARI_ID.FieldName = "CARI_ID";
            colCARI_ID.Name = "colCARI_ID";
            colCARI_ID.Visible = true;

            GridColumn colSORUMLU_AVUKAT_CARI_ID = new GridColumn();
            colSORUMLU_AVUKAT_CARI_ID.VisibleIndex = 2;
            colSORUMLU_AVUKAT_CARI_ID.FieldName = "SORUMLU_AVUKAT_CARI_ID";
            colSORUMLU_AVUKAT_CARI_ID.Name = "colSORUMLU_AVUKAT_CARI_ID";
            colSORUMLU_AVUKAT_CARI_ID.Visible = true;

            GridColumn colTARAF_KODU = new GridColumn();
            colTARAF_KODU.VisibleIndex = 3;
            colTARAF_KODU.FieldName = "TARAF_KODU";
            colTARAF_KODU.Name = "colTARAF_KODU";
            colTARAF_KODU.Visible = true;

            GridColumn colKOD = new GridColumn();
            colKOD.VisibleIndex = 4;
            colKOD.FieldName = "KOD";
            colKOD.Name = "colKOD";
            colKOD.Visible = true;

            GridColumn colTARAF_SIFAT_ID = new GridColumn();
            colTARAF_SIFAT_ID.VisibleIndex = 5;
            colTARAF_SIFAT_ID.FieldName = "TARAF_SIFAT_ID";
            colTARAF_SIFAT_ID.Name = "colTARAF_SIFAT_ID";
            colTARAF_SIFAT_ID.Visible = true;

            GridColumn colSIFAT = new GridColumn();
            colSIFAT.VisibleIndex = 6;
            colSIFAT.FieldName = "SIFAT";
            colSIFAT.Name = "colSIFAT";
            colSIFAT.Visible = true;

            GridColumn colID = new GridColumn();
            colID.VisibleIndex = 7;
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = true;

            GridColumn colTALEP_ADI = new GridColumn();
            colTALEP_ADI.VisibleIndex = 8;
            colTALEP_ADI.FieldName = "TALEP_ADI";
            colTALEP_ADI.Name = "colTALEP_ADI";
            colTALEP_ADI.Visible = true;

            GridColumn colFORM_TIP_ID = new GridColumn();
            colFORM_TIP_ID.VisibleIndex = 9;
            colFORM_TIP_ID.FieldName = "FORM_TIP_ID";
            colFORM_TIP_ID.Name = "colFORM_TIP_ID";
            colFORM_TIP_ID.Visible = true;

            GridColumn colFORM_ADI = new GridColumn();
            colFORM_ADI.VisibleIndex = 10;
            colFORM_ADI.FieldName = "FORM_ADI";
            colFORM_ADI.Name = "colFORM_ADI";
            colFORM_ADI.Visible = true;

            GridColumn colFOY_DURUM_ID = new GridColumn();
            colFOY_DURUM_ID.VisibleIndex = 11;
            colFOY_DURUM_ID.FieldName = "FOY_DURUM_ID";
            colFOY_DURUM_ID.Name = "colFOY_DURUM_ID";
            colFOY_DURUM_ID.Visible = true;

            GridColumn colDURUM = new GridColumn();
            colDURUM.VisibleIndex = 12;
            colDURUM.FieldName = "DURUM";
            colDURUM.Name = "colDURUM";
            colDURUM.Visible = true;

            GridColumn colFOY_NO = new GridColumn();
            colFOY_NO.VisibleIndex = 13;
            colFOY_NO.FieldName = "FOY_NO";
            colFOY_NO.Name = "colFOY_NO";
            colFOY_NO.Visible = true;

            GridColumn colREFERANS_NO = new GridColumn();
            colREFERANS_NO.VisibleIndex = 14;
            colREFERANS_NO.FieldName = "REFERANS_NO";
            colREFERANS_NO.Name = "colREFERANS_NO";
            colREFERANS_NO.Visible = true;

            GridColumn colREFERANS_NO2 = new GridColumn();
            colREFERANS_NO2.VisibleIndex = 15;
            colREFERANS_NO2.FieldName = "REFERANS_NO2";
            colREFERANS_NO2.Name = "colREFERANS_NO2";
            colREFERANS_NO2.Visible = true;

            GridColumn colREFERANS_NO3 = new GridColumn();
            colREFERANS_NO3.VisibleIndex = 16;
            colREFERANS_NO3.FieldName = "REFERANS_NO3";
            colREFERANS_NO3.Name = "colREFERANS_NO3";
            colREFERANS_NO3.Visible = true;

            GridColumn colADLI_BIRIM_NO_ID = new GridColumn();
            colADLI_BIRIM_NO_ID.VisibleIndex = 17;
            colADLI_BIRIM_NO_ID.FieldName = "ADLI_BIRIM_NO_ID";
            colADLI_BIRIM_NO_ID.Name = "colADLI_BIRIM_NO_ID";
            colADLI_BIRIM_NO_ID.Visible = true;

            GridColumn colNO = new GridColumn();
            colNO.VisibleIndex = 18;
            colNO.FieldName = "NO";
            colNO.Name = "colNO";
            colNO.Visible = true;

            GridColumn colADLIYE = new GridColumn();
            colADLIYE.VisibleIndex = 19;
            colADLIYE.FieldName = "ADLIYE";
            colADLIYE.Name = "colADLIYE";
            colADLIYE.Visible = true;

            GridColumn colADLI_BIRIM_ADLIYE_ID = new GridColumn();
            colADLI_BIRIM_ADLIYE_ID.VisibleIndex = 20;
            colADLI_BIRIM_ADLIYE_ID.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            colADLI_BIRIM_ADLIYE_ID.Name = "colADLI_BIRIM_ADLIYE_ID";
            colADLI_BIRIM_ADLIYE_ID.Visible = true;

            GridColumn colICRA_OZEL_KOD1_ID = new GridColumn();
            colICRA_OZEL_KOD1_ID.VisibleIndex = 21;
            colICRA_OZEL_KOD1_ID.FieldName = "ICRA_OZEL_KOD1_ID";
            colICRA_OZEL_KOD1_ID.Name = "colICRA_OZEL_KOD1_ID";
            colICRA_OZEL_KOD1_ID.Visible = true;

            GridColumn colICRA_OZEL_KOD2_ID = new GridColumn();
            colICRA_OZEL_KOD2_ID.VisibleIndex = 22;
            colICRA_OZEL_KOD2_ID.FieldName = "ICRA_OZEL_KOD2_ID";
            colICRA_OZEL_KOD2_ID.Name = "colICRA_OZEL_KOD2_ID";
            colICRA_OZEL_KOD2_ID.Visible = true;

            GridColumn colICRA_OZEL_KOD3_ID = new GridColumn();
            colICRA_OZEL_KOD3_ID.VisibleIndex = 23;
            colICRA_OZEL_KOD3_ID.FieldName = "ICRA_OZEL_KOD3_ID";
            colICRA_OZEL_KOD3_ID.Name = "colICRA_OZEL_KOD3_ID";
            colICRA_OZEL_KOD3_ID.Visible = true;

            GridColumn colICRA_OZEL_KOD4_ID = new GridColumn();
            colICRA_OZEL_KOD4_ID.VisibleIndex = 24;
            colICRA_OZEL_KOD4_ID.FieldName = "ICRA_OZEL_KOD4_ID";
            colICRA_OZEL_KOD4_ID.Name = "colICRA_OZEL_KOD4_ID";
            colICRA_OZEL_KOD4_ID.Visible = true;

            GridColumn colTAKIBIN_AVUKATA_INTIKAL_TARIHI = new GridColumn();
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.VisibleIndex = 25;
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "colTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = true;

            GridColumn colFOY_ARSIV_TARIHI = new GridColumn();
            colFOY_ARSIV_TARIHI.VisibleIndex = 26;
            colFOY_ARSIV_TARIHI.FieldName = "FOY_ARSIV_TARIHI";
            colFOY_ARSIV_TARIHI.Name = "colFOY_ARSIV_TARIHI";
            colFOY_ARSIV_TARIHI.Visible = true;

            GridColumn colFOY_INFAZ_TARIHI = new GridColumn();
            colFOY_INFAZ_TARIHI.VisibleIndex = 27;
            colFOY_INFAZ_TARIHI.FieldName = "FOY_INFAZ_TARIHI";
            colFOY_INFAZ_TARIHI.Name = "colFOY_INFAZ_TARIHI";
            colFOY_INFAZ_TARIHI.Visible = true;

            GridColumn colTAKIBIN_MUVEKKILE_IADE_TARIHI = new GridColumn();
            colTAKIBIN_MUVEKKILE_IADE_TARIHI.VisibleIndex = 28;
            colTAKIBIN_MUVEKKILE_IADE_TARIHI.FieldName = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            colTAKIBIN_MUVEKKILE_IADE_TARIHI.Name = "colTAKIBIN_MUVEKKILE_IADE_TARIHI";
            colTAKIBIN_MUVEKKILE_IADE_TARIHI.Visible = true;

            GridColumn colSON_HESAP_TARIHI = new GridColumn();
            colSON_HESAP_TARIHI.VisibleIndex = 29;
            colSON_HESAP_TARIHI.FieldName = "SON_HESAP_TARIHI";
            colSON_HESAP_TARIHI.Name = "colSON_HESAP_TARIHI";
            colSON_HESAP_TARIHI.Visible = true;

            GridColumn colBIR_YIL_KAC_GUN = new GridColumn();
            colBIR_YIL_KAC_GUN.VisibleIndex = 30;
            colBIR_YIL_KAC_GUN.FieldName = "BIR_YIL_KAC_GUN";
            colBIR_YIL_KAC_GUN.Name = "colBIR_YIL_KAC_GUN";
            colBIR_YIL_KAC_GUN.Visible = true;

            GridColumn colASIL_ALACAK_DOVIZ_ID = new GridColumn();
            colASIL_ALACAK_DOVIZ_ID.VisibleIndex = 31;
            colASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            colASIL_ALACAK_DOVIZ_ID.Name = "colASIL_ALACAK_DOVIZ_ID";
            colASIL_ALACAK_DOVIZ_ID.Visible = true;

            GridColumn colASIL_ALACAK = new GridColumn();
            colASIL_ALACAK.VisibleIndex = 32;
            colASIL_ALACAK.FieldName = "ASIL_ALACAK";
            colASIL_ALACAK.Name = "colASIL_ALACAK";
            colASIL_ALACAK.Visible = true;

            GridColumn colISLEMIS_FAIZ_DOVIZ_ID = new GridColumn();
            colISLEMIS_FAIZ_DOVIZ_ID.VisibleIndex = 33;
            colISLEMIS_FAIZ_DOVIZ_ID.FieldName = "ISLEMIS_FAIZ_DOVIZ_ID";
            colISLEMIS_FAIZ_DOVIZ_ID.Name = "colISLEMIS_FAIZ_DOVIZ_ID";
            colISLEMIS_FAIZ_DOVIZ_ID.Visible = true;

            GridColumn colISLEMIS_FAIZ = new GridColumn();
            colISLEMIS_FAIZ.VisibleIndex = 34;
            colISLEMIS_FAIZ.FieldName = "ISLEMIS_FAIZ";
            colISLEMIS_FAIZ.Name = "colISLEMIS_FAIZ";
            colISLEMIS_FAIZ.Visible = true;

            GridColumn colBSMV_TO_DOVIZ_ID = new GridColumn();
            colBSMV_TO_DOVIZ_ID.VisibleIndex = 35;
            colBSMV_TO_DOVIZ_ID.FieldName = "BSMV_TO_DOVIZ_ID";
            colBSMV_TO_DOVIZ_ID.Name = "colBSMV_TO_DOVIZ_ID";
            colBSMV_TO_DOVIZ_ID.Visible = true;

            GridColumn colBSMV_TO = new GridColumn();
            colBSMV_TO.VisibleIndex = 36;
            colBSMV_TO.FieldName = "BSMV_TO";
            colBSMV_TO.Name = "colBSMV_TO";
            colBSMV_TO.Visible = true;

            GridColumn colKKDV_TO_DOVIZ_ID = new GridColumn();
            colKKDV_TO_DOVIZ_ID.VisibleIndex = 37;
            colKKDV_TO_DOVIZ_ID.FieldName = "KKDV_TO_DOVIZ_ID";
            colKKDV_TO_DOVIZ_ID.Name = "colKKDV_TO_DOVIZ_ID";
            colKKDV_TO_DOVIZ_ID.Visible = true;

            GridColumn colKKDV_TO = new GridColumn();
            colKKDV_TO.VisibleIndex = 38;
            colKKDV_TO.FieldName = "KKDV_TO";
            colKKDV_TO.Name = "colKKDV_TO";
            colKKDV_TO.Visible = true;

            GridColumn colOIV_TO = new GridColumn();
            colOIV_TO.VisibleIndex = 39;
            colOIV_TO.FieldName = "OIV_TO";
            colOIV_TO.Name = "colOIV_TO";
            colOIV_TO.Visible = true;

            GridColumn colKDV_TO_DOVIZ_ID = new GridColumn();
            colKDV_TO_DOVIZ_ID.VisibleIndex = 40;
            colKDV_TO_DOVIZ_ID.FieldName = "KDV_TO_DOVIZ_ID";
            colKDV_TO_DOVIZ_ID.Name = "colKDV_TO_DOVIZ_ID";
            colKDV_TO_DOVIZ_ID.Visible = true;

            GridColumn colKDV_TO = new GridColumn();
            colKDV_TO.VisibleIndex = 41;
            colKDV_TO.FieldName = "KDV_TO";
            colKDV_TO.Name = "colKDV_TO";
            colKDV_TO.Visible = true;

            GridColumn colIH_VEKALET_UCRETI_DOVIZ_ID = new GridColumn();
            colIH_VEKALET_UCRETI_DOVIZ_ID.VisibleIndex = 42;
            colIH_VEKALET_UCRETI_DOVIZ_ID.FieldName = "IH_VEKALET_UCRETI_DOVIZ_ID";
            colIH_VEKALET_UCRETI_DOVIZ_ID.Name = "colIH_VEKALET_UCRETI_DOVIZ_ID";
            colIH_VEKALET_UCRETI_DOVIZ_ID.Visible = true;

            GridColumn colIH_VEKALET_UCRETI = new GridColumn();
            colIH_VEKALET_UCRETI.VisibleIndex = 43;
            colIH_VEKALET_UCRETI.FieldName = "IH_VEKALET_UCRETI";
            colIH_VEKALET_UCRETI.Name = "colIH_VEKALET_UCRETI";
            colIH_VEKALET_UCRETI.Visible = true;

            GridColumn colIH_GIDERI_DOVIZ_ID = new GridColumn();
            colIH_GIDERI_DOVIZ_ID.VisibleIndex = 44;
            colIH_GIDERI_DOVIZ_ID.FieldName = "IH_GIDERI_DOVIZ_ID";
            colIH_GIDERI_DOVIZ_ID.Name = "colIH_GIDERI_DOVIZ_ID";
            colIH_GIDERI_DOVIZ_ID.Visible = true;

            GridColumn colIH_GIDERI = new GridColumn();
            colIH_GIDERI.VisibleIndex = 45;
            colIH_GIDERI.FieldName = "IH_GIDERI";
            colIH_GIDERI.Name = "colIH_GIDERI";
            colIH_GIDERI.Visible = true;

            GridColumn colIT_HACIZDE_ODENEN_DOVIZ_ID = new GridColumn();
            colIT_HACIZDE_ODENEN_DOVIZ_ID.VisibleIndex = 46;
            colIT_HACIZDE_ODENEN_DOVIZ_ID.FieldName = "IT_HACIZDE_ODENEN_DOVIZ_ID";
            colIT_HACIZDE_ODENEN_DOVIZ_ID.Name = "colIT_HACIZDE_ODENEN_DOVIZ_ID";
            colIT_HACIZDE_ODENEN_DOVIZ_ID.Visible = true;

            GridColumn colIT_HACIZDE_ODENEN = new GridColumn();
            colIT_HACIZDE_ODENEN.VisibleIndex = 47;
            colIT_HACIZDE_ODENEN.FieldName = "IT_HACIZDE_ODENEN";
            colIT_HACIZDE_ODENEN.Name = "colIT_HACIZDE_ODENEN";
            colIT_HACIZDE_ODENEN.Visible = true;

            GridColumn colKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = new GridColumn();
            colKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.VisibleIndex = 48;
            colKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.FieldName = "KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID";
            colKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.Name = "colKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID";
            colKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.Visible = true;

            GridColumn colKARSILIKSIZ_CEK_TAZMINATI = new GridColumn();
            colKARSILIKSIZ_CEK_TAZMINATI.VisibleIndex = 49;
            colKARSILIKSIZ_CEK_TAZMINATI.FieldName = "KARSILIKSIZ_CEK_TAZMINATI";
            colKARSILIKSIZ_CEK_TAZMINATI.Name = "colKARSILIKSIZ_CEK_TAZMINATI";
            colKARSILIKSIZ_CEK_TAZMINATI.Visible = true;

            GridColumn colCEK_KOMISYONU_DOVIZ_ID = new GridColumn();
            colCEK_KOMISYONU_DOVIZ_ID.VisibleIndex = 50;
            colCEK_KOMISYONU_DOVIZ_ID.FieldName = "CEK_KOMISYONU_DOVIZ_ID";
            colCEK_KOMISYONU_DOVIZ_ID.Name = "colCEK_KOMISYONU_DOVIZ_ID";
            colCEK_KOMISYONU_DOVIZ_ID.Visible = true;

            GridColumn colCEK_KOMISYONU = new GridColumn();
            colCEK_KOMISYONU.VisibleIndex = 51;
            colCEK_KOMISYONU.FieldName = "CEK_KOMISYONU";
            colCEK_KOMISYONU.Name = "colCEK_KOMISYONU";
            colCEK_KOMISYONU.Visible = true;

            GridColumn colILAM_YARGILAMA_GIDERI_DOVIZ_ID = new GridColumn();
            colILAM_YARGILAMA_GIDERI_DOVIZ_ID.VisibleIndex = 52;
            colILAM_YARGILAMA_GIDERI_DOVIZ_ID.FieldName = "ILAM_YARGILAMA_GIDERI_DOVIZ_ID";
            colILAM_YARGILAMA_GIDERI_DOVIZ_ID.Name = "colILAM_YARGILAMA_GIDERI_DOVIZ_ID";
            colILAM_YARGILAMA_GIDERI_DOVIZ_ID.Visible = true;

            GridColumn colILAM_YARGILAMA_GIDERI = new GridColumn();
            colILAM_YARGILAMA_GIDERI.VisibleIndex = 53;
            colILAM_YARGILAMA_GIDERI.FieldName = "ILAM_YARGILAMA_GIDERI";
            colILAM_YARGILAMA_GIDERI.Name = "colILAM_YARGILAMA_GIDERI";
            colILAM_YARGILAMA_GIDERI.Visible = true;

            GridColumn colILAM_BK_YARG_ONAMA_DOVIZ_ID = new GridColumn();
            colILAM_BK_YARG_ONAMA_DOVIZ_ID.VisibleIndex = 54;
            colILAM_BK_YARG_ONAMA_DOVIZ_ID.FieldName = "ILAM_BK_YARG_ONAMA_DOVIZ_ID";
            colILAM_BK_YARG_ONAMA_DOVIZ_ID.Name = "colILAM_BK_YARG_ONAMA_DOVIZ_ID";
            colILAM_BK_YARG_ONAMA_DOVIZ_ID.Visible = true;

            GridColumn colILAM_BK_YARG_ONAMA = new GridColumn();
            colILAM_BK_YARG_ONAMA.VisibleIndex = 55;
            colILAM_BK_YARG_ONAMA.FieldName = "ILAM_BK_YARG_ONAMA";
            colILAM_BK_YARG_ONAMA.Name = "colILAM_BK_YARG_ONAMA";
            colILAM_BK_YARG_ONAMA.Visible = true;

            GridColumn colILAM_TEBLIG_GIDERI_DOVIZ_ID = new GridColumn();
            colILAM_TEBLIG_GIDERI_DOVIZ_ID.VisibleIndex = 56;
            colILAM_TEBLIG_GIDERI_DOVIZ_ID.FieldName = "ILAM_TEBLIG_GIDERI_DOVIZ_ID";
            colILAM_TEBLIG_GIDERI_DOVIZ_ID.Name = "colILAM_TEBLIG_GIDERI_DOVIZ_ID";
            colILAM_TEBLIG_GIDERI_DOVIZ_ID.Visible = true;

            GridColumn colILAM_TEBLIG_GIDERI = new GridColumn();
            colILAM_TEBLIG_GIDERI.VisibleIndex = 57;
            colILAM_TEBLIG_GIDERI.FieldName = "ILAM_TEBLIG_GIDERI";
            colILAM_TEBLIG_GIDERI.Name = "colILAM_TEBLIG_GIDERI";
            colILAM_TEBLIG_GIDERI.Visible = true;

            GridColumn colILAM_INKAR_TAZMINATI_DOVIZ_ID = new GridColumn();
            colILAM_INKAR_TAZMINATI_DOVIZ_ID.VisibleIndex = 58;
            colILAM_INKAR_TAZMINATI_DOVIZ_ID.FieldName = "ILAM_INKAR_TAZMINATI_DOVIZ_ID";
            colILAM_INKAR_TAZMINATI_DOVIZ_ID.Name = "colILAM_INKAR_TAZMINATI_DOVIZ_ID";
            colILAM_INKAR_TAZMINATI_DOVIZ_ID.Visible = true;

            GridColumn colILAM_INKAR_TAZMINATI = new GridColumn();
            colILAM_INKAR_TAZMINATI.VisibleIndex = 59;
            colILAM_INKAR_TAZMINATI.FieldName = "ILAM_INKAR_TAZMINATI";
            colILAM_INKAR_TAZMINATI.Name = "colILAM_INKAR_TAZMINATI";
            colILAM_INKAR_TAZMINATI.Visible = true;

            GridColumn colILAM_VEK_UCR_DOVIZ_ID = new GridColumn();
            colILAM_VEK_UCR_DOVIZ_ID.VisibleIndex = 60;
            colILAM_VEK_UCR_DOVIZ_ID.FieldName = "ILAM_VEK_UCR_DOVIZ_ID";
            colILAM_VEK_UCR_DOVIZ_ID.Name = "colILAM_VEK_UCR_DOVIZ_ID";
            colILAM_VEK_UCR_DOVIZ_ID.Visible = true;

            GridColumn colILAM_VEK_UCR = new GridColumn();
            colILAM_VEK_UCR.VisibleIndex = 61;
            colILAM_VEK_UCR.FieldName = "ILAM_VEK_UCR";
            colILAM_VEK_UCR.Name = "colILAM_VEK_UCR";
            colILAM_VEK_UCR.Visible = true;

            GridColumn colOIV_TO_DOVIZ_ID = new GridColumn();
            colOIV_TO_DOVIZ_ID.VisibleIndex = 62;
            colOIV_TO_DOVIZ_ID.FieldName = "OIV_TO_DOVIZ_ID";
            colOIV_TO_DOVIZ_ID.Name = "colOIV_TO_DOVIZ_ID";
            colOIV_TO_DOVIZ_ID.Visible = true;

            GridColumn colPROTESTO_GIDERI_DOVIZ_ID = new GridColumn();
            colPROTESTO_GIDERI_DOVIZ_ID.VisibleIndex = 63;
            colPROTESTO_GIDERI_DOVIZ_ID.FieldName = "PROTESTO_GIDERI_DOVIZ_ID";
            colPROTESTO_GIDERI_DOVIZ_ID.Name = "colPROTESTO_GIDERI_DOVIZ_ID";
            colPROTESTO_GIDERI_DOVIZ_ID.Visible = true;

            GridColumn colPROTESTO_GIDERI = new GridColumn();
            colPROTESTO_GIDERI.VisibleIndex = 64;
            colPROTESTO_GIDERI.FieldName = "PROTESTO_GIDERI";
            colPROTESTO_GIDERI.Name = "colPROTESTO_GIDERI";
            colPROTESTO_GIDERI.Visible = true;

            GridColumn colIHTAR_GIDERI_DOVIZ_ID = new GridColumn();
            colIHTAR_GIDERI_DOVIZ_ID.VisibleIndex = 65;
            colIHTAR_GIDERI_DOVIZ_ID.FieldName = "IHTAR_GIDERI_DOVIZ_ID";
            colIHTAR_GIDERI_DOVIZ_ID.Name = "colIHTAR_GIDERI_DOVIZ_ID";
            colIHTAR_GIDERI_DOVIZ_ID.Visible = true;

            GridColumn colIHTAR_GIDERI = new GridColumn();
            colIHTAR_GIDERI.VisibleIndex = 66;
            colIHTAR_GIDERI.FieldName = "IHTAR_GIDERI";
            colIHTAR_GIDERI.Name = "colIHTAR_GIDERI";
            colIHTAR_GIDERI.Visible = true;

            GridColumn colOZEL_TAZMINAT_DOVIZ_ID = new GridColumn();
            colOZEL_TAZMINAT_DOVIZ_ID.VisibleIndex = 67;
            colOZEL_TAZMINAT_DOVIZ_ID.FieldName = "OZEL_TAZMINAT_DOVIZ_ID";
            colOZEL_TAZMINAT_DOVIZ_ID.Name = "colOZEL_TAZMINAT_DOVIZ_ID";
            colOZEL_TAZMINAT_DOVIZ_ID.Visible = true;

            GridColumn colOZEL_TAZMINAT = new GridColumn();
            colOZEL_TAZMINAT.VisibleIndex = 68;
            colOZEL_TAZMINAT.FieldName = "OZEL_TAZMINAT";
            colOZEL_TAZMINAT.Name = "colOZEL_TAZMINAT";
            colOZEL_TAZMINAT.Visible = true;

            GridColumn colOZEL_TUTAR1_FAIZ_ORANI = new GridColumn();
            colOZEL_TUTAR1_FAIZ_ORANI.VisibleIndex = 69;
            colOZEL_TUTAR1_FAIZ_ORANI.FieldName = "OZEL_TUTAR1_FAIZ_ORANI";
            colOZEL_TUTAR1_FAIZ_ORANI.Name = "colOZEL_TUTAR1_FAIZ_ORANI";
            colOZEL_TUTAR1_FAIZ_ORANI.Visible = true;

            GridColumn colOZEL_TUTAR1_KONU_ID = new GridColumn();
            colOZEL_TUTAR1_KONU_ID.VisibleIndex = 70;
            colOZEL_TUTAR1_KONU_ID.FieldName = "OZEL_TUTAR1_KONU_ID";
            colOZEL_TUTAR1_KONU_ID.Name = "colOZEL_TUTAR1_KONU_ID";
            colOZEL_TUTAR1_KONU_ID.Visible = true;

            GridColumn colOZEL_TUTAR1_KONU_ADI = new GridColumn();
            colOZEL_TUTAR1_KONU_ADI.VisibleIndex = 71;
            colOZEL_TUTAR1_KONU_ADI.FieldName = "OZEL_TUTAR1_KONU_ADI";
            colOZEL_TUTAR1_KONU_ADI.Name = "colOZEL_TUTAR1_KONU_ADI";
            colOZEL_TUTAR1_KONU_ADI.Visible = true;

            GridColumn colOZEL_TUTAR1_DOVIZ_ID = new GridColumn();
            colOZEL_TUTAR1_DOVIZ_ID.VisibleIndex = 72;
            colOZEL_TUTAR1_DOVIZ_ID.FieldName = "OZEL_TUTAR1_DOVIZ_ID";
            colOZEL_TUTAR1_DOVIZ_ID.Name = "colOZEL_TUTAR1_DOVIZ_ID";
            colOZEL_TUTAR1_DOVIZ_ID.Visible = true;

            GridColumn colOZEL_TUTAR1 = new GridColumn();
            colOZEL_TUTAR1.VisibleIndex = 73;
            colOZEL_TUTAR1.FieldName = "OZEL_TUTAR1";
            colOZEL_TUTAR1.Name = "colOZEL_TUTAR1";
            colOZEL_TUTAR1.Visible = true;

            GridColumn colOZEL_TUTAR2_KONU_ID = new GridColumn();
            colOZEL_TUTAR2_KONU_ID.VisibleIndex = 74;
            colOZEL_TUTAR2_KONU_ID.FieldName = "OZEL_TUTAR2_KONU_ID";
            colOZEL_TUTAR2_KONU_ID.Name = "colOZEL_TUTAR2_KONU_ID";
            colOZEL_TUTAR2_KONU_ID.Visible = true;

            GridColumn colOZEL_TUTAR2_KONU_ADI = new GridColumn();
            colOZEL_TUTAR2_KONU_ADI.VisibleIndex = 75;
            colOZEL_TUTAR2_KONU_ADI.FieldName = "OZEL_TUTAR2_KONU_ADI";
            colOZEL_TUTAR2_KONU_ADI.Name = "colOZEL_TUTAR2_KONU_ADI";
            colOZEL_TUTAR2_KONU_ADI.Visible = true;

            GridColumn colOZEL_TUTAR2_DOVIZ_ID = new GridColumn();
            colOZEL_TUTAR2_DOVIZ_ID.VisibleIndex = 76;
            colOZEL_TUTAR2_DOVIZ_ID.FieldName = "OZEL_TUTAR2_DOVIZ_ID";
            colOZEL_TUTAR2_DOVIZ_ID.Name = "colOZEL_TUTAR2_DOVIZ_ID";
            colOZEL_TUTAR2_DOVIZ_ID.Visible = true;

            GridColumn colOZEL_TUTAR2 = new GridColumn();
            colOZEL_TUTAR2.VisibleIndex = 77;
            colOZEL_TUTAR2.FieldName = "OZEL_TUTAR2";
            colOZEL_TUTAR2.Name = "colOZEL_TUTAR2";
            colOZEL_TUTAR2.Visible = true;

            GridColumn colOZEL_TUTAR3_KONU_ID = new GridColumn();
            colOZEL_TUTAR3_KONU_ID.VisibleIndex = 78;
            colOZEL_TUTAR3_KONU_ID.FieldName = "OZEL_TUTAR3_KONU_ID";
            colOZEL_TUTAR3_KONU_ID.Name = "colOZEL_TUTAR3_KONU_ID";
            colOZEL_TUTAR3_KONU_ID.Visible = true;

            GridColumn colOZEL_TUTAR3_KONU_ADI = new GridColumn();
            colOZEL_TUTAR3_KONU_ADI.VisibleIndex = 79;
            colOZEL_TUTAR3_KONU_ADI.FieldName = "OZEL_TUTAR3_KONU_ADI";
            colOZEL_TUTAR3_KONU_ADI.Name = "colOZEL_TUTAR3_KONU_ADI";
            colOZEL_TUTAR3_KONU_ADI.Visible = true;

            GridColumn colOZEL_TUTAR3_DOVIZ_ID = new GridColumn();
            colOZEL_TUTAR3_DOVIZ_ID.VisibleIndex = 80;
            colOZEL_TUTAR3_DOVIZ_ID.FieldName = "OZEL_TUTAR3_DOVIZ_ID";
            colOZEL_TUTAR3_DOVIZ_ID.Name = "colOZEL_TUTAR3_DOVIZ_ID";
            colOZEL_TUTAR3_DOVIZ_ID.Visible = true;

            GridColumn colOZEL_TUTAR3 = new GridColumn();
            colOZEL_TUTAR3.VisibleIndex = 81;
            colOZEL_TUTAR3.FieldName = "OZEL_TUTAR3";
            colOZEL_TUTAR3.Name = "colOZEL_TUTAR3";
            colOZEL_TUTAR3.Visible = true;

            GridColumn colTAKIP_CIKISI_DOVIZ_ID = new GridColumn();
            colTAKIP_CIKISI_DOVIZ_ID.VisibleIndex = 82;
            colTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            colTAKIP_CIKISI_DOVIZ_ID.Name = "colTAKIP_CIKISI_DOVIZ_ID";
            colTAKIP_CIKISI_DOVIZ_ID.Visible = true;

            GridColumn colTAKIP_CIKISI = new GridColumn();
            colTAKIP_CIKISI.VisibleIndex = 83;
            colTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            colTAKIP_CIKISI.Name = "colTAKIP_CIKISI";
            colTAKIP_CIKISI.Visible = true;

            GridColumn colSONRAKI_FAIZ_DOVIZ_ID = new GridColumn();
            colSONRAKI_FAIZ_DOVIZ_ID.VisibleIndex = 84;
            colSONRAKI_FAIZ_DOVIZ_ID.FieldName = "SONRAKI_FAIZ_DOVIZ_ID";
            colSONRAKI_FAIZ_DOVIZ_ID.Name = "colSONRAKI_FAIZ_DOVIZ_ID";
            colSONRAKI_FAIZ_DOVIZ_ID.Visible = true;

            GridColumn colSONRAKI_FAIZ = new GridColumn();
            colSONRAKI_FAIZ.VisibleIndex = 85;
            colSONRAKI_FAIZ.FieldName = "SONRAKI_FAIZ";
            colSONRAKI_FAIZ.Name = "colSONRAKI_FAIZ";
            colSONRAKI_FAIZ.Visible = true;

            GridColumn colSONRAKI_TAZMINAT_DOVIZ_ID = new GridColumn();
            colSONRAKI_TAZMINAT_DOVIZ_ID.VisibleIndex = 86;
            colSONRAKI_TAZMINAT_DOVIZ_ID.FieldName = "SONRAKI_TAZMINAT_DOVIZ_ID";
            colSONRAKI_TAZMINAT_DOVIZ_ID.Name = "colSONRAKI_TAZMINAT_DOVIZ_ID";
            colSONRAKI_TAZMINAT_DOVIZ_ID.Visible = true;

            GridColumn colSONRAKI_TAZMINAT = new GridColumn();
            colSONRAKI_TAZMINAT.VisibleIndex = 87;
            colSONRAKI_TAZMINAT.FieldName = "SONRAKI_TAZMINAT";
            colSONRAKI_TAZMINAT.Name = "colSONRAKI_TAZMINAT";
            colSONRAKI_TAZMINAT.Visible = true;

            GridColumn colBSMV_TS_DOVIZ_ID = new GridColumn();
            colBSMV_TS_DOVIZ_ID.VisibleIndex = 88;
            colBSMV_TS_DOVIZ_ID.FieldName = "BSMV_TS_DOVIZ_ID";
            colBSMV_TS_DOVIZ_ID.Name = "colBSMV_TS_DOVIZ_ID";
            colBSMV_TS_DOVIZ_ID.Visible = true;

            GridColumn colBSMV_TS = new GridColumn();
            colBSMV_TS.VisibleIndex = 89;
            colBSMV_TS.FieldName = "BSMV_TS";
            colBSMV_TS.Name = "colBSMV_TS";
            colBSMV_TS.Visible = true;

            GridColumn colOIV_TS_DOVIZ_ID = new GridColumn();
            colOIV_TS_DOVIZ_ID.VisibleIndex = 90;
            colOIV_TS_DOVIZ_ID.FieldName = "OIV_TS_DOVIZ_ID";
            colOIV_TS_DOVIZ_ID.Name = "colOIV_TS_DOVIZ_ID";
            colOIV_TS_DOVIZ_ID.Visible = true;

            GridColumn colOIV_TS = new GridColumn();
            colOIV_TS.VisibleIndex = 91;
            colOIV_TS.FieldName = "OIV_TS";
            colOIV_TS.Name = "colOIV_TS";
            colOIV_TS.Visible = true;

            GridColumn colKDV_TS_DOVIZ_ID = new GridColumn();
            colKDV_TS_DOVIZ_ID.VisibleIndex = 92;
            colKDV_TS_DOVIZ_ID.FieldName = "KDV_TS_DOVIZ_ID";
            colKDV_TS_DOVIZ_ID.Name = "colKDV_TS_DOVIZ_ID";
            colKDV_TS_DOVIZ_ID.Visible = true;

            GridColumn colKDV_TS = new GridColumn();
            colKDV_TS.VisibleIndex = 93;
            colKDV_TS.FieldName = "KDV_TS";
            colKDV_TS.Name = "colKDV_TS";
            colKDV_TS.Visible = true;

            GridColumn colILK_GIDERLER_DOVIZ_ID = new GridColumn();
            colILK_GIDERLER_DOVIZ_ID.VisibleIndex = 94;
            colILK_GIDERLER_DOVIZ_ID.FieldName = "ILK_GIDERLER_DOVIZ_ID";
            colILK_GIDERLER_DOVIZ_ID.Name = "colILK_GIDERLER_DOVIZ_ID";
            colILK_GIDERLER_DOVIZ_ID.Visible = true;

            GridColumn colILK_GIDERLER = new GridColumn();
            colILK_GIDERLER.VisibleIndex = 95;
            colILK_GIDERLER.FieldName = "ILK_GIDERLER";
            colILK_GIDERLER.Name = "colILK_GIDERLER";
            colILK_GIDERLER.Visible = true;

            GridColumn colPESIN_HARC_DOVIZ_ID = new GridColumn();
            colPESIN_HARC_DOVIZ_ID.VisibleIndex = 96;
            colPESIN_HARC_DOVIZ_ID.FieldName = "PESIN_HARC_DOVIZ_ID";
            colPESIN_HARC_DOVIZ_ID.Name = "colPESIN_HARC_DOVIZ_ID";
            colPESIN_HARC_DOVIZ_ID.Visible = true;

            GridColumn colPESIN_HARC = new GridColumn();
            colPESIN_HARC.VisibleIndex = 97;
            colPESIN_HARC.FieldName = "PESIN_HARC";
            colPESIN_HARC.Name = "colPESIN_HARC";
            colPESIN_HARC.Visible = true;

            GridColumn colODENEN_TAHSIL_HARCI_DOVIZ_ID = new GridColumn();
            colODENEN_TAHSIL_HARCI_DOVIZ_ID.VisibleIndex = 98;
            colODENEN_TAHSIL_HARCI_DOVIZ_ID.FieldName = "ODENEN_TAHSIL_HARCI_DOVIZ_ID";
            colODENEN_TAHSIL_HARCI_DOVIZ_ID.Name = "colODENEN_TAHSIL_HARCI_DOVIZ_ID";
            colODENEN_TAHSIL_HARCI_DOVIZ_ID.Visible = true;

            GridColumn colODENEN_TAHSIL_HARCI = new GridColumn();
            colODENEN_TAHSIL_HARCI.VisibleIndex = 99;
            colODENEN_TAHSIL_HARCI.FieldName = "ODENEN_TAHSIL_HARCI";
            colODENEN_TAHSIL_HARCI.Name = "colODENEN_TAHSIL_HARCI";
            colODENEN_TAHSIL_HARCI.Visible = true;

            GridColumn colKALAN_TAHSIL_HARCI_DOVIZ_ID = new GridColumn();
            colKALAN_TAHSIL_HARCI_DOVIZ_ID.VisibleIndex = 100;
            colKALAN_TAHSIL_HARCI_DOVIZ_ID.FieldName = "KALAN_TAHSIL_HARCI_DOVIZ_ID";
            colKALAN_TAHSIL_HARCI_DOVIZ_ID.Name = "colKALAN_TAHSIL_HARCI_DOVIZ_ID";
            colKALAN_TAHSIL_HARCI_DOVIZ_ID.Visible = true;

            GridColumn colKALAN_TAHSIL_HARCI = new GridColumn();
            colKALAN_TAHSIL_HARCI.VisibleIndex = 101;
            colKALAN_TAHSIL_HARCI.FieldName = "KALAN_TAHSIL_HARCI";
            colKALAN_TAHSIL_HARCI.Name = "colKALAN_TAHSIL_HARCI";
            colKALAN_TAHSIL_HARCI.Visible = true;

            GridColumn colMASAYA_KATILMA_HARCI_DOVIZ_ID = new GridColumn();
            colMASAYA_KATILMA_HARCI_DOVIZ_ID.VisibleIndex = 102;
            colMASAYA_KATILMA_HARCI_DOVIZ_ID.FieldName = "MASAYA_KATILMA_HARCI_DOVIZ_ID";
            colMASAYA_KATILMA_HARCI_DOVIZ_ID.Name = "colMASAYA_KATILMA_HARCI_DOVIZ_ID";
            colMASAYA_KATILMA_HARCI_DOVIZ_ID.Visible = true;

            GridColumn colMASAYA_KATILMA_HARCI = new GridColumn();
            colMASAYA_KATILMA_HARCI.VisibleIndex = 103;
            colMASAYA_KATILMA_HARCI.FieldName = "MASAYA_KATILMA_HARCI";
            colMASAYA_KATILMA_HARCI.Name = "colMASAYA_KATILMA_HARCI";
            colMASAYA_KATILMA_HARCI.Visible = true;

            GridColumn colPAYLASMA_HARCI_DOVIZ_ID = new GridColumn();
            colPAYLASMA_HARCI_DOVIZ_ID.VisibleIndex = 104;
            colPAYLASMA_HARCI_DOVIZ_ID.FieldName = "PAYLASMA_HARCI_DOVIZ_ID";
            colPAYLASMA_HARCI_DOVIZ_ID.Name = "colPAYLASMA_HARCI_DOVIZ_ID";
            colPAYLASMA_HARCI_DOVIZ_ID.Visible = true;

            GridColumn colPAYLASMA_HARCI = new GridColumn();
            colPAYLASMA_HARCI.VisibleIndex = 105;
            colPAYLASMA_HARCI.FieldName = "PAYLASMA_HARCI";
            colPAYLASMA_HARCI.Name = "colPAYLASMA_HARCI";
            colPAYLASMA_HARCI.Visible = true;

            GridColumn colDAVA_GIDERLERI_DOVIZ_ID = new GridColumn();
            colDAVA_GIDERLERI_DOVIZ_ID.VisibleIndex = 106;
            colDAVA_GIDERLERI_DOVIZ_ID.FieldName = "DAVA_GIDERLERI_DOVIZ_ID";
            colDAVA_GIDERLERI_DOVIZ_ID.Name = "colDAVA_GIDERLERI_DOVIZ_ID";
            colDAVA_GIDERLERI_DOVIZ_ID.Visible = true;

            GridColumn colDAVA_GIDERLERI = new GridColumn();
            colDAVA_GIDERLERI.VisibleIndex = 107;
            colDAVA_GIDERLERI.FieldName = "DAVA_GIDERLERI";
            colDAVA_GIDERLERI.Name = "colDAVA_GIDERLERI";
            colDAVA_GIDERLERI.Visible = true;

            GridColumn colDIGER_GIDERLER_DOVIZ_ID = new GridColumn();
            colDIGER_GIDERLER_DOVIZ_ID.VisibleIndex = 108;
            colDIGER_GIDERLER_DOVIZ_ID.FieldName = "DIGER_GIDERLER_DOVIZ_ID";
            colDIGER_GIDERLER_DOVIZ_ID.Name = "colDIGER_GIDERLER_DOVIZ_ID";
            colDIGER_GIDERLER_DOVIZ_ID.Visible = true;

            GridColumn colDIGER_GIDERLER = new GridColumn();
            colDIGER_GIDERLER.VisibleIndex = 109;
            colDIGER_GIDERLER.FieldName = "DIGER_GIDERLER";
            colDIGER_GIDERLER.Name = "colDIGER_GIDERLER";
            colDIGER_GIDERLER.Visible = true;

            GridColumn colTAKIP_VEKALET_UCRETI_KATSAYI = new GridColumn();
            colTAKIP_VEKALET_UCRETI_KATSAYI.VisibleIndex = 110;
            colTAKIP_VEKALET_UCRETI_KATSAYI.FieldName = "TAKIP_VEKALET_UCRETI_KATSAYI";
            colTAKIP_VEKALET_UCRETI_KATSAYI.Name = "colTAKIP_VEKALET_UCRETI_KATSAYI";
            colTAKIP_VEKALET_UCRETI_KATSAYI.Visible = true;

            GridColumn colTAKIP_VEKALET_UCRETI_DOVIZ_ID = new GridColumn();
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.VisibleIndex = 111;
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.FieldName = "TAKIP_VEKALET_UCRETI_DOVIZ_ID";
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.Name = "colTAKIP_VEKALET_UCRETI_DOVIZ_ID";
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.Visible = true;

            GridColumn colTAKIP_VEKALET_UCRETI = new GridColumn();
            colTAKIP_VEKALET_UCRETI.VisibleIndex = 112;
            colTAKIP_VEKALET_UCRETI.FieldName = "TAKIP_VEKALET_UCRETI";
            colTAKIP_VEKALET_UCRETI.Name = "colTAKIP_VEKALET_UCRETI";
            colTAKIP_VEKALET_UCRETI.Visible = true;

            GridColumn colDAVA_INKAR_TAZMINATI_DOVIZ_ID = new GridColumn();
            colDAVA_INKAR_TAZMINATI_DOVIZ_ID.VisibleIndex = 113;
            colDAVA_INKAR_TAZMINATI_DOVIZ_ID.FieldName = "DAVA_INKAR_TAZMINATI_DOVIZ_ID";
            colDAVA_INKAR_TAZMINATI_DOVIZ_ID.Name = "colDAVA_INKAR_TAZMINATI_DOVIZ_ID";
            colDAVA_INKAR_TAZMINATI_DOVIZ_ID.Visible = true;

            GridColumn colDAVA_INKAR_TAZMINATI = new GridColumn();
            colDAVA_INKAR_TAZMINATI.VisibleIndex = 114;
            colDAVA_INKAR_TAZMINATI.FieldName = "DAVA_INKAR_TAZMINATI";
            colDAVA_INKAR_TAZMINATI.Name = "colDAVA_INKAR_TAZMINATI";
            colDAVA_INKAR_TAZMINATI.Visible = true;

            GridColumn colDAVA_VEKALET_UCRETI_DOVIZ_ID = new GridColumn();
            colDAVA_VEKALET_UCRETI_DOVIZ_ID.VisibleIndex = 115;
            colDAVA_VEKALET_UCRETI_DOVIZ_ID.FieldName = "DAVA_VEKALET_UCRETI_DOVIZ_ID";
            colDAVA_VEKALET_UCRETI_DOVIZ_ID.Name = "colDAVA_VEKALET_UCRETI_DOVIZ_ID";
            colDAVA_VEKALET_UCRETI_DOVIZ_ID.Visible = true;

            GridColumn colDAVA_VEKALET_UCRETI = new GridColumn();
            colDAVA_VEKALET_UCRETI.VisibleIndex = 116;
            colDAVA_VEKALET_UCRETI.FieldName = "DAVA_VEKALET_UCRETI";
            colDAVA_VEKALET_UCRETI.Name = "colDAVA_VEKALET_UCRETI";
            colDAVA_VEKALET_UCRETI.Visible = true;

            GridColumn colODEME_TOPLAMI_DOVIZ_ID = new GridColumn();
            colODEME_TOPLAMI_DOVIZ_ID.VisibleIndex = 117;
            colODEME_TOPLAMI_DOVIZ_ID.FieldName = "ODEME_TOPLAMI_DOVIZ_ID";
            colODEME_TOPLAMI_DOVIZ_ID.Name = "colODEME_TOPLAMI_DOVIZ_ID";
            colODEME_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colODEME_TOPLAMI = new GridColumn();
            colODEME_TOPLAMI.VisibleIndex = 118;
            colODEME_TOPLAMI.FieldName = "ODEME_TOPLAMI";
            colODEME_TOPLAMI.Name = "colODEME_TOPLAMI";
            colODEME_TOPLAMI.Visible = true;

            GridColumn colTO_ODEME_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTO_ODEME_TOPLAMI_DOVIZ_ID.VisibleIndex = 119;
            colTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            colTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "colTO_ODEME_TOPLAMI_DOVIZ_ID";
            colTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colTO_ODEME_TOPLAMI = new GridColumn();
            colTO_ODEME_TOPLAMI.VisibleIndex = 120;
            colTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            colTO_ODEME_TOPLAMI.Name = "colTO_ODEME_TOPLAMI";
            colTO_ODEME_TOPLAMI.Visible = true;

            GridColumn colMAHSUP_TOPLAMI_DOVIZ_ID = new GridColumn();
            colMAHSUP_TOPLAMI_DOVIZ_ID.VisibleIndex = 121;
            colMAHSUP_TOPLAMI_DOVIZ_ID.FieldName = "MAHSUP_TOPLAMI_DOVIZ_ID";
            colMAHSUP_TOPLAMI_DOVIZ_ID.Name = "colMAHSUP_TOPLAMI_DOVIZ_ID";
            colMAHSUP_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colMAHSUP_TOPLAMI = new GridColumn();
            colMAHSUP_TOPLAMI.VisibleIndex = 122;
            colMAHSUP_TOPLAMI.FieldName = "MAHSUP_TOPLAMI";
            colMAHSUP_TOPLAMI.Name = "colMAHSUP_TOPLAMI";
            colMAHSUP_TOPLAMI.Visible = true;

            GridColumn colFERAGAT_TOPLAMI = new GridColumn();
            colFERAGAT_TOPLAMI.VisibleIndex = 123;
            colFERAGAT_TOPLAMI.FieldName = "FERAGAT_TOPLAMI";
            colFERAGAT_TOPLAMI.Name = "colFERAGAT_TOPLAMI";
            colFERAGAT_TOPLAMI.Visible = true;

            GridColumn colFERAGAT_TOPLAMI_DOVIZ_ID = new GridColumn();
            colFERAGAT_TOPLAMI_DOVIZ_ID.VisibleIndex = 124;
            colFERAGAT_TOPLAMI_DOVIZ_ID.FieldName = "FERAGAT_TOPLAMI_DOVIZ_ID";
            colFERAGAT_TOPLAMI_DOVIZ_ID.Name = "colFERAGAT_TOPLAMI_DOVIZ_ID";
            colFERAGAT_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colALACAK_TOPLAMI_DOVIZ_ID = new GridColumn();
            colALACAK_TOPLAMI_DOVIZ_ID.VisibleIndex = 125;
            colALACAK_TOPLAMI_DOVIZ_ID.FieldName = "ALACAK_TOPLAMI_DOVIZ_ID";
            colALACAK_TOPLAMI_DOVIZ_ID.Name = "colALACAK_TOPLAMI_DOVIZ_ID";
            colALACAK_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colALACAK_TOPLAMI = new GridColumn();
            colALACAK_TOPLAMI.VisibleIndex = 126;
            colALACAK_TOPLAMI.FieldName = "ALACAK_TOPLAMI";
            colALACAK_TOPLAMI.Name = "colALACAK_TOPLAMI";
            colALACAK_TOPLAMI.Visible = true;

            GridColumn colKALAN_DOVIZ_ID = new GridColumn();
            colKALAN_DOVIZ_ID.VisibleIndex = 127;
            colKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            colKALAN_DOVIZ_ID.Name = "colKALAN_DOVIZ_ID";
            colKALAN_DOVIZ_ID.Visible = true;

            GridColumn colKALAN = new GridColumn();
            colKALAN.VisibleIndex = 128;
            colKALAN.FieldName = "KALAN";
            colKALAN.Name = "colKALAN";
            colKALAN.Visible = true;

            GridColumn colTAHLIYE_VEK_UCR_DOVIZ_ID = new GridColumn();
            colTAHLIYE_VEK_UCR_DOVIZ_ID.VisibleIndex = 129;
            colTAHLIYE_VEK_UCR_DOVIZ_ID.FieldName = "TAHLIYE_VEK_UCR_DOVIZ_ID";
            colTAHLIYE_VEK_UCR_DOVIZ_ID.Name = "colTAHLIYE_VEK_UCR_DOVIZ_ID";
            colTAHLIYE_VEK_UCR_DOVIZ_ID.Visible = true;

            GridColumn colTAHLIYE_VEK_UCR = new GridColumn();
            colTAHLIYE_VEK_UCR.VisibleIndex = 130;
            colTAHLIYE_VEK_UCR.FieldName = "TAHLIYE_VEK_UCR";
            colTAHLIYE_VEK_UCR.Name = "colTAHLIYE_VEK_UCR";
            colTAHLIYE_VEK_UCR.Visible = true;

            GridColumn colDIGER_HARC_DOVIZ_ID = new GridColumn();
            colDIGER_HARC_DOVIZ_ID.VisibleIndex = 131;
            colDIGER_HARC_DOVIZ_ID.FieldName = "DIGER_HARC_DOVIZ_ID";
            colDIGER_HARC_DOVIZ_ID.Name = "colDIGER_HARC_DOVIZ_ID";
            colDIGER_HARC_DOVIZ_ID.Visible = true;

            GridColumn colDIGER_HARC = new GridColumn();
            colDIGER_HARC.VisibleIndex = 132;
            colDIGER_HARC.FieldName = "DIGER_HARC";
            colDIGER_HARC.Name = "colDIGER_HARC";
            colDIGER_HARC.Visible = true;

            GridColumn colTD_GIDERI_DOVIZ_ID = new GridColumn();
            colTD_GIDERI_DOVIZ_ID.VisibleIndex = 133;
            colTD_GIDERI_DOVIZ_ID.FieldName = "TD_GIDERI_DOVIZ_ID";
            colTD_GIDERI_DOVIZ_ID.Name = "colTD_GIDERI_DOVIZ_ID";
            colTD_GIDERI_DOVIZ_ID.Visible = true;

            GridColumn colTD_GIDERI = new GridColumn();
            colTD_GIDERI.VisibleIndex = 134;
            colTD_GIDERI.FieldName = "TD_GIDERI";
            colTD_GIDERI.Name = "colTD_GIDERI";
            colTD_GIDERI.Visible = true;

            GridColumn colTD_BAKIYE_HARC_DOVIZ_ID = new GridColumn();
            colTD_BAKIYE_HARC_DOVIZ_ID.VisibleIndex = 135;
            colTD_BAKIYE_HARC_DOVIZ_ID.FieldName = "TD_BAKIYE_HARC_DOVIZ_ID";
            colTD_BAKIYE_HARC_DOVIZ_ID.Name = "colTD_BAKIYE_HARC_DOVIZ_ID";
            colTD_BAKIYE_HARC_DOVIZ_ID.Visible = true;

            GridColumn colTD_BAKIYE_HARC = new GridColumn();
            colTD_BAKIYE_HARC.VisibleIndex = 136;
            colTD_BAKIYE_HARC.FieldName = "TD_BAKIYE_HARC";
            colTD_BAKIYE_HARC.Name = "colTD_BAKIYE_HARC";
            colTD_BAKIYE_HARC.Visible = true;

            GridColumn colTD_VEK_UCR_DOVIZ_ID = new GridColumn();
            colTD_VEK_UCR_DOVIZ_ID.VisibleIndex = 137;
            colTD_VEK_UCR_DOVIZ_ID.FieldName = "TD_VEK_UCR_DOVIZ_ID";
            colTD_VEK_UCR_DOVIZ_ID.Name = "colTD_VEK_UCR_DOVIZ_ID";
            colTD_VEK_UCR_DOVIZ_ID.Visible = true;

            GridColumn colTD_VEK_UCR = new GridColumn();
            colTD_VEK_UCR.VisibleIndex = 138;
            colTD_VEK_UCR.FieldName = "TD_VEK_UCR";
            colTD_VEK_UCR.Name = "colTD_VEK_UCR";
            colTD_VEK_UCR.Visible = true;

            GridColumn colTD_TEBLIG_GIDERI_DOVIZ_ID = new GridColumn();
            colTD_TEBLIG_GIDERI_DOVIZ_ID.VisibleIndex = 139;
            colTD_TEBLIG_GIDERI_DOVIZ_ID.FieldName = "TD_TEBLIG_GIDERI_DOVIZ_ID";
            colTD_TEBLIG_GIDERI_DOVIZ_ID.Name = "colTD_TEBLIG_GIDERI_DOVIZ_ID";
            colTD_TEBLIG_GIDERI_DOVIZ_ID.Visible = true;

            GridColumn colTD_TEBLIG_GIDERI = new GridColumn();
            colTD_TEBLIG_GIDERI.VisibleIndex = 140;
            colTD_TEBLIG_GIDERI.FieldName = "TD_TEBLIG_GIDERI";
            colTD_TEBLIG_GIDERI.Name = "colTD_TEBLIG_GIDERI";
            colTD_TEBLIG_GIDERI.Visible = true;

            GridColumn colBIRIKMIS_NAFAKA_DOVIZ_ID = new GridColumn();
            colBIRIKMIS_NAFAKA_DOVIZ_ID.VisibleIndex = 141;
            colBIRIKMIS_NAFAKA_DOVIZ_ID.FieldName = "BIRIKMIS_NAFAKA_DOVIZ_ID";
            colBIRIKMIS_NAFAKA_DOVIZ_ID.Name = "colBIRIKMIS_NAFAKA_DOVIZ_ID";
            colBIRIKMIS_NAFAKA_DOVIZ_ID.Visible = true;

            GridColumn colBIRIKMIS_NAFAKA = new GridColumn();
            colBIRIKMIS_NAFAKA.VisibleIndex = 142;
            colBIRIKMIS_NAFAKA.FieldName = "BIRIKMIS_NAFAKA";
            colBIRIKMIS_NAFAKA.Name = "colBIRIKMIS_NAFAKA";
            colBIRIKMIS_NAFAKA.Visible = true;

            GridColumn colICRA_INKAR_TAZMINATI_DOVIZ_ID = new GridColumn();
            colICRA_INKAR_TAZMINATI_DOVIZ_ID.VisibleIndex = 143;
            colICRA_INKAR_TAZMINATI_DOVIZ_ID.FieldName = "ICRA_INKAR_TAZMINATI_DOVIZ_ID";
            colICRA_INKAR_TAZMINATI_DOVIZ_ID.Name = "colICRA_INKAR_TAZMINATI_DOVIZ_ID";
            colICRA_INKAR_TAZMINATI_DOVIZ_ID.Visible = true;

            GridColumn colICRA_INKAR_TAZMINATI = new GridColumn();
            colICRA_INKAR_TAZMINATI.VisibleIndex = 144;
            colICRA_INKAR_TAZMINATI.FieldName = "ICRA_INKAR_TAZMINATI";
            colICRA_INKAR_TAZMINATI.Name = "colICRA_INKAR_TAZMINATI";
            colICRA_INKAR_TAZMINATI.Visible = true;

            GridColumn colDAMGA_PULU_DOVIZ_ID = new GridColumn();
            colDAMGA_PULU_DOVIZ_ID.VisibleIndex = 145;
            colDAMGA_PULU_DOVIZ_ID.FieldName = "DAMGA_PULU_DOVIZ_ID";
            colDAMGA_PULU_DOVIZ_ID.Name = "colDAMGA_PULU_DOVIZ_ID";
            colDAMGA_PULU_DOVIZ_ID.Visible = true;

            GridColumn colDAMGA_PULU = new GridColumn();
            colDAMGA_PULU.VisibleIndex = 146;
            colDAMGA_PULU.FieldName = "DAMGA_PULU";
            colDAMGA_PULU.Name = "colDAMGA_PULU";
            colDAMGA_PULU.Visible = true;

            GridColumn colACIKLAMA = new GridColumn();
            colACIKLAMA.VisibleIndex = 147;
            colACIKLAMA.FieldName = "ACIKLAMA";
            colACIKLAMA.Name = "colACIKLAMA";
            colACIKLAMA.Visible = true;

            GridColumn colPROTOKOL_MIKTARI_DOVIZ_ID = new GridColumn();
            colPROTOKOL_MIKTARI_DOVIZ_ID.VisibleIndex = 148;
            colPROTOKOL_MIKTARI_DOVIZ_ID.FieldName = "PROTOKOL_MIKTARI_DOVIZ_ID";
            colPROTOKOL_MIKTARI_DOVIZ_ID.Name = "colPROTOKOL_MIKTARI_DOVIZ_ID";
            colPROTOKOL_MIKTARI_DOVIZ_ID.Visible = true;

            GridColumn colPROTOKOL_MIKTARI = new GridColumn();
            colPROTOKOL_MIKTARI.VisibleIndex = 149;
            colPROTOKOL_MIKTARI.FieldName = "PROTOKOL_MIKTARI";
            colPROTOKOL_MIKTARI.Name = "colPROTOKOL_MIKTARI";
            colPROTOKOL_MIKTARI.Visible = true;

            GridColumn colPROTOKOL_FAIZ_ORANI = new GridColumn();
            colPROTOKOL_FAIZ_ORANI.VisibleIndex = 150;
            colPROTOKOL_FAIZ_ORANI.FieldName = "PROTOKOL_FAIZ_ORANI";
            colPROTOKOL_FAIZ_ORANI.Name = "colPROTOKOL_FAIZ_ORANI";
            colPROTOKOL_FAIZ_ORANI.Visible = true;

            GridColumn colPROTOKOL_TARIHI = new GridColumn();
            colPROTOKOL_TARIHI.VisibleIndex = 151;
            colPROTOKOL_TARIHI.FieldName = "PROTOKOL_TARIHI";
            colPROTOKOL_TARIHI.Name = "colPROTOKOL_TARIHI";
            colPROTOKOL_TARIHI.Visible = true;

            GridColumn colKARSILIK_TUTARI_DOVIZ_ID = new GridColumn();
            colKARSILIK_TUTARI_DOVIZ_ID.VisibleIndex = 152;
            colKARSILIK_TUTARI_DOVIZ_ID.FieldName = "KARSILIK_TUTARI_DOVIZ_ID";
            colKARSILIK_TUTARI_DOVIZ_ID.Name = "colKARSILIK_TUTARI_DOVIZ_ID";
            colKARSILIK_TUTARI_DOVIZ_ID.Visible = true;

            GridColumn colKARSILIK_TUTARI = new GridColumn();
            colKARSILIK_TUTARI.VisibleIndex = 153;
            colKARSILIK_TUTARI.FieldName = "KARSILIK_TUTARI";
            colKARSILIK_TUTARI.Name = "colKARSILIK_TUTARI";
            colKARSILIK_TUTARI.Visible = true;

            GridColumn colTO_MASRAF_TOPLAMI = new GridColumn();
            colTO_MASRAF_TOPLAMI.VisibleIndex = 154;
            colTO_MASRAF_TOPLAMI.FieldName = "TO_MASRAF_TOPLAMI";
            colTO_MASRAF_TOPLAMI.Name = "colTO_MASRAF_TOPLAMI";
            colTO_MASRAF_TOPLAMI.Visible = true;

            GridColumn colTO_MASRAF_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTO_MASRAF_TOPLAMI_DOVIZ_ID.VisibleIndex = 155;
            colTO_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            colTO_MASRAF_TOPLAMI_DOVIZ_ID.Name = "colTO_MASRAF_TOPLAMI_DOVIZ_ID";
            colTO_MASRAF_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colTS_MASRAF_TOPLAMI = new GridColumn();
            colTS_MASRAF_TOPLAMI.VisibleIndex = 156;
            colTS_MASRAF_TOPLAMI.FieldName = "TS_MASRAF_TOPLAMI";
            colTS_MASRAF_TOPLAMI.Name = "colTS_MASRAF_TOPLAMI";
            colTS_MASRAF_TOPLAMI.Visible = true;

            GridColumn colTS_MASRAF_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTS_MASRAF_TOPLAMI_DOVIZ_ID.VisibleIndex = 157;
            colTS_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            colTS_MASRAF_TOPLAMI_DOVIZ_ID.Name = "colTS_MASRAF_TOPLAMI_DOVIZ_ID";
            colTS_MASRAF_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colTUM_MASRAF_TOPLAMI = new GridColumn();
            colTUM_MASRAF_TOPLAMI.VisibleIndex = 158;
            colTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            colTUM_MASRAF_TOPLAMI.Name = "colTUM_MASRAF_TOPLAMI";
            colTUM_MASRAF_TOPLAMI.Visible = true;

            GridColumn colTUM_MASRAF_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.VisibleIndex = 159;
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "colTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            colTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colHARC_TOPLAMI = new GridColumn();
            colHARC_TOPLAMI.VisibleIndex = 160;
            colHARC_TOPLAMI.FieldName = "HARC_TOPLAMI";
            colHARC_TOPLAMI.Name = "colHARC_TOPLAMI";
            colHARC_TOPLAMI.Visible = true;

            GridColumn colHARC_TOPLAMI_DOVIZ_ID = new GridColumn();
            colHARC_TOPLAMI_DOVIZ_ID.VisibleIndex = 161;
            colHARC_TOPLAMI_DOVIZ_ID.FieldName = "HARC_TOPLAMI_DOVIZ_ID";
            colHARC_TOPLAMI_DOVIZ_ID.Name = "colHARC_TOPLAMI_DOVIZ_ID";
            colHARC_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colTO_VEKALET_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTO_VEKALET_TOPLAMI_DOVIZ_ID.VisibleIndex = 162;
            colTO_VEKALET_TOPLAMI_DOVIZ_ID.FieldName = "TO_VEKALET_TOPLAMI_DOVIZ_ID";
            colTO_VEKALET_TOPLAMI_DOVIZ_ID.Name = "colTO_VEKALET_TOPLAMI_DOVIZ_ID";
            colTO_VEKALET_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colTO_VEKALET_TOPLAMI = new GridColumn();
            colTO_VEKALET_TOPLAMI.VisibleIndex = 163;
            colTO_VEKALET_TOPLAMI.FieldName = "TO_VEKALET_TOPLAMI";
            colTO_VEKALET_TOPLAMI.Name = "colTO_VEKALET_TOPLAMI";
            colTO_VEKALET_TOPLAMI.Visible = true;

            GridColumn colTS_VEKALET_TOPLAMI = new GridColumn();
            colTS_VEKALET_TOPLAMI.VisibleIndex = 164;
            colTS_VEKALET_TOPLAMI.FieldName = "TS_VEKALET_TOPLAMI";
            colTS_VEKALET_TOPLAMI.Name = "colTS_VEKALET_TOPLAMI";
            colTS_VEKALET_TOPLAMI.Visible = true;

            GridColumn colTS_VEKALET_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTS_VEKALET_TOPLAMI_DOVIZ_ID.VisibleIndex = 165;
            colTS_VEKALET_TOPLAMI_DOVIZ_ID.FieldName = "TS_VEKALET_TOPLAMI_DOVIZ_ID";
            colTS_VEKALET_TOPLAMI_DOVIZ_ID.Name = "colTS_VEKALET_TOPLAMI_DOVIZ_ID";
            colTS_VEKALET_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colTUM_VEKALET_TOPLAMI = new GridColumn();
            colTUM_VEKALET_TOPLAMI.VisibleIndex = 166;
            colTUM_VEKALET_TOPLAMI.FieldName = "TUM_VEKALET_TOPLAMI";
            colTUM_VEKALET_TOPLAMI.Name = "colTUM_VEKALET_TOPLAMI";
            colTUM_VEKALET_TOPLAMI.Visible = true;

            GridColumn colTUM_VEKALET_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.VisibleIndex = 167;
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.FieldName = "TUM_VEKALET_TOPLAMI_DOVIZ_ID";
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.Name = "colTUM_VEKALET_TOPLAMI_DOVIZ_ID";
            colTUM_VEKALET_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colKARSI_VEKALET_TOPLAMI = new GridColumn();
            colKARSI_VEKALET_TOPLAMI.VisibleIndex = 168;
            colKARSI_VEKALET_TOPLAMI.FieldName = "KARSI_VEKALET_TOPLAMI";
            colKARSI_VEKALET_TOPLAMI.Name = "colKARSI_VEKALET_TOPLAMI";
            colKARSI_VEKALET_TOPLAMI.Visible = true;

            GridColumn colKARSI_VEKALET_TOPLAMI_DOVIZ_ID = new GridColumn();
            colKARSI_VEKALET_TOPLAMI_DOVIZ_ID.VisibleIndex = 169;
            colKARSI_VEKALET_TOPLAMI_DOVIZ_ID.FieldName = "KARSI_VEKALET_TOPLAMI_DOVIZ_ID";
            colKARSI_VEKALET_TOPLAMI_DOVIZ_ID.Name = "colKARSI_VEKALET_TOPLAMI_DOVIZ_ID";
            colKARSI_VEKALET_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colFAIZ_TOPLAMI = new GridColumn();
            colFAIZ_TOPLAMI.VisibleIndex = 170;
            colFAIZ_TOPLAMI.FieldName = "FAIZ_TOPLAMI";
            colFAIZ_TOPLAMI.Name = "colFAIZ_TOPLAMI";
            colFAIZ_TOPLAMI.Visible = true;

            GridColumn colFAIZ_TOPLAMI_DOVIZ_ID = new GridColumn();
            colFAIZ_TOPLAMI_DOVIZ_ID.VisibleIndex = 171;
            colFAIZ_TOPLAMI_DOVIZ_ID.FieldName = "FAIZ_TOPLAMI_DOVIZ_ID";
            colFAIZ_TOPLAMI_DOVIZ_ID.Name = "colFAIZ_TOPLAMI_DOVIZ_ID";
            colFAIZ_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colILAM_UCRETLER_TOPLAMI = new GridColumn();
            colILAM_UCRETLER_TOPLAMI.VisibleIndex = 172;
            colILAM_UCRETLER_TOPLAMI.FieldName = "ILAM_UCRETLER_TOPLAMI";
            colILAM_UCRETLER_TOPLAMI.Name = "colILAM_UCRETLER_TOPLAMI";
            colILAM_UCRETLER_TOPLAMI.Visible = true;

            GridColumn colILAM_UCRETLER_TOPLAMI_DOVIZ_ID = new GridColumn();
            colILAM_UCRETLER_TOPLAMI_DOVIZ_ID.VisibleIndex = 173;
            colILAM_UCRETLER_TOPLAMI_DOVIZ_ID.FieldName = "ILAM_UCRETLER_TOPLAMI_DOVIZ_ID";
            colILAM_UCRETLER_TOPLAMI_DOVIZ_ID.Name = "colILAM_UCRETLER_TOPLAMI_DOVIZ_ID";
            colILAM_UCRETLER_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colIT_VEKALET_UCRETI_DOVIZ_ID = new GridColumn();
            colIT_VEKALET_UCRETI_DOVIZ_ID.VisibleIndex = 174;
            colIT_VEKALET_UCRETI_DOVIZ_ID.FieldName = "IT_VEKALET_UCRETI_DOVIZ_ID";
            colIT_VEKALET_UCRETI_DOVIZ_ID.Name = "colIT_VEKALET_UCRETI_DOVIZ_ID";
            colIT_VEKALET_UCRETI_DOVIZ_ID.Visible = true;

            GridColumn colIT_VEKALET_UCRETI = new GridColumn();
            colIT_VEKALET_UCRETI.VisibleIndex = 175;
            colIT_VEKALET_UCRETI.FieldName = "IT_VEKALET_UCRETI";
            colIT_VEKALET_UCRETI.Name = "colIT_VEKALET_UCRETI";
            colIT_VEKALET_UCRETI.Visible = true;

            GridColumn colIT_GIDERI_DOVIZ_ID = new GridColumn();
            colIT_GIDERI_DOVIZ_ID.VisibleIndex = 176;
            colIT_GIDERI_DOVIZ_ID.FieldName = "IT_GIDERI_DOVIZ_ID";
            colIT_GIDERI_DOVIZ_ID.Name = "colIT_GIDERI_DOVIZ_ID";
            colIT_GIDERI_DOVIZ_ID.Visible = true;

            GridColumn colIT_GIDERI = new GridColumn();
            colIT_GIDERI.VisibleIndex = 177;
            colIT_GIDERI.FieldName = "IT_GIDERI";
            colIT_GIDERI.Name = "colIT_GIDERI";
            colIT_GIDERI.Visible = true;

            GridColumn colTO_ODEME_MAHSUP_TOPLAMI = new GridColumn();
            colTO_ODEME_MAHSUP_TOPLAMI.VisibleIndex = 178;
            colTO_ODEME_MAHSUP_TOPLAMI.FieldName = "TO_ODEME_MAHSUP_TOPLAMI";
            colTO_ODEME_MAHSUP_TOPLAMI.Name = "colTO_ODEME_MAHSUP_TOPLAMI";
            colTO_ODEME_MAHSUP_TOPLAMI.Visible = true;

            GridColumn colTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID.VisibleIndex = 179;
            colTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID";
            colTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID.Name = "colTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID";
            colTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colPAYLASIM_TIPI = new GridColumn();
            colPAYLASIM_TIPI.VisibleIndex = 180;
            colPAYLASIM_TIPI.FieldName = "PAYLASIM_TIPI";
            colPAYLASIM_TIPI.Name = "colPAYLASIM_TIPI";
            colPAYLASIM_TIPI.Visible = true;

            GridColumn colTS_HESAP_TIP_ID = new GridColumn();
            colTS_HESAP_TIP_ID.VisibleIndex = 181;
            colTS_HESAP_TIP_ID.FieldName = "TS_HESAP_TIP_ID";
            colTS_HESAP_TIP_ID.Name = "colTS_HESAP_TIP_ID";
            colTS_HESAP_TIP_ID.Visible = true;

            GridColumn colTS_HESAP_TIP_ADI = new GridColumn();
            colTS_HESAP_TIP_ADI.VisibleIndex = 182;
            colTS_HESAP_TIP_ADI.FieldName = "TS_HESAP_TIP_ADI";
            colTS_HESAP_TIP_ADI.Name = "colTS_HESAP_TIP_ADI";
            colTS_HESAP_TIP_ADI.Visible = true;

            GridColumn colTO_HESAP_TIP_ID = new GridColumn();
            colTO_HESAP_TIP_ID.VisibleIndex = 183;
            colTO_HESAP_TIP_ID.FieldName = "TO_HESAP_TIP_ID";
            colTO_HESAP_TIP_ID.Name = "colTO_HESAP_TIP_ID";
            colTO_HESAP_TIP_ID.Visible = true;

            GridColumn colTO_HESAP_TIP_ADI = new GridColumn();
            colTO_HESAP_TIP_ADI.VisibleIndex = 184;
            colTO_HESAP_TIP_ADI.FieldName = "TO_HESAP_TIP_ADI";
            colTO_HESAP_TIP_ADI.Name = "colTO_HESAP_TIP_ADI";
            colTO_HESAP_TIP_ADI.Visible = true;

            GridColumn colBASVURMA_HARCI = new GridColumn();
            colBASVURMA_HARCI.VisibleIndex = 185;
            colBASVURMA_HARCI.FieldName = "BASVURMA_HARCI";
            colBASVURMA_HARCI.Name = "colBASVURMA_HARCI";
            colBASVURMA_HARCI.Visible = true;

            GridColumn colBASVURMA_HARCI_DOVIZ_ID = new GridColumn();
            colBASVURMA_HARCI_DOVIZ_ID.VisibleIndex = 186;
            colBASVURMA_HARCI_DOVIZ_ID.FieldName = "BASVURMA_HARCI_DOVIZ_ID";
            colBASVURMA_HARCI_DOVIZ_ID.Name = "colBASVURMA_HARCI_DOVIZ_ID";
            colBASVURMA_HARCI_DOVIZ_ID.Visible = true;

            GridColumn colVEKALET_HARCI = new GridColumn();
            colVEKALET_HARCI.VisibleIndex = 187;
            colVEKALET_HARCI.FieldName = "VEKALET_HARCI";
            colVEKALET_HARCI.Name = "colVEKALET_HARCI";
            colVEKALET_HARCI.Visible = true;

            GridColumn colVEKALET_HARCI_DOVIZ_ID = new GridColumn();
            colVEKALET_HARCI_DOVIZ_ID.VisibleIndex = 188;
            colVEKALET_HARCI_DOVIZ_ID.FieldName = "VEKALET_HARCI_DOVIZ_ID";
            colVEKALET_HARCI_DOVIZ_ID.Name = "colVEKALET_HARCI_DOVIZ_ID";
            colVEKALET_HARCI_DOVIZ_ID.Visible = true;

            GridColumn colVEKALET_PULU = new GridColumn();
            colVEKALET_PULU.VisibleIndex = 189;
            colVEKALET_PULU.FieldName = "VEKALET_PULU";
            colVEKALET_PULU.Name = "colVEKALET_PULU";
            colVEKALET_PULU.Visible = true;

            GridColumn colVEKALET_PULU_DOVIZ_ID = new GridColumn();
            colVEKALET_PULU_DOVIZ_ID.VisibleIndex = 190;
            colVEKALET_PULU_DOVIZ_ID.FieldName = "VEKALET_PULU_DOVIZ_ID";
            colVEKALET_PULU_DOVIZ_ID.Name = "colVEKALET_PULU_DOVIZ_ID";
            colVEKALET_PULU_DOVIZ_ID.Visible = true;

            GridColumn colIFLAS_BASVURMA_HARCI = new GridColumn();
            colIFLAS_BASVURMA_HARCI.VisibleIndex = 191;
            colIFLAS_BASVURMA_HARCI.FieldName = "IFLAS_BASVURMA_HARCI";
            colIFLAS_BASVURMA_HARCI.Name = "colIFLAS_BASVURMA_HARCI";
            colIFLAS_BASVURMA_HARCI.Visible = true;

            GridColumn colIFLAS_BASVURMA_HARCI_DOVIZ_ID = new GridColumn();
            colIFLAS_BASVURMA_HARCI_DOVIZ_ID.VisibleIndex = 192;
            colIFLAS_BASVURMA_HARCI_DOVIZ_ID.FieldName = "IFLAS_BASVURMA_HARCI_DOVIZ_ID";
            colIFLAS_BASVURMA_HARCI_DOVIZ_ID.Name = "colIFLAS_BASVURMA_HARCI_DOVIZ_ID";
            colIFLAS_BASVURMA_HARCI_DOVIZ_ID.Visible = true;

            GridColumn colIFLASIN_ACILMASI_HARCI = new GridColumn();
            colIFLASIN_ACILMASI_HARCI.VisibleIndex = 193;
            colIFLASIN_ACILMASI_HARCI.FieldName = "IFLASIN_ACILMASI_HARCI";
            colIFLASIN_ACILMASI_HARCI.Name = "colIFLASIN_ACILMASI_HARCI";
            colIFLASIN_ACILMASI_HARCI.Visible = true;

            GridColumn colIFLASIN_ACILMASI_HARCI_DOVIZ_ID = new GridColumn();
            colIFLASIN_ACILMASI_HARCI_DOVIZ_ID.VisibleIndex = 194;
            colIFLASIN_ACILMASI_HARCI_DOVIZ_ID.FieldName = "IFLASIN_ACILMASI_HARCI_DOVIZ_ID";
            colIFLASIN_ACILMASI_HARCI_DOVIZ_ID.Name = "colIFLASIN_ACILMASI_HARCI_DOVIZ_ID";
            colIFLASIN_ACILMASI_HARCI_DOVIZ_ID.Visible = true;

            GridColumn colILK_TEBLIGAT_GIDERI = new GridColumn();
            colILK_TEBLIGAT_GIDERI.VisibleIndex = 195;
            colILK_TEBLIGAT_GIDERI.FieldName = "ILK_TEBLIGAT_GIDERI";
            colILK_TEBLIGAT_GIDERI.Name = "colILK_TEBLIGAT_GIDERI";
            colILK_TEBLIGAT_GIDERI.Visible = true;

            GridColumn colILK_TEBLIGAT_GIDERI_DOVIZ_ID = new GridColumn();
            colILK_TEBLIGAT_GIDERI_DOVIZ_ID.VisibleIndex = 196;
            colILK_TEBLIGAT_GIDERI_DOVIZ_ID.FieldName = "ILK_TEBLIGAT_GIDERI_DOVIZ_ID";
            colILK_TEBLIGAT_GIDERI_DOVIZ_ID.Name = "colILK_TEBLIGAT_GIDERI_DOVIZ_ID";
            colILK_TEBLIGAT_GIDERI_DOVIZ_ID.Visible = true;

            GridColumn colTAHLIYE_HARCI = new GridColumn();
            colTAHLIYE_HARCI.VisibleIndex = 197;
            colTAHLIYE_HARCI.FieldName = "TAHLIYE_HARCI";
            colTAHLIYE_HARCI.Name = "colTAHLIYE_HARCI";
            colTAHLIYE_HARCI.Visible = true;

            GridColumn colTAHLIYE_HARCI_DOVIZ_ID = new GridColumn();
            colTAHLIYE_HARCI_DOVIZ_ID.VisibleIndex = 198;
            colTAHLIYE_HARCI_DOVIZ_ID.FieldName = "TAHLIYE_HARCI_DOVIZ_ID";
            colTAHLIYE_HARCI_DOVIZ_ID.Name = "colTAHLIYE_HARCI_DOVIZ_ID";
            colTAHLIYE_HARCI_DOVIZ_ID.Visible = true;

            GridColumn colTESLIM_HARCI = new GridColumn();
            colTESLIM_HARCI.VisibleIndex = 199;
            colTESLIM_HARCI.FieldName = "TESLIM_HARCI";
            colTESLIM_HARCI.Name = "colTESLIM_HARCI";
            colTESLIM_HARCI.Visible = true;

            GridColumn colTESLIM_HARCI_DOVIZ_ID = new GridColumn();
            colTESLIM_HARCI_DOVIZ_ID.VisibleIndex = 200;
            colTESLIM_HARCI_DOVIZ_ID.FieldName = "TESLIM_HARCI_DOVIZ_ID";
            colTESLIM_HARCI_DOVIZ_ID.Name = "colTESLIM_HARCI_DOVIZ_ID";
            colTESLIM_HARCI_DOVIZ_ID.Visible = true;

            GridColumn colFERAGAT_HARCI = new GridColumn();
            colFERAGAT_HARCI.VisibleIndex = 201;
            colFERAGAT_HARCI.FieldName = "FERAGAT_HARCI";
            colFERAGAT_HARCI.Name = "colFERAGAT_HARCI";
            colFERAGAT_HARCI.Visible = true;

            GridColumn colFERAGAT_HARCI_DOVIZ_ID = new GridColumn();
            colFERAGAT_HARCI_DOVIZ_ID.VisibleIndex = 202;
            colFERAGAT_HARCI_DOVIZ_ID.FieldName = "FERAGAT_HARCI_DOVIZ_ID";
            colFERAGAT_HARCI_DOVIZ_ID.Name = "colFERAGAT_HARCI_DOVIZ_ID";
            colFERAGAT_HARCI_DOVIZ_ID.Visible = true;

            GridColumn colTO_YONETIMG_TAZMINATI_DOVIZ_ID = new GridColumn();
            colTO_YONETIMG_TAZMINATI_DOVIZ_ID.VisibleIndex = 203;
            colTO_YONETIMG_TAZMINATI_DOVIZ_ID.FieldName = "TO_YONETIMG_TAZMINATI_DOVIZ_ID";
            colTO_YONETIMG_TAZMINATI_DOVIZ_ID.Name = "colTO_YONETIMG_TAZMINATI_DOVIZ_ID";
            colTO_YONETIMG_TAZMINATI_DOVIZ_ID.Visible = true;

            GridColumn colTO_YONETIMG_TAZMINATI = new GridColumn();
            colTO_YONETIMG_TAZMINATI.VisibleIndex = 204;
            colTO_YONETIMG_TAZMINATI.FieldName = "TO_YONETIMG_TAZMINATI";
            colTO_YONETIMG_TAZMINATI.Name = "colTO_YONETIMG_TAZMINATI";
            colTO_YONETIMG_TAZMINATI.Visible = true;

            GridColumn colASAMA_ID = new GridColumn();
            colASAMA_ID.VisibleIndex = 205;
            colASAMA_ID.FieldName = "ASAMA_ID";
            colASAMA_ID.Name = "colASAMA_ID";
            colASAMA_ID.Visible = true;

            GridColumn colASAMA_ADI = new GridColumn();
            colASAMA_ADI.VisibleIndex = 206;
            colASAMA_ADI.FieldName = "ASAMA_ADI";
            colASAMA_ADI.Name = "colASAMA_ADI";
            colASAMA_ADI.Visible = true;

            GridColumn colTAKIP_TALEP_ID = new GridColumn();
            colTAKIP_TALEP_ID.VisibleIndex = 207;
            colTAKIP_TALEP_ID.FieldName = "TAKIP_TALEP_ID";
            colTAKIP_TALEP_ID.Name = "colTAKIP_TALEP_ID";
            colTAKIP_TALEP_ID.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			colCARI_ADI,
			colCARI_ID,
			colSORUMLU_AVUKAT_CARI_ID,
			colTARAF_KODU,
			colKOD,
			colTARAF_SIFAT_ID,
			colSIFAT,
			colID,
			colTALEP_ADI,
			colFORM_TIP_ID,
			colFORM_ADI,
			colFOY_DURUM_ID,
			colDURUM,
			colFOY_NO,
			colREFERANS_NO,
			colREFERANS_NO2,
			colREFERANS_NO3,
			colADLI_BIRIM_NO_ID,
			colNO,
			colADLIYE,
			colADLI_BIRIM_ADLIYE_ID,
			colICRA_OZEL_KOD1_ID,
			colICRA_OZEL_KOD2_ID,
			colICRA_OZEL_KOD3_ID,
			colICRA_OZEL_KOD4_ID,
			colTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			colFOY_ARSIV_TARIHI,
			colFOY_INFAZ_TARIHI,
			colTAKIBIN_MUVEKKILE_IADE_TARIHI,
			colSON_HESAP_TARIHI,
			colBIR_YIL_KAC_GUN,
			colASIL_ALACAK_DOVIZ_ID,
			colASIL_ALACAK,
			colISLEMIS_FAIZ_DOVIZ_ID,
			colISLEMIS_FAIZ,
			colBSMV_TO_DOVIZ_ID,
			colBSMV_TO,
			colKKDV_TO_DOVIZ_ID,
			colKKDV_TO,
			colOIV_TO,
			colKDV_TO_DOVIZ_ID,
			colKDV_TO,
			colIH_VEKALET_UCRETI_DOVIZ_ID,
			colIH_VEKALET_UCRETI,
			colIH_GIDERI_DOVIZ_ID,
			colIH_GIDERI,
			colIT_HACIZDE_ODENEN_DOVIZ_ID,
			colIT_HACIZDE_ODENEN,
			colKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID,
			colKARSILIKSIZ_CEK_TAZMINATI,
			colCEK_KOMISYONU_DOVIZ_ID,
			colCEK_KOMISYONU,
			colILAM_YARGILAMA_GIDERI_DOVIZ_ID,
			colILAM_YARGILAMA_GIDERI,
			colILAM_BK_YARG_ONAMA_DOVIZ_ID,
			colILAM_BK_YARG_ONAMA,
			colILAM_TEBLIG_GIDERI_DOVIZ_ID,
			colILAM_TEBLIG_GIDERI,
			colILAM_INKAR_TAZMINATI_DOVIZ_ID,
			colILAM_INKAR_TAZMINATI,
			colILAM_VEK_UCR_DOVIZ_ID,
			colILAM_VEK_UCR,
			colOIV_TO_DOVIZ_ID,
			colPROTESTO_GIDERI_DOVIZ_ID,
			colPROTESTO_GIDERI,
			colIHTAR_GIDERI_DOVIZ_ID,
			colIHTAR_GIDERI,
			colOZEL_TAZMINAT_DOVIZ_ID,
			colOZEL_TAZMINAT,
			colOZEL_TUTAR1_FAIZ_ORANI,
			colOZEL_TUTAR1_KONU_ID,
			colOZEL_TUTAR1_KONU_ADI,
			colOZEL_TUTAR1_DOVIZ_ID,
			colOZEL_TUTAR1,
			colOZEL_TUTAR2_KONU_ID,
			colOZEL_TUTAR2_KONU_ADI,
			colOZEL_TUTAR2_DOVIZ_ID,
			colOZEL_TUTAR2,
			colOZEL_TUTAR3_KONU_ID,
			colOZEL_TUTAR3_KONU_ADI,
			colOZEL_TUTAR3_DOVIZ_ID,
			colOZEL_TUTAR3,
			colTAKIP_CIKISI_DOVIZ_ID,
			colTAKIP_CIKISI,
			colSONRAKI_FAIZ_DOVIZ_ID,
			colSONRAKI_FAIZ,
			colSONRAKI_TAZMINAT_DOVIZ_ID,
			colSONRAKI_TAZMINAT,
			colBSMV_TS_DOVIZ_ID,
			colBSMV_TS,
			colOIV_TS_DOVIZ_ID,
			colOIV_TS,
			colKDV_TS_DOVIZ_ID,
			colKDV_TS,
			colILK_GIDERLER_DOVIZ_ID,
			colILK_GIDERLER,
			colPESIN_HARC_DOVIZ_ID,
			colPESIN_HARC,
			colODENEN_TAHSIL_HARCI_DOVIZ_ID,
			colODENEN_TAHSIL_HARCI,
			colKALAN_TAHSIL_HARCI_DOVIZ_ID,
			colKALAN_TAHSIL_HARCI,
			colMASAYA_KATILMA_HARCI_DOVIZ_ID,
			colMASAYA_KATILMA_HARCI,
			colPAYLASMA_HARCI_DOVIZ_ID,
			colPAYLASMA_HARCI,
			colDAVA_GIDERLERI_DOVIZ_ID,
			colDAVA_GIDERLERI,
			colDIGER_GIDERLER_DOVIZ_ID,
			colDIGER_GIDERLER,
			colTAKIP_VEKALET_UCRETI_KATSAYI,
			colTAKIP_VEKALET_UCRETI_DOVIZ_ID,
			colTAKIP_VEKALET_UCRETI,
			colDAVA_INKAR_TAZMINATI_DOVIZ_ID,
			colDAVA_INKAR_TAZMINATI,
			colDAVA_VEKALET_UCRETI_DOVIZ_ID,
			colDAVA_VEKALET_UCRETI,
			colODEME_TOPLAMI_DOVIZ_ID,
			colODEME_TOPLAMI,
			colTO_ODEME_TOPLAMI_DOVIZ_ID,
			colTO_ODEME_TOPLAMI,
			colMAHSUP_TOPLAMI_DOVIZ_ID,
			colMAHSUP_TOPLAMI,
			colFERAGAT_TOPLAMI,
			colFERAGAT_TOPLAMI_DOVIZ_ID,
			colALACAK_TOPLAMI_DOVIZ_ID,
			colALACAK_TOPLAMI,
			colKALAN_DOVIZ_ID,
			colKALAN,
			colTAHLIYE_VEK_UCR_DOVIZ_ID,
			colTAHLIYE_VEK_UCR,
			colDIGER_HARC_DOVIZ_ID,
			colDIGER_HARC,
			colTD_GIDERI_DOVIZ_ID,
			colTD_GIDERI,
			colTD_BAKIYE_HARC_DOVIZ_ID,
			colTD_BAKIYE_HARC,
			colTD_VEK_UCR_DOVIZ_ID,
			colTD_VEK_UCR,
			colTD_TEBLIG_GIDERI_DOVIZ_ID,
			colTD_TEBLIG_GIDERI,
			colBIRIKMIS_NAFAKA_DOVIZ_ID,
			colBIRIKMIS_NAFAKA,
			colICRA_INKAR_TAZMINATI_DOVIZ_ID,
			colICRA_INKAR_TAZMINATI,
			colDAMGA_PULU_DOVIZ_ID,
			colDAMGA_PULU,
			colACIKLAMA,
			colPROTOKOL_MIKTARI_DOVIZ_ID,
			colPROTOKOL_MIKTARI,
			colPROTOKOL_FAIZ_ORANI,
			colPROTOKOL_TARIHI,
			colKARSILIK_TUTARI_DOVIZ_ID,
			colKARSILIK_TUTARI,
			colTO_MASRAF_TOPLAMI,
			colTO_MASRAF_TOPLAMI_DOVIZ_ID,
			colTS_MASRAF_TOPLAMI,
			colTS_MASRAF_TOPLAMI_DOVIZ_ID,
			colTUM_MASRAF_TOPLAMI,
			colTUM_MASRAF_TOPLAMI_DOVIZ_ID,
			colHARC_TOPLAMI,
			colHARC_TOPLAMI_DOVIZ_ID,
			colTO_VEKALET_TOPLAMI_DOVIZ_ID,
			colTO_VEKALET_TOPLAMI,
			colTS_VEKALET_TOPLAMI,
			colTS_VEKALET_TOPLAMI_DOVIZ_ID,
			colTUM_VEKALET_TOPLAMI,
			colTUM_VEKALET_TOPLAMI_DOVIZ_ID,
			colKARSI_VEKALET_TOPLAMI,
			colKARSI_VEKALET_TOPLAMI_DOVIZ_ID,
			colFAIZ_TOPLAMI,
			colFAIZ_TOPLAMI_DOVIZ_ID,
			colILAM_UCRETLER_TOPLAMI,
			colILAM_UCRETLER_TOPLAMI_DOVIZ_ID,
			colIT_VEKALET_UCRETI_DOVIZ_ID,
			colIT_VEKALET_UCRETI,
			colIT_GIDERI_DOVIZ_ID,
			colIT_GIDERI,
			colTO_ODEME_MAHSUP_TOPLAMI,
			colTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID,
			colPAYLASIM_TIPI,
			colTS_HESAP_TIP_ID,
			colTS_HESAP_TIP_ADI,
			colTO_HESAP_TIP_ID,
			colTO_HESAP_TIP_ADI,
			colBASVURMA_HARCI,
			colBASVURMA_HARCI_DOVIZ_ID,
			colVEKALET_HARCI,
			colVEKALET_HARCI_DOVIZ_ID,
			colVEKALET_PULU,
			colVEKALET_PULU_DOVIZ_ID,
			colIFLAS_BASVURMA_HARCI,
			colIFLAS_BASVURMA_HARCI_DOVIZ_ID,
			colIFLASIN_ACILMASI_HARCI,
			colIFLASIN_ACILMASI_HARCI_DOVIZ_ID,
			colILK_TEBLIGAT_GIDERI,
			colILK_TEBLIGAT_GIDERI_DOVIZ_ID,
			colTAHLIYE_HARCI,
			colTAHLIYE_HARCI_DOVIZ_ID,
			colTESLIM_HARCI,
			colTESLIM_HARCI_DOVIZ_ID,
			colFERAGAT_HARCI,
			colFERAGAT_HARCI_DOVIZ_ID,
			colTO_YONETIMG_TAZMINATI_DOVIZ_ID,
			colTO_YONETIMG_TAZMINATI,
			colASAMA_ID,
			colASAMA_ADI,
			colTAKIP_TALEP_ID,
			};

            #endregion []

            #region Column Caption

            Dictionary<string, string> captionlar = GetCaptionDictinory();
            Dictionary<string, RepositoryItem> editler = GetRepositoryItemDictinory();

            for (int i = 0; i < dizi.Length; i++)
            {
                string caption = string.Empty;
                if (captionlar.ContainsKey(dizi[i].FieldName))
                    caption = captionlar[dizi[i].FieldName];
                if (caption.Length > 0)
                    dizi[i].Caption = caption;
                else if (dizi[i].FieldName.ToLower().Contains("doviz_id"))
                    dizi[i].Caption = "Brm";

                if (dizi[i].FieldName.Contains("_DOVIZ_ID"))
                {
                    dizi[i].ColumnEdit = editler["DovizId"];
                }
                else if (editler.ContainsKey(dizi[i].FieldName))
                    dizi[i].ColumnEdit = editler[dizi[i].FieldName];
            }

            #endregion Column Caption

            return dizi;
        }

        public PivotGridField[] GetPivotFields()
        {
            #region Field & Properties

            PivotGridField fieldCARI_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldCARI_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldCARI_ADI.AreaIndex = 0;
            fieldCARI_ADI.FieldName = "CARI_ADI";
            fieldCARI_ADI.Name = "fieldCARI_ADI";
            fieldCARI_ADI.Visible = false;

            PivotGridField fieldCARI_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldCARI_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldCARI_ID.AreaIndex = 1;
            fieldCARI_ID.FieldName = "CARI_ID";
            fieldCARI_ID.Name = "fieldCARI_ID";
            fieldCARI_ID.Visible = false;

            PivotGridField fieldSORUMLU_AVUKAT_CARI_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU_AVUKAT_CARI_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU_AVUKAT_CARI_ID.AreaIndex = 2;
            fieldSORUMLU_AVUKAT_CARI_ID.FieldName = "SORUMLU_AVUKAT_CARI_ID";
            fieldSORUMLU_AVUKAT_CARI_ID.Name = "fieldSORUMLU_AVUKAT_CARI_ID";
            fieldSORUMLU_AVUKAT_CARI_ID.Visible = false;

            PivotGridField fieldTARAF_KODU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARAF_KODU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTARAF_KODU.AreaIndex = 3;
            fieldTARAF_KODU.FieldName = "TARAF_KODU";
            fieldTARAF_KODU.Name = "fieldTARAF_KODU";
            fieldTARAF_KODU.Visible = false;

            PivotGridField fieldKOD = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKOD.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKOD.AreaIndex = 4;
            fieldKOD.FieldName = "KOD";
            fieldKOD.Name = "fieldKOD";
            fieldKOD.Visible = false;

            PivotGridField fieldTARAF_SIFAT_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTARAF_SIFAT_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTARAF_SIFAT_ID.AreaIndex = 5;
            fieldTARAF_SIFAT_ID.FieldName = "TARAF_SIFAT_ID";
            fieldTARAF_SIFAT_ID.Name = "fieldTARAF_SIFAT_ID";
            fieldTARAF_SIFAT_ID.Visible = false;

            PivotGridField fieldSIFAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSIFAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSIFAT.AreaIndex = 6;
            fieldSIFAT.FieldName = "SIFAT";
            fieldSIFAT.Name = "fieldSIFAT";
            fieldSIFAT.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 7;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldTALEP_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALEP_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALEP_ADI.AreaIndex = 8;
            fieldTALEP_ADI.FieldName = "TALEP_ADI";
            fieldTALEP_ADI.Name = "fieldTALEP_ADI";
            fieldTALEP_ADI.Visible = false;

            PivotGridField fieldFORM_TIP_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFORM_TIP_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFORM_TIP_ID.AreaIndex = 9;
            fieldFORM_TIP_ID.FieldName = "FORM_TIP_ID";
            fieldFORM_TIP_ID.Name = "fieldFORM_TIP_ID";
            fieldFORM_TIP_ID.Visible = false;

            PivotGridField fieldFORM_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFORM_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFORM_ADI.AreaIndex = 10;
            fieldFORM_ADI.FieldName = "FORM_ADI";
            fieldFORM_ADI.Name = "fieldFORM_ADI";
            fieldFORM_ADI.Visible = false;

            PivotGridField fieldFOY_DURUM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_DURUM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_DURUM_ID.AreaIndex = 11;
            fieldFOY_DURUM_ID.FieldName = "FOY_DURUM_ID";
            fieldFOY_DURUM_ID.Name = "fieldFOY_DURUM_ID";
            fieldFOY_DURUM_ID.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 12;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 13;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 14;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldREFERANS_NO2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO2.AreaIndex = 15;
            fieldREFERANS_NO2.FieldName = "REFERANS_NO2";
            fieldREFERANS_NO2.Name = "fieldREFERANS_NO2";
            fieldREFERANS_NO2.Visible = false;

            PivotGridField fieldREFERANS_NO3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO3.AreaIndex = 16;
            fieldREFERANS_NO3.FieldName = "REFERANS_NO3";
            fieldREFERANS_NO3.Name = "fieldREFERANS_NO3";
            fieldREFERANS_NO3.Visible = false;

            PivotGridField fieldADLI_BIRIM_NO_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLI_BIRIM_NO_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLI_BIRIM_NO_ID.AreaIndex = 17;
            fieldADLI_BIRIM_NO_ID.FieldName = "ADLI_BIRIM_NO_ID";
            fieldADLI_BIRIM_NO_ID.Name = "fieldADLI_BIRIM_NO_ID";
            fieldADLI_BIRIM_NO_ID.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 18;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLIYE.AreaIndex = 19;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = false;

            PivotGridField fieldADLI_BIRIM_ADLIYE_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLI_BIRIM_ADLIYE_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLI_BIRIM_ADLIYE_ID.AreaIndex = 20;
            fieldADLI_BIRIM_ADLIYE_ID.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            fieldADLI_BIRIM_ADLIYE_ID.Name = "fieldADLI_BIRIM_ADLIYE_ID";
            fieldADLI_BIRIM_ADLIYE_ID.Visible = false;

            PivotGridField fieldICRA_OZEL_KOD1_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_OZEL_KOD1_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_OZEL_KOD1_ID.AreaIndex = 21;
            fieldICRA_OZEL_KOD1_ID.FieldName = "ICRA_OZEL_KOD1_ID";
            fieldICRA_OZEL_KOD1_ID.Name = "fieldICRA_OZEL_KOD1_ID";
            fieldICRA_OZEL_KOD1_ID.Visible = false;

            PivotGridField fieldICRA_OZEL_KOD2_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_OZEL_KOD2_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_OZEL_KOD2_ID.AreaIndex = 22;
            fieldICRA_OZEL_KOD2_ID.FieldName = "ICRA_OZEL_KOD2_ID";
            fieldICRA_OZEL_KOD2_ID.Name = "fieldICRA_OZEL_KOD2_ID";
            fieldICRA_OZEL_KOD2_ID.Visible = false;

            PivotGridField fieldICRA_OZEL_KOD3_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_OZEL_KOD3_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_OZEL_KOD3_ID.AreaIndex = 23;
            fieldICRA_OZEL_KOD3_ID.FieldName = "ICRA_OZEL_KOD3_ID";
            fieldICRA_OZEL_KOD3_ID.Name = "fieldICRA_OZEL_KOD3_ID";
            fieldICRA_OZEL_KOD3_ID.Visible = false;

            PivotGridField fieldICRA_OZEL_KOD4_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_OZEL_KOD4_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_OZEL_KOD4_ID.AreaIndex = 24;
            fieldICRA_OZEL_KOD4_ID.FieldName = "ICRA_OZEL_KOD4_ID";
            fieldICRA_OZEL_KOD4_ID.Name = "fieldICRA_OZEL_KOD4_ID";
            fieldICRA_OZEL_KOD4_ID.Visible = false;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 25;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldFOY_ARSIV_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_ARSIV_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_ARSIV_TARIHI.AreaIndex = 26;
            fieldFOY_ARSIV_TARIHI.FieldName = "FOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Name = "fieldFOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Visible = false;

            PivotGridField fieldFOY_INFAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_INFAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_INFAZ_TARIHI.AreaIndex = 27;
            fieldFOY_INFAZ_TARIHI.FieldName = "FOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Name = "fieldFOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Visible = false;

            PivotGridField fieldTAKIBIN_MUVEKKILE_IADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.AreaIndex = 28;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.FieldName = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Name = "fieldTAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Visible = false;

            PivotGridField fieldSON_HESAP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSON_HESAP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSON_HESAP_TARIHI.AreaIndex = 29;
            fieldSON_HESAP_TARIHI.FieldName = "SON_HESAP_TARIHI";
            fieldSON_HESAP_TARIHI.Name = "fieldSON_HESAP_TARIHI";
            fieldSON_HESAP_TARIHI.Visible = false;

            PivotGridField fieldBIR_YIL_KAC_GUN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIR_YIL_KAC_GUN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIR_YIL_KAC_GUN.AreaIndex = 30;
            fieldBIR_YIL_KAC_GUN.FieldName = "BIR_YIL_KAC_GUN";
            fieldBIR_YIL_KAC_GUN.Name = "fieldBIR_YIL_KAC_GUN";
            fieldBIR_YIL_KAC_GUN.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 31;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 32;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldISLEMIS_FAIZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISLEMIS_FAIZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISLEMIS_FAIZ_DOVIZ_ID.AreaIndex = 33;
            fieldISLEMIS_FAIZ_DOVIZ_ID.FieldName = "ISLEMIS_FAIZ_DOVIZ_ID";
            fieldISLEMIS_FAIZ_DOVIZ_ID.Name = "fieldISLEMIS_FAIZ_DOVIZ_ID";
            fieldISLEMIS_FAIZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldISLEMIS_FAIZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISLEMIS_FAIZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISLEMIS_FAIZ.AreaIndex = 34;
            fieldISLEMIS_FAIZ.FieldName = "ISLEMIS_FAIZ";
            fieldISLEMIS_FAIZ.Name = "fieldISLEMIS_FAIZ";
            fieldISLEMIS_FAIZ.Visible = false;

            PivotGridField fieldBSMV_TO_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBSMV_TO_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBSMV_TO_DOVIZ_ID.AreaIndex = 35;
            fieldBSMV_TO_DOVIZ_ID.FieldName = "BSMV_TO_DOVIZ_ID";
            fieldBSMV_TO_DOVIZ_ID.Name = "fieldBSMV_TO_DOVIZ_ID";
            fieldBSMV_TO_DOVIZ_ID.Visible = false;

            PivotGridField fieldBSMV_TO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBSMV_TO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBSMV_TO.AreaIndex = 36;
            fieldBSMV_TO.FieldName = "BSMV_TO";
            fieldBSMV_TO.Name = "fieldBSMV_TO";
            fieldBSMV_TO.Visible = false;

            PivotGridField fieldKKDV_TO_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKKDV_TO_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKKDV_TO_DOVIZ_ID.AreaIndex = 37;
            fieldKKDV_TO_DOVIZ_ID.FieldName = "KKDV_TO_DOVIZ_ID";
            fieldKKDV_TO_DOVIZ_ID.Name = "fieldKKDV_TO_DOVIZ_ID";
            fieldKKDV_TO_DOVIZ_ID.Visible = false;

            PivotGridField fieldKKDV_TO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKKDV_TO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKKDV_TO.AreaIndex = 38;
            fieldKKDV_TO.FieldName = "KKDV_TO";
            fieldKKDV_TO.Name = "fieldKKDV_TO";
            fieldKKDV_TO.Visible = false;

            PivotGridField fieldOIV_TO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOIV_TO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOIV_TO.AreaIndex = 39;
            fieldOIV_TO.FieldName = "OIV_TO";
            fieldOIV_TO.Name = "fieldOIV_TO";
            fieldOIV_TO.Visible = false;

            PivotGridField fieldKDV_TO_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKDV_TO_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKDV_TO_DOVIZ_ID.AreaIndex = 40;
            fieldKDV_TO_DOVIZ_ID.FieldName = "KDV_TO_DOVIZ_ID";
            fieldKDV_TO_DOVIZ_ID.Name = "fieldKDV_TO_DOVIZ_ID";
            fieldKDV_TO_DOVIZ_ID.Visible = false;

            PivotGridField fieldKDV_TO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKDV_TO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKDV_TO.AreaIndex = 41;
            fieldKDV_TO.FieldName = "KDV_TO";
            fieldKDV_TO.Name = "fieldKDV_TO";
            fieldKDV_TO.Visible = false;

            PivotGridField fieldIH_VEKALET_UCRETI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIH_VEKALET_UCRETI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIH_VEKALET_UCRETI_DOVIZ_ID.AreaIndex = 42;
            fieldIH_VEKALET_UCRETI_DOVIZ_ID.FieldName = "IH_VEKALET_UCRETI_DOVIZ_ID";
            fieldIH_VEKALET_UCRETI_DOVIZ_ID.Name = "fieldIH_VEKALET_UCRETI_DOVIZ_ID";
            fieldIH_VEKALET_UCRETI_DOVIZ_ID.Visible = false;

            PivotGridField fieldIH_VEKALET_UCRETI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIH_VEKALET_UCRETI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIH_VEKALET_UCRETI.AreaIndex = 43;
            fieldIH_VEKALET_UCRETI.FieldName = "IH_VEKALET_UCRETI";
            fieldIH_VEKALET_UCRETI.Name = "fieldIH_VEKALET_UCRETI";
            fieldIH_VEKALET_UCRETI.Visible = false;

            PivotGridField fieldIH_GIDERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIH_GIDERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIH_GIDERI_DOVIZ_ID.AreaIndex = 44;
            fieldIH_GIDERI_DOVIZ_ID.FieldName = "IH_GIDERI_DOVIZ_ID";
            fieldIH_GIDERI_DOVIZ_ID.Name = "fieldIH_GIDERI_DOVIZ_ID";
            fieldIH_GIDERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldIH_GIDERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIH_GIDERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIH_GIDERI.AreaIndex = 45;
            fieldIH_GIDERI.FieldName = "IH_GIDERI";
            fieldIH_GIDERI.Name = "fieldIH_GIDERI";
            fieldIH_GIDERI.Visible = false;

            PivotGridField fieldIT_HACIZDE_ODENEN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIT_HACIZDE_ODENEN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIT_HACIZDE_ODENEN_DOVIZ_ID.AreaIndex = 46;
            fieldIT_HACIZDE_ODENEN_DOVIZ_ID.FieldName = "IT_HACIZDE_ODENEN_DOVIZ_ID";
            fieldIT_HACIZDE_ODENEN_DOVIZ_ID.Name = "fieldIT_HACIZDE_ODENEN_DOVIZ_ID";
            fieldIT_HACIZDE_ODENEN_DOVIZ_ID.Visible = false;

            PivotGridField fieldIT_HACIZDE_ODENEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIT_HACIZDE_ODENEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIT_HACIZDE_ODENEN.AreaIndex = 47;
            fieldIT_HACIZDE_ODENEN.FieldName = "IT_HACIZDE_ODENEN";
            fieldIT_HACIZDE_ODENEN.Name = "fieldIT_HACIZDE_ODENEN";
            fieldIT_HACIZDE_ODENEN.Visible = false;

            PivotGridField fieldKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.AreaIndex = 48;
            fieldKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.FieldName = "KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID";
            fieldKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.Name = "fieldKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID";
            fieldKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.Visible = false;

            PivotGridField fieldKARSILIKSIZ_CEK_TAZMINATI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKARSILIKSIZ_CEK_TAZMINATI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKARSILIKSIZ_CEK_TAZMINATI.AreaIndex = 49;
            fieldKARSILIKSIZ_CEK_TAZMINATI.FieldName = "KARSILIKSIZ_CEK_TAZMINATI";
            fieldKARSILIKSIZ_CEK_TAZMINATI.Name = "fieldKARSILIKSIZ_CEK_TAZMINATI";
            fieldKARSILIKSIZ_CEK_TAZMINATI.Visible = false;

            PivotGridField fieldCEK_KOMISYONU_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldCEK_KOMISYONU_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldCEK_KOMISYONU_DOVIZ_ID.AreaIndex = 50;
            fieldCEK_KOMISYONU_DOVIZ_ID.FieldName = "CEK_KOMISYONU_DOVIZ_ID";
            fieldCEK_KOMISYONU_DOVIZ_ID.Name = "fieldCEK_KOMISYONU_DOVIZ_ID";
            fieldCEK_KOMISYONU_DOVIZ_ID.Visible = false;

            PivotGridField fieldCEK_KOMISYONU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldCEK_KOMISYONU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldCEK_KOMISYONU.AreaIndex = 51;
            fieldCEK_KOMISYONU.FieldName = "CEK_KOMISYONU";
            fieldCEK_KOMISYONU.Name = "fieldCEK_KOMISYONU";
            fieldCEK_KOMISYONU.Visible = false;

            PivotGridField fieldILAM_YARGILAMA_GIDERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_YARGILAMA_GIDERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_YARGILAMA_GIDERI_DOVIZ_ID.AreaIndex = 52;
            fieldILAM_YARGILAMA_GIDERI_DOVIZ_ID.FieldName = "ILAM_YARGILAMA_GIDERI_DOVIZ_ID";
            fieldILAM_YARGILAMA_GIDERI_DOVIZ_ID.Name = "fieldILAM_YARGILAMA_GIDERI_DOVIZ_ID";
            fieldILAM_YARGILAMA_GIDERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldILAM_YARGILAMA_GIDERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_YARGILAMA_GIDERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_YARGILAMA_GIDERI.AreaIndex = 53;
            fieldILAM_YARGILAMA_GIDERI.FieldName = "ILAM_YARGILAMA_GIDERI";
            fieldILAM_YARGILAMA_GIDERI.Name = "fieldILAM_YARGILAMA_GIDERI";
            fieldILAM_YARGILAMA_GIDERI.Visible = false;

            PivotGridField fieldILAM_BK_YARG_ONAMA_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_BK_YARG_ONAMA_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_BK_YARG_ONAMA_DOVIZ_ID.AreaIndex = 54;
            fieldILAM_BK_YARG_ONAMA_DOVIZ_ID.FieldName = "ILAM_BK_YARG_ONAMA_DOVIZ_ID";
            fieldILAM_BK_YARG_ONAMA_DOVIZ_ID.Name = "fieldILAM_BK_YARG_ONAMA_DOVIZ_ID";
            fieldILAM_BK_YARG_ONAMA_DOVIZ_ID.Visible = false;

            PivotGridField fieldILAM_BK_YARG_ONAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_BK_YARG_ONAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_BK_YARG_ONAMA.AreaIndex = 55;
            fieldILAM_BK_YARG_ONAMA.FieldName = "ILAM_BK_YARG_ONAMA";
            fieldILAM_BK_YARG_ONAMA.Name = "fieldILAM_BK_YARG_ONAMA";
            fieldILAM_BK_YARG_ONAMA.Visible = false;

            PivotGridField fieldILAM_TEBLIG_GIDERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_TEBLIG_GIDERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_TEBLIG_GIDERI_DOVIZ_ID.AreaIndex = 56;
            fieldILAM_TEBLIG_GIDERI_DOVIZ_ID.FieldName = "ILAM_TEBLIG_GIDERI_DOVIZ_ID";
            fieldILAM_TEBLIG_GIDERI_DOVIZ_ID.Name = "fieldILAM_TEBLIG_GIDERI_DOVIZ_ID";
            fieldILAM_TEBLIG_GIDERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldILAM_TEBLIG_GIDERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_TEBLIG_GIDERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_TEBLIG_GIDERI.AreaIndex = 57;
            fieldILAM_TEBLIG_GIDERI.FieldName = "ILAM_TEBLIG_GIDERI";
            fieldILAM_TEBLIG_GIDERI.Name = "fieldILAM_TEBLIG_GIDERI";
            fieldILAM_TEBLIG_GIDERI.Visible = false;

            PivotGridField fieldILAM_INKAR_TAZMINATI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_INKAR_TAZMINATI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_INKAR_TAZMINATI_DOVIZ_ID.AreaIndex = 58;
            fieldILAM_INKAR_TAZMINATI_DOVIZ_ID.FieldName = "ILAM_INKAR_TAZMINATI_DOVIZ_ID";
            fieldILAM_INKAR_TAZMINATI_DOVIZ_ID.Name = "fieldILAM_INKAR_TAZMINATI_DOVIZ_ID";
            fieldILAM_INKAR_TAZMINATI_DOVIZ_ID.Visible = false;

            PivotGridField fieldILAM_INKAR_TAZMINATI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_INKAR_TAZMINATI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_INKAR_TAZMINATI.AreaIndex = 59;
            fieldILAM_INKAR_TAZMINATI.FieldName = "ILAM_INKAR_TAZMINATI";
            fieldILAM_INKAR_TAZMINATI.Name = "fieldILAM_INKAR_TAZMINATI";
            fieldILAM_INKAR_TAZMINATI.Visible = false;

            PivotGridField fieldILAM_VEK_UCR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_VEK_UCR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_VEK_UCR_DOVIZ_ID.AreaIndex = 60;
            fieldILAM_VEK_UCR_DOVIZ_ID.FieldName = "ILAM_VEK_UCR_DOVIZ_ID";
            fieldILAM_VEK_UCR_DOVIZ_ID.Name = "fieldILAM_VEK_UCR_DOVIZ_ID";
            fieldILAM_VEK_UCR_DOVIZ_ID.Visible = false;

            PivotGridField fieldILAM_VEK_UCR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_VEK_UCR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_VEK_UCR.AreaIndex = 61;
            fieldILAM_VEK_UCR.FieldName = "ILAM_VEK_UCR";
            fieldILAM_VEK_UCR.Name = "fieldILAM_VEK_UCR";
            fieldILAM_VEK_UCR.Visible = false;

            PivotGridField fieldOIV_TO_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOIV_TO_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOIV_TO_DOVIZ_ID.AreaIndex = 62;
            fieldOIV_TO_DOVIZ_ID.FieldName = "OIV_TO_DOVIZ_ID";
            fieldOIV_TO_DOVIZ_ID.Name = "fieldOIV_TO_DOVIZ_ID";
            fieldOIV_TO_DOVIZ_ID.Visible = false;

            PivotGridField fieldPROTESTO_GIDERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROTESTO_GIDERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROTESTO_GIDERI_DOVIZ_ID.AreaIndex = 63;
            fieldPROTESTO_GIDERI_DOVIZ_ID.FieldName = "PROTESTO_GIDERI_DOVIZ_ID";
            fieldPROTESTO_GIDERI_DOVIZ_ID.Name = "fieldPROTESTO_GIDERI_DOVIZ_ID";
            fieldPROTESTO_GIDERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldPROTESTO_GIDERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROTESTO_GIDERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROTESTO_GIDERI.AreaIndex = 64;
            fieldPROTESTO_GIDERI.FieldName = "PROTESTO_GIDERI";
            fieldPROTESTO_GIDERI.Name = "fieldPROTESTO_GIDERI";
            fieldPROTESTO_GIDERI.Visible = false;

            PivotGridField fieldIHTAR_GIDERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIHTAR_GIDERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIHTAR_GIDERI_DOVIZ_ID.AreaIndex = 65;
            fieldIHTAR_GIDERI_DOVIZ_ID.FieldName = "IHTAR_GIDERI_DOVIZ_ID";
            fieldIHTAR_GIDERI_DOVIZ_ID.Name = "fieldIHTAR_GIDERI_DOVIZ_ID";
            fieldIHTAR_GIDERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldIHTAR_GIDERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIHTAR_GIDERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIHTAR_GIDERI.AreaIndex = 66;
            fieldIHTAR_GIDERI.FieldName = "IHTAR_GIDERI";
            fieldIHTAR_GIDERI.Name = "fieldIHTAR_GIDERI";
            fieldIHTAR_GIDERI.Visible = false;

            PivotGridField fieldOZEL_TAZMINAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TAZMINAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TAZMINAT_DOVIZ_ID.AreaIndex = 67;
            fieldOZEL_TAZMINAT_DOVIZ_ID.FieldName = "OZEL_TAZMINAT_DOVIZ_ID";
            fieldOZEL_TAZMINAT_DOVIZ_ID.Name = "fieldOZEL_TAZMINAT_DOVIZ_ID";
            fieldOZEL_TAZMINAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldOZEL_TAZMINAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TAZMINAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TAZMINAT.AreaIndex = 68;
            fieldOZEL_TAZMINAT.FieldName = "OZEL_TAZMINAT";
            fieldOZEL_TAZMINAT.Name = "fieldOZEL_TAZMINAT";
            fieldOZEL_TAZMINAT.Visible = false;

            PivotGridField fieldOZEL_TUTAR1_FAIZ_ORANI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TUTAR1_FAIZ_ORANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TUTAR1_FAIZ_ORANI.AreaIndex = 69;
            fieldOZEL_TUTAR1_FAIZ_ORANI.FieldName = "OZEL_TUTAR1_FAIZ_ORANI";
            fieldOZEL_TUTAR1_FAIZ_ORANI.Name = "fieldOZEL_TUTAR1_FAIZ_ORANI";
            fieldOZEL_TUTAR1_FAIZ_ORANI.Visible = false;

            PivotGridField fieldOZEL_TUTAR1_KONU_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TUTAR1_KONU_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TUTAR1_KONU_ID.AreaIndex = 70;
            fieldOZEL_TUTAR1_KONU_ID.FieldName = "OZEL_TUTAR1_KONU_ID";
            fieldOZEL_TUTAR1_KONU_ID.Name = "fieldOZEL_TUTAR1_KONU_ID";
            fieldOZEL_TUTAR1_KONU_ID.Visible = false;

            PivotGridField fieldOZEL_TUTAR1_KONU_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TUTAR1_KONU_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TUTAR1_KONU_ADI.AreaIndex = 71;
            fieldOZEL_TUTAR1_KONU_ADI.FieldName = "OZEL_TUTAR1_KONU_ADI";
            fieldOZEL_TUTAR1_KONU_ADI.Name = "fieldOZEL_TUTAR1_KONU_ADI";
            fieldOZEL_TUTAR1_KONU_ADI.Visible = false;

            PivotGridField fieldOZEL_TUTAR1_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TUTAR1_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TUTAR1_DOVIZ_ID.AreaIndex = 72;
            fieldOZEL_TUTAR1_DOVIZ_ID.FieldName = "OZEL_TUTAR1_DOVIZ_ID";
            fieldOZEL_TUTAR1_DOVIZ_ID.Name = "fieldOZEL_TUTAR1_DOVIZ_ID";
            fieldOZEL_TUTAR1_DOVIZ_ID.Visible = false;

            PivotGridField fieldOZEL_TUTAR1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TUTAR1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TUTAR1.AreaIndex = 73;
            fieldOZEL_TUTAR1.FieldName = "OZEL_TUTAR1";
            fieldOZEL_TUTAR1.Name = "fieldOZEL_TUTAR1";
            fieldOZEL_TUTAR1.Visible = false;

            PivotGridField fieldOZEL_TUTAR2_KONU_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TUTAR2_KONU_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TUTAR2_KONU_ID.AreaIndex = 74;
            fieldOZEL_TUTAR2_KONU_ID.FieldName = "OZEL_TUTAR2_KONU_ID";
            fieldOZEL_TUTAR2_KONU_ID.Name = "fieldOZEL_TUTAR2_KONU_ID";
            fieldOZEL_TUTAR2_KONU_ID.Visible = false;

            PivotGridField fieldOZEL_TUTAR2_KONU_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TUTAR2_KONU_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TUTAR2_KONU_ADI.AreaIndex = 75;
            fieldOZEL_TUTAR2_KONU_ADI.FieldName = "OZEL_TUTAR2_KONU_ADI";
            fieldOZEL_TUTAR2_KONU_ADI.Name = "fieldOZEL_TUTAR2_KONU_ADI";
            fieldOZEL_TUTAR2_KONU_ADI.Visible = false;

            PivotGridField fieldOZEL_TUTAR2_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TUTAR2_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TUTAR2_DOVIZ_ID.AreaIndex = 76;
            fieldOZEL_TUTAR2_DOVIZ_ID.FieldName = "OZEL_TUTAR2_DOVIZ_ID";
            fieldOZEL_TUTAR2_DOVIZ_ID.Name = "fieldOZEL_TUTAR2_DOVIZ_ID";
            fieldOZEL_TUTAR2_DOVIZ_ID.Visible = false;

            PivotGridField fieldOZEL_TUTAR2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TUTAR2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TUTAR2.AreaIndex = 77;
            fieldOZEL_TUTAR2.FieldName = "OZEL_TUTAR2";
            fieldOZEL_TUTAR2.Name = "fieldOZEL_TUTAR2";
            fieldOZEL_TUTAR2.Visible = false;

            PivotGridField fieldOZEL_TUTAR3_KONU_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TUTAR3_KONU_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TUTAR3_KONU_ID.AreaIndex = 78;
            fieldOZEL_TUTAR3_KONU_ID.FieldName = "OZEL_TUTAR3_KONU_ID";
            fieldOZEL_TUTAR3_KONU_ID.Name = "fieldOZEL_TUTAR3_KONU_ID";
            fieldOZEL_TUTAR3_KONU_ID.Visible = false;

            PivotGridField fieldOZEL_TUTAR3_KONU_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TUTAR3_KONU_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TUTAR3_KONU_ADI.AreaIndex = 79;
            fieldOZEL_TUTAR3_KONU_ADI.FieldName = "OZEL_TUTAR3_KONU_ADI";
            fieldOZEL_TUTAR3_KONU_ADI.Name = "fieldOZEL_TUTAR3_KONU_ADI";
            fieldOZEL_TUTAR3_KONU_ADI.Visible = false;

            PivotGridField fieldOZEL_TUTAR3_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TUTAR3_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TUTAR3_DOVIZ_ID.AreaIndex = 80;
            fieldOZEL_TUTAR3_DOVIZ_ID.FieldName = "OZEL_TUTAR3_DOVIZ_ID";
            fieldOZEL_TUTAR3_DOVIZ_ID.Name = "fieldOZEL_TUTAR3_DOVIZ_ID";
            fieldOZEL_TUTAR3_DOVIZ_ID.Visible = false;

            PivotGridField fieldOZEL_TUTAR3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TUTAR3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TUTAR3.AreaIndex = 81;
            fieldOZEL_TUTAR3.FieldName = "OZEL_TUTAR3";
            fieldOZEL_TUTAR3.Name = "fieldOZEL_TUTAR3";
            fieldOZEL_TUTAR3.Visible = false;

            PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI_DOVIZ_ID.AreaIndex = 82;
            fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTAKIP_CIKISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI.AreaIndex = 83;
            fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";
            fieldTAKIP_CIKISI.Visible = false;

            PivotGridField fieldSONRAKI_FAIZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSONRAKI_FAIZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSONRAKI_FAIZ_DOVIZ_ID.AreaIndex = 84;
            fieldSONRAKI_FAIZ_DOVIZ_ID.FieldName = "SONRAKI_FAIZ_DOVIZ_ID";
            fieldSONRAKI_FAIZ_DOVIZ_ID.Name = "fieldSONRAKI_FAIZ_DOVIZ_ID";
            fieldSONRAKI_FAIZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldSONRAKI_FAIZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSONRAKI_FAIZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSONRAKI_FAIZ.AreaIndex = 85;
            fieldSONRAKI_FAIZ.FieldName = "SONRAKI_FAIZ";
            fieldSONRAKI_FAIZ.Name = "fieldSONRAKI_FAIZ";
            fieldSONRAKI_FAIZ.Visible = false;

            PivotGridField fieldSONRAKI_TAZMINAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSONRAKI_TAZMINAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSONRAKI_TAZMINAT_DOVIZ_ID.AreaIndex = 86;
            fieldSONRAKI_TAZMINAT_DOVIZ_ID.FieldName = "SONRAKI_TAZMINAT_DOVIZ_ID";
            fieldSONRAKI_TAZMINAT_DOVIZ_ID.Name = "fieldSONRAKI_TAZMINAT_DOVIZ_ID";
            fieldSONRAKI_TAZMINAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldSONRAKI_TAZMINAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSONRAKI_TAZMINAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSONRAKI_TAZMINAT.AreaIndex = 87;
            fieldSONRAKI_TAZMINAT.FieldName = "SONRAKI_TAZMINAT";
            fieldSONRAKI_TAZMINAT.Name = "fieldSONRAKI_TAZMINAT";
            fieldSONRAKI_TAZMINAT.Visible = false;

            PivotGridField fieldBSMV_TS_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBSMV_TS_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBSMV_TS_DOVIZ_ID.AreaIndex = 88;
            fieldBSMV_TS_DOVIZ_ID.FieldName = "BSMV_TS_DOVIZ_ID";
            fieldBSMV_TS_DOVIZ_ID.Name = "fieldBSMV_TS_DOVIZ_ID";
            fieldBSMV_TS_DOVIZ_ID.Visible = false;

            PivotGridField fieldBSMV_TS = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBSMV_TS.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBSMV_TS.AreaIndex = 89;
            fieldBSMV_TS.FieldName = "BSMV_TS";
            fieldBSMV_TS.Name = "fieldBSMV_TS";
            fieldBSMV_TS.Visible = false;

            PivotGridField fieldOIV_TS_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOIV_TS_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOIV_TS_DOVIZ_ID.AreaIndex = 90;
            fieldOIV_TS_DOVIZ_ID.FieldName = "OIV_TS_DOVIZ_ID";
            fieldOIV_TS_DOVIZ_ID.Name = "fieldOIV_TS_DOVIZ_ID";
            fieldOIV_TS_DOVIZ_ID.Visible = false;

            PivotGridField fieldOIV_TS = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOIV_TS.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOIV_TS.AreaIndex = 91;
            fieldOIV_TS.FieldName = "OIV_TS";
            fieldOIV_TS.Name = "fieldOIV_TS";
            fieldOIV_TS.Visible = false;

            PivotGridField fieldKDV_TS_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKDV_TS_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKDV_TS_DOVIZ_ID.AreaIndex = 92;
            fieldKDV_TS_DOVIZ_ID.FieldName = "KDV_TS_DOVIZ_ID";
            fieldKDV_TS_DOVIZ_ID.Name = "fieldKDV_TS_DOVIZ_ID";
            fieldKDV_TS_DOVIZ_ID.Visible = false;

            PivotGridField fieldKDV_TS = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKDV_TS.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKDV_TS.AreaIndex = 93;
            fieldKDV_TS.FieldName = "KDV_TS";
            fieldKDV_TS.Name = "fieldKDV_TS";
            fieldKDV_TS.Visible = false;

            PivotGridField fieldILK_GIDERLER_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILK_GIDERLER_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILK_GIDERLER_DOVIZ_ID.AreaIndex = 94;
            fieldILK_GIDERLER_DOVIZ_ID.FieldName = "ILK_GIDERLER_DOVIZ_ID";
            fieldILK_GIDERLER_DOVIZ_ID.Name = "fieldILK_GIDERLER_DOVIZ_ID";
            fieldILK_GIDERLER_DOVIZ_ID.Visible = false;

            PivotGridField fieldILK_GIDERLER = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILK_GIDERLER.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILK_GIDERLER.AreaIndex = 95;
            fieldILK_GIDERLER.FieldName = "ILK_GIDERLER";
            fieldILK_GIDERLER.Name = "fieldILK_GIDERLER";
            fieldILK_GIDERLER.Visible = false;

            PivotGridField fieldPESIN_HARC_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPESIN_HARC_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPESIN_HARC_DOVIZ_ID.AreaIndex = 96;
            fieldPESIN_HARC_DOVIZ_ID.FieldName = "PESIN_HARC_DOVIZ_ID";
            fieldPESIN_HARC_DOVIZ_ID.Name = "fieldPESIN_HARC_DOVIZ_ID";
            fieldPESIN_HARC_DOVIZ_ID.Visible = false;

            PivotGridField fieldPESIN_HARC = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPESIN_HARC.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPESIN_HARC.AreaIndex = 97;
            fieldPESIN_HARC.FieldName = "PESIN_HARC";
            fieldPESIN_HARC.Name = "fieldPESIN_HARC";
            fieldPESIN_HARC.Visible = false;

            PivotGridField fieldODENEN_TAHSIL_HARCI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODENEN_TAHSIL_HARCI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODENEN_TAHSIL_HARCI_DOVIZ_ID.AreaIndex = 98;
            fieldODENEN_TAHSIL_HARCI_DOVIZ_ID.FieldName = "ODENEN_TAHSIL_HARCI_DOVIZ_ID";
            fieldODENEN_TAHSIL_HARCI_DOVIZ_ID.Name = "fieldODENEN_TAHSIL_HARCI_DOVIZ_ID";
            fieldODENEN_TAHSIL_HARCI_DOVIZ_ID.Visible = false;

            PivotGridField fieldODENEN_TAHSIL_HARCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODENEN_TAHSIL_HARCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODENEN_TAHSIL_HARCI.AreaIndex = 99;
            fieldODENEN_TAHSIL_HARCI.FieldName = "ODENEN_TAHSIL_HARCI";
            fieldODENEN_TAHSIL_HARCI.Name = "fieldODENEN_TAHSIL_HARCI";
            fieldODENEN_TAHSIL_HARCI.Visible = false;

            PivotGridField fieldKALAN_TAHSIL_HARCI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_TAHSIL_HARCI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_TAHSIL_HARCI_DOVIZ_ID.AreaIndex = 100;
            fieldKALAN_TAHSIL_HARCI_DOVIZ_ID.FieldName = "KALAN_TAHSIL_HARCI_DOVIZ_ID";
            fieldKALAN_TAHSIL_HARCI_DOVIZ_ID.Name = "fieldKALAN_TAHSIL_HARCI_DOVIZ_ID";
            fieldKALAN_TAHSIL_HARCI_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_TAHSIL_HARCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_TAHSIL_HARCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_TAHSIL_HARCI.AreaIndex = 101;
            fieldKALAN_TAHSIL_HARCI.FieldName = "KALAN_TAHSIL_HARCI";
            fieldKALAN_TAHSIL_HARCI.Name = "fieldKALAN_TAHSIL_HARCI";
            fieldKALAN_TAHSIL_HARCI.Visible = false;

            PivotGridField fieldMASAYA_KATILMA_HARCI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASAYA_KATILMA_HARCI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMASAYA_KATILMA_HARCI_DOVIZ_ID.AreaIndex = 102;
            fieldMASAYA_KATILMA_HARCI_DOVIZ_ID.FieldName = "MASAYA_KATILMA_HARCI_DOVIZ_ID";
            fieldMASAYA_KATILMA_HARCI_DOVIZ_ID.Name = "fieldMASAYA_KATILMA_HARCI_DOVIZ_ID";
            fieldMASAYA_KATILMA_HARCI_DOVIZ_ID.Visible = false;

            PivotGridField fieldMASAYA_KATILMA_HARCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASAYA_KATILMA_HARCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMASAYA_KATILMA_HARCI.AreaIndex = 103;
            fieldMASAYA_KATILMA_HARCI.FieldName = "MASAYA_KATILMA_HARCI";
            fieldMASAYA_KATILMA_HARCI.Name = "fieldMASAYA_KATILMA_HARCI";
            fieldMASAYA_KATILMA_HARCI.Visible = false;

            PivotGridField fieldPAYLASMA_HARCI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPAYLASMA_HARCI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPAYLASMA_HARCI_DOVIZ_ID.AreaIndex = 104;
            fieldPAYLASMA_HARCI_DOVIZ_ID.FieldName = "PAYLASMA_HARCI_DOVIZ_ID";
            fieldPAYLASMA_HARCI_DOVIZ_ID.Name = "fieldPAYLASMA_HARCI_DOVIZ_ID";
            fieldPAYLASMA_HARCI_DOVIZ_ID.Visible = false;

            PivotGridField fieldPAYLASMA_HARCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPAYLASMA_HARCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPAYLASMA_HARCI.AreaIndex = 105;
            fieldPAYLASMA_HARCI.FieldName = "PAYLASMA_HARCI";
            fieldPAYLASMA_HARCI.Name = "fieldPAYLASMA_HARCI";
            fieldPAYLASMA_HARCI.Visible = false;

            PivotGridField fieldDAVA_GIDERLERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_GIDERLERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_GIDERLERI_DOVIZ_ID.AreaIndex = 106;
            fieldDAVA_GIDERLERI_DOVIZ_ID.FieldName = "DAVA_GIDERLERI_DOVIZ_ID";
            fieldDAVA_GIDERLERI_DOVIZ_ID.Name = "fieldDAVA_GIDERLERI_DOVIZ_ID";
            fieldDAVA_GIDERLERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldDAVA_GIDERLERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_GIDERLERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_GIDERLERI.AreaIndex = 107;
            fieldDAVA_GIDERLERI.FieldName = "DAVA_GIDERLERI";
            fieldDAVA_GIDERLERI.Name = "fieldDAVA_GIDERLERI";
            fieldDAVA_GIDERLERI.Visible = false;

            PivotGridField fieldDIGER_GIDERLER_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDIGER_GIDERLER_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDIGER_GIDERLER_DOVIZ_ID.AreaIndex = 108;
            fieldDIGER_GIDERLER_DOVIZ_ID.FieldName = "DIGER_GIDERLER_DOVIZ_ID";
            fieldDIGER_GIDERLER_DOVIZ_ID.Name = "fieldDIGER_GIDERLER_DOVIZ_ID";
            fieldDIGER_GIDERLER_DOVIZ_ID.Visible = false;

            PivotGridField fieldDIGER_GIDERLER = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDIGER_GIDERLER.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDIGER_GIDERLER.AreaIndex = 109;
            fieldDIGER_GIDERLER.FieldName = "DIGER_GIDERLER";
            fieldDIGER_GIDERLER.Name = "fieldDIGER_GIDERLER";
            fieldDIGER_GIDERLER.Visible = false;

            PivotGridField fieldTAKIP_VEKALET_UCRETI_KATSAYI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_VEKALET_UCRETI_KATSAYI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_VEKALET_UCRETI_KATSAYI.AreaIndex = 110;
            fieldTAKIP_VEKALET_UCRETI_KATSAYI.FieldName = "TAKIP_VEKALET_UCRETI_KATSAYI";
            fieldTAKIP_VEKALET_UCRETI_KATSAYI.Name = "fieldTAKIP_VEKALET_UCRETI_KATSAYI";
            fieldTAKIP_VEKALET_UCRETI_KATSAYI.Visible = false;

            PivotGridField fieldTAKIP_VEKALET_UCRETI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_VEKALET_UCRETI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_VEKALET_UCRETI_DOVIZ_ID.AreaIndex = 111;
            fieldTAKIP_VEKALET_UCRETI_DOVIZ_ID.FieldName = "TAKIP_VEKALET_UCRETI_DOVIZ_ID";
            fieldTAKIP_VEKALET_UCRETI_DOVIZ_ID.Name = "fieldTAKIP_VEKALET_UCRETI_DOVIZ_ID";
            fieldTAKIP_VEKALET_UCRETI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTAKIP_VEKALET_UCRETI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_VEKALET_UCRETI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_VEKALET_UCRETI.AreaIndex = 112;
            fieldTAKIP_VEKALET_UCRETI.FieldName = "TAKIP_VEKALET_UCRETI";
            fieldTAKIP_VEKALET_UCRETI.Name = "fieldTAKIP_VEKALET_UCRETI";
            fieldTAKIP_VEKALET_UCRETI.Visible = false;

            PivotGridField fieldDAVA_INKAR_TAZMINATI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_INKAR_TAZMINATI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_INKAR_TAZMINATI_DOVIZ_ID.AreaIndex = 113;
            fieldDAVA_INKAR_TAZMINATI_DOVIZ_ID.FieldName = "DAVA_INKAR_TAZMINATI_DOVIZ_ID";
            fieldDAVA_INKAR_TAZMINATI_DOVIZ_ID.Name = "fieldDAVA_INKAR_TAZMINATI_DOVIZ_ID";
            fieldDAVA_INKAR_TAZMINATI_DOVIZ_ID.Visible = false;

            PivotGridField fieldDAVA_INKAR_TAZMINATI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_INKAR_TAZMINATI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_INKAR_TAZMINATI.AreaIndex = 114;
            fieldDAVA_INKAR_TAZMINATI.FieldName = "DAVA_INKAR_TAZMINATI";
            fieldDAVA_INKAR_TAZMINATI.Name = "fieldDAVA_INKAR_TAZMINATI";
            fieldDAVA_INKAR_TAZMINATI.Visible = false;

            PivotGridField fieldDAVA_VEKALET_UCRETI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_VEKALET_UCRETI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_VEKALET_UCRETI_DOVIZ_ID.AreaIndex = 115;
            fieldDAVA_VEKALET_UCRETI_DOVIZ_ID.FieldName = "DAVA_VEKALET_UCRETI_DOVIZ_ID";
            fieldDAVA_VEKALET_UCRETI_DOVIZ_ID.Name = "fieldDAVA_VEKALET_UCRETI_DOVIZ_ID";
            fieldDAVA_VEKALET_UCRETI_DOVIZ_ID.Visible = false;

            PivotGridField fieldDAVA_VEKALET_UCRETI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_VEKALET_UCRETI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_VEKALET_UCRETI.AreaIndex = 116;
            fieldDAVA_VEKALET_UCRETI.FieldName = "DAVA_VEKALET_UCRETI";
            fieldDAVA_VEKALET_UCRETI.Name = "fieldDAVA_VEKALET_UCRETI";
            fieldDAVA_VEKALET_UCRETI.Visible = false;

            PivotGridField fieldODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 117;
            fieldODEME_TOPLAMI_DOVIZ_ID.FieldName = "ODEME_TOPLAMI_DOVIZ_ID";
            fieldODEME_TOPLAMI_DOVIZ_ID.Name = "fieldODEME_TOPLAMI_DOVIZ_ID";
            fieldODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TOPLAMI.AreaIndex = 118;
            fieldODEME_TOPLAMI.FieldName = "ODEME_TOPLAMI";
            fieldODEME_TOPLAMI.Name = "fieldODEME_TOPLAMI";
            fieldODEME_TOPLAMI.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 119;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI.AreaIndex = 120;
            fieldTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Name = "fieldTO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Visible = false;

            PivotGridField fieldMAHSUP_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMAHSUP_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMAHSUP_TOPLAMI_DOVIZ_ID.AreaIndex = 121;
            fieldMAHSUP_TOPLAMI_DOVIZ_ID.FieldName = "MAHSUP_TOPLAMI_DOVIZ_ID";
            fieldMAHSUP_TOPLAMI_DOVIZ_ID.Name = "fieldMAHSUP_TOPLAMI_DOVIZ_ID";
            fieldMAHSUP_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldMAHSUP_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMAHSUP_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMAHSUP_TOPLAMI.AreaIndex = 122;
            fieldMAHSUP_TOPLAMI.FieldName = "MAHSUP_TOPLAMI";
            fieldMAHSUP_TOPLAMI.Name = "fieldMAHSUP_TOPLAMI";
            fieldMAHSUP_TOPLAMI.Visible = false;

            PivotGridField fieldFERAGAT_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFERAGAT_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFERAGAT_TOPLAMI.AreaIndex = 123;
            fieldFERAGAT_TOPLAMI.FieldName = "FERAGAT_TOPLAMI";
            fieldFERAGAT_TOPLAMI.Name = "fieldFERAGAT_TOPLAMI";
            fieldFERAGAT_TOPLAMI.Visible = false;

            PivotGridField fieldFERAGAT_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFERAGAT_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFERAGAT_TOPLAMI_DOVIZ_ID.AreaIndex = 124;
            fieldFERAGAT_TOPLAMI_DOVIZ_ID.FieldName = "FERAGAT_TOPLAMI_DOVIZ_ID";
            fieldFERAGAT_TOPLAMI_DOVIZ_ID.Name = "fieldFERAGAT_TOPLAMI_DOVIZ_ID";
            fieldFERAGAT_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldALACAK_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALACAK_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldALACAK_TOPLAMI_DOVIZ_ID.AreaIndex = 125;
            fieldALACAK_TOPLAMI_DOVIZ_ID.FieldName = "ALACAK_TOPLAMI_DOVIZ_ID";
            fieldALACAK_TOPLAMI_DOVIZ_ID.Name = "fieldALACAK_TOPLAMI_DOVIZ_ID";
            fieldALACAK_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldALACAK_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALACAK_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldALACAK_TOPLAMI.AreaIndex = 126;
            fieldALACAK_TOPLAMI.FieldName = "ALACAK_TOPLAMI";
            fieldALACAK_TOPLAMI.Name = "fieldALACAK_TOPLAMI";
            fieldALACAK_TOPLAMI.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 127;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 128;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldTAHLIYE_VEK_UCR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHLIYE_VEK_UCR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHLIYE_VEK_UCR_DOVIZ_ID.AreaIndex = 129;
            fieldTAHLIYE_VEK_UCR_DOVIZ_ID.FieldName = "TAHLIYE_VEK_UCR_DOVIZ_ID";
            fieldTAHLIYE_VEK_UCR_DOVIZ_ID.Name = "fieldTAHLIYE_VEK_UCR_DOVIZ_ID";
            fieldTAHLIYE_VEK_UCR_DOVIZ_ID.Visible = false;

            PivotGridField fieldTAHLIYE_VEK_UCR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHLIYE_VEK_UCR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHLIYE_VEK_UCR.AreaIndex = 130;
            fieldTAHLIYE_VEK_UCR.FieldName = "TAHLIYE_VEK_UCR";
            fieldTAHLIYE_VEK_UCR.Name = "fieldTAHLIYE_VEK_UCR";
            fieldTAHLIYE_VEK_UCR.Visible = false;

            PivotGridField fieldDIGER_HARC_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDIGER_HARC_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDIGER_HARC_DOVIZ_ID.AreaIndex = 131;
            fieldDIGER_HARC_DOVIZ_ID.FieldName = "DIGER_HARC_DOVIZ_ID";
            fieldDIGER_HARC_DOVIZ_ID.Name = "fieldDIGER_HARC_DOVIZ_ID";
            fieldDIGER_HARC_DOVIZ_ID.Visible = false;

            PivotGridField fieldDIGER_HARC = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDIGER_HARC.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDIGER_HARC.AreaIndex = 132;
            fieldDIGER_HARC.FieldName = "DIGER_HARC";
            fieldDIGER_HARC.Name = "fieldDIGER_HARC";
            fieldDIGER_HARC.Visible = false;

            PivotGridField fieldTD_GIDERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTD_GIDERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTD_GIDERI_DOVIZ_ID.AreaIndex = 133;
            fieldTD_GIDERI_DOVIZ_ID.FieldName = "TD_GIDERI_DOVIZ_ID";
            fieldTD_GIDERI_DOVIZ_ID.Name = "fieldTD_GIDERI_DOVIZ_ID";
            fieldTD_GIDERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTD_GIDERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTD_GIDERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTD_GIDERI.AreaIndex = 134;
            fieldTD_GIDERI.FieldName = "TD_GIDERI";
            fieldTD_GIDERI.Name = "fieldTD_GIDERI";
            fieldTD_GIDERI.Visible = false;

            PivotGridField fieldTD_BAKIYE_HARC_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTD_BAKIYE_HARC_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTD_BAKIYE_HARC_DOVIZ_ID.AreaIndex = 135;
            fieldTD_BAKIYE_HARC_DOVIZ_ID.FieldName = "TD_BAKIYE_HARC_DOVIZ_ID";
            fieldTD_BAKIYE_HARC_DOVIZ_ID.Name = "fieldTD_BAKIYE_HARC_DOVIZ_ID";
            fieldTD_BAKIYE_HARC_DOVIZ_ID.Visible = false;

            PivotGridField fieldTD_BAKIYE_HARC = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTD_BAKIYE_HARC.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTD_BAKIYE_HARC.AreaIndex = 136;
            fieldTD_BAKIYE_HARC.FieldName = "TD_BAKIYE_HARC";
            fieldTD_BAKIYE_HARC.Name = "fieldTD_BAKIYE_HARC";
            fieldTD_BAKIYE_HARC.Visible = false;

            PivotGridField fieldTD_VEK_UCR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTD_VEK_UCR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTD_VEK_UCR_DOVIZ_ID.AreaIndex = 137;
            fieldTD_VEK_UCR_DOVIZ_ID.FieldName = "TD_VEK_UCR_DOVIZ_ID";
            fieldTD_VEK_UCR_DOVIZ_ID.Name = "fieldTD_VEK_UCR_DOVIZ_ID";
            fieldTD_VEK_UCR_DOVIZ_ID.Visible = false;

            PivotGridField fieldTD_VEK_UCR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTD_VEK_UCR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTD_VEK_UCR.AreaIndex = 138;
            fieldTD_VEK_UCR.FieldName = "TD_VEK_UCR";
            fieldTD_VEK_UCR.Name = "fieldTD_VEK_UCR";
            fieldTD_VEK_UCR.Visible = false;

            PivotGridField fieldTD_TEBLIG_GIDERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTD_TEBLIG_GIDERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTD_TEBLIG_GIDERI_DOVIZ_ID.AreaIndex = 139;
            fieldTD_TEBLIG_GIDERI_DOVIZ_ID.FieldName = "TD_TEBLIG_GIDERI_DOVIZ_ID";
            fieldTD_TEBLIG_GIDERI_DOVIZ_ID.Name = "fieldTD_TEBLIG_GIDERI_DOVIZ_ID";
            fieldTD_TEBLIG_GIDERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTD_TEBLIG_GIDERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTD_TEBLIG_GIDERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTD_TEBLIG_GIDERI.AreaIndex = 140;
            fieldTD_TEBLIG_GIDERI.FieldName = "TD_TEBLIG_GIDERI";
            fieldTD_TEBLIG_GIDERI.Name = "fieldTD_TEBLIG_GIDERI";
            fieldTD_TEBLIG_GIDERI.Visible = false;

            PivotGridField fieldBIRIKMIS_NAFAKA_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIKMIS_NAFAKA_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIKMIS_NAFAKA_DOVIZ_ID.AreaIndex = 141;
            fieldBIRIKMIS_NAFAKA_DOVIZ_ID.FieldName = "BIRIKMIS_NAFAKA_DOVIZ_ID";
            fieldBIRIKMIS_NAFAKA_DOVIZ_ID.Name = "fieldBIRIKMIS_NAFAKA_DOVIZ_ID";
            fieldBIRIKMIS_NAFAKA_DOVIZ_ID.Visible = false;

            PivotGridField fieldBIRIKMIS_NAFAKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIKMIS_NAFAKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIKMIS_NAFAKA.AreaIndex = 142;
            fieldBIRIKMIS_NAFAKA.FieldName = "BIRIKMIS_NAFAKA";
            fieldBIRIKMIS_NAFAKA.Name = "fieldBIRIKMIS_NAFAKA";
            fieldBIRIKMIS_NAFAKA.Visible = false;

            PivotGridField fieldICRA_INKAR_TAZMINATI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_INKAR_TAZMINATI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_INKAR_TAZMINATI_DOVIZ_ID.AreaIndex = 143;
            fieldICRA_INKAR_TAZMINATI_DOVIZ_ID.FieldName = "ICRA_INKAR_TAZMINATI_DOVIZ_ID";
            fieldICRA_INKAR_TAZMINATI_DOVIZ_ID.Name = "fieldICRA_INKAR_TAZMINATI_DOVIZ_ID";
            fieldICRA_INKAR_TAZMINATI_DOVIZ_ID.Visible = false;

            PivotGridField fieldICRA_INKAR_TAZMINATI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_INKAR_TAZMINATI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_INKAR_TAZMINATI.AreaIndex = 144;
            fieldICRA_INKAR_TAZMINATI.FieldName = "ICRA_INKAR_TAZMINATI";
            fieldICRA_INKAR_TAZMINATI.Name = "fieldICRA_INKAR_TAZMINATI";
            fieldICRA_INKAR_TAZMINATI.Visible = false;

            PivotGridField fieldDAMGA_PULU_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAMGA_PULU_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAMGA_PULU_DOVIZ_ID.AreaIndex = 145;
            fieldDAMGA_PULU_DOVIZ_ID.FieldName = "DAMGA_PULU_DOVIZ_ID";
            fieldDAMGA_PULU_DOVIZ_ID.Name = "fieldDAMGA_PULU_DOVIZ_ID";
            fieldDAMGA_PULU_DOVIZ_ID.Visible = false;

            PivotGridField fieldDAMGA_PULU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAMGA_PULU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAMGA_PULU.AreaIndex = 146;
            fieldDAMGA_PULU.FieldName = "DAMGA_PULU";
            fieldDAMGA_PULU.Name = "fieldDAMGA_PULU";
            fieldDAMGA_PULU.Visible = false;

            PivotGridField fieldACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldACIKLAMA.AreaIndex = 147;
            fieldACIKLAMA.FieldName = "ACIKLAMA";
            fieldACIKLAMA.Name = "fieldACIKLAMA";
            fieldACIKLAMA.Visible = false;

            PivotGridField fieldPROTOKOL_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROTOKOL_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROTOKOL_MIKTARI_DOVIZ_ID.AreaIndex = 148;
            fieldPROTOKOL_MIKTARI_DOVIZ_ID.FieldName = "PROTOKOL_MIKTARI_DOVIZ_ID";
            fieldPROTOKOL_MIKTARI_DOVIZ_ID.Name = "fieldPROTOKOL_MIKTARI_DOVIZ_ID";
            fieldPROTOKOL_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldPROTOKOL_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROTOKOL_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROTOKOL_MIKTARI.AreaIndex = 149;
            fieldPROTOKOL_MIKTARI.FieldName = "PROTOKOL_MIKTARI";
            fieldPROTOKOL_MIKTARI.Name = "fieldPROTOKOL_MIKTARI";
            fieldPROTOKOL_MIKTARI.Visible = false;

            PivotGridField fieldPROTOKOL_FAIZ_ORANI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROTOKOL_FAIZ_ORANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROTOKOL_FAIZ_ORANI.AreaIndex = 150;
            fieldPROTOKOL_FAIZ_ORANI.FieldName = "PROTOKOL_FAIZ_ORANI";
            fieldPROTOKOL_FAIZ_ORANI.Name = "fieldPROTOKOL_FAIZ_ORANI";
            fieldPROTOKOL_FAIZ_ORANI.Visible = false;

            PivotGridField fieldPROTOKOL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROTOKOL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROTOKOL_TARIHI.AreaIndex = 151;
            fieldPROTOKOL_TARIHI.FieldName = "PROTOKOL_TARIHI";
            fieldPROTOKOL_TARIHI.Name = "fieldPROTOKOL_TARIHI";
            fieldPROTOKOL_TARIHI.Visible = false;

            PivotGridField fieldKARSILIK_TUTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKARSILIK_TUTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKARSILIK_TUTARI_DOVIZ_ID.AreaIndex = 152;
            fieldKARSILIK_TUTARI_DOVIZ_ID.FieldName = "KARSILIK_TUTARI_DOVIZ_ID";
            fieldKARSILIK_TUTARI_DOVIZ_ID.Name = "fieldKARSILIK_TUTARI_DOVIZ_ID";
            fieldKARSILIK_TUTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldKARSILIK_TUTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKARSILIK_TUTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKARSILIK_TUTARI.AreaIndex = 153;
            fieldKARSILIK_TUTARI.FieldName = "KARSILIK_TUTARI";
            fieldKARSILIK_TUTARI.Name = "fieldKARSILIK_TUTARI";
            fieldKARSILIK_TUTARI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI.AreaIndex = 154;
            fieldTO_MASRAF_TOPLAMI.FieldName = "TO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Name = "fieldTO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 155;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI.AreaIndex = 156;
            fieldTS_MASRAF_TOPLAMI.FieldName = "TS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Name = "fieldTS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 157;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI.AreaIndex = 158;
            fieldTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Name = "fieldTUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 159;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldHARC_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHARC_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHARC_TOPLAMI.AreaIndex = 160;
            fieldHARC_TOPLAMI.FieldName = "HARC_TOPLAMI";
            fieldHARC_TOPLAMI.Name = "fieldHARC_TOPLAMI";
            fieldHARC_TOPLAMI.Visible = false;

            PivotGridField fieldHARC_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHARC_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHARC_TOPLAMI_DOVIZ_ID.AreaIndex = 161;
            fieldHARC_TOPLAMI_DOVIZ_ID.FieldName = "HARC_TOPLAMI_DOVIZ_ID";
            fieldHARC_TOPLAMI_DOVIZ_ID.Name = "fieldHARC_TOPLAMI_DOVIZ_ID";
            fieldHARC_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_VEKALET_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_VEKALET_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_VEKALET_TOPLAMI_DOVIZ_ID.AreaIndex = 162;
            fieldTO_VEKALET_TOPLAMI_DOVIZ_ID.FieldName = "TO_VEKALET_TOPLAMI_DOVIZ_ID";
            fieldTO_VEKALET_TOPLAMI_DOVIZ_ID.Name = "fieldTO_VEKALET_TOPLAMI_DOVIZ_ID";
            fieldTO_VEKALET_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_VEKALET_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_VEKALET_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_VEKALET_TOPLAMI.AreaIndex = 163;
            fieldTO_VEKALET_TOPLAMI.FieldName = "TO_VEKALET_TOPLAMI";
            fieldTO_VEKALET_TOPLAMI.Name = "fieldTO_VEKALET_TOPLAMI";
            fieldTO_VEKALET_TOPLAMI.Visible = false;

            PivotGridField fieldTS_VEKALET_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_VEKALET_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_VEKALET_TOPLAMI.AreaIndex = 164;
            fieldTS_VEKALET_TOPLAMI.FieldName = "TS_VEKALET_TOPLAMI";
            fieldTS_VEKALET_TOPLAMI.Name = "fieldTS_VEKALET_TOPLAMI";
            fieldTS_VEKALET_TOPLAMI.Visible = false;

            PivotGridField fieldTS_VEKALET_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_VEKALET_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_VEKALET_TOPLAMI_DOVIZ_ID.AreaIndex = 165;
            fieldTS_VEKALET_TOPLAMI_DOVIZ_ID.FieldName = "TS_VEKALET_TOPLAMI_DOVIZ_ID";
            fieldTS_VEKALET_TOPLAMI_DOVIZ_ID.Name = "fieldTS_VEKALET_TOPLAMI_DOVIZ_ID";
            fieldTS_VEKALET_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_VEKALET_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_VEKALET_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_VEKALET_TOPLAMI.AreaIndex = 166;
            fieldTUM_VEKALET_TOPLAMI.FieldName = "TUM_VEKALET_TOPLAMI";
            fieldTUM_VEKALET_TOPLAMI.Name = "fieldTUM_VEKALET_TOPLAMI";
            fieldTUM_VEKALET_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID.AreaIndex = 167;
            fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID.FieldName = "TUM_VEKALET_TOPLAMI_DOVIZ_ID";
            fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID";
            fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldKARSI_VEKALET_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKARSI_VEKALET_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKARSI_VEKALET_TOPLAMI.AreaIndex = 168;
            fieldKARSI_VEKALET_TOPLAMI.FieldName = "KARSI_VEKALET_TOPLAMI";
            fieldKARSI_VEKALET_TOPLAMI.Name = "fieldKARSI_VEKALET_TOPLAMI";
            fieldKARSI_VEKALET_TOPLAMI.Visible = false;

            PivotGridField fieldKARSI_VEKALET_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKARSI_VEKALET_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKARSI_VEKALET_TOPLAMI_DOVIZ_ID.AreaIndex = 169;
            fieldKARSI_VEKALET_TOPLAMI_DOVIZ_ID.FieldName = "KARSI_VEKALET_TOPLAMI_DOVIZ_ID";
            fieldKARSI_VEKALET_TOPLAMI_DOVIZ_ID.Name = "fieldKARSI_VEKALET_TOPLAMI_DOVIZ_ID";
            fieldKARSI_VEKALET_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldFAIZ_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFAIZ_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFAIZ_TOPLAMI.AreaIndex = 170;
            fieldFAIZ_TOPLAMI.FieldName = "FAIZ_TOPLAMI";
            fieldFAIZ_TOPLAMI.Name = "fieldFAIZ_TOPLAMI";
            fieldFAIZ_TOPLAMI.Visible = false;

            PivotGridField fieldFAIZ_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFAIZ_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFAIZ_TOPLAMI_DOVIZ_ID.AreaIndex = 171;
            fieldFAIZ_TOPLAMI_DOVIZ_ID.FieldName = "FAIZ_TOPLAMI_DOVIZ_ID";
            fieldFAIZ_TOPLAMI_DOVIZ_ID.Name = "fieldFAIZ_TOPLAMI_DOVIZ_ID";
            fieldFAIZ_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldILAM_UCRETLER_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_UCRETLER_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_UCRETLER_TOPLAMI.AreaIndex = 172;
            fieldILAM_UCRETLER_TOPLAMI.FieldName = "ILAM_UCRETLER_TOPLAMI";
            fieldILAM_UCRETLER_TOPLAMI.Name = "fieldILAM_UCRETLER_TOPLAMI";
            fieldILAM_UCRETLER_TOPLAMI.Visible = false;

            PivotGridField fieldILAM_UCRETLER_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_UCRETLER_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_UCRETLER_TOPLAMI_DOVIZ_ID.AreaIndex = 173;
            fieldILAM_UCRETLER_TOPLAMI_DOVIZ_ID.FieldName = "ILAM_UCRETLER_TOPLAMI_DOVIZ_ID";
            fieldILAM_UCRETLER_TOPLAMI_DOVIZ_ID.Name = "fieldILAM_UCRETLER_TOPLAMI_DOVIZ_ID";
            fieldILAM_UCRETLER_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldIT_VEKALET_UCRETI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIT_VEKALET_UCRETI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIT_VEKALET_UCRETI_DOVIZ_ID.AreaIndex = 174;
            fieldIT_VEKALET_UCRETI_DOVIZ_ID.FieldName = "IT_VEKALET_UCRETI_DOVIZ_ID";
            fieldIT_VEKALET_UCRETI_DOVIZ_ID.Name = "fieldIT_VEKALET_UCRETI_DOVIZ_ID";
            fieldIT_VEKALET_UCRETI_DOVIZ_ID.Visible = false;

            PivotGridField fieldIT_VEKALET_UCRETI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIT_VEKALET_UCRETI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIT_VEKALET_UCRETI.AreaIndex = 175;
            fieldIT_VEKALET_UCRETI.FieldName = "IT_VEKALET_UCRETI";
            fieldIT_VEKALET_UCRETI.Name = "fieldIT_VEKALET_UCRETI";
            fieldIT_VEKALET_UCRETI.Visible = false;

            PivotGridField fieldIT_GIDERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIT_GIDERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIT_GIDERI_DOVIZ_ID.AreaIndex = 176;
            fieldIT_GIDERI_DOVIZ_ID.FieldName = "IT_GIDERI_DOVIZ_ID";
            fieldIT_GIDERI_DOVIZ_ID.Name = "fieldIT_GIDERI_DOVIZ_ID";
            fieldIT_GIDERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldIT_GIDERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIT_GIDERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIT_GIDERI.AreaIndex = 177;
            fieldIT_GIDERI.FieldName = "IT_GIDERI";
            fieldIT_GIDERI.Name = "fieldIT_GIDERI";
            fieldIT_GIDERI.Visible = false;

            PivotGridField fieldTO_ODEME_MAHSUP_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_MAHSUP_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_MAHSUP_TOPLAMI.AreaIndex = 178;
            fieldTO_ODEME_MAHSUP_TOPLAMI.FieldName = "TO_ODEME_MAHSUP_TOPLAMI";
            fieldTO_ODEME_MAHSUP_TOPLAMI.Name = "fieldTO_ODEME_MAHSUP_TOPLAMI";
            fieldTO_ODEME_MAHSUP_TOPLAMI.Visible = false;

            PivotGridField fieldTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID.AreaIndex = 179;
            fieldTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldPAYLASIM_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPAYLASIM_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPAYLASIM_TIPI.AreaIndex = 180;
            fieldPAYLASIM_TIPI.FieldName = "PAYLASIM_TIPI";
            fieldPAYLASIM_TIPI.Name = "fieldPAYLASIM_TIPI";
            fieldPAYLASIM_TIPI.Visible = false;

            PivotGridField fieldTS_HESAP_TIP_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_HESAP_TIP_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_HESAP_TIP_ID.AreaIndex = 181;
            fieldTS_HESAP_TIP_ID.FieldName = "TS_HESAP_TIP_ID";
            fieldTS_HESAP_TIP_ID.Name = "fieldTS_HESAP_TIP_ID";
            fieldTS_HESAP_TIP_ID.Visible = false;

            PivotGridField fieldTS_HESAP_TIP_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_HESAP_TIP_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_HESAP_TIP_ADI.AreaIndex = 182;
            fieldTS_HESAP_TIP_ADI.FieldName = "TS_HESAP_TIP_ADI";
            fieldTS_HESAP_TIP_ADI.Name = "fieldTS_HESAP_TIP_ADI";
            fieldTS_HESAP_TIP_ADI.Visible = false;

            PivotGridField fieldTO_HESAP_TIP_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_HESAP_TIP_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_HESAP_TIP_ID.AreaIndex = 183;
            fieldTO_HESAP_TIP_ID.FieldName = "TO_HESAP_TIP_ID";
            fieldTO_HESAP_TIP_ID.Name = "fieldTO_HESAP_TIP_ID";
            fieldTO_HESAP_TIP_ID.Visible = false;

            PivotGridField fieldTO_HESAP_TIP_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_HESAP_TIP_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_HESAP_TIP_ADI.AreaIndex = 184;
            fieldTO_HESAP_TIP_ADI.FieldName = "TO_HESAP_TIP_ADI";
            fieldTO_HESAP_TIP_ADI.Name = "fieldTO_HESAP_TIP_ADI";
            fieldTO_HESAP_TIP_ADI.Visible = false;

            PivotGridField fieldBASVURMA_HARCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBASVURMA_HARCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBASVURMA_HARCI.AreaIndex = 185;
            fieldBASVURMA_HARCI.FieldName = "BASVURMA_HARCI";
            fieldBASVURMA_HARCI.Name = "fieldBASVURMA_HARCI";
            fieldBASVURMA_HARCI.Visible = false;

            PivotGridField fieldBASVURMA_HARCI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBASVURMA_HARCI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBASVURMA_HARCI_DOVIZ_ID.AreaIndex = 186;
            fieldBASVURMA_HARCI_DOVIZ_ID.FieldName = "BASVURMA_HARCI_DOVIZ_ID";
            fieldBASVURMA_HARCI_DOVIZ_ID.Name = "fieldBASVURMA_HARCI_DOVIZ_ID";
            fieldBASVURMA_HARCI_DOVIZ_ID.Visible = false;

            PivotGridField fieldVEKALET_HARCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldVEKALET_HARCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldVEKALET_HARCI.AreaIndex = 187;
            fieldVEKALET_HARCI.FieldName = "VEKALET_HARCI";
            fieldVEKALET_HARCI.Name = "fieldVEKALET_HARCI";
            fieldVEKALET_HARCI.Visible = false;

            PivotGridField fieldVEKALET_HARCI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldVEKALET_HARCI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldVEKALET_HARCI_DOVIZ_ID.AreaIndex = 188;
            fieldVEKALET_HARCI_DOVIZ_ID.FieldName = "VEKALET_HARCI_DOVIZ_ID";
            fieldVEKALET_HARCI_DOVIZ_ID.Name = "fieldVEKALET_HARCI_DOVIZ_ID";
            fieldVEKALET_HARCI_DOVIZ_ID.Visible = false;

            PivotGridField fieldVEKALET_PULU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldVEKALET_PULU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldVEKALET_PULU.AreaIndex = 189;
            fieldVEKALET_PULU.FieldName = "VEKALET_PULU";
            fieldVEKALET_PULU.Name = "fieldVEKALET_PULU";
            fieldVEKALET_PULU.Visible = false;

            PivotGridField fieldVEKALET_PULU_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldVEKALET_PULU_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldVEKALET_PULU_DOVIZ_ID.AreaIndex = 190;
            fieldVEKALET_PULU_DOVIZ_ID.FieldName = "VEKALET_PULU_DOVIZ_ID";
            fieldVEKALET_PULU_DOVIZ_ID.Name = "fieldVEKALET_PULU_DOVIZ_ID";
            fieldVEKALET_PULU_DOVIZ_ID.Visible = false;

            PivotGridField fieldIFLAS_BASVURMA_HARCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIFLAS_BASVURMA_HARCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIFLAS_BASVURMA_HARCI.AreaIndex = 191;
            fieldIFLAS_BASVURMA_HARCI.FieldName = "IFLAS_BASVURMA_HARCI";
            fieldIFLAS_BASVURMA_HARCI.Name = "fieldIFLAS_BASVURMA_HARCI";
            fieldIFLAS_BASVURMA_HARCI.Visible = false;

            PivotGridField fieldIFLAS_BASVURMA_HARCI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIFLAS_BASVURMA_HARCI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIFLAS_BASVURMA_HARCI_DOVIZ_ID.AreaIndex = 192;
            fieldIFLAS_BASVURMA_HARCI_DOVIZ_ID.FieldName = "IFLAS_BASVURMA_HARCI_DOVIZ_ID";
            fieldIFLAS_BASVURMA_HARCI_DOVIZ_ID.Name = "fieldIFLAS_BASVURMA_HARCI_DOVIZ_ID";
            fieldIFLAS_BASVURMA_HARCI_DOVIZ_ID.Visible = false;

            PivotGridField fieldIFLASIN_ACILMASI_HARCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIFLASIN_ACILMASI_HARCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIFLASIN_ACILMASI_HARCI.AreaIndex = 193;
            fieldIFLASIN_ACILMASI_HARCI.FieldName = "IFLASIN_ACILMASI_HARCI";
            fieldIFLASIN_ACILMASI_HARCI.Name = "fieldIFLASIN_ACILMASI_HARCI";
            fieldIFLASIN_ACILMASI_HARCI.Visible = false;

            PivotGridField fieldIFLASIN_ACILMASI_HARCI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIFLASIN_ACILMASI_HARCI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIFLASIN_ACILMASI_HARCI_DOVIZ_ID.AreaIndex = 194;
            fieldIFLASIN_ACILMASI_HARCI_DOVIZ_ID.FieldName = "IFLASIN_ACILMASI_HARCI_DOVIZ_ID";
            fieldIFLASIN_ACILMASI_HARCI_DOVIZ_ID.Name = "fieldIFLASIN_ACILMASI_HARCI_DOVIZ_ID";
            fieldIFLASIN_ACILMASI_HARCI_DOVIZ_ID.Visible = false;

            PivotGridField fieldILK_TEBLIGAT_GIDERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILK_TEBLIGAT_GIDERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILK_TEBLIGAT_GIDERI.AreaIndex = 195;
            fieldILK_TEBLIGAT_GIDERI.FieldName = "ILK_TEBLIGAT_GIDERI";
            fieldILK_TEBLIGAT_GIDERI.Name = "fieldILK_TEBLIGAT_GIDERI";
            fieldILK_TEBLIGAT_GIDERI.Visible = false;

            PivotGridField fieldILK_TEBLIGAT_GIDERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILK_TEBLIGAT_GIDERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILK_TEBLIGAT_GIDERI_DOVIZ_ID.AreaIndex = 196;
            fieldILK_TEBLIGAT_GIDERI_DOVIZ_ID.FieldName = "ILK_TEBLIGAT_GIDERI_DOVIZ_ID";
            fieldILK_TEBLIGAT_GIDERI_DOVIZ_ID.Name = "fieldILK_TEBLIGAT_GIDERI_DOVIZ_ID";
            fieldILK_TEBLIGAT_GIDERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTAHLIYE_HARCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHLIYE_HARCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHLIYE_HARCI.AreaIndex = 197;
            fieldTAHLIYE_HARCI.FieldName = "TAHLIYE_HARCI";
            fieldTAHLIYE_HARCI.Name = "fieldTAHLIYE_HARCI";
            fieldTAHLIYE_HARCI.Visible = false;

            PivotGridField fieldTAHLIYE_HARCI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHLIYE_HARCI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHLIYE_HARCI_DOVIZ_ID.AreaIndex = 198;
            fieldTAHLIYE_HARCI_DOVIZ_ID.FieldName = "TAHLIYE_HARCI_DOVIZ_ID";
            fieldTAHLIYE_HARCI_DOVIZ_ID.Name = "fieldTAHLIYE_HARCI_DOVIZ_ID";
            fieldTAHLIYE_HARCI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTESLIM_HARCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTESLIM_HARCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTESLIM_HARCI.AreaIndex = 199;
            fieldTESLIM_HARCI.FieldName = "TESLIM_HARCI";
            fieldTESLIM_HARCI.Name = "fieldTESLIM_HARCI";
            fieldTESLIM_HARCI.Visible = false;

            PivotGridField fieldTESLIM_HARCI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTESLIM_HARCI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTESLIM_HARCI_DOVIZ_ID.AreaIndex = 200;
            fieldTESLIM_HARCI_DOVIZ_ID.FieldName = "TESLIM_HARCI_DOVIZ_ID";
            fieldTESLIM_HARCI_DOVIZ_ID.Name = "fieldTESLIM_HARCI_DOVIZ_ID";
            fieldTESLIM_HARCI_DOVIZ_ID.Visible = false;

            PivotGridField fieldFERAGAT_HARCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFERAGAT_HARCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFERAGAT_HARCI.AreaIndex = 201;
            fieldFERAGAT_HARCI.FieldName = "FERAGAT_HARCI";
            fieldFERAGAT_HARCI.Name = "fieldFERAGAT_HARCI";
            fieldFERAGAT_HARCI.Visible = false;

            PivotGridField fieldFERAGAT_HARCI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFERAGAT_HARCI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFERAGAT_HARCI_DOVIZ_ID.AreaIndex = 202;
            fieldFERAGAT_HARCI_DOVIZ_ID.FieldName = "FERAGAT_HARCI_DOVIZ_ID";
            fieldFERAGAT_HARCI_DOVIZ_ID.Name = "fieldFERAGAT_HARCI_DOVIZ_ID";
            fieldFERAGAT_HARCI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_YONETIMG_TAZMINATI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_YONETIMG_TAZMINATI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_YONETIMG_TAZMINATI_DOVIZ_ID.AreaIndex = 203;
            fieldTO_YONETIMG_TAZMINATI_DOVIZ_ID.FieldName = "TO_YONETIMG_TAZMINATI_DOVIZ_ID";
            fieldTO_YONETIMG_TAZMINATI_DOVIZ_ID.Name = "fieldTO_YONETIMG_TAZMINATI_DOVIZ_ID";
            fieldTO_YONETIMG_TAZMINATI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_YONETIMG_TAZMINATI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_YONETIMG_TAZMINATI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_YONETIMG_TAZMINATI.AreaIndex = 204;
            fieldTO_YONETIMG_TAZMINATI.FieldName = "TO_YONETIMG_TAZMINATI";
            fieldTO_YONETIMG_TAZMINATI.Name = "fieldTO_YONETIMG_TAZMINATI";
            fieldTO_YONETIMG_TAZMINATI.Visible = false;

            PivotGridField fieldASAMA_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASAMA_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASAMA_ID.AreaIndex = 205;
            fieldASAMA_ID.FieldName = "ASAMA_ID";
            fieldASAMA_ID.Name = "fieldASAMA_ID";
            fieldASAMA_ID.Visible = false;

            PivotGridField fieldASAMA_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASAMA_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASAMA_ADI.AreaIndex = 206;
            fieldASAMA_ADI.FieldName = "ASAMA_ADI";
            fieldASAMA_ADI.Name = "fieldASAMA_ADI";
            fieldASAMA_ADI.Visible = false;

            PivotGridField fieldTAKIP_TALEP_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TALEP_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_TALEP_ID.AreaIndex = 207;
            fieldTAKIP_TALEP_ID.FieldName = "TAKIP_TALEP_ID";
            fieldTAKIP_TALEP_ID.Name = "fieldTAKIP_TALEP_ID";
            fieldTAKIP_TALEP_ID.Visible = false;

            #endregion Field & Properties

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldCARI_ADI,
			fieldCARI_ID,
			fieldSORUMLU_AVUKAT_CARI_ID,
			fieldTARAF_KODU,
			fieldKOD,
			fieldTARAF_SIFAT_ID,
			fieldSIFAT,
			fieldID,
			fieldTALEP_ADI,
			fieldFORM_TIP_ID,
			fieldFORM_ADI,
			fieldFOY_DURUM_ID,
			fieldDURUM,
			fieldFOY_NO,
			fieldREFERANS_NO,
			fieldREFERANS_NO2,
			fieldREFERANS_NO3,
			fieldADLI_BIRIM_NO_ID,
			fieldNO,
			fieldADLIYE,
			fieldADLI_BIRIM_ADLIYE_ID,
			fieldICRA_OZEL_KOD1_ID,
			fieldICRA_OZEL_KOD2_ID,
			fieldICRA_OZEL_KOD3_ID,
			fieldICRA_OZEL_KOD4_ID,
			fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			fieldFOY_ARSIV_TARIHI,
			fieldFOY_INFAZ_TARIHI,
			fieldTAKIBIN_MUVEKKILE_IADE_TARIHI,
			fieldSON_HESAP_TARIHI,
			fieldBIR_YIL_KAC_GUN,
			fieldASIL_ALACAK_DOVIZ_ID,
			fieldASIL_ALACAK,
			fieldISLEMIS_FAIZ_DOVIZ_ID,
			fieldISLEMIS_FAIZ,
			fieldBSMV_TO_DOVIZ_ID,
			fieldBSMV_TO,
			fieldKKDV_TO_DOVIZ_ID,
			fieldKKDV_TO,
			fieldOIV_TO,
			fieldKDV_TO_DOVIZ_ID,
			fieldKDV_TO,
			fieldIH_VEKALET_UCRETI_DOVIZ_ID,
			fieldIH_VEKALET_UCRETI,
			fieldIH_GIDERI_DOVIZ_ID,
			fieldIH_GIDERI,
			fieldIT_HACIZDE_ODENEN_DOVIZ_ID,
			fieldIT_HACIZDE_ODENEN,
			fieldKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID,
			fieldKARSILIKSIZ_CEK_TAZMINATI,
			fieldCEK_KOMISYONU_DOVIZ_ID,
			fieldCEK_KOMISYONU,
			fieldILAM_YARGILAMA_GIDERI_DOVIZ_ID,
			fieldILAM_YARGILAMA_GIDERI,
			fieldILAM_BK_YARG_ONAMA_DOVIZ_ID,
			fieldILAM_BK_YARG_ONAMA,
			fieldILAM_TEBLIG_GIDERI_DOVIZ_ID,
			fieldILAM_TEBLIG_GIDERI,
			fieldILAM_INKAR_TAZMINATI_DOVIZ_ID,
			fieldILAM_INKAR_TAZMINATI,
			fieldILAM_VEK_UCR_DOVIZ_ID,
			fieldILAM_VEK_UCR,
			fieldOIV_TO_DOVIZ_ID,
			fieldPROTESTO_GIDERI_DOVIZ_ID,
			fieldPROTESTO_GIDERI,
			fieldIHTAR_GIDERI_DOVIZ_ID,
			fieldIHTAR_GIDERI,
			fieldOZEL_TAZMINAT_DOVIZ_ID,
			fieldOZEL_TAZMINAT,
			fieldOZEL_TUTAR1_FAIZ_ORANI,
			fieldOZEL_TUTAR1_KONU_ID,
			fieldOZEL_TUTAR1_KONU_ADI,
			fieldOZEL_TUTAR1_DOVIZ_ID,
			fieldOZEL_TUTAR1,
			fieldOZEL_TUTAR2_KONU_ID,
			fieldOZEL_TUTAR2_KONU_ADI,
			fieldOZEL_TUTAR2_DOVIZ_ID,
			fieldOZEL_TUTAR2,
			fieldOZEL_TUTAR3_KONU_ID,
			fieldOZEL_TUTAR3_KONU_ADI,
			fieldOZEL_TUTAR3_DOVIZ_ID,
			fieldOZEL_TUTAR3,
			fieldTAKIP_CIKISI_DOVIZ_ID,
			fieldTAKIP_CIKISI,
			fieldSONRAKI_FAIZ_DOVIZ_ID,
			fieldSONRAKI_FAIZ,
			fieldSONRAKI_TAZMINAT_DOVIZ_ID,
			fieldSONRAKI_TAZMINAT,
			fieldBSMV_TS_DOVIZ_ID,
			fieldBSMV_TS,
			fieldOIV_TS_DOVIZ_ID,
			fieldOIV_TS,
			fieldKDV_TS_DOVIZ_ID,
			fieldKDV_TS,
			fieldILK_GIDERLER_DOVIZ_ID,
			fieldILK_GIDERLER,
			fieldPESIN_HARC_DOVIZ_ID,
			fieldPESIN_HARC,
			fieldODENEN_TAHSIL_HARCI_DOVIZ_ID,
			fieldODENEN_TAHSIL_HARCI,
			fieldKALAN_TAHSIL_HARCI_DOVIZ_ID,
			fieldKALAN_TAHSIL_HARCI,
			fieldMASAYA_KATILMA_HARCI_DOVIZ_ID,
			fieldMASAYA_KATILMA_HARCI,
			fieldPAYLASMA_HARCI_DOVIZ_ID,
			fieldPAYLASMA_HARCI,
			fieldDAVA_GIDERLERI_DOVIZ_ID,
			fieldDAVA_GIDERLERI,
			fieldDIGER_GIDERLER_DOVIZ_ID,
			fieldDIGER_GIDERLER,
			fieldTAKIP_VEKALET_UCRETI_KATSAYI,
			fieldTAKIP_VEKALET_UCRETI_DOVIZ_ID,
			fieldTAKIP_VEKALET_UCRETI,
			fieldDAVA_INKAR_TAZMINATI_DOVIZ_ID,
			fieldDAVA_INKAR_TAZMINATI,
			fieldDAVA_VEKALET_UCRETI_DOVIZ_ID,
			fieldDAVA_VEKALET_UCRETI,
			fieldODEME_TOPLAMI_DOVIZ_ID,
			fieldODEME_TOPLAMI,
			fieldTO_ODEME_TOPLAMI_DOVIZ_ID,
			fieldTO_ODEME_TOPLAMI,
			fieldMAHSUP_TOPLAMI_DOVIZ_ID,
			fieldMAHSUP_TOPLAMI,
			fieldFERAGAT_TOPLAMI,
			fieldFERAGAT_TOPLAMI_DOVIZ_ID,
			fieldALACAK_TOPLAMI_DOVIZ_ID,
			fieldALACAK_TOPLAMI,
			fieldKALAN_DOVIZ_ID,
			fieldKALAN,
			fieldTAHLIYE_VEK_UCR_DOVIZ_ID,
			fieldTAHLIYE_VEK_UCR,
			fieldDIGER_HARC_DOVIZ_ID,
			fieldDIGER_HARC,
			fieldTD_GIDERI_DOVIZ_ID,
			fieldTD_GIDERI,
			fieldTD_BAKIYE_HARC_DOVIZ_ID,
			fieldTD_BAKIYE_HARC,
			fieldTD_VEK_UCR_DOVIZ_ID,
			fieldTD_VEK_UCR,
			fieldTD_TEBLIG_GIDERI_DOVIZ_ID,
			fieldTD_TEBLIG_GIDERI,
			fieldBIRIKMIS_NAFAKA_DOVIZ_ID,
			fieldBIRIKMIS_NAFAKA,
			fieldICRA_INKAR_TAZMINATI_DOVIZ_ID,
			fieldICRA_INKAR_TAZMINATI,
			fieldDAMGA_PULU_DOVIZ_ID,
			fieldDAMGA_PULU,
			fieldACIKLAMA,
			fieldPROTOKOL_MIKTARI_DOVIZ_ID,
			fieldPROTOKOL_MIKTARI,
			fieldPROTOKOL_FAIZ_ORANI,
			fieldPROTOKOL_TARIHI,
			fieldKARSILIK_TUTARI_DOVIZ_ID,
			fieldKARSILIK_TUTARI,
			fieldTO_MASRAF_TOPLAMI,
			fieldTO_MASRAF_TOPLAMI_DOVIZ_ID,
			fieldTS_MASRAF_TOPLAMI,
			fieldTS_MASRAF_TOPLAMI_DOVIZ_ID,
			fieldTUM_MASRAF_TOPLAMI,
			fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID,
			fieldHARC_TOPLAMI,
			fieldHARC_TOPLAMI_DOVIZ_ID,
			fieldTO_VEKALET_TOPLAMI_DOVIZ_ID,
			fieldTO_VEKALET_TOPLAMI,
			fieldTS_VEKALET_TOPLAMI,
			fieldTS_VEKALET_TOPLAMI_DOVIZ_ID,
			fieldTUM_VEKALET_TOPLAMI,
			fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID,
			fieldKARSI_VEKALET_TOPLAMI,
			fieldKARSI_VEKALET_TOPLAMI_DOVIZ_ID,
			fieldFAIZ_TOPLAMI,
			fieldFAIZ_TOPLAMI_DOVIZ_ID,
			fieldILAM_UCRETLER_TOPLAMI,
			fieldILAM_UCRETLER_TOPLAMI_DOVIZ_ID,
			fieldIT_VEKALET_UCRETI_DOVIZ_ID,
			fieldIT_VEKALET_UCRETI,
			fieldIT_GIDERI_DOVIZ_ID,
			fieldIT_GIDERI,
			fieldTO_ODEME_MAHSUP_TOPLAMI,
			fieldTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID,
			fieldPAYLASIM_TIPI,
			fieldTS_HESAP_TIP_ID,
			fieldTS_HESAP_TIP_ADI,
			fieldTO_HESAP_TIP_ID,
			fieldTO_HESAP_TIP_ADI,
			fieldBASVURMA_HARCI,
			fieldBASVURMA_HARCI_DOVIZ_ID,
			fieldVEKALET_HARCI,
			fieldVEKALET_HARCI_DOVIZ_ID,
			fieldVEKALET_PULU,
			fieldVEKALET_PULU_DOVIZ_ID,
			fieldIFLAS_BASVURMA_HARCI,
			fieldIFLAS_BASVURMA_HARCI_DOVIZ_ID,
			fieldIFLASIN_ACILMASI_HARCI,
			fieldIFLASIN_ACILMASI_HARCI_DOVIZ_ID,
			fieldILK_TEBLIGAT_GIDERI,
			fieldILK_TEBLIGAT_GIDERI_DOVIZ_ID,
			fieldTAHLIYE_HARCI,
			fieldTAHLIYE_HARCI_DOVIZ_ID,
			fieldTESLIM_HARCI,
			fieldTESLIM_HARCI_DOVIZ_ID,
			fieldFERAGAT_HARCI,
			fieldFERAGAT_HARCI_DOVIZ_ID,
			fieldTO_YONETIMG_TAZMINATI_DOVIZ_ID,
			fieldTO_YONETIMG_TAZMINATI,
			fieldASAMA_ID,
			fieldASAMA_ADI,
			fieldTAKIP_TALEP_ID,
			};

            #endregion []

            #region Field Caption

            Dictionary<string, string> captionlar = GetCaptionDictinory();
            Dictionary<string, RepositoryItem> editler = GetRepositoryItemDictinory();

            for (int i = 0; i < dizi.Length; i++)
            {
                string caption = string.Empty;
                if (captionlar.ContainsKey(dizi[i].FieldName))
                    caption = captionlar[dizi[i].FieldName];
                if (caption.Length > 0)
                    dizi[i].Caption = caption;
                else if (dizi[i].FieldName.ToLower().Contains("doviz_id"))
                    dizi[i].Caption = "Brm";

                if (dizi[i].FieldName.Contains("_DOVIZ_ID"))
                {
                    dizi[i].FieldEdit = editler["DovizId"];
                }
                else if (editler.ContainsKey(dizi[i].FieldName))
                    dizi[i].FieldEdit = editler[dizi[i].FieldName];
            }

            #endregion Field Caption

            return dizi;
        }

        private Dictionary<string, string> GetCaptionDictinory()
        {
            Dictionary<string, string> dicFieldCaption = new Dictionary<string, string>();

            #region Caption Edit

            dicFieldCaption.Add("CARI_ADI", "");
            dicFieldCaption.Add("CARI_ID", "");
            dicFieldCaption.Add("SORUMLU_AVUKAT_CARI_ID", "");
            dicFieldCaption.Add("TARAF_KODU", "");
            dicFieldCaption.Add("KOD", "");
            dicFieldCaption.Add("TARAF_SIFAT_ID", "");
            dicFieldCaption.Add("SIFAT", "");
            dicFieldCaption.Add("ID", "");
            dicFieldCaption.Add("TALEP_ADI", "");
            dicFieldCaption.Add("FORM_TIP_ID", "");
            dicFieldCaption.Add("FORM_ADI", "");
            dicFieldCaption.Add("FOY_DURUM_ID", "");
            dicFieldCaption.Add("DURUM", "");
            dicFieldCaption.Add("FOY_NO", "");
            dicFieldCaption.Add("REFERANS_NO", "");
            dicFieldCaption.Add("REFERANS_NO2", "");
            dicFieldCaption.Add("REFERANS_NO3", "");
            dicFieldCaption.Add("ADLI_BIRIM_NO_ID", "");
            dicFieldCaption.Add("NO", "");
            dicFieldCaption.Add("ADLIYE", "");
            dicFieldCaption.Add("ADLI_BIRIM_ADLIYE_ID", "");
            dicFieldCaption.Add("ICRA_OZEL_KOD1_ID", "");
            dicFieldCaption.Add("ICRA_OZEL_KOD2_ID", "");
            dicFieldCaption.Add("ICRA_OZEL_KOD3_ID", "");
            dicFieldCaption.Add("ICRA_OZEL_KOD4_ID", "");
            dicFieldCaption.Add("TAKIBIN_AVUKATA_INTIKAL_TARIHI", "");
            dicFieldCaption.Add("FOY_ARSIV_TARIHI", "");
            dicFieldCaption.Add("FOY_INFAZ_TARIHI", "");
            dicFieldCaption.Add("TAKIBIN_MUVEKKILE_IADE_TARIHI", "");
            dicFieldCaption.Add("SON_HESAP_TARIHI", "");
            dicFieldCaption.Add("BIR_YIL_KAC_GUN", "");
            dicFieldCaption.Add("ASIL_ALACAK", "");
            dicFieldCaption.Add("ISLEMIS_FAIZ", "");
            dicFieldCaption.Add("BSMV_TO", "");
            dicFieldCaption.Add("KKDV_TO", "");
            dicFieldCaption.Add("OIV_TO", "");
            dicFieldCaption.Add("KDV_TO", "");
            dicFieldCaption.Add("IH_VEKALET_UCRETI", "");
            dicFieldCaption.Add("IH_GIDERI", "");
            dicFieldCaption.Add("IT_HACIZDE_ODENEN", "");
            dicFieldCaption.Add("KARSILIKSIZ_CEK_TAZMINATI", "");
            dicFieldCaption.Add("CEK_KOMISYONU", "");
            dicFieldCaption.Add("ILAM_YARGILAMA_GIDERI", "");
            dicFieldCaption.Add("ILAM_BK_YARG_ONAMA", "");
            dicFieldCaption.Add("ILAM_TEBLIG_GIDERI", "");
            dicFieldCaption.Add("ILAM_INKAR_TAZMINATI", "");
            dicFieldCaption.Add("ILAM_VEK_UCR", "");
            dicFieldCaption.Add("PROTESTO_GIDERI", "");
            dicFieldCaption.Add("IHTAR_GIDERI", "");
            dicFieldCaption.Add("OZEL_TAZMINAT", "");
            dicFieldCaption.Add("OZEL_TUTAR1_FAIZ_ORANI", "");
            dicFieldCaption.Add("OZEL_TUTAR1_KONU_ID", "");
            dicFieldCaption.Add("OZEL_TUTAR1_KONU_ADI", "");
            dicFieldCaption.Add("OZEL_TUTAR1", "");
            dicFieldCaption.Add("OZEL_TUTAR2_KONU_ID", "");
            dicFieldCaption.Add("OZEL_TUTAR2_KONU_ADI", "");
            dicFieldCaption.Add("OZEL_TUTAR2", "");
            dicFieldCaption.Add("OZEL_TUTAR3_KONU_ID", "");
            dicFieldCaption.Add("OZEL_TUTAR3_KONU_ADI", "");
            dicFieldCaption.Add("OZEL_TUTAR3", "");
            dicFieldCaption.Add("TAKIP_CIKISI", "");
            dicFieldCaption.Add("SONRAKI_FAIZ", "");
            dicFieldCaption.Add("SONRAKI_TAZMINAT", "");
            dicFieldCaption.Add("BSMV_TS", "");
            dicFieldCaption.Add("OIV_TS", "");
            dicFieldCaption.Add("KDV_TS", "");
            dicFieldCaption.Add("ILK_GIDERLER", "");
            dicFieldCaption.Add("PESIN_HARC", "");
            dicFieldCaption.Add("ODENEN_TAHSIL_HARCI", "");
            dicFieldCaption.Add("KALAN_TAHSIL_HARCI", "");
            dicFieldCaption.Add("MASAYA_KATILMA_HARCI", "");
            dicFieldCaption.Add("PAYLASMA_HARCI", "");
            dicFieldCaption.Add("DAVA_GIDERLERI", "");
            dicFieldCaption.Add("DIGER_GIDERLER", "");
            dicFieldCaption.Add("TAKIP_VEKALET_UCRETI_KATSAYI", "");
            dicFieldCaption.Add("TAKIP_VEKALET_UCRETI", "");
            dicFieldCaption.Add("DAVA_INKAR_TAZMINATI", "");
            dicFieldCaption.Add("DAVA_VEKALET_UCRETI", "");
            dicFieldCaption.Add("ODEME_TOPLAMI", "");
            dicFieldCaption.Add("TO_ODEME_TOPLAMI", "");
            dicFieldCaption.Add("MAHSUP_TOPLAMI", "");
            dicFieldCaption.Add("FERAGAT_TOPLAMI", "");
            dicFieldCaption.Add("ALACAK_TOPLAMI", "");
            dicFieldCaption.Add("KALAN", "");
            dicFieldCaption.Add("TAHLIYE_VEK_UCR", "");
            dicFieldCaption.Add("DIGER_HARC", "");
            dicFieldCaption.Add("TD_GIDERI", "");
            dicFieldCaption.Add("TD_BAKIYE_HARC", "");
            dicFieldCaption.Add("TD_VEK_UCR", "");
            dicFieldCaption.Add("TD_TEBLIG_GIDERI", "");
            dicFieldCaption.Add("BIRIKMIS_NAFAKA", "");
            dicFieldCaption.Add("ICRA_INKAR_TAZMINATI", "");
            dicFieldCaption.Add("DAMGA_PULU", "");
            dicFieldCaption.Add("ACIKLAMA", "");
            dicFieldCaption.Add("PROTOKOL_MIKTARI", "");
            dicFieldCaption.Add("PROTOKOL_FAIZ_ORANI", "");
            dicFieldCaption.Add("PROTOKOL_TARIHI", "");
            dicFieldCaption.Add("KARSILIK_TUTARI", "");
            dicFieldCaption.Add("TO_MASRAF_TOPLAMI", "");
            dicFieldCaption.Add("TS_MASRAF_TOPLAMI", "");
            dicFieldCaption.Add("TUM_MASRAF_TOPLAMI", "");
            dicFieldCaption.Add("HARC_TOPLAMI", "");
            dicFieldCaption.Add("TO_VEKALET_TOPLAMI", "");
            dicFieldCaption.Add("TS_VEKALET_TOPLAMI", "");
            dicFieldCaption.Add("TUM_VEKALET_TOPLAMI", "");
            dicFieldCaption.Add("KARSI_VEKALET_TOPLAMI", "");
            dicFieldCaption.Add("FAIZ_TOPLAMI", "");
            dicFieldCaption.Add("ILAM_UCRETLER_TOPLAMI", "");
            dicFieldCaption.Add("IT_VEKALET_UCRETI", "");
            dicFieldCaption.Add("IT_GIDERI", "");
            dicFieldCaption.Add("TO_ODEME_MAHSUP_TOPLAMI", "");
            dicFieldCaption.Add("PAYLASIM_TIPI", "");
            dicFieldCaption.Add("TS_HESAP_TIP_ID", "");
            dicFieldCaption.Add("TS_HESAP_TIP_ADI", "");
            dicFieldCaption.Add("TO_HESAP_TIP_ID", "");
            dicFieldCaption.Add("TO_HESAP_TIP_ADI", "");
            dicFieldCaption.Add("BASVURMA_HARCI", "");
            dicFieldCaption.Add("VEKALET_HARCI", "");
            dicFieldCaption.Add("VEKALET_PULU", "");
            dicFieldCaption.Add("IFLAS_BASVURMA_HARCI", "");
            dicFieldCaption.Add("IFLASIN_ACILMASI_HARCI", "");
            dicFieldCaption.Add("ILK_TEBLIGAT_GIDERI", "");
            dicFieldCaption.Add("TAHLIYE_HARCI", "");
            dicFieldCaption.Add("TESLIM_HARCI", "");
            dicFieldCaption.Add("FERAGAT_HARCI", "");
            dicFieldCaption.Add("TO_YONETIMG_TAZMINATI", "");
            dicFieldCaption.Add("ASAMA_ID", "");
            dicFieldCaption.Add("ASAMA_ADI", "");
            dicFieldCaption.Add("TAKIP_TALEP_ID", "");

            #endregion Caption Edit

            return dicFieldCaption;
        }

        private Dictionary<string, RepositoryItem> GetRepositoryItemDictinory()
        {
            RepositoryItemLookUpEdit rlueDoviz = new RepositoryItemLookUpEdit();

            RepositoryItem Item = new RepositoryItem();

            Dictionary<string, RepositoryItem> sozluk = new Dictionary<string, RepositoryItem>();

            #region Add item

            sozluk.Add("DovizId", rlueDoviz);

            sozluk.Add("CARI_ID", Item);
            sozluk.Add("SORUMLU_AVUKAT_CARI_ID", Item);
            sozluk.Add("TARAF_SIFAT_ID", Item);
            sozluk.Add("FORM_TIP_ID", Item);
            sozluk.Add("FOY_DURUM_ID", Item);
            sozluk.Add("ADLI_BIRIM_NO_ID", Item);
            sozluk.Add("ADLI_BIRIM_ADLIYE_ID", Item);
            sozluk.Add("ICRA_OZEL_KOD1_ID", Item);
            sozluk.Add("ICRA_OZEL_KOD2_ID", Item);
            sozluk.Add("ICRA_OZEL_KOD3_ID", Item);
            sozluk.Add("ICRA_OZEL_KOD4_ID", Item);
            sozluk.Add("OZEL_TUTAR1_KONU_ID", Item);
            sozluk.Add("OZEL_TUTAR2_KONU_ID", Item);
            sozluk.Add("OZEL_TUTAR3_KONU_ID", Item);
            sozluk.Add("TS_HESAP_TIP_ID", Item);
            sozluk.Add("TO_HESAP_TIP_ID", Item);
            sozluk.Add("ASAMA_ID", Item);
            sozluk.Add("TAKIP_TALEP_ID", Item);

            #endregion Add item

            return sozluk;
        }

        #region IRaporSource Members

        public object ChartDataSource
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public object ListDataSource
        {
            get
            {
                return MyDataSource;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public object PivotDataSource
        {
            get
            {
                return MyDataSource;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public void PrintChart()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void PrintListe()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void PrintPivot()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void SaveChart()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void SaveListe()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void SavePivot()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion IRaporSource Members
    }
}