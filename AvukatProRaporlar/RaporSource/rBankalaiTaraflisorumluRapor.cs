using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    public class rBankalaiTaraflisorumluRapor
    {
        private Dictionary<string, string> captionlar;
        private Dictionary<string, RepositoryItem> editler;

        #region Settings

        public bool EnableChart
        {
            get { return false; }
        }

        public bool EnableGrid
        {
            get { return false; }
        }

        public bool EnablePivot
        {
            get { return false; }
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

        public string MenuName
        {
            get { return "Menu Name"; }
        }

        public string Title
        {
            get { return "Title"; }
        }

        #endregion Settings

        public GridBand[] GetBands()
        {
            BandedGridColumn devirdenAdet = new BandedGridColumn();
            devirdenAdet.VisibleIndex = 0;
            devirdenAdet.FieldName = "devirdenAdet";
            devirdenAdet.Name = "devirdenAdet";
            devirdenAdet.Visible = true;
            devirdenAdet.Caption = "Adet1";

            BandedGridColumn devirdenMiktar = new BandedGridColumn();
            devirdenMiktar.VisibleIndex = 1;
            devirdenMiktar.FieldName = "devirdenMiktar";
            devirdenMiktar.Name = "devirdenMiktar";
            devirdenMiktar.Visible = true;
            devirdenMiktar.Caption = "Miktar1";

            BandedGridColumn gelenAdet = new BandedGridColumn();
            gelenAdet.VisibleIndex = 2;
            gelenAdet.FieldName = "gelenAdet";
            gelenAdet.Name = "gelenAdet";
            gelenAdet.Visible = true;
            gelenAdet.Caption = "Adet";

            BandedGridColumn gelenMiktar = new BandedGridColumn();
            gelenMiktar.VisibleIndex = 3;
            gelenMiktar.FieldName = "gelenMiktar";
            gelenMiktar.Name = "gelenMiktar";
            gelenMiktar.Visible = true;
            gelenMiktar.Caption = "Miktar";

            BandedGridColumn tahsilatAdet = new BandedGridColumn();
            tahsilatAdet.VisibleIndex = 4;
            tahsilatAdet.FieldName = "tahsilatAdet";
            tahsilatAdet.Name = "tahsilatAdet";
            tahsilatAdet.Visible = true;
            tahsilatAdet.Caption = "Adet";

            BandedGridColumn tahsilatMiktar = new BandedGridColumn();
            tahsilatMiktar.VisibleIndex = 5;
            tahsilatMiktar.FieldName = "tahsilatMiktar";
            tahsilatMiktar.Name = "tahsilatMiktar";
            tahsilatMiktar.Visible = true;
            tahsilatMiktar.Caption = "Miktar";

            BandedGridColumn acizAdet = new BandedGridColumn();
            acizAdet.VisibleIndex = 6;
            acizAdet.FieldName = "acizAdet";
            acizAdet.Name = "acizAdet";
            acizAdet.Visible = true;
            acizAdet.Caption = "Adet";

            BandedGridColumn acizMiktar = new BandedGridColumn();
            acizMiktar.VisibleIndex = 7;
            acizMiktar.FieldName = "acizMiktar";
            acizMiktar.Name = "acizMiktar";
            acizMiktar.Visible = true;
            acizMiktar.Caption = "Miktar";

            BandedGridColumn tahsilatDagAnapara = new BandedGridColumn();
            tahsilatDagAnapara.VisibleIndex = 8;
            tahsilatDagAnapara.FieldName = "tahsilatDagAnapara";
            tahsilatDagAnapara.Name = "tahsilatDagAnapara";
            tahsilatDagAnapara.Visible = true;
            tahsilatDagAnapara.Caption = "Anaparaya";

            BandedGridColumn tahsilatDagFaize = new BandedGridColumn();
            tahsilatDagFaize.VisibleIndex = 9;
            tahsilatDagFaize.FieldName = "tahsilatDagFaize";
            tahsilatDagFaize.Name = "tahsilatDagFaize";
            tahsilatDagFaize.Visible = true;
            tahsilatDagFaize.Caption = "Faize";

            BandedGridColumn tahsilatDagMasraflara = new BandedGridColumn();
            tahsilatDagMasraflara.VisibleIndex = 10;
            tahsilatDagMasraflara.FieldName = "tahsilatDagMasraflara";
            tahsilatDagMasraflara.Name = "tahsilatDagMasraflara";
            tahsilatDagMasraflara.Visible = true;
            tahsilatDagMasraflara.Caption = "Masraflara";

            BandedGridColumn devirAdet = new BandedGridColumn();
            devirAdet.VisibleIndex = 11;
            devirAdet.FieldName = "devirAdet";
            devirAdet.Name = "devirAdet";
            devirAdet.Visible = true;
            devirAdet.Caption = "Adet";

            BandedGridColumn devirMiktar = new BandedGridColumn();
            devirMiktar.VisibleIndex = 12;
            devirMiktar.FieldName = "devirMiktar";
            devirMiktar.Name = "devirMiktar";
            devirMiktar.Visible = true;
            devirMiktar.Caption = "Miktar";

            GridBand devirdenGelen = new GridBand();
            devirdenGelen.Caption = "Devirden Gelen";
            GridBand gelen = new GridBand();
            gelen.Caption = "Gelen";
            GridBand tahsilatlaKapanan = new GridBand();
            tahsilatlaKapanan.Caption = "Tahsilatla Kapanan";
            GridBand acizDerkenar = new GridBand();
            acizDerkenar.Caption = "Aciz / Derkenarla Kapanan";
            GridBand tahsilatDagilimi = new GridBand();
            tahsilatDagilimi.Caption = "Tahsilat Dağılımı";
            GridBand devir = new GridBand();
            devir.Caption = "Devir";

            devirdenGelen.Columns.Add(devirdenAdet);
            devirdenGelen.Columns.Add(devirdenMiktar);
            gelen.Columns.Add(gelenAdet);
            gelen.Columns.Add(gelenMiktar);
            tahsilatlaKapanan.Columns.Add(tahsilatAdet);
            tahsilatlaKapanan.Columns.Add(tahsilatMiktar);
            acizDerkenar.Columns.Add(acizAdet);
            acizDerkenar.Columns.Add(acizMiktar);
            tahsilatDagilimi.Columns.Add(tahsilatDagAnapara);
            tahsilatDagilimi.Columns.Add(tahsilatDagFaize);
            tahsilatDagilimi.Columns.Add(tahsilatDagMasraflara);
            devir.Columns.Add(devirAdet);
            devir.Columns.Add(devirMiktar);

            GridBand[] bands = new GridBand[]{
                devirdenGelen,
            gelen,tahsilatlaKapanan,acizDerkenar,tahsilatDagilimi,devir
            };

            return bands;
        }

        public GridColumn[] GetGridColumns()
        {
            #region Field & Properties

            GridBand devirdenGelen = new GridBand();
            devirdenGelen.Caption = "Devirden Gelen";
            GridBand gelen = new GridBand();
            gelen.Caption = "Gelen";
            GridBand tahsilatlaKapanan = new GridBand();
            tahsilatlaKapanan.Caption = "Tahsilatla Kapanan";
            GridBand acizDerkenar = new GridBand();
            acizDerkenar.Caption = "Aciz / Derkenarla Kapanan";
            GridBand tahsilatDagilimi = new GridBand();
            tahsilatDagilimi.Caption = "Tahsilat Dağılımı";
            GridBand devir = new GridBand();
            devir.Caption = "Devir";

            BandedGridColumn devirdenAdet = new BandedGridColumn();
            devirdenAdet.VisibleIndex = 0;
            devirdenAdet.FieldName = "devirdenAdet";
            devirdenAdet.Name = "devirdenAdet";
            devirdenAdet.Visible = true;
            devirdenAdet.Caption = "Adet1";

            BandedGridColumn devirdenMiktar = new BandedGridColumn();
            devirdenMiktar.VisibleIndex = 1;
            devirdenMiktar.FieldName = "devirdenMiktar";
            devirdenMiktar.Name = "devirdenMiktar";
            devirdenMiktar.Visible = true;
            devirdenMiktar.Caption = "Miktar1";

            BandedGridColumn gelenAdet = new BandedGridColumn();
            gelenAdet.VisibleIndex = 2;
            gelenAdet.FieldName = "gelenAdet";
            gelenAdet.Name = "gelenAdet";
            gelenAdet.Visible = true;
            gelenAdet.Caption = "Adet";

            BandedGridColumn gelenMiktar = new BandedGridColumn();
            gelenMiktar.VisibleIndex = 3;
            gelenMiktar.FieldName = "gelenMiktar";
            gelenMiktar.Name = "gelenMiktar";
            gelenMiktar.Visible = true;
            gelenMiktar.Caption = "Miktar";

            BandedGridColumn tahsilatAdet = new BandedGridColumn();
            tahsilatAdet.VisibleIndex = 4;
            tahsilatAdet.FieldName = "tahsilatAdet";
            tahsilatAdet.Name = "tahsilatAdet";
            tahsilatAdet.Visible = true;
            tahsilatAdet.Caption = "Adet";

            BandedGridColumn tahsilatMiktar = new BandedGridColumn();
            tahsilatMiktar.VisibleIndex = 5;
            tahsilatMiktar.FieldName = "tahsilatMiktar";
            tahsilatMiktar.Name = "tahsilatMiktar";
            tahsilatMiktar.Visible = true;
            tahsilatMiktar.Caption = "Miktar";

            BandedGridColumn acizAdet = new BandedGridColumn();
            acizAdet.VisibleIndex = 6;
            acizAdet.FieldName = "acizAdet";
            acizAdet.Name = "acizAdet";
            acizAdet.Visible = true;
            acizAdet.Caption = "Adet";

            BandedGridColumn acizMiktar = new BandedGridColumn();
            acizMiktar.VisibleIndex = 7;
            acizMiktar.FieldName = "acizMiktar";
            acizMiktar.Name = "acizMiktar";
            acizMiktar.Visible = true;
            acizMiktar.Caption = "Miktar";

            BandedGridColumn tahsilatDagAnapara = new BandedGridColumn();
            tahsilatDagAnapara.VisibleIndex = 8;
            tahsilatDagAnapara.FieldName = "tahsilatDagAnapara";
            tahsilatDagAnapara.Name = "tahsilatDagAnapara";
            tahsilatDagAnapara.Visible = true;
            tahsilatDagAnapara.Caption = "Anaparaya";

            BandedGridColumn tahsilatDagFaize = new BandedGridColumn();
            tahsilatDagFaize.VisibleIndex = 9;
            tahsilatDagFaize.FieldName = "tahsilatDagFaize";
            tahsilatDagFaize.Name = "tahsilatDagFaize";
            tahsilatDagFaize.Visible = true;
            tahsilatDagFaize.Caption = "Faize";

            BandedGridColumn tahsilatDagMasraflara = new BandedGridColumn();
            tahsilatDagMasraflara.VisibleIndex = 10;
            tahsilatDagMasraflara.FieldName = "tahsilatDagMasraflara";
            tahsilatDagMasraflara.Name = "tahsilatDagMasraflara";
            tahsilatDagMasraflara.Visible = true;
            tahsilatDagMasraflara.Caption = "Masraflara";

            BandedGridColumn devirAdet = new BandedGridColumn();
            devirAdet.VisibleIndex = 11;
            devirAdet.FieldName = "devirAdet";
            devirAdet.Name = "devirAdet";
            devirAdet.Visible = true;
            devirAdet.Caption = "Adet";

            BandedGridColumn devirMiktar = new BandedGridColumn();
            devirMiktar.VisibleIndex = 12;
            devirMiktar.FieldName = "devirMiktar";
            devirMiktar.Name = "devirMiktar";
            devirMiktar.Visible = true;
            devirMiktar.Caption = "Miktar";

            #region eski

            /*
            GridColumn colFOY_NO = new GridColumn();
            colFOY_NO.VisibleIndex = 0;
            colFOY_NO.FieldName = "FOY_NO";
            colFOY_NO.Name = "colFOY_NO";
            colFOY_NO.Visible = true;

            GridColumn colREFERANS_NO = new GridColumn();
            colREFERANS_NO.VisibleIndex = 1;
            colREFERANS_NO.FieldName = "REFERANS_NO";
            colREFERANS_NO.Name = "colREFERANS_NO";
            colREFERANS_NO.Visible = true;

            GridColumn colREFERANS_NO2 = new GridColumn();
            colREFERANS_NO2.VisibleIndex = 2;
            colREFERANS_NO2.FieldName = "REFERANS_NO2";
            colREFERANS_NO2.Name = "colREFERANS_NO2";
            colREFERANS_NO2.Visible = true;

            GridColumn colREFERANS_NO3 = new GridColumn();
            colREFERANS_NO3.VisibleIndex = 3;
            colREFERANS_NO3.FieldName = "REFERANS_NO3";
            colREFERANS_NO3.Name = "colREFERANS_NO3";
            colREFERANS_NO3.Visible = true;

            GridColumn colTAKIP_TARIHI = new GridColumn();
            colTAKIP_TARIHI.VisibleIndex = 4;
            colTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            colTAKIP_TARIHI.Name = "colTAKIP_TARIHI";
            colTAKIP_TARIHI.Visible = true;

            GridColumn colESAS_NO = new GridColumn();
            colESAS_NO.VisibleIndex = 5;
            colESAS_NO.FieldName = "ESAS_NO";
            colESAS_NO.Name = "colESAS_NO";
            colESAS_NO.Visible = true;

            GridColumn colTAKIBIN_AVUKATA_INTIKAL_TARIHI = new GridColumn();
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.VisibleIndex = 6;
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "colTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            colTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = true;

            GridColumn colASIL_ALACAK_DOVIZ_ID = new GridColumn();
            colASIL_ALACAK_DOVIZ_ID.VisibleIndex = 7;
            colASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            colASIL_ALACAK_DOVIZ_ID.Name = "colASIL_ALACAK_DOVIZ_ID";
            colASIL_ALACAK_DOVIZ_ID.Visible = true;

            GridColumn colASIL_ALACAK = new GridColumn();
            colASIL_ALACAK.VisibleIndex = 8;
            colASIL_ALACAK.FieldName = "ASIL_ALACAK";
            colASIL_ALACAK.Name = "colASIL_ALACAK";
            colASIL_ALACAK.Visible = true;

            GridColumn colISLEMIS_FAIZ_DOVIZ_ID = new GridColumn();
            colISLEMIS_FAIZ_DOVIZ_ID.VisibleIndex = 9;
            colISLEMIS_FAIZ_DOVIZ_ID.FieldName = "ISLEMIS_FAIZ_DOVIZ_ID";
            colISLEMIS_FAIZ_DOVIZ_ID.Name = "colISLEMIS_FAIZ_DOVIZ_ID";
            colISLEMIS_FAIZ_DOVIZ_ID.Visible = true;

            GridColumn colGOREV = new GridColumn();
            colGOREV.VisibleIndex = 219;
            colGOREV.FieldName = "GOREV";
            colGOREV.Name = "colGOREV";
            colGOREV.Visible = true;

            GridColumn colISLEMIS_FAIZ = new GridColumn();
            colISLEMIS_FAIZ.VisibleIndex = 10;
            colISLEMIS_FAIZ.FieldName = "ISLEMIS_FAIZ";
            colISLEMIS_FAIZ.Name = "colISLEMIS_FAIZ";
            colISLEMIS_FAIZ.Visible = true;

            GridColumn colTAKIP_CIKISI = new GridColumn();
            colTAKIP_CIKISI.VisibleIndex = 11;
            colTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            colTAKIP_CIKISI.Name = "colTAKIP_CIKISI";
            colTAKIP_CIKISI.Visible = true;

            GridColumn colTAKIP_CIKISI_DOVIZ_ID = new GridColumn();
            colTAKIP_CIKISI_DOVIZ_ID.VisibleIndex = 12;
            colTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            colTAKIP_CIKISI_DOVIZ_ID.Name = "colTAKIP_CIKISI_DOVIZ_ID";
            colTAKIP_CIKISI_DOVIZ_ID.Visible = true;

            GridColumn colSONRAKI_FAIZ = new GridColumn();
            colSONRAKI_FAIZ.VisibleIndex = 13;
            colSONRAKI_FAIZ.FieldName = "SONRAKI_FAIZ";
            colSONRAKI_FAIZ.Name = "colSONRAKI_FAIZ";
            colSONRAKI_FAIZ.Visible = true;

            GridColumn colSONRAKI_FAIZ_DOVIZ_ID = new GridColumn();
            colSONRAKI_FAIZ_DOVIZ_ID.VisibleIndex = 14;
            colSONRAKI_FAIZ_DOVIZ_ID.FieldName = "SONRAKI_FAIZ_DOVIZ_ID";
            colSONRAKI_FAIZ_DOVIZ_ID.Name = "colSONRAKI_FAIZ_DOVIZ_ID";
            colSONRAKI_FAIZ_DOVIZ_ID.Visible = true;

            GridColumn colODEME_TOPLAMI_DOVIZ_ID = new GridColumn();
            colODEME_TOPLAMI_DOVIZ_ID.VisibleIndex = 15;
            colODEME_TOPLAMI_DOVIZ_ID.FieldName = "ODEME_TOPLAMI_DOVIZ_ID";
            colODEME_TOPLAMI_DOVIZ_ID.Name = "colODEME_TOPLAMI_DOVIZ_ID";
            colODEME_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colODEME_TOPLAMI = new GridColumn();
            colODEME_TOPLAMI.VisibleIndex = 16;
            colODEME_TOPLAMI.FieldName = "ODEME_TOPLAMI";
            colODEME_TOPLAMI.Name = "colODEME_TOPLAMI";
            colODEME_TOPLAMI.Visible = true;

            GridColumn colTO_ODEME_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTO_ODEME_TOPLAMI_DOVIZ_ID.VisibleIndex = 17;
            colTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            colTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "colTO_ODEME_TOPLAMI_DOVIZ_ID";
            colTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colTO_ODEME_TOPLAMI = new GridColumn();
            colTO_ODEME_TOPLAMI.VisibleIndex = 18;
            colTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            colTO_ODEME_TOPLAMI.Name = "colTO_ODEME_TOPLAMI";
            colTO_ODEME_TOPLAMI.Visible = true;

            GridColumn colKALAN = new GridColumn();
            colKALAN.VisibleIndex = 19;
            colKALAN.FieldName = "KALAN";
            colKALAN.Name = "colKALAN";
            colKALAN.Visible = true;

            GridColumn colKALAN_DOVIZ_ID = new GridColumn();
            colKALAN_DOVIZ_ID.VisibleIndex = 20;
            colKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            colKALAN_DOVIZ_ID.Name = "colKALAN_DOVIZ_ID";
            colKALAN_DOVIZ_ID.Visible = true;

            GridColumn colACIKLAMA = new GridColumn();
            colACIKLAMA.VisibleIndex = 21;
            colACIKLAMA.FieldName = "ACIKLAMA";
            colACIKLAMA.Name = "colACIKLAMA";
            colACIKLAMA.Visible = true;

            GridColumn colKAPAMA_TARIHI = new GridColumn();
            colKAPAMA_TARIHI.VisibleIndex = 22;
            colKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            colKAPAMA_TARIHI.Name = "colKAPAMA_TARIHI";
            colKAPAMA_TARIHI.Visible = true;

            GridColumn colRISK_MIKTARI = new GridColumn();
            colRISK_MIKTARI.VisibleIndex = 23;
            colRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            colRISK_MIKTARI.Name = "colRISK_MIKTARI";
            colRISK_MIKTARI.Visible = true;

            GridColumn colRISK_MIKTARI_DOVIZ_ID = new GridColumn();
            colRISK_MIKTARI_DOVIZ_ID.VisibleIndex = 24;
            colRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            colRISK_MIKTARI_DOVIZ_ID.Name = "colRISK_MIKTARI_DOVIZ_ID";
            colRISK_MIKTARI_DOVIZ_ID.Visible = true;

            GridColumn colTS_MASRAF_HARC_TOPLAMI = new GridColumn();
            colTS_MASRAF_HARC_TOPLAMI.VisibleIndex = 25;
            colTS_MASRAF_HARC_TOPLAMI.FieldName = "TS_MASRAF_HARC_TOPLAMI";
            colTS_MASRAF_HARC_TOPLAMI.Name = "colTS_MASRAF_HARC_TOPLAMI";
            colTS_MASRAF_HARC_TOPLAMI.Visible = true;

            GridColumn colTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID.VisibleIndex = 26;
            colTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_HARC_TOPLAMI_DOVIZ_ID";
            colTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID.Name = "colTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID";
            colTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 27;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 28;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            GridColumn colTAKIP_EDEN = new GridColumn();
            colTAKIP_EDEN.VisibleIndex = 29;
            colTAKIP_EDEN.FieldName = "TAKIP_EDEN";
            colTAKIP_EDEN.Name = "colTAKIP_EDEN";
            colTAKIP_EDEN.Visible = true;

            GridColumn colTAKIP_EDILEN = new GridColumn();
            colTAKIP_EDILEN.VisibleIndex = 30;
            colTAKIP_EDILEN.FieldName = "TAKIP_EDILEN";
            colTAKIP_EDILEN.Name = "colTAKIP_EDILEN";
            colTAKIP_EDILEN.Visible = true;

            GridColumn colIZLEYEN = new GridColumn();
            colIZLEYEN.VisibleIndex = 31;
            colIZLEYEN.FieldName = "IZLEYEN";
            colIZLEYEN.Name = "colIZLEYEN";
            colIZLEYEN.Visible = true;

            GridColumn colSORUMLU = new GridColumn();
            colSORUMLU.VisibleIndex = 32;
            colSORUMLU.FieldName = "SORUMLU";
            colSORUMLU.Name = "colSORUMLU";
            colSORUMLU.Visible = true;

            GridColumn colTAKIP_EDEN_SIFAT = new GridColumn();
            colTAKIP_EDEN_SIFAT.VisibleIndex = 33;
            colTAKIP_EDEN_SIFAT.FieldName = "TAKIP_EDEN_SIFAT";
            colTAKIP_EDEN_SIFAT.Name = "colTAKIP_EDEN_SIFAT";
            colTAKIP_EDEN_SIFAT.Visible = true;

            GridColumn colTAKIP_EDILEN_SIFAT = new GridColumn();
            colTAKIP_EDILEN_SIFAT.VisibleIndex = 34;
            colTAKIP_EDILEN_SIFAT.FieldName = "TAKIP_EDILEN_SIFAT";
            colTAKIP_EDILEN_SIFAT.Name = "colTAKIP_EDILEN_SIFAT";
            colTAKIP_EDILEN_SIFAT.Visible = true;

            GridColumn colTALEP_ADI = new GridColumn();
            colTALEP_ADI.VisibleIndex = 35;
            colTALEP_ADI.FieldName = "TALEP_ADI";
            colTALEP_ADI.Name = "colTALEP_ADI";
            colTALEP_ADI.Visible = true;

            GridColumn colFORM_TIPI = new GridColumn();
            colFORM_TIPI.VisibleIndex = 36;
            colFORM_TIPI.FieldName = "FORM_TIPI";
            colFORM_TIPI.Name = "colFORM_TIPI";
            colFORM_TIPI.Visible = true;

            GridColumn colDURUM = new GridColumn();
            colDURUM.VisibleIndex = 37;
            colDURUM.FieldName = "DURUM";
            colDURUM.Name = "colDURUM";
            colDURUM.Visible = true;

            GridColumn colICRA_ADLIYE = new GridColumn();
            colICRA_ADLIYE.VisibleIndex = 38;
            colICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            colICRA_ADLIYE.Name = "colICRA_ADLIYE";
            colICRA_ADLIYE.Visible = true;

            GridColumn colICRA_BIRIM_NO = new GridColumn();
            colICRA_BIRIM_NO.VisibleIndex = 39;
            colICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            colICRA_BIRIM_NO.Name = "colICRA_BIRIM_NO";
            colICRA_BIRIM_NO.Visible = true;

            GridColumn colOZEL_KOD1 = new GridColumn();
            colOZEL_KOD1.VisibleIndex = 40;
            colOZEL_KOD1.FieldName = "OZEL_KOD1";
            colOZEL_KOD1.Name = "colOZEL_KOD1";
            colOZEL_KOD1.Visible = true;

            GridColumn colOZEL_KOD2 = new GridColumn();
            colOZEL_KOD2.VisibleIndex = 41;
            colOZEL_KOD2.FieldName = "OZEL_KOD2";
            colOZEL_KOD2.Name = "colOZEL_KOD2";
            colOZEL_KOD2.Visible = true;

            GridColumn colOZEL_KOD3 = new GridColumn();
            colOZEL_KOD3.VisibleIndex = 42;
            colOZEL_KOD3.FieldName = "OZEL_KOD3";
            colOZEL_KOD3.Name = "colOZEL_KOD3";
            colOZEL_KOD3.Visible = true;

            GridColumn colOZEL_KOD4 = new GridColumn();
            colOZEL_KOD4.VisibleIndex = 43;
            colOZEL_KOD4.FieldName = "OZEL_KOD4";
            colOZEL_KOD4.Name = "colOZEL_KOD4";
            colOZEL_KOD4.Visible = true;

            GridColumn colFOY_ARSIV_TARIHI = new GridColumn();
            colFOY_ARSIV_TARIHI.VisibleIndex = 44;
            colFOY_ARSIV_TARIHI.FieldName = "FOY_ARSIV_TARIHI";
            colFOY_ARSIV_TARIHI.Name = "colFOY_ARSIV_TARIHI";
            colFOY_ARSIV_TARIHI.Visible = true;

            GridColumn colFOY_INFAZ_TARIHI = new GridColumn();
            colFOY_INFAZ_TARIHI.VisibleIndex = 45;
            colFOY_INFAZ_TARIHI.FieldName = "FOY_INFAZ_TARIHI";
            colFOY_INFAZ_TARIHI.Name = "colFOY_INFAZ_TARIHI";
            colFOY_INFAZ_TARIHI.Visible = true;

            GridColumn colTAKIBIN_MUVEKKILE_IADE_TARIHI = new GridColumn();
            colTAKIBIN_MUVEKKILE_IADE_TARIHI.VisibleIndex = 46;
            colTAKIBIN_MUVEKKILE_IADE_TARIHI.FieldName = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            colTAKIBIN_MUVEKKILE_IADE_TARIHI.Name = "colTAKIBIN_MUVEKKILE_IADE_TARIHI";
            colTAKIBIN_MUVEKKILE_IADE_TARIHI.Visible = true;

            GridColumn colSON_HESAP_TARIHI = new GridColumn();
            colSON_HESAP_TARIHI.VisibleIndex = 47;
            colSON_HESAP_TARIHI.FieldName = "SON_HESAP_TARIHI";
            colSON_HESAP_TARIHI.Name = "colSON_HESAP_TARIHI";
            colSON_HESAP_TARIHI.Visible = true;

            GridColumn colBIR_YIL_KAC_GUN = new GridColumn();
            colBIR_YIL_KAC_GUN.VisibleIndex = 48;
            colBIR_YIL_KAC_GUN.FieldName = "BIR_YIL_KAC_GUN";
            colBIR_YIL_KAC_GUN.Name = "colBIR_YIL_KAC_GUN";
            colBIR_YIL_KAC_GUN.Visible = true;

            GridColumn colBSMV_TO = new GridColumn();
            colBSMV_TO.VisibleIndex = 49;
            colBSMV_TO.FieldName = "BSMV_TO";
            colBSMV_TO.Name = "colBSMV_TO";
            colBSMV_TO.Visible = true;

            GridColumn colBSMV_TO_DOVIZ_ID = new GridColumn();
            colBSMV_TO_DOVIZ_ID.VisibleIndex = 50;
            colBSMV_TO_DOVIZ_ID.FieldName = "BSMV_TO_DOVIZ_ID";
            colBSMV_TO_DOVIZ_ID.Name = "colBSMV_TO_DOVIZ_ID";
            colBSMV_TO_DOVIZ_ID.Visible = true;

            GridColumn colKKDV_TO = new GridColumn();
            colKKDV_TO.VisibleIndex = 51;
            colKKDV_TO.FieldName = "KKDV_TO";
            colKKDV_TO.Name = "colKKDV_TO";
            colKKDV_TO.Visible = true;

            GridColumn colKKDV_TO_DOVIZ_ID = new GridColumn();
            colKKDV_TO_DOVIZ_ID.VisibleIndex = 52;
            colKKDV_TO_DOVIZ_ID.FieldName = "KKDV_TO_DOVIZ_ID";
            colKKDV_TO_DOVIZ_ID.Name = "colKKDV_TO_DOVIZ_ID";
            colKKDV_TO_DOVIZ_ID.Visible = true;

            GridColumn colKDV_TO = new GridColumn();
            colKDV_TO.VisibleIndex = 53;
            colKDV_TO.FieldName = "KDV_TO";
            colKDV_TO.Name = "colKDV_TO";
            colKDV_TO.Visible = true;

            GridColumn colKDV_TO_DOVIZ_ID = new GridColumn();
            colKDV_TO_DOVIZ_ID.VisibleIndex = 54;
            colKDV_TO_DOVIZ_ID.FieldName = "KDV_TO_DOVIZ_ID";
            colKDV_TO_DOVIZ_ID.Name = "colKDV_TO_DOVIZ_ID";
            colKDV_TO_DOVIZ_ID.Visible = true;

            GridColumn colIH_VEKALET_UCRETI = new GridColumn();
            colIH_VEKALET_UCRETI.VisibleIndex = 55;
            colIH_VEKALET_UCRETI.FieldName = "IH_VEKALET_UCRETI";
            colIH_VEKALET_UCRETI.Name = "colIH_VEKALET_UCRETI";
            colIH_VEKALET_UCRETI.Visible = true;

            GridColumn colIH_VEKALET_UCRETI_DOVIZ_ID = new GridColumn();
            colIH_VEKALET_UCRETI_DOVIZ_ID.VisibleIndex = 56;
            colIH_VEKALET_UCRETI_DOVIZ_ID.FieldName = "IH_VEKALET_UCRETI_DOVIZ_ID";
            colIH_VEKALET_UCRETI_DOVIZ_ID.Name = "colIH_VEKALET_UCRETI_DOVIZ_ID";
            colIH_VEKALET_UCRETI_DOVIZ_ID.Visible = true;

            GridColumn colIH_GIDERI = new GridColumn();
            colIH_GIDERI.VisibleIndex = 57;
            colIH_GIDERI.FieldName = "IH_GIDERI";
            colIH_GIDERI.Name = "colIH_GIDERI";
            colIH_GIDERI.Visible = true;

            GridColumn colIH_GIDERI_DOVIZ_ID = new GridColumn();
            colIH_GIDERI_DOVIZ_ID.VisibleIndex = 58;
            colIH_GIDERI_DOVIZ_ID.FieldName = "IH_GIDERI_DOVIZ_ID";
            colIH_GIDERI_DOVIZ_ID.Name = "colIH_GIDERI_DOVIZ_ID";
            colIH_GIDERI_DOVIZ_ID.Visible = true;

            GridColumn colIT_HACIZDE_ODENEN = new GridColumn();
            colIT_HACIZDE_ODENEN.VisibleIndex = 59;
            colIT_HACIZDE_ODENEN.FieldName = "IT_HACIZDE_ODENEN";
            colIT_HACIZDE_ODENEN.Name = "colIT_HACIZDE_ODENEN";
            colIT_HACIZDE_ODENEN.Visible = true;

            GridColumn colIT_HACIZDE_ODENEN_DOVIZ_ID = new GridColumn();
            colIT_HACIZDE_ODENEN_DOVIZ_ID.VisibleIndex = 60;
            colIT_HACIZDE_ODENEN_DOVIZ_ID.FieldName = "IT_HACIZDE_ODENEN_DOVIZ_ID";
            colIT_HACIZDE_ODENEN_DOVIZ_ID.Name = "colIT_HACIZDE_ODENEN_DOVIZ_ID";
            colIT_HACIZDE_ODENEN_DOVIZ_ID.Visible = true;

            GridColumn colKARSILIKSIZ_CEK_TAZMINATI = new GridColumn();
            colKARSILIKSIZ_CEK_TAZMINATI.VisibleIndex = 61;
            colKARSILIKSIZ_CEK_TAZMINATI.FieldName = "KARSILIKSIZ_CEK_TAZMINATI";
            colKARSILIKSIZ_CEK_TAZMINATI.Name = "colKARSILIKSIZ_CEK_TAZMINATI";
            colKARSILIKSIZ_CEK_TAZMINATI.Visible = true;

            GridColumn colKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = new GridColumn();
            colKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.VisibleIndex = 62;
            colKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.FieldName = "KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID";
            colKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.Name = "colKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID";
            colKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.Visible = true;

            GridColumn colCEK_KOMISYONU = new GridColumn();
            colCEK_KOMISYONU.VisibleIndex = 63;
            colCEK_KOMISYONU.FieldName = "CEK_KOMISYONU";
            colCEK_KOMISYONU.Name = "colCEK_KOMISYONU";
            colCEK_KOMISYONU.Visible = true;

            GridColumn colCEK_KOMISYONU_DOVIZ_ID = new GridColumn();
            colCEK_KOMISYONU_DOVIZ_ID.VisibleIndex = 64;
            colCEK_KOMISYONU_DOVIZ_ID.FieldName = "CEK_KOMISYONU_DOVIZ_ID";
            colCEK_KOMISYONU_DOVIZ_ID.Name = "colCEK_KOMISYONU_DOVIZ_ID";
            colCEK_KOMISYONU_DOVIZ_ID.Visible = true;

            GridColumn colILAM_YARGILAMA_GIDERI = new GridColumn();
            colILAM_YARGILAMA_GIDERI.VisibleIndex = 65;
            colILAM_YARGILAMA_GIDERI.FieldName = "ILAM_YARGILAMA_GIDERI";
            colILAM_YARGILAMA_GIDERI.Name = "colILAM_YARGILAMA_GIDERI";
            colILAM_YARGILAMA_GIDERI.Visible = true;

            GridColumn colILAM_YARGILAMA_GIDERI_DOVIZ_ID = new GridColumn();
            colILAM_YARGILAMA_GIDERI_DOVIZ_ID.VisibleIndex = 66;
            colILAM_YARGILAMA_GIDERI_DOVIZ_ID.FieldName = "ILAM_YARGILAMA_GIDERI_DOVIZ_ID";
            colILAM_YARGILAMA_GIDERI_DOVIZ_ID.Name = "colILAM_YARGILAMA_GIDERI_DOVIZ_ID";
            colILAM_YARGILAMA_GIDERI_DOVIZ_ID.Visible = true;

            GridColumn colILAM_BK_YARG_ONAMA = new GridColumn();
            colILAM_BK_YARG_ONAMA.VisibleIndex = 67;
            colILAM_BK_YARG_ONAMA.FieldName = "ILAM_BK_YARG_ONAMA";
            colILAM_BK_YARG_ONAMA.Name = "colILAM_BK_YARG_ONAMA";
            colILAM_BK_YARG_ONAMA.Visible = true;

            GridColumn colILAM_BK_YARG_ONAMA_DOVIZ_ID = new GridColumn();
            colILAM_BK_YARG_ONAMA_DOVIZ_ID.VisibleIndex = 68;
            colILAM_BK_YARG_ONAMA_DOVIZ_ID.FieldName = "ILAM_BK_YARG_ONAMA_DOVIZ_ID";
            colILAM_BK_YARG_ONAMA_DOVIZ_ID.Name = "colILAM_BK_YARG_ONAMA_DOVIZ_ID";
            colILAM_BK_YARG_ONAMA_DOVIZ_ID.Visible = true;

            GridColumn colILAM_TEBLIG_GIDERI = new GridColumn();
            colILAM_TEBLIG_GIDERI.VisibleIndex = 69;
            colILAM_TEBLIG_GIDERI.FieldName = "ILAM_TEBLIG_GIDERI";
            colILAM_TEBLIG_GIDERI.Name = "colILAM_TEBLIG_GIDERI";
            colILAM_TEBLIG_GIDERI.Visible = true;

            GridColumn colILAM_TEBLIG_GIDERI_DOVIZ_ID = new GridColumn();
            colILAM_TEBLIG_GIDERI_DOVIZ_ID.VisibleIndex = 70;
            colILAM_TEBLIG_GIDERI_DOVIZ_ID.FieldName = "ILAM_TEBLIG_GIDERI_DOVIZ_ID";
            colILAM_TEBLIG_GIDERI_DOVIZ_ID.Name = "colILAM_TEBLIG_GIDERI_DOVIZ_ID";
            colILAM_TEBLIG_GIDERI_DOVIZ_ID.Visible = true;

            GridColumn colILAM_INKAR_TAZMINATI = new GridColumn();
            colILAM_INKAR_TAZMINATI.VisibleIndex = 71;
            colILAM_INKAR_TAZMINATI.FieldName = "ILAM_INKAR_TAZMINATI";
            colILAM_INKAR_TAZMINATI.Name = "colILAM_INKAR_TAZMINATI";
            colILAM_INKAR_TAZMINATI.Visible = true;

            GridColumn colILAM_INKAR_TAZMINATI_DOVIZ_ID = new GridColumn();
            colILAM_INKAR_TAZMINATI_DOVIZ_ID.VisibleIndex = 72;
            colILAM_INKAR_TAZMINATI_DOVIZ_ID.FieldName = "ILAM_INKAR_TAZMINATI_DOVIZ_ID";
            colILAM_INKAR_TAZMINATI_DOVIZ_ID.Name = "colILAM_INKAR_TAZMINATI_DOVIZ_ID";
            colILAM_INKAR_TAZMINATI_DOVIZ_ID.Visible = true;

            GridColumn colILAM_VEK_UCR = new GridColumn();
            colILAM_VEK_UCR.VisibleIndex = 73;
            colILAM_VEK_UCR.FieldName = "ILAM_VEK_UCR";
            colILAM_VEK_UCR.Name = "colILAM_VEK_UCR";
            colILAM_VEK_UCR.Visible = true;

            GridColumn colILAM_VEK_UCR_DOVIZ_ID = new GridColumn();
            colILAM_VEK_UCR_DOVIZ_ID.VisibleIndex = 74;
            colILAM_VEK_UCR_DOVIZ_ID.FieldName = "ILAM_VEK_UCR_DOVIZ_ID";
            colILAM_VEK_UCR_DOVIZ_ID.Name = "colILAM_VEK_UCR_DOVIZ_ID";
            colILAM_VEK_UCR_DOVIZ_ID.Visible = true;

            GridColumn colOIV_TO = new GridColumn();
            colOIV_TO.VisibleIndex = 75;
            colOIV_TO.FieldName = "OIV_TO";
            colOIV_TO.Name = "colOIV_TO";
            colOIV_TO.Visible = true;

            GridColumn colOIV_TO_DOVIZ_ID = new GridColumn();
            colOIV_TO_DOVIZ_ID.VisibleIndex = 76;
            colOIV_TO_DOVIZ_ID.FieldName = "OIV_TO_DOVIZ_ID";
            colOIV_TO_DOVIZ_ID.Name = "colOIV_TO_DOVIZ_ID";
            colOIV_TO_DOVIZ_ID.Visible = true;

            GridColumn colPROTESTO_GIDERI = new GridColumn();
            colPROTESTO_GIDERI.VisibleIndex = 77;
            colPROTESTO_GIDERI.FieldName = "PROTESTO_GIDERI";
            colPROTESTO_GIDERI.Name = "colPROTESTO_GIDERI";
            colPROTESTO_GIDERI.Visible = true;

            GridColumn colPROTESTO_GIDERI_DOVIZ_ID = new GridColumn();
            colPROTESTO_GIDERI_DOVIZ_ID.VisibleIndex = 78;
            colPROTESTO_GIDERI_DOVIZ_ID.FieldName = "PROTESTO_GIDERI_DOVIZ_ID";
            colPROTESTO_GIDERI_DOVIZ_ID.Name = "colPROTESTO_GIDERI_DOVIZ_ID";
            colPROTESTO_GIDERI_DOVIZ_ID.Visible = true;

            GridColumn colIHTAR_GIDERI = new GridColumn();
            colIHTAR_GIDERI.VisibleIndex = 79;
            colIHTAR_GIDERI.FieldName = "IHTAR_GIDERI";
            colIHTAR_GIDERI.Name = "colIHTAR_GIDERI";
            colIHTAR_GIDERI.Visible = true;

            GridColumn colIHTAR_GIDERI_DOVIZ_ID = new GridColumn();
            colIHTAR_GIDERI_DOVIZ_ID.VisibleIndex = 80;
            colIHTAR_GIDERI_DOVIZ_ID.FieldName = "IHTAR_GIDERI_DOVIZ_ID";
            colIHTAR_GIDERI_DOVIZ_ID.Name = "colIHTAR_GIDERI_DOVIZ_ID";
            colIHTAR_GIDERI_DOVIZ_ID.Visible = true;

            GridColumn colOZEL_TAZMINAT = new GridColumn();
            colOZEL_TAZMINAT.VisibleIndex = 81;
            colOZEL_TAZMINAT.FieldName = "OZEL_TAZMINAT";
            colOZEL_TAZMINAT.Name = "colOZEL_TAZMINAT";
            colOZEL_TAZMINAT.Visible = true;

            GridColumn colOZEL_TAZMINAT_DOVIZ_ID = new GridColumn();
            colOZEL_TAZMINAT_DOVIZ_ID.VisibleIndex = 82;
            colOZEL_TAZMINAT_DOVIZ_ID.FieldName = "OZEL_TAZMINAT_DOVIZ_ID";
            colOZEL_TAZMINAT_DOVIZ_ID.Name = "colOZEL_TAZMINAT_DOVIZ_ID";
            colOZEL_TAZMINAT_DOVIZ_ID.Visible = true;

            GridColumn colOZEL_TUTAR1_FAIZ_ORANI = new GridColumn();
            colOZEL_TUTAR1_FAIZ_ORANI.VisibleIndex = 83;
            colOZEL_TUTAR1_FAIZ_ORANI.FieldName = "OZEL_TUTAR1_FAIZ_ORANI";
            colOZEL_TUTAR1_FAIZ_ORANI.Name = "colOZEL_TUTAR1_FAIZ_ORANI";
            colOZEL_TUTAR1_FAIZ_ORANI.Visible = true;

            GridColumn colOZEL_TUTAR_KONU1 = new GridColumn();
            colOZEL_TUTAR_KONU1.VisibleIndex = 84;
            colOZEL_TUTAR_KONU1.FieldName = "OZEL_TUTAR_KONU1";
            colOZEL_TUTAR_KONU1.Name = "colOZEL_TUTAR_KONU1";
            colOZEL_TUTAR_KONU1.Visible = true;

            GridColumn colOZEL_TUTAR_KONU2 = new GridColumn();
            colOZEL_TUTAR_KONU2.VisibleIndex = 85;
            colOZEL_TUTAR_KONU2.FieldName = "OZEL_TUTAR_KONU2";
            colOZEL_TUTAR_KONU2.Name = "colOZEL_TUTAR_KONU2";
            colOZEL_TUTAR_KONU2.Visible = true;

            GridColumn colOZEL_TUTAR_KONU3 = new GridColumn();
            colOZEL_TUTAR_KONU3.VisibleIndex = 86;
            colOZEL_TUTAR_KONU3.FieldName = "OZEL_TUTAR_KONU3";
            colOZEL_TUTAR_KONU3.Name = "colOZEL_TUTAR_KONU3";
            colOZEL_TUTAR_KONU3.Visible = true;

            GridColumn colOZEL_TUTAR1 = new GridColumn();
            colOZEL_TUTAR1.VisibleIndex = 87;
            colOZEL_TUTAR1.FieldName = "OZEL_TUTAR1";
            colOZEL_TUTAR1.Name = "colOZEL_TUTAR1";
            colOZEL_TUTAR1.Visible = true;

            GridColumn colOZEL_TUTAR1_DOVIZ_ID = new GridColumn();
            colOZEL_TUTAR1_DOVIZ_ID.VisibleIndex = 88;
            colOZEL_TUTAR1_DOVIZ_ID.FieldName = "OZEL_TUTAR1_DOVIZ_ID";
            colOZEL_TUTAR1_DOVIZ_ID.Name = "colOZEL_TUTAR1_DOVIZ_ID";
            colOZEL_TUTAR1_DOVIZ_ID.Visible = true;

            GridColumn colOZEL_TUTAR2 = new GridColumn();
            colOZEL_TUTAR2.VisibleIndex = 89;
            colOZEL_TUTAR2.FieldName = "OZEL_TUTAR2";
            colOZEL_TUTAR2.Name = "colOZEL_TUTAR2";
            colOZEL_TUTAR2.Visible = true;

            GridColumn colOZEL_TUTAR2_DOVIZ_ID = new GridColumn();
            colOZEL_TUTAR2_DOVIZ_ID.VisibleIndex = 90;
            colOZEL_TUTAR2_DOVIZ_ID.FieldName = "OZEL_TUTAR2_DOVIZ_ID";
            colOZEL_TUTAR2_DOVIZ_ID.Name = "colOZEL_TUTAR2_DOVIZ_ID";
            colOZEL_TUTAR2_DOVIZ_ID.Visible = true;

            GridColumn colOZEL_TUTAR3 = new GridColumn();
            colOZEL_TUTAR3.VisibleIndex = 91;
            colOZEL_TUTAR3.FieldName = "OZEL_TUTAR3";
            colOZEL_TUTAR3.Name = "colOZEL_TUTAR3";
            colOZEL_TUTAR3.Visible = true;

            GridColumn colOZEL_TUTAR3_DOVIZ_ID = new GridColumn();
            colOZEL_TUTAR3_DOVIZ_ID.VisibleIndex = 92;
            colOZEL_TUTAR3_DOVIZ_ID.FieldName = "OZEL_TUTAR3_DOVIZ_ID";
            colOZEL_TUTAR3_DOVIZ_ID.Name = "colOZEL_TUTAR3_DOVIZ_ID";
            colOZEL_TUTAR3_DOVIZ_ID.Visible = true;

            GridColumn colSONRAKI_TAZMINAT = new GridColumn();
            colSONRAKI_TAZMINAT.VisibleIndex = 93;
            colSONRAKI_TAZMINAT.FieldName = "SONRAKI_TAZMINAT";
            colSONRAKI_TAZMINAT.Name = "colSONRAKI_TAZMINAT";
            colSONRAKI_TAZMINAT.Visible = true;

            GridColumn colSONRAKI_TAZMINAT_DOVIZ_ID = new GridColumn();
            colSONRAKI_TAZMINAT_DOVIZ_ID.VisibleIndex = 94;
            colSONRAKI_TAZMINAT_DOVIZ_ID.FieldName = "SONRAKI_TAZMINAT_DOVIZ_ID";
            colSONRAKI_TAZMINAT_DOVIZ_ID.Name = "colSONRAKI_TAZMINAT_DOVIZ_ID";
            colSONRAKI_TAZMINAT_DOVIZ_ID.Visible = true;

            GridColumn colBSMV_TS = new GridColumn();
            colBSMV_TS.VisibleIndex = 95;
            colBSMV_TS.FieldName = "BSMV_TS";
            colBSMV_TS.Name = "colBSMV_TS";
            colBSMV_TS.Visible = true;

            GridColumn colBSMV_TS_DOVIZ_ID = new GridColumn();
            colBSMV_TS_DOVIZ_ID.VisibleIndex = 96;
            colBSMV_TS_DOVIZ_ID.FieldName = "BSMV_TS_DOVIZ_ID";
            colBSMV_TS_DOVIZ_ID.Name = "colBSMV_TS_DOVIZ_ID";
            colBSMV_TS_DOVIZ_ID.Visible = true;

            GridColumn colOIV_TS = new GridColumn();
            colOIV_TS.VisibleIndex = 97;
            colOIV_TS.FieldName = "OIV_TS";
            colOIV_TS.Name = "colOIV_TS";
            colOIV_TS.Visible = true;

            GridColumn colOIV_TS_DOVIZ_ID = new GridColumn();
            colOIV_TS_DOVIZ_ID.VisibleIndex = 98;
            colOIV_TS_DOVIZ_ID.FieldName = "OIV_TS_DOVIZ_ID";
            colOIV_TS_DOVIZ_ID.Name = "colOIV_TS_DOVIZ_ID";
            colOIV_TS_DOVIZ_ID.Visible = true;

            GridColumn colKDV_TS = new GridColumn();
            colKDV_TS.VisibleIndex = 99;
            colKDV_TS.FieldName = "KDV_TS";
            colKDV_TS.Name = "colKDV_TS";
            colKDV_TS.Visible = true;

            GridColumn colKDV_TS_DOVIZ_ID = new GridColumn();
            colKDV_TS_DOVIZ_ID.VisibleIndex = 100;
            colKDV_TS_DOVIZ_ID.FieldName = "KDV_TS_DOVIZ_ID";
            colKDV_TS_DOVIZ_ID.Name = "colKDV_TS_DOVIZ_ID";
            colKDV_TS_DOVIZ_ID.Visible = true;

            GridColumn colILK_GIDERLER = new GridColumn();
            colILK_GIDERLER.VisibleIndex = 101;
            colILK_GIDERLER.FieldName = "ILK_GIDERLER";
            colILK_GIDERLER.Name = "colILK_GIDERLER";
            colILK_GIDERLER.Visible = true;

            GridColumn colILK_GIDERLER_DOVIZ_ID = new GridColumn();
            colILK_GIDERLER_DOVIZ_ID.VisibleIndex = 102;
            colILK_GIDERLER_DOVIZ_ID.FieldName = "ILK_GIDERLER_DOVIZ_ID";
            colILK_GIDERLER_DOVIZ_ID.Name = "colILK_GIDERLER_DOVIZ_ID";
            colILK_GIDERLER_DOVIZ_ID.Visible = true;

            GridColumn colPESIN_HARC = new GridColumn();
            colPESIN_HARC.VisibleIndex = 103;
            colPESIN_HARC.FieldName = "PESIN_HARC";
            colPESIN_HARC.Name = "colPESIN_HARC";
            colPESIN_HARC.Visible = true;

            GridColumn colPESIN_HARC_DOVIZ_ID = new GridColumn();
            colPESIN_HARC_DOVIZ_ID.VisibleIndex = 104;
            colPESIN_HARC_DOVIZ_ID.FieldName = "PESIN_HARC_DOVIZ_ID";
            colPESIN_HARC_DOVIZ_ID.Name = "colPESIN_HARC_DOVIZ_ID";
            colPESIN_HARC_DOVIZ_ID.Visible = true;

            GridColumn colODENEN_TAHSIL_HARCI = new GridColumn();
            colODENEN_TAHSIL_HARCI.VisibleIndex = 105;
            colODENEN_TAHSIL_HARCI.FieldName = "ODENEN_TAHSIL_HARCI";
            colODENEN_TAHSIL_HARCI.Name = "colODENEN_TAHSIL_HARCI";
            colODENEN_TAHSIL_HARCI.Visible = true;

            GridColumn colODENEN_TAHSIL_HARCI_DOVIZ_ID = new GridColumn();
            colODENEN_TAHSIL_HARCI_DOVIZ_ID.VisibleIndex = 106;
            colODENEN_TAHSIL_HARCI_DOVIZ_ID.FieldName = "ODENEN_TAHSIL_HARCI_DOVIZ_ID";
            colODENEN_TAHSIL_HARCI_DOVIZ_ID.Name = "colODENEN_TAHSIL_HARCI_DOVIZ_ID";
            colODENEN_TAHSIL_HARCI_DOVIZ_ID.Visible = true;

            GridColumn colKALAN_TAHSIL_HARCI = new GridColumn();
            colKALAN_TAHSIL_HARCI.VisibleIndex = 107;
            colKALAN_TAHSIL_HARCI.FieldName = "KALAN_TAHSIL_HARCI";
            colKALAN_TAHSIL_HARCI.Name = "colKALAN_TAHSIL_HARCI";
            colKALAN_TAHSIL_HARCI.Visible = true;

            GridColumn colKALAN_TAHSIL_HARCI_DOVIZ_ID = new GridColumn();
            colKALAN_TAHSIL_HARCI_DOVIZ_ID.VisibleIndex = 108;
            colKALAN_TAHSIL_HARCI_DOVIZ_ID.FieldName = "KALAN_TAHSIL_HARCI_DOVIZ_ID";
            colKALAN_TAHSIL_HARCI_DOVIZ_ID.Name = "colKALAN_TAHSIL_HARCI_DOVIZ_ID";
            colKALAN_TAHSIL_HARCI_DOVIZ_ID.Visible = true;

            GridColumn colMASAYA_KATILMA_HARCI = new GridColumn();
            colMASAYA_KATILMA_HARCI.VisibleIndex = 109;
            colMASAYA_KATILMA_HARCI.FieldName = "MASAYA_KATILMA_HARCI";
            colMASAYA_KATILMA_HARCI.Name = "colMASAYA_KATILMA_HARCI";
            colMASAYA_KATILMA_HARCI.Visible = true;

            GridColumn colMASAYA_KATILMA_HARCI_DOVIZ_ID = new GridColumn();
            colMASAYA_KATILMA_HARCI_DOVIZ_ID.VisibleIndex = 110;
            colMASAYA_KATILMA_HARCI_DOVIZ_ID.FieldName = "MASAYA_KATILMA_HARCI_DOVIZ_ID";
            colMASAYA_KATILMA_HARCI_DOVIZ_ID.Name = "colMASAYA_KATILMA_HARCI_DOVIZ_ID";
            colMASAYA_KATILMA_HARCI_DOVIZ_ID.Visible = true;

            GridColumn colPAYLASMA_HARCI = new GridColumn();
            colPAYLASMA_HARCI.VisibleIndex = 111;
            colPAYLASMA_HARCI.FieldName = "PAYLASMA_HARCI";
            colPAYLASMA_HARCI.Name = "colPAYLASMA_HARCI";
            colPAYLASMA_HARCI.Visible = true;

            GridColumn colPAYLASMA_HARCI_DOVIZ_ID = new GridColumn();
            colPAYLASMA_HARCI_DOVIZ_ID.VisibleIndex = 112;
            colPAYLASMA_HARCI_DOVIZ_ID.FieldName = "PAYLASMA_HARCI_DOVIZ_ID";
            colPAYLASMA_HARCI_DOVIZ_ID.Name = "colPAYLASMA_HARCI_DOVIZ_ID";
            colPAYLASMA_HARCI_DOVIZ_ID.Visible = true;

            GridColumn colDAVA_GIDERLERI = new GridColumn();
            colDAVA_GIDERLERI.VisibleIndex = 113;
            colDAVA_GIDERLERI.FieldName = "DAVA_GIDERLERI";
            colDAVA_GIDERLERI.Name = "colDAVA_GIDERLERI";
            colDAVA_GIDERLERI.Visible = true;

            GridColumn colDAVA_GIDERLERI_DOVIZ_ID = new GridColumn();
            colDAVA_GIDERLERI_DOVIZ_ID.VisibleIndex = 114;
            colDAVA_GIDERLERI_DOVIZ_ID.FieldName = "DAVA_GIDERLERI_DOVIZ_ID";
            colDAVA_GIDERLERI_DOVIZ_ID.Name = "colDAVA_GIDERLERI_DOVIZ_ID";
            colDAVA_GIDERLERI_DOVIZ_ID.Visible = true;

            GridColumn colDIGER_GIDERLER = new GridColumn();
            colDIGER_GIDERLER.VisibleIndex = 115;
            colDIGER_GIDERLER.FieldName = "DIGER_GIDERLER";
            colDIGER_GIDERLER.Name = "colDIGER_GIDERLER";
            colDIGER_GIDERLER.Visible = true;

            GridColumn colDIGER_GIDERLER_DOVIZ_ID = new GridColumn();
            colDIGER_GIDERLER_DOVIZ_ID.VisibleIndex = 116;
            colDIGER_GIDERLER_DOVIZ_ID.FieldName = "DIGER_GIDERLER_DOVIZ_ID";
            colDIGER_GIDERLER_DOVIZ_ID.Name = "colDIGER_GIDERLER_DOVIZ_ID";
            colDIGER_GIDERLER_DOVIZ_ID.Visible = true;

            GridColumn colTAKIP_VEKALET_UCRETI = new GridColumn();
            colTAKIP_VEKALET_UCRETI.VisibleIndex = 117;
            colTAKIP_VEKALET_UCRETI.FieldName = "TAKIP_VEKALET_UCRETI";
            colTAKIP_VEKALET_UCRETI.Name = "colTAKIP_VEKALET_UCRETI";
            colTAKIP_VEKALET_UCRETI.Visible = true;

            GridColumn colTAKIP_VEKALET_UCRETI_DOVIZ_ID = new GridColumn();
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.VisibleIndex = 118;
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.FieldName = "TAKIP_VEKALET_UCRETI_DOVIZ_ID";
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.Name = "colTAKIP_VEKALET_UCRETI_DOVIZ_ID";
            colTAKIP_VEKALET_UCRETI_DOVIZ_ID.Visible = true;

            GridColumn colTAKIP_VEKALET_UCRETI_KATSAYI = new GridColumn();
            colTAKIP_VEKALET_UCRETI_KATSAYI.VisibleIndex = 119;
            colTAKIP_VEKALET_UCRETI_KATSAYI.FieldName = "TAKIP_VEKALET_UCRETI_KATSAYI";
            colTAKIP_VEKALET_UCRETI_KATSAYI.Name = "colTAKIP_VEKALET_UCRETI_KATSAYI";
            colTAKIP_VEKALET_UCRETI_KATSAYI.Visible = true;

            GridColumn colDAVA_INKAR_TAZMINATI = new GridColumn();
            colDAVA_INKAR_TAZMINATI.VisibleIndex = 120;
            colDAVA_INKAR_TAZMINATI.FieldName = "DAVA_INKAR_TAZMINATI";
            colDAVA_INKAR_TAZMINATI.Name = "colDAVA_INKAR_TAZMINATI";
            colDAVA_INKAR_TAZMINATI.Visible = true;

            GridColumn colDAVA_INKAR_TAZMINATI_DOVIZ_ID = new GridColumn();
            colDAVA_INKAR_TAZMINATI_DOVIZ_ID.VisibleIndex = 121;
            colDAVA_INKAR_TAZMINATI_DOVIZ_ID.FieldName = "DAVA_INKAR_TAZMINATI_DOVIZ_ID";
            colDAVA_INKAR_TAZMINATI_DOVIZ_ID.Name = "colDAVA_INKAR_TAZMINATI_DOVIZ_ID";
            colDAVA_INKAR_TAZMINATI_DOVIZ_ID.Visible = true;

            GridColumn colDAVA_VEKALET_UCRETI = new GridColumn();
            colDAVA_VEKALET_UCRETI.VisibleIndex = 122;
            colDAVA_VEKALET_UCRETI.FieldName = "DAVA_VEKALET_UCRETI";
            colDAVA_VEKALET_UCRETI.Name = "colDAVA_VEKALET_UCRETI";
            colDAVA_VEKALET_UCRETI.Visible = true;

            GridColumn colDAVA_VEKALET_UCRETI_DOVIZ_ID = new GridColumn();
            colDAVA_VEKALET_UCRETI_DOVIZ_ID.VisibleIndex = 123;
            colDAVA_VEKALET_UCRETI_DOVIZ_ID.FieldName = "DAVA_VEKALET_UCRETI_DOVIZ_ID";
            colDAVA_VEKALET_UCRETI_DOVIZ_ID.Name = "colDAVA_VEKALET_UCRETI_DOVIZ_ID";
            colDAVA_VEKALET_UCRETI_DOVIZ_ID.Visible = true;

            GridColumn colMAHSUP_TOPLAMI = new GridColumn();
            colMAHSUP_TOPLAMI.VisibleIndex = 124;
            colMAHSUP_TOPLAMI.FieldName = "MAHSUP_TOPLAMI";
            colMAHSUP_TOPLAMI.Name = "colMAHSUP_TOPLAMI";
            colMAHSUP_TOPLAMI.Visible = true;

            GridColumn colMAHSUP_TOPLAMI_DOVIZ_ID = new GridColumn();
            colMAHSUP_TOPLAMI_DOVIZ_ID.VisibleIndex = 125;
            colMAHSUP_TOPLAMI_DOVIZ_ID.FieldName = "MAHSUP_TOPLAMI_DOVIZ_ID";
            colMAHSUP_TOPLAMI_DOVIZ_ID.Name = "colMAHSUP_TOPLAMI_DOVIZ_ID";
            colMAHSUP_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colFERAGAT_TOPLAMI = new GridColumn();
            colFERAGAT_TOPLAMI.VisibleIndex = 126;
            colFERAGAT_TOPLAMI.FieldName = "FERAGAT_TOPLAMI";
            colFERAGAT_TOPLAMI.Name = "colFERAGAT_TOPLAMI";
            colFERAGAT_TOPLAMI.Visible = true;

            GridColumn colFERAGAT_TOPLAMI_DOVIZ_ID = new GridColumn();
            colFERAGAT_TOPLAMI_DOVIZ_ID.VisibleIndex = 127;
            colFERAGAT_TOPLAMI_DOVIZ_ID.FieldName = "FERAGAT_TOPLAMI_DOVIZ_ID";
            colFERAGAT_TOPLAMI_DOVIZ_ID.Name = "colFERAGAT_TOPLAMI_DOVIZ_ID";
            colFERAGAT_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colALACAK_TOPLAMI = new GridColumn();
            colALACAK_TOPLAMI.VisibleIndex = 128;
            colALACAK_TOPLAMI.FieldName = "ALACAK_TOPLAMI";
            colALACAK_TOPLAMI.Name = "colALACAK_TOPLAMI";
            colALACAK_TOPLAMI.Visible = true;

            GridColumn colALACAK_TOPLAMI_DOVIZ_ID = new GridColumn();
            colALACAK_TOPLAMI_DOVIZ_ID.VisibleIndex = 129;
            colALACAK_TOPLAMI_DOVIZ_ID.FieldName = "ALACAK_TOPLAMI_DOVIZ_ID";
            colALACAK_TOPLAMI_DOVIZ_ID.Name = "colALACAK_TOPLAMI_DOVIZ_ID";
            colALACAK_TOPLAMI_DOVIZ_ID.Visible = true;

            GridColumn colTAHLIYE_VEK_UCR = new GridColumn();
            colTAHLIYE_VEK_UCR.VisibleIndex = 130;
            colTAHLIYE_VEK_UCR.FieldName = "TAHLIYE_VEK_UCR";
            colTAHLIYE_VEK_UCR.Name = "colTAHLIYE_VEK_UCR";
            colTAHLIYE_VEK_UCR.Visible = true;

            GridColumn colTAHLIYE_VEK_UCR_DOVIZ_ID = new GridColumn();
            colTAHLIYE_VEK_UCR_DOVIZ_ID.VisibleIndex = 131;
            colTAHLIYE_VEK_UCR_DOVIZ_ID.FieldName = "TAHLIYE_VEK_UCR_DOVIZ_ID";
            colTAHLIYE_VEK_UCR_DOVIZ_ID.Name = "colTAHLIYE_VEK_UCR_DOVIZ_ID";
            colTAHLIYE_VEK_UCR_DOVIZ_ID.Visible = true;

            GridColumn colDIGER_HARC = new GridColumn();
            colDIGER_HARC.VisibleIndex = 132;
            colDIGER_HARC.FieldName = "DIGER_HARC";
            colDIGER_HARC.Name = "colDIGER_HARC";
            colDIGER_HARC.Visible = true;

            GridColumn colDIGER_HARC_DOVIZ_ID = new GridColumn();
            colDIGER_HARC_DOVIZ_ID.VisibleIndex = 133;
            colDIGER_HARC_DOVIZ_ID.FieldName = "DIGER_HARC_DOVIZ_ID";
            colDIGER_HARC_DOVIZ_ID.Name = "colDIGER_HARC_DOVIZ_ID";
            colDIGER_HARC_DOVIZ_ID.Visible = true;

            GridColumn colTD_GIDERI = new GridColumn();
            colTD_GIDERI.VisibleIndex = 134;
            colTD_GIDERI.FieldName = "TD_GIDERI";
            colTD_GIDERI.Name = "colTD_GIDERI";
            colTD_GIDERI.Visible = true;

            GridColumn colTD_GIDERI_DOVIZ_ID = new GridColumn();
            colTD_GIDERI_DOVIZ_ID.VisibleIndex = 135;
            colTD_GIDERI_DOVIZ_ID.FieldName = "TD_GIDERI_DOVIZ_ID";
            colTD_GIDERI_DOVIZ_ID.Name = "colTD_GIDERI_DOVIZ_ID";
            colTD_GIDERI_DOVIZ_ID.Visible = true;

            GridColumn colTD_BAKIYE_HARC = new GridColumn();
            colTD_BAKIYE_HARC.VisibleIndex = 136;
            colTD_BAKIYE_HARC.FieldName = "TD_BAKIYE_HARC";
            colTD_BAKIYE_HARC.Name = "colTD_BAKIYE_HARC";
            colTD_BAKIYE_HARC.Visible = true;

            GridColumn colTD_BAKIYE_HARC_DOVIZ_ID = new GridColumn();
            colTD_BAKIYE_HARC_DOVIZ_ID.VisibleIndex = 137;
            colTD_BAKIYE_HARC_DOVIZ_ID.FieldName = "TD_BAKIYE_HARC_DOVIZ_ID";
            colTD_BAKIYE_HARC_DOVIZ_ID.Name = "colTD_BAKIYE_HARC_DOVIZ_ID";
            colTD_BAKIYE_HARC_DOVIZ_ID.Visible = true;

            GridColumn colTD_VEK_UCR = new GridColumn();
            colTD_VEK_UCR.VisibleIndex = 138;
            colTD_VEK_UCR.FieldName = "TD_VEK_UCR";
            colTD_VEK_UCR.Name = "colTD_VEK_UCR";
            colTD_VEK_UCR.Visible = true;

            GridColumn colTD_VEK_UCR_DOVIZ_ID = new GridColumn();
            colTD_VEK_UCR_DOVIZ_ID.VisibleIndex = 139;
            colTD_VEK_UCR_DOVIZ_ID.FieldName = "TD_VEK_UCR_DOVIZ_ID";
            colTD_VEK_UCR_DOVIZ_ID.Name = "colTD_VEK_UCR_DOVIZ_ID";
            colTD_VEK_UCR_DOVIZ_ID.Visible = true;

            GridColumn colTD_TEBLIG_GIDERI = new GridColumn();
            colTD_TEBLIG_GIDERI.VisibleIndex = 140;
            colTD_TEBLIG_GIDERI.FieldName = "TD_TEBLIG_GIDERI";
            colTD_TEBLIG_GIDERI.Name = "colTD_TEBLIG_GIDERI";
            colTD_TEBLIG_GIDERI.Visible = true;

            GridColumn colTD_TEBLIG_GIDERI_DOVIZ_ID = new GridColumn();
            colTD_TEBLIG_GIDERI_DOVIZ_ID.VisibleIndex = 141;
            colTD_TEBLIG_GIDERI_DOVIZ_ID.FieldName = "TD_TEBLIG_GIDERI_DOVIZ_ID";
            colTD_TEBLIG_GIDERI_DOVIZ_ID.Name = "colTD_TEBLIG_GIDERI_DOVIZ_ID";
            colTD_TEBLIG_GIDERI_DOVIZ_ID.Visible = true;

            GridColumn colBIRIKMIS_NAFAKA = new GridColumn();
            colBIRIKMIS_NAFAKA.VisibleIndex = 142;
            colBIRIKMIS_NAFAKA.FieldName = "BIRIKMIS_NAFAKA";
            colBIRIKMIS_NAFAKA.Name = "colBIRIKMIS_NAFAKA";
            colBIRIKMIS_NAFAKA.Visible = true;

            GridColumn colBIRIKMIS_NAFAKA_DOVIZ_ID = new GridColumn();
            colBIRIKMIS_NAFAKA_DOVIZ_ID.VisibleIndex = 143;
            colBIRIKMIS_NAFAKA_DOVIZ_ID.FieldName = "BIRIKMIS_NAFAKA_DOVIZ_ID";
            colBIRIKMIS_NAFAKA_DOVIZ_ID.Name = "colBIRIKMIS_NAFAKA_DOVIZ_ID";
            colBIRIKMIS_NAFAKA_DOVIZ_ID.Visible = true;

            GridColumn colICRA_INKAR_TAZMINATI = new GridColumn();
            colICRA_INKAR_TAZMINATI.VisibleIndex = 144;
            colICRA_INKAR_TAZMINATI.FieldName = "ICRA_INKAR_TAZMINATI";
            colICRA_INKAR_TAZMINATI.Name = "colICRA_INKAR_TAZMINATI";
            colICRA_INKAR_TAZMINATI.Visible = true;

            GridColumn colICRA_INKAR_TAZMINATI_DOVIZ_ID = new GridColumn();
            colICRA_INKAR_TAZMINATI_DOVIZ_ID.VisibleIndex = 145;
            colICRA_INKAR_TAZMINATI_DOVIZ_ID.FieldName = "ICRA_INKAR_TAZMINATI_DOVIZ_ID";
            colICRA_INKAR_TAZMINATI_DOVIZ_ID.Name = "colICRA_INKAR_TAZMINATI_DOVIZ_ID";
            colICRA_INKAR_TAZMINATI_DOVIZ_ID.Visible = true;

            GridColumn colDAMGA_PULU = new GridColumn();
            colDAMGA_PULU.VisibleIndex = 146;
            colDAMGA_PULU.FieldName = "DAMGA_PULU";
            colDAMGA_PULU.Name = "colDAMGA_PULU";
            colDAMGA_PULU.Visible = true;

            GridColumn colDAMGA_PULU_DOVIZ_ID = new GridColumn();
            colDAMGA_PULU_DOVIZ_ID.VisibleIndex = 147;
            colDAMGA_PULU_DOVIZ_ID.FieldName = "DAMGA_PULU_DOVIZ_ID";
            colDAMGA_PULU_DOVIZ_ID.Name = "colDAMGA_PULU_DOVIZ_ID";
            colDAMGA_PULU_DOVIZ_ID.Visible = true;

            GridColumn colPROTOKOL_MIKTARI = new GridColumn();
            colPROTOKOL_MIKTARI.VisibleIndex = 148;
            colPROTOKOL_MIKTARI.FieldName = "PROTOKOL_MIKTARI";
            colPROTOKOL_MIKTARI.Name = "colPROTOKOL_MIKTARI";
            colPROTOKOL_MIKTARI.Visible = true;

            GridColumn colPROTOKOL_MIKTARI_DOVIZ_ID = new GridColumn();
            colPROTOKOL_MIKTARI_DOVIZ_ID.VisibleIndex = 149;
            colPROTOKOL_MIKTARI_DOVIZ_ID.FieldName = "PROTOKOL_MIKTARI_DOVIZ_ID";
            colPROTOKOL_MIKTARI_DOVIZ_ID.Name = "colPROTOKOL_MIKTARI_DOVIZ_ID";
            colPROTOKOL_MIKTARI_DOVIZ_ID.Visible = true;

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

            GridColumn colKARSILIK_TUTARI = new GridColumn();
            colKARSILIK_TUTARI.VisibleIndex = 152;
            colKARSILIK_TUTARI.FieldName = "KARSILIK_TUTARI";
            colKARSILIK_TUTARI.Name = "colKARSILIK_TUTARI";
            colKARSILIK_TUTARI.Visible = true;

            GridColumn colKARSILIK_TUTARI_DOVIZ_ID = new GridColumn();
            colKARSILIK_TUTARI_DOVIZ_ID.VisibleIndex = 153;
            colKARSILIK_TUTARI_DOVIZ_ID.FieldName = "KARSILIK_TUTARI_DOVIZ_ID";
            colKARSILIK_TUTARI_DOVIZ_ID.Name = "colKARSILIK_TUTARI_DOVIZ_ID";
            colKARSILIK_TUTARI_DOVIZ_ID.Visible = true;

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

            GridColumn colTO_VEKALET_TOPLAMI = new GridColumn();
            colTO_VEKALET_TOPLAMI.VisibleIndex = 162;
            colTO_VEKALET_TOPLAMI.FieldName = "TO_VEKALET_TOPLAMI";
            colTO_VEKALET_TOPLAMI.Name = "colTO_VEKALET_TOPLAMI";
            colTO_VEKALET_TOPLAMI.Visible = true;

            GridColumn colTO_VEKALET_TOPLAMI_DOVIZ_ID = new GridColumn();
            colTO_VEKALET_TOPLAMI_DOVIZ_ID.VisibleIndex = 163;
            colTO_VEKALET_TOPLAMI_DOVIZ_ID.FieldName = "TO_VEKALET_TOPLAMI_DOVIZ_ID";
            colTO_VEKALET_TOPLAMI_DOVIZ_ID.Name = "colTO_VEKALET_TOPLAMI_DOVIZ_ID";
            colTO_VEKALET_TOPLAMI_DOVIZ_ID.Visible = true;

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

            GridColumn colIT_VEKALET_UCRETI = new GridColumn();
            colIT_VEKALET_UCRETI.VisibleIndex = 174;
            colIT_VEKALET_UCRETI.FieldName = "IT_VEKALET_UCRETI";
            colIT_VEKALET_UCRETI.Name = "colIT_VEKALET_UCRETI";
            colIT_VEKALET_UCRETI.Visible = true;

            GridColumn colIT_VEKALET_UCRETI_DOVIZ_ID = new GridColumn();
            colIT_VEKALET_UCRETI_DOVIZ_ID.VisibleIndex = 175;
            colIT_VEKALET_UCRETI_DOVIZ_ID.FieldName = "IT_VEKALET_UCRETI_DOVIZ_ID";
            colIT_VEKALET_UCRETI_DOVIZ_ID.Name = "colIT_VEKALET_UCRETI_DOVIZ_ID";
            colIT_VEKALET_UCRETI_DOVIZ_ID.Visible = true;

            GridColumn colIT_GIDERI = new GridColumn();
            colIT_GIDERI.VisibleIndex = 176;
            colIT_GIDERI.FieldName = "IT_GIDERI";
            colIT_GIDERI.Name = "colIT_GIDERI";
            colIT_GIDERI.Visible = true;

            GridColumn colIT_GIDERI_DOVIZ_ID = new GridColumn();
            colIT_GIDERI_DOVIZ_ID.VisibleIndex = 177;
            colIT_GIDERI_DOVIZ_ID.FieldName = "IT_GIDERI_DOVIZ_ID";
            colIT_GIDERI_DOVIZ_ID.Name = "colIT_GIDERI_DOVIZ_ID";
            colIT_GIDERI_DOVIZ_ID.Visible = true;

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

            GridColumn colBASVURMA_HARCI = new GridColumn();
            colBASVURMA_HARCI.VisibleIndex = 181;
            colBASVURMA_HARCI.FieldName = "BASVURMA_HARCI";
            colBASVURMA_HARCI.Name = "colBASVURMA_HARCI";
            colBASVURMA_HARCI.Visible = true;

            GridColumn colBASVURMA_HARCI_DOVIZ_ID = new GridColumn();
            colBASVURMA_HARCI_DOVIZ_ID.VisibleIndex = 182;
            colBASVURMA_HARCI_DOVIZ_ID.FieldName = "BASVURMA_HARCI_DOVIZ_ID";
            colBASVURMA_HARCI_DOVIZ_ID.Name = "colBASVURMA_HARCI_DOVIZ_ID";
            colBASVURMA_HARCI_DOVIZ_ID.Visible = true;

            GridColumn colVEKALET_HARCI = new GridColumn();
            colVEKALET_HARCI.VisibleIndex = 183;
            colVEKALET_HARCI.FieldName = "VEKALET_HARCI";
            colVEKALET_HARCI.Name = "colVEKALET_HARCI";
            colVEKALET_HARCI.Visible = true;

            GridColumn colVEKALET_HARCI_DOVIZ_ID = new GridColumn();
            colVEKALET_HARCI_DOVIZ_ID.VisibleIndex = 184;
            colVEKALET_HARCI_DOVIZ_ID.FieldName = "VEKALET_HARCI_DOVIZ_ID";
            colVEKALET_HARCI_DOVIZ_ID.Name = "colVEKALET_HARCI_DOVIZ_ID";
            colVEKALET_HARCI_DOVIZ_ID.Visible = true;

            GridColumn colVEKALET_PULU = new GridColumn();
            colVEKALET_PULU.VisibleIndex = 185;
            colVEKALET_PULU.FieldName = "VEKALET_PULU";
            colVEKALET_PULU.Name = "colVEKALET_PULU";
            colVEKALET_PULU.Visible = true;

            GridColumn colVEKALET_PULU_DOVIZ_ID = new GridColumn();
            colVEKALET_PULU_DOVIZ_ID.VisibleIndex = 186;
            colVEKALET_PULU_DOVIZ_ID.FieldName = "VEKALET_PULU_DOVIZ_ID";
            colVEKALET_PULU_DOVIZ_ID.Name = "colVEKALET_PULU_DOVIZ_ID";
            colVEKALET_PULU_DOVIZ_ID.Visible = true;

            GridColumn colIFLAS_BASVURMA_HARCI = new GridColumn();
            colIFLAS_BASVURMA_HARCI.VisibleIndex = 187;
            colIFLAS_BASVURMA_HARCI.FieldName = "IFLAS_BASVURMA_HARCI";
            colIFLAS_BASVURMA_HARCI.Name = "colIFLAS_BASVURMA_HARCI";
            colIFLAS_BASVURMA_HARCI.Visible = true;

            GridColumn colIFLAS_BASVURMA_HARCI_DOVIZ_ID = new GridColumn();
            colIFLAS_BASVURMA_HARCI_DOVIZ_ID.VisibleIndex = 188;
            colIFLAS_BASVURMA_HARCI_DOVIZ_ID.FieldName = "IFLAS_BASVURMA_HARCI_DOVIZ_ID";
            colIFLAS_BASVURMA_HARCI_DOVIZ_ID.Name = "colIFLAS_BASVURMA_HARCI_DOVIZ_ID";
            colIFLAS_BASVURMA_HARCI_DOVIZ_ID.Visible = true;

            GridColumn colIFLASIN_ACILMASI_HARCI = new GridColumn();
            colIFLASIN_ACILMASI_HARCI.VisibleIndex = 189;
            colIFLASIN_ACILMASI_HARCI.FieldName = "IFLASIN_ACILMASI_HARCI";
            colIFLASIN_ACILMASI_HARCI.Name = "colIFLASIN_ACILMASI_HARCI";
            colIFLASIN_ACILMASI_HARCI.Visible = true;

            GridColumn colIFLASIN_ACILMASI_HARCI_DOVIZ_ID = new GridColumn();
            colIFLASIN_ACILMASI_HARCI_DOVIZ_ID.VisibleIndex = 190;
            colIFLASIN_ACILMASI_HARCI_DOVIZ_ID.FieldName = "IFLASIN_ACILMASI_HARCI_DOVIZ_ID";
            colIFLASIN_ACILMASI_HARCI_DOVIZ_ID.Name = "colIFLASIN_ACILMASI_HARCI_DOVIZ_ID";
            colIFLASIN_ACILMASI_HARCI_DOVIZ_ID.Visible = true;

            GridColumn colILK_TEBLIGAT_GIDERI = new GridColumn();
            colILK_TEBLIGAT_GIDERI.VisibleIndex = 191;
            colILK_TEBLIGAT_GIDERI.FieldName = "ILK_TEBLIGAT_GIDERI";
            colILK_TEBLIGAT_GIDERI.Name = "colILK_TEBLIGAT_GIDERI";
            colILK_TEBLIGAT_GIDERI.Visible = true;

            GridColumn colILK_TEBLIGAT_GIDERI_DOVIZ_ID = new GridColumn();
            colILK_TEBLIGAT_GIDERI_DOVIZ_ID.VisibleIndex = 192;
            colILK_TEBLIGAT_GIDERI_DOVIZ_ID.FieldName = "ILK_TEBLIGAT_GIDERI_DOVIZ_ID";
            colILK_TEBLIGAT_GIDERI_DOVIZ_ID.Name = "colILK_TEBLIGAT_GIDERI_DOVIZ_ID";
            colILK_TEBLIGAT_GIDERI_DOVIZ_ID.Visible = true;

            GridColumn colTAHLIYE_HARCI = new GridColumn();
            colTAHLIYE_HARCI.VisibleIndex = 193;
            colTAHLIYE_HARCI.FieldName = "TAHLIYE_HARCI";
            colTAHLIYE_HARCI.Name = "colTAHLIYE_HARCI";
            colTAHLIYE_HARCI.Visible = true;

            GridColumn colTAHLIYE_HARCI_DOVIZ_ID = new GridColumn();
            colTAHLIYE_HARCI_DOVIZ_ID.VisibleIndex = 194;
            colTAHLIYE_HARCI_DOVIZ_ID.FieldName = "TAHLIYE_HARCI_DOVIZ_ID";
            colTAHLIYE_HARCI_DOVIZ_ID.Name = "colTAHLIYE_HARCI_DOVIZ_ID";
            colTAHLIYE_HARCI_DOVIZ_ID.Visible = true;

            GridColumn colTESLIM_HARCI = new GridColumn();
            colTESLIM_HARCI.VisibleIndex = 195;
            colTESLIM_HARCI.FieldName = "TESLIM_HARCI";
            colTESLIM_HARCI.Name = "colTESLIM_HARCI";
            colTESLIM_HARCI.Visible = true;

            GridColumn colTESLIM_HARCI_DOVIZ_ID = new GridColumn();
            colTESLIM_HARCI_DOVIZ_ID.VisibleIndex = 196;
            colTESLIM_HARCI_DOVIZ_ID.FieldName = "TESLIM_HARCI_DOVIZ_ID";
            colTESLIM_HARCI_DOVIZ_ID.Name = "colTESLIM_HARCI_DOVIZ_ID";
            colTESLIM_HARCI_DOVIZ_ID.Visible = true;

            GridColumn colFERAGAT_HARCI = new GridColumn();
            colFERAGAT_HARCI.VisibleIndex = 197;
            colFERAGAT_HARCI.FieldName = "FERAGAT_HARCI";
            colFERAGAT_HARCI.Name = "colFERAGAT_HARCI";
            colFERAGAT_HARCI.Visible = true;

            GridColumn colFERAGAT_HARCI_DOVIZ_ID = new GridColumn();
            colFERAGAT_HARCI_DOVIZ_ID.VisibleIndex = 198;
            colFERAGAT_HARCI_DOVIZ_ID.FieldName = "FERAGAT_HARCI_DOVIZ_ID";
            colFERAGAT_HARCI_DOVIZ_ID.Name = "colFERAGAT_HARCI_DOVIZ_ID";
            colFERAGAT_HARCI_DOVIZ_ID.Visible = true;

            GridColumn colTO_YONETIMG_TAZMINATI = new GridColumn();
            colTO_YONETIMG_TAZMINATI.VisibleIndex = 199;
            colTO_YONETIMG_TAZMINATI.FieldName = "TO_YONETIMG_TAZMINATI";
            colTO_YONETIMG_TAZMINATI.Name = "colTO_YONETIMG_TAZMINATI";
            colTO_YONETIMG_TAZMINATI.Visible = true;

            GridColumn colTO_YONETIMG_TAZMINATI_DOVIZ_ID = new GridColumn();
            colTO_YONETIMG_TAZMINATI_DOVIZ_ID.VisibleIndex = 200;
            colTO_YONETIMG_TAZMINATI_DOVIZ_ID.FieldName = "TO_YONETIMG_TAZMINATI_DOVIZ_ID";
            colTO_YONETIMG_TAZMINATI_DOVIZ_ID.Name = "colTO_YONETIMG_TAZMINATI_DOVIZ_ID";
            colTO_YONETIMG_TAZMINATI_DOVIZ_ID.Visible = true;

            GridColumn colTS_HESAP_TIP = new GridColumn();
            colTS_HESAP_TIP.VisibleIndex = 201;
            colTS_HESAP_TIP.FieldName = "TS_HESAP_TIP";
            colTS_HESAP_TIP.Name = "colTS_HESAP_TIP";
            colTS_HESAP_TIP.Visible = true;

            GridColumn colTO_HESAP_TIP = new GridColumn();
            colTO_HESAP_TIP.VisibleIndex = 202;
            colTO_HESAP_TIP.FieldName = "TO_HESAP_TIP";
            colTO_HESAP_TIP.Name = "colTO_HESAP_TIP";
            colTO_HESAP_TIP.Visible = true;

            GridColumn colASAMA_ADI = new GridColumn();
            colASAMA_ADI.VisibleIndex = 203;
            colASAMA_ADI.FieldName = "ASAMA_ADI";
            colASAMA_ADI.Name = "colASAMA_ADI";
            colASAMA_ADI.Visible = true;

            GridColumn colBANKA = new GridColumn();
            colBANKA.VisibleIndex = 204;
            colBANKA.FieldName = "BANKA";
            colBANKA.Name = "colBANKA";
            colBANKA.Visible = true;

            GridColumn colBANKA_SUBE = new GridColumn();
            colBANKA_SUBE.VisibleIndex = 205;
            colBANKA_SUBE.FieldName = "BANKA_SUBE";
            colBANKA_SUBE.Name = "colBANKA_SUBE";
            colBANKA_SUBE.Visible = true;

            GridColumn colFOY_BIRIM = new GridColumn();
            colFOY_BIRIM.VisibleIndex = 206;
            colFOY_BIRIM.FieldName = "FOY_BIRIM";
            colFOY_BIRIM.Name = "colFOY_BIRIM";
            colFOY_BIRIM.Visible = true;

            GridColumn colFOY_YERI = new GridColumn();
            colFOY_YERI.VisibleIndex = 207;
            colFOY_YERI.FieldName = "FOY_YERI";
            colFOY_YERI.Name = "colFOY_YERI";
            colFOY_YERI.Visible = true;

            GridColumn colTAHSILAT_DURUM = new GridColumn();
            colTAHSILAT_DURUM.VisibleIndex = 208;
            colTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            colTAHSILAT_DURUM.Name = "colTAHSILAT_DURUM";
            colTAHSILAT_DURUM.Visible = true;

            GridColumn colFOY_OZEL_DURUM = new GridColumn();
            colFOY_OZEL_DURUM.VisibleIndex = 209;
            colFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            colFOY_OZEL_DURUM.Name = "colFOY_OZEL_DURUM";
            colFOY_OZEL_DURUM.Visible = true;

            GridColumn colKREDI_GRUP = new GridColumn();
            colKREDI_GRUP.VisibleIndex = 210;
            colKREDI_GRUP.FieldName = "KREDI_GRUP";
            colKREDI_GRUP.Name = "colKREDI_GRUP";
            colKREDI_GRUP.Visible = true;

            GridColumn colKREDI_TIP = new GridColumn();
            colKREDI_TIP.VisibleIndex = 211;
            colKREDI_TIP.FieldName = "KREDI_TIP";
            colKREDI_TIP.Name = "colKREDI_TIP";
            colKREDI_TIP.Visible = true;

            GridColumn colKLASOR_1 = new GridColumn();
            colKLASOR_1.VisibleIndex = 212;
            colKLASOR_1.FieldName = "KLASOR_1";
            colKLASOR_1.Name = "colKLASOR_1";
            colKLASOR_1.Visible = true;

            GridColumn colKLASOR_2 = new GridColumn();
            colKLASOR_2.VisibleIndex = 213;
            colKLASOR_2.FieldName = "KLASOR_2";
            colKLASOR_2.Name = "colKLASOR_2";
            colKLASOR_2.Visible = true;

            GridColumn colID = new GridColumn();
            colID.VisibleIndex = 214;
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = true;

            GridColumn colBOLGE = new GridColumn();
            colBOLGE.VisibleIndex = 215;
            colBOLGE.FieldName = "BOLGE";
            colBOLGE.Name = "colBOLGE";
            colBOLGE.Visible = true;

            GridColumn colBOLUM = new GridColumn();
            colBOLUM.VisibleIndex = 216;
            colBOLUM.FieldName = "BOLUM";
            colBOLUM.Name = "colBOLUM";
            colBOLUM.Visible = true;

            GridColumn colALACAK_NEDENI = new GridColumn();
            colALACAK_NEDENI.VisibleIndex = 217;
            colALACAK_NEDENI.FieldName = "ALACAK_NEDENI";
            colALACAK_NEDENI.Name = "colALACAK_NEDENI";
            colALACAK_NEDENI.Visible = true;

            GridColumn colALACAK_NEDEN_ID = new GridColumn();
            colALACAK_NEDEN_ID.VisibleIndex = 218;
            colALACAK_NEDEN_ID.FieldName = "ALACAK_NEDEN_ID";
            colALACAK_NEDEN_ID.Name = "colALACAK_NEDEN_ID";
            colALACAK_NEDEN_ID.Visible = true;

              */

            #endregion eski

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
            devirdenAdet,
            devirdenMiktar,
            gelenAdet,
            gelenMiktar,
            tahsilatAdet,
            tahsilatMiktar,
            acizAdet,
            acizMiktar,
            tahsilatDagAnapara,
            tahsilatDagFaize,
            tahsilatDagMasraflara,
            devirAdet,
            devirMiktar

                #region eski

            /*
			colFOY_NO,
			colREFERANS_NO,
			colREFERANS_NO2,
			colREFERANS_NO3,
			colTAKIP_TARIHI,
			colESAS_NO,
			colTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			colASIL_ALACAK_DOVIZ_ID,
			colASIL_ALACAK,
			colISLEMIS_FAIZ_DOVIZ_ID,
			colISLEMIS_FAIZ,
			colTAKIP_CIKISI,
			colTAKIP_CIKISI_DOVIZ_ID,
			colSONRAKI_FAIZ,
			colSONRAKI_FAIZ_DOVIZ_ID,
			colODEME_TOPLAMI_DOVIZ_ID,
			colODEME_TOPLAMI,
			colTO_ODEME_TOPLAMI_DOVIZ_ID,
			colTO_ODEME_TOPLAMI,
			colKALAN,
			colKALAN_DOVIZ_ID,
			colACIKLAMA,
			colKAPAMA_TARIHI,
			colRISK_MIKTARI,
			colRISK_MIKTARI_DOVIZ_ID,
			colTS_MASRAF_HARC_TOPLAMI,
			colTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID,
			colSUBE_KOD_ID,
			colKONTROL_KIM_ID,
			colTAKIP_EDEN,
			colTAKIP_EDILEN,
			colIZLEYEN,
			colSORUMLU,
			colTAKIP_EDEN_SIFAT,
			colTAKIP_EDILEN_SIFAT,
			colTALEP_ADI,
			colFORM_TIPI,
			colDURUM,
			colICRA_ADLIYE,
			colICRA_BIRIM_NO,
			colOZEL_KOD1,
			colOZEL_KOD2,
			colOZEL_KOD3,
			colOZEL_KOD4,
			colFOY_ARSIV_TARIHI,
			colFOY_INFAZ_TARIHI,
			colTAKIBIN_MUVEKKILE_IADE_TARIHI,
			colSON_HESAP_TARIHI,
			colBIR_YIL_KAC_GUN,
			colBSMV_TO,
			colBSMV_TO_DOVIZ_ID,
			colKKDV_TO,
			colKKDV_TO_DOVIZ_ID,
			colKDV_TO,
			colKDV_TO_DOVIZ_ID,
			colIH_VEKALET_UCRETI,
			colIH_VEKALET_UCRETI_DOVIZ_ID,
			colIH_GIDERI,
			colIH_GIDERI_DOVIZ_ID,
			colIT_HACIZDE_ODENEN,
			colIT_HACIZDE_ODENEN_DOVIZ_ID,
			colKARSILIKSIZ_CEK_TAZMINATI,
			colKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID,
			colCEK_KOMISYONU,
			colCEK_KOMISYONU_DOVIZ_ID,
			colILAM_YARGILAMA_GIDERI,
			colILAM_YARGILAMA_GIDERI_DOVIZ_ID,
			colILAM_BK_YARG_ONAMA,
			colILAM_BK_YARG_ONAMA_DOVIZ_ID,
			colILAM_TEBLIG_GIDERI,
			colILAM_TEBLIG_GIDERI_DOVIZ_ID,
			colILAM_INKAR_TAZMINATI,
			colILAM_INKAR_TAZMINATI_DOVIZ_ID,
			colILAM_VEK_UCR,
			colILAM_VEK_UCR_DOVIZ_ID,
			colOIV_TO,
			colOIV_TO_DOVIZ_ID,
			colPROTESTO_GIDERI,
			colPROTESTO_GIDERI_DOVIZ_ID,
			colIHTAR_GIDERI,
			colIHTAR_GIDERI_DOVIZ_ID,
			colOZEL_TAZMINAT,
			colOZEL_TAZMINAT_DOVIZ_ID,
			colOZEL_TUTAR1_FAIZ_ORANI,
			colOZEL_TUTAR_KONU1,
			colOZEL_TUTAR_KONU2,
			colOZEL_TUTAR_KONU3,
			colOZEL_TUTAR1,
			colOZEL_TUTAR1_DOVIZ_ID,
			colOZEL_TUTAR2,
			colOZEL_TUTAR2_DOVIZ_ID,
			colOZEL_TUTAR3,
			colOZEL_TUTAR3_DOVIZ_ID,
			colSONRAKI_TAZMINAT,
			colSONRAKI_TAZMINAT_DOVIZ_ID,
			colBSMV_TS,
			colBSMV_TS_DOVIZ_ID,
			colOIV_TS,
			colOIV_TS_DOVIZ_ID,
			colKDV_TS,
			colKDV_TS_DOVIZ_ID,
			colILK_GIDERLER,
			colILK_GIDERLER_DOVIZ_ID,
			colPESIN_HARC,
			colPESIN_HARC_DOVIZ_ID,
			colODENEN_TAHSIL_HARCI,
			colODENEN_TAHSIL_HARCI_DOVIZ_ID,
			colKALAN_TAHSIL_HARCI,
			colKALAN_TAHSIL_HARCI_DOVIZ_ID,
			colMASAYA_KATILMA_HARCI,
			colMASAYA_KATILMA_HARCI_DOVIZ_ID,
			colPAYLASMA_HARCI,
			colPAYLASMA_HARCI_DOVIZ_ID,
			colDAVA_GIDERLERI,
			colDAVA_GIDERLERI_DOVIZ_ID,
			colDIGER_GIDERLER,
			colDIGER_GIDERLER_DOVIZ_ID,
			colTAKIP_VEKALET_UCRETI,
			colTAKIP_VEKALET_UCRETI_DOVIZ_ID,
			colTAKIP_VEKALET_UCRETI_KATSAYI,
			colDAVA_INKAR_TAZMINATI,
			colDAVA_INKAR_TAZMINATI_DOVIZ_ID,
			colDAVA_VEKALET_UCRETI,
			colDAVA_VEKALET_UCRETI_DOVIZ_ID,
			colMAHSUP_TOPLAMI,
			colMAHSUP_TOPLAMI_DOVIZ_ID,
			colFERAGAT_TOPLAMI,
			colFERAGAT_TOPLAMI_DOVIZ_ID,
			colALACAK_TOPLAMI,
			colALACAK_TOPLAMI_DOVIZ_ID,
			colTAHLIYE_VEK_UCR,
			colTAHLIYE_VEK_UCR_DOVIZ_ID,
			colDIGER_HARC,
			colDIGER_HARC_DOVIZ_ID,
			colTD_GIDERI,
			colTD_GIDERI_DOVIZ_ID,
			colTD_BAKIYE_HARC,
			colTD_BAKIYE_HARC_DOVIZ_ID,
			colTD_VEK_UCR,
			colTD_VEK_UCR_DOVIZ_ID,
			colTD_TEBLIG_GIDERI,
			colTD_TEBLIG_GIDERI_DOVIZ_ID,
			colBIRIKMIS_NAFAKA,
			colBIRIKMIS_NAFAKA_DOVIZ_ID,
			colICRA_INKAR_TAZMINATI,
			colICRA_INKAR_TAZMINATI_DOVIZ_ID,
			colDAMGA_PULU,
			colDAMGA_PULU_DOVIZ_ID,
			colPROTOKOL_MIKTARI,
			colPROTOKOL_MIKTARI_DOVIZ_ID,
			colPROTOKOL_FAIZ_ORANI,
			colPROTOKOL_TARIHI,
			colKARSILIK_TUTARI,
			colKARSILIK_TUTARI_DOVIZ_ID,
			colTO_MASRAF_TOPLAMI,
			colTO_MASRAF_TOPLAMI_DOVIZ_ID,
			colTS_MASRAF_TOPLAMI,
			colTS_MASRAF_TOPLAMI_DOVIZ_ID,
			colTUM_MASRAF_TOPLAMI,
			colTUM_MASRAF_TOPLAMI_DOVIZ_ID,
			colHARC_TOPLAMI,
			colHARC_TOPLAMI_DOVIZ_ID,
			colTO_VEKALET_TOPLAMI,
			colTO_VEKALET_TOPLAMI_DOVIZ_ID,
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
			colIT_VEKALET_UCRETI,
			colIT_VEKALET_UCRETI_DOVIZ_ID,
			colIT_GIDERI,
			colIT_GIDERI_DOVIZ_ID,
			colTO_ODEME_MAHSUP_TOPLAMI,
			colTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID,
			colPAYLASIM_TIPI,
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
			colTO_YONETIMG_TAZMINATI,
			colTO_YONETIMG_TAZMINATI_DOVIZ_ID,
			colTS_HESAP_TIP,
			colTO_HESAP_TIP,
			colASAMA_ADI,
			colBANKA,
			colBANKA_SUBE,
			colFOY_BIRIM,
			colFOY_YERI,
			colTAHSILAT_DURUM,
			colFOY_OZEL_DURUM,
			colKREDI_GRUP,
			colKREDI_TIP,
			colKLASOR_1,
			colKLASOR_2,
			colID,
			colBOLGE,
			colBOLUM,
			colALACAK_NEDENI,

			//colALACAK_NEDEN_ID,
             */

#endregion eski
			};

            #endregion []

            #region Column Caption

            #region eski

            /*
            if (captionlar==null)
            captionlar = GetCaptionDictinory();
            if(editler==null)
            editler = GetRepositoryItemDictinory();

            for (int i = 0; i < dizi.Length; i++)
            {
                string caption = string.Empty;
                if (captionlar.ContainsKey(dizi[i].FieldName))
                    caption = captionlar[dizi[i].FieldName];
                if (caption.Length > 0)
                    dizi[i].Caption = caption;
                else if (dizi[i].FieldName.ToLower().Contains("doviz_id"))
                {
                    dizi[i].Caption = "Brm";
                    dizi[i].ToolTip = dizi[i].FieldName.Replace('_', ' ').Replace("ID", " ").ToString();
                }

                if (dizi[i].FieldName.Contains("_DOVIZ_ID"))
                {
                    dizi[i].ColumnEdit = editler["DovizId"];
                    dizi[i].Caption = "Brm";
                    dizi[i].ToolTip = dizi[i].FieldName.Replace('_', ' ').Replace("ID", " ").ToString();
                }
                else if (editler.ContainsKey(dizi[i].FieldName))
                    dizi[i].ColumnEdit = editler[dizi[i].FieldName];
            }
             */

            #endregion eski

            #endregion Column Caption

            return dizi;
        }

        public PivotGridField[] GetPivotFields(string pencere)
        {
            #region Field & Properties

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 0;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 1;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldREFERANS_NO2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO2.AreaIndex = 2;
            fieldREFERANS_NO2.FieldName = "REFERANS_NO2";
            fieldREFERANS_NO2.Name = "fieldREFERANS_NO2";
            fieldREFERANS_NO2.Visible = false;

            PivotGridField fieldREFERANS_NO3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO3.AreaIndex = 3;
            fieldREFERANS_NO3.FieldName = "REFERANS_NO3";
            fieldREFERANS_NO3.Name = "fieldREFERANS_NO3";
            fieldREFERANS_NO3.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_TARIHI.AreaIndex = 4;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 5;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldICRA_OZEL_KOD3_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_OZEL_KOD3_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_OZEL_KOD3_ID.AreaIndex = 6;
            fieldICRA_OZEL_KOD3_ID.FieldName = "ICRA_OZEL_KOD3_ID";
            fieldICRA_OZEL_KOD3_ID.Name = "fieldICRA_OZEL_KOD3_ID";
            fieldICRA_OZEL_KOD3_ID.Visible = false;

            PivotGridField fieldICRA_OZEL_KOD4_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_OZEL_KOD4_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_OZEL_KOD4_ID.AreaIndex = 7;
            fieldICRA_OZEL_KOD4_ID.FieldName = "ICRA_OZEL_KOD4_ID";
            fieldICRA_OZEL_KOD4_ID.Name = "fieldICRA_OZEL_KOD4_ID";
            fieldICRA_OZEL_KOD4_ID.Visible = false;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 8;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 9;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 10;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldISLEMIS_FAIZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISLEMIS_FAIZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISLEMIS_FAIZ_DOVIZ_ID.AreaIndex = 11;
            fieldISLEMIS_FAIZ_DOVIZ_ID.FieldName = "ISLEMIS_FAIZ_DOVIZ_ID";
            fieldISLEMIS_FAIZ_DOVIZ_ID.Name = "fieldISLEMIS_FAIZ_DOVIZ_ID";
            fieldISLEMIS_FAIZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldISLEMIS_FAIZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISLEMIS_FAIZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISLEMIS_FAIZ.AreaIndex = 12;
            fieldISLEMIS_FAIZ.FieldName = "ISLEMIS_FAIZ";
            fieldISLEMIS_FAIZ.Name = "fieldISLEMIS_FAIZ";
            fieldISLEMIS_FAIZ.Visible = false;

            PivotGridField fieldTAKIP_CIKISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI.AreaIndex = 13;
            fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";
            fieldTAKIP_CIKISI.Visible = false;

            PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI_DOVIZ_ID.AreaIndex = 14;
            fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSONRAKI_FAIZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSONRAKI_FAIZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSONRAKI_FAIZ.AreaIndex = 15;
            fieldSONRAKI_FAIZ.FieldName = "SONRAKI_FAIZ";
            fieldSONRAKI_FAIZ.Name = "fieldSONRAKI_FAIZ";
            fieldSONRAKI_FAIZ.Visible = false;

            PivotGridField fieldSONRAKI_FAIZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSONRAKI_FAIZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSONRAKI_FAIZ_DOVIZ_ID.AreaIndex = 16;
            fieldSONRAKI_FAIZ_DOVIZ_ID.FieldName = "SONRAKI_FAIZ_DOVIZ_ID";
            fieldSONRAKI_FAIZ_DOVIZ_ID.Name = "fieldSONRAKI_FAIZ_DOVIZ_ID";
            fieldSONRAKI_FAIZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 17;
            fieldODEME_TOPLAMI_DOVIZ_ID.FieldName = "ODEME_TOPLAMI_DOVIZ_ID";
            fieldODEME_TOPLAMI_DOVIZ_ID.Name = "fieldODEME_TOPLAMI_DOVIZ_ID";
            fieldODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TOPLAMI.AreaIndex = 18;
            fieldODEME_TOPLAMI.FieldName = "ODEME_TOPLAMI";
            fieldODEME_TOPLAMI.Name = "fieldODEME_TOPLAMI";
            fieldODEME_TOPLAMI.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 19;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI.AreaIndex = 20;
            fieldTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Name = "fieldTO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 21;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 22;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldACIKLAMA.AreaIndex = 23;
            fieldACIKLAMA.FieldName = "ACIKLAMA";
            fieldACIKLAMA.Name = "fieldACIKLAMA";
            fieldACIKLAMA.Visible = false;

            PivotGridField fieldKAPAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKAPAMA_TARIHI.AreaIndex = 24;
            fieldKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Name = "fieldKAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Visible = false;

            PivotGridField fieldRISK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI.AreaIndex = 25;
            fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";
            fieldRISK_MIKTARI.Visible = false;

            PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 26;
            fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_MASRAF_HARC_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_HARC_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_HARC_TOPLAMI.AreaIndex = 27;
            fieldTS_MASRAF_HARC_TOPLAMI.FieldName = "TS_MASRAF_HARC_TOPLAMI";
            fieldTS_MASRAF_HARC_TOPLAMI.Name = "fieldTS_MASRAF_HARC_TOPLAMI";
            fieldTS_MASRAF_HARC_TOPLAMI.Visible = false;

            PivotGridField fieldTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID.AreaIndex = 28;
            fieldTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_HARC_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID.Name = "fieldTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 29;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 30;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 31;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayısı";
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldTAKIP_EDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDEN.AreaIndex = 32;
            fieldTAKIP_EDEN.FieldName = "TAKIP_EDEN";
            fieldTAKIP_EDEN.Name = "fieldTAKIP_EDEN";
            fieldTAKIP_EDEN.Visible = false;

            PivotGridField fieldTAKIP_EDILEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDILEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDILEN.AreaIndex = 33;
            fieldTAKIP_EDILEN.FieldName = "TAKIP_EDILEN";
            fieldTAKIP_EDILEN.Name = "fieldTAKIP_EDILEN";
            fieldTAKIP_EDILEN.Visible = false;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 34;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 35;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldTAKIP_EDEN_SIFAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDEN_SIFAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDEN_SIFAT.AreaIndex = 36;
            fieldTAKIP_EDEN_SIFAT.FieldName = "TAKIP_EDEN_SIFAT";
            fieldTAKIP_EDEN_SIFAT.Name = "fieldTAKIP_EDEN_SIFAT";
            fieldTAKIP_EDEN_SIFAT.Visible = false;

            PivotGridField fieldTAKIP_EDILEN_SIFAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDILEN_SIFAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDILEN_SIFAT.AreaIndex = 37;
            fieldTAKIP_EDILEN_SIFAT.FieldName = "TAKIP_EDILEN_SIFAT";
            fieldTAKIP_EDILEN_SIFAT.Name = "fieldTAKIP_EDILEN_SIFAT";
            fieldTAKIP_EDILEN_SIFAT.Visible = false;

            PivotGridField fieldTALEP_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALEP_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALEP_ADI.AreaIndex = 38;
            fieldTALEP_ADI.FieldName = "TALEP_ADI";
            fieldTALEP_ADI.Name = "fieldTALEP_ADI";
            fieldTALEP_ADI.Visible = false;

            PivotGridField fieldFORM_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFORM_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFORM_TIPI.AreaIndex = 39;
            fieldFORM_TIPI.FieldName = "FORM_TIPI";
            fieldFORM_TIPI.Name = "fieldFORM_TIPI";
            fieldFORM_TIPI.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDURUM.AreaIndex = 40;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 41;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 42;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldOZEL_KOD1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD1.AreaIndex = 43;
            fieldOZEL_KOD1.FieldName = "OZEL_KOD1";
            fieldOZEL_KOD1.Name = "fieldOZEL_KOD1";
            fieldOZEL_KOD1.Visible = false;

            PivotGridField fieldOZEL_KOD2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD2.AreaIndex = 44;
            fieldOZEL_KOD2.FieldName = "OZEL_KOD2";
            fieldOZEL_KOD2.Name = "fieldOZEL_KOD2";
            fieldOZEL_KOD2.Visible = false;

            PivotGridField fieldOZEL_KOD3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD3.AreaIndex = 45;
            fieldOZEL_KOD3.FieldName = "OZEL_KOD3";
            fieldOZEL_KOD3.Name = "fieldOZEL_KOD3";
            fieldOZEL_KOD3.Visible = false;

            PivotGridField fieldOZEL_KOD4 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD4.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD4.AreaIndex = 46;
            fieldOZEL_KOD4.FieldName = "OZEL_KOD4";
            fieldOZEL_KOD4.Name = "fieldOZEL_KOD4";
            fieldOZEL_KOD4.Visible = false;

            PivotGridField fieldFOY_ARSIV_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_ARSIV_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_ARSIV_TARIHI.AreaIndex = 47;
            fieldFOY_ARSIV_TARIHI.FieldName = "FOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Name = "fieldFOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Visible = false;

            PivotGridField fieldFOY_INFAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_INFAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_INFAZ_TARIHI.AreaIndex = 48;
            fieldFOY_INFAZ_TARIHI.FieldName = "FOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Name = "fieldFOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Visible = false;

            PivotGridField fieldTAKIBIN_MUVEKKILE_IADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.AreaIndex = 49;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.FieldName = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Name = "fieldTAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Visible = false;

            PivotGridField fieldSON_HESAP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSON_HESAP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSON_HESAP_TARIHI.AreaIndex = 50;
            fieldSON_HESAP_TARIHI.FieldName = "SON_HESAP_TARIHI";
            fieldSON_HESAP_TARIHI.Name = "fieldSON_HESAP_TARIHI";
            fieldSON_HESAP_TARIHI.Visible = false;

            PivotGridField fieldBIR_YIL_KAC_GUN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIR_YIL_KAC_GUN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIR_YIL_KAC_GUN.AreaIndex = 51;
            fieldBIR_YIL_KAC_GUN.FieldName = "BIR_YIL_KAC_GUN";
            fieldBIR_YIL_KAC_GUN.Name = "fieldBIR_YIL_KAC_GUN";
            fieldBIR_YIL_KAC_GUN.Visible = false;

            PivotGridField fieldBSMV_TO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBSMV_TO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBSMV_TO.AreaIndex = 52;
            fieldBSMV_TO.FieldName = "BSMV_TO";
            fieldBSMV_TO.Name = "fieldBSMV_TO";
            fieldBSMV_TO.Visible = false;

            PivotGridField fieldBSMV_TO_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBSMV_TO_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBSMV_TO_DOVIZ_ID.AreaIndex = 53;
            fieldBSMV_TO_DOVIZ_ID.FieldName = "BSMV_TO_DOVIZ_ID";
            fieldBSMV_TO_DOVIZ_ID.Name = "fieldBSMV_TO_DOVIZ_ID";
            fieldBSMV_TO_DOVIZ_ID.Visible = false;

            PivotGridField fieldKKDV_TO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKKDV_TO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKKDV_TO.AreaIndex = 54;
            fieldKKDV_TO.FieldName = "KKDV_TO";
            fieldKKDV_TO.Name = "fieldKKDV_TO";
            fieldKKDV_TO.Visible = false;

            PivotGridField fieldKKDV_TO_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKKDV_TO_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKKDV_TO_DOVIZ_ID.AreaIndex = 55;
            fieldKKDV_TO_DOVIZ_ID.FieldName = "KKDV_TO_DOVIZ_ID";
            fieldKKDV_TO_DOVIZ_ID.Name = "fieldKKDV_TO_DOVIZ_ID";
            fieldKKDV_TO_DOVIZ_ID.Visible = false;

            PivotGridField fieldKDV_TO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKDV_TO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKDV_TO.AreaIndex = 56;
            fieldKDV_TO.FieldName = "KDV_TO";
            fieldKDV_TO.Name = "fieldKDV_TO";
            fieldKDV_TO.Visible = false;

            PivotGridField fieldKDV_TO_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKDV_TO_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKDV_TO_DOVIZ_ID.AreaIndex = 57;
            fieldKDV_TO_DOVIZ_ID.FieldName = "KDV_TO_DOVIZ_ID";
            fieldKDV_TO_DOVIZ_ID.Name = "fieldKDV_TO_DOVIZ_ID";
            fieldKDV_TO_DOVIZ_ID.Visible = false;

            PivotGridField fieldIH_VEKALET_UCRETI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIH_VEKALET_UCRETI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIH_VEKALET_UCRETI.AreaIndex = 58;
            fieldIH_VEKALET_UCRETI.FieldName = "IH_VEKALET_UCRETI";
            fieldIH_VEKALET_UCRETI.Name = "fieldIH_VEKALET_UCRETI";
            fieldIH_VEKALET_UCRETI.Visible = false;

            PivotGridField fieldIH_VEKALET_UCRETI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIH_VEKALET_UCRETI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIH_VEKALET_UCRETI_DOVIZ_ID.AreaIndex = 59;
            fieldIH_VEKALET_UCRETI_DOVIZ_ID.FieldName = "IH_VEKALET_UCRETI_DOVIZ_ID";
            fieldIH_VEKALET_UCRETI_DOVIZ_ID.Name = "fieldIH_VEKALET_UCRETI_DOVIZ_ID";
            fieldIH_VEKALET_UCRETI_DOVIZ_ID.Visible = false;

            PivotGridField fieldIH_GIDERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIH_GIDERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIH_GIDERI.AreaIndex = 60;
            fieldIH_GIDERI.FieldName = "IH_GIDERI";
            fieldIH_GIDERI.Name = "fieldIH_GIDERI";
            fieldIH_GIDERI.Visible = false;

            PivotGridField fieldIH_GIDERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIH_GIDERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIH_GIDERI_DOVIZ_ID.AreaIndex = 61;
            fieldIH_GIDERI_DOVIZ_ID.FieldName = "IH_GIDERI_DOVIZ_ID";
            fieldIH_GIDERI_DOVIZ_ID.Name = "fieldIH_GIDERI_DOVIZ_ID";
            fieldIH_GIDERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldIT_HACIZDE_ODENEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIT_HACIZDE_ODENEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIT_HACIZDE_ODENEN.AreaIndex = 62;
            fieldIT_HACIZDE_ODENEN.FieldName = "IT_HACIZDE_ODENEN";
            fieldIT_HACIZDE_ODENEN.Name = "fieldIT_HACIZDE_ODENEN";
            fieldIT_HACIZDE_ODENEN.Visible = false;

            PivotGridField fieldIT_HACIZDE_ODENEN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIT_HACIZDE_ODENEN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIT_HACIZDE_ODENEN_DOVIZ_ID.AreaIndex = 63;
            fieldIT_HACIZDE_ODENEN_DOVIZ_ID.FieldName = "IT_HACIZDE_ODENEN_DOVIZ_ID";
            fieldIT_HACIZDE_ODENEN_DOVIZ_ID.Name = "fieldIT_HACIZDE_ODENEN_DOVIZ_ID";
            fieldIT_HACIZDE_ODENEN_DOVIZ_ID.Visible = false;

            PivotGridField fieldKARSILIKSIZ_CEK_TAZMINATI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKARSILIKSIZ_CEK_TAZMINATI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKARSILIKSIZ_CEK_TAZMINATI.AreaIndex = 64;
            fieldKARSILIKSIZ_CEK_TAZMINATI.FieldName = "KARSILIKSIZ_CEK_TAZMINATI";
            fieldKARSILIKSIZ_CEK_TAZMINATI.Name = "fieldKARSILIKSIZ_CEK_TAZMINATI";
            fieldKARSILIKSIZ_CEK_TAZMINATI.Visible = false;

            PivotGridField fieldKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.AreaIndex = 65;
            fieldKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.FieldName = "KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID";
            fieldKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.Name = "fieldKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID";
            fieldKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.Visible = false;

            PivotGridField fieldCEK_KOMISYONU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldCEK_KOMISYONU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldCEK_KOMISYONU.AreaIndex = 66;
            fieldCEK_KOMISYONU.FieldName = "CEK_KOMISYONU";
            fieldCEK_KOMISYONU.Name = "fieldCEK_KOMISYONU";
            fieldCEK_KOMISYONU.Visible = false;

            PivotGridField fieldCEK_KOMISYONU_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldCEK_KOMISYONU_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldCEK_KOMISYONU_DOVIZ_ID.AreaIndex = 67;
            fieldCEK_KOMISYONU_DOVIZ_ID.FieldName = "CEK_KOMISYONU_DOVIZ_ID";
            fieldCEK_KOMISYONU_DOVIZ_ID.Name = "fieldCEK_KOMISYONU_DOVIZ_ID";
            fieldCEK_KOMISYONU_DOVIZ_ID.Visible = false;

            PivotGridField fieldILAM_YARGILAMA_GIDERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_YARGILAMA_GIDERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_YARGILAMA_GIDERI.AreaIndex = 68;
            fieldILAM_YARGILAMA_GIDERI.FieldName = "ILAM_YARGILAMA_GIDERI";
            fieldILAM_YARGILAMA_GIDERI.Name = "fieldILAM_YARGILAMA_GIDERI";
            fieldILAM_YARGILAMA_GIDERI.Visible = false;

            PivotGridField fieldILAM_YARGILAMA_GIDERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_YARGILAMA_GIDERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_YARGILAMA_GIDERI_DOVIZ_ID.AreaIndex = 69;
            fieldILAM_YARGILAMA_GIDERI_DOVIZ_ID.FieldName = "ILAM_YARGILAMA_GIDERI_DOVIZ_ID";
            fieldILAM_YARGILAMA_GIDERI_DOVIZ_ID.Name = "fieldILAM_YARGILAMA_GIDERI_DOVIZ_ID";
            fieldILAM_YARGILAMA_GIDERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldILAM_BK_YARG_ONAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_BK_YARG_ONAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_BK_YARG_ONAMA.AreaIndex = 70;
            fieldILAM_BK_YARG_ONAMA.FieldName = "ILAM_BK_YARG_ONAMA";
            fieldILAM_BK_YARG_ONAMA.Name = "fieldILAM_BK_YARG_ONAMA";
            fieldILAM_BK_YARG_ONAMA.Visible = false;

            PivotGridField fieldILAM_BK_YARG_ONAMA_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_BK_YARG_ONAMA_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_BK_YARG_ONAMA_DOVIZ_ID.AreaIndex = 71;
            fieldILAM_BK_YARG_ONAMA_DOVIZ_ID.FieldName = "ILAM_BK_YARG_ONAMA_DOVIZ_ID";
            fieldILAM_BK_YARG_ONAMA_DOVIZ_ID.Name = "fieldILAM_BK_YARG_ONAMA_DOVIZ_ID";
            fieldILAM_BK_YARG_ONAMA_DOVIZ_ID.Visible = false;

            PivotGridField fieldILAM_TEBLIG_GIDERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_TEBLIG_GIDERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_TEBLIG_GIDERI.AreaIndex = 72;
            fieldILAM_TEBLIG_GIDERI.FieldName = "ILAM_TEBLIG_GIDERI";
            fieldILAM_TEBLIG_GIDERI.Name = "fieldILAM_TEBLIG_GIDERI";
            fieldILAM_TEBLIG_GIDERI.Visible = false;

            PivotGridField fieldILAM_TEBLIG_GIDERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_TEBLIG_GIDERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_TEBLIG_GIDERI_DOVIZ_ID.AreaIndex = 73;
            fieldILAM_TEBLIG_GIDERI_DOVIZ_ID.FieldName = "ILAM_TEBLIG_GIDERI_DOVIZ_ID";
            fieldILAM_TEBLIG_GIDERI_DOVIZ_ID.Name = "fieldILAM_TEBLIG_GIDERI_DOVIZ_ID";
            fieldILAM_TEBLIG_GIDERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldILAM_INKAR_TAZMINATI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_INKAR_TAZMINATI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_INKAR_TAZMINATI.AreaIndex = 74;
            fieldILAM_INKAR_TAZMINATI.FieldName = "ILAM_INKAR_TAZMINATI";
            fieldILAM_INKAR_TAZMINATI.Name = "fieldILAM_INKAR_TAZMINATI";
            fieldILAM_INKAR_TAZMINATI.Visible = false;

            PivotGridField fieldILAM_INKAR_TAZMINATI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_INKAR_TAZMINATI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_INKAR_TAZMINATI_DOVIZ_ID.AreaIndex = 75;
            fieldILAM_INKAR_TAZMINATI_DOVIZ_ID.FieldName = "ILAM_INKAR_TAZMINATI_DOVIZ_ID";
            fieldILAM_INKAR_TAZMINATI_DOVIZ_ID.Name = "fieldILAM_INKAR_TAZMINATI_DOVIZ_ID";
            fieldILAM_INKAR_TAZMINATI_DOVIZ_ID.Visible = false;

            PivotGridField fieldILAM_VEK_UCR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_VEK_UCR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_VEK_UCR.AreaIndex = 76;
            fieldILAM_VEK_UCR.FieldName = "ILAM_VEK_UCR";
            fieldILAM_VEK_UCR.Name = "fieldILAM_VEK_UCR";
            fieldILAM_VEK_UCR.Visible = false;

            PivotGridField fieldILAM_VEK_UCR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_VEK_UCR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_VEK_UCR_DOVIZ_ID.AreaIndex = 77;
            fieldILAM_VEK_UCR_DOVIZ_ID.FieldName = "ILAM_VEK_UCR_DOVIZ_ID";
            fieldILAM_VEK_UCR_DOVIZ_ID.Name = "fieldILAM_VEK_UCR_DOVIZ_ID";
            fieldILAM_VEK_UCR_DOVIZ_ID.Visible = false;

            PivotGridField fieldOIV_TO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOIV_TO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOIV_TO.AreaIndex = 78;
            fieldOIV_TO.FieldName = "OIV_TO";
            fieldOIV_TO.Name = "fieldOIV_TO";
            fieldOIV_TO.Visible = false;

            PivotGridField fieldOIV_TO_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOIV_TO_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOIV_TO_DOVIZ_ID.AreaIndex = 79;
            fieldOIV_TO_DOVIZ_ID.FieldName = "OIV_TO_DOVIZ_ID";
            fieldOIV_TO_DOVIZ_ID.Name = "fieldOIV_TO_DOVIZ_ID";
            fieldOIV_TO_DOVIZ_ID.Visible = false;

            PivotGridField fieldPROTESTO_GIDERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROTESTO_GIDERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROTESTO_GIDERI.AreaIndex = 80;
            fieldPROTESTO_GIDERI.FieldName = "PROTESTO_GIDERI";
            fieldPROTESTO_GIDERI.Name = "fieldPROTESTO_GIDERI";
            fieldPROTESTO_GIDERI.Visible = false;

            PivotGridField fieldPROTESTO_GIDERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROTESTO_GIDERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROTESTO_GIDERI_DOVIZ_ID.AreaIndex = 81;
            fieldPROTESTO_GIDERI_DOVIZ_ID.FieldName = "PROTESTO_GIDERI_DOVIZ_ID";
            fieldPROTESTO_GIDERI_DOVIZ_ID.Name = "fieldPROTESTO_GIDERI_DOVIZ_ID";
            fieldPROTESTO_GIDERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldIHTAR_GIDERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIHTAR_GIDERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIHTAR_GIDERI.AreaIndex = 82;
            fieldIHTAR_GIDERI.FieldName = "IHTAR_GIDERI";
            fieldIHTAR_GIDERI.Name = "fieldIHTAR_GIDERI";
            fieldIHTAR_GIDERI.Visible = false;

            PivotGridField fieldIHTAR_GIDERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIHTAR_GIDERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIHTAR_GIDERI_DOVIZ_ID.AreaIndex = 83;
            fieldIHTAR_GIDERI_DOVIZ_ID.FieldName = "IHTAR_GIDERI_DOVIZ_ID";
            fieldIHTAR_GIDERI_DOVIZ_ID.Name = "fieldIHTAR_GIDERI_DOVIZ_ID";
            fieldIHTAR_GIDERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldOZEL_TAZMINAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TAZMINAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TAZMINAT.AreaIndex = 84;
            fieldOZEL_TAZMINAT.FieldName = "OZEL_TAZMINAT";
            fieldOZEL_TAZMINAT.Name = "fieldOZEL_TAZMINAT";
            fieldOZEL_TAZMINAT.Visible = false;

            PivotGridField fieldOZEL_TAZMINAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TAZMINAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TAZMINAT_DOVIZ_ID.AreaIndex = 85;
            fieldOZEL_TAZMINAT_DOVIZ_ID.FieldName = "OZEL_TAZMINAT_DOVIZ_ID";
            fieldOZEL_TAZMINAT_DOVIZ_ID.Name = "fieldOZEL_TAZMINAT_DOVIZ_ID";
            fieldOZEL_TAZMINAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldOZEL_TUTAR1_FAIZ_ORANI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TUTAR1_FAIZ_ORANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TUTAR1_FAIZ_ORANI.AreaIndex = 86;
            fieldOZEL_TUTAR1_FAIZ_ORANI.FieldName = "OZEL_TUTAR1_FAIZ_ORANI";
            fieldOZEL_TUTAR1_FAIZ_ORANI.Name = "fieldOZEL_TUTAR1_FAIZ_ORANI";
            fieldOZEL_TUTAR1_FAIZ_ORANI.Visible = false;

            PivotGridField fieldOZEL_TUTAR_KONU1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TUTAR_KONU1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TUTAR_KONU1.AreaIndex = 87;
            fieldOZEL_TUTAR_KONU1.FieldName = "OZEL_TUTAR_KONU1";
            fieldOZEL_TUTAR_KONU1.Name = "fieldOZEL_TUTAR_KONU1";
            fieldOZEL_TUTAR_KONU1.Visible = false;

            PivotGridField fieldOZEL_TUTAR_KONU2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TUTAR_KONU2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TUTAR_KONU2.AreaIndex = 88;
            fieldOZEL_TUTAR_KONU2.FieldName = "OZEL_TUTAR_KONU2";
            fieldOZEL_TUTAR_KONU2.Name = "fieldOZEL_TUTAR_KONU2";
            fieldOZEL_TUTAR_KONU2.Visible = false;

            PivotGridField fieldOZEL_TUTAR_KONU3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TUTAR_KONU3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TUTAR_KONU3.AreaIndex = 89;
            fieldOZEL_TUTAR_KONU3.FieldName = "OZEL_TUTAR_KONU3";
            fieldOZEL_TUTAR_KONU3.Name = "fieldOZEL_TUTAR_KONU3";
            fieldOZEL_TUTAR_KONU3.Visible = false;

            PivotGridField fieldOZEL_TUTAR1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TUTAR1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TUTAR1.AreaIndex = 90;
            fieldOZEL_TUTAR1.FieldName = "OZEL_TUTAR1";
            fieldOZEL_TUTAR1.Name = "fieldOZEL_TUTAR1";
            fieldOZEL_TUTAR1.Visible = false;

            PivotGridField fieldOZEL_TUTAR1_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TUTAR1_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TUTAR1_DOVIZ_ID.AreaIndex = 91;
            fieldOZEL_TUTAR1_DOVIZ_ID.FieldName = "OZEL_TUTAR1_DOVIZ_ID";
            fieldOZEL_TUTAR1_DOVIZ_ID.Name = "fieldOZEL_TUTAR1_DOVIZ_ID";
            fieldOZEL_TUTAR1_DOVIZ_ID.Visible = false;

            PivotGridField fieldOZEL_TUTAR2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TUTAR2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TUTAR2.AreaIndex = 92;
            fieldOZEL_TUTAR2.FieldName = "OZEL_TUTAR2";
            fieldOZEL_TUTAR2.Name = "fieldOZEL_TUTAR2";
            fieldOZEL_TUTAR2.Visible = false;

            PivotGridField fieldOZEL_TUTAR2_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TUTAR2_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TUTAR2_DOVIZ_ID.AreaIndex = 93;
            fieldOZEL_TUTAR2_DOVIZ_ID.FieldName = "OZEL_TUTAR2_DOVIZ_ID";
            fieldOZEL_TUTAR2_DOVIZ_ID.Name = "fieldOZEL_TUTAR2_DOVIZ_ID";
            fieldOZEL_TUTAR2_DOVIZ_ID.Visible = false;

            PivotGridField fieldOZEL_TUTAR3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TUTAR3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TUTAR3.AreaIndex = 94;
            fieldOZEL_TUTAR3.FieldName = "OZEL_TUTAR3";
            fieldOZEL_TUTAR3.Name = "fieldOZEL_TUTAR3";
            fieldOZEL_TUTAR3.Visible = false;

            PivotGridField fieldOZEL_TUTAR3_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TUTAR3_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TUTAR3_DOVIZ_ID.AreaIndex = 95;
            fieldOZEL_TUTAR3_DOVIZ_ID.FieldName = "OZEL_TUTAR3_DOVIZ_ID";
            fieldOZEL_TUTAR3_DOVIZ_ID.Name = "fieldOZEL_TUTAR3_DOVIZ_ID";
            fieldOZEL_TUTAR3_DOVIZ_ID.Visible = false;

            PivotGridField fieldSONRAKI_TAZMINAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSONRAKI_TAZMINAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSONRAKI_TAZMINAT.AreaIndex = 96;
            fieldSONRAKI_TAZMINAT.FieldName = "SONRAKI_TAZMINAT";
            fieldSONRAKI_TAZMINAT.Name = "fieldSONRAKI_TAZMINAT";
            fieldSONRAKI_TAZMINAT.Visible = false;

            PivotGridField fieldSONRAKI_TAZMINAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSONRAKI_TAZMINAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSONRAKI_TAZMINAT_DOVIZ_ID.AreaIndex = 97;
            fieldSONRAKI_TAZMINAT_DOVIZ_ID.FieldName = "SONRAKI_TAZMINAT_DOVIZ_ID";
            fieldSONRAKI_TAZMINAT_DOVIZ_ID.Name = "fieldSONRAKI_TAZMINAT_DOVIZ_ID";
            fieldSONRAKI_TAZMINAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldBSMV_TS = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBSMV_TS.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBSMV_TS.AreaIndex = 98;
            fieldBSMV_TS.FieldName = "BSMV_TS";
            fieldBSMV_TS.Name = "fieldBSMV_TS";
            fieldBSMV_TS.Visible = false;

            PivotGridField fieldBSMV_TS_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBSMV_TS_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBSMV_TS_DOVIZ_ID.AreaIndex = 99;
            fieldBSMV_TS_DOVIZ_ID.FieldName = "BSMV_TS_DOVIZ_ID";
            fieldBSMV_TS_DOVIZ_ID.Name = "fieldBSMV_TS_DOVIZ_ID";
            fieldBSMV_TS_DOVIZ_ID.Visible = false;

            PivotGridField fieldOIV_TS = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOIV_TS.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOIV_TS.AreaIndex = 100;
            fieldOIV_TS.FieldName = "OIV_TS";
            fieldOIV_TS.Name = "fieldOIV_TS";
            fieldOIV_TS.Visible = false;

            PivotGridField fieldOIV_TS_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOIV_TS_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOIV_TS_DOVIZ_ID.AreaIndex = 101;
            fieldOIV_TS_DOVIZ_ID.FieldName = "OIV_TS_DOVIZ_ID";
            fieldOIV_TS_DOVIZ_ID.Name = "fieldOIV_TS_DOVIZ_ID";
            fieldOIV_TS_DOVIZ_ID.Visible = false;

            PivotGridField fieldKDV_TS = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKDV_TS.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKDV_TS.AreaIndex = 102;
            fieldKDV_TS.FieldName = "KDV_TS";
            fieldKDV_TS.Name = "fieldKDV_TS";
            fieldKDV_TS.Visible = false;

            PivotGridField fieldKDV_TS_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKDV_TS_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKDV_TS_DOVIZ_ID.AreaIndex = 103;
            fieldKDV_TS_DOVIZ_ID.FieldName = "KDV_TS_DOVIZ_ID";
            fieldKDV_TS_DOVIZ_ID.Name = "fieldKDV_TS_DOVIZ_ID";
            fieldKDV_TS_DOVIZ_ID.Visible = false;

            PivotGridField fieldILK_GIDERLER = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILK_GIDERLER.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILK_GIDERLER.AreaIndex = 104;
            fieldILK_GIDERLER.FieldName = "ILK_GIDERLER";
            fieldILK_GIDERLER.Name = "fieldILK_GIDERLER";
            fieldILK_GIDERLER.Visible = false;

            PivotGridField fieldILK_GIDERLER_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILK_GIDERLER_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILK_GIDERLER_DOVIZ_ID.AreaIndex = 105;
            fieldILK_GIDERLER_DOVIZ_ID.FieldName = "ILK_GIDERLER_DOVIZ_ID";
            fieldILK_GIDERLER_DOVIZ_ID.Name = "fieldILK_GIDERLER_DOVIZ_ID";
            fieldILK_GIDERLER_DOVIZ_ID.Visible = false;

            PivotGridField fieldPESIN_HARC = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPESIN_HARC.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPESIN_HARC.AreaIndex = 106;
            fieldPESIN_HARC.FieldName = "PESIN_HARC";
            fieldPESIN_HARC.Name = "fieldPESIN_HARC";
            fieldPESIN_HARC.Visible = false;

            PivotGridField fieldPESIN_HARC_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPESIN_HARC_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPESIN_HARC_DOVIZ_ID.AreaIndex = 107;
            fieldPESIN_HARC_DOVIZ_ID.FieldName = "PESIN_HARC_DOVIZ_ID";
            fieldPESIN_HARC_DOVIZ_ID.Name = "fieldPESIN_HARC_DOVIZ_ID";
            fieldPESIN_HARC_DOVIZ_ID.Visible = false;

            PivotGridField fieldODENEN_TAHSIL_HARCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODENEN_TAHSIL_HARCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODENEN_TAHSIL_HARCI.AreaIndex = 108;
            fieldODENEN_TAHSIL_HARCI.FieldName = "ODENEN_TAHSIL_HARCI";
            fieldODENEN_TAHSIL_HARCI.Name = "fieldODENEN_TAHSIL_HARCI";
            fieldODENEN_TAHSIL_HARCI.Visible = false;

            PivotGridField fieldODENEN_TAHSIL_HARCI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODENEN_TAHSIL_HARCI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODENEN_TAHSIL_HARCI_DOVIZ_ID.AreaIndex = 109;
            fieldODENEN_TAHSIL_HARCI_DOVIZ_ID.FieldName = "ODENEN_TAHSIL_HARCI_DOVIZ_ID";
            fieldODENEN_TAHSIL_HARCI_DOVIZ_ID.Name = "fieldODENEN_TAHSIL_HARCI_DOVIZ_ID";
            fieldODENEN_TAHSIL_HARCI_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_TAHSIL_HARCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_TAHSIL_HARCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_TAHSIL_HARCI.AreaIndex = 110;
            fieldKALAN_TAHSIL_HARCI.FieldName = "KALAN_TAHSIL_HARCI";
            fieldKALAN_TAHSIL_HARCI.Name = "fieldKALAN_TAHSIL_HARCI";
            fieldKALAN_TAHSIL_HARCI.Visible = false;

            PivotGridField fieldKALAN_TAHSIL_HARCI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_TAHSIL_HARCI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_TAHSIL_HARCI_DOVIZ_ID.AreaIndex = 111;
            fieldKALAN_TAHSIL_HARCI_DOVIZ_ID.FieldName = "KALAN_TAHSIL_HARCI_DOVIZ_ID";
            fieldKALAN_TAHSIL_HARCI_DOVIZ_ID.Name = "fieldKALAN_TAHSIL_HARCI_DOVIZ_ID";
            fieldKALAN_TAHSIL_HARCI_DOVIZ_ID.Visible = false;

            PivotGridField fieldMASAYA_KATILMA_HARCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASAYA_KATILMA_HARCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMASAYA_KATILMA_HARCI.AreaIndex = 112;
            fieldMASAYA_KATILMA_HARCI.FieldName = "MASAYA_KATILMA_HARCI";
            fieldMASAYA_KATILMA_HARCI.Name = "fieldMASAYA_KATILMA_HARCI";
            fieldMASAYA_KATILMA_HARCI.Visible = false;

            PivotGridField fieldMASAYA_KATILMA_HARCI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASAYA_KATILMA_HARCI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMASAYA_KATILMA_HARCI_DOVIZ_ID.AreaIndex = 113;
            fieldMASAYA_KATILMA_HARCI_DOVIZ_ID.FieldName = "MASAYA_KATILMA_HARCI_DOVIZ_ID";
            fieldMASAYA_KATILMA_HARCI_DOVIZ_ID.Name = "fieldMASAYA_KATILMA_HARCI_DOVIZ_ID";
            fieldMASAYA_KATILMA_HARCI_DOVIZ_ID.Visible = false;

            PivotGridField fieldPAYLASMA_HARCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPAYLASMA_HARCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPAYLASMA_HARCI.AreaIndex = 114;
            fieldPAYLASMA_HARCI.FieldName = "PAYLASMA_HARCI";
            fieldPAYLASMA_HARCI.Name = "fieldPAYLASMA_HARCI";
            fieldPAYLASMA_HARCI.Visible = false;

            PivotGridField fieldPAYLASMA_HARCI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPAYLASMA_HARCI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPAYLASMA_HARCI_DOVIZ_ID.AreaIndex = 115;
            fieldPAYLASMA_HARCI_DOVIZ_ID.FieldName = "PAYLASMA_HARCI_DOVIZ_ID";
            fieldPAYLASMA_HARCI_DOVIZ_ID.Name = "fieldPAYLASMA_HARCI_DOVIZ_ID";
            fieldPAYLASMA_HARCI_DOVIZ_ID.Visible = false;

            PivotGridField fieldDAVA_GIDERLERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_GIDERLERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_GIDERLERI.AreaIndex = 116;
            fieldDAVA_GIDERLERI.FieldName = "DAVA_GIDERLERI";
            fieldDAVA_GIDERLERI.Name = "fieldDAVA_GIDERLERI";
            fieldDAVA_GIDERLERI.Visible = false;

            PivotGridField fieldDAVA_GIDERLERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_GIDERLERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_GIDERLERI_DOVIZ_ID.AreaIndex = 117;
            fieldDAVA_GIDERLERI_DOVIZ_ID.FieldName = "DAVA_GIDERLERI_DOVIZ_ID";
            fieldDAVA_GIDERLERI_DOVIZ_ID.Name = "fieldDAVA_GIDERLERI_DOVIZ_ID";
            fieldDAVA_GIDERLERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldDIGER_GIDERLER = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDIGER_GIDERLER.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDIGER_GIDERLER.AreaIndex = 118;
            fieldDIGER_GIDERLER.FieldName = "DIGER_GIDERLER";
            fieldDIGER_GIDERLER.Name = "fieldDIGER_GIDERLER";
            fieldDIGER_GIDERLER.Visible = false;

            PivotGridField fieldDIGER_GIDERLER_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDIGER_GIDERLER_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDIGER_GIDERLER_DOVIZ_ID.AreaIndex = 119;
            fieldDIGER_GIDERLER_DOVIZ_ID.FieldName = "DIGER_GIDERLER_DOVIZ_ID";
            fieldDIGER_GIDERLER_DOVIZ_ID.Name = "fieldDIGER_GIDERLER_DOVIZ_ID";
            fieldDIGER_GIDERLER_DOVIZ_ID.Visible = false;

            PivotGridField fieldTAKIP_VEKALET_UCRETI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_VEKALET_UCRETI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_VEKALET_UCRETI.AreaIndex = 120;
            fieldTAKIP_VEKALET_UCRETI.FieldName = "TAKIP_VEKALET_UCRETI";
            fieldTAKIP_VEKALET_UCRETI.Name = "fieldTAKIP_VEKALET_UCRETI";
            fieldTAKIP_VEKALET_UCRETI.Visible = false;

            PivotGridField fieldTAKIP_VEKALET_UCRETI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_VEKALET_UCRETI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_VEKALET_UCRETI_DOVIZ_ID.AreaIndex = 121;
            fieldTAKIP_VEKALET_UCRETI_DOVIZ_ID.FieldName = "TAKIP_VEKALET_UCRETI_DOVIZ_ID";
            fieldTAKIP_VEKALET_UCRETI_DOVIZ_ID.Name = "fieldTAKIP_VEKALET_UCRETI_DOVIZ_ID";
            fieldTAKIP_VEKALET_UCRETI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTAKIP_VEKALET_UCRETI_KATSAYI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_VEKALET_UCRETI_KATSAYI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_VEKALET_UCRETI_KATSAYI.AreaIndex = 122;
            fieldTAKIP_VEKALET_UCRETI_KATSAYI.FieldName = "TAKIP_VEKALET_UCRETI_KATSAYI";
            fieldTAKIP_VEKALET_UCRETI_KATSAYI.Name = "fieldTAKIP_VEKALET_UCRETI_KATSAYI";
            fieldTAKIP_VEKALET_UCRETI_KATSAYI.Visible = false;

            PivotGridField fieldDAVA_INKAR_TAZMINATI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_INKAR_TAZMINATI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_INKAR_TAZMINATI.AreaIndex = 123;
            fieldDAVA_INKAR_TAZMINATI.FieldName = "DAVA_INKAR_TAZMINATI";
            fieldDAVA_INKAR_TAZMINATI.Name = "fieldDAVA_INKAR_TAZMINATI";
            fieldDAVA_INKAR_TAZMINATI.Visible = false;

            PivotGridField fieldDAVA_INKAR_TAZMINATI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_INKAR_TAZMINATI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_INKAR_TAZMINATI_DOVIZ_ID.AreaIndex = 124;
            fieldDAVA_INKAR_TAZMINATI_DOVIZ_ID.FieldName = "DAVA_INKAR_TAZMINATI_DOVIZ_ID";
            fieldDAVA_INKAR_TAZMINATI_DOVIZ_ID.Name = "fieldDAVA_INKAR_TAZMINATI_DOVIZ_ID";
            fieldDAVA_INKAR_TAZMINATI_DOVIZ_ID.Visible = false;

            PivotGridField fieldDAVA_VEKALET_UCRETI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_VEKALET_UCRETI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_VEKALET_UCRETI.AreaIndex = 125;
            fieldDAVA_VEKALET_UCRETI.FieldName = "DAVA_VEKALET_UCRETI";
            fieldDAVA_VEKALET_UCRETI.Name = "fieldDAVA_VEKALET_UCRETI";
            fieldDAVA_VEKALET_UCRETI.Visible = false;

            PivotGridField fieldDAVA_VEKALET_UCRETI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_VEKALET_UCRETI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_VEKALET_UCRETI_DOVIZ_ID.AreaIndex = 126;
            fieldDAVA_VEKALET_UCRETI_DOVIZ_ID.FieldName = "DAVA_VEKALET_UCRETI_DOVIZ_ID";
            fieldDAVA_VEKALET_UCRETI_DOVIZ_ID.Name = "fieldDAVA_VEKALET_UCRETI_DOVIZ_ID";
            fieldDAVA_VEKALET_UCRETI_DOVIZ_ID.Visible = false;

            PivotGridField fieldMAHSUP_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMAHSUP_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMAHSUP_TOPLAMI.AreaIndex = 127;
            fieldMAHSUP_TOPLAMI.FieldName = "MAHSUP_TOPLAMI";
            fieldMAHSUP_TOPLAMI.Name = "fieldMAHSUP_TOPLAMI";
            fieldMAHSUP_TOPLAMI.Visible = false;

            PivotGridField fieldMAHSUP_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMAHSUP_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMAHSUP_TOPLAMI_DOVIZ_ID.AreaIndex = 128;
            fieldMAHSUP_TOPLAMI_DOVIZ_ID.FieldName = "MAHSUP_TOPLAMI_DOVIZ_ID";
            fieldMAHSUP_TOPLAMI_DOVIZ_ID.Name = "fieldMAHSUP_TOPLAMI_DOVIZ_ID";
            fieldMAHSUP_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldFERAGAT_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFERAGAT_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFERAGAT_TOPLAMI.AreaIndex = 129;
            fieldFERAGAT_TOPLAMI.FieldName = "FERAGAT_TOPLAMI";
            fieldFERAGAT_TOPLAMI.Name = "fieldFERAGAT_TOPLAMI";
            fieldFERAGAT_TOPLAMI.Visible = false;

            PivotGridField fieldFERAGAT_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFERAGAT_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFERAGAT_TOPLAMI_DOVIZ_ID.AreaIndex = 130;
            fieldFERAGAT_TOPLAMI_DOVIZ_ID.FieldName = "FERAGAT_TOPLAMI_DOVIZ_ID";
            fieldFERAGAT_TOPLAMI_DOVIZ_ID.Name = "fieldFERAGAT_TOPLAMI_DOVIZ_ID";
            fieldFERAGAT_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldALACAK_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALACAK_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldALACAK_TOPLAMI.AreaIndex = 131;
            fieldALACAK_TOPLAMI.FieldName = "ALACAK_TOPLAMI";
            fieldALACAK_TOPLAMI.Name = "fieldALACAK_TOPLAMI";
            fieldALACAK_TOPLAMI.Visible = false;

            PivotGridField fieldALACAK_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALACAK_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldALACAK_TOPLAMI_DOVIZ_ID.AreaIndex = 132;
            fieldALACAK_TOPLAMI_DOVIZ_ID.FieldName = "ALACAK_TOPLAMI_DOVIZ_ID";
            fieldALACAK_TOPLAMI_DOVIZ_ID.Name = "fieldALACAK_TOPLAMI_DOVIZ_ID";
            fieldALACAK_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTAHLIYE_VEK_UCR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHLIYE_VEK_UCR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHLIYE_VEK_UCR.AreaIndex = 133;
            fieldTAHLIYE_VEK_UCR.FieldName = "TAHLIYE_VEK_UCR";
            fieldTAHLIYE_VEK_UCR.Name = "fieldTAHLIYE_VEK_UCR";
            fieldTAHLIYE_VEK_UCR.Visible = false;

            PivotGridField fieldTAHLIYE_VEK_UCR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHLIYE_VEK_UCR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHLIYE_VEK_UCR_DOVIZ_ID.AreaIndex = 134;
            fieldTAHLIYE_VEK_UCR_DOVIZ_ID.FieldName = "TAHLIYE_VEK_UCR_DOVIZ_ID";
            fieldTAHLIYE_VEK_UCR_DOVIZ_ID.Name = "fieldTAHLIYE_VEK_UCR_DOVIZ_ID";
            fieldTAHLIYE_VEK_UCR_DOVIZ_ID.Visible = false;

            PivotGridField fieldDIGER_HARC = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDIGER_HARC.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDIGER_HARC.AreaIndex = 135;
            fieldDIGER_HARC.FieldName = "DIGER_HARC";
            fieldDIGER_HARC.Name = "fieldDIGER_HARC";
            fieldDIGER_HARC.Visible = false;

            PivotGridField fieldDIGER_HARC_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDIGER_HARC_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDIGER_HARC_DOVIZ_ID.AreaIndex = 136;
            fieldDIGER_HARC_DOVIZ_ID.FieldName = "DIGER_HARC_DOVIZ_ID";
            fieldDIGER_HARC_DOVIZ_ID.Name = "fieldDIGER_HARC_DOVIZ_ID";
            fieldDIGER_HARC_DOVIZ_ID.Visible = false;

            PivotGridField fieldTD_GIDERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTD_GIDERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTD_GIDERI.AreaIndex = 137;
            fieldTD_GIDERI.FieldName = "TD_GIDERI";
            fieldTD_GIDERI.Name = "fieldTD_GIDERI";
            fieldTD_GIDERI.Visible = false;

            PivotGridField fieldTD_GIDERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTD_GIDERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTD_GIDERI_DOVIZ_ID.AreaIndex = 138;
            fieldTD_GIDERI_DOVIZ_ID.FieldName = "TD_GIDERI_DOVIZ_ID";
            fieldTD_GIDERI_DOVIZ_ID.Name = "fieldTD_GIDERI_DOVIZ_ID";
            fieldTD_GIDERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTD_BAKIYE_HARC = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTD_BAKIYE_HARC.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTD_BAKIYE_HARC.AreaIndex = 139;
            fieldTD_BAKIYE_HARC.FieldName = "TD_BAKIYE_HARC";
            fieldTD_BAKIYE_HARC.Name = "fieldTD_BAKIYE_HARC";
            fieldTD_BAKIYE_HARC.Visible = false;

            PivotGridField fieldTD_BAKIYE_HARC_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTD_BAKIYE_HARC_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTD_BAKIYE_HARC_DOVIZ_ID.AreaIndex = 140;
            fieldTD_BAKIYE_HARC_DOVIZ_ID.FieldName = "TD_BAKIYE_HARC_DOVIZ_ID";
            fieldTD_BAKIYE_HARC_DOVIZ_ID.Name = "fieldTD_BAKIYE_HARC_DOVIZ_ID";
            fieldTD_BAKIYE_HARC_DOVIZ_ID.Visible = false;

            PivotGridField fieldTD_VEK_UCR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTD_VEK_UCR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTD_VEK_UCR.AreaIndex = 141;
            fieldTD_VEK_UCR.FieldName = "TD_VEK_UCR";
            fieldTD_VEK_UCR.Name = "fieldTD_VEK_UCR";
            fieldTD_VEK_UCR.Visible = false;

            PivotGridField fieldTD_VEK_UCR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTD_VEK_UCR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTD_VEK_UCR_DOVIZ_ID.AreaIndex = 142;
            fieldTD_VEK_UCR_DOVIZ_ID.FieldName = "TD_VEK_UCR_DOVIZ_ID";
            fieldTD_VEK_UCR_DOVIZ_ID.Name = "fieldTD_VEK_UCR_DOVIZ_ID";
            fieldTD_VEK_UCR_DOVIZ_ID.Visible = false;

            PivotGridField fieldTD_TEBLIG_GIDERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTD_TEBLIG_GIDERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTD_TEBLIG_GIDERI.AreaIndex = 143;
            fieldTD_TEBLIG_GIDERI.FieldName = "TD_TEBLIG_GIDERI";
            fieldTD_TEBLIG_GIDERI.Name = "fieldTD_TEBLIG_GIDERI";
            fieldTD_TEBLIG_GIDERI.Visible = false;

            PivotGridField fieldTD_TEBLIG_GIDERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTD_TEBLIG_GIDERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTD_TEBLIG_GIDERI_DOVIZ_ID.AreaIndex = 144;
            fieldTD_TEBLIG_GIDERI_DOVIZ_ID.FieldName = "TD_TEBLIG_GIDERI_DOVIZ_ID";
            fieldTD_TEBLIG_GIDERI_DOVIZ_ID.Name = "fieldTD_TEBLIG_GIDERI_DOVIZ_ID";
            fieldTD_TEBLIG_GIDERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldBIRIKMIS_NAFAKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIKMIS_NAFAKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIKMIS_NAFAKA.AreaIndex = 145;
            fieldBIRIKMIS_NAFAKA.FieldName = "BIRIKMIS_NAFAKA";
            fieldBIRIKMIS_NAFAKA.Name = "fieldBIRIKMIS_NAFAKA";
            fieldBIRIKMIS_NAFAKA.Visible = false;

            PivotGridField fieldBIRIKMIS_NAFAKA_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIKMIS_NAFAKA_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIKMIS_NAFAKA_DOVIZ_ID.AreaIndex = 146;
            fieldBIRIKMIS_NAFAKA_DOVIZ_ID.FieldName = "BIRIKMIS_NAFAKA_DOVIZ_ID";
            fieldBIRIKMIS_NAFAKA_DOVIZ_ID.Name = "fieldBIRIKMIS_NAFAKA_DOVIZ_ID";
            fieldBIRIKMIS_NAFAKA_DOVIZ_ID.Visible = false;

            PivotGridField fieldICRA_INKAR_TAZMINATI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_INKAR_TAZMINATI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_INKAR_TAZMINATI.AreaIndex = 147;
            fieldICRA_INKAR_TAZMINATI.FieldName = "ICRA_INKAR_TAZMINATI";
            fieldICRA_INKAR_TAZMINATI.Name = "fieldICRA_INKAR_TAZMINATI";
            fieldICRA_INKAR_TAZMINATI.Visible = false;

            PivotGridField fieldICRA_INKAR_TAZMINATI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_INKAR_TAZMINATI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_INKAR_TAZMINATI_DOVIZ_ID.AreaIndex = 148;
            fieldICRA_INKAR_TAZMINATI_DOVIZ_ID.FieldName = "ICRA_INKAR_TAZMINATI_DOVIZ_ID";
            fieldICRA_INKAR_TAZMINATI_DOVIZ_ID.Name = "fieldICRA_INKAR_TAZMINATI_DOVIZ_ID";
            fieldICRA_INKAR_TAZMINATI_DOVIZ_ID.Visible = false;

            PivotGridField fieldDAMGA_PULU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAMGA_PULU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAMGA_PULU.AreaIndex = 149;
            fieldDAMGA_PULU.FieldName = "DAMGA_PULU";
            fieldDAMGA_PULU.Name = "fieldDAMGA_PULU";
            fieldDAMGA_PULU.Visible = false;

            PivotGridField fieldDAMGA_PULU_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAMGA_PULU_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAMGA_PULU_DOVIZ_ID.AreaIndex = 150;
            fieldDAMGA_PULU_DOVIZ_ID.FieldName = "DAMGA_PULU_DOVIZ_ID";
            fieldDAMGA_PULU_DOVIZ_ID.Name = "fieldDAMGA_PULU_DOVIZ_ID";
            fieldDAMGA_PULU_DOVIZ_ID.Visible = false;

            PivotGridField fieldPROTOKOL_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROTOKOL_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROTOKOL_MIKTARI.AreaIndex = 151;
            fieldPROTOKOL_MIKTARI.FieldName = "PROTOKOL_MIKTARI";
            fieldPROTOKOL_MIKTARI.Name = "fieldPROTOKOL_MIKTARI";
            fieldPROTOKOL_MIKTARI.Visible = false;

            PivotGridField fieldPROTOKOL_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROTOKOL_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROTOKOL_MIKTARI_DOVIZ_ID.AreaIndex = 152;
            fieldPROTOKOL_MIKTARI_DOVIZ_ID.FieldName = "PROTOKOL_MIKTARI_DOVIZ_ID";
            fieldPROTOKOL_MIKTARI_DOVIZ_ID.Name = "fieldPROTOKOL_MIKTARI_DOVIZ_ID";
            fieldPROTOKOL_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldPROTOKOL_FAIZ_ORANI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROTOKOL_FAIZ_ORANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROTOKOL_FAIZ_ORANI.AreaIndex = 153;
            fieldPROTOKOL_FAIZ_ORANI.FieldName = "PROTOKOL_FAIZ_ORANI";
            fieldPROTOKOL_FAIZ_ORANI.Name = "fieldPROTOKOL_FAIZ_ORANI";
            fieldPROTOKOL_FAIZ_ORANI.Visible = false;

            PivotGridField fieldPROTOKOL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROTOKOL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROTOKOL_TARIHI.AreaIndex = 154;
            fieldPROTOKOL_TARIHI.FieldName = "PROTOKOL_TARIHI";
            fieldPROTOKOL_TARIHI.Name = "fieldPROTOKOL_TARIHI";
            fieldPROTOKOL_TARIHI.Visible = false;

            PivotGridField fieldKARSILIK_TUTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKARSILIK_TUTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKARSILIK_TUTARI.AreaIndex = 155;
            fieldKARSILIK_TUTARI.FieldName = "KARSILIK_TUTARI";
            fieldKARSILIK_TUTARI.Name = "fieldKARSILIK_TUTARI";
            fieldKARSILIK_TUTARI.Visible = false;

            PivotGridField fieldKARSILIK_TUTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKARSILIK_TUTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKARSILIK_TUTARI_DOVIZ_ID.AreaIndex = 156;
            fieldKARSILIK_TUTARI_DOVIZ_ID.FieldName = "KARSILIK_TUTARI_DOVIZ_ID";
            fieldKARSILIK_TUTARI_DOVIZ_ID.Name = "fieldKARSILIK_TUTARI_DOVIZ_ID";
            fieldKARSILIK_TUTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI.AreaIndex = 157;
            fieldTO_MASRAF_TOPLAMI.FieldName = "TO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Name = "fieldTO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 158;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI.AreaIndex = 159;
            fieldTS_MASRAF_TOPLAMI.FieldName = "TS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Name = "fieldTS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 160;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI.AreaIndex = 161;
            fieldTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Name = "fieldTUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 162;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldHARC_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHARC_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHARC_TOPLAMI.AreaIndex = 163;
            fieldHARC_TOPLAMI.FieldName = "HARC_TOPLAMI";
            fieldHARC_TOPLAMI.Name = "fieldHARC_TOPLAMI";
            fieldHARC_TOPLAMI.Visible = false;

            PivotGridField fieldHARC_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHARC_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHARC_TOPLAMI_DOVIZ_ID.AreaIndex = 164;
            fieldHARC_TOPLAMI_DOVIZ_ID.FieldName = "HARC_TOPLAMI_DOVIZ_ID";
            fieldHARC_TOPLAMI_DOVIZ_ID.Name = "fieldHARC_TOPLAMI_DOVIZ_ID";
            fieldHARC_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_VEKALET_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_VEKALET_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_VEKALET_TOPLAMI.AreaIndex = 165;
            fieldTO_VEKALET_TOPLAMI.FieldName = "TO_VEKALET_TOPLAMI";
            fieldTO_VEKALET_TOPLAMI.Name = "fieldTO_VEKALET_TOPLAMI";
            fieldTO_VEKALET_TOPLAMI.Visible = false;

            PivotGridField fieldTO_VEKALET_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_VEKALET_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_VEKALET_TOPLAMI_DOVIZ_ID.AreaIndex = 166;
            fieldTO_VEKALET_TOPLAMI_DOVIZ_ID.FieldName = "TO_VEKALET_TOPLAMI_DOVIZ_ID";
            fieldTO_VEKALET_TOPLAMI_DOVIZ_ID.Name = "fieldTO_VEKALET_TOPLAMI_DOVIZ_ID";
            fieldTO_VEKALET_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_VEKALET_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_VEKALET_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_VEKALET_TOPLAMI.AreaIndex = 167;
            fieldTS_VEKALET_TOPLAMI.FieldName = "TS_VEKALET_TOPLAMI";
            fieldTS_VEKALET_TOPLAMI.Name = "fieldTS_VEKALET_TOPLAMI";
            fieldTS_VEKALET_TOPLAMI.Visible = false;

            PivotGridField fieldTS_VEKALET_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_VEKALET_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_VEKALET_TOPLAMI_DOVIZ_ID.AreaIndex = 168;
            fieldTS_VEKALET_TOPLAMI_DOVIZ_ID.FieldName = "TS_VEKALET_TOPLAMI_DOVIZ_ID";
            fieldTS_VEKALET_TOPLAMI_DOVIZ_ID.Name = "fieldTS_VEKALET_TOPLAMI_DOVIZ_ID";
            fieldTS_VEKALET_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_VEKALET_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_VEKALET_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_VEKALET_TOPLAMI.AreaIndex = 169;
            fieldTUM_VEKALET_TOPLAMI.FieldName = "TUM_VEKALET_TOPLAMI";
            fieldTUM_VEKALET_TOPLAMI.Name = "fieldTUM_VEKALET_TOPLAMI";
            fieldTUM_VEKALET_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID.AreaIndex = 170;
            fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID.FieldName = "TUM_VEKALET_TOPLAMI_DOVIZ_ID";
            fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID";
            fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldKARSI_VEKALET_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKARSI_VEKALET_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKARSI_VEKALET_TOPLAMI.AreaIndex = 171;
            fieldKARSI_VEKALET_TOPLAMI.FieldName = "KARSI_VEKALET_TOPLAMI";
            fieldKARSI_VEKALET_TOPLAMI.Name = "fieldKARSI_VEKALET_TOPLAMI";
            fieldKARSI_VEKALET_TOPLAMI.Visible = false;

            PivotGridField fieldKARSI_VEKALET_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKARSI_VEKALET_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKARSI_VEKALET_TOPLAMI_DOVIZ_ID.AreaIndex = 172;
            fieldKARSI_VEKALET_TOPLAMI_DOVIZ_ID.FieldName = "KARSI_VEKALET_TOPLAMI_DOVIZ_ID";
            fieldKARSI_VEKALET_TOPLAMI_DOVIZ_ID.Name = "fieldKARSI_VEKALET_TOPLAMI_DOVIZ_ID";
            fieldKARSI_VEKALET_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldFAIZ_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFAIZ_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFAIZ_TOPLAMI.AreaIndex = 173;
            fieldFAIZ_TOPLAMI.FieldName = "FAIZ_TOPLAMI";
            fieldFAIZ_TOPLAMI.Name = "fieldFAIZ_TOPLAMI";
            fieldFAIZ_TOPLAMI.Visible = false;

            PivotGridField fieldFAIZ_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFAIZ_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFAIZ_TOPLAMI_DOVIZ_ID.AreaIndex = 174;
            fieldFAIZ_TOPLAMI_DOVIZ_ID.FieldName = "FAIZ_TOPLAMI_DOVIZ_ID";
            fieldFAIZ_TOPLAMI_DOVIZ_ID.Name = "fieldFAIZ_TOPLAMI_DOVIZ_ID";
            fieldFAIZ_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldILAM_UCRETLER_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_UCRETLER_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_UCRETLER_TOPLAMI.AreaIndex = 175;
            fieldILAM_UCRETLER_TOPLAMI.FieldName = "ILAM_UCRETLER_TOPLAMI";
            fieldILAM_UCRETLER_TOPLAMI.Name = "fieldILAM_UCRETLER_TOPLAMI";
            fieldILAM_UCRETLER_TOPLAMI.Visible = false;

            PivotGridField fieldILAM_UCRETLER_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_UCRETLER_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_UCRETLER_TOPLAMI_DOVIZ_ID.AreaIndex = 176;
            fieldILAM_UCRETLER_TOPLAMI_DOVIZ_ID.FieldName = "ILAM_UCRETLER_TOPLAMI_DOVIZ_ID";
            fieldILAM_UCRETLER_TOPLAMI_DOVIZ_ID.Name = "fieldILAM_UCRETLER_TOPLAMI_DOVIZ_ID";
            fieldILAM_UCRETLER_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldIT_VEKALET_UCRETI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIT_VEKALET_UCRETI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIT_VEKALET_UCRETI.AreaIndex = 177;
            fieldIT_VEKALET_UCRETI.FieldName = "IT_VEKALET_UCRETI";
            fieldIT_VEKALET_UCRETI.Name = "fieldIT_VEKALET_UCRETI";
            fieldIT_VEKALET_UCRETI.Visible = false;

            PivotGridField fieldIT_VEKALET_UCRETI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIT_VEKALET_UCRETI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIT_VEKALET_UCRETI_DOVIZ_ID.AreaIndex = 178;
            fieldIT_VEKALET_UCRETI_DOVIZ_ID.FieldName = "IT_VEKALET_UCRETI_DOVIZ_ID";
            fieldIT_VEKALET_UCRETI_DOVIZ_ID.Name = "fieldIT_VEKALET_UCRETI_DOVIZ_ID";
            fieldIT_VEKALET_UCRETI_DOVIZ_ID.Visible = false;

            PivotGridField fieldIT_GIDERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIT_GIDERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIT_GIDERI.AreaIndex = 179;
            fieldIT_GIDERI.FieldName = "IT_GIDERI";
            fieldIT_GIDERI.Name = "fieldIT_GIDERI";
            fieldIT_GIDERI.Visible = false;

            PivotGridField fieldIT_GIDERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIT_GIDERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIT_GIDERI_DOVIZ_ID.AreaIndex = 180;
            fieldIT_GIDERI_DOVIZ_ID.FieldName = "IT_GIDERI_DOVIZ_ID";
            fieldIT_GIDERI_DOVIZ_ID.Name = "fieldIT_GIDERI_DOVIZ_ID";
            fieldIT_GIDERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_MAHSUP_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_MAHSUP_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_MAHSUP_TOPLAMI.AreaIndex = 181;
            fieldTO_ODEME_MAHSUP_TOPLAMI.FieldName = "TO_ODEME_MAHSUP_TOPLAMI";
            fieldTO_ODEME_MAHSUP_TOPLAMI.Name = "fieldTO_ODEME_MAHSUP_TOPLAMI";
            fieldTO_ODEME_MAHSUP_TOPLAMI.Visible = false;

            PivotGridField fieldTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID.AreaIndex = 182;
            fieldTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldPAYLASIM_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPAYLASIM_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPAYLASIM_TIPI.AreaIndex = 183;
            fieldPAYLASIM_TIPI.FieldName = "PAYLASIM_TIPI";
            fieldPAYLASIM_TIPI.Name = "fieldPAYLASIM_TIPI";
            fieldPAYLASIM_TIPI.Visible = false;

            PivotGridField fieldBASVURMA_HARCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBASVURMA_HARCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBASVURMA_HARCI.AreaIndex = 184;
            fieldBASVURMA_HARCI.FieldName = "BASVURMA_HARCI";
            fieldBASVURMA_HARCI.Name = "fieldBASVURMA_HARCI";
            fieldBASVURMA_HARCI.Visible = false;

            PivotGridField fieldBASVURMA_HARCI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBASVURMA_HARCI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBASVURMA_HARCI_DOVIZ_ID.AreaIndex = 185;
            fieldBASVURMA_HARCI_DOVIZ_ID.FieldName = "BASVURMA_HARCI_DOVIZ_ID";
            fieldBASVURMA_HARCI_DOVIZ_ID.Name = "fieldBASVURMA_HARCI_DOVIZ_ID";
            fieldBASVURMA_HARCI_DOVIZ_ID.Visible = false;

            PivotGridField fieldVEKALET_HARCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldVEKALET_HARCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldVEKALET_HARCI.AreaIndex = 186;
            fieldVEKALET_HARCI.FieldName = "VEKALET_HARCI";
            fieldVEKALET_HARCI.Name = "fieldVEKALET_HARCI";
            fieldVEKALET_HARCI.Visible = false;

            PivotGridField fieldVEKALET_HARCI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldVEKALET_HARCI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldVEKALET_HARCI_DOVIZ_ID.AreaIndex = 187;
            fieldVEKALET_HARCI_DOVIZ_ID.FieldName = "VEKALET_HARCI_DOVIZ_ID";
            fieldVEKALET_HARCI_DOVIZ_ID.Name = "fieldVEKALET_HARCI_DOVIZ_ID";
            fieldVEKALET_HARCI_DOVIZ_ID.Visible = false;

            PivotGridField fieldVEKALET_PULU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldVEKALET_PULU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldVEKALET_PULU.AreaIndex = 188;
            fieldVEKALET_PULU.FieldName = "VEKALET_PULU";
            fieldVEKALET_PULU.Name = "fieldVEKALET_PULU";
            fieldVEKALET_PULU.Visible = false;

            PivotGridField fieldVEKALET_PULU_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldVEKALET_PULU_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldVEKALET_PULU_DOVIZ_ID.AreaIndex = 189;
            fieldVEKALET_PULU_DOVIZ_ID.FieldName = "VEKALET_PULU_DOVIZ_ID";
            fieldVEKALET_PULU_DOVIZ_ID.Name = "fieldVEKALET_PULU_DOVIZ_ID";
            fieldVEKALET_PULU_DOVIZ_ID.Visible = false;

            PivotGridField fieldIFLAS_BASVURMA_HARCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIFLAS_BASVURMA_HARCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIFLAS_BASVURMA_HARCI.AreaIndex = 190;
            fieldIFLAS_BASVURMA_HARCI.FieldName = "IFLAS_BASVURMA_HARCI";
            fieldIFLAS_BASVURMA_HARCI.Name = "fieldIFLAS_BASVURMA_HARCI";
            fieldIFLAS_BASVURMA_HARCI.Visible = false;

            PivotGridField fieldIFLAS_BASVURMA_HARCI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIFLAS_BASVURMA_HARCI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIFLAS_BASVURMA_HARCI_DOVIZ_ID.AreaIndex = 191;
            fieldIFLAS_BASVURMA_HARCI_DOVIZ_ID.FieldName = "IFLAS_BASVURMA_HARCI_DOVIZ_ID";
            fieldIFLAS_BASVURMA_HARCI_DOVIZ_ID.Name = "fieldIFLAS_BASVURMA_HARCI_DOVIZ_ID";
            fieldIFLAS_BASVURMA_HARCI_DOVIZ_ID.Visible = false;

            PivotGridField fieldIFLASIN_ACILMASI_HARCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIFLASIN_ACILMASI_HARCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIFLASIN_ACILMASI_HARCI.AreaIndex = 192;
            fieldIFLASIN_ACILMASI_HARCI.FieldName = "IFLASIN_ACILMASI_HARCI";
            fieldIFLASIN_ACILMASI_HARCI.Name = "fieldIFLASIN_ACILMASI_HARCI";
            fieldIFLASIN_ACILMASI_HARCI.Visible = false;

            PivotGridField fieldIFLASIN_ACILMASI_HARCI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIFLASIN_ACILMASI_HARCI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIFLASIN_ACILMASI_HARCI_DOVIZ_ID.AreaIndex = 193;
            fieldIFLASIN_ACILMASI_HARCI_DOVIZ_ID.FieldName = "IFLASIN_ACILMASI_HARCI_DOVIZ_ID";
            fieldIFLASIN_ACILMASI_HARCI_DOVIZ_ID.Name = "fieldIFLASIN_ACILMASI_HARCI_DOVIZ_ID";
            fieldIFLASIN_ACILMASI_HARCI_DOVIZ_ID.Visible = false;

            PivotGridField fieldILK_TEBLIGAT_GIDERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILK_TEBLIGAT_GIDERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILK_TEBLIGAT_GIDERI.AreaIndex = 194;
            fieldILK_TEBLIGAT_GIDERI.FieldName = "ILK_TEBLIGAT_GIDERI";
            fieldILK_TEBLIGAT_GIDERI.Name = "fieldILK_TEBLIGAT_GIDERI";
            fieldILK_TEBLIGAT_GIDERI.Visible = false;

            PivotGridField fieldILK_TEBLIGAT_GIDERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILK_TEBLIGAT_GIDERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILK_TEBLIGAT_GIDERI_DOVIZ_ID.AreaIndex = 195;
            fieldILK_TEBLIGAT_GIDERI_DOVIZ_ID.FieldName = "ILK_TEBLIGAT_GIDERI_DOVIZ_ID";
            fieldILK_TEBLIGAT_GIDERI_DOVIZ_ID.Name = "fieldILK_TEBLIGAT_GIDERI_DOVIZ_ID";
            fieldILK_TEBLIGAT_GIDERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTAHLIYE_HARCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHLIYE_HARCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHLIYE_HARCI.AreaIndex = 196;
            fieldTAHLIYE_HARCI.FieldName = "TAHLIYE_HARCI";
            fieldTAHLIYE_HARCI.Name = "fieldTAHLIYE_HARCI";
            fieldTAHLIYE_HARCI.Visible = false;

            PivotGridField fieldTAHLIYE_HARCI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHLIYE_HARCI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHLIYE_HARCI_DOVIZ_ID.AreaIndex = 197;
            fieldTAHLIYE_HARCI_DOVIZ_ID.FieldName = "TAHLIYE_HARCI_DOVIZ_ID";
            fieldTAHLIYE_HARCI_DOVIZ_ID.Name = "fieldTAHLIYE_HARCI_DOVIZ_ID";
            fieldTAHLIYE_HARCI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTESLIM_HARCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTESLIM_HARCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTESLIM_HARCI.AreaIndex = 198;
            fieldTESLIM_HARCI.FieldName = "TESLIM_HARCI";
            fieldTESLIM_HARCI.Name = "fieldTESLIM_HARCI";
            fieldTESLIM_HARCI.Visible = false;

            PivotGridField fieldTESLIM_HARCI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTESLIM_HARCI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTESLIM_HARCI_DOVIZ_ID.AreaIndex = 199;
            fieldTESLIM_HARCI_DOVIZ_ID.FieldName = "TESLIM_HARCI_DOVIZ_ID";
            fieldTESLIM_HARCI_DOVIZ_ID.Name = "fieldTESLIM_HARCI_DOVIZ_ID";
            fieldTESLIM_HARCI_DOVIZ_ID.Visible = false;

            PivotGridField fieldFERAGAT_HARCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFERAGAT_HARCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFERAGAT_HARCI.AreaIndex = 200;
            fieldFERAGAT_HARCI.FieldName = "FERAGAT_HARCI";
            fieldFERAGAT_HARCI.Name = "fieldFERAGAT_HARCI";
            fieldFERAGAT_HARCI.Visible = false;

            PivotGridField fieldFERAGAT_HARCI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFERAGAT_HARCI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFERAGAT_HARCI_DOVIZ_ID.AreaIndex = 201;
            fieldFERAGAT_HARCI_DOVIZ_ID.FieldName = "FERAGAT_HARCI_DOVIZ_ID";
            fieldFERAGAT_HARCI_DOVIZ_ID.Name = "fieldFERAGAT_HARCI_DOVIZ_ID";
            fieldFERAGAT_HARCI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_YONETIMG_TAZMINATI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_YONETIMG_TAZMINATI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_YONETIMG_TAZMINATI.AreaIndex = 202;
            fieldTO_YONETIMG_TAZMINATI.FieldName = "TO_YONETIMG_TAZMINATI";
            fieldTO_YONETIMG_TAZMINATI.Name = "fieldTO_YONETIMG_TAZMINATI";
            fieldTO_YONETIMG_TAZMINATI.Visible = false;

            PivotGridField fieldTO_YONETIMG_TAZMINATI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_YONETIMG_TAZMINATI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_YONETIMG_TAZMINATI_DOVIZ_ID.AreaIndex = 203;
            fieldTO_YONETIMG_TAZMINATI_DOVIZ_ID.FieldName = "TO_YONETIMG_TAZMINATI_DOVIZ_ID";
            fieldTO_YONETIMG_TAZMINATI_DOVIZ_ID.Name = "fieldTO_YONETIMG_TAZMINATI_DOVIZ_ID";
            fieldTO_YONETIMG_TAZMINATI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_HESAP_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_HESAP_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_HESAP_TIP.AreaIndex = 204;
            fieldTS_HESAP_TIP.FieldName = "TS_HESAP_TIP";
            fieldTS_HESAP_TIP.Name = "fieldTS_HESAP_TIP";
            fieldTS_HESAP_TIP.Visible = false;

            PivotGridField fieldTO_HESAP_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_HESAP_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_HESAP_TIP.AreaIndex = 205;
            fieldTO_HESAP_TIP.FieldName = "TO_HESAP_TIP";
            fieldTO_HESAP_TIP.Name = "fieldTO_HESAP_TIP";
            fieldTO_HESAP_TIP.Visible = false;

            PivotGridField fieldASAMA_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASAMA_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASAMA_ADI.AreaIndex = 206;
            fieldASAMA_ADI.FieldName = "ASAMA_ADI";
            fieldASAMA_ADI.Name = "fieldASAMA_ADI";
            fieldASAMA_ADI.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 207;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 208;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 209;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 210;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 211;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 212;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 213;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 214;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldKLASOR_1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_1.AreaIndex = 215;
            fieldKLASOR_1.FieldName = "KLASOR_1";
            fieldKLASOR_1.Name = "fieldKLASOR_1";
            fieldKLASOR_1.Visible = false;

            PivotGridField fieldKLASOR_2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_2.AreaIndex = 216;
            fieldKLASOR_2.FieldName = "KLASOR_2";
            fieldKLASOR_2.Name = "fieldKLASOR_2";
            fieldKLASOR_2.Visible = false;

            PivotGridField fieldICRA_FOY_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_FOY_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_FOY_ID.AreaIndex = 217;
            fieldICRA_FOY_ID.FieldName = "ICRA_FOY_ID";
            fieldICRA_FOY_ID.Name = "fieldICRA_FOY_ID";
            fieldICRA_FOY_ID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldICRA_FOY_ID.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 218;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 219;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldALACAK_NEDENI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALACAK_NEDENI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldALACAK_NEDENI.AreaIndex = 217;
            fieldALACAK_NEDENI.FieldName = "ALACAK_NEDENI";
            fieldALACAK_NEDENI.Name = "fieldALACAK_NEDENI";
            fieldALACAK_NEDENI.Visible = false;

            PivotGridField fieldALACAK_NEDEN_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALACAK_NEDEN_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldALACAK_NEDEN_ID.AreaIndex = 218;
            fieldALACAK_NEDEN_ID.FieldName = "ALACAK_NEDEN_ID";
            fieldALACAK_NEDEN_ID.Name = "fieldALACAK_NEDEN_ID";
            fieldALACAK_NEDEN_ID.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 219;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = null;
            switch (pencere)
            {
                case "Bu Ay İçinde Tahsilat ve Derkenar İle Biten Dosya Sayısı":
                    dizi = BuAyIcindeTahsilatDerkenarIleBitenDosyaSayısı();
                    break;

                case "Bir Sonraki Aya Devreden (Üstteki Satırların Toplamı)":
                case "Bu Ay İçinde Gelen Dosya Sayısı":
                case "Toplam (Devreden Ve Bu Ay Gelen) Dosya Sayısı":
                    dizi = BirSonrakiAyaDevreden();
                    fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
                    fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                    fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
                    fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
                    fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                    break;

                case "Aciz ve Derkenarla Kapanan Dosyaların Anapara Toplamı":
                    dizi = AcizVeDerkenarlaKapananDosyalar();
                    break;

                case "Dosyalarının Durumlarına Göre Dağılımı":
                    dizi = DosyalarinDurumlarinaGoreDagilimi();
                    break;

                case "İcra Dosyalarının Bölümlere Göre Dağılımı":
                    dizi = IcraDosylarininBolumlerineGore();
                    break;

                case "İcra Dosyalarının İcra Form Tipine Göre Dağılımı":
                    dizi = IcraDosyalarininFormTipineGoreDagilimi();
                    break;

                case "İcra Dosyalarının İcra Taleplerine Göre Dağılımı":
                    dizi = IcraDosyalarininIcraTaleplerineGoreDagilimi();
                    break;

                case "İcra Dosyalarının İcra Alacak Nedenlerine Göre Dağılımı":
                    dizi = IcraDosyalarininIcraAlacakNedenlerineGoreDagilimi();
                    break;

                case "İcra Dosyalarının İcra Alacak Nedenlerine Göre Dağılımı Yıllara Göre":
                    dizi = IcraDosyalarininIcraAlacakNedenlerineGoreDagilimiYillaraGore();
                    break;

                case "İcra Dosyalarının Bürolara Göre Dağılımı":
                    dizi = IcraDosyalarininBurolaraGoreDagilimi();
                    break;

                case "İcra Dosyalarının Sorumlu Avukatlara Göre Dağılımı":
                    dizi = IcraDosylarininSorumluAvukatlaraGoreDagilimi();
                    break;

                case "İcra Dosyalarının İzleyen Avukatlara Göre Dağılımı":
                    dizi = IcraDosylarininIzleyenAvukatlaraGoreDagilimi();
                    break;

                case "İcra Dosyalarının Durumlarına Göre Dağılımı":
                    dizi = IcraDosylarininDurumlarinaGoreDagilimi();
                    break;

                case "İcra Dosyalarının Bölgelere Göre Dağılımı":
                    dizi = IcraDosylarininBolgelereGoreDagilimi();
                    break;

                case "İcra Dosyalarının Şubelere Göre Dağılımı":
                    dizi = IcraDosylarininSubelereGoreDagilimi();
                    break;

                case "İcra Dosyalarının Kredi Tiplerine Göre Dağılımı":
                    dizi = IcraDosylarininKrediTipineGoreDagilimi();
                    break;

                case "Takibe Konulan İcra Dosyalarının Kapananlara Oranı Aylara Göre":
                    dizi = TakibeKonulanIcraDosylarininKapananlaraOranıAylaraGore();
                    break;

                case "Takibe Konulan İcra Dosyalarının Kapananlara Oranı Yıllara Göre":
                    dizi = TakibeKonulanIcraDosylarininKapananlaraOranıYillaraGore();
                    break;

                case "Takibe Konulan İcra Dosyalarının Kapananlara Oranı Hukuk Bürolarına Göre":
                    dizi = TakibeKonulanIcraDosylarininKapananlaraOranıBurolaraGore();
                    break;

                case "Takibe Konulan İcra Dosyalarının Kapananlara Oranı Yılın Çeyreklerine Göre":
                    dizi = TakibeKonulanIcraDosylarininKapananlaraOranıYilinCeyreklerineGore();
                    break;

                case "Takibe Konulan İcra Dosyalarının Kapananlara Oranı Hukuk Birimlerine Göre":
                    dizi = TakibeKonulanIcraDosylarininKapananlaraOranıBirimlereGore();
                    break;

                case "Takibe Konulan İcra Dosyalarının Kapananlara Oranı Hukuk Bölgelere Göre":
                    dizi = TakibeKonulanIcraDosylarininKapananlaraOranıBolgelereGore();
                    break;

                case "Takibe Konulan İcra Dosyalarının Kapananlara Oranı Hukuk Şubelere Göre":
                    dizi = TakibeKonulanIcraDosylarininKapananlaraOranıSubelereGore();
                    break;

                case "Takibe Konulan İcra Dosyalarının Kapananlara Oranı Hukuk Kredi Tiplerine Göre":
                    dizi = TakibeKonulanIcraDosylarininKapananlaraOranıKrediTiplerineGore();
                    break;

                case "İcra Dosyası Kapama Ortalaması Hukuk Bürolarına Göre":
                case "Kapama Sayısı (Bürolara Göre)":
                    dizi = IcraDosyasiKapamaOrtalamasıBurolaraGore();
                    break;

                case "Kapama Sayısı (Aylara, Yıllara Göre)":
                case "Açılan Takip Sayısı (Aylara, Yıllara Göre)":
                    dizi = KapamaSayisiAylaraYillaraGore();
                    break;

                case "İcra Dosyalarinin Diğer Takip Kalemlerine Göre Dağilimi":
                    dizi = IcraDosyalarininDigerTakipKalemlerineGoreDagilimi();
                    break;

                case "İcra Dosyalarinin Alacak Miktarlarına Gore Dağilimi":
                    dizi = IcraDosyalarininAlacakMiktarlarinaGoreDagilimi();
                    break;
                default:
                    dizi = null;
                    break;
            }

            #region []

            if (dizi == null)
            {
                dizi = new PivotGridField[]
		{
			fieldFOY_NO,
			fieldREFERANS_NO,
			fieldREFERANS_NO2,
			fieldREFERANS_NO3,
			fieldTAKIP_TARIHI,
			fieldESAS_NO,
			fieldICRA_OZEL_KOD3_ID,
			fieldICRA_OZEL_KOD4_ID,
			fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			fieldASIL_ALACAK_DOVIZ_ID,
			fieldASIL_ALACAK,
			fieldISLEMIS_FAIZ_DOVIZ_ID,
			fieldISLEMIS_FAIZ,
			fieldTAKIP_CIKISI,
			fieldTAKIP_CIKISI_DOVIZ_ID,
			fieldSONRAKI_FAIZ,
			fieldSONRAKI_FAIZ_DOVIZ_ID,
			fieldODEME_TOPLAMI_DOVIZ_ID,
			fieldODEME_TOPLAMI,
			fieldTO_ODEME_TOPLAMI_DOVIZ_ID,
			fieldTO_ODEME_TOPLAMI,
			fieldKALAN,
			fieldKALAN_DOVIZ_ID,
			fieldACIKLAMA,
			fieldKAPAMA_TARIHI,
			fieldRISK_MIKTARI,
			fieldRISK_MIKTARI_DOVIZ_ID,
			fieldTS_MASRAF_HARC_TOPLAMI,
			fieldTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID,
			fieldSUBE_KOD_ID,
			fieldKONTROL_KIM_ID,
			fieldID,
			fieldTAKIP_EDEN,
			fieldTAKIP_EDILEN,
			fieldIZLEYEN,
			fieldSORUMLU,
			fieldTAKIP_EDEN_SIFAT,
			fieldTAKIP_EDILEN_SIFAT,
			fieldTALEP_ADI,
			fieldFORM_TIPI,
			fieldDURUM,
			fieldICRA_ADLIYE,
			fieldICRA_BIRIM_NO,
			fieldOZEL_KOD1,
			fieldOZEL_KOD2,
			fieldOZEL_KOD3,
			fieldOZEL_KOD4,
			fieldFOY_ARSIV_TARIHI,
			fieldFOY_INFAZ_TARIHI,
			fieldTAKIBIN_MUVEKKILE_IADE_TARIHI,
			fieldSON_HESAP_TARIHI,
			fieldBIR_YIL_KAC_GUN,
			fieldBSMV_TO,
			fieldBSMV_TO_DOVIZ_ID,
			fieldKKDV_TO,
			fieldKKDV_TO_DOVIZ_ID,
			fieldKDV_TO,
			fieldKDV_TO_DOVIZ_ID,
			fieldIH_VEKALET_UCRETI,
			fieldIH_VEKALET_UCRETI_DOVIZ_ID,
			fieldIH_GIDERI,
			fieldIH_GIDERI_DOVIZ_ID,
			fieldIT_HACIZDE_ODENEN,
			fieldIT_HACIZDE_ODENEN_DOVIZ_ID,
			fieldKARSILIKSIZ_CEK_TAZMINATI,
			fieldKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID,
			fieldCEK_KOMISYONU,
			fieldCEK_KOMISYONU_DOVIZ_ID,
			fieldILAM_YARGILAMA_GIDERI,
			fieldILAM_YARGILAMA_GIDERI_DOVIZ_ID,
			fieldILAM_BK_YARG_ONAMA,
			fieldILAM_BK_YARG_ONAMA_DOVIZ_ID,
			fieldILAM_TEBLIG_GIDERI,
			fieldILAM_TEBLIG_GIDERI_DOVIZ_ID,
			fieldILAM_INKAR_TAZMINATI,
			fieldILAM_INKAR_TAZMINATI_DOVIZ_ID,
			fieldILAM_VEK_UCR,
			fieldILAM_VEK_UCR_DOVIZ_ID,
			fieldOIV_TO,
			fieldOIV_TO_DOVIZ_ID,
			fieldPROTESTO_GIDERI,
			fieldPROTESTO_GIDERI_DOVIZ_ID,
			fieldIHTAR_GIDERI,
			fieldIHTAR_GIDERI_DOVIZ_ID,
			fieldOZEL_TAZMINAT,
			fieldOZEL_TAZMINAT_DOVIZ_ID,
			fieldOZEL_TUTAR1_FAIZ_ORANI,
			fieldOZEL_TUTAR_KONU1,
			fieldOZEL_TUTAR_KONU2,
			fieldOZEL_TUTAR_KONU3,
			fieldOZEL_TUTAR1,
			fieldOZEL_TUTAR1_DOVIZ_ID,
			fieldOZEL_TUTAR2,
			fieldOZEL_TUTAR2_DOVIZ_ID,
			fieldOZEL_TUTAR3,
			fieldOZEL_TUTAR3_DOVIZ_ID,
			fieldSONRAKI_TAZMINAT,
			fieldSONRAKI_TAZMINAT_DOVIZ_ID,
			fieldBSMV_TS,
			fieldBSMV_TS_DOVIZ_ID,
			fieldOIV_TS,
			fieldOIV_TS_DOVIZ_ID,
			fieldKDV_TS,
			fieldKDV_TS_DOVIZ_ID,
			fieldILK_GIDERLER,
			fieldILK_GIDERLER_DOVIZ_ID,
			fieldPESIN_HARC,
			fieldPESIN_HARC_DOVIZ_ID,
			fieldODENEN_TAHSIL_HARCI,
			fieldODENEN_TAHSIL_HARCI_DOVIZ_ID,
			fieldKALAN_TAHSIL_HARCI,
			fieldKALAN_TAHSIL_HARCI_DOVIZ_ID,
			fieldMASAYA_KATILMA_HARCI,
			fieldMASAYA_KATILMA_HARCI_DOVIZ_ID,
			fieldPAYLASMA_HARCI,
			fieldPAYLASMA_HARCI_DOVIZ_ID,
			fieldDAVA_GIDERLERI,
			fieldDAVA_GIDERLERI_DOVIZ_ID,
			fieldDIGER_GIDERLER,
			fieldDIGER_GIDERLER_DOVIZ_ID,
			fieldTAKIP_VEKALET_UCRETI,
			fieldTAKIP_VEKALET_UCRETI_DOVIZ_ID,
			fieldTAKIP_VEKALET_UCRETI_KATSAYI,
			fieldDAVA_INKAR_TAZMINATI,
			fieldDAVA_INKAR_TAZMINATI_DOVIZ_ID,
			fieldDAVA_VEKALET_UCRETI,
			fieldDAVA_VEKALET_UCRETI_DOVIZ_ID,
			fieldMAHSUP_TOPLAMI,
			fieldMAHSUP_TOPLAMI_DOVIZ_ID,
			fieldFERAGAT_TOPLAMI,
			fieldFERAGAT_TOPLAMI_DOVIZ_ID,
			fieldALACAK_TOPLAMI,
			fieldALACAK_TOPLAMI_DOVIZ_ID,
			fieldTAHLIYE_VEK_UCR,
			fieldTAHLIYE_VEK_UCR_DOVIZ_ID,
			fieldDIGER_HARC,
			fieldDIGER_HARC_DOVIZ_ID,
			fieldTD_GIDERI,
			fieldTD_GIDERI_DOVIZ_ID,
			fieldTD_BAKIYE_HARC,
			fieldTD_BAKIYE_HARC_DOVIZ_ID,
			fieldTD_VEK_UCR,
			fieldTD_VEK_UCR_DOVIZ_ID,
			fieldTD_TEBLIG_GIDERI,
			fieldTD_TEBLIG_GIDERI_DOVIZ_ID,
			fieldBIRIKMIS_NAFAKA,
			fieldBIRIKMIS_NAFAKA_DOVIZ_ID,
			fieldICRA_INKAR_TAZMINATI,
			fieldICRA_INKAR_TAZMINATI_DOVIZ_ID,
			fieldDAMGA_PULU,
			fieldDAMGA_PULU_DOVIZ_ID,
			fieldPROTOKOL_MIKTARI,
			fieldPROTOKOL_MIKTARI_DOVIZ_ID,
			fieldPROTOKOL_FAIZ_ORANI,
			fieldPROTOKOL_TARIHI,
			fieldKARSILIK_TUTARI,
			fieldKARSILIK_TUTARI_DOVIZ_ID,
			fieldTO_MASRAF_TOPLAMI,
			fieldTO_MASRAF_TOPLAMI_DOVIZ_ID,
			fieldTS_MASRAF_TOPLAMI,
			fieldTS_MASRAF_TOPLAMI_DOVIZ_ID,
			fieldTUM_MASRAF_TOPLAMI,
			fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID,
			fieldHARC_TOPLAMI,
			fieldHARC_TOPLAMI_DOVIZ_ID,
			fieldTO_VEKALET_TOPLAMI,
			fieldTO_VEKALET_TOPLAMI_DOVIZ_ID,
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
			fieldIT_VEKALET_UCRETI,
			fieldIT_VEKALET_UCRETI_DOVIZ_ID,
			fieldIT_GIDERI,
			fieldIT_GIDERI_DOVIZ_ID,
			fieldTO_ODEME_MAHSUP_TOPLAMI,
			fieldTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID,
			fieldPAYLASIM_TIPI,
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
			fieldTO_YONETIMG_TAZMINATI,
			fieldTO_YONETIMG_TAZMINATI_DOVIZ_ID,
			fieldTS_HESAP_TIP,
			fieldTO_HESAP_TIP,
			fieldASAMA_ADI,
			fieldBANKA,
			fieldBANKA_SUBE,
			fieldFOY_BIRIM,
			fieldFOY_YERI,
			fieldTAHSILAT_DURUM,
			fieldFOY_OZEL_DURUM,
			fieldKREDI_GRUP,
			fieldKREDI_TIP,
			fieldKLASOR_1,
			fieldKLASOR_2,
			fieldICRA_FOY_ID,
			fieldBOLGE,
			fieldBOLUM,
            fieldALACAK_NEDENI,
			fieldALACAK_NEDEN_ID,
			};
            }

            #endregion []

            #region Field Caption

            if (captionlar == null)
                captionlar = GetCaptionDictinory();
            if (editler == null)
                editler = GetRepositoryItemDictinory();

            for (int i = 0; i < dizi.Length; i++)
            {
                string caption = string.Empty;
                if (captionlar.ContainsKey(dizi[i].FieldName))
                    caption = captionlar[dizi[i].FieldName];
                if (caption.Length > 0)
                    dizi[i].Caption = caption;
                else if (dizi[i].FieldName.ToLower().Contains("doviz_id"))
                {
                    dizi[i].Caption = "Brm";
                    dizi[i].ToolTips.ValueText = dizi[i].FieldName.Replace('_', ' ').Replace("ID", " ").ToString();
                }

                if (dizi[i].FieldName.Contains("_DOVIZ_ID"))
                {
                    dizi[i].FieldEdit = editler["DovizId"];
                    dizi[i].Caption = "Brm";
                    dizi[i].ToolTips.ValueText = dizi[i].FieldName.Replace('_', ' ').Replace("ID", " ").ToString();
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

            #region Özelleştirme

            AvukatProLib.CompInfo cm = Program.compList[0];
            string RefNo, RefNo2, refNo3, OzelKod1, OzelKod2, OzelKod3, OzelKod4, ANRefNo, ANRefNo2, ANRefNo3;
            var icrarefoz = AvukatProLib.OzelKodReferans.OzelKodReferans.GetIcraOzelKodReferans(cm.ConStr);
            if (string.IsNullOrEmpty(icrarefoz.IcraReferans1))
                RefNo = "Ref No";
            else
                RefNo = icrarefoz.IcraReferans1;

            if (string.IsNullOrEmpty(icrarefoz.IcraReferans2))
                RefNo2 = "Ref No2";
            else
                RefNo2 = icrarefoz.IcraReferans2;

            if (string.IsNullOrEmpty(icrarefoz.IcraReferans3))
                refNo3 = "Ref No3";
            else
                refNo3 = icrarefoz.IcraReferans3;

            if (string.IsNullOrEmpty(icrarefoz.IcraOzelKod1))
                OzelKod1 = "Özel Kod1";
            else
                OzelKod1 = icrarefoz.IcraOzelKod1;

            if (string.IsNullOrEmpty(icrarefoz.IcraOzelKod2))
                OzelKod2 = "Özel Kod2";
            else
                OzelKod2 = icrarefoz.IcraOzelKod2;

            if (string.IsNullOrEmpty(icrarefoz.IcraOzelKod3))
                OzelKod3 = "Özel Kod3";
            else
                OzelKod3 = icrarefoz.IcraOzelKod3;

            if (string.IsNullOrEmpty(icrarefoz.IcraOzelKod4))
                OzelKod4 = "Özel Kod4";
            else
                OzelKod4 = icrarefoz.IcraOzelKod4;
            if (string.IsNullOrEmpty(icrarefoz.IcraANrefarans1))
                ANRefNo = "Kredi Kartı Numarası";
            else
                ANRefNo = icrarefoz.IcraANrefarans1;
            if (string.IsNullOrEmpty(icrarefoz.IcraANreferans2))
                ANRefNo2 = "Hesap No";
            else
                ANRefNo2 = icrarefoz.IcraANreferans2;
            if (string.IsNullOrEmpty(icrarefoz.IcraANreferans3))
                ANRefNo3 = "Kebir";
            else
                ANRefNo3 = icrarefoz.IcraANreferans3;

            #endregion Özelleştirme

            #region Caption Edit

            dicFieldCaption.Add("FOY_NO", "Foy No");
            dicFieldCaption.Add("REFERANS_NO", RefNo);
            dicFieldCaption.Add("REFERANS_NO2", RefNo2);
            dicFieldCaption.Add("REFERANS_NO3", refNo3);
            dicFieldCaption.Add("TAKIP_TARIHI", "Takip T.");
            dicFieldCaption.Add("ESAS_NO", "Esas No");
            dicFieldCaption.Add("ICRA_OZEL_KOD3_ID", "");
            dicFieldCaption.Add("ICRA_OZEL_KOD4_ID", "");
            dicFieldCaption.Add("TAKIBIN_AVUKATA_INTIKAL_TARIHI", "İntikal T.");
            dicFieldCaption.Add("ASIL_ALACAK", "Asıl Alacak");
            dicFieldCaption.Add("ISLEMIS_FAIZ", "İşlenmiş Faiz");
            dicFieldCaption.Add("TAKIP_CIKISI", "Takip Çıkışı");
            dicFieldCaption.Add("SONRAKI_FAIZ", "Sonraki Faiz");
            dicFieldCaption.Add("ODEME_TOPLAMI", "Ödeme Toplamı");
            dicFieldCaption.Add("TO_ODEME_TOPLAMI", "T.Ö Ödeme Toplamı");
            dicFieldCaption.Add("KALAN", "Kalan");
            dicFieldCaption.Add("ACIKLAMA", "Açıklama");
            dicFieldCaption.Add("KAPAMA_TARIHI", "Kapama T.");
            dicFieldCaption.Add("RISK_MIKTARI", "Risk Miktarı");
            dicFieldCaption.Add("TS_MASRAF_HARC_TOPLAMI", "TS Masraf Harç Toplamı");
            dicFieldCaption.Add("SUBE_KOD_ID", "Büro");
            dicFieldCaption.Add("KONTROL_KIM_ID", "Kullanıcı");
            dicFieldCaption.Add("ID", "");
            dicFieldCaption.Add("TAKIP_EDEN", "Takip Eden");
            dicFieldCaption.Add("TAKIP_EDILEN", "Takip Edilen");
            dicFieldCaption.Add("IZLEYEN", "İzleyen");
            dicFieldCaption.Add("SORUMLU", "Sorumlu");
            dicFieldCaption.Add("TAKIP_EDEN_SIFAT", "Takip Eden Sıfat");
            dicFieldCaption.Add("TAKIP_EDILEN_SIFAT", "Takip Edilen Sıfat");
            dicFieldCaption.Add("TALEP_ADI", "Talep Adı");
            dicFieldCaption.Add("FORM_TIPI", "Form Tipi");
            dicFieldCaption.Add("DURUM", "Durum");
            dicFieldCaption.Add("ICRA_ADLIYE", "Adliye");
            dicFieldCaption.Add("ICRA_BIRIM_NO", "Birim No");
            dicFieldCaption.Add("OZEL_KOD1", OzelKod1);
            dicFieldCaption.Add("OZEL_KOD2", OzelKod2);
            dicFieldCaption.Add("OZEL_KOD3", OzelKod3);
            dicFieldCaption.Add("OZEL_KOD4", OzelKod4);
            dicFieldCaption.Add("FOY_ARSIV_TARIHI", "Arşiv T.");
            dicFieldCaption.Add("FOY_INFAZ_TARIHI", "İnfaz T.");
            dicFieldCaption.Add("TAKIBIN_MUVEKKILE_IADE_TARIHI", "Takibin Müvekkile İade T.");
            dicFieldCaption.Add("SON_HESAP_TARIHI", "Son Hesap T.");
            dicFieldCaption.Add("BIR_YIL_KAC_GUN", "Bir Yıl Kaç Gün");
            dicFieldCaption.Add("BSMV_TO", "BSMV");
            dicFieldCaption.Add("KKDV_TO", "KKDV");
            dicFieldCaption.Add("KDV_TO", "KDV");
            dicFieldCaption.Add("IH_VEKALET_UCRETI", "Vekalet Ücreti");
            dicFieldCaption.Add("IH_GIDERI", "İhtar Gideri");
            dicFieldCaption.Add("IT_HACIZDE_ODENEN", "Hacizde Ödenen");
            dicFieldCaption.Add("KARSILIKSIZ_CEK_TAZMINATI", "Karşılıksız Çek Tazminatı");
            dicFieldCaption.Add("CEK_KOMISYONU", "Çek Komisyonu");
            dicFieldCaption.Add("ILAM_YARGILAMA_GIDERI", "İlam Yargılama Gideri");
            dicFieldCaption.Add("ILAM_BK_YARG_ONAMA", "BK Yarg Onama");
            dicFieldCaption.Add("ILAM_TEBLIG_GIDERI", "Tebliğ Gideri");
            dicFieldCaption.Add("ILAM_INKAR_TAZMINATI", "İnkar Tazminatı");
            dicFieldCaption.Add("ILAM_VEK_UCR", "İlam Vek Ücreti");
            dicFieldCaption.Add("OIV_TO", "OIV");
            dicFieldCaption.Add("PROTESTO_GIDERI", "Protesto Gideri");
            dicFieldCaption.Add("IHTAR_GIDERI", "İhtar Gideri");
            dicFieldCaption.Add("OZEL_TAZMINAT", "Özel Tazminat");
            dicFieldCaption.Add("OZEL_TUTAR1_FAIZ_ORANI", "Özel Tutar Faiz Oranı");
            dicFieldCaption.Add("OZEL_TUTAR_KONU1", "Özel Tutar Konu1");
            dicFieldCaption.Add("OZEL_TUTAR_KONU2", "Özel Tutar Konu2");
            dicFieldCaption.Add("OZEL_TUTAR_KONU3", "Özel Tutar Konu3");
            dicFieldCaption.Add("OZEL_TUTAR1", "Özel Tutar1");
            dicFieldCaption.Add("OZEL_TUTAR2", "Özel Tutar2");
            dicFieldCaption.Add("OZEL_TUTAR3", "Özel Tutar3");
            dicFieldCaption.Add("SONRAKI_TAZMINAT", "Sonraki Tazminat");
            dicFieldCaption.Add("BSMV_TS", "BSMV T.S.");
            dicFieldCaption.Add("OIV_TS", "OIV TS");
            dicFieldCaption.Add("KDV_TS", "KDV TS");
            dicFieldCaption.Add("ILK_GIDERLER", "İlk Giderler");
            dicFieldCaption.Add("PESIN_HARC", "Peşin Harç");
            dicFieldCaption.Add("ODENEN_TAHSIL_HARCI", "Ödenen Tahsil Harcı");
            dicFieldCaption.Add("KALAN_TAHSIL_HARCI", "Kalan Tahsil Harcı");
            dicFieldCaption.Add("MASAYA_KATILMA_HARCI", "Masaya Katılma Harcı");
            dicFieldCaption.Add("PAYLASMA_HARCI", "Paylaşma Harcı");
            dicFieldCaption.Add("DAVA_GIDERLERI", "Dava Giderleri");
            dicFieldCaption.Add("DIGER_GIDERLER", "Diğer Giderler");
            dicFieldCaption.Add("TAKIP_VEKALET_UCRETI", "Takip Vekalet Ücreti");
            dicFieldCaption.Add("TAKIP_VEKALET_UCRETI_KATSAYI", "Takip Vekalet Katsayı");
            dicFieldCaption.Add("DAVA_INKAR_TAZMINATI", "Dava İnkar Tazminatı");
            dicFieldCaption.Add("DAVA_VEKALET_UCRETI", "Dava Vekalet Ücreti");
            dicFieldCaption.Add("MAHSUP_TOPLAMI", "Mahsup Toplamı");
            dicFieldCaption.Add("FERAGAT_TOPLAMI", "Feragat Toplamı");
            dicFieldCaption.Add("ALACAK_TOPLAMI", "Alacak Toplamı");
            dicFieldCaption.Add("TAHLIYE_VEK_UCR", "Tahliye Vek Ücr.");
            dicFieldCaption.Add("DIGER_HARC", "Diğer Harç");
            dicFieldCaption.Add("TD_GIDERI", "TD Gideri");
            dicFieldCaption.Add("TD_BAKIYE_HARC", "TD Bakiye Harç");
            dicFieldCaption.Add("TD_VEK_UCR", "TD Vek Ücr");
            dicFieldCaption.Add("TD_TEBLIG_GIDERI", "TD Tebliğ Gideri");
            dicFieldCaption.Add("BIRIKMIS_NAFAKA", "Birikmiş Nafaka");
            dicFieldCaption.Add("ICRA_INKAR_TAZMINATI", "İnkar Taz.");
            dicFieldCaption.Add("DAMGA_PULU", "Damga Pulu");
            dicFieldCaption.Add("PROTOKOL_MIKTARI", "Protokol Mik");
            dicFieldCaption.Add("PROTOKOL_FAIZ_ORANI", "Protokol Faiz Orn.");
            dicFieldCaption.Add("PROTOKOL_TARIHI", "Protokol T.");
            dicFieldCaption.Add("KARSILIK_TUTARI", "Karşılık Tutarı");
            dicFieldCaption.Add("TO_MASRAF_TOPLAMI", "T.Ö. Masraf Toplamı");
            dicFieldCaption.Add("TS_MASRAF_TOPLAMI", "T.S. Masraf Toplamı");
            dicFieldCaption.Add("TUM_MASRAF_TOPLAMI", "Tüm Masraf Toplamı");
            dicFieldCaption.Add("HARC_TOPLAMI", "Harç Toplamı");
            dicFieldCaption.Add("TO_VEKALET_TOPLAMI", "T.Ö. Vekalet Toplamı");
            dicFieldCaption.Add("TS_VEKALET_TOPLAMI", "T.S. Vekalet Toplamı");
            dicFieldCaption.Add("TUM_VEKALET_TOPLAMI", "Tüm Vekalet Toplamı");
            dicFieldCaption.Add("KARSI_VEKALET_TOPLAMI", "Karşı Vekalet Toplamı");
            dicFieldCaption.Add("FAIZ_TOPLAMI", "Faiz Toplamı");
            dicFieldCaption.Add("ILAM_UCRETLER_TOPLAMI", "İlam Vek.Ücretleri Toplamı");
            dicFieldCaption.Add("IT_VEKALET_UCRETI", "I.T. Vekalet Ücreti");
            dicFieldCaption.Add("IT_GIDERI", "İ.T. Gideri");
            dicFieldCaption.Add("TO_ODEME_MAHSUP_TOPLAMI", "T.Ö. Ödeme Mahsup Toplamı");
            dicFieldCaption.Add("PAYLASIM_TIPI", "Paylaşım Tipi");
            dicFieldCaption.Add("BASVURMA_HARCI", "Başvurma Harcı");
            dicFieldCaption.Add("VEKALET_HARCI", "Vekalet Harcı");
            dicFieldCaption.Add("VEKALET_PULU", "Vekalet Pulu");
            dicFieldCaption.Add("IFLAS_BASVURMA_HARCI", "İflas Başvurma Harcı");
            dicFieldCaption.Add("IFLASIN_ACILMASI_HARCI", "İflasın Açılması Harcı");
            dicFieldCaption.Add("ILK_TEBLIGAT_GIDERI", "İlk Tebligat Gideri");
            dicFieldCaption.Add("TAHLIYE_HARCI", "Tahliye Harcı");
            dicFieldCaption.Add("TESLIM_HARCI", "Teslim Harcı");
            dicFieldCaption.Add("FERAGAT_HARCI", "Feragat Harcı");
            dicFieldCaption.Add("TO_YONETIMG_TAZMINATI", "T.Ö. Yönetim Tazminatı");
            dicFieldCaption.Add("TS_HESAP_TIP", "T.S. Hesap Tipi");
            dicFieldCaption.Add("TO_HESAP_TIP", "T.Ö. Hesap Tipi");
            dicFieldCaption.Add("ASAMA_ADI", "Aşama");
            dicFieldCaption.Add("BANKA", "Banka");
            dicFieldCaption.Add("BANKA_SUBE", "Banka Şube");
            dicFieldCaption.Add("FOY_BIRIM", "Foy Birim");
            dicFieldCaption.Add("FOY_YERI", "Foy Yeri");
            dicFieldCaption.Add("TAHSILAT_DURUM", "Tahsilat Durum");
            dicFieldCaption.Add("FOY_OZEL_DURUM", "Foy Özel Durum");
            dicFieldCaption.Add("KREDI_GRUP", "Kredi Grup");
            dicFieldCaption.Add("KREDI_TIP", "Kredi Tip");
            dicFieldCaption.Add("KLASOR_1", "Klasör 1");
            dicFieldCaption.Add("KLASOR_2", "Klasör 2");
            dicFieldCaption.Add("ICRA_FOY_ID", "Dosya Sayisi");
            dicFieldCaption.Add("BOLGE", "Bölge");
            dicFieldCaption.Add("BOLUM", "Bölüm");
            dicFieldCaption.Add("ALACAK_NEDENI", "");
            dicFieldCaption.Add("ALACAK_NEDEN_ID", "");
            dicFieldCaption.Add("GOREV", "");

            #endregion Caption Edit

            return dicFieldCaption;
        }

        private Dictionary<string, RepositoryItem> GetRepositoryItemDictinory()
        {
            Dictionary<string, RepositoryItem> sozluk = new Dictionary<string, RepositoryItem>();

            #region Add item

            sozluk.Add("DovizId", InitsEx.DovizTipGetir);
            sozluk.Add("SUBE_KOD_ID", InitsEx.SubeKod);
            sozluk.Add("KONTROL_KIM_ID", InitsEx.KontrolKim);
            sozluk.Add("KALAN", InitsEx.ParaBicimiAyarla);
            sozluk.Add("RISK_MIKTARI", InitsEx.ParaBicimiAyarla);
            sozluk.Add("RISK_MIKTARI_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("OZEL_TUTAR1_FAIZ_ORANI", InitsEx.ParaBicimiAyarla);
            sozluk.Add("OZEL_TUTAR1", InitsEx.ParaBicimiAyarla);
            sozluk.Add("OZEL_TUTAR1_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("OZEL_TUTAR2", InitsEx.ParaBicimiAyarla);
            sozluk.Add("OZEL_TUTAR2_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("OZEL_TUTAR3", InitsEx.ParaBicimiAyarla);
            sozluk.Add("OZEL_TUTAR3_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("KALAN_TAHSIL_HARCI", InitsEx.ParaBicimiAyarla);
            sozluk.Add("PROTOKOL_MIKTARI", InitsEx.ParaBicimiAyarla);
            sozluk.Add("PROTOKOL_MIKTARI_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("KARSILIK_TUTARI", InitsEx.ParaBicimiAyarla);
            sozluk.Add("KARSILIK_TUTARI_DOVIZ_ID", InitsEx.DovizTipGetir);

            #endregion Add item

            return sozluk;
        }

        private PivotGridField[] IcraDosyalarininAlacakMiktarlarinaGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.AreaIndex = 4;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldTAKIP_TARIHI.Visible = true;

            PivotGridField fieldKAPAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            fieldKAPAMA_TARIHI.AreaIndex = 24;
            fieldKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Name = "fieldKAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldKAPAMA_TARIHI.Visible = true;

            PivotGridField fieldKAPAMA_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            fieldKAPAMA_TARIHI2.AreaIndex = 24;
            fieldKAPAMA_TARIHI2.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI2.Name = "fieldKAPAMA_TARIHI2";
            fieldKAPAMA_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldKAPAMA_TARIHI2.Visible = true;

            PivotGridField fieldTAKIP_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI2.AreaIndex = 4;
            fieldTAKIP_TARIHI2.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI2.Name = "fieldTAKIP_TARIHI2";
            fieldTAKIP_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldTAKIP_TARIHI2.Visible = true;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 8;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 9;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 10;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldTAKIP_CIKISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.AreaIndex = 13;
            fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";
            fieldTAKIP_CIKISI.Visible = false;

            PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI_DOVIZ_ID.AreaIndex = 14;
            fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 17;
            fieldODEME_TOPLAMI_DOVIZ_ID.FieldName = "ODEME_TOPLAMI_DOVIZ_ID";
            fieldODEME_TOPLAMI_DOVIZ_ID.Name = "fieldODEME_TOPLAMI_DOVIZ_ID";
            fieldODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TOPLAMI.AreaIndex = 18;
            fieldODEME_TOPLAMI.FieldName = "ODEME_TOPLAMI";
            fieldODEME_TOPLAMI.Name = "fieldODEME_TOPLAMI";
            fieldODEME_TOPLAMI.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 19;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI.AreaIndex = 20;
            fieldTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Name = "fieldTO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 21;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 22;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldRISK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI.AreaIndex = 25;
            fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";
            fieldRISK_MIKTARI.Visible = false;

            PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 26;
            fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 29;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 31;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 34;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 35;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDURUM.AreaIndex = 40;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldFOY_ARSIV_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_ARSIV_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_ARSIV_TARIHI.AreaIndex = 47;
            fieldFOY_ARSIV_TARIHI.FieldName = "FOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Name = "fieldFOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Visible = false;

            PivotGridField fieldFOY_INFAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_INFAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_INFAZ_TARIHI.AreaIndex = 48;
            fieldFOY_INFAZ_TARIHI.FieldName = "FOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Name = "fieldFOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Visible = false;

            PivotGridField fieldTAKIBIN_MUVEKKILE_IADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.AreaIndex = 49;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.FieldName = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Name = "fieldTAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI.AreaIndex = 157;
            fieldTO_MASRAF_TOPLAMI.FieldName = "TO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Name = "fieldTO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 158;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI.AreaIndex = 159;
            fieldTS_MASRAF_TOPLAMI.FieldName = "TS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Name = "fieldTS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 160;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI.AreaIndex = 161;
            fieldTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Name = "fieldTUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 162;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 208;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 213;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 214;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 219;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldFORM_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFORM_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFORM_TIPI.AreaIndex = 39;
            fieldFORM_TIPI.FieldName = "FORM_TIPI";
            fieldFORM_TIPI.Name = "fieldFORM_TIPI";
            fieldFORM_TIPI.Visible = false;

            PivotGridField fieldTALEP_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALEP_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALEP_ADI.AreaIndex = 38;
            fieldTALEP_ADI.FieldName = "TALEP_ADI";
            fieldTALEP_ADI.Name = "fieldTALEP_ADI";
            fieldTALEP_ADI.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 218;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldTUM_VEKALET_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_VEKALET_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_VEKALET_TOPLAMI.AreaIndex = 169;
            fieldTUM_VEKALET_TOPLAMI.FieldName = "TUM_VEKALET_TOPLAMI";
            fieldTUM_VEKALET_TOPLAMI.Name = "fieldTUM_VEKALET_TOPLAMI";
            fieldTUM_VEKALET_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID.AreaIndex = 170;
            fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID.FieldName = "TUM_VEKALET_TOPLAMI_DOVIZ_ID";
            fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID";
            fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldHARC_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHARC_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHARC_TOPLAMI.AreaIndex = 163;
            fieldHARC_TOPLAMI.FieldName = "HARC_TOPLAMI";
            fieldHARC_TOPLAMI.Name = "fieldHARC_TOPLAMI";
            fieldHARC_TOPLAMI.Visible = false;

            PivotGridField fieldHARC_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHARC_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHARC_TOPLAMI_DOVIZ_ID.AreaIndex = 164;
            fieldHARC_TOPLAMI_DOVIZ_ID.FieldName = "HARC_TOPLAMI_DOVIZ_ID";
            fieldHARC_TOPLAMI_DOVIZ_ID.Name = "fieldHARC_TOPLAMI_DOVIZ_ID";
            fieldHARC_TOPLAMI_DOVIZ_ID.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = dizi = new PivotGridField[]
            {
                fieldRISK_MIKTARI,
                fieldRISK_MIKTARI_DOVIZ_ID,
                fieldTUM_MASRAF_TOPLAMI,
                fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTS_MASRAF_TOPLAMI,
                fieldTS_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_MASRAF_TOPLAMI,
                fieldTO_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldODEME_TOPLAMI_DOVIZ_ID,
			    fieldODEME_TOPLAMI,
			    fieldTO_ODEME_TOPLAMI_DOVIZ_ID,
			    fieldTO_ODEME_TOPLAMI,
                fieldKALAN,
                fieldKALAN_DOVIZ_ID,
                fieldTAKIP_CIKISI,
                fieldTAKIP_CIKISI_DOVIZ_ID,
                fieldASIL_ALACAK,
			    fieldASIL_ALACAK_DOVIZ_ID,
                fieldSORUMLU,
                fieldIZLEYEN,
                fieldTALEP_ADI,
                fieldBANKA_SUBE,
                fieldKREDI_GRUP,
			    fieldKREDI_TIP,
                fieldBOLGE,
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			    fieldFOY_ARSIV_TARIHI,
			    fieldFOY_INFAZ_TARIHI,
			    fieldTAKIBIN_MUVEKKILE_IADE_TARIHI,
                fieldID,
                fieldTAKIP_TARIHI,
                fieldTUM_VEKALET_TOPLAMI,
			    fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID,
                fieldHARC_TOPLAMI,
			    fieldHARC_TOPLAMI_DOVIZ_ID,
                fieldFORM_TIPI,
            };
            fieldTAKIP_CIKISI.Visible = true;
            fieldTAKIP_TARIHI.Visible = true;
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = true;
            fieldASIL_ALACAK.Visible = true;
            fieldASIL_ALACAK_DOVIZ_ID.Visible = true;
            fieldKALAN.Visible = true;
            fieldKALAN_DOVIZ_ID.Visible = true;
            fieldODEME_TOPLAMI_DOVIZ_ID.Visible = true;
            fieldODEME_TOPLAMI.Visible = true;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = true;
            fieldTO_ODEME_TOPLAMI.Visible = true;
            fieldTALEP_ADI.Visible = true;
            fieldFORM_TIPI.Visible = true;
            fieldRISK_MIKTARI.Visible = true;
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = true;
            fieldTUM_VEKALET_TOPLAMI.Visible = true;
            fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID.Visible = true;
            fieldHARC_TOPLAMI.Visible = true;
            fieldHARC_TOPLAMI_DOVIZ_ID.Visible = true;

            return dizi;
        }

        private PivotGridField[] IcraDosyalarininDigerTakipKalemlerineGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.AreaIndex = 4;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldTAKIP_TARIHI.Visible = true;

            PivotGridField fieldKAPAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            fieldKAPAMA_TARIHI.AreaIndex = 24;
            fieldKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Name = "fieldKAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldKAPAMA_TARIHI.Visible = true;

            PivotGridField fieldKAPAMA_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            fieldKAPAMA_TARIHI2.AreaIndex = 24;
            fieldKAPAMA_TARIHI2.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI2.Name = "fieldKAPAMA_TARIHI2";
            fieldKAPAMA_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldKAPAMA_TARIHI2.Visible = true;

            PivotGridField fieldTAKIP_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI2.AreaIndex = 4;
            fieldTAKIP_TARIHI2.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI2.Name = "fieldTAKIP_TARIHI2";
            fieldTAKIP_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldTAKIP_TARIHI2.Visible = true;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 8;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 9;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 10;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldTAKIP_CIKISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.AreaIndex = 13;
            fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";
            fieldTAKIP_CIKISI.Visible = false;

            PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI_DOVIZ_ID.AreaIndex = 14;
            fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 19;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI.AreaIndex = 20;
            fieldTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Name = "fieldTO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 21;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 22;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldRISK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI.AreaIndex = 25;
            fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";
            fieldRISK_MIKTARI.Visible = false;

            PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 26;
            fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 29;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldID.AreaIndex = 31;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 34;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 35;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDURUM.AreaIndex = 40;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldFOY_ARSIV_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_ARSIV_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_ARSIV_TARIHI.AreaIndex = 47;
            fieldFOY_ARSIV_TARIHI.FieldName = "FOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Name = "fieldFOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Visible = false;

            PivotGridField fieldFOY_INFAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_INFAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_INFAZ_TARIHI.AreaIndex = 48;
            fieldFOY_INFAZ_TARIHI.FieldName = "FOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Name = "fieldFOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Visible = false;

            PivotGridField fieldTAKIBIN_MUVEKKILE_IADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.AreaIndex = 49;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.FieldName = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Name = "fieldTAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI.AreaIndex = 157;
            fieldTO_MASRAF_TOPLAMI.FieldName = "TO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Name = "fieldTO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 158;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI.AreaIndex = 159;
            fieldTS_MASRAF_TOPLAMI.FieldName = "TS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Name = "fieldTS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 160;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI.AreaIndex = 161;
            fieldTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Name = "fieldTUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 162;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 208;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 213;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 214;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 219;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldFORM_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFORM_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFORM_TIPI.AreaIndex = 39;
            fieldFORM_TIPI.FieldName = "FORM_TIPI";
            fieldFORM_TIPI.Name = "fieldFORM_TIPI";
            fieldFORM_TIPI.Visible = false;

            PivotGridField fieldTALEP_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALEP_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALEP_ADI.AreaIndex = 38;
            fieldTALEP_ADI.FieldName = "TALEP_ADI";
            fieldTALEP_ADI.Name = "fieldTALEP_ADI";
            fieldTALEP_ADI.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 218;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 17;
            fieldODEME_TOPLAMI_DOVIZ_ID.FieldName = "ODEME_TOPLAMI_DOVIZ_ID";
            fieldODEME_TOPLAMI_DOVIZ_ID.Name = "fieldODEME_TOPLAMI_DOVIZ_ID";
            fieldODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TOPLAMI.AreaIndex = 18;
            fieldODEME_TOPLAMI.FieldName = "ODEME_TOPLAMI";
            fieldODEME_TOPLAMI.Name = "fieldODEME_TOPLAMI";
            fieldODEME_TOPLAMI.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = dizi = new PivotGridField[]
            {
                fieldRISK_MIKTARI,
                fieldRISK_MIKTARI_DOVIZ_ID,
                fieldTUM_MASRAF_TOPLAMI,
                fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTS_MASRAF_TOPLAMI,
                fieldTS_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_MASRAF_TOPLAMI,
                fieldTO_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldODEME_TOPLAMI_DOVIZ_ID,
			    fieldODEME_TOPLAMI,
			    fieldTO_ODEME_TOPLAMI_DOVIZ_ID,
			    fieldTO_ODEME_TOPLAMI,
                fieldKALAN,
                fieldKALAN_DOVIZ_ID,
                fieldTAKIP_CIKISI,
                fieldTAKIP_CIKISI_DOVIZ_ID,
                fieldASIL_ALACAK,
			    fieldASIL_ALACAK_DOVIZ_ID,
                fieldSORUMLU,
                fieldIZLEYEN,
                fieldKAPAMA_TARIHI,
                fieldKAPAMA_TARIHI2,
                fieldTALEP_ADI,
                fieldBANKA_SUBE,
                fieldKREDI_GRUP,
			    fieldKREDI_TIP,
                fieldBOLGE,
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			    fieldFOY_ARSIV_TARIHI,
			    fieldFOY_INFAZ_TARIHI,
			    fieldTAKIBIN_MUVEKKILE_IADE_TARIHI,
                fieldID,
                fieldTAKIP_TARIHI,
                fieldFORM_TIPI,
            };
            fieldTAKIP_CIKISI.Visible = true;
            fieldTAKIP_TARIHI.Visible = true;
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = true;
            fieldKALAN.Visible = true;
            fieldKALAN_DOVIZ_ID.Visible = true;
            fieldTALEP_ADI.Visible = true;
            fieldFORM_TIPI.Visible = true;
            fieldTUM_MASRAF_TOPLAMI.Visible = true;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = true;

            return dizi;
        }

        private PivotGridField[] IcraDosyalarininIcraAlacakNedenlerineGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.AreaIndex = 4;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateYear;
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldKAPAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            fieldKAPAMA_TARIHI.AreaIndex = 24;
            fieldKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Name = "fieldKAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldKAPAMA_TARIHI.Visible = true;

            PivotGridField fieldKAPAMA_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            fieldKAPAMA_TARIHI2.AreaIndex = 24;
            fieldKAPAMA_TARIHI2.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI2.Name = "fieldKAPAMA_TARIHI2";
            fieldKAPAMA_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldKAPAMA_TARIHI2.Visible = true;

            PivotGridField fieldTAKIP_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI2.AreaIndex = 4;
            fieldTAKIP_TARIHI2.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI2.Name = "fieldTAKIP_TARIHI2";
            fieldTAKIP_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldTAKIP_TARIHI2.Visible = true;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 8;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 9;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 10;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldTAKIP_CIKISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.AreaIndex = 13;
            fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";
            fieldTAKIP_CIKISI.Visible = false;

            PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI_DOVIZ_ID.AreaIndex = 14;
            fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 19;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI.AreaIndex = 20;
            fieldTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Name = "fieldTO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 21;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 22;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldRISK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI.AreaIndex = 25;
            fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";
            fieldRISK_MIKTARI.Visible = false;

            PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 26;
            fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 29;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.AreaIndex = 31;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Kayıt Sayisi";
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 34;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 35;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDURUM.AreaIndex = 40;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldFOY_ARSIV_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_ARSIV_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_ARSIV_TARIHI.AreaIndex = 47;
            fieldFOY_ARSIV_TARIHI.FieldName = "FOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Name = "fieldFOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Visible = false;

            PivotGridField fieldFOY_INFAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_INFAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_INFAZ_TARIHI.AreaIndex = 48;
            fieldFOY_INFAZ_TARIHI.FieldName = "FOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Name = "fieldFOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Visible = false;

            PivotGridField fieldTAKIBIN_MUVEKKILE_IADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.AreaIndex = 49;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.FieldName = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Name = "fieldTAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI.AreaIndex = 157;
            fieldTO_MASRAF_TOPLAMI.FieldName = "TO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Name = "fieldTO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 158;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI.AreaIndex = 159;
            fieldTS_MASRAF_TOPLAMI.FieldName = "TS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Name = "fieldTS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 160;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI.AreaIndex = 161;
            fieldTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Name = "fieldTUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 162;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 208;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 213;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 214;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 219;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldFORM_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFORM_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFORM_TIPI.AreaIndex = 39;
            fieldFORM_TIPI.FieldName = "FORM_TIPI";
            fieldFORM_TIPI.Name = "fieldFORM_TIPI";
            fieldFORM_TIPI.Visible = false;

            PivotGridField fieldTALEP_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALEP_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALEP_ADI.AreaIndex = 38;
            fieldTALEP_ADI.FieldName = "TALEP_ADI";
            fieldTALEP_ADI.Name = "fieldTALEP_ADI";
            fieldTALEP_ADI.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 218;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldALACAK_NEDENI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALACAK_NEDENI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldALACAK_NEDENI.AreaIndex = 217;
            fieldALACAK_NEDENI.FieldName = "ALACAK_NEDENI";
            fieldALACAK_NEDENI.Name = "fieldALACAK_NEDENI";
            fieldALACAK_NEDENI.Visible = false;

            PivotGridField fieldALACAK_NEDEN_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALACAK_NEDEN_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldALACAK_NEDEN_ID.AreaIndex = 218;
            fieldALACAK_NEDEN_ID.FieldName = "ALACAK_NEDEN_ID";
            fieldALACAK_NEDEN_ID.Name = "fieldALACAK_NEDEN_ID";
            fieldALACAK_NEDEN_ID.Visible = true;

            #endregion Field & Properties

            PivotGridField[] dizi = dizi = new PivotGridField[]
            {
                fieldRISK_MIKTARI,
                fieldRISK_MIKTARI_DOVIZ_ID,
                fieldTUM_MASRAF_TOPLAMI,
                fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTS_MASRAF_TOPLAMI,
                fieldTS_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_MASRAF_TOPLAMI,
                fieldTO_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_ODEME_TOPLAMI,
                fieldTO_ODEME_TOPLAMI_DOVIZ_ID,
                fieldKALAN,
                fieldKALAN_DOVIZ_ID,
                fieldTAKIP_CIKISI,
                fieldTAKIP_CIKISI_DOVIZ_ID,
                fieldASIL_ALACAK,
			    fieldASIL_ALACAK_DOVIZ_ID,
                fieldSORUMLU,
                fieldIZLEYEN,
                fieldKAPAMA_TARIHI,
                fieldKAPAMA_TARIHI2,
                fieldTALEP_ADI,
                fieldBANKA_SUBE,
                fieldKREDI_GRUP,
			    fieldKREDI_TIP,
                fieldBOLGE,
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			    fieldFOY_ARSIV_TARIHI,
			    fieldFOY_INFAZ_TARIHI,
			    fieldTAKIBIN_MUVEKKILE_IADE_TARIHI,
                fieldID,
                fieldTAKIP_TARIHI,
            };
            fieldALACAK_NEDENI.Area = PivotArea.DataArea;
            fieldALACAK_NEDENI.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;

            return dizi;
        }

        private PivotGridField[] IcraDosyalarininIcraAlacakNedenlerineGoreDagilimiYillaraGore()
        {
            #region Field & Properties

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.AreaIndex = 4;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateYear;
            fieldTAKIP_TARIHI.Visible = true;

            PivotGridField fieldKAPAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            fieldKAPAMA_TARIHI.AreaIndex = 24;
            fieldKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Name = "fieldKAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldKAPAMA_TARIHI.Visible = true;

            PivotGridField fieldKAPAMA_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            fieldKAPAMA_TARIHI2.AreaIndex = 24;
            fieldKAPAMA_TARIHI2.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI2.Name = "fieldKAPAMA_TARIHI2";
            fieldKAPAMA_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldKAPAMA_TARIHI2.Visible = true;

            PivotGridField fieldTAKIP_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI2.AreaIndex = 4;
            fieldTAKIP_TARIHI2.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI2.Name = "fieldTAKIP_TARIHI2";
            fieldTAKIP_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldTAKIP_TARIHI2.Visible = true;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 8;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 9;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 10;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldTAKIP_CIKISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.AreaIndex = 13;
            fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";
            fieldTAKIP_CIKISI.Visible = false;

            PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI_DOVIZ_ID.AreaIndex = 14;
            fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 19;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI.AreaIndex = 20;
            fieldTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Name = "fieldTO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 21;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 22;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldRISK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI.AreaIndex = 25;
            fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";
            fieldRISK_MIKTARI.Visible = false;

            PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 26;
            fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 29;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.AreaIndex = 31;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Kayıt Sayisi";
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 34;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 35;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDURUM.AreaIndex = 40;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldFOY_ARSIV_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_ARSIV_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_ARSIV_TARIHI.AreaIndex = 47;
            fieldFOY_ARSIV_TARIHI.FieldName = "FOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Name = "fieldFOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Visible = false;

            PivotGridField fieldFOY_INFAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_INFAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_INFAZ_TARIHI.AreaIndex = 48;
            fieldFOY_INFAZ_TARIHI.FieldName = "FOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Name = "fieldFOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Visible = false;

            PivotGridField fieldTAKIBIN_MUVEKKILE_IADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.AreaIndex = 49;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.FieldName = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Name = "fieldTAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI.AreaIndex = 157;
            fieldTO_MASRAF_TOPLAMI.FieldName = "TO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Name = "fieldTO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 158;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI.AreaIndex = 159;
            fieldTS_MASRAF_TOPLAMI.FieldName = "TS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Name = "fieldTS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 160;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI.AreaIndex = 161;
            fieldTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Name = "fieldTUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 162;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 208;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 213;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 214;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 219;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldFORM_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFORM_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFORM_TIPI.AreaIndex = 39;
            fieldFORM_TIPI.FieldName = "FORM_TIPI";
            fieldFORM_TIPI.Name = "fieldFORM_TIPI";
            fieldFORM_TIPI.Visible = false;

            PivotGridField fieldTALEP_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALEP_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALEP_ADI.AreaIndex = 38;
            fieldTALEP_ADI.FieldName = "TALEP_ADI";
            fieldTALEP_ADI.Name = "fieldTALEP_ADI";
            fieldTALEP_ADI.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 218;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldALACAK_NEDENI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALACAK_NEDENI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldALACAK_NEDENI.AreaIndex = 217;
            fieldALACAK_NEDENI.FieldName = "ALACAK_NEDENI";
            fieldALACAK_NEDENI.Name = "fieldALACAK_NEDENI";
            fieldALACAK_NEDENI.Visible = false;

            PivotGridField fieldALACAK_NEDEN_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALACAK_NEDEN_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldALACAK_NEDEN_ID.AreaIndex = 218;
            fieldALACAK_NEDEN_ID.FieldName = "ALACAK_NEDEN_ID";
            fieldALACAK_NEDEN_ID.Name = "fieldALACAK_NEDEN_ID";
            fieldALACAK_NEDEN_ID.Visible = true;

            #endregion Field & Properties

            PivotGridField[] dizi = dizi = new PivotGridField[]
            {
                fieldRISK_MIKTARI,
                fieldRISK_MIKTARI_DOVIZ_ID,
                fieldTUM_MASRAF_TOPLAMI,
                fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTS_MASRAF_TOPLAMI,
                fieldTS_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_MASRAF_TOPLAMI,
                fieldTO_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_ODEME_TOPLAMI,
                fieldTO_ODEME_TOPLAMI_DOVIZ_ID,
                fieldKALAN,
                fieldKALAN_DOVIZ_ID,
                fieldTAKIP_CIKISI,
                fieldTAKIP_CIKISI_DOVIZ_ID,
                fieldASIL_ALACAK,
			    fieldASIL_ALACAK_DOVIZ_ID,
                fieldSORUMLU,
                fieldIZLEYEN,
                fieldKAPAMA_TARIHI,
                fieldKAPAMA_TARIHI2,
                fieldTALEP_ADI,
                fieldBANKA_SUBE,
                fieldKREDI_GRUP,
			    fieldKREDI_TIP,
                fieldBOLGE,
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			    fieldFOY_ARSIV_TARIHI,
			    fieldFOY_INFAZ_TARIHI,
			    fieldTAKIBIN_MUVEKKILE_IADE_TARIHI,
                fieldID,
                fieldTAKIP_TARIHI,
            };
            fieldALACAK_NEDENI.Area = PivotArea.DataArea;
            fieldTAKIP_TARIHI.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldALACAK_NEDENI.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            return dizi;
        }

        private PivotGridField[] IcraDosyasiKapamaOrtalamasıBurolaraGore()
        {
            #region Field & Properties

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.AreaIndex = 4;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldKAPAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            fieldKAPAMA_TARIHI.AreaIndex = 24;
            fieldKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Name = "fieldKAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldKAPAMA_TARIHI.Visible = true;

            PivotGridField fieldTAKIP_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI2.AreaIndex = 4;
            fieldTAKIP_TARIHI2.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI2.Name = "fieldTAKIP_TARIHI2";
            fieldTAKIP_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldTAKIP_TARIHI2.Visible = true;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 8;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 9;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 10;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldTAKIP_CIKISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.AreaIndex = 13;
            fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";
            fieldTAKIP_CIKISI.Visible = false;

            PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI_DOVIZ_ID.AreaIndex = 14;
            fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 19;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI.AreaIndex = 20;
            fieldTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Name = "fieldTO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 21;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 22;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldRISK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI.AreaIndex = 25;
            fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";
            fieldRISK_MIKTARI.Visible = false;

            PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 26;
            fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 29;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = true;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.AreaIndex = 31;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 34;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 35;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDURUM.AreaIndex = 40;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldFOY_ARSIV_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_ARSIV_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_ARSIV_TARIHI.AreaIndex = 47;
            fieldFOY_ARSIV_TARIHI.FieldName = "FOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Name = "fieldFOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Visible = false;

            PivotGridField fieldFOY_INFAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_INFAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_INFAZ_TARIHI.AreaIndex = 48;
            fieldFOY_INFAZ_TARIHI.FieldName = "FOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Name = "fieldFOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Visible = false;

            PivotGridField fieldTAKIBIN_MUVEKKILE_IADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.AreaIndex = 49;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.FieldName = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Name = "fieldTAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI.AreaIndex = 157;
            fieldTO_MASRAF_TOPLAMI.FieldName = "TO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Name = "fieldTO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 158;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI.AreaIndex = 159;
            fieldTS_MASRAF_TOPLAMI.FieldName = "TS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Name = "fieldTS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 160;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI.AreaIndex = 161;
            fieldTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Name = "fieldTUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 162;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 208;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 213;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 214;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 219;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldFORM_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFORM_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFORM_TIPI.AreaIndex = 39;
            fieldFORM_TIPI.FieldName = "FORM_TIPI";
            fieldFORM_TIPI.Name = "fieldFORM_TIPI";
            fieldFORM_TIPI.Visible = false;

            PivotGridField fieldTALEP_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALEP_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALEP_ADI.AreaIndex = 38;
            fieldTALEP_ADI.FieldName = "TALEP_ADI";
            fieldTALEP_ADI.Name = "fieldTALEP_ADI";
            fieldTALEP_ADI.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 218;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = dizi = new PivotGridField[]
            {
                fieldRISK_MIKTARI,
                fieldRISK_MIKTARI_DOVIZ_ID,
                fieldTUM_MASRAF_TOPLAMI,
                fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTS_MASRAF_TOPLAMI,
                fieldTS_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_MASRAF_TOPLAMI,
                fieldTO_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_ODEME_TOPLAMI,
                fieldTO_ODEME_TOPLAMI_DOVIZ_ID,
                fieldKALAN,
                fieldKALAN_DOVIZ_ID,
                fieldTAKIP_CIKISI,
                fieldTAKIP_CIKISI_DOVIZ_ID,
                fieldASIL_ALACAK,
			    fieldASIL_ALACAK_DOVIZ_ID,
                fieldSORUMLU,
                fieldIZLEYEN,
                fieldKAPAMA_TARIHI,
                fieldTALEP_ADI,
                fieldBANKA_SUBE,
                fieldKREDI_GRUP,
			    fieldKREDI_TIP,
                fieldBOLGE,
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			    fieldFOY_ARSIV_TARIHI,
			    fieldFOY_INFAZ_TARIHI,
			    fieldTAKIBIN_MUVEKKILE_IADE_TARIHI,
                fieldID,
                fieldSUBE_KOD_ID,
                fieldTAKIP_TARIHI,
            };
            fieldKAPAMA_TARIHI.Area = PivotArea.DataArea;
            fieldKAPAMA_TARIHI.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldSUBE_KOD_ID.Area = PivotArea.RowArea;
            return dizi;
        }

        private PivotGridField[] KapamaSayisiAylaraYillaraGore()
        {
            #region Field & Properties

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.AreaIndex = 4;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldTAKIP_TARIHI.Visible = true;

            PivotGridField fieldKAPAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            fieldKAPAMA_TARIHI.AreaIndex = 24;
            fieldKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Name = "fieldKAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldKAPAMA_TARIHI.Visible = true;

            PivotGridField fieldKAPAMA_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            fieldKAPAMA_TARIHI2.AreaIndex = 24;
            fieldKAPAMA_TARIHI2.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI2.Name = "fieldKAPAMA_TARIHI2";
            fieldKAPAMA_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldKAPAMA_TARIHI2.Visible = true;

            PivotGridField fieldTAKIP_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI2.AreaIndex = 4;
            fieldTAKIP_TARIHI2.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI2.Name = "fieldTAKIP_TARIHI2";
            fieldTAKIP_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldTAKIP_TARIHI2.Visible = true;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 8;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 9;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 10;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldTAKIP_CIKISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.AreaIndex = 13;
            fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";
            fieldTAKIP_CIKISI.Visible = false;

            PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI_DOVIZ_ID.AreaIndex = 14;
            fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 19;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI.AreaIndex = 20;
            fieldTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Name = "fieldTO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 21;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 22;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldRISK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI.AreaIndex = 25;
            fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";
            fieldRISK_MIKTARI.Visible = false;

            PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 26;
            fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 29;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.AreaIndex = 31;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 34;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 35;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDURUM.AreaIndex = 40;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldFOY_ARSIV_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_ARSIV_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_ARSIV_TARIHI.AreaIndex = 47;
            fieldFOY_ARSIV_TARIHI.FieldName = "FOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Name = "fieldFOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Visible = false;

            PivotGridField fieldFOY_INFAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_INFAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_INFAZ_TARIHI.AreaIndex = 48;
            fieldFOY_INFAZ_TARIHI.FieldName = "FOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Name = "fieldFOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Visible = false;

            PivotGridField fieldTAKIBIN_MUVEKKILE_IADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.AreaIndex = 49;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.FieldName = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Name = "fieldTAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI.AreaIndex = 157;
            fieldTO_MASRAF_TOPLAMI.FieldName = "TO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Name = "fieldTO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 158;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI.AreaIndex = 159;
            fieldTS_MASRAF_TOPLAMI.FieldName = "TS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Name = "fieldTS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 160;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI.AreaIndex = 161;
            fieldTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Name = "fieldTUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 162;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 208;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 213;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 214;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 219;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldFORM_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFORM_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFORM_TIPI.AreaIndex = 39;
            fieldFORM_TIPI.FieldName = "FORM_TIPI";
            fieldFORM_TIPI.Name = "fieldFORM_TIPI";
            fieldFORM_TIPI.Visible = false;

            PivotGridField fieldTALEP_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALEP_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALEP_ADI.AreaIndex = 38;
            fieldTALEP_ADI.FieldName = "TALEP_ADI";
            fieldTALEP_ADI.Name = "fieldTALEP_ADI";
            fieldTALEP_ADI.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 218;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = dizi = new PivotGridField[]
            {
                fieldRISK_MIKTARI,
                fieldRISK_MIKTARI_DOVIZ_ID,
                fieldTUM_MASRAF_TOPLAMI,
                fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTS_MASRAF_TOPLAMI,
                fieldTS_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_MASRAF_TOPLAMI,
                fieldTO_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_ODEME_TOPLAMI,
                fieldTO_ODEME_TOPLAMI_DOVIZ_ID,
                fieldKALAN,
                fieldKALAN_DOVIZ_ID,
                fieldTAKIP_CIKISI,
                fieldTAKIP_CIKISI_DOVIZ_ID,
                fieldASIL_ALACAK,
			    fieldASIL_ALACAK_DOVIZ_ID,
                fieldSORUMLU,
                fieldIZLEYEN,
                fieldKAPAMA_TARIHI,
                fieldKAPAMA_TARIHI2,
                fieldTALEP_ADI,
                fieldBANKA_SUBE,
                fieldKREDI_GRUP,
			    fieldKREDI_TIP,
                fieldBOLGE,
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			    fieldFOY_ARSIV_TARIHI,
			    fieldFOY_INFAZ_TARIHI,
			    fieldTAKIBIN_MUVEKKILE_IADE_TARIHI,
                fieldID,
                fieldTAKIP_TARIHI,
            };
            fieldKAPAMA_TARIHI.Area = PivotArea.RowArea;
            fieldKAPAMA_TARIHI2.Area = PivotArea.RowArea;
            return dizi;
        }

        private PivotGridField[] TakibeKonulanIcraDosylarininKapananlaraOranıAylaraGore()
        {
            #region Field & Properties

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.AreaIndex = 4;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldTAKIP_TARIHI.Visible = true;

            PivotGridField fieldKAPAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            fieldKAPAMA_TARIHI.AreaIndex = 24;
            fieldKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Name = "fieldKAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldKAPAMA_TARIHI.Visible = true;

            PivotGridField fieldKAPAMA_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            fieldKAPAMA_TARIHI2.AreaIndex = 24;
            fieldKAPAMA_TARIHI2.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI2.Name = "fieldKAPAMA_TARIHI2";
            fieldKAPAMA_TARIHI2.GroupInterval = PivotGroupInterval.DateMonth;
            fieldKAPAMA_TARIHI2.Visible = true;

            PivotGridField fieldTAKIP_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI2.AreaIndex = 4;
            fieldTAKIP_TARIHI2.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI2.Name = "fieldTAKIP_TARIHI2";
            fieldTAKIP_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldTAKIP_TARIHI2.Visible = true;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 8;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 9;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 10;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldTAKIP_CIKISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.AreaIndex = 13;
            fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";
            fieldTAKIP_CIKISI.Visible = false;

            PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI_DOVIZ_ID.AreaIndex = 14;
            fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 19;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI.AreaIndex = 20;
            fieldTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Name = "fieldTO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 21;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 22;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldRISK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI.AreaIndex = 25;
            fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";
            fieldRISK_MIKTARI.Visible = false;

            PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 26;
            fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 29;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.AreaIndex = 31;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 34;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 35;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDURUM.AreaIndex = 40;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldFOY_ARSIV_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_ARSIV_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_ARSIV_TARIHI.AreaIndex = 47;
            fieldFOY_ARSIV_TARIHI.FieldName = "FOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Name = "fieldFOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Visible = false;

            PivotGridField fieldFOY_INFAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_INFAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_INFAZ_TARIHI.AreaIndex = 48;
            fieldFOY_INFAZ_TARIHI.FieldName = "FOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Name = "fieldFOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Visible = false;

            PivotGridField fieldTAKIBIN_MUVEKKILE_IADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.AreaIndex = 49;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.FieldName = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Name = "fieldTAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI.AreaIndex = 157;
            fieldTO_MASRAF_TOPLAMI.FieldName = "TO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Name = "fieldTO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 158;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI.AreaIndex = 159;
            fieldTS_MASRAF_TOPLAMI.FieldName = "TS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Name = "fieldTS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 160;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI.AreaIndex = 161;
            fieldTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Name = "fieldTUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 162;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 208;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 213;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 214;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 219;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldFORM_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFORM_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFORM_TIPI.AreaIndex = 39;
            fieldFORM_TIPI.FieldName = "FORM_TIPI";
            fieldFORM_TIPI.Name = "fieldFORM_TIPI";
            fieldFORM_TIPI.Visible = false;

            PivotGridField fieldTALEP_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALEP_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALEP_ADI.AreaIndex = 38;
            fieldTALEP_ADI.FieldName = "TALEP_ADI";
            fieldTALEP_ADI.Name = "fieldTALEP_ADI";
            fieldTALEP_ADI.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 218;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = dizi = new PivotGridField[]
            {
                fieldRISK_MIKTARI,
                fieldRISK_MIKTARI_DOVIZ_ID,
                fieldTUM_MASRAF_TOPLAMI,
                fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTS_MASRAF_TOPLAMI,
                fieldTS_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_MASRAF_TOPLAMI,
                fieldTO_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_ODEME_TOPLAMI,
                fieldTO_ODEME_TOPLAMI_DOVIZ_ID,
                fieldKALAN,
                fieldKALAN_DOVIZ_ID,
                fieldTAKIP_CIKISI,
                fieldTAKIP_CIKISI_DOVIZ_ID,
                fieldASIL_ALACAK,
			    fieldASIL_ALACAK_DOVIZ_ID,
                fieldSORUMLU,
                fieldIZLEYEN,
                fieldKAPAMA_TARIHI,
                fieldKAPAMA_TARIHI2,
                fieldTALEP_ADI,
                fieldBANKA_SUBE,
                fieldKREDI_GRUP,
			    fieldKREDI_TIP,
                fieldBOLGE,
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			    fieldFOY_ARSIV_TARIHI,
			    fieldFOY_INFAZ_TARIHI,
			    fieldTAKIBIN_MUVEKKILE_IADE_TARIHI,
                fieldID,
                fieldTAKIP_TARIHI,
            };
            fieldKAPAMA_TARIHI.Area = PivotArea.DataArea;
            fieldTAKIP_TARIHI.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldKAPAMA_TARIHI.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldKAPAMA_TARIHI2.Area = PivotArea.RowArea;
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            return dizi;
        }

        private PivotGridField[] TakibeKonulanIcraDosylarininKapananlaraOranıBirimlereGore()
        {
            #region Field & Properties

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.AreaIndex = 4;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldTAKIP_TARIHI.Visible = true;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 209;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = true;

            PivotGridField fieldKAPAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            fieldKAPAMA_TARIHI.AreaIndex = 24;
            fieldKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Name = "fieldKAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldKAPAMA_TARIHI.Visible = true;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 8;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 9;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 10;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldTAKIP_CIKISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.AreaIndex = 13;
            fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";
            fieldTAKIP_CIKISI.Visible = false;

            PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI_DOVIZ_ID.AreaIndex = 14;
            fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 19;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI.AreaIndex = 20;
            fieldTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Name = "fieldTO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 21;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 22;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldRISK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI.AreaIndex = 25;
            fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";
            fieldRISK_MIKTARI.Visible = false;

            PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 26;
            fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 29;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = true;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.AreaIndex = 31;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 34;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 35;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDURUM.AreaIndex = 40;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldFOY_ARSIV_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_ARSIV_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_ARSIV_TARIHI.AreaIndex = 47;
            fieldFOY_ARSIV_TARIHI.FieldName = "FOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Name = "fieldFOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Visible = false;

            PivotGridField fieldFOY_INFAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_INFAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_INFAZ_TARIHI.AreaIndex = 48;
            fieldFOY_INFAZ_TARIHI.FieldName = "FOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Name = "fieldFOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Visible = false;

            PivotGridField fieldTAKIBIN_MUVEKKILE_IADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.AreaIndex = 49;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.FieldName = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Name = "fieldTAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI.AreaIndex = 157;
            fieldTO_MASRAF_TOPLAMI.FieldName = "TO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Name = "fieldTO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 158;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI.AreaIndex = 159;
            fieldTS_MASRAF_TOPLAMI.FieldName = "TS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Name = "fieldTS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 160;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI.AreaIndex = 161;
            fieldTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Name = "fieldTUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 162;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 208;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 213;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 214;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 219;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldFORM_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFORM_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFORM_TIPI.AreaIndex = 39;
            fieldFORM_TIPI.FieldName = "FORM_TIPI";
            fieldFORM_TIPI.Name = "fieldFORM_TIPI";
            fieldFORM_TIPI.Visible = false;

            PivotGridField fieldTALEP_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALEP_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALEP_ADI.AreaIndex = 38;
            fieldTALEP_ADI.FieldName = "TALEP_ADI";
            fieldTALEP_ADI.Name = "fieldTALEP_ADI";
            fieldTALEP_ADI.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 218;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = dizi = new PivotGridField[]
            {
                fieldRISK_MIKTARI,
                fieldRISK_MIKTARI_DOVIZ_ID,
                fieldTUM_MASRAF_TOPLAMI,
                fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTS_MASRAF_TOPLAMI,
                fieldTS_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_MASRAF_TOPLAMI,
                fieldTO_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_ODEME_TOPLAMI,
                fieldTO_ODEME_TOPLAMI_DOVIZ_ID,
                fieldKALAN,
                fieldKALAN_DOVIZ_ID,
                fieldTAKIP_CIKISI,
                fieldTAKIP_CIKISI_DOVIZ_ID,
                fieldASIL_ALACAK,
			    fieldASIL_ALACAK_DOVIZ_ID,
                fieldSORUMLU,
                fieldIZLEYEN,
                fieldKAPAMA_TARIHI,
                fieldTALEP_ADI,
                fieldBANKA_SUBE,
                fieldKREDI_GRUP,
			    fieldKREDI_TIP,
                fieldBOLGE,
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			    fieldFOY_ARSIV_TARIHI,
			    fieldFOY_INFAZ_TARIHI,
			    fieldTAKIBIN_MUVEKKILE_IADE_TARIHI,
                fieldID,
                fieldFOY_BIRIM,
                fieldTAKIP_TARIHI,
            };
            fieldKAPAMA_TARIHI.Area = PivotArea.DataArea;
            fieldTAKIP_TARIHI.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldKAPAMA_TARIHI.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldFOY_BIRIM.Area = PivotArea.RowArea;
            return dizi;
        }

        private PivotGridField[] TakibeKonulanIcraDosylarininKapananlaraOranıBolgelereGore()
        {
            #region Field & Properties

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.AreaIndex = 4;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldTAKIP_TARIHI.Visible = true;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 209;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldKAPAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            fieldKAPAMA_TARIHI.AreaIndex = 24;
            fieldKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Name = "fieldKAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldKAPAMA_TARIHI.Visible = true;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 8;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 9;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 10;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldTAKIP_CIKISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.AreaIndex = 13;
            fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";
            fieldTAKIP_CIKISI.Visible = false;

            PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI_DOVIZ_ID.AreaIndex = 14;
            fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 19;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI.AreaIndex = 20;
            fieldTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Name = "fieldTO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 21;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 22;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldRISK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI.AreaIndex = 25;
            fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";
            fieldRISK_MIKTARI.Visible = false;

            PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 26;
            fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 29;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = true;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.AreaIndex = 31;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 34;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 35;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDURUM.AreaIndex = 40;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldFOY_ARSIV_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_ARSIV_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_ARSIV_TARIHI.AreaIndex = 47;
            fieldFOY_ARSIV_TARIHI.FieldName = "FOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Name = "fieldFOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Visible = false;

            PivotGridField fieldFOY_INFAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_INFAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_INFAZ_TARIHI.AreaIndex = 48;
            fieldFOY_INFAZ_TARIHI.FieldName = "FOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Name = "fieldFOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Visible = false;

            PivotGridField fieldTAKIBIN_MUVEKKILE_IADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.AreaIndex = 49;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.FieldName = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Name = "fieldTAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI.AreaIndex = 157;
            fieldTO_MASRAF_TOPLAMI.FieldName = "TO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Name = "fieldTO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 158;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI.AreaIndex = 159;
            fieldTS_MASRAF_TOPLAMI.FieldName = "TS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Name = "fieldTS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 160;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI.AreaIndex = 161;
            fieldTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Name = "fieldTUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 162;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 208;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 213;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 214;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 219;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldFORM_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFORM_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFORM_TIPI.AreaIndex = 39;
            fieldFORM_TIPI.FieldName = "FORM_TIPI";
            fieldFORM_TIPI.Name = "fieldFORM_TIPI";
            fieldFORM_TIPI.Visible = false;

            PivotGridField fieldTALEP_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALEP_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALEP_ADI.AreaIndex = 38;
            fieldTALEP_ADI.FieldName = "TALEP_ADI";
            fieldTALEP_ADI.Name = "fieldTALEP_ADI";
            fieldTALEP_ADI.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 218;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = true;

            #endregion Field & Properties

            PivotGridField[] dizi = dizi = new PivotGridField[]
            {
                fieldRISK_MIKTARI,
                fieldRISK_MIKTARI_DOVIZ_ID,
                fieldTUM_MASRAF_TOPLAMI,
                fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTS_MASRAF_TOPLAMI,
                fieldTS_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_MASRAF_TOPLAMI,
                fieldTO_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_ODEME_TOPLAMI,
                fieldTO_ODEME_TOPLAMI_DOVIZ_ID,
                fieldKALAN,
                fieldKALAN_DOVIZ_ID,
                fieldTAKIP_CIKISI,
                fieldTAKIP_CIKISI_DOVIZ_ID,
                fieldASIL_ALACAK,
			    fieldASIL_ALACAK_DOVIZ_ID,
                fieldSORUMLU,
                fieldIZLEYEN,
                fieldKAPAMA_TARIHI,
                fieldTALEP_ADI,
                fieldBANKA_SUBE,
                fieldKREDI_GRUP,
			    fieldKREDI_TIP,
                fieldBOLGE,
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			    fieldFOY_ARSIV_TARIHI,
			    fieldFOY_INFAZ_TARIHI,
			    fieldTAKIBIN_MUVEKKILE_IADE_TARIHI,
                fieldID,
                fieldFOY_BIRIM,
                fieldTAKIP_TARIHI,
            };
            fieldKAPAMA_TARIHI.Area = PivotArea.DataArea;
            fieldTAKIP_TARIHI.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldKAPAMA_TARIHI.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldBOLGE.Area = PivotArea.RowArea;
            return dizi;
        }

        private PivotGridField[] TakibeKonulanIcraDosylarininKapananlaraOranıBurolaraGore()
        {
            #region Field & Properties

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.AreaIndex = 4;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldTAKIP_TARIHI.Visible = true;

            PivotGridField fieldKAPAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            fieldKAPAMA_TARIHI.AreaIndex = 24;
            fieldKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Name = "fieldKAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldKAPAMA_TARIHI.Visible = true;

            PivotGridField fieldTAKIP_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI2.AreaIndex = 4;
            fieldTAKIP_TARIHI2.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI2.Name = "fieldTAKIP_TARIHI2";
            fieldTAKIP_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldTAKIP_TARIHI2.Visible = true;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 8;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 9;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 10;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldTAKIP_CIKISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.AreaIndex = 13;
            fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";
            fieldTAKIP_CIKISI.Visible = false;

            PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI_DOVIZ_ID.AreaIndex = 14;
            fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 19;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI.AreaIndex = 20;
            fieldTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Name = "fieldTO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 21;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 22;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldRISK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI.AreaIndex = 25;
            fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";
            fieldRISK_MIKTARI.Visible = false;

            PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 26;
            fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 29;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = true;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.AreaIndex = 31;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 34;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 35;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDURUM.AreaIndex = 40;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldFOY_ARSIV_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_ARSIV_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_ARSIV_TARIHI.AreaIndex = 47;
            fieldFOY_ARSIV_TARIHI.FieldName = "FOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Name = "fieldFOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Visible = false;

            PivotGridField fieldFOY_INFAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_INFAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_INFAZ_TARIHI.AreaIndex = 48;
            fieldFOY_INFAZ_TARIHI.FieldName = "FOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Name = "fieldFOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Visible = false;

            PivotGridField fieldTAKIBIN_MUVEKKILE_IADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.AreaIndex = 49;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.FieldName = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Name = "fieldTAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI.AreaIndex = 157;
            fieldTO_MASRAF_TOPLAMI.FieldName = "TO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Name = "fieldTO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 158;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI.AreaIndex = 159;
            fieldTS_MASRAF_TOPLAMI.FieldName = "TS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Name = "fieldTS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 160;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI.AreaIndex = 161;
            fieldTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Name = "fieldTUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 162;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 208;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 213;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 214;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 219;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldFORM_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFORM_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFORM_TIPI.AreaIndex = 39;
            fieldFORM_TIPI.FieldName = "FORM_TIPI";
            fieldFORM_TIPI.Name = "fieldFORM_TIPI";
            fieldFORM_TIPI.Visible = false;

            PivotGridField fieldTALEP_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALEP_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALEP_ADI.AreaIndex = 38;
            fieldTALEP_ADI.FieldName = "TALEP_ADI";
            fieldTALEP_ADI.Name = "fieldTALEP_ADI";
            fieldTALEP_ADI.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 218;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = dizi = new PivotGridField[]
            {
                fieldRISK_MIKTARI,
                fieldRISK_MIKTARI_DOVIZ_ID,
                fieldTUM_MASRAF_TOPLAMI,
                fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTS_MASRAF_TOPLAMI,
                fieldTS_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_MASRAF_TOPLAMI,
                fieldTO_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_ODEME_TOPLAMI,
                fieldTO_ODEME_TOPLAMI_DOVIZ_ID,
                fieldKALAN,
                fieldKALAN_DOVIZ_ID,
                fieldTAKIP_CIKISI,
                fieldTAKIP_CIKISI_DOVIZ_ID,
                fieldASIL_ALACAK,
			    fieldASIL_ALACAK_DOVIZ_ID,
                fieldSORUMLU,
                fieldIZLEYEN,
                fieldKAPAMA_TARIHI,
                fieldTALEP_ADI,
                fieldBANKA_SUBE,
                fieldKREDI_GRUP,
			    fieldKREDI_TIP,
                fieldBOLGE,
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			    fieldFOY_ARSIV_TARIHI,
			    fieldFOY_INFAZ_TARIHI,
			    fieldTAKIBIN_MUVEKKILE_IADE_TARIHI,
                fieldID,
                fieldSUBE_KOD_ID,
                fieldTAKIP_TARIHI,
            };
            fieldKAPAMA_TARIHI.Area = PivotArea.DataArea;
            fieldTAKIP_TARIHI.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldKAPAMA_TARIHI.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldSUBE_KOD_ID.Area = PivotArea.RowArea;
            return dizi;
        }

        private PivotGridField[] TakibeKonulanIcraDosylarininKapananlaraOranıKrediTiplerineGore()
        {
            #region Field & Properties

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.AreaIndex = 4;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldTAKIP_TARIHI.Visible = true;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 209;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldKAPAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            fieldKAPAMA_TARIHI.AreaIndex = 24;
            fieldKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Name = "fieldKAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldKAPAMA_TARIHI.Visible = true;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 8;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 9;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 10;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldTAKIP_CIKISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.AreaIndex = 13;
            fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";
            fieldTAKIP_CIKISI.Visible = false;

            PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI_DOVIZ_ID.AreaIndex = 14;
            fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 19;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI.AreaIndex = 20;
            fieldTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Name = "fieldTO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 21;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 22;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldRISK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI.AreaIndex = 25;
            fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";
            fieldRISK_MIKTARI.Visible = false;

            PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 26;
            fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 29;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = true;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.AreaIndex = 31;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 34;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 35;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDURUM.AreaIndex = 40;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldFOY_ARSIV_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_ARSIV_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_ARSIV_TARIHI.AreaIndex = 47;
            fieldFOY_ARSIV_TARIHI.FieldName = "FOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Name = "fieldFOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Visible = false;

            PivotGridField fieldFOY_INFAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_INFAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_INFAZ_TARIHI.AreaIndex = 48;
            fieldFOY_INFAZ_TARIHI.FieldName = "FOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Name = "fieldFOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Visible = false;

            PivotGridField fieldTAKIBIN_MUVEKKILE_IADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.AreaIndex = 49;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.FieldName = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Name = "fieldTAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI.AreaIndex = 157;
            fieldTO_MASRAF_TOPLAMI.FieldName = "TO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Name = "fieldTO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 158;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI.AreaIndex = 159;
            fieldTS_MASRAF_TOPLAMI.FieldName = "TS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Name = "fieldTS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 160;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI.AreaIndex = 161;
            fieldTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Name = "fieldTUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 162;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 208;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 213;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 214;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = true;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 219;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldFORM_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFORM_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFORM_TIPI.AreaIndex = 39;
            fieldFORM_TIPI.FieldName = "FORM_TIPI";
            fieldFORM_TIPI.Name = "fieldFORM_TIPI";
            fieldFORM_TIPI.Visible = false;

            PivotGridField fieldTALEP_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALEP_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALEP_ADI.AreaIndex = 38;
            fieldTALEP_ADI.FieldName = "TALEP_ADI";
            fieldTALEP_ADI.Name = "fieldTALEP_ADI";
            fieldTALEP_ADI.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 218;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = dizi = new PivotGridField[]
            {
                fieldRISK_MIKTARI,
                fieldRISK_MIKTARI_DOVIZ_ID,
                fieldTUM_MASRAF_TOPLAMI,
                fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTS_MASRAF_TOPLAMI,
                fieldTS_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_MASRAF_TOPLAMI,
                fieldTO_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_ODEME_TOPLAMI,
                fieldTO_ODEME_TOPLAMI_DOVIZ_ID,
                fieldKALAN,
                fieldKALAN_DOVIZ_ID,
                fieldTAKIP_CIKISI,
                fieldTAKIP_CIKISI_DOVIZ_ID,
                fieldASIL_ALACAK,
			    fieldASIL_ALACAK_DOVIZ_ID,
                fieldSORUMLU,
                fieldIZLEYEN,
                fieldKAPAMA_TARIHI,
                fieldTALEP_ADI,
                fieldBANKA_SUBE,
                fieldKREDI_GRUP,
			    fieldKREDI_TIP,
                fieldBOLGE,
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			    fieldFOY_ARSIV_TARIHI,
			    fieldFOY_INFAZ_TARIHI,
			    fieldTAKIBIN_MUVEKKILE_IADE_TARIHI,
                fieldID,
                fieldFOY_BIRIM,
                fieldTAKIP_TARIHI,
            };
            fieldKAPAMA_TARIHI.Area = PivotArea.DataArea;
            fieldTAKIP_TARIHI.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldKAPAMA_TARIHI.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldKREDI_TIP.Area = PivotArea.RowArea;
            return dizi;
        }

        private PivotGridField[] TakibeKonulanIcraDosylarininKapananlaraOranıSubelereGore()
        {
            #region Field & Properties

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.AreaIndex = 4;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldTAKIP_TARIHI.Visible = true;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 209;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldKAPAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            fieldKAPAMA_TARIHI.AreaIndex = 24;
            fieldKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Name = "fieldKAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldKAPAMA_TARIHI.Visible = true;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 8;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 9;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 10;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldTAKIP_CIKISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.AreaIndex = 13;
            fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";
            fieldTAKIP_CIKISI.Visible = false;

            PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI_DOVIZ_ID.AreaIndex = 14;
            fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 19;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI.AreaIndex = 20;
            fieldTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Name = "fieldTO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 21;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 22;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldRISK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI.AreaIndex = 25;
            fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";
            fieldRISK_MIKTARI.Visible = false;

            PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 26;
            fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 29;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = true;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.AreaIndex = 31;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 34;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 35;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDURUM.AreaIndex = 40;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldFOY_ARSIV_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_ARSIV_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_ARSIV_TARIHI.AreaIndex = 47;
            fieldFOY_ARSIV_TARIHI.FieldName = "FOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Name = "fieldFOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Visible = false;

            PivotGridField fieldFOY_INFAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_INFAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_INFAZ_TARIHI.AreaIndex = 48;
            fieldFOY_INFAZ_TARIHI.FieldName = "FOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Name = "fieldFOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Visible = false;

            PivotGridField fieldTAKIBIN_MUVEKKILE_IADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.AreaIndex = 49;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.FieldName = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Name = "fieldTAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI.AreaIndex = 157;
            fieldTO_MASRAF_TOPLAMI.FieldName = "TO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Name = "fieldTO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 158;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI.AreaIndex = 159;
            fieldTS_MASRAF_TOPLAMI.FieldName = "TS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Name = "fieldTS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 160;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI.AreaIndex = 161;
            fieldTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Name = "fieldTUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 162;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 208;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = true;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 213;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 214;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 219;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldFORM_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFORM_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFORM_TIPI.AreaIndex = 39;
            fieldFORM_TIPI.FieldName = "FORM_TIPI";
            fieldFORM_TIPI.Name = "fieldFORM_TIPI";
            fieldFORM_TIPI.Visible = false;

            PivotGridField fieldTALEP_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALEP_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALEP_ADI.AreaIndex = 38;
            fieldTALEP_ADI.FieldName = "TALEP_ADI";
            fieldTALEP_ADI.Name = "fieldTALEP_ADI";
            fieldTALEP_ADI.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 218;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = dizi = new PivotGridField[]
            {
                fieldRISK_MIKTARI,
                fieldRISK_MIKTARI_DOVIZ_ID,
                fieldTUM_MASRAF_TOPLAMI,
                fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTS_MASRAF_TOPLAMI,
                fieldTS_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_MASRAF_TOPLAMI,
                fieldTO_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_ODEME_TOPLAMI,
                fieldTO_ODEME_TOPLAMI_DOVIZ_ID,
                fieldKALAN,
                fieldKALAN_DOVIZ_ID,
                fieldTAKIP_CIKISI,
                fieldTAKIP_CIKISI_DOVIZ_ID,
                fieldASIL_ALACAK,
			    fieldASIL_ALACAK_DOVIZ_ID,
                fieldSORUMLU,
                fieldIZLEYEN,
                fieldKAPAMA_TARIHI,
                fieldTALEP_ADI,
                fieldBANKA_SUBE,
                fieldKREDI_GRUP,
			    fieldKREDI_TIP,
                fieldBOLGE,
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			    fieldFOY_ARSIV_TARIHI,
			    fieldFOY_INFAZ_TARIHI,
			    fieldTAKIBIN_MUVEKKILE_IADE_TARIHI,
                fieldID,
                fieldFOY_BIRIM,
                fieldTAKIP_TARIHI,
            };
            fieldKAPAMA_TARIHI.Area = PivotArea.DataArea;
            fieldTAKIP_TARIHI.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldKAPAMA_TARIHI.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldBANKA_SUBE.Area = PivotArea.RowArea;
            return dizi;
        }

        private PivotGridField[] TakibeKonulanIcraDosylarininKapananlaraOranıYilinCeyreklerineGore()
        {
            #region Field & Properties

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.AreaIndex = 4;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldTAKIP_TARIHI.Visible = true;

            PivotGridField fieldKAPAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            fieldKAPAMA_TARIHI.AreaIndex = 24;
            fieldKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Name = "fieldKAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldKAPAMA_TARIHI.Visible = true;

            PivotGridField fieldKAPAMA_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            fieldKAPAMA_TARIHI2.AreaIndex = 24;
            fieldKAPAMA_TARIHI2.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI2.Name = "fieldKAPAMA_TARIHI2";
            fieldKAPAMA_TARIHI2.GroupInterval = PivotGroupInterval.DateQuarter;
            fieldKAPAMA_TARIHI2.Visible = true;

            PivotGridField fieldTAKIP_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI2.AreaIndex = 4;
            fieldTAKIP_TARIHI2.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI2.Name = "fieldTAKIP_TARIHI2";
            fieldTAKIP_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldTAKIP_TARIHI2.Visible = true;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 8;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 9;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 10;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldTAKIP_CIKISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.AreaIndex = 13;
            fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";
            fieldTAKIP_CIKISI.Visible = false;

            PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI_DOVIZ_ID.AreaIndex = 14;
            fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 19;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI.AreaIndex = 20;
            fieldTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Name = "fieldTO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 21;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 22;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldRISK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI.AreaIndex = 25;
            fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";
            fieldRISK_MIKTARI.Visible = false;

            PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 26;
            fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 29;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.AreaIndex = 31;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 34;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 35;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDURUM.AreaIndex = 40;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldFOY_ARSIV_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_ARSIV_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_ARSIV_TARIHI.AreaIndex = 47;
            fieldFOY_ARSIV_TARIHI.FieldName = "FOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Name = "fieldFOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Visible = false;

            PivotGridField fieldFOY_INFAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_INFAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_INFAZ_TARIHI.AreaIndex = 48;
            fieldFOY_INFAZ_TARIHI.FieldName = "FOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Name = "fieldFOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Visible = false;

            PivotGridField fieldTAKIBIN_MUVEKKILE_IADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.AreaIndex = 49;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.FieldName = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Name = "fieldTAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI.AreaIndex = 157;
            fieldTO_MASRAF_TOPLAMI.FieldName = "TO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Name = "fieldTO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 158;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI.AreaIndex = 159;
            fieldTS_MASRAF_TOPLAMI.FieldName = "TS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Name = "fieldTS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 160;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI.AreaIndex = 161;
            fieldTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Name = "fieldTUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 162;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 208;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 213;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 214;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 219;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldFORM_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFORM_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFORM_TIPI.AreaIndex = 39;
            fieldFORM_TIPI.FieldName = "FORM_TIPI";
            fieldFORM_TIPI.Name = "fieldFORM_TIPI";
            fieldFORM_TIPI.Visible = false;

            PivotGridField fieldTALEP_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALEP_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALEP_ADI.AreaIndex = 38;
            fieldTALEP_ADI.FieldName = "TALEP_ADI";
            fieldTALEP_ADI.Name = "fieldTALEP_ADI";
            fieldTALEP_ADI.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 218;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = dizi = new PivotGridField[]
            {
                fieldRISK_MIKTARI,
                fieldRISK_MIKTARI_DOVIZ_ID,
                fieldTUM_MASRAF_TOPLAMI,
                fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTS_MASRAF_TOPLAMI,
                fieldTS_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_MASRAF_TOPLAMI,
                fieldTO_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_ODEME_TOPLAMI,
                fieldTO_ODEME_TOPLAMI_DOVIZ_ID,
                fieldKALAN,
                fieldKALAN_DOVIZ_ID,
                fieldTAKIP_CIKISI,
                fieldTAKIP_CIKISI_DOVIZ_ID,
                fieldASIL_ALACAK,
			    fieldASIL_ALACAK_DOVIZ_ID,
                fieldSORUMLU,
                fieldIZLEYEN,
                fieldKAPAMA_TARIHI,
                fieldKAPAMA_TARIHI2,
                fieldTALEP_ADI,
                fieldBANKA_SUBE,
                fieldKREDI_GRUP,
			    fieldKREDI_TIP,
                fieldBOLGE,
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			    fieldFOY_ARSIV_TARIHI,
			    fieldFOY_INFAZ_TARIHI,
			    fieldTAKIBIN_MUVEKKILE_IADE_TARIHI,
                fieldID,
                fieldTAKIP_TARIHI,
            };
            fieldKAPAMA_TARIHI.Area = PivotArea.DataArea;
            fieldTAKIP_TARIHI.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldKAPAMA_TARIHI.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldKAPAMA_TARIHI2.Area = PivotArea.RowArea;
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            return dizi;
        }

        private PivotGridField[] TakibeKonulanIcraDosylarininKapananlaraOranıYillaraGore()
        {
            #region Field & Properties

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.AreaIndex = 4;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldTAKIP_TARIHI.Visible = true;

            PivotGridField fieldKAPAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            fieldKAPAMA_TARIHI.AreaIndex = 24;
            fieldKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Name = "fieldKAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldKAPAMA_TARIHI.Visible = true;

            PivotGridField fieldKAPAMA_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            fieldKAPAMA_TARIHI2.AreaIndex = 24;
            fieldKAPAMA_TARIHI2.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI2.Name = "fieldKAPAMA_TARIHI2";
            fieldKAPAMA_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldKAPAMA_TARIHI2.Visible = true;

            PivotGridField fieldTAKIP_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI2.AreaIndex = 4;
            fieldTAKIP_TARIHI2.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI2.Name = "fieldTAKIP_TARIHI2";
            fieldTAKIP_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldTAKIP_TARIHI2.Visible = true;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 8;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 9;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 10;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldTAKIP_CIKISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.AreaIndex = 13;
            fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";
            fieldTAKIP_CIKISI.Visible = false;

            PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI_DOVIZ_ID.AreaIndex = 14;
            fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 19;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI.AreaIndex = 20;
            fieldTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Name = "fieldTO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 21;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 22;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldRISK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI.AreaIndex = 25;
            fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";
            fieldRISK_MIKTARI.Visible = false;

            PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 26;
            fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 29;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.AreaIndex = 31;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Name = "fieldID";
            fieldID.Visible = false;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 34;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 35;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDURUM.AreaIndex = 40;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldFOY_ARSIV_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_ARSIV_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_ARSIV_TARIHI.AreaIndex = 47;
            fieldFOY_ARSIV_TARIHI.FieldName = "FOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Name = "fieldFOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Visible = false;

            PivotGridField fieldFOY_INFAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_INFAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_INFAZ_TARIHI.AreaIndex = 48;
            fieldFOY_INFAZ_TARIHI.FieldName = "FOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Name = "fieldFOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Visible = false;

            PivotGridField fieldTAKIBIN_MUVEKKILE_IADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.AreaIndex = 49;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.FieldName = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Name = "fieldTAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI.AreaIndex = 157;
            fieldTO_MASRAF_TOPLAMI.FieldName = "TO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Name = "fieldTO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 158;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI.AreaIndex = 159;
            fieldTS_MASRAF_TOPLAMI.FieldName = "TS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Name = "fieldTS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 160;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI.AreaIndex = 161;
            fieldTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Name = "fieldTUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 162;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 208;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 213;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 214;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 219;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldFORM_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFORM_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFORM_TIPI.AreaIndex = 39;
            fieldFORM_TIPI.FieldName = "FORM_TIPI";
            fieldFORM_TIPI.Name = "fieldFORM_TIPI";
            fieldFORM_TIPI.Visible = false;

            PivotGridField fieldTALEP_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALEP_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALEP_ADI.AreaIndex = 38;
            fieldTALEP_ADI.FieldName = "TALEP_ADI";
            fieldTALEP_ADI.Name = "fieldTALEP_ADI";
            fieldTALEP_ADI.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 218;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = dizi = new PivotGridField[]
            {
                fieldRISK_MIKTARI,
                fieldRISK_MIKTARI_DOVIZ_ID,
                fieldTUM_MASRAF_TOPLAMI,
                fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTS_MASRAF_TOPLAMI,
                fieldTS_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_MASRAF_TOPLAMI,
                fieldTO_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_ODEME_TOPLAMI,
                fieldTO_ODEME_TOPLAMI_DOVIZ_ID,
                fieldKALAN,
                fieldKALAN_DOVIZ_ID,
                fieldTAKIP_CIKISI,
                fieldTAKIP_CIKISI_DOVIZ_ID,
                fieldASIL_ALACAK,
			    fieldASIL_ALACAK_DOVIZ_ID,
                fieldSORUMLU,
                fieldIZLEYEN,
                fieldKAPAMA_TARIHI,
                fieldKAPAMA_TARIHI2,
                fieldTALEP_ADI,
                fieldBANKA_SUBE,
                fieldKREDI_GRUP,
			    fieldKREDI_TIP,
                fieldBOLGE,
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			    fieldFOY_ARSIV_TARIHI,
			    fieldFOY_INFAZ_TARIHI,
			    fieldTAKIBIN_MUVEKKILE_IADE_TARIHI,
                fieldID,
                fieldTAKIP_TARIHI,
            };
            fieldKAPAMA_TARIHI.Area = PivotArea.DataArea;
            fieldTAKIP_TARIHI.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldKAPAMA_TARIHI.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldKAPAMA_TARIHI2.Area = PivotArea.RowArea;
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            return dizi;
        }

        #region PivotMetotlar

        private PivotGridField[] AcizVeDerkenarlaKapananDosyalar()
        {
            #region Field & Properties

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.AreaIndex = 4;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldTAKIP_TARIHI.Visible = true;
            PivotGridField fieldTAKIP_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI2.AreaIndex = 4;
            fieldTAKIP_TARIHI2.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI2.Name = "fieldTAKIP_TARIHI2";
            fieldTAKIP_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldTAKIP_TARIHI2.Visible = true;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 8;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 9;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 10;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldTAKIP_CIKISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.AreaIndex = 13;
            fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";
            fieldTAKIP_CIKISI.Visible = true;

            PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI_DOVIZ_ID.AreaIndex = 14;
            fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 19;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI.AreaIndex = 20;
            fieldTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Name = "fieldTO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 21;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 22;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldRISK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI.AreaIndex = 25;
            fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";
            fieldRISK_MIKTARI.Visible = false;

            PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 26;
            fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 29;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.AreaIndex = 31;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 34;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 35;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDURUM.AreaIndex = 40;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = true;

            PivotGridField fieldFOY_ARSIV_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_ARSIV_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_ARSIV_TARIHI.AreaIndex = 47;
            fieldFOY_ARSIV_TARIHI.FieldName = "FOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Name = "fieldFOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Visible = false;

            PivotGridField fieldFOY_INFAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_INFAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_INFAZ_TARIHI.AreaIndex = 48;
            fieldFOY_INFAZ_TARIHI.FieldName = "FOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Name = "fieldFOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Visible = false;

            PivotGridField fieldTAKIBIN_MUVEKKILE_IADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.AreaIndex = 49;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.FieldName = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Name = "fieldTAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI.AreaIndex = 157;
            fieldTO_MASRAF_TOPLAMI.FieldName = "TO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Name = "fieldTO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 158;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI.AreaIndex = 159;
            fieldTS_MASRAF_TOPLAMI.FieldName = "TS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Name = "fieldTS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 160;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI.AreaIndex = 161;
            fieldTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Name = "fieldTUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 162;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 208;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 213;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 214;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = dizi = new PivotGridField[]
            {
                fieldRISK_MIKTARI,
                fieldRISK_MIKTARI_DOVIZ_ID,
                fieldTUM_MASRAF_TOPLAMI,
                fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTS_MASRAF_TOPLAMI,
                fieldTS_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_MASRAF_TOPLAMI,
                fieldTO_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_ODEME_TOPLAMI,
                fieldTO_ODEME_TOPLAMI_DOVIZ_ID,
                fieldKALAN,
                fieldKALAN_DOVIZ_ID,
                fieldTAKIP_CIKISI,
                fieldTAKIP_CIKISI_DOVIZ_ID,
                fieldASIL_ALACAK,
			    fieldASIL_ALACAK_DOVIZ_ID,
                fieldSORUMLU,
                fieldIZLEYEN,
                fieldDURUM,
                fieldBANKA_SUBE,
                fieldKREDI_GRUP,
			    fieldKREDI_TIP,
                fieldSUBE_KOD_ID,
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			    fieldFOY_ARSIV_TARIHI,
			    fieldFOY_INFAZ_TARIHI,
			    fieldTAKIBIN_MUVEKKILE_IADE_TARIHI,
                fieldID,
                fieldTAKIP_TARIHI2,
                fieldTAKIP_TARIHI,
            };
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI2.Area = PivotArea.RowArea;
            return dizi;
        }

        private PivotGridField[] BirSonrakiAyaDevreden()
        {
            #region Field & Properties

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.AreaIndex = 4;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldTAKIP_TARIHI.Visible = true;
            PivotGridField fieldTAKIP_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI2.AreaIndex = 4;
            fieldTAKIP_TARIHI2.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI2.Name = "fieldTAKIP_TARIHI2";
            fieldTAKIP_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldTAKIP_TARIHI2.Visible = true;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 8;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 9;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 10;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldTAKIP_CIKISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.AreaIndex = 13;
            fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";
            fieldTAKIP_CIKISI.Visible = true;

            PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI_DOVIZ_ID.AreaIndex = 14;
            fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 19;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI.AreaIndex = 20;
            fieldTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Name = "fieldTO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 21;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 22;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldRISK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI.AreaIndex = 25;
            fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";
            fieldRISK_MIKTARI.Visible = false;

            PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 26;
            fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 29;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.AreaIndex = 31;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 34;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 35;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDURUM.AreaIndex = 40;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = true;

            PivotGridField fieldFOY_ARSIV_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_ARSIV_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_ARSIV_TARIHI.AreaIndex = 47;
            fieldFOY_ARSIV_TARIHI.FieldName = "FOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Name = "fieldFOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Visible = false;

            PivotGridField fieldFOY_INFAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_INFAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_INFAZ_TARIHI.AreaIndex = 48;
            fieldFOY_INFAZ_TARIHI.FieldName = "FOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Name = "fieldFOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Visible = false;

            PivotGridField fieldTAKIBIN_MUVEKKILE_IADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.AreaIndex = 49;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.FieldName = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Name = "fieldTAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI.AreaIndex = 157;
            fieldTO_MASRAF_TOPLAMI.FieldName = "TO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Name = "fieldTO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 158;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI.AreaIndex = 159;
            fieldTS_MASRAF_TOPLAMI.FieldName = "TS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Name = "fieldTS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 160;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI.AreaIndex = 161;
            fieldTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Name = "fieldTUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 162;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 208;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 213;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 214;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = dizi = new PivotGridField[]
            {
                fieldRISK_MIKTARI,
                fieldRISK_MIKTARI_DOVIZ_ID,
                fieldTUM_MASRAF_TOPLAMI,
                fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTS_MASRAF_TOPLAMI,
                fieldTS_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_MASRAF_TOPLAMI,
                fieldTO_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_ODEME_TOPLAMI,
                fieldTO_ODEME_TOPLAMI_DOVIZ_ID,
                fieldKALAN,
                fieldKALAN_DOVIZ_ID,
                fieldTAKIP_CIKISI,
                fieldTAKIP_CIKISI_DOVIZ_ID,
                fieldASIL_ALACAK,
			    fieldASIL_ALACAK_DOVIZ_ID,
                fieldSORUMLU,
                fieldIZLEYEN,
                fieldDURUM,
                fieldBANKA_SUBE,
                fieldKREDI_GRUP,
			    fieldKREDI_TIP,
                fieldSUBE_KOD_ID,
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			    fieldFOY_ARSIV_TARIHI,
			    fieldFOY_INFAZ_TARIHI,
			    fieldTAKIBIN_MUVEKKILE_IADE_TARIHI,
                fieldID,
                fieldTAKIP_TARIHI2,
                fieldTAKIP_TARIHI,
            };
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI2.Area = PivotArea.RowArea;
            return dizi;
        }

        private PivotGridField[] BuAyIcindeTahsilatDerkenarIleBitenDosyaSayısı()
        {
            #region Field & Properties

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 0;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 1;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldREFERANS_NO2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO2.AreaIndex = 2;
            fieldREFERANS_NO2.FieldName = "REFERANS_NO2";
            fieldREFERANS_NO2.Name = "fieldREFERANS_NO2";
            fieldREFERANS_NO2.Visible = false;

            PivotGridField fieldREFERANS_NO3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO3.AreaIndex = 3;
            fieldREFERANS_NO3.FieldName = "REFERANS_NO3";
            fieldREFERANS_NO3.Name = "fieldREFERANS_NO3";
            fieldREFERANS_NO3.Visible = false;

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_TARIHI.AreaIndex = 4;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 5;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldICRA_OZEL_KOD3_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_OZEL_KOD3_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_OZEL_KOD3_ID.AreaIndex = 6;
            fieldICRA_OZEL_KOD3_ID.FieldName = "ICRA_OZEL_KOD3_ID";
            fieldICRA_OZEL_KOD3_ID.Name = "fieldICRA_OZEL_KOD3_ID";
            fieldICRA_OZEL_KOD3_ID.Visible = false;

            PivotGridField fieldICRA_OZEL_KOD4_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_OZEL_KOD4_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_OZEL_KOD4_ID.AreaIndex = 7;
            fieldICRA_OZEL_KOD4_ID.FieldName = "ICRA_OZEL_KOD4_ID";
            fieldICRA_OZEL_KOD4_ID.Name = "fieldICRA_OZEL_KOD4_ID";
            fieldICRA_OZEL_KOD4_ID.Visible = false;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 8;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 9;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 10;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldISLEMIS_FAIZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISLEMIS_FAIZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISLEMIS_FAIZ_DOVIZ_ID.AreaIndex = 11;
            fieldISLEMIS_FAIZ_DOVIZ_ID.FieldName = "ISLEMIS_FAIZ_DOVIZ_ID";
            fieldISLEMIS_FAIZ_DOVIZ_ID.Name = "fieldISLEMIS_FAIZ_DOVIZ_ID";
            fieldISLEMIS_FAIZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldISLEMIS_FAIZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldISLEMIS_FAIZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldISLEMIS_FAIZ.AreaIndex = 12;
            fieldISLEMIS_FAIZ.FieldName = "ISLEMIS_FAIZ";
            fieldISLEMIS_FAIZ.Name = "fieldISLEMIS_FAIZ";
            fieldISLEMIS_FAIZ.Visible = false;

            PivotGridField fieldTAKIP_CIKISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI.AreaIndex = 13;
            fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";
            fieldTAKIP_CIKISI.Visible = false;

            PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI_DOVIZ_ID.AreaIndex = 14;
            fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSONRAKI_FAIZ = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSONRAKI_FAIZ.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSONRAKI_FAIZ.AreaIndex = 15;
            fieldSONRAKI_FAIZ.FieldName = "SONRAKI_FAIZ";
            fieldSONRAKI_FAIZ.Name = "fieldSONRAKI_FAIZ";
            fieldSONRAKI_FAIZ.Visible = false;

            PivotGridField fieldSONRAKI_FAIZ_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSONRAKI_FAIZ_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSONRAKI_FAIZ_DOVIZ_ID.AreaIndex = 16;
            fieldSONRAKI_FAIZ_DOVIZ_ID.FieldName = "SONRAKI_FAIZ_DOVIZ_ID";
            fieldSONRAKI_FAIZ_DOVIZ_ID.Name = "fieldSONRAKI_FAIZ_DOVIZ_ID";
            fieldSONRAKI_FAIZ_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 17;
            fieldODEME_TOPLAMI_DOVIZ_ID.FieldName = "ODEME_TOPLAMI_DOVIZ_ID";
            fieldODEME_TOPLAMI_DOVIZ_ID.Name = "fieldODEME_TOPLAMI_DOVIZ_ID";
            fieldODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODEME_TOPLAMI.AreaIndex = 18;
            fieldODEME_TOPLAMI.FieldName = "ODEME_TOPLAMI";
            fieldODEME_TOPLAMI.Name = "fieldODEME_TOPLAMI";
            fieldODEME_TOPLAMI.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 19;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI.AreaIndex = 20;
            fieldTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Name = "fieldTO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 21;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 22;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldACIKLAMA.AreaIndex = 23;
            fieldACIKLAMA.FieldName = "ACIKLAMA";
            fieldACIKLAMA.Name = "fieldACIKLAMA";
            fieldACIKLAMA.Visible = false;

            PivotGridField fieldKAPAMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKAPAMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKAPAMA_TARIHI.AreaIndex = 24;
            fieldKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Name = "fieldKAPAMA_TARIHI";
            fieldKAPAMA_TARIHI.Visible = false;

            PivotGridField fieldRISK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI.AreaIndex = 25;
            fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";
            fieldRISK_MIKTARI.Visible = false;

            PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 26;
            fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_MASRAF_HARC_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_HARC_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_HARC_TOPLAMI.AreaIndex = 27;
            fieldTS_MASRAF_HARC_TOPLAMI.FieldName = "TS_MASRAF_HARC_TOPLAMI";
            fieldTS_MASRAF_HARC_TOPLAMI.Name = "fieldTS_MASRAF_HARC_TOPLAMI";
            fieldTS_MASRAF_HARC_TOPLAMI.Visible = false;

            PivotGridField fieldTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID.AreaIndex = 28;
            fieldTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_HARC_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID.Name = "fieldTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_HARC_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 29;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 30;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.AreaIndex = 31;
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldTAKIP_EDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDEN.AreaIndex = 32;
            fieldTAKIP_EDEN.FieldName = "TAKIP_EDEN";
            fieldTAKIP_EDEN.Name = "fieldTAKIP_EDEN";
            fieldTAKIP_EDEN.Visible = false;

            PivotGridField fieldTAKIP_EDILEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDILEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDILEN.AreaIndex = 33;
            fieldTAKIP_EDILEN.FieldName = "TAKIP_EDILEN";
            fieldTAKIP_EDILEN.Name = "fieldTAKIP_EDILEN";
            fieldTAKIP_EDILEN.Visible = false;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 34;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 35;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldTAKIP_EDEN_SIFAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDEN_SIFAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDEN_SIFAT.AreaIndex = 36;
            fieldTAKIP_EDEN_SIFAT.FieldName = "TAKIP_EDEN_SIFAT";
            fieldTAKIP_EDEN_SIFAT.Name = "fieldTAKIP_EDEN_SIFAT";
            fieldTAKIP_EDEN_SIFAT.Visible = false;

            PivotGridField fieldTAKIP_EDILEN_SIFAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_EDILEN_SIFAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_EDILEN_SIFAT.AreaIndex = 37;
            fieldTAKIP_EDILEN_SIFAT.FieldName = "TAKIP_EDILEN_SIFAT";
            fieldTAKIP_EDILEN_SIFAT.Name = "fieldTAKIP_EDILEN_SIFAT";
            fieldTAKIP_EDILEN_SIFAT.Visible = false;

            PivotGridField fieldTALEP_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALEP_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALEP_ADI.AreaIndex = 38;
            fieldTALEP_ADI.FieldName = "TALEP_ADI";
            fieldTALEP_ADI.Name = "fieldTALEP_ADI";
            fieldTALEP_ADI.Visible = false;

            PivotGridField fieldFORM_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFORM_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFORM_TIPI.AreaIndex = 39;
            fieldFORM_TIPI.FieldName = "FORM_TIPI";
            fieldFORM_TIPI.Name = "fieldFORM_TIPI";
            fieldFORM_TIPI.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDURUM.AreaIndex = 40;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = true;

            PivotGridField fieldICRA_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_ADLIYE.AreaIndex = 41;
            fieldICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            fieldICRA_ADLIYE.Name = "fieldICRA_ADLIYE";
            fieldICRA_ADLIYE.Visible = false;

            PivotGridField fieldICRA_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_BIRIM_NO.AreaIndex = 42;
            fieldICRA_BIRIM_NO.FieldName = "ICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Name = "fieldICRA_BIRIM_NO";
            fieldICRA_BIRIM_NO.Visible = false;

            PivotGridField fieldOZEL_KOD1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD1.AreaIndex = 43;
            fieldOZEL_KOD1.FieldName = "OZEL_KOD1";
            fieldOZEL_KOD1.Name = "fieldOZEL_KOD1";
            fieldOZEL_KOD1.Visible = false;

            PivotGridField fieldOZEL_KOD2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD2.AreaIndex = 44;
            fieldOZEL_KOD2.FieldName = "OZEL_KOD2";
            fieldOZEL_KOD2.Name = "fieldOZEL_KOD2";
            fieldOZEL_KOD2.Visible = false;

            PivotGridField fieldOZEL_KOD3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD3.AreaIndex = 45;
            fieldOZEL_KOD3.FieldName = "OZEL_KOD3";
            fieldOZEL_KOD3.Name = "fieldOZEL_KOD3";
            fieldOZEL_KOD3.Visible = false;

            PivotGridField fieldOZEL_KOD4 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_KOD4.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_KOD4.AreaIndex = 46;
            fieldOZEL_KOD4.FieldName = "OZEL_KOD4";
            fieldOZEL_KOD4.Name = "fieldOZEL_KOD4";
            fieldOZEL_KOD4.Visible = false;

            PivotGridField fieldFOY_ARSIV_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_ARSIV_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_ARSIV_TARIHI.AreaIndex = 47;
            fieldFOY_ARSIV_TARIHI.FieldName = "FOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Name = "fieldFOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Visible = false;

            PivotGridField fieldFOY_INFAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_INFAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_INFAZ_TARIHI.AreaIndex = 48;
            fieldFOY_INFAZ_TARIHI.FieldName = "FOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Name = "fieldFOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Visible = false;

            PivotGridField fieldTAKIBIN_MUVEKKILE_IADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.AreaIndex = 49;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.FieldName = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Name = "fieldTAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Visible = false;

            PivotGridField fieldSON_HESAP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSON_HESAP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSON_HESAP_TARIHI.AreaIndex = 50;
            fieldSON_HESAP_TARIHI.FieldName = "SON_HESAP_TARIHI";
            fieldSON_HESAP_TARIHI.Name = "fieldSON_HESAP_TARIHI";
            fieldSON_HESAP_TARIHI.Visible = false;

            PivotGridField fieldBIR_YIL_KAC_GUN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIR_YIL_KAC_GUN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIR_YIL_KAC_GUN.AreaIndex = 51;
            fieldBIR_YIL_KAC_GUN.FieldName = "BIR_YIL_KAC_GUN";
            fieldBIR_YIL_KAC_GUN.Name = "fieldBIR_YIL_KAC_GUN";
            fieldBIR_YIL_KAC_GUN.Visible = false;

            PivotGridField fieldBSMV_TO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBSMV_TO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBSMV_TO.AreaIndex = 52;
            fieldBSMV_TO.FieldName = "BSMV_TO";
            fieldBSMV_TO.Name = "fieldBSMV_TO";
            fieldBSMV_TO.Visible = false;

            PivotGridField fieldBSMV_TO_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBSMV_TO_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBSMV_TO_DOVIZ_ID.AreaIndex = 53;
            fieldBSMV_TO_DOVIZ_ID.FieldName = "BSMV_TO_DOVIZ_ID";
            fieldBSMV_TO_DOVIZ_ID.Name = "fieldBSMV_TO_DOVIZ_ID";
            fieldBSMV_TO_DOVIZ_ID.Visible = false;

            PivotGridField fieldKKDV_TO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKKDV_TO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKKDV_TO.AreaIndex = 54;
            fieldKKDV_TO.FieldName = "KKDV_TO";
            fieldKKDV_TO.Name = "fieldKKDV_TO";
            fieldKKDV_TO.Visible = false;

            PivotGridField fieldKKDV_TO_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKKDV_TO_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKKDV_TO_DOVIZ_ID.AreaIndex = 55;
            fieldKKDV_TO_DOVIZ_ID.FieldName = "KKDV_TO_DOVIZ_ID";
            fieldKKDV_TO_DOVIZ_ID.Name = "fieldKKDV_TO_DOVIZ_ID";
            fieldKKDV_TO_DOVIZ_ID.Visible = false;

            PivotGridField fieldKDV_TO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKDV_TO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKDV_TO.AreaIndex = 56;
            fieldKDV_TO.FieldName = "KDV_TO";
            fieldKDV_TO.Name = "fieldKDV_TO";
            fieldKDV_TO.Visible = false;

            PivotGridField fieldKDV_TO_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKDV_TO_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKDV_TO_DOVIZ_ID.AreaIndex = 57;
            fieldKDV_TO_DOVIZ_ID.FieldName = "KDV_TO_DOVIZ_ID";
            fieldKDV_TO_DOVIZ_ID.Name = "fieldKDV_TO_DOVIZ_ID";
            fieldKDV_TO_DOVIZ_ID.Visible = false;

            PivotGridField fieldIH_VEKALET_UCRETI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIH_VEKALET_UCRETI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIH_VEKALET_UCRETI.AreaIndex = 58;
            fieldIH_VEKALET_UCRETI.FieldName = "IH_VEKALET_UCRETI";
            fieldIH_VEKALET_UCRETI.Name = "fieldIH_VEKALET_UCRETI";
            fieldIH_VEKALET_UCRETI.Visible = false;

            PivotGridField fieldIH_VEKALET_UCRETI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIH_VEKALET_UCRETI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIH_VEKALET_UCRETI_DOVIZ_ID.AreaIndex = 59;
            fieldIH_VEKALET_UCRETI_DOVIZ_ID.FieldName = "IH_VEKALET_UCRETI_DOVIZ_ID";
            fieldIH_VEKALET_UCRETI_DOVIZ_ID.Name = "fieldIH_VEKALET_UCRETI_DOVIZ_ID";
            fieldIH_VEKALET_UCRETI_DOVIZ_ID.Visible = false;

            PivotGridField fieldIH_GIDERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIH_GIDERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIH_GIDERI.AreaIndex = 60;
            fieldIH_GIDERI.FieldName = "IH_GIDERI";
            fieldIH_GIDERI.Name = "fieldIH_GIDERI";
            fieldIH_GIDERI.Visible = false;

            PivotGridField fieldIH_GIDERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIH_GIDERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIH_GIDERI_DOVIZ_ID.AreaIndex = 61;
            fieldIH_GIDERI_DOVIZ_ID.FieldName = "IH_GIDERI_DOVIZ_ID";
            fieldIH_GIDERI_DOVIZ_ID.Name = "fieldIH_GIDERI_DOVIZ_ID";
            fieldIH_GIDERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldIT_HACIZDE_ODENEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIT_HACIZDE_ODENEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIT_HACIZDE_ODENEN.AreaIndex = 62;
            fieldIT_HACIZDE_ODENEN.FieldName = "IT_HACIZDE_ODENEN";
            fieldIT_HACIZDE_ODENEN.Name = "fieldIT_HACIZDE_ODENEN";
            fieldIT_HACIZDE_ODENEN.Visible = false;

            PivotGridField fieldIT_HACIZDE_ODENEN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIT_HACIZDE_ODENEN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIT_HACIZDE_ODENEN_DOVIZ_ID.AreaIndex = 63;
            fieldIT_HACIZDE_ODENEN_DOVIZ_ID.FieldName = "IT_HACIZDE_ODENEN_DOVIZ_ID";
            fieldIT_HACIZDE_ODENEN_DOVIZ_ID.Name = "fieldIT_HACIZDE_ODENEN_DOVIZ_ID";
            fieldIT_HACIZDE_ODENEN_DOVIZ_ID.Visible = false;

            PivotGridField fieldKARSILIKSIZ_CEK_TAZMINATI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKARSILIKSIZ_CEK_TAZMINATI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKARSILIKSIZ_CEK_TAZMINATI.AreaIndex = 64;
            fieldKARSILIKSIZ_CEK_TAZMINATI.FieldName = "KARSILIKSIZ_CEK_TAZMINATI";
            fieldKARSILIKSIZ_CEK_TAZMINATI.Name = "fieldKARSILIKSIZ_CEK_TAZMINATI";
            fieldKARSILIKSIZ_CEK_TAZMINATI.Visible = false;

            PivotGridField fieldKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.AreaIndex = 65;
            fieldKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.FieldName = "KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID";
            fieldKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.Name = "fieldKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID";
            fieldKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.Visible = false;

            PivotGridField fieldCEK_KOMISYONU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldCEK_KOMISYONU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldCEK_KOMISYONU.AreaIndex = 66;
            fieldCEK_KOMISYONU.FieldName = "CEK_KOMISYONU";
            fieldCEK_KOMISYONU.Name = "fieldCEK_KOMISYONU";
            fieldCEK_KOMISYONU.Visible = false;

            PivotGridField fieldCEK_KOMISYONU_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldCEK_KOMISYONU_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldCEK_KOMISYONU_DOVIZ_ID.AreaIndex = 67;
            fieldCEK_KOMISYONU_DOVIZ_ID.FieldName = "CEK_KOMISYONU_DOVIZ_ID";
            fieldCEK_KOMISYONU_DOVIZ_ID.Name = "fieldCEK_KOMISYONU_DOVIZ_ID";
            fieldCEK_KOMISYONU_DOVIZ_ID.Visible = false;

            PivotGridField fieldILAM_YARGILAMA_GIDERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_YARGILAMA_GIDERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_YARGILAMA_GIDERI.AreaIndex = 68;
            fieldILAM_YARGILAMA_GIDERI.FieldName = "ILAM_YARGILAMA_GIDERI";
            fieldILAM_YARGILAMA_GIDERI.Name = "fieldILAM_YARGILAMA_GIDERI";
            fieldILAM_YARGILAMA_GIDERI.Visible = false;

            PivotGridField fieldILAM_YARGILAMA_GIDERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_YARGILAMA_GIDERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_YARGILAMA_GIDERI_DOVIZ_ID.AreaIndex = 69;
            fieldILAM_YARGILAMA_GIDERI_DOVIZ_ID.FieldName = "ILAM_YARGILAMA_GIDERI_DOVIZ_ID";
            fieldILAM_YARGILAMA_GIDERI_DOVIZ_ID.Name = "fieldILAM_YARGILAMA_GIDERI_DOVIZ_ID";
            fieldILAM_YARGILAMA_GIDERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldILAM_BK_YARG_ONAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_BK_YARG_ONAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_BK_YARG_ONAMA.AreaIndex = 70;
            fieldILAM_BK_YARG_ONAMA.FieldName = "ILAM_BK_YARG_ONAMA";
            fieldILAM_BK_YARG_ONAMA.Name = "fieldILAM_BK_YARG_ONAMA";
            fieldILAM_BK_YARG_ONAMA.Visible = false;

            PivotGridField fieldILAM_BK_YARG_ONAMA_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_BK_YARG_ONAMA_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_BK_YARG_ONAMA_DOVIZ_ID.AreaIndex = 71;
            fieldILAM_BK_YARG_ONAMA_DOVIZ_ID.FieldName = "ILAM_BK_YARG_ONAMA_DOVIZ_ID";
            fieldILAM_BK_YARG_ONAMA_DOVIZ_ID.Name = "fieldILAM_BK_YARG_ONAMA_DOVIZ_ID";
            fieldILAM_BK_YARG_ONAMA_DOVIZ_ID.Visible = false;

            PivotGridField fieldILAM_TEBLIG_GIDERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_TEBLIG_GIDERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_TEBLIG_GIDERI.AreaIndex = 72;
            fieldILAM_TEBLIG_GIDERI.FieldName = "ILAM_TEBLIG_GIDERI";
            fieldILAM_TEBLIG_GIDERI.Name = "fieldILAM_TEBLIG_GIDERI";
            fieldILAM_TEBLIG_GIDERI.Visible = false;

            PivotGridField fieldILAM_TEBLIG_GIDERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_TEBLIG_GIDERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_TEBLIG_GIDERI_DOVIZ_ID.AreaIndex = 73;
            fieldILAM_TEBLIG_GIDERI_DOVIZ_ID.FieldName = "ILAM_TEBLIG_GIDERI_DOVIZ_ID";
            fieldILAM_TEBLIG_GIDERI_DOVIZ_ID.Name = "fieldILAM_TEBLIG_GIDERI_DOVIZ_ID";
            fieldILAM_TEBLIG_GIDERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldILAM_INKAR_TAZMINATI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_INKAR_TAZMINATI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_INKAR_TAZMINATI.AreaIndex = 74;
            fieldILAM_INKAR_TAZMINATI.FieldName = "ILAM_INKAR_TAZMINATI";
            fieldILAM_INKAR_TAZMINATI.Name = "fieldILAM_INKAR_TAZMINATI";
            fieldILAM_INKAR_TAZMINATI.Visible = false;

            PivotGridField fieldILAM_INKAR_TAZMINATI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_INKAR_TAZMINATI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_INKAR_TAZMINATI_DOVIZ_ID.AreaIndex = 75;
            fieldILAM_INKAR_TAZMINATI_DOVIZ_ID.FieldName = "ILAM_INKAR_TAZMINATI_DOVIZ_ID";
            fieldILAM_INKAR_TAZMINATI_DOVIZ_ID.Name = "fieldILAM_INKAR_TAZMINATI_DOVIZ_ID";
            fieldILAM_INKAR_TAZMINATI_DOVIZ_ID.Visible = false;

            PivotGridField fieldILAM_VEK_UCR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_VEK_UCR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_VEK_UCR.AreaIndex = 76;
            fieldILAM_VEK_UCR.FieldName = "ILAM_VEK_UCR";
            fieldILAM_VEK_UCR.Name = "fieldILAM_VEK_UCR";
            fieldILAM_VEK_UCR.Visible = false;

            PivotGridField fieldILAM_VEK_UCR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_VEK_UCR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_VEK_UCR_DOVIZ_ID.AreaIndex = 77;
            fieldILAM_VEK_UCR_DOVIZ_ID.FieldName = "ILAM_VEK_UCR_DOVIZ_ID";
            fieldILAM_VEK_UCR_DOVIZ_ID.Name = "fieldILAM_VEK_UCR_DOVIZ_ID";
            fieldILAM_VEK_UCR_DOVIZ_ID.Visible = false;

            PivotGridField fieldOIV_TO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOIV_TO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOIV_TO.AreaIndex = 78;
            fieldOIV_TO.FieldName = "OIV_TO";
            fieldOIV_TO.Name = "fieldOIV_TO";
            fieldOIV_TO.Visible = false;

            PivotGridField fieldOIV_TO_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOIV_TO_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOIV_TO_DOVIZ_ID.AreaIndex = 79;
            fieldOIV_TO_DOVIZ_ID.FieldName = "OIV_TO_DOVIZ_ID";
            fieldOIV_TO_DOVIZ_ID.Name = "fieldOIV_TO_DOVIZ_ID";
            fieldOIV_TO_DOVIZ_ID.Visible = false;

            PivotGridField fieldPROTESTO_GIDERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROTESTO_GIDERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROTESTO_GIDERI.AreaIndex = 80;
            fieldPROTESTO_GIDERI.FieldName = "PROTESTO_GIDERI";
            fieldPROTESTO_GIDERI.Name = "fieldPROTESTO_GIDERI";
            fieldPROTESTO_GIDERI.Visible = false;

            PivotGridField fieldPROTESTO_GIDERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROTESTO_GIDERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROTESTO_GIDERI_DOVIZ_ID.AreaIndex = 81;
            fieldPROTESTO_GIDERI_DOVIZ_ID.FieldName = "PROTESTO_GIDERI_DOVIZ_ID";
            fieldPROTESTO_GIDERI_DOVIZ_ID.Name = "fieldPROTESTO_GIDERI_DOVIZ_ID";
            fieldPROTESTO_GIDERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldIHTAR_GIDERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIHTAR_GIDERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIHTAR_GIDERI.AreaIndex = 82;
            fieldIHTAR_GIDERI.FieldName = "IHTAR_GIDERI";
            fieldIHTAR_GIDERI.Name = "fieldIHTAR_GIDERI";
            fieldIHTAR_GIDERI.Visible = false;

            PivotGridField fieldIHTAR_GIDERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIHTAR_GIDERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIHTAR_GIDERI_DOVIZ_ID.AreaIndex = 83;
            fieldIHTAR_GIDERI_DOVIZ_ID.FieldName = "IHTAR_GIDERI_DOVIZ_ID";
            fieldIHTAR_GIDERI_DOVIZ_ID.Name = "fieldIHTAR_GIDERI_DOVIZ_ID";
            fieldIHTAR_GIDERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldOZEL_TAZMINAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TAZMINAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TAZMINAT.AreaIndex = 84;
            fieldOZEL_TAZMINAT.FieldName = "OZEL_TAZMINAT";
            fieldOZEL_TAZMINAT.Name = "fieldOZEL_TAZMINAT";
            fieldOZEL_TAZMINAT.Visible = false;

            PivotGridField fieldOZEL_TAZMINAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TAZMINAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TAZMINAT_DOVIZ_ID.AreaIndex = 85;
            fieldOZEL_TAZMINAT_DOVIZ_ID.FieldName = "OZEL_TAZMINAT_DOVIZ_ID";
            fieldOZEL_TAZMINAT_DOVIZ_ID.Name = "fieldOZEL_TAZMINAT_DOVIZ_ID";
            fieldOZEL_TAZMINAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldOZEL_TUTAR1_FAIZ_ORANI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TUTAR1_FAIZ_ORANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TUTAR1_FAIZ_ORANI.AreaIndex = 86;
            fieldOZEL_TUTAR1_FAIZ_ORANI.FieldName = "OZEL_TUTAR1_FAIZ_ORANI";
            fieldOZEL_TUTAR1_FAIZ_ORANI.Name = "fieldOZEL_TUTAR1_FAIZ_ORANI";
            fieldOZEL_TUTAR1_FAIZ_ORANI.Visible = false;

            PivotGridField fieldOZEL_TUTAR_KONU1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TUTAR_KONU1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TUTAR_KONU1.AreaIndex = 87;
            fieldOZEL_TUTAR_KONU1.FieldName = "OZEL_TUTAR_KONU1";
            fieldOZEL_TUTAR_KONU1.Name = "fieldOZEL_TUTAR_KONU1";
            fieldOZEL_TUTAR_KONU1.Visible = false;

            PivotGridField fieldOZEL_TUTAR_KONU2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TUTAR_KONU2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TUTAR_KONU2.AreaIndex = 88;
            fieldOZEL_TUTAR_KONU2.FieldName = "OZEL_TUTAR_KONU2";
            fieldOZEL_TUTAR_KONU2.Name = "fieldOZEL_TUTAR_KONU2";
            fieldOZEL_TUTAR_KONU2.Visible = false;

            PivotGridField fieldOZEL_TUTAR_KONU3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TUTAR_KONU3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TUTAR_KONU3.AreaIndex = 89;
            fieldOZEL_TUTAR_KONU3.FieldName = "OZEL_TUTAR_KONU3";
            fieldOZEL_TUTAR_KONU3.Name = "fieldOZEL_TUTAR_KONU3";
            fieldOZEL_TUTAR_KONU3.Visible = false;

            PivotGridField fieldOZEL_TUTAR1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TUTAR1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TUTAR1.AreaIndex = 90;
            fieldOZEL_TUTAR1.FieldName = "OZEL_TUTAR1";
            fieldOZEL_TUTAR1.Name = "fieldOZEL_TUTAR1";
            fieldOZEL_TUTAR1.Visible = false;

            PivotGridField fieldOZEL_TUTAR1_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TUTAR1_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TUTAR1_DOVIZ_ID.AreaIndex = 91;
            fieldOZEL_TUTAR1_DOVIZ_ID.FieldName = "OZEL_TUTAR1_DOVIZ_ID";
            fieldOZEL_TUTAR1_DOVIZ_ID.Name = "fieldOZEL_TUTAR1_DOVIZ_ID";
            fieldOZEL_TUTAR1_DOVIZ_ID.Visible = false;

            PivotGridField fieldOZEL_TUTAR2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TUTAR2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TUTAR2.AreaIndex = 92;
            fieldOZEL_TUTAR2.FieldName = "OZEL_TUTAR2";
            fieldOZEL_TUTAR2.Name = "fieldOZEL_TUTAR2";
            fieldOZEL_TUTAR2.Visible = false;

            PivotGridField fieldOZEL_TUTAR2_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TUTAR2_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TUTAR2_DOVIZ_ID.AreaIndex = 93;
            fieldOZEL_TUTAR2_DOVIZ_ID.FieldName = "OZEL_TUTAR2_DOVIZ_ID";
            fieldOZEL_TUTAR2_DOVIZ_ID.Name = "fieldOZEL_TUTAR2_DOVIZ_ID";
            fieldOZEL_TUTAR2_DOVIZ_ID.Visible = false;

            PivotGridField fieldOZEL_TUTAR3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TUTAR3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TUTAR3.AreaIndex = 94;
            fieldOZEL_TUTAR3.FieldName = "OZEL_TUTAR3";
            fieldOZEL_TUTAR3.Name = "fieldOZEL_TUTAR3";
            fieldOZEL_TUTAR3.Visible = false;

            PivotGridField fieldOZEL_TUTAR3_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOZEL_TUTAR3_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOZEL_TUTAR3_DOVIZ_ID.AreaIndex = 95;
            fieldOZEL_TUTAR3_DOVIZ_ID.FieldName = "OZEL_TUTAR3_DOVIZ_ID";
            fieldOZEL_TUTAR3_DOVIZ_ID.Name = "fieldOZEL_TUTAR3_DOVIZ_ID";
            fieldOZEL_TUTAR3_DOVIZ_ID.Visible = false;

            PivotGridField fieldSONRAKI_TAZMINAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSONRAKI_TAZMINAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSONRAKI_TAZMINAT.AreaIndex = 96;
            fieldSONRAKI_TAZMINAT.FieldName = "SONRAKI_TAZMINAT";
            fieldSONRAKI_TAZMINAT.Name = "fieldSONRAKI_TAZMINAT";
            fieldSONRAKI_TAZMINAT.Visible = false;

            PivotGridField fieldSONRAKI_TAZMINAT_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSONRAKI_TAZMINAT_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSONRAKI_TAZMINAT_DOVIZ_ID.AreaIndex = 97;
            fieldSONRAKI_TAZMINAT_DOVIZ_ID.FieldName = "SONRAKI_TAZMINAT_DOVIZ_ID";
            fieldSONRAKI_TAZMINAT_DOVIZ_ID.Name = "fieldSONRAKI_TAZMINAT_DOVIZ_ID";
            fieldSONRAKI_TAZMINAT_DOVIZ_ID.Visible = false;

            PivotGridField fieldBSMV_TS = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBSMV_TS.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBSMV_TS.AreaIndex = 98;
            fieldBSMV_TS.FieldName = "BSMV_TS";
            fieldBSMV_TS.Name = "fieldBSMV_TS";
            fieldBSMV_TS.Visible = false;

            PivotGridField fieldBSMV_TS_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBSMV_TS_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBSMV_TS_DOVIZ_ID.AreaIndex = 99;
            fieldBSMV_TS_DOVIZ_ID.FieldName = "BSMV_TS_DOVIZ_ID";
            fieldBSMV_TS_DOVIZ_ID.Name = "fieldBSMV_TS_DOVIZ_ID";
            fieldBSMV_TS_DOVIZ_ID.Visible = false;

            PivotGridField fieldOIV_TS = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOIV_TS.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOIV_TS.AreaIndex = 100;
            fieldOIV_TS.FieldName = "OIV_TS";
            fieldOIV_TS.Name = "fieldOIV_TS";
            fieldOIV_TS.Visible = false;

            PivotGridField fieldOIV_TS_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldOIV_TS_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldOIV_TS_DOVIZ_ID.AreaIndex = 101;
            fieldOIV_TS_DOVIZ_ID.FieldName = "OIV_TS_DOVIZ_ID";
            fieldOIV_TS_DOVIZ_ID.Name = "fieldOIV_TS_DOVIZ_ID";
            fieldOIV_TS_DOVIZ_ID.Visible = false;

            PivotGridField fieldKDV_TS = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKDV_TS.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKDV_TS.AreaIndex = 102;
            fieldKDV_TS.FieldName = "KDV_TS";
            fieldKDV_TS.Name = "fieldKDV_TS";
            fieldKDV_TS.Visible = false;

            PivotGridField fieldKDV_TS_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKDV_TS_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKDV_TS_DOVIZ_ID.AreaIndex = 103;
            fieldKDV_TS_DOVIZ_ID.FieldName = "KDV_TS_DOVIZ_ID";
            fieldKDV_TS_DOVIZ_ID.Name = "fieldKDV_TS_DOVIZ_ID";
            fieldKDV_TS_DOVIZ_ID.Visible = false;

            PivotGridField fieldILK_GIDERLER = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILK_GIDERLER.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILK_GIDERLER.AreaIndex = 104;
            fieldILK_GIDERLER.FieldName = "ILK_GIDERLER";
            fieldILK_GIDERLER.Name = "fieldILK_GIDERLER";
            fieldILK_GIDERLER.Visible = false;

            PivotGridField fieldILK_GIDERLER_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILK_GIDERLER_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILK_GIDERLER_DOVIZ_ID.AreaIndex = 105;
            fieldILK_GIDERLER_DOVIZ_ID.FieldName = "ILK_GIDERLER_DOVIZ_ID";
            fieldILK_GIDERLER_DOVIZ_ID.Name = "fieldILK_GIDERLER_DOVIZ_ID";
            fieldILK_GIDERLER_DOVIZ_ID.Visible = false;

            PivotGridField fieldPESIN_HARC = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPESIN_HARC.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPESIN_HARC.AreaIndex = 106;
            fieldPESIN_HARC.FieldName = "PESIN_HARC";
            fieldPESIN_HARC.Name = "fieldPESIN_HARC";
            fieldPESIN_HARC.Visible = false;

            PivotGridField fieldPESIN_HARC_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPESIN_HARC_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPESIN_HARC_DOVIZ_ID.AreaIndex = 107;
            fieldPESIN_HARC_DOVIZ_ID.FieldName = "PESIN_HARC_DOVIZ_ID";
            fieldPESIN_HARC_DOVIZ_ID.Name = "fieldPESIN_HARC_DOVIZ_ID";
            fieldPESIN_HARC_DOVIZ_ID.Visible = false;

            PivotGridField fieldODENEN_TAHSIL_HARCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODENEN_TAHSIL_HARCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODENEN_TAHSIL_HARCI.AreaIndex = 108;
            fieldODENEN_TAHSIL_HARCI.FieldName = "ODENEN_TAHSIL_HARCI";
            fieldODENEN_TAHSIL_HARCI.Name = "fieldODENEN_TAHSIL_HARCI";
            fieldODENEN_TAHSIL_HARCI.Visible = false;

            PivotGridField fieldODENEN_TAHSIL_HARCI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldODENEN_TAHSIL_HARCI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldODENEN_TAHSIL_HARCI_DOVIZ_ID.AreaIndex = 109;
            fieldODENEN_TAHSIL_HARCI_DOVIZ_ID.FieldName = "ODENEN_TAHSIL_HARCI_DOVIZ_ID";
            fieldODENEN_TAHSIL_HARCI_DOVIZ_ID.Name = "fieldODENEN_TAHSIL_HARCI_DOVIZ_ID";
            fieldODENEN_TAHSIL_HARCI_DOVIZ_ID.Visible = false;

            PivotGridField fieldKALAN_TAHSIL_HARCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_TAHSIL_HARCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_TAHSIL_HARCI.AreaIndex = 110;
            fieldKALAN_TAHSIL_HARCI.FieldName = "KALAN_TAHSIL_HARCI";
            fieldKALAN_TAHSIL_HARCI.Name = "fieldKALAN_TAHSIL_HARCI";
            fieldKALAN_TAHSIL_HARCI.Visible = false;

            PivotGridField fieldKALAN_TAHSIL_HARCI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_TAHSIL_HARCI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_TAHSIL_HARCI_DOVIZ_ID.AreaIndex = 111;
            fieldKALAN_TAHSIL_HARCI_DOVIZ_ID.FieldName = "KALAN_TAHSIL_HARCI_DOVIZ_ID";
            fieldKALAN_TAHSIL_HARCI_DOVIZ_ID.Name = "fieldKALAN_TAHSIL_HARCI_DOVIZ_ID";
            fieldKALAN_TAHSIL_HARCI_DOVIZ_ID.Visible = false;

            PivotGridField fieldMASAYA_KATILMA_HARCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASAYA_KATILMA_HARCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMASAYA_KATILMA_HARCI.AreaIndex = 112;
            fieldMASAYA_KATILMA_HARCI.FieldName = "MASAYA_KATILMA_HARCI";
            fieldMASAYA_KATILMA_HARCI.Name = "fieldMASAYA_KATILMA_HARCI";
            fieldMASAYA_KATILMA_HARCI.Visible = false;

            PivotGridField fieldMASAYA_KATILMA_HARCI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMASAYA_KATILMA_HARCI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMASAYA_KATILMA_HARCI_DOVIZ_ID.AreaIndex = 113;
            fieldMASAYA_KATILMA_HARCI_DOVIZ_ID.FieldName = "MASAYA_KATILMA_HARCI_DOVIZ_ID";
            fieldMASAYA_KATILMA_HARCI_DOVIZ_ID.Name = "fieldMASAYA_KATILMA_HARCI_DOVIZ_ID";
            fieldMASAYA_KATILMA_HARCI_DOVIZ_ID.Visible = false;

            PivotGridField fieldPAYLASMA_HARCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPAYLASMA_HARCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPAYLASMA_HARCI.AreaIndex = 114;
            fieldPAYLASMA_HARCI.FieldName = "PAYLASMA_HARCI";
            fieldPAYLASMA_HARCI.Name = "fieldPAYLASMA_HARCI";
            fieldPAYLASMA_HARCI.Visible = false;

            PivotGridField fieldPAYLASMA_HARCI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPAYLASMA_HARCI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPAYLASMA_HARCI_DOVIZ_ID.AreaIndex = 115;
            fieldPAYLASMA_HARCI_DOVIZ_ID.FieldName = "PAYLASMA_HARCI_DOVIZ_ID";
            fieldPAYLASMA_HARCI_DOVIZ_ID.Name = "fieldPAYLASMA_HARCI_DOVIZ_ID";
            fieldPAYLASMA_HARCI_DOVIZ_ID.Visible = false;

            PivotGridField fieldDAVA_GIDERLERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_GIDERLERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_GIDERLERI.AreaIndex = 116;
            fieldDAVA_GIDERLERI.FieldName = "DAVA_GIDERLERI";
            fieldDAVA_GIDERLERI.Name = "fieldDAVA_GIDERLERI";
            fieldDAVA_GIDERLERI.Visible = false;

            PivotGridField fieldDAVA_GIDERLERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_GIDERLERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_GIDERLERI_DOVIZ_ID.AreaIndex = 117;
            fieldDAVA_GIDERLERI_DOVIZ_ID.FieldName = "DAVA_GIDERLERI_DOVIZ_ID";
            fieldDAVA_GIDERLERI_DOVIZ_ID.Name = "fieldDAVA_GIDERLERI_DOVIZ_ID";
            fieldDAVA_GIDERLERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldDIGER_GIDERLER = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDIGER_GIDERLER.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDIGER_GIDERLER.AreaIndex = 118;
            fieldDIGER_GIDERLER.FieldName = "DIGER_GIDERLER";
            fieldDIGER_GIDERLER.Name = "fieldDIGER_GIDERLER";
            fieldDIGER_GIDERLER.Visible = false;

            PivotGridField fieldDIGER_GIDERLER_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDIGER_GIDERLER_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDIGER_GIDERLER_DOVIZ_ID.AreaIndex = 119;
            fieldDIGER_GIDERLER_DOVIZ_ID.FieldName = "DIGER_GIDERLER_DOVIZ_ID";
            fieldDIGER_GIDERLER_DOVIZ_ID.Name = "fieldDIGER_GIDERLER_DOVIZ_ID";
            fieldDIGER_GIDERLER_DOVIZ_ID.Visible = false;

            PivotGridField fieldTAKIP_VEKALET_UCRETI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_VEKALET_UCRETI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_VEKALET_UCRETI.AreaIndex = 120;
            fieldTAKIP_VEKALET_UCRETI.FieldName = "TAKIP_VEKALET_UCRETI";
            fieldTAKIP_VEKALET_UCRETI.Name = "fieldTAKIP_VEKALET_UCRETI";
            fieldTAKIP_VEKALET_UCRETI.Visible = false;

            PivotGridField fieldTAKIP_VEKALET_UCRETI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_VEKALET_UCRETI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_VEKALET_UCRETI_DOVIZ_ID.AreaIndex = 121;
            fieldTAKIP_VEKALET_UCRETI_DOVIZ_ID.FieldName = "TAKIP_VEKALET_UCRETI_DOVIZ_ID";
            fieldTAKIP_VEKALET_UCRETI_DOVIZ_ID.Name = "fieldTAKIP_VEKALET_UCRETI_DOVIZ_ID";
            fieldTAKIP_VEKALET_UCRETI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTAKIP_VEKALET_UCRETI_KATSAYI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_VEKALET_UCRETI_KATSAYI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_VEKALET_UCRETI_KATSAYI.AreaIndex = 122;
            fieldTAKIP_VEKALET_UCRETI_KATSAYI.FieldName = "TAKIP_VEKALET_UCRETI_KATSAYI";
            fieldTAKIP_VEKALET_UCRETI_KATSAYI.Name = "fieldTAKIP_VEKALET_UCRETI_KATSAYI";
            fieldTAKIP_VEKALET_UCRETI_KATSAYI.Visible = false;

            PivotGridField fieldDAVA_INKAR_TAZMINATI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_INKAR_TAZMINATI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_INKAR_TAZMINATI.AreaIndex = 123;
            fieldDAVA_INKAR_TAZMINATI.FieldName = "DAVA_INKAR_TAZMINATI";
            fieldDAVA_INKAR_TAZMINATI.Name = "fieldDAVA_INKAR_TAZMINATI";
            fieldDAVA_INKAR_TAZMINATI.Visible = false;

            PivotGridField fieldDAVA_INKAR_TAZMINATI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_INKAR_TAZMINATI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_INKAR_TAZMINATI_DOVIZ_ID.AreaIndex = 124;
            fieldDAVA_INKAR_TAZMINATI_DOVIZ_ID.FieldName = "DAVA_INKAR_TAZMINATI_DOVIZ_ID";
            fieldDAVA_INKAR_TAZMINATI_DOVIZ_ID.Name = "fieldDAVA_INKAR_TAZMINATI_DOVIZ_ID";
            fieldDAVA_INKAR_TAZMINATI_DOVIZ_ID.Visible = false;

            PivotGridField fieldDAVA_VEKALET_UCRETI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_VEKALET_UCRETI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_VEKALET_UCRETI.AreaIndex = 125;
            fieldDAVA_VEKALET_UCRETI.FieldName = "DAVA_VEKALET_UCRETI";
            fieldDAVA_VEKALET_UCRETI.Name = "fieldDAVA_VEKALET_UCRETI";
            fieldDAVA_VEKALET_UCRETI.Visible = false;

            PivotGridField fieldDAVA_VEKALET_UCRETI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_VEKALET_UCRETI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_VEKALET_UCRETI_DOVIZ_ID.AreaIndex = 126;
            fieldDAVA_VEKALET_UCRETI_DOVIZ_ID.FieldName = "DAVA_VEKALET_UCRETI_DOVIZ_ID";
            fieldDAVA_VEKALET_UCRETI_DOVIZ_ID.Name = "fieldDAVA_VEKALET_UCRETI_DOVIZ_ID";
            fieldDAVA_VEKALET_UCRETI_DOVIZ_ID.Visible = false;

            PivotGridField fieldMAHSUP_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMAHSUP_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMAHSUP_TOPLAMI.AreaIndex = 127;
            fieldMAHSUP_TOPLAMI.FieldName = "MAHSUP_TOPLAMI";
            fieldMAHSUP_TOPLAMI.Name = "fieldMAHSUP_TOPLAMI";
            fieldMAHSUP_TOPLAMI.Visible = false;

            PivotGridField fieldMAHSUP_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldMAHSUP_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldMAHSUP_TOPLAMI_DOVIZ_ID.AreaIndex = 128;
            fieldMAHSUP_TOPLAMI_DOVIZ_ID.FieldName = "MAHSUP_TOPLAMI_DOVIZ_ID";
            fieldMAHSUP_TOPLAMI_DOVIZ_ID.Name = "fieldMAHSUP_TOPLAMI_DOVIZ_ID";
            fieldMAHSUP_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldFERAGAT_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFERAGAT_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFERAGAT_TOPLAMI.AreaIndex = 129;
            fieldFERAGAT_TOPLAMI.FieldName = "FERAGAT_TOPLAMI";
            fieldFERAGAT_TOPLAMI.Name = "fieldFERAGAT_TOPLAMI";
            fieldFERAGAT_TOPLAMI.Visible = false;

            PivotGridField fieldFERAGAT_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFERAGAT_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFERAGAT_TOPLAMI_DOVIZ_ID.AreaIndex = 130;
            fieldFERAGAT_TOPLAMI_DOVIZ_ID.FieldName = "FERAGAT_TOPLAMI_DOVIZ_ID";
            fieldFERAGAT_TOPLAMI_DOVIZ_ID.Name = "fieldFERAGAT_TOPLAMI_DOVIZ_ID";
            fieldFERAGAT_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldALACAK_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALACAK_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldALACAK_TOPLAMI.AreaIndex = 131;
            fieldALACAK_TOPLAMI.FieldName = "ALACAK_TOPLAMI";
            fieldALACAK_TOPLAMI.Name = "fieldALACAK_TOPLAMI";
            fieldALACAK_TOPLAMI.Visible = false;

            PivotGridField fieldALACAK_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldALACAK_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldALACAK_TOPLAMI_DOVIZ_ID.AreaIndex = 132;
            fieldALACAK_TOPLAMI_DOVIZ_ID.FieldName = "ALACAK_TOPLAMI_DOVIZ_ID";
            fieldALACAK_TOPLAMI_DOVIZ_ID.Name = "fieldALACAK_TOPLAMI_DOVIZ_ID";
            fieldALACAK_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTAHLIYE_VEK_UCR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHLIYE_VEK_UCR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHLIYE_VEK_UCR.AreaIndex = 133;
            fieldTAHLIYE_VEK_UCR.FieldName = "TAHLIYE_VEK_UCR";
            fieldTAHLIYE_VEK_UCR.Name = "fieldTAHLIYE_VEK_UCR";
            fieldTAHLIYE_VEK_UCR.Visible = false;

            PivotGridField fieldTAHLIYE_VEK_UCR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHLIYE_VEK_UCR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHLIYE_VEK_UCR_DOVIZ_ID.AreaIndex = 134;
            fieldTAHLIYE_VEK_UCR_DOVIZ_ID.FieldName = "TAHLIYE_VEK_UCR_DOVIZ_ID";
            fieldTAHLIYE_VEK_UCR_DOVIZ_ID.Name = "fieldTAHLIYE_VEK_UCR_DOVIZ_ID";
            fieldTAHLIYE_VEK_UCR_DOVIZ_ID.Visible = false;

            PivotGridField fieldDIGER_HARC = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDIGER_HARC.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDIGER_HARC.AreaIndex = 135;
            fieldDIGER_HARC.FieldName = "DIGER_HARC";
            fieldDIGER_HARC.Name = "fieldDIGER_HARC";
            fieldDIGER_HARC.Visible = false;

            PivotGridField fieldDIGER_HARC_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDIGER_HARC_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDIGER_HARC_DOVIZ_ID.AreaIndex = 136;
            fieldDIGER_HARC_DOVIZ_ID.FieldName = "DIGER_HARC_DOVIZ_ID";
            fieldDIGER_HARC_DOVIZ_ID.Name = "fieldDIGER_HARC_DOVIZ_ID";
            fieldDIGER_HARC_DOVIZ_ID.Visible = false;

            PivotGridField fieldTD_GIDERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTD_GIDERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTD_GIDERI.AreaIndex = 137;
            fieldTD_GIDERI.FieldName = "TD_GIDERI";
            fieldTD_GIDERI.Name = "fieldTD_GIDERI";
            fieldTD_GIDERI.Visible = false;

            PivotGridField fieldTD_GIDERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTD_GIDERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTD_GIDERI_DOVIZ_ID.AreaIndex = 138;
            fieldTD_GIDERI_DOVIZ_ID.FieldName = "TD_GIDERI_DOVIZ_ID";
            fieldTD_GIDERI_DOVIZ_ID.Name = "fieldTD_GIDERI_DOVIZ_ID";
            fieldTD_GIDERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTD_BAKIYE_HARC = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTD_BAKIYE_HARC.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTD_BAKIYE_HARC.AreaIndex = 139;
            fieldTD_BAKIYE_HARC.FieldName = "TD_BAKIYE_HARC";
            fieldTD_BAKIYE_HARC.Name = "fieldTD_BAKIYE_HARC";
            fieldTD_BAKIYE_HARC.Visible = false;

            PivotGridField fieldTD_BAKIYE_HARC_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTD_BAKIYE_HARC_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTD_BAKIYE_HARC_DOVIZ_ID.AreaIndex = 140;
            fieldTD_BAKIYE_HARC_DOVIZ_ID.FieldName = "TD_BAKIYE_HARC_DOVIZ_ID";
            fieldTD_BAKIYE_HARC_DOVIZ_ID.Name = "fieldTD_BAKIYE_HARC_DOVIZ_ID";
            fieldTD_BAKIYE_HARC_DOVIZ_ID.Visible = false;

            PivotGridField fieldTD_VEK_UCR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTD_VEK_UCR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTD_VEK_UCR.AreaIndex = 141;
            fieldTD_VEK_UCR.FieldName = "TD_VEK_UCR";
            fieldTD_VEK_UCR.Name = "fieldTD_VEK_UCR";
            fieldTD_VEK_UCR.Visible = false;

            PivotGridField fieldTD_VEK_UCR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTD_VEK_UCR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTD_VEK_UCR_DOVIZ_ID.AreaIndex = 142;
            fieldTD_VEK_UCR_DOVIZ_ID.FieldName = "TD_VEK_UCR_DOVIZ_ID";
            fieldTD_VEK_UCR_DOVIZ_ID.Name = "fieldTD_VEK_UCR_DOVIZ_ID";
            fieldTD_VEK_UCR_DOVIZ_ID.Visible = false;

            PivotGridField fieldTD_TEBLIG_GIDERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTD_TEBLIG_GIDERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTD_TEBLIG_GIDERI.AreaIndex = 143;
            fieldTD_TEBLIG_GIDERI.FieldName = "TD_TEBLIG_GIDERI";
            fieldTD_TEBLIG_GIDERI.Name = "fieldTD_TEBLIG_GIDERI";
            fieldTD_TEBLIG_GIDERI.Visible = false;

            PivotGridField fieldTD_TEBLIG_GIDERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTD_TEBLIG_GIDERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTD_TEBLIG_GIDERI_DOVIZ_ID.AreaIndex = 144;
            fieldTD_TEBLIG_GIDERI_DOVIZ_ID.FieldName = "TD_TEBLIG_GIDERI_DOVIZ_ID";
            fieldTD_TEBLIG_GIDERI_DOVIZ_ID.Name = "fieldTD_TEBLIG_GIDERI_DOVIZ_ID";
            fieldTD_TEBLIG_GIDERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldBIRIKMIS_NAFAKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIKMIS_NAFAKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIKMIS_NAFAKA.AreaIndex = 145;
            fieldBIRIKMIS_NAFAKA.FieldName = "BIRIKMIS_NAFAKA";
            fieldBIRIKMIS_NAFAKA.Name = "fieldBIRIKMIS_NAFAKA";
            fieldBIRIKMIS_NAFAKA.Visible = false;

            PivotGridField fieldBIRIKMIS_NAFAKA_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBIRIKMIS_NAFAKA_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBIRIKMIS_NAFAKA_DOVIZ_ID.AreaIndex = 146;
            fieldBIRIKMIS_NAFAKA_DOVIZ_ID.FieldName = "BIRIKMIS_NAFAKA_DOVIZ_ID";
            fieldBIRIKMIS_NAFAKA_DOVIZ_ID.Name = "fieldBIRIKMIS_NAFAKA_DOVIZ_ID";
            fieldBIRIKMIS_NAFAKA_DOVIZ_ID.Visible = false;

            PivotGridField fieldICRA_INKAR_TAZMINATI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_INKAR_TAZMINATI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_INKAR_TAZMINATI.AreaIndex = 147;
            fieldICRA_INKAR_TAZMINATI.FieldName = "ICRA_INKAR_TAZMINATI";
            fieldICRA_INKAR_TAZMINATI.Name = "fieldICRA_INKAR_TAZMINATI";
            fieldICRA_INKAR_TAZMINATI.Visible = false;

            PivotGridField fieldICRA_INKAR_TAZMINATI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_INKAR_TAZMINATI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_INKAR_TAZMINATI_DOVIZ_ID.AreaIndex = 148;
            fieldICRA_INKAR_TAZMINATI_DOVIZ_ID.FieldName = "ICRA_INKAR_TAZMINATI_DOVIZ_ID";
            fieldICRA_INKAR_TAZMINATI_DOVIZ_ID.Name = "fieldICRA_INKAR_TAZMINATI_DOVIZ_ID";
            fieldICRA_INKAR_TAZMINATI_DOVIZ_ID.Visible = false;

            PivotGridField fieldDAMGA_PULU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAMGA_PULU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAMGA_PULU.AreaIndex = 149;
            fieldDAMGA_PULU.FieldName = "DAMGA_PULU";
            fieldDAMGA_PULU.Name = "fieldDAMGA_PULU";
            fieldDAMGA_PULU.Visible = false;

            PivotGridField fieldDAMGA_PULU_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAMGA_PULU_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAMGA_PULU_DOVIZ_ID.AreaIndex = 150;
            fieldDAMGA_PULU_DOVIZ_ID.FieldName = "DAMGA_PULU_DOVIZ_ID";
            fieldDAMGA_PULU_DOVIZ_ID.Name = "fieldDAMGA_PULU_DOVIZ_ID";
            fieldDAMGA_PULU_DOVIZ_ID.Visible = false;

            PivotGridField fieldPROTOKOL_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROTOKOL_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROTOKOL_MIKTARI.AreaIndex = 151;
            fieldPROTOKOL_MIKTARI.FieldName = "PROTOKOL_MIKTARI";
            fieldPROTOKOL_MIKTARI.Name = "fieldPROTOKOL_MIKTARI";
            fieldPROTOKOL_MIKTARI.Visible = false;

            PivotGridField fieldPROTOKOL_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROTOKOL_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROTOKOL_MIKTARI_DOVIZ_ID.AreaIndex = 152;
            fieldPROTOKOL_MIKTARI_DOVIZ_ID.FieldName = "PROTOKOL_MIKTARI_DOVIZ_ID";
            fieldPROTOKOL_MIKTARI_DOVIZ_ID.Name = "fieldPROTOKOL_MIKTARI_DOVIZ_ID";
            fieldPROTOKOL_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldPROTOKOL_FAIZ_ORANI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROTOKOL_FAIZ_ORANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROTOKOL_FAIZ_ORANI.AreaIndex = 153;
            fieldPROTOKOL_FAIZ_ORANI.FieldName = "PROTOKOL_FAIZ_ORANI";
            fieldPROTOKOL_FAIZ_ORANI.Name = "fieldPROTOKOL_FAIZ_ORANI";
            fieldPROTOKOL_FAIZ_ORANI.Visible = false;

            PivotGridField fieldPROTOKOL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPROTOKOL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPROTOKOL_TARIHI.AreaIndex = 154;
            fieldPROTOKOL_TARIHI.FieldName = "PROTOKOL_TARIHI";
            fieldPROTOKOL_TARIHI.Name = "fieldPROTOKOL_TARIHI";
            fieldPROTOKOL_TARIHI.Visible = false;

            PivotGridField fieldKARSILIK_TUTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKARSILIK_TUTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKARSILIK_TUTARI.AreaIndex = 155;
            fieldKARSILIK_TUTARI.FieldName = "KARSILIK_TUTARI";
            fieldKARSILIK_TUTARI.Name = "fieldKARSILIK_TUTARI";
            fieldKARSILIK_TUTARI.Visible = false;

            PivotGridField fieldKARSILIK_TUTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKARSILIK_TUTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKARSILIK_TUTARI_DOVIZ_ID.AreaIndex = 156;
            fieldKARSILIK_TUTARI_DOVIZ_ID.FieldName = "KARSILIK_TUTARI_DOVIZ_ID";
            fieldKARSILIK_TUTARI_DOVIZ_ID.Name = "fieldKARSILIK_TUTARI_DOVIZ_ID";
            fieldKARSILIK_TUTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI.AreaIndex = 157;
            fieldTO_MASRAF_TOPLAMI.FieldName = "TO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Name = "fieldTO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 158;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI.AreaIndex = 159;
            fieldTS_MASRAF_TOPLAMI.FieldName = "TS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Name = "fieldTS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 160;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI.AreaIndex = 161;
            fieldTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Name = "fieldTUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 162;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldHARC_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHARC_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHARC_TOPLAMI.AreaIndex = 163;
            fieldHARC_TOPLAMI.FieldName = "HARC_TOPLAMI";
            fieldHARC_TOPLAMI.Name = "fieldHARC_TOPLAMI";
            fieldHARC_TOPLAMI.Visible = false;

            PivotGridField fieldHARC_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHARC_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHARC_TOPLAMI_DOVIZ_ID.AreaIndex = 164;
            fieldHARC_TOPLAMI_DOVIZ_ID.FieldName = "HARC_TOPLAMI_DOVIZ_ID";
            fieldHARC_TOPLAMI_DOVIZ_ID.Name = "fieldHARC_TOPLAMI_DOVIZ_ID";
            fieldHARC_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_VEKALET_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_VEKALET_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_VEKALET_TOPLAMI.AreaIndex = 165;
            fieldTO_VEKALET_TOPLAMI.FieldName = "TO_VEKALET_TOPLAMI";
            fieldTO_VEKALET_TOPLAMI.Name = "fieldTO_VEKALET_TOPLAMI";
            fieldTO_VEKALET_TOPLAMI.Visible = false;

            PivotGridField fieldTO_VEKALET_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_VEKALET_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_VEKALET_TOPLAMI_DOVIZ_ID.AreaIndex = 166;
            fieldTO_VEKALET_TOPLAMI_DOVIZ_ID.FieldName = "TO_VEKALET_TOPLAMI_DOVIZ_ID";
            fieldTO_VEKALET_TOPLAMI_DOVIZ_ID.Name = "fieldTO_VEKALET_TOPLAMI_DOVIZ_ID";
            fieldTO_VEKALET_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_VEKALET_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_VEKALET_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_VEKALET_TOPLAMI.AreaIndex = 167;
            fieldTS_VEKALET_TOPLAMI.FieldName = "TS_VEKALET_TOPLAMI";
            fieldTS_VEKALET_TOPLAMI.Name = "fieldTS_VEKALET_TOPLAMI";
            fieldTS_VEKALET_TOPLAMI.Visible = false;

            PivotGridField fieldTS_VEKALET_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_VEKALET_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_VEKALET_TOPLAMI_DOVIZ_ID.AreaIndex = 168;
            fieldTS_VEKALET_TOPLAMI_DOVIZ_ID.FieldName = "TS_VEKALET_TOPLAMI_DOVIZ_ID";
            fieldTS_VEKALET_TOPLAMI_DOVIZ_ID.Name = "fieldTS_VEKALET_TOPLAMI_DOVIZ_ID";
            fieldTS_VEKALET_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_VEKALET_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_VEKALET_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_VEKALET_TOPLAMI.AreaIndex = 169;
            fieldTUM_VEKALET_TOPLAMI.FieldName = "TUM_VEKALET_TOPLAMI";
            fieldTUM_VEKALET_TOPLAMI.Name = "fieldTUM_VEKALET_TOPLAMI";
            fieldTUM_VEKALET_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID.AreaIndex = 170;
            fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID.FieldName = "TUM_VEKALET_TOPLAMI_DOVIZ_ID";
            fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID";
            fieldTUM_VEKALET_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldKARSI_VEKALET_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKARSI_VEKALET_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKARSI_VEKALET_TOPLAMI.AreaIndex = 171;
            fieldKARSI_VEKALET_TOPLAMI.FieldName = "KARSI_VEKALET_TOPLAMI";
            fieldKARSI_VEKALET_TOPLAMI.Name = "fieldKARSI_VEKALET_TOPLAMI";
            fieldKARSI_VEKALET_TOPLAMI.Visible = false;

            PivotGridField fieldKARSI_VEKALET_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKARSI_VEKALET_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKARSI_VEKALET_TOPLAMI_DOVIZ_ID.AreaIndex = 172;
            fieldKARSI_VEKALET_TOPLAMI_DOVIZ_ID.FieldName = "KARSI_VEKALET_TOPLAMI_DOVIZ_ID";
            fieldKARSI_VEKALET_TOPLAMI_DOVIZ_ID.Name = "fieldKARSI_VEKALET_TOPLAMI_DOVIZ_ID";
            fieldKARSI_VEKALET_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldFAIZ_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFAIZ_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFAIZ_TOPLAMI.AreaIndex = 173;
            fieldFAIZ_TOPLAMI.FieldName = "FAIZ_TOPLAMI";
            fieldFAIZ_TOPLAMI.Name = "fieldFAIZ_TOPLAMI";
            fieldFAIZ_TOPLAMI.Visible = false;

            PivotGridField fieldFAIZ_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFAIZ_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFAIZ_TOPLAMI_DOVIZ_ID.AreaIndex = 174;
            fieldFAIZ_TOPLAMI_DOVIZ_ID.FieldName = "FAIZ_TOPLAMI_DOVIZ_ID";
            fieldFAIZ_TOPLAMI_DOVIZ_ID.Name = "fieldFAIZ_TOPLAMI_DOVIZ_ID";
            fieldFAIZ_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldILAM_UCRETLER_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_UCRETLER_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_UCRETLER_TOPLAMI.AreaIndex = 175;
            fieldILAM_UCRETLER_TOPLAMI.FieldName = "ILAM_UCRETLER_TOPLAMI";
            fieldILAM_UCRETLER_TOPLAMI.Name = "fieldILAM_UCRETLER_TOPLAMI";
            fieldILAM_UCRETLER_TOPLAMI.Visible = false;

            PivotGridField fieldILAM_UCRETLER_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILAM_UCRETLER_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILAM_UCRETLER_TOPLAMI_DOVIZ_ID.AreaIndex = 176;
            fieldILAM_UCRETLER_TOPLAMI_DOVIZ_ID.FieldName = "ILAM_UCRETLER_TOPLAMI_DOVIZ_ID";
            fieldILAM_UCRETLER_TOPLAMI_DOVIZ_ID.Name = "fieldILAM_UCRETLER_TOPLAMI_DOVIZ_ID";
            fieldILAM_UCRETLER_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldIT_VEKALET_UCRETI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIT_VEKALET_UCRETI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIT_VEKALET_UCRETI.AreaIndex = 177;
            fieldIT_VEKALET_UCRETI.FieldName = "IT_VEKALET_UCRETI";
            fieldIT_VEKALET_UCRETI.Name = "fieldIT_VEKALET_UCRETI";
            fieldIT_VEKALET_UCRETI.Visible = false;

            PivotGridField fieldIT_VEKALET_UCRETI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIT_VEKALET_UCRETI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIT_VEKALET_UCRETI_DOVIZ_ID.AreaIndex = 178;
            fieldIT_VEKALET_UCRETI_DOVIZ_ID.FieldName = "IT_VEKALET_UCRETI_DOVIZ_ID";
            fieldIT_VEKALET_UCRETI_DOVIZ_ID.Name = "fieldIT_VEKALET_UCRETI_DOVIZ_ID";
            fieldIT_VEKALET_UCRETI_DOVIZ_ID.Visible = false;

            PivotGridField fieldIT_GIDERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIT_GIDERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIT_GIDERI.AreaIndex = 179;
            fieldIT_GIDERI.FieldName = "IT_GIDERI";
            fieldIT_GIDERI.Name = "fieldIT_GIDERI";
            fieldIT_GIDERI.Visible = false;

            PivotGridField fieldIT_GIDERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIT_GIDERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIT_GIDERI_DOVIZ_ID.AreaIndex = 180;
            fieldIT_GIDERI_DOVIZ_ID.FieldName = "IT_GIDERI_DOVIZ_ID";
            fieldIT_GIDERI_DOVIZ_ID.Name = "fieldIT_GIDERI_DOVIZ_ID";
            fieldIT_GIDERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_MAHSUP_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_MAHSUP_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_MAHSUP_TOPLAMI.AreaIndex = 181;
            fieldTO_ODEME_MAHSUP_TOPLAMI.FieldName = "TO_ODEME_MAHSUP_TOPLAMI";
            fieldTO_ODEME_MAHSUP_TOPLAMI.Name = "fieldTO_ODEME_MAHSUP_TOPLAMI";
            fieldTO_ODEME_MAHSUP_TOPLAMI.Visible = false;

            PivotGridField fieldTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID.AreaIndex = 182;
            fieldTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldPAYLASIM_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldPAYLASIM_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldPAYLASIM_TIPI.AreaIndex = 183;
            fieldPAYLASIM_TIPI.FieldName = "PAYLASIM_TIPI";
            fieldPAYLASIM_TIPI.Name = "fieldPAYLASIM_TIPI";
            fieldPAYLASIM_TIPI.Visible = false;

            PivotGridField fieldBASVURMA_HARCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBASVURMA_HARCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBASVURMA_HARCI.AreaIndex = 184;
            fieldBASVURMA_HARCI.FieldName = "BASVURMA_HARCI";
            fieldBASVURMA_HARCI.Name = "fieldBASVURMA_HARCI";
            fieldBASVURMA_HARCI.Visible = false;

            PivotGridField fieldBASVURMA_HARCI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBASVURMA_HARCI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBASVURMA_HARCI_DOVIZ_ID.AreaIndex = 185;
            fieldBASVURMA_HARCI_DOVIZ_ID.FieldName = "BASVURMA_HARCI_DOVIZ_ID";
            fieldBASVURMA_HARCI_DOVIZ_ID.Name = "fieldBASVURMA_HARCI_DOVIZ_ID";
            fieldBASVURMA_HARCI_DOVIZ_ID.Visible = false;

            PivotGridField fieldVEKALET_HARCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldVEKALET_HARCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldVEKALET_HARCI.AreaIndex = 186;
            fieldVEKALET_HARCI.FieldName = "VEKALET_HARCI";
            fieldVEKALET_HARCI.Name = "fieldVEKALET_HARCI";
            fieldVEKALET_HARCI.Visible = false;

            PivotGridField fieldVEKALET_HARCI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldVEKALET_HARCI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldVEKALET_HARCI_DOVIZ_ID.AreaIndex = 187;
            fieldVEKALET_HARCI_DOVIZ_ID.FieldName = "VEKALET_HARCI_DOVIZ_ID";
            fieldVEKALET_HARCI_DOVIZ_ID.Name = "fieldVEKALET_HARCI_DOVIZ_ID";
            fieldVEKALET_HARCI_DOVIZ_ID.Visible = false;

            PivotGridField fieldVEKALET_PULU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldVEKALET_PULU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldVEKALET_PULU.AreaIndex = 188;
            fieldVEKALET_PULU.FieldName = "VEKALET_PULU";
            fieldVEKALET_PULU.Name = "fieldVEKALET_PULU";
            fieldVEKALET_PULU.Visible = false;

            PivotGridField fieldVEKALET_PULU_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldVEKALET_PULU_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldVEKALET_PULU_DOVIZ_ID.AreaIndex = 189;
            fieldVEKALET_PULU_DOVIZ_ID.FieldName = "VEKALET_PULU_DOVIZ_ID";
            fieldVEKALET_PULU_DOVIZ_ID.Name = "fieldVEKALET_PULU_DOVIZ_ID";
            fieldVEKALET_PULU_DOVIZ_ID.Visible = false;

            PivotGridField fieldIFLAS_BASVURMA_HARCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIFLAS_BASVURMA_HARCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIFLAS_BASVURMA_HARCI.AreaIndex = 190;
            fieldIFLAS_BASVURMA_HARCI.FieldName = "IFLAS_BASVURMA_HARCI";
            fieldIFLAS_BASVURMA_HARCI.Name = "fieldIFLAS_BASVURMA_HARCI";
            fieldIFLAS_BASVURMA_HARCI.Visible = false;

            PivotGridField fieldIFLAS_BASVURMA_HARCI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIFLAS_BASVURMA_HARCI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIFLAS_BASVURMA_HARCI_DOVIZ_ID.AreaIndex = 191;
            fieldIFLAS_BASVURMA_HARCI_DOVIZ_ID.FieldName = "IFLAS_BASVURMA_HARCI_DOVIZ_ID";
            fieldIFLAS_BASVURMA_HARCI_DOVIZ_ID.Name = "fieldIFLAS_BASVURMA_HARCI_DOVIZ_ID";
            fieldIFLAS_BASVURMA_HARCI_DOVIZ_ID.Visible = false;

            PivotGridField fieldIFLASIN_ACILMASI_HARCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIFLASIN_ACILMASI_HARCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIFLASIN_ACILMASI_HARCI.AreaIndex = 192;
            fieldIFLASIN_ACILMASI_HARCI.FieldName = "IFLASIN_ACILMASI_HARCI";
            fieldIFLASIN_ACILMASI_HARCI.Name = "fieldIFLASIN_ACILMASI_HARCI";
            fieldIFLASIN_ACILMASI_HARCI.Visible = false;

            PivotGridField fieldIFLASIN_ACILMASI_HARCI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIFLASIN_ACILMASI_HARCI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIFLASIN_ACILMASI_HARCI_DOVIZ_ID.AreaIndex = 193;
            fieldIFLASIN_ACILMASI_HARCI_DOVIZ_ID.FieldName = "IFLASIN_ACILMASI_HARCI_DOVIZ_ID";
            fieldIFLASIN_ACILMASI_HARCI_DOVIZ_ID.Name = "fieldIFLASIN_ACILMASI_HARCI_DOVIZ_ID";
            fieldIFLASIN_ACILMASI_HARCI_DOVIZ_ID.Visible = false;

            PivotGridField fieldILK_TEBLIGAT_GIDERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILK_TEBLIGAT_GIDERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILK_TEBLIGAT_GIDERI.AreaIndex = 194;
            fieldILK_TEBLIGAT_GIDERI.FieldName = "ILK_TEBLIGAT_GIDERI";
            fieldILK_TEBLIGAT_GIDERI.Name = "fieldILK_TEBLIGAT_GIDERI";
            fieldILK_TEBLIGAT_GIDERI.Visible = false;

            PivotGridField fieldILK_TEBLIGAT_GIDERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldILK_TEBLIGAT_GIDERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldILK_TEBLIGAT_GIDERI_DOVIZ_ID.AreaIndex = 195;
            fieldILK_TEBLIGAT_GIDERI_DOVIZ_ID.FieldName = "ILK_TEBLIGAT_GIDERI_DOVIZ_ID";
            fieldILK_TEBLIGAT_GIDERI_DOVIZ_ID.Name = "fieldILK_TEBLIGAT_GIDERI_DOVIZ_ID";
            fieldILK_TEBLIGAT_GIDERI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTAHLIYE_HARCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHLIYE_HARCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHLIYE_HARCI.AreaIndex = 196;
            fieldTAHLIYE_HARCI.FieldName = "TAHLIYE_HARCI";
            fieldTAHLIYE_HARCI.Name = "fieldTAHLIYE_HARCI";
            fieldTAHLIYE_HARCI.Visible = false;

            PivotGridField fieldTAHLIYE_HARCI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHLIYE_HARCI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHLIYE_HARCI_DOVIZ_ID.AreaIndex = 197;
            fieldTAHLIYE_HARCI_DOVIZ_ID.FieldName = "TAHLIYE_HARCI_DOVIZ_ID";
            fieldTAHLIYE_HARCI_DOVIZ_ID.Name = "fieldTAHLIYE_HARCI_DOVIZ_ID";
            fieldTAHLIYE_HARCI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTESLIM_HARCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTESLIM_HARCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTESLIM_HARCI.AreaIndex = 198;
            fieldTESLIM_HARCI.FieldName = "TESLIM_HARCI";
            fieldTESLIM_HARCI.Name = "fieldTESLIM_HARCI";
            fieldTESLIM_HARCI.Visible = false;

            PivotGridField fieldTESLIM_HARCI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTESLIM_HARCI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTESLIM_HARCI_DOVIZ_ID.AreaIndex = 199;
            fieldTESLIM_HARCI_DOVIZ_ID.FieldName = "TESLIM_HARCI_DOVIZ_ID";
            fieldTESLIM_HARCI_DOVIZ_ID.Name = "fieldTESLIM_HARCI_DOVIZ_ID";
            fieldTESLIM_HARCI_DOVIZ_ID.Visible = false;

            PivotGridField fieldFERAGAT_HARCI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFERAGAT_HARCI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFERAGAT_HARCI.AreaIndex = 200;
            fieldFERAGAT_HARCI.FieldName = "FERAGAT_HARCI";
            fieldFERAGAT_HARCI.Name = "fieldFERAGAT_HARCI";
            fieldFERAGAT_HARCI.Visible = false;

            PivotGridField fieldFERAGAT_HARCI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFERAGAT_HARCI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFERAGAT_HARCI_DOVIZ_ID.AreaIndex = 201;
            fieldFERAGAT_HARCI_DOVIZ_ID.FieldName = "FERAGAT_HARCI_DOVIZ_ID";
            fieldFERAGAT_HARCI_DOVIZ_ID.Name = "fieldFERAGAT_HARCI_DOVIZ_ID";
            fieldFERAGAT_HARCI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_YONETIMG_TAZMINATI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_YONETIMG_TAZMINATI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_YONETIMG_TAZMINATI.AreaIndex = 202;
            fieldTO_YONETIMG_TAZMINATI.FieldName = "TO_YONETIMG_TAZMINATI";
            fieldTO_YONETIMG_TAZMINATI.Name = "fieldTO_YONETIMG_TAZMINATI";
            fieldTO_YONETIMG_TAZMINATI.Visible = false;

            PivotGridField fieldTO_YONETIMG_TAZMINATI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_YONETIMG_TAZMINATI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_YONETIMG_TAZMINATI_DOVIZ_ID.AreaIndex = 203;
            fieldTO_YONETIMG_TAZMINATI_DOVIZ_ID.FieldName = "TO_YONETIMG_TAZMINATI_DOVIZ_ID";
            fieldTO_YONETIMG_TAZMINATI_DOVIZ_ID.Name = "fieldTO_YONETIMG_TAZMINATI_DOVIZ_ID";
            fieldTO_YONETIMG_TAZMINATI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_HESAP_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_HESAP_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_HESAP_TIP.AreaIndex = 204;
            fieldTS_HESAP_TIP.FieldName = "TS_HESAP_TIP";
            fieldTS_HESAP_TIP.Name = "fieldTS_HESAP_TIP";
            fieldTS_HESAP_TIP.Visible = false;

            PivotGridField fieldTO_HESAP_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_HESAP_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_HESAP_TIP.AreaIndex = 205;
            fieldTO_HESAP_TIP.FieldName = "TO_HESAP_TIP";
            fieldTO_HESAP_TIP.Name = "fieldTO_HESAP_TIP";
            fieldTO_HESAP_TIP.Visible = false;

            PivotGridField fieldASAMA_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASAMA_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASAMA_ADI.AreaIndex = 206;
            fieldASAMA_ADI.FieldName = "ASAMA_ADI";
            fieldASAMA_ADI.Name = "fieldASAMA_ADI";
            fieldASAMA_ADI.Visible = false;

            PivotGridField fieldBANKA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA.AreaIndex = 207;
            fieldBANKA.FieldName = "BANKA";
            fieldBANKA.Name = "fieldBANKA";
            fieldBANKA.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 208;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldFOY_BIRIM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_BIRIM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_BIRIM.AreaIndex = 209;
            fieldFOY_BIRIM.FieldName = "FOY_BIRIM";
            fieldFOY_BIRIM.Name = "fieldFOY_BIRIM";
            fieldFOY_BIRIM.Visible = false;

            PivotGridField fieldFOY_YERI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_YERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_YERI.AreaIndex = 210;
            fieldFOY_YERI.FieldName = "FOY_YERI";
            fieldFOY_YERI.Name = "fieldFOY_YERI";
            fieldFOY_YERI.Visible = false;

            PivotGridField fieldTAHSILAT_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAHSILAT_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAHSILAT_DURUM.AreaIndex = 211;
            fieldTAHSILAT_DURUM.FieldName = "TAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Name = "fieldTAHSILAT_DURUM";
            fieldTAHSILAT_DURUM.Visible = false;

            PivotGridField fieldFOY_OZEL_DURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_OZEL_DURUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_OZEL_DURUM.AreaIndex = 212;
            fieldFOY_OZEL_DURUM.FieldName = "FOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Name = "fieldFOY_OZEL_DURUM";
            fieldFOY_OZEL_DURUM.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 213;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 214;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldKLASOR_1 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_1.AreaIndex = 215;
            fieldKLASOR_1.FieldName = "KLASOR_1";
            fieldKLASOR_1.Name = "fieldKLASOR_1";
            fieldKLASOR_1.Visible = false;

            PivotGridField fieldKLASOR_2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKLASOR_2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKLASOR_2.AreaIndex = 216;
            fieldKLASOR_2.FieldName = "KLASOR_2";
            fieldKLASOR_2.Name = "fieldKLASOR_2";
            fieldKLASOR_2.Visible = false;

            PivotGridField fieldICRA_FOY_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldICRA_FOY_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldICRA_FOY_ID.AreaIndex = 217;
            fieldICRA_FOY_ID.FieldName = "ICRA_FOY_ID";
            fieldICRA_FOY_ID.Name = "fieldICRA_FOY_ID";
            fieldICRA_FOY_ID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldICRA_FOY_ID.Caption = "Dosya Sayisi";
            fieldICRA_FOY_ID.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 218;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 219;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = dizi = new PivotGridField[]
            {
                fieldSORUMLU,
                fieldIZLEYEN,
                fieldDURUM,
                fieldBANKA_SUBE,
                fieldKREDI_GRUP,
			    fieldKREDI_TIP,
                fieldSUBE_KOD_ID,
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			    fieldFOY_ARSIV_TARIHI,
			    fieldFOY_INFAZ_TARIHI,
			    fieldTAKIBIN_MUVEKKILE_IADE_TARIHI,
                fieldID,
            };
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            return dizi;
        }

        private PivotGridField[] DosyalarinDurumlarinaGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.AreaIndex = 4;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldTAKIP_TARIHI.Visible = true;
            PivotGridField fieldTAKIP_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI2.AreaIndex = 4;
            fieldTAKIP_TARIHI2.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI2.Name = "fieldTAKIP_TARIHI2";
            fieldTAKIP_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldTAKIP_TARIHI2.Visible = true;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 8;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 9;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 10;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldTAKIP_CIKISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.AreaIndex = 13;
            fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";
            fieldTAKIP_CIKISI.Visible = true;

            PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI_DOVIZ_ID.AreaIndex = 14;
            fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 19;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI.AreaIndex = 20;
            fieldTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Name = "fieldTO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 21;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 22;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldRISK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI.AreaIndex = 25;
            fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";
            fieldRISK_MIKTARI.Visible = false;

            PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 26;
            fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 29;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.AreaIndex = 31;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 34;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 35;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDURUM.AreaIndex = 40;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = true;

            PivotGridField fieldFOY_ARSIV_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_ARSIV_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_ARSIV_TARIHI.AreaIndex = 47;
            fieldFOY_ARSIV_TARIHI.FieldName = "FOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Name = "fieldFOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Visible = false;

            PivotGridField fieldFOY_INFAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_INFAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_INFAZ_TARIHI.AreaIndex = 48;
            fieldFOY_INFAZ_TARIHI.FieldName = "FOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Name = "fieldFOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Visible = false;

            PivotGridField fieldTAKIBIN_MUVEKKILE_IADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.AreaIndex = 49;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.FieldName = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Name = "fieldTAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI.AreaIndex = 157;
            fieldTO_MASRAF_TOPLAMI.FieldName = "TO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Name = "fieldTO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 158;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI.AreaIndex = 159;
            fieldTS_MASRAF_TOPLAMI.FieldName = "TS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Name = "fieldTS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 160;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI.AreaIndex = 161;
            fieldTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Name = "fieldTUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 162;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 208;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 213;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 214;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = dizi = new PivotGridField[]
            {
                fieldRISK_MIKTARI,
                fieldRISK_MIKTARI_DOVIZ_ID,
                fieldTUM_MASRAF_TOPLAMI,
                fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTS_MASRAF_TOPLAMI,
                fieldTS_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_MASRAF_TOPLAMI,
                fieldTO_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_ODEME_TOPLAMI,
                fieldTO_ODEME_TOPLAMI_DOVIZ_ID,
                fieldKALAN,
                fieldKALAN_DOVIZ_ID,
                fieldTAKIP_CIKISI,
                fieldTAKIP_CIKISI_DOVIZ_ID,
                fieldASIL_ALACAK,
			    fieldASIL_ALACAK_DOVIZ_ID,
                fieldSORUMLU,
                fieldIZLEYEN,
                fieldDURUM,
                fieldBANKA_SUBE,
                fieldKREDI_GRUP,
			    fieldKREDI_TIP,
                fieldSUBE_KOD_ID,
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			    fieldFOY_ARSIV_TARIHI,
			    fieldFOY_INFAZ_TARIHI,
			    fieldTAKIBIN_MUVEKKILE_IADE_TARIHI,
                fieldID,
                fieldTAKIP_TARIHI,
            };
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            return dizi;
        }

        private PivotGridField[] IcraDosyalarininBurolaraGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.AreaIndex = 4;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldTAKIP_TARIHI.Visible = true;
            PivotGridField fieldTAKIP_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI2.AreaIndex = 4;
            fieldTAKIP_TARIHI2.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI2.Name = "fieldTAKIP_TARIHI2";
            fieldTAKIP_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldTAKIP_TARIHI2.Visible = true;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 8;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 9;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 10;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldTAKIP_CIKISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.AreaIndex = 13;
            fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";
            fieldTAKIP_CIKISI.Visible = true;

            PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI_DOVIZ_ID.AreaIndex = 14;
            fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 19;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI.AreaIndex = 20;
            fieldTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Name = "fieldTO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 21;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 22;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldRISK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI.AreaIndex = 25;
            fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";
            fieldRISK_MIKTARI.Visible = false;

            PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 26;
            fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 29;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = true;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.AreaIndex = 31;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 34;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 35;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDURUM.AreaIndex = 40;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = true;

            PivotGridField fieldFOY_ARSIV_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_ARSIV_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_ARSIV_TARIHI.AreaIndex = 47;
            fieldFOY_ARSIV_TARIHI.FieldName = "FOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Name = "fieldFOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Visible = false;

            PivotGridField fieldFOY_INFAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_INFAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_INFAZ_TARIHI.AreaIndex = 48;
            fieldFOY_INFAZ_TARIHI.FieldName = "FOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Name = "fieldFOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Visible = false;

            PivotGridField fieldTAKIBIN_MUVEKKILE_IADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.AreaIndex = 49;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.FieldName = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Name = "fieldTAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI.AreaIndex = 157;
            fieldTO_MASRAF_TOPLAMI.FieldName = "TO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Name = "fieldTO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 158;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI.AreaIndex = 159;
            fieldTS_MASRAF_TOPLAMI.FieldName = "TS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Name = "fieldTS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 160;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI.AreaIndex = 161;
            fieldTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Name = "fieldTUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 162;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 208;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 213;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 214;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 219;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldFORM_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFORM_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFORM_TIPI.AreaIndex = 39;
            fieldFORM_TIPI.FieldName = "FORM_TIPI";
            fieldFORM_TIPI.Name = "fieldFORM_TIPI";
            fieldFORM_TIPI.Visible = false;

            PivotGridField fieldTALEP_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALEP_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALEP_ADI.AreaIndex = 38;
            fieldTALEP_ADI.FieldName = "TALEP_ADI";
            fieldTALEP_ADI.Name = "fieldTALEP_ADI";
            fieldTALEP_ADI.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = dizi = new PivotGridField[]
            {
                fieldRISK_MIKTARI,
                fieldRISK_MIKTARI_DOVIZ_ID,
                fieldTUM_MASRAF_TOPLAMI,
                fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTS_MASRAF_TOPLAMI,
                fieldTS_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_MASRAF_TOPLAMI,
                fieldTO_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_ODEME_TOPLAMI,
                fieldTO_ODEME_TOPLAMI_DOVIZ_ID,
                fieldKALAN,
                fieldKALAN_DOVIZ_ID,
                fieldTAKIP_CIKISI,
                fieldTAKIP_CIKISI_DOVIZ_ID,
                fieldASIL_ALACAK,
			    fieldASIL_ALACAK_DOVIZ_ID,
                fieldSORUMLU,
                fieldIZLEYEN,
                fieldTALEP_ADI,
                fieldBANKA_SUBE,
                fieldKREDI_GRUP,
			    fieldKREDI_TIP,
                fieldSUBE_KOD_ID,
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			    fieldFOY_ARSIV_TARIHI,
			    fieldFOY_INFAZ_TARIHI,
			    fieldTAKIBIN_MUVEKKILE_IADE_TARIHI,
                fieldID,
                fieldTAKIP_TARIHI,
            };
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            return dizi;
        }

        private PivotGridField[] IcraDosyalarininFormTipineGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.AreaIndex = 4;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldTAKIP_TARIHI.Visible = true;
            PivotGridField fieldTAKIP_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI2.AreaIndex = 4;
            fieldTAKIP_TARIHI2.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI2.Name = "fieldTAKIP_TARIHI2";
            fieldTAKIP_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldTAKIP_TARIHI2.Visible = true;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 8;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 9;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 10;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldTAKIP_CIKISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.AreaIndex = 13;
            fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";
            fieldTAKIP_CIKISI.Visible = true;

            PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI_DOVIZ_ID.AreaIndex = 14;
            fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 19;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI.AreaIndex = 20;
            fieldTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Name = "fieldTO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 21;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 22;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldRISK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI.AreaIndex = 25;
            fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";
            fieldRISK_MIKTARI.Visible = false;

            PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 26;
            fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 29;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.AreaIndex = 31;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 34;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 35;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDURUM.AreaIndex = 40;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = true;

            PivotGridField fieldFOY_ARSIV_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_ARSIV_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_ARSIV_TARIHI.AreaIndex = 47;
            fieldFOY_ARSIV_TARIHI.FieldName = "FOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Name = "fieldFOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Visible = false;

            PivotGridField fieldFOY_INFAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_INFAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_INFAZ_TARIHI.AreaIndex = 48;
            fieldFOY_INFAZ_TARIHI.FieldName = "FOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Name = "fieldFOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Visible = false;

            PivotGridField fieldTAKIBIN_MUVEKKILE_IADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.AreaIndex = 49;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.FieldName = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Name = "fieldTAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI.AreaIndex = 157;
            fieldTO_MASRAF_TOPLAMI.FieldName = "TO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Name = "fieldTO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 158;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI.AreaIndex = 159;
            fieldTS_MASRAF_TOPLAMI.FieldName = "TS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Name = "fieldTS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 160;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI.AreaIndex = 161;
            fieldTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Name = "fieldTUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 162;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 208;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 213;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 214;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 219;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldFORM_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFORM_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFORM_TIPI.AreaIndex = 39;
            fieldFORM_TIPI.FieldName = "FORM_TIPI";
            fieldFORM_TIPI.Name = "fieldFORM_TIPI";
            fieldFORM_TIPI.Visible = true;

            #endregion Field & Properties

            PivotGridField[] dizi = dizi = new PivotGridField[]
            {
                fieldRISK_MIKTARI,
                fieldRISK_MIKTARI_DOVIZ_ID,
                fieldTUM_MASRAF_TOPLAMI,
                fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTS_MASRAF_TOPLAMI,
                fieldTS_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_MASRAF_TOPLAMI,
                fieldTO_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_ODEME_TOPLAMI,
                fieldTO_ODEME_TOPLAMI_DOVIZ_ID,
                fieldKALAN,
                fieldKALAN_DOVIZ_ID,
                fieldTAKIP_CIKISI,
                fieldTAKIP_CIKISI_DOVIZ_ID,
                fieldASIL_ALACAK,
			    fieldASIL_ALACAK_DOVIZ_ID,
                fieldSORUMLU,
                fieldIZLEYEN,
                fieldFORM_TIPI,
                fieldBANKA_SUBE,
                fieldKREDI_GRUP,
			    fieldKREDI_TIP,
                fieldSUBE_KOD_ID,
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			    fieldFOY_ARSIV_TARIHI,
			    fieldFOY_INFAZ_TARIHI,
			    fieldTAKIBIN_MUVEKKILE_IADE_TARIHI,
                fieldID,
                fieldTAKIP_TARIHI,
            };
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldFORM_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            return dizi;
        }

        private PivotGridField[] IcraDosyalarininIcraTaleplerineGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.AreaIndex = 4;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldTAKIP_TARIHI.Visible = true;
            PivotGridField fieldTAKIP_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI2.AreaIndex = 4;
            fieldTAKIP_TARIHI2.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI2.Name = "fieldTAKIP_TARIHI2";
            fieldTAKIP_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldTAKIP_TARIHI2.Visible = true;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 8;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 9;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 10;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldTAKIP_CIKISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.AreaIndex = 13;
            fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";
            fieldTAKIP_CIKISI.Visible = true;

            PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI_DOVIZ_ID.AreaIndex = 14;
            fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 19;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI.AreaIndex = 20;
            fieldTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Name = "fieldTO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 21;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 22;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldRISK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI.AreaIndex = 25;
            fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";
            fieldRISK_MIKTARI.Visible = false;

            PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 26;
            fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 29;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.AreaIndex = 31;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 34;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 35;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDURUM.AreaIndex = 40;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = true;

            PivotGridField fieldFOY_ARSIV_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_ARSIV_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_ARSIV_TARIHI.AreaIndex = 47;
            fieldFOY_ARSIV_TARIHI.FieldName = "FOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Name = "fieldFOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Visible = false;

            PivotGridField fieldFOY_INFAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_INFAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_INFAZ_TARIHI.AreaIndex = 48;
            fieldFOY_INFAZ_TARIHI.FieldName = "FOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Name = "fieldFOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Visible = false;

            PivotGridField fieldTAKIBIN_MUVEKKILE_IADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.AreaIndex = 49;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.FieldName = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Name = "fieldTAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI.AreaIndex = 157;
            fieldTO_MASRAF_TOPLAMI.FieldName = "TO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Name = "fieldTO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 158;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI.AreaIndex = 159;
            fieldTS_MASRAF_TOPLAMI.FieldName = "TS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Name = "fieldTS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 160;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI.AreaIndex = 161;
            fieldTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Name = "fieldTUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 162;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 208;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 213;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 214;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 219;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldFORM_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFORM_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFORM_TIPI.AreaIndex = 39;
            fieldFORM_TIPI.FieldName = "FORM_TIPI";
            fieldFORM_TIPI.Name = "fieldFORM_TIPI";
            fieldFORM_TIPI.Visible = false;

            PivotGridField fieldTALEP_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALEP_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALEP_ADI.AreaIndex = 38;
            fieldTALEP_ADI.FieldName = "TALEP_ADI";
            fieldTALEP_ADI.Name = "fieldTALEP_ADI";
            fieldTALEP_ADI.Visible = true;

            #endregion Field & Properties

            PivotGridField[] dizi = dizi = new PivotGridField[]
            {
                fieldRISK_MIKTARI,
                fieldRISK_MIKTARI_DOVIZ_ID,
                fieldTUM_MASRAF_TOPLAMI,
                fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTS_MASRAF_TOPLAMI,
                fieldTS_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_MASRAF_TOPLAMI,
                fieldTO_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_ODEME_TOPLAMI,
                fieldTO_ODEME_TOPLAMI_DOVIZ_ID,
                fieldKALAN,
                fieldKALAN_DOVIZ_ID,
                fieldTAKIP_CIKISI,
                fieldTAKIP_CIKISI_DOVIZ_ID,
                fieldASIL_ALACAK,
			    fieldASIL_ALACAK_DOVIZ_ID,
                fieldSORUMLU,
                fieldIZLEYEN,
                fieldTALEP_ADI,
                fieldBANKA_SUBE,
                fieldKREDI_GRUP,
			    fieldKREDI_TIP,
                fieldSUBE_KOD_ID,
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			    fieldFOY_ARSIV_TARIHI,
			    fieldFOY_INFAZ_TARIHI,
			    fieldTAKIBIN_MUVEKKILE_IADE_TARIHI,
                fieldID,
                fieldTAKIP_TARIHI,
            };
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldTALEP_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            return dizi;
        }

        private PivotGridField[] IcraDosylarininBolgelereGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.AreaIndex = 4;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldTAKIP_TARIHI.Visible = true;
            PivotGridField fieldTAKIP_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI2.AreaIndex = 4;
            fieldTAKIP_TARIHI2.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI2.Name = "fieldTAKIP_TARIHI2";
            fieldTAKIP_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldTAKIP_TARIHI2.Visible = true;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 8;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 9;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 10;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldTAKIP_CIKISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.AreaIndex = 13;
            fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";
            fieldTAKIP_CIKISI.Visible = true;

            PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI_DOVIZ_ID.AreaIndex = 14;
            fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 19;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI.AreaIndex = 20;
            fieldTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Name = "fieldTO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 21;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 22;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldRISK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI.AreaIndex = 25;
            fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";
            fieldRISK_MIKTARI.Visible = false;

            PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 26;
            fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 29;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.AreaIndex = 31;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 34;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 35;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDURUM.AreaIndex = 40;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldFOY_ARSIV_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_ARSIV_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_ARSIV_TARIHI.AreaIndex = 47;
            fieldFOY_ARSIV_TARIHI.FieldName = "FOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Name = "fieldFOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Visible = false;

            PivotGridField fieldFOY_INFAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_INFAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_INFAZ_TARIHI.AreaIndex = 48;
            fieldFOY_INFAZ_TARIHI.FieldName = "FOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Name = "fieldFOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Visible = false;

            PivotGridField fieldTAKIBIN_MUVEKKILE_IADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.AreaIndex = 49;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.FieldName = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Name = "fieldTAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI.AreaIndex = 157;
            fieldTO_MASRAF_TOPLAMI.FieldName = "TO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Name = "fieldTO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 158;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI.AreaIndex = 159;
            fieldTS_MASRAF_TOPLAMI.FieldName = "TS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Name = "fieldTS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 160;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI.AreaIndex = 161;
            fieldTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Name = "fieldTUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 162;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 208;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 213;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 214;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 219;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldFORM_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFORM_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFORM_TIPI.AreaIndex = 39;
            fieldFORM_TIPI.FieldName = "FORM_TIPI";
            fieldFORM_TIPI.Name = "fieldFORM_TIPI";
            fieldFORM_TIPI.Visible = false;

            PivotGridField fieldTALEP_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALEP_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALEP_ADI.AreaIndex = 38;
            fieldTALEP_ADI.FieldName = "TALEP_ADI";
            fieldTALEP_ADI.Name = "fieldTALEP_ADI";
            fieldTALEP_ADI.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 218;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = true;

            #endregion Field & Properties

            PivotGridField[] dizi = dizi = new PivotGridField[]
            {
                fieldRISK_MIKTARI,
                fieldRISK_MIKTARI_DOVIZ_ID,
                fieldTUM_MASRAF_TOPLAMI,
                fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTS_MASRAF_TOPLAMI,
                fieldTS_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_MASRAF_TOPLAMI,
                fieldTO_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_ODEME_TOPLAMI,
                fieldTO_ODEME_TOPLAMI_DOVIZ_ID,
                fieldKALAN,
                fieldKALAN_DOVIZ_ID,
                fieldTAKIP_CIKISI,
                fieldTAKIP_CIKISI_DOVIZ_ID,
                fieldASIL_ALACAK,
			    fieldASIL_ALACAK_DOVIZ_ID,
                fieldSORUMLU,
                fieldIZLEYEN,
                fieldTALEP_ADI,
                fieldBANKA_SUBE,
                fieldKREDI_GRUP,
			    fieldKREDI_TIP,
                fieldBOLGE,
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			    fieldFOY_ARSIV_TARIHI,
			    fieldFOY_INFAZ_TARIHI,
			    fieldTAKIBIN_MUVEKKILE_IADE_TARIHI,
                fieldID,
                fieldTAKIP_TARIHI,
            };
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            return dizi;
        }

        private PivotGridField[] IcraDosylarininBolumlerineGore()
        {
            #region Field & Properties

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.AreaIndex = 4;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldTAKIP_TARIHI.Visible = true;
            PivotGridField fieldTAKIP_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI2.AreaIndex = 4;
            fieldTAKIP_TARIHI2.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI2.Name = "fieldTAKIP_TARIHI2";
            fieldTAKIP_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldTAKIP_TARIHI2.Visible = true;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 8;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 9;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 10;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldTAKIP_CIKISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.AreaIndex = 13;
            fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";
            fieldTAKIP_CIKISI.Visible = true;

            PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI_DOVIZ_ID.AreaIndex = 14;
            fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 19;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI.AreaIndex = 20;
            fieldTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Name = "fieldTO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 21;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 22;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldRISK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI.AreaIndex = 25;
            fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";
            fieldRISK_MIKTARI.Visible = false;

            PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 26;
            fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 29;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.AreaIndex = 31;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 34;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 35;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDURUM.AreaIndex = 40;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = true;

            PivotGridField fieldFOY_ARSIV_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_ARSIV_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_ARSIV_TARIHI.AreaIndex = 47;
            fieldFOY_ARSIV_TARIHI.FieldName = "FOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Name = "fieldFOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Visible = false;

            PivotGridField fieldFOY_INFAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_INFAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_INFAZ_TARIHI.AreaIndex = 48;
            fieldFOY_INFAZ_TARIHI.FieldName = "FOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Name = "fieldFOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Visible = false;

            PivotGridField fieldTAKIBIN_MUVEKKILE_IADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.AreaIndex = 49;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.FieldName = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Name = "fieldTAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI.AreaIndex = 157;
            fieldTO_MASRAF_TOPLAMI.FieldName = "TO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Name = "fieldTO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 158;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI.AreaIndex = 159;
            fieldTS_MASRAF_TOPLAMI.FieldName = "TS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Name = "fieldTS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 160;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI.AreaIndex = 161;
            fieldTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Name = "fieldTUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 162;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 208;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 213;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 214;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 219;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = true;

            #endregion Field & Properties

            PivotGridField[] dizi = dizi = new PivotGridField[]
            {
                fieldRISK_MIKTARI,
                fieldRISK_MIKTARI_DOVIZ_ID,
                fieldTUM_MASRAF_TOPLAMI,
                fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTS_MASRAF_TOPLAMI,
                fieldTS_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_MASRAF_TOPLAMI,
                fieldTO_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_ODEME_TOPLAMI,
                fieldTO_ODEME_TOPLAMI_DOVIZ_ID,
                fieldKALAN,
                fieldKALAN_DOVIZ_ID,
                fieldTAKIP_CIKISI,
                fieldTAKIP_CIKISI_DOVIZ_ID,
                fieldASIL_ALACAK,
			    fieldASIL_ALACAK_DOVIZ_ID,
                fieldSORUMLU,
                fieldIZLEYEN,
                fieldBOLUM,
                fieldBANKA_SUBE,
                fieldKREDI_GRUP,
			    fieldKREDI_TIP,
                fieldSUBE_KOD_ID,
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			    fieldFOY_ARSIV_TARIHI,
			    fieldFOY_INFAZ_TARIHI,
			    fieldTAKIBIN_MUVEKKILE_IADE_TARIHI,
                fieldID,
                fieldTAKIP_TARIHI,
            };
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            return dizi;
        }

        private PivotGridField[] IcraDosylarininDurumlarinaGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.AreaIndex = 4;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldTAKIP_TARIHI.Visible = true;
            PivotGridField fieldTAKIP_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI2.AreaIndex = 4;
            fieldTAKIP_TARIHI2.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI2.Name = "fieldTAKIP_TARIHI2";
            fieldTAKIP_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldTAKIP_TARIHI2.Visible = true;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 8;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 9;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 10;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldTAKIP_CIKISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.AreaIndex = 13;
            fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";
            fieldTAKIP_CIKISI.Visible = true;

            PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI_DOVIZ_ID.AreaIndex = 14;
            fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 19;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI.AreaIndex = 20;
            fieldTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Name = "fieldTO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 21;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 22;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldRISK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI.AreaIndex = 25;
            fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";
            fieldRISK_MIKTARI.Visible = false;

            PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 26;
            fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 29;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.AreaIndex = 31;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 34;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 35;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDURUM.AreaIndex = 40;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = true;

            PivotGridField fieldFOY_ARSIV_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_ARSIV_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_ARSIV_TARIHI.AreaIndex = 47;
            fieldFOY_ARSIV_TARIHI.FieldName = "FOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Name = "fieldFOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Visible = false;

            PivotGridField fieldFOY_INFAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_INFAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_INFAZ_TARIHI.AreaIndex = 48;
            fieldFOY_INFAZ_TARIHI.FieldName = "FOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Name = "fieldFOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Visible = false;

            PivotGridField fieldTAKIBIN_MUVEKKILE_IADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.AreaIndex = 49;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.FieldName = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Name = "fieldTAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI.AreaIndex = 157;
            fieldTO_MASRAF_TOPLAMI.FieldName = "TO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Name = "fieldTO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 158;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI.AreaIndex = 159;
            fieldTS_MASRAF_TOPLAMI.FieldName = "TS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Name = "fieldTS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 160;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI.AreaIndex = 161;
            fieldTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Name = "fieldTUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 162;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 208;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 213;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 214;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 219;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldFORM_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFORM_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFORM_TIPI.AreaIndex = 39;
            fieldFORM_TIPI.FieldName = "FORM_TIPI";
            fieldFORM_TIPI.Name = "fieldFORM_TIPI";
            fieldFORM_TIPI.Visible = false;

            PivotGridField fieldTALEP_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALEP_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALEP_ADI.AreaIndex = 38;
            fieldTALEP_ADI.FieldName = "TALEP_ADI";
            fieldTALEP_ADI.Name = "fieldTALEP_ADI";
            fieldTALEP_ADI.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = dizi = new PivotGridField[]
            {
                fieldRISK_MIKTARI,
                fieldRISK_MIKTARI_DOVIZ_ID,
                fieldTUM_MASRAF_TOPLAMI,
                fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTS_MASRAF_TOPLAMI,
                fieldTS_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_MASRAF_TOPLAMI,
                fieldTO_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_ODEME_TOPLAMI,
                fieldTO_ODEME_TOPLAMI_DOVIZ_ID,
                fieldKALAN,
                fieldKALAN_DOVIZ_ID,
                fieldTAKIP_CIKISI,
                fieldTAKIP_CIKISI_DOVIZ_ID,
                fieldASIL_ALACAK,
			    fieldASIL_ALACAK_DOVIZ_ID,
                fieldSORUMLU,
                fieldIZLEYEN,
                fieldTALEP_ADI,
                fieldBANKA_SUBE,
                fieldKREDI_GRUP,
			    fieldKREDI_TIP,
                fieldDURUM,
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			    fieldFOY_ARSIV_TARIHI,
			    fieldFOY_INFAZ_TARIHI,
			    fieldTAKIBIN_MUVEKKILE_IADE_TARIHI,
                fieldID,
                fieldTAKIP_TARIHI,
            };
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            return dizi;
        }

        private PivotGridField[] IcraDosylarininIzleyenAvukatlaraGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.AreaIndex = 4;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldTAKIP_TARIHI.Visible = true;
            PivotGridField fieldTAKIP_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI2.AreaIndex = 4;
            fieldTAKIP_TARIHI2.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI2.Name = "fieldTAKIP_TARIHI2";
            fieldTAKIP_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldTAKIP_TARIHI2.Visible = true;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 8;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 9;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 10;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldTAKIP_CIKISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.AreaIndex = 13;
            fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";
            fieldTAKIP_CIKISI.Visible = true;

            PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI_DOVIZ_ID.AreaIndex = 14;
            fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 19;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI.AreaIndex = 20;
            fieldTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Name = "fieldTO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 21;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 22;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldRISK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI.AreaIndex = 25;
            fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";
            fieldRISK_MIKTARI.Visible = false;

            PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 26;
            fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 29;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.AreaIndex = 31;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 34;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = true;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 35;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDURUM.AreaIndex = 40;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = true;

            PivotGridField fieldFOY_ARSIV_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_ARSIV_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_ARSIV_TARIHI.AreaIndex = 47;
            fieldFOY_ARSIV_TARIHI.FieldName = "FOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Name = "fieldFOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Visible = false;

            PivotGridField fieldFOY_INFAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_INFAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_INFAZ_TARIHI.AreaIndex = 48;
            fieldFOY_INFAZ_TARIHI.FieldName = "FOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Name = "fieldFOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Visible = false;

            PivotGridField fieldTAKIBIN_MUVEKKILE_IADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.AreaIndex = 49;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.FieldName = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Name = "fieldTAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI.AreaIndex = 157;
            fieldTO_MASRAF_TOPLAMI.FieldName = "TO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Name = "fieldTO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 158;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI.AreaIndex = 159;
            fieldTS_MASRAF_TOPLAMI.FieldName = "TS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Name = "fieldTS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 160;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI.AreaIndex = 161;
            fieldTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Name = "fieldTUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 162;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 208;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 213;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 214;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 219;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldFORM_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFORM_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFORM_TIPI.AreaIndex = 39;
            fieldFORM_TIPI.FieldName = "FORM_TIPI";
            fieldFORM_TIPI.Name = "fieldFORM_TIPI";
            fieldFORM_TIPI.Visible = false;

            PivotGridField fieldTALEP_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALEP_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALEP_ADI.AreaIndex = 38;
            fieldTALEP_ADI.FieldName = "TALEP_ADI";
            fieldTALEP_ADI.Name = "fieldTALEP_ADI";
            fieldTALEP_ADI.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = dizi = new PivotGridField[]
            {
                fieldRISK_MIKTARI,
                fieldRISK_MIKTARI_DOVIZ_ID,
                fieldTUM_MASRAF_TOPLAMI,
                fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTS_MASRAF_TOPLAMI,
                fieldTS_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_MASRAF_TOPLAMI,
                fieldTO_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_ODEME_TOPLAMI,
                fieldTO_ODEME_TOPLAMI_DOVIZ_ID,
                fieldKALAN,
                fieldKALAN_DOVIZ_ID,
                fieldTAKIP_CIKISI,
                fieldTAKIP_CIKISI_DOVIZ_ID,
                fieldASIL_ALACAK,
			    fieldASIL_ALACAK_DOVIZ_ID,
                fieldSORUMLU,
                fieldIZLEYEN,
                fieldTALEP_ADI,
                fieldBANKA_SUBE,
                fieldKREDI_GRUP,
			    fieldKREDI_TIP,
                fieldSUBE_KOD_ID,
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			    fieldFOY_ARSIV_TARIHI,
			    fieldFOY_INFAZ_TARIHI,
			    fieldTAKIBIN_MUVEKKILE_IADE_TARIHI,
                fieldID,
                fieldTAKIP_TARIHI,
            };
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            return dizi;
        }

        private PivotGridField[] IcraDosylarininKrediTipineGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.AreaIndex = 4;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldTAKIP_TARIHI.Visible = true;
            PivotGridField fieldTAKIP_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI2.AreaIndex = 4;
            fieldTAKIP_TARIHI2.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI2.Name = "fieldTAKIP_TARIHI2";
            fieldTAKIP_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldTAKIP_TARIHI2.Visible = true;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 8;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 9;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 10;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldTAKIP_CIKISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.AreaIndex = 13;
            fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";
            fieldTAKIP_CIKISI.Visible = true;

            PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI_DOVIZ_ID.AreaIndex = 14;
            fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 19;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI.AreaIndex = 20;
            fieldTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Name = "fieldTO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 21;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 22;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldRISK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI.AreaIndex = 25;
            fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";
            fieldRISK_MIKTARI.Visible = false;

            PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 26;
            fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 29;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.AreaIndex = 31;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 34;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 35;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDURUM.AreaIndex = 40;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldFOY_ARSIV_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_ARSIV_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_ARSIV_TARIHI.AreaIndex = 47;
            fieldFOY_ARSIV_TARIHI.FieldName = "FOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Name = "fieldFOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Visible = false;

            PivotGridField fieldFOY_INFAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_INFAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_INFAZ_TARIHI.AreaIndex = 48;
            fieldFOY_INFAZ_TARIHI.FieldName = "FOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Name = "fieldFOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Visible = false;

            PivotGridField fieldTAKIBIN_MUVEKKILE_IADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.AreaIndex = 49;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.FieldName = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Name = "fieldTAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI.AreaIndex = 157;
            fieldTO_MASRAF_TOPLAMI.FieldName = "TO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Name = "fieldTO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 158;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI.AreaIndex = 159;
            fieldTS_MASRAF_TOPLAMI.FieldName = "TS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Name = "fieldTS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 160;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI.AreaIndex = 161;
            fieldTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Name = "fieldTUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 162;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 208;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 213;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 214;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = true;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 219;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldFORM_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFORM_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFORM_TIPI.AreaIndex = 39;
            fieldFORM_TIPI.FieldName = "FORM_TIPI";
            fieldFORM_TIPI.Name = "fieldFORM_TIPI";
            fieldFORM_TIPI.Visible = false;

            PivotGridField fieldTALEP_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALEP_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALEP_ADI.AreaIndex = 38;
            fieldTALEP_ADI.FieldName = "TALEP_ADI";
            fieldTALEP_ADI.Name = "fieldTALEP_ADI";
            fieldTALEP_ADI.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 218;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = dizi = new PivotGridField[]
            {
                fieldRISK_MIKTARI,
                fieldRISK_MIKTARI_DOVIZ_ID,
                fieldTUM_MASRAF_TOPLAMI,
                fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTS_MASRAF_TOPLAMI,
                fieldTS_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_MASRAF_TOPLAMI,
                fieldTO_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_ODEME_TOPLAMI,
                fieldTO_ODEME_TOPLAMI_DOVIZ_ID,
                fieldKALAN,
                fieldKALAN_DOVIZ_ID,
                fieldTAKIP_CIKISI,
                fieldTAKIP_CIKISI_DOVIZ_ID,
                fieldASIL_ALACAK,
			    fieldASIL_ALACAK_DOVIZ_ID,
                fieldSORUMLU,
                fieldIZLEYEN,
                fieldTALEP_ADI,
                fieldBANKA_SUBE,
                fieldKREDI_GRUP,
			    fieldKREDI_TIP,
                fieldBOLGE,
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			    fieldFOY_ARSIV_TARIHI,
			    fieldFOY_INFAZ_TARIHI,
			    fieldTAKIBIN_MUVEKKILE_IADE_TARIHI,
                fieldID,
                fieldTAKIP_TARIHI,
            };
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            return dizi;
        }

        private PivotGridField[] IcraDosylarininSorumluAvukatlaraGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.AreaIndex = 4;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldTAKIP_TARIHI.Visible = true;
            PivotGridField fieldTAKIP_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI2.AreaIndex = 4;
            fieldTAKIP_TARIHI2.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI2.Name = "fieldTAKIP_TARIHI2";
            fieldTAKIP_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldTAKIP_TARIHI2.Visible = true;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 8;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 9;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 10;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldTAKIP_CIKISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.AreaIndex = 13;
            fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";
            fieldTAKIP_CIKISI.Visible = true;

            PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI_DOVIZ_ID.AreaIndex = 14;
            fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 19;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI.AreaIndex = 20;
            fieldTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Name = "fieldTO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 21;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 22;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldRISK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI.AreaIndex = 25;
            fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";
            fieldRISK_MIKTARI.Visible = false;

            PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 26;
            fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 29;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.AreaIndex = 31;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 34;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 35;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = true;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDURUM.AreaIndex = 40;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = true;

            PivotGridField fieldFOY_ARSIV_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_ARSIV_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_ARSIV_TARIHI.AreaIndex = 47;
            fieldFOY_ARSIV_TARIHI.FieldName = "FOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Name = "fieldFOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Visible = false;

            PivotGridField fieldFOY_INFAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_INFAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_INFAZ_TARIHI.AreaIndex = 48;
            fieldFOY_INFAZ_TARIHI.FieldName = "FOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Name = "fieldFOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Visible = false;

            PivotGridField fieldTAKIBIN_MUVEKKILE_IADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.AreaIndex = 49;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.FieldName = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Name = "fieldTAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI.AreaIndex = 157;
            fieldTO_MASRAF_TOPLAMI.FieldName = "TO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Name = "fieldTO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 158;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI.AreaIndex = 159;
            fieldTS_MASRAF_TOPLAMI.FieldName = "TS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Name = "fieldTS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 160;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI.AreaIndex = 161;
            fieldTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Name = "fieldTUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 162;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 208;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = false;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 213;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 214;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 219;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldFORM_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFORM_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFORM_TIPI.AreaIndex = 39;
            fieldFORM_TIPI.FieldName = "FORM_TIPI";
            fieldFORM_TIPI.Name = "fieldFORM_TIPI";
            fieldFORM_TIPI.Visible = false;

            PivotGridField fieldTALEP_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALEP_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALEP_ADI.AreaIndex = 38;
            fieldTALEP_ADI.FieldName = "TALEP_ADI";
            fieldTALEP_ADI.Name = "fieldTALEP_ADI";
            fieldTALEP_ADI.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = dizi = new PivotGridField[]
            {
                fieldRISK_MIKTARI,
                fieldRISK_MIKTARI_DOVIZ_ID,
                fieldTUM_MASRAF_TOPLAMI,
                fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTS_MASRAF_TOPLAMI,
                fieldTS_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_MASRAF_TOPLAMI,
                fieldTO_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_ODEME_TOPLAMI,
                fieldTO_ODEME_TOPLAMI_DOVIZ_ID,
                fieldKALAN,
                fieldKALAN_DOVIZ_ID,
                fieldTAKIP_CIKISI,
                fieldTAKIP_CIKISI_DOVIZ_ID,
                fieldASIL_ALACAK,
			    fieldASIL_ALACAK_DOVIZ_ID,
                fieldSORUMLU,
                fieldIZLEYEN,
                fieldTALEP_ADI,
                fieldBANKA_SUBE,
                fieldKREDI_GRUP,
			    fieldKREDI_TIP,
                fieldSUBE_KOD_ID,
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			    fieldFOY_ARSIV_TARIHI,
			    fieldFOY_INFAZ_TARIHI,
			    fieldTAKIBIN_MUVEKKILE_IADE_TARIHI,
                fieldID,
                fieldTAKIP_TARIHI,
            };
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            return dizi;
        }

        private PivotGridField[] IcraDosylarininSubelereGoreDagilimi()
        {
            #region Field & Properties

            PivotGridField fieldTAKIP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI.AreaIndex = 4;
            fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
            fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateMonth;
            fieldTAKIP_TARIHI.Visible = true;
            PivotGridField fieldTAKIP_TARIHI2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_TARIHI2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldTAKIP_TARIHI2.AreaIndex = 4;
            fieldTAKIP_TARIHI2.FieldName = "TAKIP_TARIHI";
            fieldTAKIP_TARIHI2.Name = "fieldTAKIP_TARIHI2";
            fieldTAKIP_TARIHI2.GroupInterval = PivotGroupInterval.DateYear;
            fieldTAKIP_TARIHI2.Visible = true;

            PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 8;
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Visible = false;

            PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK_DOVIZ_ID.AreaIndex = 9;
            fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
            fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

            PivotGridField fieldASIL_ALACAK = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldASIL_ALACAK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldASIL_ALACAK.AreaIndex = 10;
            fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
            fieldASIL_ALACAK.Name = "fieldASIL_ALACAK";
            fieldASIL_ALACAK.Visible = false;

            PivotGridField fieldTAKIP_CIKISI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.AreaIndex = 13;
            fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
            fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";
            fieldTAKIP_CIKISI.Visible = true;

            PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIP_CIKISI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIP_CIKISI_DOVIZ_ID.AreaIndex = 14;
            fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
            fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.AreaIndex = 19;
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_TOPLAMI_DOVIZ_ID";
            fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTO_ODEME_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_ODEME_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_ODEME_TOPLAMI.AreaIndex = 20;
            fieldTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Name = "fieldTO_ODEME_TOPLAMI";
            fieldTO_ODEME_TOPLAMI.Visible = false;

            PivotGridField fieldKALAN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN.AreaIndex = 21;
            fieldKALAN.FieldName = "KALAN";
            fieldKALAN.Name = "fieldKALAN";
            fieldKALAN.Visible = false;

            PivotGridField fieldKALAN_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKALAN_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKALAN_DOVIZ_ID.AreaIndex = 22;
            fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
            fieldKALAN_DOVIZ_ID.Visible = false;

            PivotGridField fieldRISK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI.AreaIndex = 25;
            fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
            fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";
            fieldRISK_MIKTARI.Visible = false;

            PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldRISK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 26;
            fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
            fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 29;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldID.AreaIndex = 31;
            fieldID.FieldName = "ID";
            fieldID.Caption = "Dosya Sayisi";
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldID.Name = "fieldID";
            fieldID.Visible = true;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 34;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 35;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldDURUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDURUM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldDURUM.AreaIndex = 40;
            fieldDURUM.FieldName = "DURUM";
            fieldDURUM.Name = "fieldDURUM";
            fieldDURUM.Visible = false;

            PivotGridField fieldFOY_ARSIV_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_ARSIV_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_ARSIV_TARIHI.AreaIndex = 47;
            fieldFOY_ARSIV_TARIHI.FieldName = "FOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Name = "fieldFOY_ARSIV_TARIHI";
            fieldFOY_ARSIV_TARIHI.Visible = false;

            PivotGridField fieldFOY_INFAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_INFAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_INFAZ_TARIHI.AreaIndex = 48;
            fieldFOY_INFAZ_TARIHI.FieldName = "FOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Name = "fieldFOY_INFAZ_TARIHI";
            fieldFOY_INFAZ_TARIHI.Visible = false;

            PivotGridField fieldTAKIBIN_MUVEKKILE_IADE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.AreaIndex = 49;
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.FieldName = "TAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Name = "fieldTAKIBIN_MUVEKKILE_IADE_TARIHI";
            fieldTAKIBIN_MUVEKKILE_IADE_TARIHI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI.AreaIndex = 157;
            fieldTO_MASRAF_TOPLAMI.FieldName = "TO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Name = "fieldTO_MASRAF_TOPLAMI";
            fieldTO_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTO_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 158;
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTO_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTO_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI.AreaIndex = 159;
            fieldTS_MASRAF_TOPLAMI.FieldName = "TS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Name = "fieldTS_MASRAF_TOPLAMI";
            fieldTS_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTS_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 160;
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTS_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTS_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI.AreaIndex = 161;
            fieldTUM_MASRAF_TOPLAMI.FieldName = "TUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Name = "fieldTUM_MASRAF_TOPLAMI";
            fieldTUM_MASRAF_TOPLAMI.Visible = false;

            PivotGridField fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.AreaIndex = 162;
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Name = "fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID";
            fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID.Visible = false;

            PivotGridField fieldBANKA_SUBE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBANKA_SUBE.AreaIndex = 208;
            fieldBANKA_SUBE.FieldName = "BANKA_SUBE";
            fieldBANKA_SUBE.Name = "fieldBANKA_SUBE";
            fieldBANKA_SUBE.Visible = true;

            PivotGridField fieldKREDI_GRUP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_GRUP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_GRUP.AreaIndex = 213;
            fieldKREDI_GRUP.FieldName = "KREDI_GRUP";
            fieldKREDI_GRUP.Name = "fieldKREDI_GRUP";
            fieldKREDI_GRUP.Visible = false;

            PivotGridField fieldKREDI_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKREDI_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKREDI_TIP.AreaIndex = 214;
            fieldKREDI_TIP.FieldName = "KREDI_TIP";
            fieldKREDI_TIP.Name = "fieldKREDI_TIP";
            fieldKREDI_TIP.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 219;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            PivotGridField fieldFORM_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFORM_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFORM_TIPI.AreaIndex = 39;
            fieldFORM_TIPI.FieldName = "FORM_TIPI";
            fieldFORM_TIPI.Name = "fieldFORM_TIPI";
            fieldFORM_TIPI.Visible = false;

            PivotGridField fieldTALEP_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTALEP_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTALEP_ADI.AreaIndex = 38;
            fieldTALEP_ADI.FieldName = "TALEP_ADI";
            fieldTALEP_ADI.Name = "fieldTALEP_ADI";
            fieldTALEP_ADI.Visible = false;

            PivotGridField fieldBOLGE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLGE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLGE.AreaIndex = 218;
            fieldBOLGE.FieldName = "BOLGE";
            fieldBOLGE.Name = "fieldBOLGE";
            fieldBOLGE.Visible = false;

            #endregion Field & Properties

            PivotGridField[] dizi = dizi = new PivotGridField[]
            {
                fieldRISK_MIKTARI,
                fieldRISK_MIKTARI_DOVIZ_ID,
                fieldTUM_MASRAF_TOPLAMI,
                fieldTUM_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTS_MASRAF_TOPLAMI,
                fieldTS_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_MASRAF_TOPLAMI,
                fieldTO_MASRAF_TOPLAMI_DOVIZ_ID,
                fieldTO_ODEME_TOPLAMI,
                fieldTO_ODEME_TOPLAMI_DOVIZ_ID,
                fieldKALAN,
                fieldKALAN_DOVIZ_ID,
                fieldTAKIP_CIKISI,
                fieldTAKIP_CIKISI_DOVIZ_ID,
                fieldASIL_ALACAK,
			    fieldASIL_ALACAK_DOVIZ_ID,
                fieldSORUMLU,
                fieldIZLEYEN,
                fieldTALEP_ADI,
                fieldBANKA_SUBE,
                fieldKREDI_GRUP,
			    fieldKREDI_TIP,
                fieldBOLGE,
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
			    fieldFOY_ARSIV_TARIHI,
			    fieldFOY_INFAZ_TARIHI,
			    fieldTAKIBIN_MUVEKKILE_IADE_TARIHI,
                fieldID,
                fieldTAKIP_TARIHI,
            };
            fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            fieldBANKA_SUBE.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_CIKISI.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTAKIP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            return dizi;
        }

        #endregion PivotMetotlar
    }
}