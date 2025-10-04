using System.Collections.Generic;
using AvukatPro.Services.Implementations;
using AvukatPro.Services.Interfaces;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;
using AvukatProLib;

namespace AdimAdimDavaKaydi.UserControls.Util
{
    public static class Util
    {
        public static DevExpress.XtraGrid.GridSummaryItem GetSummaryItemByField(GridColumn col)
        {
            return new DevExpress.XtraGrid.GridSummaryItem(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:C2}");
        }
        public static GridGroupSummaryItem GetGroupSummaryItem(GridColumn col)
        {
            return new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, col.FieldName, col, "{0:C2}");
        }

        public static DevExpress.XtraGrid.GridSummaryItem GetSummaryItemByFieldNumeric(GridColumn col)
        {
            return new DevExpress.XtraGrid.GridSummaryItem(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}");
        }
        public static GridGroupSummaryItem GetGroupSummaryItemNumeric(GridColumn col)
        {
            return new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, col.FieldName, col, "{0:N0}");
        }
    }

    public static class Muhasebe
    {
        public static RepositoryItemLookUpEdit rlueDosyaTipi = new RepositoryItemLookUpEdit();
        public static RepositoryItemLookUpEdit rlueSegment = new RepositoryItemLookUpEdit();
        public static RepositoryItemLookUpEdit rlueFaturaKapsamTip = new RepositoryItemLookUpEdit();
        public static RepositoryItemLookUpEdit rlueDoviz = new RepositoryItemLookUpEdit();
        public static RepositoryItemLookUpEdit rlueKontrolKim = new RepositoryItemLookUpEdit();
        public static RepositoryItemSpinEdit rlueTutar = new RepositoryItemSpinEdit();
        public static RepositoryItemLookUpEdit rlueSubeKod = new RepositoryItemLookUpEdit();
        public static RepositoryItemLookUpEdit rlueCari = new RepositoryItemLookUpEdit();
        public static RepositoryItemLookUpEdit rlueAdliye = new RepositoryItemLookUpEdit();
        public static RepositoryItemLookUpEdit rlueAdliNo = new RepositoryItemLookUpEdit();
        public static RepositoryItemLookUpEdit rlueAdliGorev = new RepositoryItemLookUpEdit();
        public static RepositoryItemLookUpEdit rlueHarAnaKat = new RepositoryItemLookUpEdit();
        public static RepositoryItemLookUpEdit rlueHarAltKat = new RepositoryItemLookUpEdit();
        public static RepositoryItemLookUpEdit rlueMAsrafAvans = new RepositoryItemLookUpEdit();
        public static RepositoryItemLookUpEdit rlueAlacakTipi = new RepositoryItemLookUpEdit();
        public static RepositoryItemLookUpEdit rlueOdemeTipi = new RepositoryItemLookUpEdit();
        public static RepositoryItemLookUpEdit rlueModul = new RepositoryItemLookUpEdit();
        public static RepositoryItemLookUpEdit rlueAlacakNeden = new RepositoryItemLookUpEdit();
        public static RepositoryItemDateEdit rlueTarih = new RepositoryItemDateEdit();
        public static RepositoryItemSpinEdit rlueOran = new RepositoryItemSpinEdit();

        public class MuhasebeDetayli //cari hesap
        {

            public GridColumn[] GetMuhasebeDetayliColumns()
            {
                #region Kolonlar

                GridColumn colID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colSegmentId = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colMUHASEBE_HEDEF_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colBORC_ALACAK_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colADET = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colBIRIM_FIYAT = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colTOPLAM_TUTAR = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colKDV_TUTAR = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colSTOPAJ_SSDF_TUTAR = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colGENEL_TOPLAM = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colMuhasebelestirilmemis = new DevExpress.XtraGrid.Columns.GridColumn();
                //GridColumn colMuhasebelestirilmemisDovizId = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colBankaDekontNo = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colEFTReferansNo = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colREFERANS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colHAREKET_ANA_KATEGORI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colHAREKET_ALT_KATEGORI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colKasaHesapId = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colMuhatapHesapId = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colFOY_NO = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colADLI_BIRIM_ADLIYE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colADLI_BIRIM_NO_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colADLI_BIRIM_GOREV_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colESAS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colKiymetliEvrakId = new DevExpress.XtraGrid.Columns.GridColumn();
                //GridColumn colMASRAF_AVANS_DETAY_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                //GridColumn colACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colKAYIT_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
                //GridColumn colSUBE_KODU = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colTARIH = new DevExpress.XtraGrid.Columns.GridColumn();
                //GridColumn colDETAY_ACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();

                GridColumn colCari = new GridColumn();

                #endregion Kolonlar

                #region RepositoryItem

                RepositoryItemLookUpEdit rlueMuhasebeHedef = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueMasrafAvans = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueHarAltKat = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueHarAnaKat = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueDoviz = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueAdliye = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueAdliNo = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueAdliGorev = new RepositoryItemLookUpEdit();
                RepositoryItemDateEdit tarih = new RepositoryItemDateEdit();
                RepositoryItemMemoExEdit aciklama = new RepositoryItemMemoExEdit();
                RepositoryItemSpinEdit oran = new RepositoryItemSpinEdit();

                RepositoryItemLookUpEdit rlueCariID = new RepositoryItemLookUpEdit();

                BelgeUtil.Inits.BorcAlacakGetir(rlueAlacakTipi);
                BelgeUtil.Inits.HareketAnaKategoriGetir(rlueHarAnaKat);
                BelgeUtil.Inits.MuhasebeHareketAltKategori(rlueHarAltKat);
                BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliye);
                BelgeUtil.Inits.AdliBirimNoGetir(rlueAdliNo);
                BelgeUtil.Inits.AdliBirimGorevGetir(rlueAdliGorev);
                BelgeUtil.Inits.ParaBicimiAyarla(rlueTutar);
                BelgeUtil.Inits.YuzdeBicimiAyarla(oran);
                BelgeUtil.Inits.ModulGetir(rlueMuhasebeHedef);
                AvukatPro.Services.Implementations.DevExpressService.SegmentDoldur(rlueSegment);
                BelgeUtil.Inits.CariMuvekkilGetir(rlueCariID);

                #endregion RepositoryItem

                #region Properties

                //
                // colID
                //
                colID.Caption = "ID";
                colID.FieldName = "Id";
                colID.Name = "colID";
                colID.Visible = false;
                colID.VisibleIndex = -1;
                //
                // colSegmentId
                //
                colSegmentId.Caption = "Bölüm";
                colSegmentId.ColumnEdit = rlueSegment;
                colSegmentId.FieldName = "SegmentId";
                colSegmentId.Name = "colSegmentId";
                colSegmentId.Visible = true;
                colSegmentId.VisibleIndex = 1;
                //
                //colMUHASEBE_HEDEF_TIP
                //
                colMUHASEBE_HEDEF_TIP.Caption = "Muhasebe Hedep Tip";
                colMUHASEBE_HEDEF_TIP.FieldName = "MuhasebeHedefTip";
                colMUHASEBE_HEDEF_TIP.Name = "colMUHASEBE_HEDEF_TIP";
                colMUHASEBE_HEDEF_TIP.ColumnEdit = rlueMuhasebeHedef;
                colMUHASEBE_HEDEF_TIP.Visible = true;
                colMUHASEBE_HEDEF_TIP.VisibleIndex = 2;
                //
                // colBORC_ALACAK_ID
                //
                colBORC_ALACAK_ID.Caption = "Alacak Tipi";
                colBORC_ALACAK_ID.FieldName = "BorcAlacakId";
                colBORC_ALACAK_ID.Name = "colBORC_ALACAK_ID";
                colBORC_ALACAK_ID.ColumnEdit = rlueAlacakTipi;
                colBORC_ALACAK_ID.Visible = true;
                colBORC_ALACAK_ID.VisibleIndex = 26;
                //
                // colADET
                //
                colADET.Caption = "Adet";
                colADET.FieldName = "Adet";
                colADET.Name = "colADET";
                colADET.Visible = true;
                colADET.VisibleIndex = 3;
                //
                // colBIRIM_FIYAT
                //
                colBIRIM_FIYAT.Caption = "Birim Fiyat";
                colBIRIM_FIYAT.FieldName = "BirimFiyat";
                colBIRIM_FIYAT.Name = "colBIRIM_FIYAT";
                colBIRIM_FIYAT.ColumnEdit = rlueTutar;
                colBIRIM_FIYAT.Visible = true;
                colBIRIM_FIYAT.VisibleIndex = 4;
                //
                // colBIRIM_FIYAT_DOVIZ_ID
                //
                colBIRIM_FIYAT_DOVIZ_ID.Caption = "";
                colBIRIM_FIYAT_DOVIZ_ID.FieldName = "BirimFiyatDovizId";
                colBIRIM_FIYAT_DOVIZ_ID.Name = "colBIRIM_FIYAT_DOVIZ_ID";
                colBIRIM_FIYAT_DOVIZ_ID.ColumnEdit = rlueDoviz;
                colBIRIM_FIYAT_DOVIZ_ID.Visible = true;
                colBIRIM_FIYAT_DOVIZ_ID.VisibleIndex = 5;
                //
                // colTOPLAM_TUTAR
                //
                colTOPLAM_TUTAR.Caption = "Toplam Tutar";
                colTOPLAM_TUTAR.FieldName = "ToplamTutar";
                colTOPLAM_TUTAR.Name = "colTOPLAM_TUTAR";
                colTOPLAM_TUTAR.ColumnEdit = rlueTutar;
                colTOPLAM_TUTAR.Visible = true;
                colTOPLAM_TUTAR.VisibleIndex = 6;
                //
                // colKDV_TUTAR
                //
                colKDV_TUTAR.Caption = "KDV";
                colKDV_TUTAR.FieldName = "KdvTutar";
                colKDV_TUTAR.Name = "colKDV_TUTAR";
                colKDV_TUTAR.ColumnEdit = rlueTutar;
                colKDV_TUTAR.Visible = true;
                colKDV_TUTAR.VisibleIndex = 7;
                //
                // colSTOPAJ_SSDF_TUTAR
                //
                colSTOPAJ_SSDF_TUTAR.Caption = "SSDF";
                colSTOPAJ_SSDF_TUTAR.FieldName = "StopajSsdfTutar";
                colSTOPAJ_SSDF_TUTAR.Name = "colSTOPAJ_SSDF_TUTAR";
                colSTOPAJ_SSDF_TUTAR.ColumnEdit = rlueTutar;
                colSTOPAJ_SSDF_TUTAR.Visible = true;
                colSTOPAJ_SSDF_TUTAR.VisibleIndex = 8;
                //
                // colGENEL_TOPLAM
                //
                colGENEL_TOPLAM.Caption = "Genel Toplam";
                colGENEL_TOPLAM.FieldName = "GenelToplam";
                colGENEL_TOPLAM.Name = "colGENEL_TOPLAM";
                colGENEL_TOPLAM.ColumnEdit = rlueTutar;
                colGENEL_TOPLAM.Visible = true;
                colGENEL_TOPLAM.VisibleIndex = 9;
                //
                // colCarilestirilebilir
                //
                colMuhasebelestirilmemis.Caption = "Carileþtirilebilir Tutar";
                colMuhasebelestirilmemis.FieldName = "MuhasebelestirilmemisMiktar";
                colMuhasebelestirilmemis.Name = "colCarilestirilebilir";
                colMuhasebelestirilmemis.ColumnEdit = rlueTutar;
                colMuhasebelestirilmemis.Visible = true;
                colMuhasebelestirilmemis.VisibleIndex = 10;

                ////
                //// colCarilestirilebilirDovizId
                ////
                //colMuhasebelestirilmemisDovizId.Caption = "";
                //colMuhasebelestirilmemisDovizId.FieldName = "MuhasebelestirilmemisMiktarDovizId";
                //colMuhasebelestirilmemisDovizId.Name = "colCarilestirilebilirDovizId";
                //colMuhasebelestirilmemisDovizId.ColumnEdit = rlueDoviz;
                //colMuhasebelestirilmemisDovizId.Visible = true;
                //colMuhasebelestirilmemisDovizId.VisibleIndex = 11;
                //
                // colBankaDekontNo
                //
                colBankaDekontNo.Caption = "Dekont No";
                colBankaDekontNo.FieldName = "BankaDekontNo";
                colBankaDekontNo.Name = "colBankaDekontNo";
                colBankaDekontNo.Visible = true;
                colBankaDekontNo.VisibleIndex = 12;
                //
                // colEFTReferansNo
                //
                colEFTReferansNo.Caption = "Eft Referans";
                colEFTReferansNo.FieldName = "EftReferansNo";
                colEFTReferansNo.Name = "colEFTReferansNo";
                colEFTReferansNo.Visible = true;
                colEFTReferansNo.VisibleIndex = 13;
                //
                // colREFERANS_NO
                //
                colREFERANS_NO.Caption = "Referans No";
                colREFERANS_NO.FieldName = "ReferansNo";
                colREFERANS_NO.Name = "colREFERANS_NO";
                colREFERANS_NO.Visible = true;
                colREFERANS_NO.VisibleIndex = 14;
                //
                // colHAREKET_ALT_KATEGORI_ID
                //
                colHAREKET_ALT_KATEGORI_ID.Caption = "Alt Kategori";
                colHAREKET_ALT_KATEGORI_ID.FieldName = "HareketAltKategoriId";
                colHAREKET_ALT_KATEGORI_ID.Name = "colHAREKET_ALT_KATEGORI_ID";
                colHAREKET_ALT_KATEGORI_ID.ColumnEdit = rlueHarAltKat;
                colHAREKET_ALT_KATEGORI_ID.Visible = true;
                colHAREKET_ALT_KATEGORI_ID.VisibleIndex = 15;
                //
                // colFOY_NO
                //
                colFOY_NO.Caption = "Dosya No";
                colFOY_NO.FieldName = "FoyNo";
                colFOY_NO.Name = "colFOY_NO";
                colFOY_NO.Visible = true;
                colFOY_NO.VisibleIndex = 16;
                //
                // colADLI_BIRIM_ADLIYE_ID
                //
                colADLI_BIRIM_ADLIYE_ID.Caption = "Adliye";
                colADLI_BIRIM_ADLIYE_ID.FieldName = "AdliBirimAdliyeId";
                colADLI_BIRIM_ADLIYE_ID.Name = "colADLI_BIRIM_ADLIYE_ID";
                colADLI_BIRIM_ADLIYE_ID.ColumnEdit = rlueAdliye;
                colADLI_BIRIM_ADLIYE_ID.Visible = true;
                colADLI_BIRIM_ADLIYE_ID.VisibleIndex = 17;
                //
                //colADLI_BIRIM_NO_ID
                //
                colADLI_BIRIM_NO_ID.Caption = "No";
                colADLI_BIRIM_NO_ID.FieldName = "AdliBirimNoId";
                colADLI_BIRIM_NO_ID.Name = "colADLI_BIRIM_NO_ID";
                colADLI_BIRIM_NO_ID.ColumnEdit = rlueAdliNo;
                colADLI_BIRIM_NO_ID.Visible = true;
                colADLI_BIRIM_NO_ID.VisibleIndex = 18;
                //
                //colADLI_BIRIM_GOREV_ID
                //
                colADLI_BIRIM_GOREV_ID.Caption = "Görev";
                colADLI_BIRIM_GOREV_ID.FieldName = "AdliBirimGorevId";
                colADLI_BIRIM_GOREV_ID.Name = "colADLI_BIRIM_GOREV_ID";
                colADLI_BIRIM_GOREV_ID.ColumnEdit = rlueAdliGorev;
                colADLI_BIRIM_GOREV_ID.Visible = true;
                colADLI_BIRIM_GOREV_ID.VisibleIndex = 19;
                //
                //colESAS_NO
                //
                colESAS_NO.Caption = "Esas No";
                colESAS_NO.FieldName = "EsasNo";
                colESAS_NO.Name = "colESAS_NO";
                colESAS_NO.Visible = true;
                colESAS_NO.VisibleIndex = 20;
                //
                // colHAREKET_ANA_KATEGORI_ID
                //
                colHAREKET_ANA_KATEGORI_ID.Caption = "Ana Kategori";
                colHAREKET_ANA_KATEGORI_ID.FieldName = "HareketAnaKategoriId";
                colHAREKET_ANA_KATEGORI_ID.Name = "colHAREKET_ANA_KATEGORI_ID";
                colHAREKET_ANA_KATEGORI_ID.ColumnEdit = rlueHarAnaKat;
                colHAREKET_ANA_KATEGORI_ID.Visible = false;
                colHAREKET_ANA_KATEGORI_ID.VisibleIndex = -1;
                //
                // colKasaHesapId
                //
                colKasaHesapId.Caption = "Kasa Hesap";
                colKasaHesapId.FieldName = "KasaHesapSahibiCariBankaId";
                colKasaHesapId.Name = "colKasaHesapId";
                colKasaHesapId.Visible = false;
                colKasaHesapId.VisibleIndex = -1;
                //
                // colMuhatapHesapId
                //
                colMuhatapHesapId.Caption = "Muhatap Hesap";
                colMuhatapHesapId.FieldName = "MuhatapHesapSahibiCariBankaId";
                colMuhatapHesapId.Name = "colMuhatapHesapId";
                colMuhatapHesapId.Visible = false;
                colMuhatapHesapId.VisibleIndex = -1;
                //
                // colKiymetliEvrakId
                //
                colKiymetliEvrakId.Caption = "";
                colKiymetliEvrakId.FieldName = "KiymetliEvrakId";
                colKiymetliEvrakId.Name = "colKiymetliEvrakId";
                colKiymetliEvrakId.Visible = false;
                colKiymetliEvrakId.VisibleIndex = -1;
                ////
                ////colMASRAF_AVANS_DETAY_ID
                ////
                //colMASRAF_AVANS_DETAY_ID.Caption = "";
                //colMASRAF_AVANS_DETAY_ID.FieldName = "MasrafAvansDetayId";
                //colMASRAF_AVANS_DETAY_ID.Name = "colMASRAF_AVANS_DETAY_ID";
                //colMASRAF_AVANS_DETAY_ID.Visible = false;
                //colMASRAF_AVANS_DETAY_ID.VisibleIndex = -1;
                ////
                //// colACIKLAMA
                ////
                //colACIKLAMA.Caption = "Açýklama";
                //colACIKLAMA.FieldName = "Aciklama";
                //colACIKLAMA.Name = "colACIKLAMA";
                //colACIKLAMA.ColumnEdit = aciklama;
                //colACIKLAMA.Visible = false;
                //colACIKLAMA.VisibleIndex = 2;
                //
                // colKAYIT_TARIHI
                //
                colKAYIT_TARIHI.Caption = "Kayýt Tarihi";
                colKAYIT_TARIHI.FieldName = "KayitTarihi";
                colKAYIT_TARIHI.Name = "colKAYIT_TARIHI";
                colKAYIT_TARIHI.Visible = true;
                colKAYIT_TARIHI.VisibleIndex = 3;
                ////
                //// colSUBE_KODU
                ////
                //colSUBE_KODU.Caption = "Þube Kodu";
                //colSUBE_KODU.FieldName = "SubeKodu";
                //colSUBE_KODU.Name = "colSUBE_KODU";
                //colSUBE_KODU.Visible = true;
                //colSUBE_KODU.VisibleIndex = 4;
                //
                // colTARIH
                //
                colTARIH.Caption = "Tarih";
                colTARIH.FieldName = "Tarih";
                colTARIH.Name = "colTARIH";
                colTARIH.Visible = true;
                colTARIH.VisibleIndex = 5;
                ////
                //// colDETAY_ACIKLAMA
                ////
                //colDETAY_ACIKLAMA.Caption = "Detay Açýklama";
                //colDETAY_ACIKLAMA.FieldName = "DetayAciklama";
                //colDETAY_ACIKLAMA.Name = "colDETAY_ACIKLAMA";
                //colDETAY_ACIKLAMA.ColumnEdit = aciklama;
                //colDETAY_ACIKLAMA.Visible = true;
                //colDETAY_ACIKLAMA.VisibleIndex = 15;

                //
                // colBORC_ALACAK_ID
                //
                colCari.Caption = "Þahýs";
                colCari.FieldName = "MuvekkilCariId";
                colCari.Name = "colCariID";
                colCari.ColumnEdit = rlueCariID;
                colCari.Visible = true;
                colCari.VisibleIndex = 26;

                #endregion Properties

                #region Summary

                StyleFormatCondition c1 = new StyleFormatCondition(FormatConditionEnum.Greater, colBIRIM_FIYAT, "", 0, 0, true);
                c1.Appearance.BackColor = System.Drawing.Color.LimeGreen;

                StyleFormatCondition c2 = new StyleFormatCondition(FormatConditionEnum.Less, colBIRIM_FIYAT, "", 0, 0, true);
                c2.Appearance.BackColor = System.Drawing.Color.Orange;

                colGENEL_TOPLAM.SummaryItem.Assign(Util.GetSummaryItemByField(colGENEL_TOPLAM));
                colTOPLAM_TUTAR.SummaryItem.Assign(Util.GetSummaryItemByField(colTOPLAM_TUTAR));
                colKDV_TUTAR.SummaryItem.Assign(Util.GetSummaryItemByField(colKDV_TUTAR));
                colSTOPAJ_SSDF_TUTAR.SummaryItem.Assign(Util.GetSummaryItemByField(colSTOPAJ_SSDF_TUTAR));
                colMuhasebelestirilmemis.SummaryItem.Assign(Util.GetSummaryItemByField(colMuhasebelestirilmemis));
                colADET.SummaryItem.Assign(Util.GetSummaryItemByFieldNumeric(colADET));

                #endregion Summary

                #region []

                GridColumn[] dizi = new[]
                                            {
                                                colID,
                                                colSegmentId,
                                                colMUHASEBE_HEDEF_TIP,
                                                colBORC_ALACAK_ID,
                                                colADET,
                                                colBIRIM_FIYAT,
                                                colBIRIM_FIYAT_DOVIZ_ID ,
                                                colTOPLAM_TUTAR,
                                                colKDV_TUTAR,
                                                colSTOPAJ_SSDF_TUTAR,
                                                colGENEL_TOPLAM ,
                                                colMuhasebelestirilmemis ,
                                                //colMuhasebelestirilmemisDovizId ,
                                                colBankaDekontNo ,
                                                colEFTReferansNo ,
                                                colREFERANS_NO ,
                                                colHAREKET_ANA_KATEGORI_ID,
                                                colHAREKET_ALT_KATEGORI_ID,
                                                colKasaHesapId ,
                                                colMuhatapHesapId ,
                                                colFOY_NO ,
                                                colADLI_BIRIM_ADLIYE_ID ,
                                                colADLI_BIRIM_NO_ID ,
                                                colADLI_BIRIM_GOREV_ID ,
                                                colESAS_NO ,
                                                colKiymetliEvrakId,
                                                colTARIH,
                                                colKAYIT_TARIHI,
                                                colCari
                                            };

                #endregion []

                foreach (var item in dizi)
                {
                    item.OptionsColumn.ReadOnly = true;
                    item.OptionsColumn.AllowEdit = false;
                }

                return dizi;
            }
        }

        public class MasrafAvans
        {

            public GridColumn[] GetMasrafAvansDetayliColumns()
            {
                #region Columns

                GridColumn colID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colSegmentId = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colMODUL_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colMASRAF_AVANS_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colBORC_ALACAK_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colADET = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colBIRIM_FIYAT = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colTOPLAM_TUTAR = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colKDV_TUTAR = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colSTOPAJ_SSDF_TUTAR = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colGENEL_TOPLAM = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colBankaDekontNo = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colEFTReferansNo = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colREFERANS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colHAREKET_ALT_KATEGORI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colFOY_NO = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colADLI_BIRIM_ADLIYE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colADLI_BIRIM_NO_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colADLI_BIRIM_GOREV_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colESAS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colHAREKET_ANA_KATEGORI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colKasaHesapId = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colMuhatapHesapId = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colKiymetliEvrakId = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colMUVEKKIL_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colDETAY_ACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colCARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                //GridColumn colACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
                //GridColumn colBORCLU_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colTARIH = new DevExpress.XtraGrid.Columns.GridColumn();
                //GridColumn colKULLANICI_BELGE_NO = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colODEME_TIP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colKAYIT_TARIHI = new GridColumn();
                #endregion Columns

                #region RepositoryItem

                RepositoryItemMemoExEdit MAciklama = new RepositoryItemMemoExEdit();

                //if (rlueMAlacakNeden.DataSource != null)
                //{
                BelgeUtil.Inits.YuzdeBicimiAyarla(rlueOran);
                BelgeUtil.Inits.ParaBicimiAyarla(rlueTutar);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliye);
                BelgeUtil.Inits.AdliBirimNoGetir(rlueAdliNo);
                BelgeUtil.Inits.AdliBirimGorevGetir(rlueAdliGorev);
                BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
                BelgeUtil.Inits.MuhasebeHareketAltKategori(rlueHarAltKat);
                BelgeUtil.Inits.HareketAnaKategoriGetir(rlueHarAnaKat);
                BelgeUtil.Inits.perCariGetir(rlueCari);
                BelgeUtil.Inits.MasrafAvansTipGetir(rlueMAsrafAvans);
                BelgeUtil.Inits.BorcAlacakGetir(rlueAlacakTipi);
                BelgeUtil.Inits.OdemeTipiGetir(rlueOdemeTipi);
                BelgeUtil.Inits.ModulGetir(rlueModul);
                BelgeUtil.Inits.AlacakNEdenGetir(rlueAlacakNeden);
                AvukatPro.Services.Implementations.DevExpressService.SegmentDoldur(rlueSegment);


                // }

                #endregion RepositoryItem

                #region Properties
                //
                // colID
                //
                colID.Caption = "ID";
                colID.FieldName = "Id";
                colID.Name = "colID";
                colID.Visible = false;
                colID.VisibleIndex = -1;
                //
                // colSegmentId
                //
                colSegmentId.Caption = "Bölüm";
                colSegmentId.ColumnEdit = rlueSegment;
                colSegmentId.FieldName = "SegmentId";
                colSegmentId.Name = "colSegmentId";
                colSegmentId.Visible = true;
                colSegmentId.VisibleIndex = 0;
                //
                // colMODUL_ID
                //
                colMODUL_ID.Caption = "Modül";
                colMODUL_ID.FieldName = "ModulId";
                colMODUL_ID.Name = "colMODUL_ID";
                colMODUL_ID.ColumnEdit = rlueModul;
                colMODUL_ID.Visible = true;
                colMODUL_ID.VisibleIndex = 1;
                //
                // colMASRAF_AVANS_TIP
                //
                colMASRAF_AVANS_TIP.Caption = "Masraf Avans";
                colMASRAF_AVANS_TIP.FieldName = "MasrafAvansTip";
                colMASRAF_AVANS_TIP.Name = "colMASRAF_AVANS_TIP";
                colMASRAF_AVANS_TIP.ColumnEdit = rlueMAsrafAvans;
                colMASRAF_AVANS_TIP.Visible = true;
                colMASRAF_AVANS_TIP.VisibleIndex = 2;
                //
                // colBORC_ALACAK_ID
                //
                colBORC_ALACAK_ID.Caption = "Alacak Tipi";
                colBORC_ALACAK_ID.FieldName = "BorcAlacakId";
                colBORC_ALACAK_ID.Name = "colBORC_ALACAK_ID";
                colBORC_ALACAK_ID.ColumnEdit = rlueAlacakTipi;
                colBORC_ALACAK_ID.Visible = true;
                colBORC_ALACAK_ID.VisibleIndex = 3;
                //
                // colADET
                //
                colADET.Caption = "Adet";
                colADET.FieldName = "Adet";
                colADET.Name = "colADET";
                colADET.Visible = true;
                colADET.VisibleIndex = 4;
                //
                // colBIRIM_FIYAT
                //
                colBIRIM_FIYAT.Caption = "Birim Fiyat";
                colBIRIM_FIYAT.FieldName = "BirimFiyat";
                colBIRIM_FIYAT.Name = "colBIRIM_FIYAT";
                colBIRIM_FIYAT.ColumnEdit = rlueTutar;
                colBIRIM_FIYAT.Visible = true;
                colBIRIM_FIYAT.VisibleIndex = 5;
                //
                // colBIRIM_FIYAT_DOVIZ_ID
                //
                colBIRIM_FIYAT_DOVIZ_ID.Caption = "";
                colBIRIM_FIYAT_DOVIZ_ID.ColumnEdit = rlueDoviz;
                colBIRIM_FIYAT_DOVIZ_ID.FieldName = "BirimFiyatDovizId";
                colBIRIM_FIYAT_DOVIZ_ID.Name = "colBIRIM_FIYAT_DOVIZ_ID";
                colBIRIM_FIYAT_DOVIZ_ID.Visible = true;
                colBIRIM_FIYAT_DOVIZ_ID.VisibleIndex = 6;
                //
                // colTOPLAM_TUTAR
                //
                colTOPLAM_TUTAR.Caption = "Toplam Tutar";
                colTOPLAM_TUTAR.FieldName = "ToplamTutar";
                colTOPLAM_TUTAR.Name = "colTOPLAM_TUTAR";
                colTOPLAM_TUTAR.ColumnEdit = rlueTutar;
                colTOPLAM_TUTAR.Visible = true;
                colTOPLAM_TUTAR.VisibleIndex = 6;
                ////
                //// colTOPLAM_TUTAR_DOVIZ_ID
                ////
                //colTOPLAM_TUTAR_DOVIZ_ID.Caption = "";
                //colTOPLAM_TUTAR_DOVIZ_ID.FieldName = "ToplamTutarDovizId";
                //colTOPLAM_TUTAR_DOVIZ_ID.Name = "colTOPLAM_TUTAR_DOVIZ_ID";
                //colTOPLAM_TUTAR_DOVIZ_ID.ColumnEdit = rlueMDoviz;
                //colTOPLAM_TUTAR_DOVIZ_ID.Visible = true;
                //colTOPLAM_TUTAR_DOVIZ_ID.VisibleIndex = 7;
                //
                // colKDV_TUTAR
                //
                colKDV_TUTAR.Caption = "KDV Tutar";
                colKDV_TUTAR.FieldName = "KdvTutar";
                colKDV_TUTAR.Name = "colKDV_TUTAR";
                colKDV_TUTAR.ColumnEdit = rlueTutar;
                colKDV_TUTAR.Visible = true;
                colKDV_TUTAR.VisibleIndex = 8;
                //
                // colSTOPAJ_SSDF_TUTAR
                //
                colSTOPAJ_SSDF_TUTAR.Caption = "Stopaj SSDF Tutarý";
                colSTOPAJ_SSDF_TUTAR.FieldName = "StopajSsdfTutar";
                colSTOPAJ_SSDF_TUTAR.Name = "colSTOPAJ_SSDF_TUTAR";
                colSTOPAJ_SSDF_TUTAR.ColumnEdit = rlueTutar;
                colSTOPAJ_SSDF_TUTAR.Visible = true;
                colSTOPAJ_SSDF_TUTAR.VisibleIndex = 9;
                //
                // colGENEL_TOPLAM
                //
                colGENEL_TOPLAM.Caption = "Genel Toplam";
                colGENEL_TOPLAM.FieldName = "GenelToplam";
                colGENEL_TOPLAM.Name = "colGENEL_TOPLAM";
                colGENEL_TOPLAM.ColumnEdit = rlueTutar;
                colGENEL_TOPLAM.Visible = true;
                colGENEL_TOPLAM.VisibleIndex = 10;

                //// colGENEL_TOPLAM_DOVIZ_ID

                //colGENEL_TOPLAM_DOVIZ_ID.Caption = "";
                //colGENEL_TOPLAM_DOVIZ_ID.FieldName = "GenelToplamDovizId";
                //colGENEL_TOPLAM_DOVIZ_ID.Name = "colGENEL_TOPLAM_DOVIZ_ID";
                //colGENEL_TOPLAM_DOVIZ_ID.ColumnEdit = rlueMDoviz;
                //colGENEL_TOPLAM_DOVIZ_ID.Visible = true;
                //colGENEL_TOPLAM_DOVIZ_ID.VisibleIndex = 11;
                //
                // colBankaDekontNo
                //
                colBankaDekontNo.Caption = "Dekont No";
                colBankaDekontNo.FieldName = "BankaDekontNo";
                colBankaDekontNo.Name = "colBankaDekontNo";
                colBankaDekontNo.Visible = true;
                colBankaDekontNo.VisibleIndex = 12;
                //
                // colEFTReferansNo
                //
                colEFTReferansNo.Caption = "Eft Referans";
                colEFTReferansNo.FieldName = "EftReferansNo";
                colEFTReferansNo.Name = "colEFTReferansNo";
                colEFTReferansNo.Visible = true;
                colEFTReferansNo.VisibleIndex = 13;
                //
                // colREFERANS_NO
                //
                colREFERANS_NO.Caption = "Referans No";
                colREFERANS_NO.FieldName = "ReferansNo";
                colREFERANS_NO.Name = "colREFERANS_NO";
                colREFERANS_NO.Visible = true;
                colREFERANS_NO.VisibleIndex = 14;
                //
                // colHAREKET_ALT_KATEGORI_ID
                //
                colHAREKET_ALT_KATEGORI_ID.Caption = "Hareket Alt Kategori";
                colHAREKET_ALT_KATEGORI_ID.FieldName = "HareketAltKategoriId";
                colHAREKET_ALT_KATEGORI_ID.Name = "colHAREKET_ALT_KATEGORI_ID";
                colHAREKET_ALT_KATEGORI_ID.ColumnEdit = rlueHarAltKat;
                colHAREKET_ALT_KATEGORI_ID.Visible = true;
                colHAREKET_ALT_KATEGORI_ID.VisibleIndex = 15;
                //
                // colFOY_NO
                //
                colFOY_NO.Caption = "Dosya No";
                colFOY_NO.FieldName = "FoyNo";
                colFOY_NO.Name = "colFOY_NO";
                colFOY_NO.Visible = true;
                colFOY_NO.VisibleIndex = 16;
                //
                // colADLI_BIRIM_ADLIYE_ID
                //
                colADLI_BIRIM_ADLIYE_ID.Caption = "Adliye";
                colADLI_BIRIM_ADLIYE_ID.FieldName = "AdliBirimAdliyeId";
                colADLI_BIRIM_ADLIYE_ID.Name = "colADLI_BIRIM_ADLIYE_ID";
                colADLI_BIRIM_ADLIYE_ID.ColumnEdit = rlueAdliye;
                colADLI_BIRIM_ADLIYE_ID.Visible = true;
                colADLI_BIRIM_ADLIYE_ID.VisibleIndex = 17;
                //
                // colADLI_BIRIM_NO_ID
                //
                colADLI_BIRIM_NO_ID.Caption = "No";
                colADLI_BIRIM_NO_ID.FieldName = "AdliBirimNoId";
                colADLI_BIRIM_NO_ID.Name = "colADLI_BIRIM_NO_ID";
                colADLI_BIRIM_NO_ID.ColumnEdit = rlueAdliNo;
                colADLI_BIRIM_NO_ID.Visible = true;
                colADLI_BIRIM_NO_ID.VisibleIndex = 18;
                //
                // colADLI_BIRIM_GOREV_ID
                //
                colADLI_BIRIM_GOREV_ID.Caption = "Görev";
                colADLI_BIRIM_GOREV_ID.FieldName = "AdliBirimGorevId";
                colADLI_BIRIM_GOREV_ID.Name = "colADLI_BIRIM_GOREV_ID";
                colADLI_BIRIM_GOREV_ID.ColumnEdit = rlueAdliGorev;
                colADLI_BIRIM_GOREV_ID.Visible = true;
                colADLI_BIRIM_GOREV_ID.VisibleIndex = 19;
                //
                // colESAS_NO
                //
                colESAS_NO.Caption = "Esas No";
                colESAS_NO.FieldName = "EsasNo";
                colESAS_NO.Name = "colESAS_NO";
                colESAS_NO.Visible = true;
                colESAS_NO.VisibleIndex = 20;

                //
                // colHAREKET_ANA_KATEGORI_ID
                //
                colHAREKET_ANA_KATEGORI_ID.Caption = "Hareket Ana Kategori";
                colHAREKET_ANA_KATEGORI_ID.FieldName = "HareketAnaKategoriId";
                colHAREKET_ANA_KATEGORI_ID.Name = "colHAREKET_ANA_KATEGORI_ID";
                colHAREKET_ANA_KATEGORI_ID.ColumnEdit = rlueHarAnaKat;
                colHAREKET_ANA_KATEGORI_ID.Visible = false;
                colHAREKET_ANA_KATEGORI_ID.VisibleIndex = -1;
                //
                // colMuhatapHesapId
                //
                colMuhatapHesapId.Caption = "Muhatap Hesap";
                colMuhatapHesapId.FieldName = "MuhatapHesapSahibiCariBankaId";
                colMuhatapHesapId.Name = "colMuhatapHesapId";
                colMuhatapHesapId.Visible = false;
                colMuhatapHesapId.VisibleIndex = -1;
                //
                // colKasaHesapId
                //
                colKasaHesapId.Caption = "Kasa Hesap";
                colKasaHesapId.FieldName = "KasaHesapSahibiCariBankaId";
                colKasaHesapId.Name = "colKasaHesapId";
                colKasaHesapId.Visible = false;
                colKasaHesapId.VisibleIndex = -1;
                //
                // colKiymetliEvrakId
                //
                colKiymetliEvrakId.Caption = "";
                colKiymetliEvrakId.FieldName = "KiymetliEvrakId";
                colKiymetliEvrakId.Name = "colKiymetliEvrakId";
                colKiymetliEvrakId.Visible = false;
                colKiymetliEvrakId.VisibleIndex = -1;

                //// colACIKLAMA

                //colACIKLAMA.Caption = "Açýklama";
                //colACIKLAMA.FieldName = "Aciklama";
                //colACIKLAMA.Name = "colACIKLAMA";
                //colACIKLAMA.ColumnEdit = MAciklama;
                //colACIKLAMA.Visible = true;
                //colACIKLAMA.VisibleIndex = 20;

                //// colBORCLU_CARI_ID

                //colBORCLU_CARI_ID.Caption = "Borçlu";
                //colBORCLU_CARI_ID.FieldName = "BorcluCariId";
                //colBORCLU_CARI_ID.Name = "colBORCLU_CARI_ID";
                //colBORCLU_CARI_ID.ColumnEdit = rlueCari;
                //colBORCLU_CARI_ID.Visible = true;
                //colBORCLU_CARI_ID.VisibleIndex = 21;

                // colTARIH

                colTARIH.Caption = "Tarih";
                colTARIH.FieldName = "Tarih";
                colTARIH.Name = "colTARIH";
                colTARIH.ColumnEdit = rlueTarih;
                colTARIH.Visible = true;
                colTARIH.VisibleIndex = 24;

                //// colKULLANICI_BELGE_NO

                //colKULLANICI_BELGE_NO.Caption = "Kullanýcý Belge No";
                //colKULLANICI_BELGE_NO.FieldName = "KullaniciBelgeNo";
                //colKULLANICI_BELGE_NO.Name = "colKULLANICI_BELGE_NO";
                //colKULLANICI_BELGE_NO.Visible = true;
                //colKULLANICI_BELGE_NO.VisibleIndex = 25;

                // colMUVEKKIL_CARI_ID

                colMUVEKKIL_CARI_ID.Caption = "Müvekkil";
                colMUVEKKIL_CARI_ID.FieldName = "MuvekkilCariId";
                colMUVEKKIL_CARI_ID.Name = "colMUVEKKIL_CARI_ID";
                colMUVEKKIL_CARI_ID.ColumnEdit = rlueCari;
                colMUVEKKIL_CARI_ID.Visible = true;
                colMUVEKKIL_CARI_ID.VisibleIndex = 14;

                // colDETAY_ACIKLAMA

                colDETAY_ACIKLAMA.Caption = "Açýklama";
                colDETAY_ACIKLAMA.FieldName = "DetayAciklama";
                colDETAY_ACIKLAMA.Name = "colDETAY_ACIKLAMA";
                colDETAY_ACIKLAMA.ColumnEdit = MAciklama;
                colDETAY_ACIKLAMA.Visible = true;
                colDETAY_ACIKLAMA.VisibleIndex = 15;

                // colCARI_ID

                colCARI_ID.Caption = "Taraf Adý";
                colCARI_ID.FieldName = "CariId";
                colCARI_ID.Name = "colCARI_ID";
                colCARI_ID.ColumnEdit = rlueCari;
                colCARI_ID.Visible = true;
                colCARI_ID.VisibleIndex = 16;

                // colODEME_TIP_ID

                colODEME_TIP_ID.Caption = "Ödeme Tipi";
                colODEME_TIP_ID.FieldName = "OdemeTipId";
                colODEME_TIP_ID.Name = "colODEME_TIP_ID";
                colODEME_TIP_ID.ColumnEdit = rlueOdemeTipi;
                colODEME_TIP_ID.Visible = true;
                colODEME_TIP_ID.VisibleIndex = 27;
                //
                //colKAYIT_TARIHI
                //
                colKAYIT_TARIHI.VisibleIndex = 28;
                colKAYIT_TARIHI.Caption = "Kayýt Tarihi";
                colKAYIT_TARIHI.FieldName = "KayitTarihi";
                colKAYIT_TARIHI.Name = "colKAYIT_TARIHI";
                colKAYIT_TARIHI.Visible = true;
                #endregion Properties

                #region Summary

                StyleFormatCondition c1 = new StyleFormatCondition(FormatConditionEnum.Greater, colBIRIM_FIYAT, "", 0, 0, true);
                c1.Appearance.BackColor = System.Drawing.Color.LimeGreen;

                StyleFormatCondition c2 = new StyleFormatCondition(FormatConditionEnum.Less, colBIRIM_FIYAT, "", 0, 0, true);
                c2.Appearance.BackColor = System.Drawing.Color.Orange;
                colGENEL_TOPLAM.SummaryItem.Assign(Util.GetSummaryItemByField(colGENEL_TOPLAM));
                colKDV_TUTAR.SummaryItem.Assign(Util.GetSummaryItemByField(colKDV_TUTAR));
                colSTOPAJ_SSDF_TUTAR.SummaryItem.Assign(Util.GetSummaryItemByField(colSTOPAJ_SSDF_TUTAR));
                colTOPLAM_TUTAR.SummaryItem.Assign(Util.GetSummaryItemByField(colTOPLAM_TUTAR));
                colADET.SummaryItem.Assign(Util.GetSummaryItemByFieldNumeric(colADET));

                #endregion Summary

                #region []

                GridColumn[] dizi = new[]
                                            {
                                                colID,
                                                colSegmentId,
                                                colMODUL_ID ,
                                                colMASRAF_AVANS_TIP,
                                                colBORC_ALACAK_ID ,
                                                colADET ,
                                                colBIRIM_FIYAT ,
                                                colBIRIM_FIYAT_DOVIZ_ID ,
                                                colTOPLAM_TUTAR ,
                                                colKDV_TUTAR ,
                                                colSTOPAJ_SSDF_TUTAR,
                                                colGENEL_TOPLAM ,
                                                colBankaDekontNo ,
                                                colEFTReferansNo ,
                                                colREFERANS_NO ,
                                                colHAREKET_ALT_KATEGORI_ID ,
                                                colFOY_NO ,
                                                colADLI_BIRIM_ADLIYE_ID ,
                                                colADLI_BIRIM_NO_ID ,
                                                colADLI_BIRIM_GOREV_ID ,
                                                colESAS_NO ,
                                                colHAREKET_ANA_KATEGORI_ID ,
                                                colKasaHesapId ,
                                                colMuhatapHesapId ,
                                                colKiymetliEvrakId ,
                                                colMUVEKKIL_CARI_ID,
                                                colDETAY_ACIKLAMA,
                                                colCARI_ID,
                                                colTARIH,
                                                colODEME_TIP_ID,
                                                colKAYIT_TARIHI
                                            };

                #endregion []

                foreach (var item in dizi)
                {
                    item.OptionsColumn.ReadOnly = true;
                    item.OptionsColumn.AllowEdit = false;
                }

                return dizi;
            }

            //public GridColumn[] GetMasrafAvans()
            //{
            //    #region Columns

            //    GridColumn colCARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            //    GridColumn colREFERANS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            //    GridColumn colMASRAF_AVANS_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
            //    GridColumn colCARI_HESAP_HEDEF_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
            //    GridColumn colICRA_FOY_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            //    GridColumn colDAVA_FOY_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            //    GridColumn colHAZIRLIK_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            //    GridColumn colRUCU_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            //    GridColumn colACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            //    GridColumn colKAYIT_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            //    GridColumn colKLASOR_KODU = new DevExpress.XtraGrid.Columns.GridColumn();
            //    GridColumn colSUBE_KODU = new DevExpress.XtraGrid.Columns.GridColumn();
            //    GridColumn colKONTROL_NE_ZAMAN = new DevExpress.XtraGrid.Columns.GridColumn();
            //    GridColumn colKONTROL_KIM = new DevExpress.XtraGrid.Columns.GridColumn();
            //    GridColumn colKONTROL_VERSIYON = new DevExpress.XtraGrid.Columns.GridColumn();
            //    GridColumn colSTAMP = new DevExpress.XtraGrid.Columns.GridColumn();
            //    GridColumn colBORCLU_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            //    GridColumn colMANUEL_KAYIT_MI = new DevExpress.XtraGrid.Columns.GridColumn();

            //    #endregion Columns

            //    #region RepositoryItem

            //    RepositoryItemLookUpEdit rlueCari = new RepositoryItemLookUpEdit();
            //    RepositoryItemLookUpEdit rlueModul = new RepositoryItemLookUpEdit();

            //    BelgeUtil.Inits.perCariGetir(rlueCari);
            //    BelgeUtil.Inits.ModulGetir(rlueModul);

            //    #endregion RepositoryItem

            //    #region Properties

            //    //
            //    // colCARI_ID
            //    //
            //    colCARI_ID.Caption = "Adý";
            //    colCARI_ID.FieldName = "CARI_ID";
            //    colCARI_ID.Name = "colCARI_ID";
            //    colCARI_ID.Visible = true;
            //    colCARI_ID.VisibleIndex = 0;
            //    colCARI_ID.ColumnEdit = rlueCari;
            //    //
            //    // colREFERANS_NO
            //    //
            //    colREFERANS_NO.Caption = "Referans No";
            //    colREFERANS_NO.FieldName = "REFERANS_NO";
            //    colREFERANS_NO.Name = "colREFERANS_NO";
            //    colREFERANS_NO.Visible = true;
            //    colREFERANS_NO.VisibleIndex = 1;
            //    //
            //    // colMASRAF_AVANS_TIP
            //    //
            //    colMASRAF_AVANS_TIP.Caption = "Masraf Avans";
            //    colMASRAF_AVANS_TIP.FieldName = "MASRAF_AVANS_TIP";
            //    colMASRAF_AVANS_TIP.Name = "colMASRAF_AVANS_TIP";
            //    colMASRAF_AVANS_TIP.Visible = true;
            //    colMASRAF_AVANS_TIP.VisibleIndex = 2;
            //    //
            //    // colCARI_HESAP_HEDEF_TIP //Repository Item // modul
            //    //
            //    colCARI_HESAP_HEDEF_TIP.Caption = "Modül";
            //    colCARI_HESAP_HEDEF_TIP.FieldName = "CARI_HESAP_HEDEF_TIP";
            //    colCARI_HESAP_HEDEF_TIP.Name = "colCARI_HESAP_HEDEF_TIP";
            //    colCARI_HESAP_HEDEF_TIP.Visible = true;
            //    colCARI_HESAP_HEDEF_TIP.VisibleIndex = 3;
            //    colCARI_HESAP_HEDEF_TIP.ColumnEdit = rlueModul;
            //    //
            //    // colICRA_FOY_NO
            //    //
            //    colICRA_FOY_NO.Caption = "Ýcra Föy No";
            //    colICRA_FOY_NO.FieldName = "ICRA_FOY_NO";
            //    colICRA_FOY_NO.Name = "colICRA_FOY_NO";
            //    colICRA_FOY_NO.Visible = true;
            //    colICRA_FOY_NO.VisibleIndex = 4;
            //    //
            //    // colDAVA_FOY_NO
            //    //
            //    colDAVA_FOY_NO.Caption = "Dava Föy No";
            //    colDAVA_FOY_NO.FieldName = "DAVA_FOY_NO";
            //    colDAVA_FOY_NO.Name = "colDAVA_FOY_NO";
            //    colDAVA_FOY_NO.Visible = true;
            //    colDAVA_FOY_NO.VisibleIndex = 5;
            //    //
            //    // colHAZIRLIK_NO
            //    //
            //    colHAZIRLIK_NO.Caption = "Hazýrlýk No";
            //    colHAZIRLIK_NO.FieldName = "HAZIRLIK_NO";
            //    colHAZIRLIK_NO.Name = "colHAZIRLIK_NO";
            //    colHAZIRLIK_NO.Visible = true;
            //    colHAZIRLIK_NO.VisibleIndex = 6;
            //    //
            //    // colRUCU_NO
            //    //
            //    colRUCU_NO.Caption = "Rücu No";
            //    colRUCU_NO.FieldName = "RUCU_NO";
            //    colRUCU_NO.Name = "colRUCU_NO";
            //    colRUCU_NO.Visible = true;
            //    colRUCU_NO.VisibleIndex = 7;
            //    //
            //    // colACIKLAMA
            //    //
            //    colACIKLAMA.Caption = "Açýklama";
            //    colACIKLAMA.FieldName = "ACIKLAMA";
            //    colACIKLAMA.Name = "colACIKLAMA";
            //    colACIKLAMA.Visible = true;
            //    colACIKLAMA.VisibleIndex = 8;
            //    //
            //    // colKAYIT_TARIHI
            //    //
            //    colKAYIT_TARIHI.Caption = "Kayýt T";
            //    colKAYIT_TARIHI.FieldName = "KAYIT_TARIHI";
            //    colKAYIT_TARIHI.Name = "colKAYIT_TARIHI";
            //    colKAYIT_TARIHI.Visible = true;
            //    colKAYIT_TARIHI.VisibleIndex = 9;
            //    //
            //    // colKLASOR_KODU -- Kalkacak
            //    //
            //    colKLASOR_KODU.Caption = "KLASOR_KODU";
            //    colKLASOR_KODU.FieldName = "KLASOR_KODU";
            //    colKLASOR_KODU.Name = "colKLASOR_KODU";
            //    colKLASOR_KODU.Visible = false;
            //    colKLASOR_KODU.VisibleIndex = 10;
            //    //
            //    // colSUBE_KODU
            //    //
            //    colSUBE_KODU.Caption = "Þubesi";
            //    colSUBE_KODU.FieldName = "SUBE_KODU";
            //    colSUBE_KODU.Name = "colSUBE_KODU";
            //    colSUBE_KODU.Visible = true;
            //    colSUBE_KODU.VisibleIndex = 11;
            //    //
            //    // colKONTROL_NE_ZAMAN
            //    //
            //    colKONTROL_NE_ZAMAN.Caption = "KONTROL_NE_ZAMAN";
            //    colKONTROL_NE_ZAMAN.FieldName = "KONTROL_NE_ZAMAN";
            //    colKONTROL_NE_ZAMAN.Name = "colKONTROL_NE_ZAMAN";
            //    colKONTROL_NE_ZAMAN.Visible = false;
            //    colKONTROL_NE_ZAMAN.VisibleIndex = 12;
            //    //
            //    // colKONTROL_KIM
            //    //
            //    colKONTROL_KIM.Caption = "KONTROL_KIM";
            //    colKONTROL_KIM.FieldName = "KONTROL_KIM";
            //    colKONTROL_KIM.Name = "colKONTROL_KIM";
            //    colKONTROL_KIM.Visible = false;
            //    colKONTROL_KIM.VisibleIndex = 13;
            //    //
            //    // colKONTROL_VERSIYON
            //    //
            //    colKONTROL_VERSIYON.Caption = "KONTROL_VERSIYON";
            //    colKONTROL_VERSIYON.FieldName = "KONTROL_VERSIYON";
            //    colKONTROL_VERSIYON.Name = "colKONTROL_VERSIYON";
            //    colKONTROL_VERSIYON.Visible = false;
            //    colKONTROL_VERSIYON.VisibleIndex = 14;
            //    //
            //    // colSTAMP
            //    //
            //    colSTAMP.Caption = "STAMP";
            //    colSTAMP.FieldName = "STAMP";
            //    colSTAMP.Name = "colSTAMP";
            //    colSTAMP.Visible = false;
            //    colSTAMP.VisibleIndex = 15;
            //    //
            //    // colBORCLU_CARI_ID
            //    //
            //    colBORCLU_CARI_ID.Caption = "Borçlu Adý";
            //    colBORCLU_CARI_ID.FieldName = "BORCLU_CARI_ID";
            //    colBORCLU_CARI_ID.Name = "colBORCLU_CARI_ID";
            //    colBORCLU_CARI_ID.Visible = true;
            //    colBORCLU_CARI_ID.VisibleIndex = 16;
            //    colBORCLU_CARI_ID.ColumnEdit = rlueCari;
            //    //
            //    // colMANUEL_KAYIT_MI
            //    //
            //    colMANUEL_KAYIT_MI.Caption = "MANUEL_KAYIT_MI";
            //    colMANUEL_KAYIT_MI.FieldName = "MANUEL_KAYIT_MI";
            //    colMANUEL_KAYIT_MI.Name = "colMANUEL_KAYIT_MI";
            //    colMANUEL_KAYIT_MI.Visible = false;
            //    colMANUEL_KAYIT_MI.VisibleIndex = 17;

            //    #endregion Properties

            //    #region []

            //    GridColumn[] dizi = new[]
            //                            {
            //                                colCARI_ID,
            //                                colREFERANS_NO,
            //                                colMASRAF_AVANS_TIP,
            //                                colCARI_HESAP_HEDEF_TIP,
            //                                colICRA_FOY_NO,
            //                                colDAVA_FOY_NO,
            //                                colHAZIRLIK_NO,
            //                                colRUCU_NO,
            //                                colACIKLAMA,
            //                                colKAYIT_TARIHI,
            //                                colKLASOR_KODU,
            //                                colSUBE_KODU,
            //                                colKONTROL_NE_ZAMAN,
            //                                colKONTROL_KIM,
            //                                colKONTROL_VERSIYON,
            //                                colSTAMP,
            //                                colBORCLU_CARI_ID,
            //                                colMANUEL_KAYIT_MI
            //                            };

            //    #endregion []

            //    return dizi;
            //}
        }

        public class Kasa
        {

            public GridColumn[] GetKasaColumns()
            {
                #region Columns

                GridColumn colID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colHAREKET_CARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colSegmentId = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colBORC_ALACAK_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colADET = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colBIRIM_FIYAT = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colBIRIM_FIYAT_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                //GridColumn colTOPLAM_TUTAR = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colKDV_TUTAR = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colSTOPAJ_SSDF_TUTAR = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colGENEL_TOPLAM = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colBankaDekontNo = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colEFTReferansNo = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colREFERANS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colODEME_TIP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colHAREKET_ALT_KATEGORI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colKasaHesapId = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colMuhatapHesapId = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colKiymetliEvrakId = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colHAREKET_ANA_KATEGORI_ID = new DevExpress.XtraGrid.Columns.GridColumn();

                //GridColumn colBELGE_NO = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colTARIH = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colKAYIT_TARIHI = new GridColumn();
                //GridColumn colKLASOR_KODU = new DevExpress.XtraGrid.Columns.GridColumn();
                //GridColumn colSUBE_KODU = new DevExpress.XtraGrid.Columns.GridColumn();
                //GridColumn colKONTROL_NE_ZAMAN = new DevExpress.XtraGrid.Columns.GridColumn();
                //GridColumn colKONTROL_KIM = new DevExpress.XtraGrid.Columns.GridColumn();
                //GridColumn colKONTROL_VERSIYON = new DevExpress.XtraGrid.Columns.GridColumn();

                #endregion Columns

                #region RepositoryItem

                RepositoryItemLookUpEdit rlueCari = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueDoviz = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueBorcluAlacak = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueHareketAnaKategori = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueHareketAltKategori = new RepositoryItemLookUpEdit();
                RepositoryItemSpinEdit rSpinTutar = new RepositoryItemSpinEdit();
                RepositoryItemLookUpEdit rlueOdemeTipi = new RepositoryItemLookUpEdit();

                BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
                BelgeUtil.Inits.ParaBicimiAyarla(rSpinTutar);
                BelgeUtil.Inits.perCariGetir(rlueCari);
                BelgeUtil.Inits.BorcAlacakGetir(rlueBorcluAlacak);
                BelgeUtil.Inits.HareketAnaKategoriGetir(rlueHareketAnaKategori);
                BelgeUtil.Inits.OdemeTipiGetir(rlueOdemeTipi);
                AvukatPro.Services.Implementations.DevExpressService.SegmentDoldur(rlueSegment);
                AvukatPro.Services.Implementations.DevExpressService.AltKategoriDoldur(rlueHareketAltKategori);

                #endregion RepositoryItem

                #region Properties
                //
                // colID
                //
                colID.Caption = "ID";
                colID.FieldName = "Id";
                colID.Name = "colID";
                colID.Visible = false;
                colID.VisibleIndex = -1;
                //
                // colHAREKET_CARI_ID
                //
                colHAREKET_CARI_ID.Caption = "Þahýs Adý";
                colHAREKET_CARI_ID.FieldName = "HareketCariId";
                colHAREKET_CARI_ID.ColumnEdit = rlueCari;
                colHAREKET_CARI_ID.Name = "colHAREKET_CARI_ID";
                colHAREKET_CARI_ID.Visible = true;
                colHAREKET_CARI_ID.VisibleIndex = 0;

                //
                // colSegmentId
                //
                colSegmentId.Caption = "Bölüm";
                colSegmentId.FieldName = "SegmentId";
                colSegmentId.ColumnEdit = rlueSegment;
                colSegmentId.Name = "colSegmentId";
                colSegmentId.Visible = true;
                colSegmentId.VisibleIndex = 1;
                //
                // colBORC_ALACAK_ID 
                //
                colBORC_ALACAK_ID.Caption = "B/A";
                colBORC_ALACAK_ID.FieldName = "BorcAlacakId";
                colBORC_ALACAK_ID.Name = "colBORC_ALACAK_ID";
                colBORC_ALACAK_ID.Visible = true;
                colBORC_ALACAK_ID.VisibleIndex = 2;
                colBORC_ALACAK_ID.ColumnEdit = rlueBorcluAlacak;
                //
                // colADET
                //
                colADET.Caption = "Adet";
                colADET.FieldName = "Adet";
                colADET.Name = "colADET";
                colADET.Visible = true;
                colADET.VisibleIndex = 3;
                //
                // colBIRIM_FIYAT
                //
                colBIRIM_FIYAT.Caption = "Birim Fiyat";
                colBIRIM_FIYAT.FieldName = "BirimFiyat";
                colBIRIM_FIYAT.Name = "colBIRIM_FIYAT";
                colBIRIM_FIYAT.Visible = true;
                colBIRIM_FIYAT.ColumnEdit = rSpinTutar;
                colBIRIM_FIYAT.VisibleIndex = 4;
                //
                // colBIRIM_FIYAT_DOVIZ_ID
                //
                colBIRIM_FIYAT_DOVIZ_ID.Caption = "Brm";
                colBIRIM_FIYAT_DOVIZ_ID.FieldName = "BirimFiyatDovizId";
                colBIRIM_FIYAT_DOVIZ_ID.Name = "colBIRIM_FIYAT_DOVIZ_ID";
                colBIRIM_FIYAT_DOVIZ_ID.Visible = true;
                colBIRIM_FIYAT_DOVIZ_ID.VisibleIndex = 5;
                colBIRIM_FIYAT_DOVIZ_ID.ColumnEdit = rlueDoviz;
                ////
                //// colTOPLAM_TUTAR
                ////
                //colTOPLAM_TUTAR.Caption = "Toplam Tutar";
                //colTOPLAM_TUTAR.FieldName = "ToplamTutar";
                //colTOPLAM_TUTAR.Name = "colTOPLAM_TUTAR";
                //colTOPLAM_TUTAR.ColumnEdit = rSpinTutar;
                //colTOPLAM_TUTAR.Visible = true;
                //colTOPLAM_TUTAR.VisibleIndex = 6;
                ////
                //// colTOPLAM_TUTAR_DOVIZ_ID
                ////
                //colTOPLAM_TUTAR_DOVIZ_ID.Caption = "";
                //colTOPLAM_TUTAR_DOVIZ_ID.FieldName = "ToplamTutarDovizId";
                //colTOPLAM_TUTAR_DOVIZ_ID.Name = "colTOPLAM_TUTAR_DOVIZ_ID";
                //colTOPLAM_TUTAR_DOVIZ_ID.ColumnEdit = rlueMDoviz;
                //colTOPLAM_TUTAR_DOVIZ_ID.Visible = true;
                //colTOPLAM_TUTAR_DOVIZ_ID.VisibleIndex = 7;
                //
                // colKDV_TUTAR
                //
                colKDV_TUTAR.Caption = "KDV Tutar";
                colKDV_TUTAR.FieldName = "KdvTutar";
                colKDV_TUTAR.Name = "colKDV_TUTAR";
                colKDV_TUTAR.ColumnEdit = rSpinTutar;
                colKDV_TUTAR.Visible = true;
                colKDV_TUTAR.VisibleIndex = 7;
                //
                // colSTOPAJ_SSDF_TUTAR
                //
                colSTOPAJ_SSDF_TUTAR.Caption = "Stopaj SSDF Tutarý";
                colSTOPAJ_SSDF_TUTAR.FieldName = "StopajSsdfTutar";
                colSTOPAJ_SSDF_TUTAR.Name = "colSTOPAJ_SSDF_TUTAR";
                colSTOPAJ_SSDF_TUTAR.ColumnEdit = rSpinTutar;
                colSTOPAJ_SSDF_TUTAR.Visible = true;
                colSTOPAJ_SSDF_TUTAR.VisibleIndex = 8;
                //
                // colGENEL_TOPLAM
                //
                colGENEL_TOPLAM.Caption = "Genel Toplam";
                colGENEL_TOPLAM.FieldName = "GenelToplam";
                colGENEL_TOPLAM.Name = "colGENEL_TOPLAM";
                colGENEL_TOPLAM.ColumnEdit = rSpinTutar;
                colGENEL_TOPLAM.Visible = true;
                colGENEL_TOPLAM.VisibleIndex = 9;
                ////
                //// colGENEL_TOPLAM_DOVIZ_ID
                ////
                //colGENEL_TOPLAM_DOVIZ_ID.Caption = "";
                //colGENEL_TOPLAM_DOVIZ_ID.FieldName = "GenelToplamDovizId";
                //colGENEL_TOPLAM_DOVIZ_ID.Name = "colGENEL_TOPLAM_DOVIZ_ID";
                //colGENEL_TOPLAM_DOVIZ_ID.ColumnEdit = rlueMDoviz;
                //colGENEL_TOPLAM_DOVIZ_ID.Visible = true;
                //colGENEL_TOPLAM_DOVIZ_ID.VisibleIndex = 11;
                //
                // colBankaDekontNo
                //
                colBankaDekontNo.Caption = "Dekont No";
                colBankaDekontNo.FieldName = "BankaDekontNo";
                colBankaDekontNo.Name = "colBankaDekontNo";
                colBankaDekontNo.Visible = true;
                colBankaDekontNo.VisibleIndex = 10;
                //
                // colEFTReferansNo
                //
                colEFTReferansNo.Caption = "Eft Referans";
                colEFTReferansNo.FieldName = "EftReferansNo";
                colEFTReferansNo.Name = "colEFTReferansNo";
                colEFTReferansNo.Visible = true;
                colEFTReferansNo.VisibleIndex = 11;
                //
                // colREFERANS_NO
                //
                colREFERANS_NO.Caption = "Referans";
                colREFERANS_NO.FieldName = "ReferansNo";
                colREFERANS_NO.Name = "colREFERANS_NO";
                colREFERANS_NO.Visible = true;
                colREFERANS_NO.VisibleIndex = 12;
                //
                // colODEME_TIP_ID 
                //
                colODEME_TIP_ID.Caption = "Ödeme Tipi";
                colODEME_TIP_ID.FieldName = "OdemeTipId";
                colODEME_TIP_ID.Name = "colODEME_TIP_ID";
                colODEME_TIP_ID.Visible = true;
                colODEME_TIP_ID.VisibleIndex = 13;
                colODEME_TIP_ID.ColumnEdit = rlueOdemeTipi;
                //
                // colHAREKET_ALT_KATEGORI_ID
                //
                colHAREKET_ALT_KATEGORI_ID.Caption = "Alt Kategori";
                colHAREKET_ALT_KATEGORI_ID.FieldName = "HareketAltKategoriId";
                colHAREKET_ALT_KATEGORI_ID.Name = "colHAREKET_ALT_KATEGORI_ID";
                colHAREKET_ALT_KATEGORI_ID.Visible = false;
                colHAREKET_ALT_KATEGORI_ID.VisibleIndex = -1;
                colHAREKET_ALT_KATEGORI_ID.ColumnEdit = rlueHareketAnaKategori;
                //
                // colHAREKET_ANA_KATEGORI_ID
                //
                colHAREKET_ANA_KATEGORI_ID.Caption = "Ana Kategori";
                colHAREKET_ANA_KATEGORI_ID.FieldName = "HareketAnaKategoriId";
                colHAREKET_ANA_KATEGORI_ID.Name = "colHAREKET_ANA_KATEGORI_ID";
                colHAREKET_ANA_KATEGORI_ID.Visible = false;
                colHAREKET_ANA_KATEGORI_ID.VisibleIndex = -1;
                colHAREKET_ANA_KATEGORI_ID.ColumnEdit = rlueHareketAnaKategori;
                //
                // colKasaHesapId
                //
                colKasaHesapId.Caption = "Kasa Hesap";
                colKasaHesapId.FieldName = "KasaHesapSahibiCariBankaId";
                colKasaHesapId.Name = "colKasaHesapId";
                colKasaHesapId.Visible = false;
                colKasaHesapId.VisibleIndex = -1;
                //
                // colMuhatapHesapId
                //
                colMuhatapHesapId.Caption = "Muhatap Hesap";
                colMuhatapHesapId.FieldName = "MuhatapHesapSahibiCariBankaId";
                colMuhatapHesapId.Name = "colMuhatapHesapId";
                colMuhatapHesapId.Visible = false;
                colMuhatapHesapId.VisibleIndex = -1;
                //
                // colKiymetliEvrakId
                //
                colKiymetliEvrakId.Caption = "";
                colKiymetliEvrakId.FieldName = "KiymetliEvrakId";
                colKiymetliEvrakId.Name = "colKiymetliEvrakId";
                colKiymetliEvrakId.Visible = false;
                colKiymetliEvrakId.VisibleIndex = -1;


                // colKAYIT_TARIHI

                colKAYIT_TARIHI.Caption = "Kayýt Tarihi";
                colKAYIT_TARIHI.FieldName = "KayitTarihi";
                colKAYIT_TARIHI.Name = "colKAYIT_TARIHI";
                colKAYIT_TARIHI.Visible = true;
                colKAYIT_TARIHI.VisibleIndex = 12;
                ////
                //// colKLASOR_KODU
                ////
                //colKLASOR_KODU.Caption = "Klasör Kodu";
                //colKLASOR_KODU.FieldName = "KLASOR_KODU";
                //colKLASOR_KODU.Name = "colKLASOR_KODU";
                //colKLASOR_KODU.Visible = false;
                //colKLASOR_KODU.VisibleIndex = 13;
                ////
                //// colSUBE_KODU
                ////
                //colSUBE_KODU.Caption = "Þubesi";
                //colSUBE_KODU.FieldName = "SUBE_KODU";
                //colSUBE_KODU.Name = "colSUBE_KODU";
                //colSUBE_KODU.Visible = true;
                //colSUBE_KODU.VisibleIndex = 14;
                ////
                //// colKONTROL_NE_ZAMAN
                ////
                //colKONTROL_NE_ZAMAN.Caption = "Kontrol Ne Zaman";
                //colKONTROL_NE_ZAMAN.FieldName = "KONTROL_NE_ZAMAN";
                //colKONTROL_NE_ZAMAN.Name = "colKONTROL_NE_ZAMAN";
                //colKONTROL_NE_ZAMAN.Visible = false;
                //colKONTROL_NE_ZAMAN.VisibleIndex = 15;
                ////
                //// colKONTROL_KIM
                ////
                //colKONTROL_KIM.Caption = "Kontrol Kim";
                //colKONTROL_KIM.FieldName = "KONTROL_KIM";
                //colKONTROL_KIM.Name = "colKONTROL_KIM";
                //colKONTROL_KIM.Visible = false;
                //colKONTROL_KIM.VisibleIndex = 16;
                ////
                //// colKONTROL_VERSIYON
                ////
                //colKONTROL_VERSIYON.Caption = "Kontrol Versiyon";
                //colKONTROL_VERSIYON.FieldName = "KONTROL_VERSIYON";
                //colKONTROL_VERSIYON.Name = "colKONTROL_VERSIYON";
                //colKONTROL_VERSIYON.Visible = false;
                //colKONTROL_VERSIYON.VisibleIndex = 17;          
                //
                // colACIKLAMA
                //
                colACIKLAMA.Caption = "Açýklama";
                colACIKLAMA.FieldName = "Aciklama";
                colACIKLAMA.Name = "colACIKLAMA";
                colACIKLAMA.Visible = true;
                colACIKLAMA.VisibleIndex = 11;
                ////
                //// colBELGE_NO
                ////
                //colBELGE_NO.Caption = "Belge No";
                //colBELGE_NO.FieldName = "BelgeNo";
                //colBELGE_NO.Name = "colBELGE_NO";
                //colBELGE_NO.Visible = true;
                //colBELGE_NO.VisibleIndex = 3;

                //
                // colTARIH
                //
                colTARIH.Caption = "Tarih";
                colTARIH.FieldName = "Tarih";
                colTARIH.Name = "colTARIH";
                colTARIH.Visible = true;
                colTARIH.VisibleIndex = 15;

                #endregion Properties

                #region Summary
                colGENEL_TOPLAM.SummaryItem.Assign(Util.GetSummaryItemByField(colGENEL_TOPLAM));
                colKDV_TUTAR.SummaryItem.Assign(Util.GetSummaryItemByField(colKDV_TUTAR));
                colSTOPAJ_SSDF_TUTAR.SummaryItem.Assign(Util.GetSummaryItemByField(colSTOPAJ_SSDF_TUTAR));
                colADET.SummaryItem.Assign(Util.GetSummaryItemByFieldNumeric(colADET));

                #endregion Summary

                #region []

                GridColumn[] dizi = new[]
                                            {
                                                colID,
                                                colHAREKET_CARI_ID ,
                                                colSegmentId ,
                                                colBORC_ALACAK_ID,
                                                colADET ,
                                                colBIRIM_FIYAT ,                                                
                                                colBIRIM_FIYAT_DOVIZ_ID,
                                                //colTOPLAM_TUTAR ,
                                                colKDV_TUTAR ,
                                                colSTOPAJ_SSDF_TUTAR ,
                                                colGENEL_TOPLAM ,
                                                colBankaDekontNo ,
                                                colEFTReferansNo ,
                                                colREFERANS_NO ,
                                                colODEME_TIP_ID ,
                                                colHAREKET_ALT_KATEGORI_ID ,
                                                colKasaHesapId,
                                                colMuhatapHesapId ,
                                                colKiymetliEvrakId,
                                                colHAREKET_ANA_KATEGORI_ID,
                                                colTARIH,
                                                colKAYIT_TARIHI,
                                                colACIKLAMA
                                            };

                #endregion []

                foreach (var item in dizi)
                {
                    item.OptionsColumn.ReadOnly = true;
                    item.OptionsColumn.AllowEdit = false;
                }

                return dizi;
            }
        }

        public class Fatura //serbest meslek makbuzu
        {

            public GridColumn[] GetFaturaColumns()
            {
                #region Columns

                GridColumn colID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colCARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colSegmentId = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colFATURA_HEDEF_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colFATURA_TARIH = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colAdet = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colBirimFiyat = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colTOPLAM = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colKDV = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colSTOPAJ_TUTAR = new GridColumn();
                GridColumn colSSDF_TUTAR = new GridColumn();
                GridColumn colGENEL_TOPLAM = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colGENEL_TOPLAM_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colKonu = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colREFERANS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colFOY_NO = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colADLI_BIRIM_ADLIYE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colADLI_BIRIM_NO_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colADLI_BIRIM_GOREV_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colESAS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
                //GridColumn colSERI_NO = new DevExpress.XtraGrid.Columns.GridColumn();
                //GridColumn colACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
                //GridColumn colKONTROL_KIM_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                //GridColumn colSUBE_KOD_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                //GridColumn colICRA_FOY_NO = new DevExpress.XtraGrid.Columns.GridColumn();
                //GridColumn colDAVA_FOY_NO = new DevExpress.XtraGrid.Columns.GridColumn();
                //GridColumn colHAZIRLIK_NO = new DevExpress.XtraGrid.Columns.GridColumn();
                //GridColumn colKAYIT_TARIHI = new GridColumn();
                #endregion Columns

                #region RepositoryItem

                BelgeUtil.Inits.ModulGetir(rlueDosyaTipi);
                BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
                //BelgeUtil.Inits.KontrolKimGetir(rlueKontrolKim);
                //BelgeUtil.Inits.SubeKodGetir(rlueSubeKod);
                BelgeUtil.Inits.ParaBicimiAyarla(rlueTutar);
                BelgeUtil.Inits.perCariGetir(rlueCari);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliye);
                BelgeUtil.Inits.AdliBirimNoGetir(rlueAdliNo);
                BelgeUtil.Inits.AdliBirimGorevGetir(rlueAdliGorev);
                AvukatPro.Services.Implementations.DevExpressService.SegmentDoldur(rlueSegment);

                #endregion RepositoryItem

                #region Properties
                //
                // colID
                //
                colID.Caption = "ID";
                colID.FieldName = "Id";
                colID.Name = "colID";
                colID.Visible = false;
                colID.VisibleIndex = -1;
                //
                // colCARI_ID
                //
                colCARI_ID.FieldName = "CariId";
                colCARI_ID.Name = "colCARI_ID";
                colCARI_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                colCARI_ID.Visible = true;
                colCARI_ID.VisibleIndex = 0;
                colCARI_ID.Caption = "Müvekkil";
                colCARI_ID.ColumnEdit = rlueCari;
                //
                // colSegmentId
                //

                colSegmentId.Caption = "Bölüm";
                colSegmentId.ColumnEdit = rlueSegment;
                colSegmentId.FieldName = "SegmentId";
                colSegmentId.Name = "colSegmentId";
                colSegmentId.Visible = true;
                colSegmentId.VisibleIndex = 1;
                //
                // colFATURA_HEDEF_TIP
                //
                colFATURA_HEDEF_TIP.FieldName = "FaturaHedefTip";
                colFATURA_HEDEF_TIP.Name = "colFATURA_HEDEF_TIP";
                colFATURA_HEDEF_TIP.ColumnEdit = rlueDosyaTipi;
                colFATURA_HEDEF_TIP.OptionsFilter.AutoFilterCondition =
                    DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                colFATURA_HEDEF_TIP.Visible = true;
                colFATURA_HEDEF_TIP.Caption = "Hedef Tip";
                colFATURA_HEDEF_TIP.VisibleIndex = 2;
                //
                // colFATURA_TARIH
                //
                colFATURA_TARIH.FieldName = "FaturaTarih";
                colFATURA_TARIH.Name = "colFATURA_TARIH";
                colFATURA_TARIH.OptionsFilter.AutoFilterCondition =
                    DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                colFATURA_TARIH.OptionsFilter.FilterPopupMode =
                    DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
                colFATURA_TARIH.Visible = true;
                colFATURA_TARIH.Caption = "Fatura T.";
                colFATURA_TARIH.VisibleIndex = 3;
                //
                //colAdet
                //
                colAdet.FieldName = "Adet";
                colAdet.Name = "colAdet";
                colAdet.OptionsFilter.AutoFilterCondition =
                    DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                colAdet.Visible = true;
                colAdet.VisibleIndex = 4;
                colAdet.Caption = "Adet";
                //
                //colBirimFiyat
                //
                colBirimFiyat.FieldName = "BirimTutar";
                colBirimFiyat.Name = "colBirimFiyat";
                colBirimFiyat.OptionsFilter.AutoFilterCondition =
                    DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                colBirimFiyat.Visible = true;
                colBirimFiyat.VisibleIndex = 5;
                colBirimFiyat.Caption = "Birim Fiyat";
                colBirimFiyat.ColumnEdit = rlueTutar;
                //
                // colTOPLAM
                //
                colTOPLAM.FieldName = "Toplam";
                colTOPLAM.Name = "colTOPLAM";
                colTOPLAM.OptionsFilter.AutoFilterCondition =
                    DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                colTOPLAM.Visible = true;
                colTOPLAM.VisibleIndex = 6;
                colTOPLAM.Caption = "Toplam";
                colTOPLAM.ColumnEdit = rlueTutar;
                //
                // colKDV
                //
                colKDV.FieldName = "KdvTutar";
                colKDV.Name = "colKDV";
                colKDV.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                colKDV.Visible = true;
                colKDV.VisibleIndex = 7;
                colKDV.Caption = "KDV";
                colKDV.ColumnEdit = rlueTutar;
                //
                // colSTOPAJ_TUTAR
                //
                colSTOPAJ_TUTAR.Caption = "Stopaj";
                colSTOPAJ_TUTAR.FieldName = "StopajTutar";
                colSTOPAJ_TUTAR.Name = "colSTOPAJ_TUTAR";
                colSTOPAJ_TUTAR.ColumnEdit = rlueTutar;
                colSTOPAJ_TUTAR.Visible = true;
                colSTOPAJ_TUTAR.VisibleIndex = 8;
                //
                // colSSDF_TUTAR
                //
                colSSDF_TUTAR.Caption = "SSDF";
                colSSDF_TUTAR.FieldName = "SsdfTutar";
                colSSDF_TUTAR.Name = "colSSDF_TUTAR";
                colSSDF_TUTAR.ColumnEdit = rlueTutar;
                colSSDF_TUTAR.Visible = true;
                colSSDF_TUTAR.VisibleIndex = 9;
                //
                // colGENEL_TOPLAM
                //
                colGENEL_TOPLAM.Caption = "Genel Toplam";
                colGENEL_TOPLAM.FieldName = "GenelToplam";
                colGENEL_TOPLAM.Name = "colGENEL_TOPLAM";
                colGENEL_TOPLAM.ColumnEdit = rlueTutar;
                colGENEL_TOPLAM.Visible = true;
                colGENEL_TOPLAM.VisibleIndex = 10;
                //
                // colGENEL_TOPLAM_DOVIZ_ID
                //
                colGENEL_TOPLAM_DOVIZ_ID.Caption = "Br.";
                colGENEL_TOPLAM_DOVIZ_ID.FieldName = "GenelToplamDovizId";
                colGENEL_TOPLAM_DOVIZ_ID.Name = "colGENEL_TOPLAM_DOVIZ_ID";
                colGENEL_TOPLAM_DOVIZ_ID.ColumnEdit = rlueDoviz;
                colGENEL_TOPLAM_DOVIZ_ID.Visible = true;
                colGENEL_TOPLAM_DOVIZ_ID.VisibleIndex = 11;
                //
                // colREFERANS_NO
                //
                colREFERANS_NO.FieldName = "ReferansNo";
                colREFERANS_NO.Name = "colREFERANS_NO";
                colREFERANS_NO.OptionsFilter.AutoFilterCondition =
                DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                colREFERANS_NO.Visible = true;
                colREFERANS_NO.Caption = "Referans No";
                colREFERANS_NO.VisibleIndex = 12;
                //
                // colFOY_NO
                //
                colFOY_NO.Caption = "Dosya No";
                colFOY_NO.FieldName = "FoyNo";
                colFOY_NO.Name = "colFOY_NO";
                colFOY_NO.Visible = true;
                colFOY_NO.VisibleIndex = 13;
                //
                // colADLI_BIRIM_ADLIYE_ID
                //
                colADLI_BIRIM_ADLIYE_ID.Caption = "Adliye";
                colADLI_BIRIM_ADLIYE_ID.FieldName = "AdliBirimAdliyeId";
                colADLI_BIRIM_ADLIYE_ID.Name = "colADLI_BIRIM_ADLIYE_ID";
                colADLI_BIRIM_ADLIYE_ID.ColumnEdit = rlueAdliye;
                colADLI_BIRIM_ADLIYE_ID.Visible = true;
                colADLI_BIRIM_ADLIYE_ID.VisibleIndex = 14;
                //
                // colADLI_BIRIM_NO_ID
                //
                colADLI_BIRIM_NO_ID.Caption = "No";
                colADLI_BIRIM_NO_ID.FieldName = "AdliBirimNoId";
                colADLI_BIRIM_NO_ID.Name = "colADLI_BIRIM_NO_ID";
                colADLI_BIRIM_NO_ID.ColumnEdit = rlueAdliNo;
                colADLI_BIRIM_NO_ID.Visible = true;
                colADLI_BIRIM_NO_ID.VisibleIndex = 15;
                //
                // colADLI_BIRIM_GOREV_ID
                //
                colADLI_BIRIM_GOREV_ID.Caption = "Görev";
                colADLI_BIRIM_GOREV_ID.FieldName = "AdliBirimGorevId";
                colADLI_BIRIM_GOREV_ID.Name = "colADLI_BIRIM_GOREV_ID";
                colADLI_BIRIM_GOREV_ID.ColumnEdit = rlueAdliGorev;
                colADLI_BIRIM_GOREV_ID.Visible = true;
                colADLI_BIRIM_GOREV_ID.VisibleIndex = 16;
                //
                // colESAS_NO
                //
                colESAS_NO.Caption = "Esas No";
                colESAS_NO.FieldName = "EsasNo";
                colESAS_NO.Name = "colESAS_NO";
                colESAS_NO.Visible = true;
                colESAS_NO.VisibleIndex = 17;
                ////
                ////colKAYIT_TARIHI
                ////
                //colKAYIT_TARIHI.VisibleIndex = 18;
                //colKAYIT_TARIHI.Caption = "Kayýt Tarihi";
                //colKAYIT_TARIHI.FieldName = "KayitTarihi";
                //colKAYIT_TARIHI.Name = "colKAYIT_TARIHI";
                //colKAYIT_TARIHI.Visible = true;
                ////
                //// colTOPLAM_DOVIZ_ID
                ////
                //colTOPLAM_DOVIZ_ID.CustomizationCaption = "TOPLAM_DOVIZ_ID";
                //colTOPLAM_DOVIZ_ID.FieldName = "ToplamDovizId";
                //colTOPLAM_DOVIZ_ID.Name = "colTOPLAM_DOVIZ_ID";
                //colTOPLAM_DOVIZ_ID.OptionsFilter.AutoFilterCondition =
                //    DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                //colTOPLAM_DOVIZ_ID.ToolTip = "TOPLAM Birim";
                //colTOPLAM_DOVIZ_ID.Visible = true;
                //colTOPLAM_DOVIZ_ID.VisibleIndex = 11;
                //colTOPLAM_DOVIZ_ID.Width = 30;
                //colTOPLAM_DOVIZ_ID.Caption = "Toplam Brm";
                //colTOPLAM_DOVIZ_ID.ColumnEdit = rlueDoviz;
                ////
                //// colKDV_DOVIZ_ID
                ////
                //colKDV_DOVIZ_ID.CustomizationCaption = "Kdv para birimi";
                //colKDV_DOVIZ_ID.FieldName = "KdvDovizId";
                //colKDV_DOVIZ_ID.Name = "colKDV_DOVIZ_ID";
                //colKDV_DOVIZ_ID.OptionsFilter.AutoFilterCondition =
                //    DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                //colKDV_DOVIZ_ID.ToolTip = "KDV Birim";
                //colKDV_DOVIZ_ID.Visible = true;
                //colKDV_DOVIZ_ID.VisibleIndex = 9;
                //colKDV_DOVIZ_ID.Caption = "";
                //colKDV_DOVIZ_ID.Width = 30;
                //colKDV_DOVIZ_ID.ColumnEdit = rlueDoviz;
                ////
                //// colSERI_NO
                ////
                //colSERI_NO.FieldName = "SeriNo";
                //colSERI_NO.Name = "colSERI_NO";
                //colSERI_NO.OptionsFilter.AutoFilterCondition =
                //    DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                //colSERI_NO.Visible = true;
                //colSERI_NO.Caption = "Seri No";
                //colSERI_NO.VisibleIndex = 14;
                ////
                //// colACIKLAMA
                ////
                //colACIKLAMA.FieldName = "Aciklama";
                //colACIKLAMA.Name = "colACIKLAMA";
                //colACIKLAMA.OptionsFilter.AutoFilterCondition =
                //    DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                //colACIKLAMA.Visible = true;
                //colACIKLAMA.Caption = "Açýklama";
                //colACIKLAMA.VisibleIndex = 15;
                ////
                //// colKONTROL_KIM_ID
                ////
                //colKONTROL_KIM_ID.FieldName = "KontrolKimId";
                //colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
                //colKONTROL_KIM_ID.OptionsFilter.AutoFilterCondition =
                //    DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                //colKONTROL_KIM_ID.Visible = true;
                //colKONTROL_KIM_ID.VisibleIndex = 16;
                //colKONTROL_KIM_ID.Caption = "Kullanici";
                //colKONTROL_KIM_ID.ColumnEdit = rlueKontrolKim;
                ////
                //// colSUBE_KOD_ID
                ////
                //colSUBE_KOD_ID.FieldName = "SubeKodId";
                //colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
                //colSUBE_KOD_ID.OptionsFilter.AutoFilterCondition =
                //    DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                //colSUBE_KOD_ID.Visible = true;
                //colSUBE_KOD_ID.Caption = "Büro";
                //colSUBE_KOD_ID.VisibleIndex = 17;
                //colSUBE_KOD_ID.ColumnEdit = rlueSubeKod;
                ////
                //// colICRA_FOY_NO
                ////
                //colICRA_FOY_NO.FieldName = "IcraFoyNo";
                //colICRA_FOY_NO.Name = "colICRA_FOY_NO";
                //colICRA_FOY_NO.OptionsFilter.AutoFilterCondition =
                //    DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                //colICRA_FOY_NO.Visible = true;
                //colICRA_FOY_NO.Caption = "Icra Dosya No";
                //colICRA_FOY_NO.VisibleIndex = 2;
                ////
                //// colDAVA_FOY_NO
                ////
                //colDAVA_FOY_NO.FieldName = "DavaFoyNo";
                //colDAVA_FOY_NO.Name = "colDAVA_FOY_NO";
                //colDAVA_FOY_NO.OptionsFilter.AutoFilterCondition =
                //    DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                //colDAVA_FOY_NO.Visible = true;
                //colDAVA_FOY_NO.Caption = "Dava Dosya No";
                //colDAVA_FOY_NO.VisibleIndex = 3;
                ////
                //// colHAZIRLIK_NO
                ////
                //colHAZIRLIK_NO.FieldName = "HazirlikNo";
                //colHAZIRLIK_NO.Name = "colHAZIRLIK_NO";
                //colHAZIRLIK_NO.OptionsFilter.AutoFilterCondition =
                //    DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                //colHAZIRLIK_NO.Visible = true;
                //colDAVA_FOY_NO.Caption = "Soruþturma Dosya No";
                //colHAZIRLIK_NO.VisibleIndex = 4;
                ////
                //// colFATURA_KAPSAM_TIP
                ////
                //colFATURA_KAPSAM_TIP.FieldName = "FaturaKapsamTip";
                //colFATURA_KAPSAM_TIP.Name = "colFATURA_KAPSAM_TIP";
                //colFATURA_KAPSAM_TIP.ColumnEdit = rlueFaturaKapsamTip;
                //colFATURA_KAPSAM_TIP.OptionsFilter.AutoFilterCondition =
                //    DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                //colFATURA_KAPSAM_TIP.Visible = true;
                //colFATURA_KAPSAM_TIP.Caption = "Fatura Kapsam Tip";
                //colFATURA_KAPSAM_TIP.VisibleIndex = 5;

                #endregion Properties

                #region Summary

                colTOPLAM.SummaryItem.Assign(Util.GetSummaryItemByField(colTOPLAM));
                colKDV.SummaryItem.Assign(Util.GetSummaryItemByField(colKDV));
                colSTOPAJ_TUTAR.SummaryItem.Assign(Util.GetSummaryItemByField(colSTOPAJ_TUTAR));
                colSSDF_TUTAR.SummaryItem.Assign(Util.GetSummaryItemByField(colSSDF_TUTAR));
                colGENEL_TOPLAM.SummaryItem.Assign(Util.GetSummaryItemByField(colGENEL_TOPLAM));
                colAdet.SummaryItem.Assign(Util.GetSummaryItemByFieldNumeric(colAdet));

                #endregion Summary

                #region[]

                GridColumn[] dizi = new[]
                                            {
                                                colID,
                                                colCARI_ID ,
                                                colSegmentId ,
                                                colFATURA_HEDEF_TIP,
                                                colFATURA_TARIH ,
                                                colAdet,
                                                colBirimFiyat ,
                                                colTOPLAM ,
                                                colKDV ,
                                                colSTOPAJ_TUTAR,
                                                colSSDF_TUTAR,
                                                colGENEL_TOPLAM ,
                                                colGENEL_TOPLAM_DOVIZ_ID,
                                                colKonu ,
                                                colREFERANS_NO ,
                                                colFOY_NO ,
                                                colADLI_BIRIM_ADLIYE_ID,
                                                colADLI_BIRIM_NO_ID,
                                                colADLI_BIRIM_GOREV_ID ,
                                                colESAS_NO
                                                //colKAYIT_TARIHI
                                            };

                #endregion

                foreach (var item in dizi)
                {
                    item.OptionsColumn.ReadOnly = true;
                    item.OptionsColumn.AllowEdit = false;
                }

                return dizi;
            }

            public GridColumn[] GetFaturaIcColumns()
            {
                #region Columns

                GridColumn colID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colCARI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colSegmentId = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colFATURA_HEDEF_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colFATURA_TARIH = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colAdet = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colBirimFiyat = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colTOPLAM = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colKDV = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colSTOPAJ_TUTAR = new GridColumn();
                GridColumn colSSDF_TUTAR = new GridColumn();
                GridColumn colGENEL_TOPLAM = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colGENEL_TOPLAM_DOVIZ_ID = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colKonu = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colREFERANS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colKAYIT_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
                #endregion Columns

                #region RepositoryItem

                BelgeUtil.Inits.FaturaHedefTipGetir(rlueDosyaTipi);
                BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
                BelgeUtil.Inits.ParaBicimiAyarla(rlueTutar);
                BelgeUtil.Inits.perCariGetir(rlueCari);
                AvukatPro.Services.Implementations.DevExpressService.SegmentDoldur(rlueSegment);

                #endregion RepositoryItem

                #region Properties
                //
                // colID
                //
                colID.Caption = "ID";
                colID.FieldName = "Id";
                colID.Name = "colID";
                colID.Visible = false;
                colID.VisibleIndex = -1;
                //
                // colCARI_ID
                //
                colCARI_ID.FieldName = "CariId";
                colCARI_ID.Name = "colCARI_ID";
                colCARI_ID.OptionsFilter.AutoFilterCondition =
                    DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                colCARI_ID.Visible = true;
                colCARI_ID.VisibleIndex = 0;
                colCARI_ID.Caption = "Müvekkil";
                colCARI_ID.ColumnEdit = rlueCari;
                //
                // colSegmentId
                //

                colSegmentId.Caption = "Bölüm";
                colSegmentId.ColumnEdit = rlueSegment;
                colSegmentId.FieldName = "SegmentId";
                colSegmentId.Name = "colSegmentId";
                colSegmentId.Visible = true;
                colSegmentId.VisibleIndex = 1;
                //
                // colFATURA_HEDEF_TIP
                //
                colFATURA_HEDEF_TIP.FieldName = "FaturaHedefTip";
                colFATURA_HEDEF_TIP.Name = "colFATURA_HEDEF_TIP";
                colFATURA_HEDEF_TIP.ColumnEdit = rlueDosyaTipi;
                colFATURA_HEDEF_TIP.OptionsFilter.AutoFilterCondition =
                    DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                colFATURA_HEDEF_TIP.Visible = true;
                colFATURA_HEDEF_TIP.Caption = "Hedef Tip";
                colFATURA_HEDEF_TIP.VisibleIndex = 2;
                //
                // colFATURA_TARIH
                //
                colFATURA_TARIH.FieldName = "FaturaTarih";
                colFATURA_TARIH.Name = "colFATURA_TARIH";
                colFATURA_TARIH.OptionsFilter.AutoFilterCondition =
                    DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                colFATURA_TARIH.OptionsFilter.FilterPopupMode =
                    DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
                colFATURA_TARIH.Visible = true;
                colFATURA_TARIH.Caption = "Fatura T.";
                colFATURA_TARIH.VisibleIndex = 3;
                //
                //colAdet
                //
                colAdet.FieldName = "Adet";
                colAdet.Name = "colAdet";
                colAdet.OptionsFilter.AutoFilterCondition =
                    DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                colAdet.Visible = true;
                colAdet.VisibleIndex = 4;
                colAdet.Caption = "Adet";
                //
                //colBirimFiyat
                //
                colBirimFiyat.FieldName = "BirimTutar";
                colBirimFiyat.Name = "colBirimFiyat";
                colBirimFiyat.OptionsFilter.AutoFilterCondition =
                    DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                colBirimFiyat.Visible = true;
                colBirimFiyat.VisibleIndex = 5;
                colBirimFiyat.Caption = "Birim Fiyat";
                colBirimFiyat.ColumnEdit = rlueTutar;
                //
                // colTOPLAM
                //
                colTOPLAM.FieldName = "Toplam";
                colTOPLAM.Name = "colTOPLAM";
                colTOPLAM.OptionsFilter.AutoFilterCondition =
                    DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                colTOPLAM.Visible = true;
                colTOPLAM.VisibleIndex = 6;
                colTOPLAM.Caption = "Toplam";
                colTOPLAM.ColumnEdit = rlueTutar;
                //
                // colKDV
                //
                colKDV.FieldName = "KdvTutar";
                colKDV.Name = "colKDV";
                colKDV.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                colKDV.Visible = true;
                colKDV.VisibleIndex = 7;
                colKDV.Caption = "KDV";
                colKDV.ColumnEdit = rlueTutar;
                //
                // colSTOPAJ_TUTAR
                //
                colSTOPAJ_TUTAR.Caption = "Stopaj";
                colSTOPAJ_TUTAR.FieldName = "StopajTutar";
                colSTOPAJ_TUTAR.Name = "colSTOPAJ_TUTAR";
                colSTOPAJ_TUTAR.ColumnEdit = rlueTutar;
                colSTOPAJ_TUTAR.Visible = true;
                colSTOPAJ_TUTAR.VisibleIndex = 8;
                //
                // colSSDF_TUTAR
                //
                colSSDF_TUTAR.Caption = "SSDF";
                colSSDF_TUTAR.FieldName = "SsdfTutar";
                colSSDF_TUTAR.Name = "colSSDF_TUTAR";
                colSSDF_TUTAR.ColumnEdit = rlueTutar;
                colSSDF_TUTAR.Visible = true;
                colSSDF_TUTAR.VisibleIndex = 9;
                //
                // colGENEL_TOPLAM
                //
                colGENEL_TOPLAM.Caption = "Genel Toplam";
                colGENEL_TOPLAM.FieldName = "GenelToplam";
                colGENEL_TOPLAM.Name = "colGENEL_TOPLAM";
                colGENEL_TOPLAM.ColumnEdit = rlueTutar;
                colGENEL_TOPLAM.Visible = true;
                colGENEL_TOPLAM.VisibleIndex = 10;
                //
                // colGENEL_TOPLAM_DOVIZ_ID
                //
                colGENEL_TOPLAM_DOVIZ_ID.Caption = "Br.";
                colGENEL_TOPLAM_DOVIZ_ID.FieldName = "GenelToplamDovizId";
                colGENEL_TOPLAM_DOVIZ_ID.Name = "colGENEL_TOPLAM_DOVIZ_ID";
                colGENEL_TOPLAM_DOVIZ_ID.ColumnEdit = rlueDoviz;
                colGENEL_TOPLAM_DOVIZ_ID.Visible = true;
                colGENEL_TOPLAM_DOVIZ_ID.VisibleIndex = 11;
                //
                // colREFERANS_NO
                //
                colREFERANS_NO.FieldName = "ReferansNo";
                colREFERANS_NO.Name = "colREFERANS_NO";
                colREFERANS_NO.OptionsFilter.AutoFilterCondition =
                DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                colREFERANS_NO.Visible = true;
                colREFERANS_NO.Caption = "Referans No";
                colREFERANS_NO.VisibleIndex = 12;
                //
                // colKAYIT_TARIHI
                //
                colKAYIT_TARIHI.FieldName = "KayitTarihi";
                colKAYIT_TARIHI.Name = "colKAYIT_TARIHI";
                colKAYIT_TARIHI.Visible = true;
                colKAYIT_TARIHI.Caption = "Kayýt Tarihi";
                colKAYIT_TARIHI.VisibleIndex = 13;
                #endregion Properties

                #region Summary

                colTOPLAM.SummaryItem.Assign(Util.GetSummaryItemByField(colTOPLAM));
                colKDV.SummaryItem.Assign(Util.GetSummaryItemByField(colKDV));
                colSTOPAJ_TUTAR.SummaryItem.Assign(Util.GetSummaryItemByField(colSTOPAJ_TUTAR));
                colSSDF_TUTAR.SummaryItem.Assign(Util.GetSummaryItemByField(colSSDF_TUTAR));
                colGENEL_TOPLAM.SummaryItem.Assign(Util.GetSummaryItemByField(colGENEL_TOPLAM));

                #endregion Summary

                #region[]

                GridColumn[] dizi = new[]
                                            {
                                                colID,
                                                colCARI_ID ,
                                                colSegmentId ,
                                                colFATURA_HEDEF_TIP,
                                                colFATURA_TARIH ,
                                                colAdet,
                                                colBirimFiyat ,
                                                colTOPLAM ,
                                                colKDV ,
                                                colSTOPAJ_TUTAR,
                                                colSSDF_TUTAR,
                                                colGENEL_TOPLAM ,
                                                colGENEL_TOPLAM_DOVIZ_ID,
                                                colKonu ,
                                                colREFERANS_NO ,   
                                                colKAYIT_TARIHI
                                            };

                #endregion

                foreach (var item in dizi)
                {
                    item.OptionsColumn.ReadOnly = true;
                    item.OptionsColumn.AllowEdit = false;
                }

                return dizi;
            }
        }

        public class CariHesap
        {
            public GridColumn[] GetCariHesapColumn()
            {
                #region RepositoryItem

                RepositoryItemLookUpEdit rlueCari = new RepositoryItemLookUpEdit();
                RepositoryItemMemoExEdit aciklama = new RepositoryItemMemoExEdit();
                RepositoryItemLookUpEdit rlueBorcAlacak = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueOdemeTipi = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueHarAnaKat = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueHarAltKat = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueDoviz = new RepositoryItemLookUpEdit();

                #endregion

                #region InitsData

                BelgeUtil.Inits.perCariGetir(rlueCari);
                BelgeUtil.Inits.BorcAlacakGetir(rlueBorcAlacak);
                BelgeUtil.Inits.OdemeTipiGetir(rlueOdemeTipi);
                BelgeUtil.Inits.MuhasebeHareketAltKategori(rlueHarAltKat);
                BelgeUtil.Inits.HareketAnaKategoriGetir(rlueHarAnaKat);
                BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
                BelgeUtil.Inits.ParaBicimiAyarla(rlueTutar);

                #endregion

                #region Field & Properties

                GridColumn colID = new GridColumn();
                colID.VisibleIndex = 0;
                colID.FieldName = "ID";
                colID.Name = "colID";
                colID.Visible = false;

                GridColumn colCARI_ID = new GridColumn();
                colCARI_ID.VisibleIndex = 1;
                colCARI_ID.Caption = "Þahýs";
                colCARI_ID.FieldName = "CARI_ID";
                colCARI_ID.Name = "colCARI_ID";
                colCARI_ID.ColumnEdit = rlueCari;
                colCARI_ID.Visible = true;

                GridColumn colAD = new GridColumn();
                colAD.VisibleIndex = 2;
                colAD.FieldName = "AD";
                colAD.Name = "colAD";
                colAD.Visible = false;

                GridColumn colPERSONEL_MI = new GridColumn();
                colPERSONEL_MI.VisibleIndex = 3;
                colPERSONEL_MI.Caption = "Personel mi";
                colPERSONEL_MI.FieldName = "PERSONEL_MI";
                colPERSONEL_MI.Name = "colPERSONEL_MI";
                colPERSONEL_MI.Visible = false;

                GridColumn colMUVEKKIL_MI = new GridColumn();
                colMUVEKKIL_MI.VisibleIndex = 4;
                colMUVEKKIL_MI.Caption = "Müvekkil mi";
                colMUVEKKIL_MI.FieldName = "MUVEKKIL_MI";
                colMUVEKKIL_MI.Name = "colMUVEKKIL_MI";
                colMUVEKKIL_MI.Visible = false;

                GridColumn colFIRMA_MI = new GridColumn();
                colFIRMA_MI.VisibleIndex = 5;
                colFIRMA_MI.Caption = "Firma mý";
                colFIRMA_MI.FieldName = "FIRMA_MI";
                colFIRMA_MI.Name = "colFIRMA_MI";
                colFIRMA_MI.Visible = true;

                GridColumn colAVUKAT_MI = new GridColumn();
                colAVUKAT_MI.VisibleIndex = 6;
                colAVUKAT_MI.Caption = "Avukat mý";
                colAVUKAT_MI.FieldName = "AVUKAT_MI";
                colAVUKAT_MI.Name = "colAVUKAT_MI";
                colAVUKAT_MI.Visible = true;

                GridColumn colREFERANS_NO = new GridColumn();
                colREFERANS_NO.VisibleIndex = 7;
                colREFERANS_NO.Caption = "Referans No";
                colREFERANS_NO.FieldName = "REFERANS_NO";
                colREFERANS_NO.Name = "colREFERANS_NO";
                colREFERANS_NO.Visible = true;

                GridColumn colACIKLAMA = new GridColumn();
                colACIKLAMA.VisibleIndex = 8;
                colACIKLAMA.Caption = "Açýklama";
                colACIKLAMA.FieldName = "ACIKLAMA";
                colACIKLAMA.Name = "colACIKLAMA";
                colACIKLAMA.ColumnEdit = aciklama;
                colACIKLAMA.Visible = true;

                GridColumn colDETAY_ID = new GridColumn();
                colDETAY_ID.VisibleIndex = 9;
                colDETAY_ID.Caption = "Detay";
                colDETAY_ID.FieldName = "DETAY_ID";
                colDETAY_ID.Name = "colDETAY_ID";
                colDETAY_ID.Visible = false;

                GridColumn colDOSYA_MUH_AKTARILDI = new GridColumn();
                colDOSYA_MUH_AKTARILDI.VisibleIndex = 10;
                colDOSYA_MUH_AKTARILDI.Caption = "Dosya Muh Aktarýldý";
                colDOSYA_MUH_AKTARILDI.FieldName = "DOSYA_MUH_AKTARILDI";
                colDOSYA_MUH_AKTARILDI.Name = "colDOSYA_MUH_AKTARILDI";
                colDOSYA_MUH_AKTARILDI.Visible = true;

                GridColumn colBORC_ALACAK_ID = new GridColumn();
                colBORC_ALACAK_ID.VisibleIndex = 11;
                colBORC_ALACAK_ID.Caption = "B/A";
                colBORC_ALACAK_ID.FieldName = "BORC_ALACAK_ID";
                colBORC_ALACAK_ID.Name = "colBORC_ALACAK_ID";
                colBORC_ALACAK_ID.ColumnEdit = rlueBorcAlacak;
                colBORC_ALACAK_ID.Visible = true;

                GridColumn colODEME_TIP_ID = new GridColumn();
                colODEME_TIP_ID.VisibleIndex = 12;
                colODEME_TIP_ID.Caption = "Ödeme Tip";
                colODEME_TIP_ID.FieldName = "ODEME_TIP_ID";
                colODEME_TIP_ID.Name = "colODEME_TIP_ID";
                colODEME_TIP_ID.ColumnEdit = rlueOdemeTipi;
                colODEME_TIP_ID.Visible = true;

                GridColumn colCARI_HESAP_HEDEF_TIP = new GridColumn();
                colCARI_HESAP_HEDEF_TIP.VisibleIndex = 13;
                colCARI_HESAP_HEDEF_TIP.Caption = "Hesap Hedef Tip";
                colCARI_HESAP_HEDEF_TIP.FieldName = "CARI_HESAP_HEDEF_TIP";
                colCARI_HESAP_HEDEF_TIP.Name = "colCARI_HESAP_HEDEF_TIP";
                colCARI_HESAP_HEDEF_TIP.Visible = true;

                GridColumn colICRA_FOY_ID = new GridColumn();
                colICRA_FOY_ID.VisibleIndex = 14;
                colICRA_FOY_ID.FieldName = "ICRA_FOY_ID";
                colICRA_FOY_ID.Name = "colICRA_FOY_ID";
                colICRA_FOY_ID.Visible = false;

                GridColumn colICRA_FOY_NO = new GridColumn();
                colICRA_FOY_NO.VisibleIndex = 15;
                colICRA_FOY_NO.FieldName = "ICRA_FOY_NO";
                colICRA_FOY_NO.Name = "colICRA_FOY_NO";
                colICRA_FOY_NO.Visible = false;

                GridColumn colDAVA_FOY_ID = new GridColumn();
                colDAVA_FOY_ID.VisibleIndex = 16;
                colDAVA_FOY_ID.FieldName = "DAVA_FOY_ID";
                colDAVA_FOY_ID.Name = "colDAVA_FOY_ID";
                colDAVA_FOY_ID.Visible = false;

                GridColumn colDAVA_FOY_NO = new GridColumn();
                colDAVA_FOY_NO.VisibleIndex = 17;
                colDAVA_FOY_NO.FieldName = "DAVA_FOY_NO";
                colDAVA_FOY_NO.Name = "colDAVA_FOY_NO";
                colDAVA_FOY_NO.Visible = false;

                GridColumn colHAZIRLIK_ID = new GridColumn();
                colHAZIRLIK_ID.VisibleIndex = 18;
                colHAZIRLIK_ID.FieldName = "HAZIRLIK_ID";
                colHAZIRLIK_ID.Name = "colHAZIRLIK_ID";
                colHAZIRLIK_ID.Visible = false;

                GridColumn colHAZIRLIK_NO = new GridColumn();
                colHAZIRLIK_NO.VisibleIndex = 19;
                colHAZIRLIK_NO.FieldName = "HAZIRLIK_NO";
                colHAZIRLIK_NO.Name = "colHAZIRLIK_NO";
                colHAZIRLIK_NO.Visible = false;

                GridColumn colRUCU_ID = new GridColumn();
                colRUCU_ID.VisibleIndex = 20;
                colRUCU_ID.FieldName = "RUCU_ID";
                colRUCU_ID.Name = "colRUCU_ID";
                colRUCU_ID.Visible = false;

                GridColumn colRUCU_NO = new GridColumn();
                colRUCU_NO.VisibleIndex = 21;
                colRUCU_NO.FieldName = "RUCU_NO";
                colRUCU_NO.Name = "colRUCU_NO";
                colRUCU_NO.Visible = false;

                GridColumn colTARIH = new GridColumn();
                colTARIH.VisibleIndex = 22;
                colTARIH.Caption = "Tarih";
                colTARIH.FieldName = "TARIH";
                colTARIH.Name = "colTARIH";
                colTARIH.Visible = true;

                GridColumn colKULLANICI_BELGE_NO = new GridColumn();
                colKULLANICI_BELGE_NO.VisibleIndex = 23;
                colKULLANICI_BELGE_NO.Caption = "Kullanýcý Belge No";
                colKULLANICI_BELGE_NO.FieldName = "KULLANICI_BELGE_NO";
                colKULLANICI_BELGE_NO.Name = "colKULLANICI_BELGE_NO";
                colKULLANICI_BELGE_NO.Visible = true;

                GridColumn colHAREKET_ANA_KATEGORI_ID = new GridColumn();
                colHAREKET_ANA_KATEGORI_ID.VisibleIndex = 24;
                colHAREKET_ANA_KATEGORI_ID.Caption = "Har.Ana Kat.";
                colHAREKET_ANA_KATEGORI_ID.FieldName = "HAREKET_ANA_KATEGORI_ID";
                colHAREKET_ANA_KATEGORI_ID.Name = "colHAREKET_ANA_KATEGORI_ID";
                colHAREKET_ANA_KATEGORI_ID.ColumnEdit = rlueHarAnaKat;
                colHAREKET_ANA_KATEGORI_ID.Visible = true;

                GridColumn colHAREKET_ALT_KAREGORI_ID = new GridColumn();
                colHAREKET_ALT_KAREGORI_ID.VisibleIndex = 25;
                colHAREKET_ALT_KAREGORI_ID.Caption = "Har. Alt Kat";
                colHAREKET_ALT_KAREGORI_ID.FieldName = "HAREKET_ALT_KAREGORI_ID";
                colHAREKET_ALT_KAREGORI_ID.Name = "colHAREKET_ALT_KAREGORI_ID";
                colHAREKET_ALT_KAREGORI_ID.ColumnEdit = rlueHarAltKat;
                colHAREKET_ALT_KAREGORI_ID.Visible = true;

                GridColumn colADET = new GridColumn();
                colADET.VisibleIndex = 26;
                colADET.Caption = "Adet";
                colADET.FieldName = "ADET";
                colADET.Name = "colADET";
                colADET.Visible = true;

                GridColumn colBIRIM_FIYAT_DOVIZ_ID = new GridColumn();
                colBIRIM_FIYAT_DOVIZ_ID.VisibleIndex = 28;
                colBIRIM_FIYAT_DOVIZ_ID.Caption = "Brm.";
                colBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
                colBIRIM_FIYAT_DOVIZ_ID.Name = "colBIRIM_FIYAT_DOVIZ_ID";
                colBIRIM_FIYAT_DOVIZ_ID.CustomizationCaption = "Birim Fiyat Döviz Tip";
                colBIRIM_FIYAT_DOVIZ_ID.ColumnEdit = rlueDoviz;
                colBIRIM_FIYAT_DOVIZ_ID.Visible = true;

                GridColumn colBIRIM_FIYAT = new GridColumn();
                colBIRIM_FIYAT.VisibleIndex = 27;
                colBIRIM_FIYAT.Caption = "Birim Fiyat";
                colBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
                colBIRIM_FIYAT.Name = "colBIRIM_FIYAT";
                colBIRIM_FIYAT.ColumnEdit = rlueTutar;
                colBIRIM_FIYAT.Visible = true;

                GridColumn colGENEL_TOPLAM = new GridColumn();
                colGENEL_TOPLAM.VisibleIndex = 29;
                colGENEL_TOPLAM.Caption = "Genel Toplam";
                colGENEL_TOPLAM.FieldName = "GENEL_TOPLAM";
                colGENEL_TOPLAM.Name = "colGENEL_TOPLAM";
                colGENEL_TOPLAM.ColumnEdit = rlueTutar;
                colGENEL_TOPLAM.Visible = true;

                GridColumn colDETAY_ACIKLAMA = new GridColumn();
                colDETAY_ACIKLAMA.VisibleIndex = 30;
                colDETAY_ACIKLAMA.Caption = "Detay Kayýt";
                colDETAY_ACIKLAMA.FieldName = "DETAY_ACIKLAMA";
                colDETAY_ACIKLAMA.Name = "colDETAY_ACIKLAMA";
                colDETAY_ACIKLAMA.ColumnEdit = aciklama;
                colDETAY_ACIKLAMA.Visible = true;

                GridColumn colKAYIT_TARIHI = new GridColumn();
                colKAYIT_TARIHI.VisibleIndex = 31;
                colKAYIT_TARIHI.Caption = "Kayýt T";
                colKAYIT_TARIHI.FieldName = "KAYIT_TARIHI";
                colKAYIT_TARIHI.Name = "colKAYIT_TARIHI";
                colKAYIT_TARIHI.Visible = true;

                GridColumn colINCELENDI = new GridColumn();
                colINCELENDI.VisibleIndex = 32;
                colINCELENDI.Caption = "Ýncelendi";
                colINCELENDI.FieldName = "INCELENDI";
                colINCELENDI.Name = "colINCELENDI";
                colINCELENDI.Visible = true;

                GridColumn colONAY_TARIHI = new GridColumn();
                colONAY_TARIHI.VisibleIndex = 33;
                colONAY_TARIHI.Caption = "Onay T";
                colONAY_TARIHI.FieldName = "ONAY_TARIHI";
                colONAY_TARIHI.Name = "colONAY_TARIHI";
                colONAY_TARIHI.Visible = true;

                GridColumn colONAY_NO = new GridColumn();
                colONAY_NO.VisibleIndex = 34;
                colONAY_NO.Caption = "Onay No";
                colONAY_NO.FieldName = "ONAY_NO";
                colONAY_NO.Name = "colONAY_NO";
                colONAY_NO.Visible = true;

                GridColumn colONAY_DURUM = new GridColumn();
                colONAY_DURUM.VisibleIndex = 35;
                colONAY_DURUM.Caption = "Onay Durum";
                colONAY_DURUM.FieldName = "ONAY_DURUM";
                colONAY_DURUM.Name = "colONAY_DURUM";
                colONAY_DURUM.Visible = true;

                GridColumn colSOZLESME_ID = new GridColumn();
                colSOZLESME_ID.VisibleIndex = 36;
                colSOZLESME_ID.FieldName = "SOZLESME_ID";
                colSOZLESME_ID.Name = "colSOZLESME_ID";
                colSOZLESME_ID.Visible = false;

                GridColumn colKLASOR_KODU = new GridColumn();
                colKLASOR_KODU.VisibleIndex = 37;
                colKLASOR_KODU.Caption = "Klasör Kodu";
                colKLASOR_KODU.FieldName = "KLASOR_KODU";
                colKLASOR_KODU.Name = "colKLASOR_KODU";
                colKLASOR_KODU.Visible = true;

                GridColumn colSUBE_KODU = new GridColumn();
                colSUBE_KODU.VisibleIndex = 38;
                colSUBE_KODU.Caption = "Þube Kodu";
                colSUBE_KODU.FieldName = "SUBE_KODU";
                colSUBE_KODU.Name = "colSUBE_KODU";
                colSUBE_KODU.Visible = true;

                GridColumn colKONTROL_NE_ZAMAN = new GridColumn();
                colKONTROL_NE_ZAMAN.VisibleIndex = 39;
                colKONTROL_NE_ZAMAN.Caption = "Kontrol Ne Zaman";
                colKONTROL_NE_ZAMAN.FieldName = "KONTROL_NE_ZAMAN";
                colKONTROL_NE_ZAMAN.Name = "colKONTROL_NE_ZAMAN";
                colKONTROL_NE_ZAMAN.Visible = true;

                GridColumn colKONTROL_KIM = new GridColumn();
                colKONTROL_KIM.VisibleIndex = 40;
                colKONTROL_KIM.FieldName = "KONTROL_KIM";
                colKONTROL_KIM.Name = "colKONTROL_KIM";
                colKONTROL_KIM.Visible = false;

                GridColumn colKONTROL_VERSIYON = new GridColumn();
                colKONTROL_VERSIYON.VisibleIndex = 41;
                colKONTROL_VERSIYON.Caption = "Kontrol Versiyon";
                colKONTROL_VERSIYON.FieldName = "KONTROL_VERSIYON";
                colKONTROL_VERSIYON.Name = "colKONTROL_VERSIYON";
                colKONTROL_VERSIYON.Visible = true;

                GridColumn colKONTROL_KIM_ID = new GridColumn();
                colKONTROL_KIM_ID.VisibleIndex = 42;
                colKONTROL_KIM_ID.Caption = "Ýþlem Yapan";
                colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
                colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
                colKONTROL_KIM_ID.Visible = true;

                GridColumn colSUBE_KOD_ID = new GridColumn();
                colSUBE_KOD_ID.VisibleIndex = 43;
                colSUBE_KOD_ID.Caption = "Þube Kodu";
                colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
                colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
                colSUBE_KOD_ID.Visible = true;

                GridColumn colSTAMP = new GridColumn();
                colSTAMP.VisibleIndex = 44;
                colSTAMP.Caption = "Stamp";
                colSTAMP.FieldName = "STAMP";
                colSTAMP.Name = "colSTAMP";
                colSTAMP.Visible = true;

                GridColumn colKOD = new GridColumn();
                colKOD.VisibleIndex = 45;
                colKOD.Caption = "Kod";
                colKOD.FieldName = "KOD";
                colKOD.Name = "colKOD";
                colKOD.Visible = true;

                #endregion

                #region []

                GridColumn[] dizi = new[]
                                            {
                                                //colID,
                                                //colCARI_ID,
                                                colAD,
                                                colPERSONEL_MI,
                                                colMUVEKKIL_MI,
                                                colFIRMA_MI,
                                                colAVUKAT_MI,
                                                colREFERANS_NO,
                                                colACIKLAMA,
                                                //colDETAY_ID,
                                                colDOSYA_MUH_AKTARILDI,
                                                colBORC_ALACAK_ID,
                                                colODEME_TIP_ID,
                                                colCARI_HESAP_HEDEF_TIP,
                                                //colICRA_FOY_ID,
                                                //colICRA_FOY_NO,
                                                //colDAVA_FOY_ID,
                                                //colDAVA_FOY_NO,
                                                //colHAZIRLIK_ID,
                                                //colHAZIRLIK_NO,
                                                //colRUCU_ID,
                                                //colRUCU_NO,
                                                colTARIH,
                                                colKULLANICI_BELGE_NO,
                                                colHAREKET_ANA_KATEGORI_ID,
                                                colHAREKET_ALT_KAREGORI_ID,
                                                colADET,
                                                colBIRIM_FIYAT,
                                                colBIRIM_FIYAT_DOVIZ_ID,
                                                colGENEL_TOPLAM,
                                                colDETAY_ACIKLAMA,
                                                colKAYIT_TARIHI,
                                                colINCELENDI,
                                                colONAY_TARIHI,
                                                colONAY_NO,
                                                colONAY_DURUM,
                                                //colSOZLESME_ID,
                                                //colKLASOR_KODU,
                                                //colSUBE_KODU,
                                                //colKONTROL_NE_ZAMAN,
                                                //colKONTROL_KIM,
                                                //colKONTROL_VERSIYON,
                                                //colKONTROL_KIM_ID,
                                                //colSUBE_KOD_ID,
                                                //colSTAMP,
                                                colKOD,
                                            };

                #endregion

                foreach (var item in dizi)
                {
                    item.OptionsColumn.ReadOnly = true;
                    item.OptionsColumn.AllowEdit = false;
                }
                return dizi;
            }
        }

        public class PersonelCariHesap
        {

            public GridColumn[] GetCariColumns()
            {
                #region RepositoryItem

                //RepositoryItemLookUpEdit rlueMasAvansTip = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueCari = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueOnay = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueBorcAlacak = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueOdemeTipi = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueHarAnaKat = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueHarAltKat = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueDoviz = new RepositoryItemLookUpEdit();

                #endregion

                #region InitsData

                BelgeUtil.Inits.ModulGetir(rlueDosyaTipi);
                BelgeUtil.Inits.OnayDurumGetir(rlueOnay);
                //BelgeUtil.Inits.MasrafAvansTipGetir(rlueMasAvansTip);
                BelgeUtil.Inits.perCariGetir(rlueCari);
                BelgeUtil.Inits.BorcAlacakGetir(rlueBorcAlacak);
                BelgeUtil.Inits.OdemeTipiGetir(rlueOdemeTipi);
                BelgeUtil.Inits.MuhasebeHareketAltKategori(rlueHarAltKat);
                BelgeUtil.Inits.HareketAnaKategoriGetir(rlueHarAnaKat);
                BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
                BelgeUtil.Inits.ParaBicimiAyarla(rlueTutar);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliye);
                BelgeUtil.Inits.AdliBirimNoGetir(rlueAdliNo);
                BelgeUtil.Inits.AdliBirimGorevGetir(rlueAdliGorev);
                AvukatPro.Services.Implementations.DevExpressService.SegmentDoldur(rlueSegment);

                #endregion

                #region Field & Properties

                GridColumn colID = new GridColumn();
                GridColumn colCARI_ID = new GridColumn();
                GridColumn colSegmentId = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colCARI_HESAP_HEDEF_TIP = new GridColumn();
                GridColumn colMASRAF_AVANS_ID = new GridColumn();
                GridColumn colBORC_ALACAK_ID = new GridColumn();
                GridColumn colTarih = new GridColumn();
                GridColumn colAciklama = new GridColumn();
                GridColumn colADET = new GridColumn();
                GridColumn colBIRIM_FIYAT = new GridColumn();
                GridColumn colBIRIM_FIYAT_DOVIZ_ID = new GridColumn();
                GridColumn colGENEL_TOPLAM = new GridColumn();
                GridColumn colTOPLAM_TUTAR = new GridColumn();
                GridColumn colKDV_TUTAR = new GridColumn();
                GridColumn colSTOPAJ_SSDF_TUTAR = new GridColumn();
                GridColumn colBankaDekontNo = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colEFTReferansNo = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colREFERANS_NO = new GridColumn();
                GridColumn colODEME_TIP_ID = new GridColumn();
                GridColumn colHAREKET_ALT_KAREGORI_ID = new GridColumn();
                GridColumn colFOY_NO = new GridColumn();
                GridColumn colADLI_BIRIM_ADLIYE_ID = new GridColumn();
                GridColumn colADLI_BIRIM_NO_ID = new GridColumn();
                GridColumn colADLI_BIRIM_GOREV_ID = new GridColumn();
                GridColumn colESAS_NO = new GridColumn();
                GridColumn colINCELENDI = new GridColumn();
                GridColumn colONAY_DURUM = new GridColumn();
                GridColumn colONAY_TARIHI = new GridColumn();
                GridColumn colONAY_NO = new GridColumn();
                GridColumn colHAREKET_ANA_KATEGORI_ID = new GridColumn();
                GridColumn colKasaHesapId = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colMuhatapHesapId = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colKiymetliEvrakId = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colKAYIT_TARIHI = new GridColumn();

                //
                //colID
                //
                colID.VisibleIndex = -1;
                colID.FieldName = "Id";
                colID.Name = "colID";
                colID.Visible = false;
                //
                //colCARI_ID
                //
                colCARI_ID.VisibleIndex = 0;
                colCARI_ID.Caption = "Personel";
                colCARI_ID.FieldName = "CariId";
                colCARI_ID.Name = "colCARI_ID";
                colCARI_ID.ColumnEdit = rlueCari;
                colCARI_ID.Visible = true;
                //
                //colSegmentId
                //
                colSegmentId.Caption = "Bölüm";
                colSegmentId.ColumnEdit = rlueSegment;
                colSegmentId.FieldName = "SegmentId";
                colSegmentId.Name = "colSegmentId";
                colSegmentId.Visible = true;
                colSegmentId.VisibleIndex = 1;
                //
                //colCARI_HESAP_HEDEF_TIP
                //
                colCARI_HESAP_HEDEF_TIP.VisibleIndex = 2;
                colCARI_HESAP_HEDEF_TIP.Caption = "Hesap Hedef Tip";
                colCARI_HESAP_HEDEF_TIP.FieldName = "CariHesapHedefTip";
                colCARI_HESAP_HEDEF_TIP.Name = "colCARI_HESAP_HEDEF_TIP";
                colCARI_HESAP_HEDEF_TIP.Visible = true;
                colCARI_HESAP_HEDEF_TIP.ColumnEdit = rlueDosyaTipi;
                //
                //colMASRAF_AVANS_ID
                //
                colMASRAF_AVANS_ID.VisibleIndex = 0;
                colMASRAF_AVANS_ID.Caption = "Masraf Avans";
                colMASRAF_AVANS_ID.FieldName = "MASRAF_AVANS_ID";
                colMASRAF_AVANS_ID.Name = "colMASRAF_AVANS_ID";
                //colMASRAF_AVANS_ID.ColumnEdit = rlueMasAvansTip;
                colMASRAF_AVANS_ID.Visible = false;
                //
                //colBORC_ALACAK_ID
                //
                colBORC_ALACAK_ID.VisibleIndex = 4;
                colBORC_ALACAK_ID.Caption = "B/A";
                colBORC_ALACAK_ID.FieldName = "BorcAlacakId";
                colBORC_ALACAK_ID.Name = "colBORC_ALACAK_ID";
                colBORC_ALACAK_ID.ColumnEdit = rlueBorcAlacak;
                colBORC_ALACAK_ID.Visible = true;
                //
                //colBORC_ALACAK_ID
                //
                colTarih.VisibleIndex = 4;
                colTarih.Caption = "Hareket T.";
                colTarih.FieldName = "Tarih";
                colTarih.Name = "colTarih";
                colTarih.Visible = true;
                //
                //colAciklama
                //
                colAciklama.VisibleIndex = 4;
                colAciklama.Caption = "Açýklama";
                colAciklama.FieldName = "Aciklama";
                colAciklama.Name = "colAciklama";
                colAciklama.Visible = false;
                //
                //colADET  
                //
                colADET.VisibleIndex = 5;
                colADET.Caption = "Adet";
                colADET.FieldName = "Adet";
                colADET.Name = "colADET";
                colADET.Visible = true;
                //
                //colBIRIM_FIYAT
                //
                colBIRIM_FIYAT.VisibleIndex = 6;
                colBIRIM_FIYAT.Caption = "Birim Fiyat";
                colBIRIM_FIYAT.FieldName = "BirimFiyat";
                colBIRIM_FIYAT.Name = "colBIRIM_FIYAT";
                colBIRIM_FIYAT.ColumnEdit = rlueTutar;
                colBIRIM_FIYAT.Visible = true;
                //
                //colBIRIM_FIYAT_DOVIZ_ID
                //
                colBIRIM_FIYAT_DOVIZ_ID.VisibleIndex = 7;
                colBIRIM_FIYAT_DOVIZ_ID.Caption = "Brm.";
                colBIRIM_FIYAT_DOVIZ_ID.FieldName = "BirimFiyatDovizId";
                colBIRIM_FIYAT_DOVIZ_ID.Name = "colBIRIM_FIYAT_DOVIZ_ID";
                colBIRIM_FIYAT_DOVIZ_ID.CustomizationCaption = "Birim Fiyat Döviz Tip";
                colBIRIM_FIYAT_DOVIZ_ID.ColumnEdit = rlueDoviz;
                colBIRIM_FIYAT_DOVIZ_ID.Visible = true;
                //
                // colTOPLAM_TUTAR
                //
                colTOPLAM_TUTAR.Caption = "Toplam Tutar";
                colTOPLAM_TUTAR.FieldName = "ToplamTutar";
                colTOPLAM_TUTAR.Name = "colTOPLAM_TUTAR";
                colTOPLAM_TUTAR.ColumnEdit = rlueTutar;
                colTOPLAM_TUTAR.Visible = true;
                colTOPLAM_TUTAR.VisibleIndex = 8;
                //
                // colKDV_TUTAR
                //
                colKDV_TUTAR.Caption = "KDV Tutar";
                colKDV_TUTAR.FieldName = "KdvTutar";
                colKDV_TUTAR.Name = "colKDV_TUTAR";
                colKDV_TUTAR.ColumnEdit = rlueTutar;
                colKDV_TUTAR.Visible = true;
                colKDV_TUTAR.VisibleIndex = 9;
                //
                // colSTOPAJ_SSDF_TUTAR
                //
                colSTOPAJ_SSDF_TUTAR.Caption = "Stopaj SSDF Tutarý";
                colSTOPAJ_SSDF_TUTAR.FieldName = "StopajSsdfTutar";
                colSTOPAJ_SSDF_TUTAR.Name = "colSTOPAJ_SSDF_TUTAR";
                colSTOPAJ_SSDF_TUTAR.ColumnEdit = rlueTutar;
                colSTOPAJ_SSDF_TUTAR.Visible = true;
                colSTOPAJ_SSDF_TUTAR.VisibleIndex = 10;
                //
                //colGENEL_TOPLAM
                //
                colGENEL_TOPLAM.VisibleIndex = 11;
                colGENEL_TOPLAM.Caption = "Genel Toplam";
                colGENEL_TOPLAM.FieldName = "GenelToplam";
                colGENEL_TOPLAM.Name = "colGENEL_TOPLAM";
                colGENEL_TOPLAM.ColumnEdit = rlueTutar;
                colGENEL_TOPLAM.Visible = true;
                //
                // colBankaDekontNo
                //
                colBankaDekontNo.Caption = "Dekont No";
                colBankaDekontNo.FieldName = "BankaDekontNo";
                colBankaDekontNo.Name = "colBankaDekontNo";
                colBankaDekontNo.Visible = true;
                colBankaDekontNo.VisibleIndex = 12;
                //
                // colEFTReferansNo
                //
                colEFTReferansNo.Caption = "Eft Referans";
                colEFTReferansNo.FieldName = "EftReferansNo";
                colEFTReferansNo.Name = "colEFTReferansNo";
                colEFTReferansNo.Visible = true;
                colEFTReferansNo.VisibleIndex = 13;
                //
                // colREFERANS_NO
                //
                colREFERANS_NO.Caption = "Referans";
                colREFERANS_NO.FieldName = "ReferansNo";
                colREFERANS_NO.Name = "colREFERANS_NO";
                colREFERANS_NO.Visible = true;
                colREFERANS_NO.VisibleIndex = 14;
                //
                //colODEME_TIP_ID
                //
                colODEME_TIP_ID.VisibleIndex = 15;
                colODEME_TIP_ID.Caption = "Ödeme Tip";
                colODEME_TIP_ID.FieldName = "OdemeTipId";
                colODEME_TIP_ID.Name = "colODEME_TIP_ID";
                colODEME_TIP_ID.ColumnEdit = rlueOdemeTipi;
                colODEME_TIP_ID.Visible = true;
                //
                //colHAREKET_ALT_KAREGORI_ID
                //
                colHAREKET_ALT_KAREGORI_ID.VisibleIndex = 16;
                colHAREKET_ALT_KAREGORI_ID.Caption = "Har. Alt Kat";
                colHAREKET_ALT_KAREGORI_ID.FieldName = "HareketAltKaregoriId";
                colHAREKET_ALT_KAREGORI_ID.Name = "colHAREKET_ALT_KAREGORI_ID";
                colHAREKET_ALT_KAREGORI_ID.ColumnEdit = rlueHarAltKat;
                colHAREKET_ALT_KAREGORI_ID.Visible = true;
                //
                // colFOY_NO
                //
                colFOY_NO.Caption = "Dosya No";
                colFOY_NO.FieldName = "FoyNo";
                colFOY_NO.Name = "colFOY_NO";
                colFOY_NO.Visible = true;
                colFOY_NO.VisibleIndex = 17;
                //
                // colADLI_BIRIM_ADLIYE_ID
                //
                colADLI_BIRIM_ADLIYE_ID.Caption = "Adliye";
                colADLI_BIRIM_ADLIYE_ID.FieldName = "AdliBirimAdliyeId";
                colADLI_BIRIM_ADLIYE_ID.Name = "colADLI_BIRIM_ADLIYE_ID";
                colADLI_BIRIM_ADLIYE_ID.ColumnEdit = rlueAdliye;
                colADLI_BIRIM_ADLIYE_ID.Visible = true;
                colADLI_BIRIM_ADLIYE_ID.VisibleIndex = 18;
                //
                // colADLI_BIRIM_NO_ID
                //
                colADLI_BIRIM_NO_ID.Caption = "No";
                colADLI_BIRIM_NO_ID.FieldName = "AdliBirimNoId";
                colADLI_BIRIM_NO_ID.Name = "colADLI_BIRIM_NO_ID";
                colADLI_BIRIM_NO_ID.ColumnEdit = rlueAdliNo;
                colADLI_BIRIM_NO_ID.Visible = true;
                colADLI_BIRIM_NO_ID.VisibleIndex = 19;
                //
                // colADLI_BIRIM_GOREV_ID
                //
                colADLI_BIRIM_GOREV_ID.Caption = "Görev";
                colADLI_BIRIM_GOREV_ID.FieldName = "AdliBirimGorevId";
                colADLI_BIRIM_GOREV_ID.Name = "colADLI_BIRIM_GOREV_ID";
                colADLI_BIRIM_GOREV_ID.ColumnEdit = rlueAdliGorev;
                colADLI_BIRIM_GOREV_ID.Visible = true;
                colADLI_BIRIM_GOREV_ID.VisibleIndex = 20;
                //
                // colESAS_NO
                //
                colESAS_NO.Caption = "Esas No";
                colESAS_NO.FieldName = "EsasNo";
                colESAS_NO.Name = "colESAS_NO";
                colESAS_NO.Visible = true;
                colESAS_NO.VisibleIndex = 21;
                //
                //colINCELENDI
                //
                colINCELENDI.VisibleIndex = 22;
                colINCELENDI.Caption = "Ýncelendi";
                colINCELENDI.FieldName = "Incelendi";
                colINCELENDI.Name = "colINCELENDI";
                colINCELENDI.Visible = true;
                //
                //colONAY_TARIHI
                //
                colONAY_TARIHI.VisibleIndex = 23;
                colONAY_TARIHI.Caption = "Onay T";
                colONAY_TARIHI.FieldName = "OnayTarihi";
                colONAY_TARIHI.Name = "colONAY_TARIHI";
                colONAY_TARIHI.Visible = true;
                //
                //colONAY_NO
                //
                colONAY_NO.VisibleIndex = 24;
                colONAY_NO.Caption = "Onay No";
                colONAY_NO.FieldName = "OnayNo";
                colONAY_NO.Name = "colONAY_NO";
                colONAY_NO.Visible = true;
                //
                //colONAY_DURUM
                //
                colONAY_DURUM.VisibleIndex = 25;
                colONAY_DURUM.Caption = "Onay Durum";
                colONAY_DURUM.FieldName = "OnayDurum";
                colONAY_DURUM.Name = "colONAY_DURUM";
                colONAY_DURUM.ColumnEdit = rlueOnay;
                colONAY_DURUM.Visible = true;
                //
                // colKasaHesapId
                //
                colKasaHesapId.Caption = "Kasa Hesap";
                colKasaHesapId.FieldName = "KasaHesapSahibiCariBankaId";
                colKasaHesapId.Name = "colKasaHesapId";
                colKasaHesapId.Visible = false;
                colKasaHesapId.VisibleIndex = -1;
                //
                // colMuhatapHesapId
                //
                colMuhatapHesapId.Caption = "Muhatap Hesap";
                colMuhatapHesapId.FieldName = "MuhatapHesapSahibiCariBankaId";
                colMuhatapHesapId.Name = "colMuhatapHesapId";
                colMuhatapHesapId.Visible = false;
                colMuhatapHesapId.VisibleIndex = -1;
                //
                // colKiymetliEvrakId
                //
                colKiymetliEvrakId.Caption = "";
                colKiymetliEvrakId.FieldName = "KiymetliEvrakId";
                colKiymetliEvrakId.Name = "colKiymetliEvrakId";
                colKiymetliEvrakId.Visible = false;
                colKiymetliEvrakId.VisibleIndex = -1;
                //
                //colHAREKET_ANA_KATEGORI_ID
                //
                colHAREKET_ANA_KATEGORI_ID.VisibleIndex = -1;
                colHAREKET_ANA_KATEGORI_ID.Caption = "Har.Ana Kat.";
                colHAREKET_ANA_KATEGORI_ID.FieldName = "HareketAnaKategoriId";
                colHAREKET_ANA_KATEGORI_ID.Name = "colHAREKET_ANA_KATEGORI_ID";
                colHAREKET_ANA_KATEGORI_ID.ColumnEdit = rlueHarAnaKat;
                colHAREKET_ANA_KATEGORI_ID.Visible = false;

                //
                //colKAYIT_TARIHI
                //
                colKAYIT_TARIHI.VisibleIndex = 26;
                colKAYIT_TARIHI.Caption = "Kayýt Tarihi";
                colKAYIT_TARIHI.FieldName = "KayitTarihi";
                colKAYIT_TARIHI.Name = "colKAYIT_TARIHI";
                colKAYIT_TARIHI.Visible = true;

                //GridColumn colAD = new GridColumn();
                //colAD.VisibleIndex = 2;
                //colAD.FieldName = "Ad";
                //colAD.Name = "colAD";
                //colAD.Visible = false;

                //GridColumn colPERSONEL_MI = new GridColumn();
                //colPERSONEL_MI.VisibleIndex = 3;
                //colPERSONEL_MI.Caption = "Personel mi";
                //colPERSONEL_MI.FieldName = "PersonelMi";
                //colPERSONEL_MI.Name = "colPERSONEL_MI";
                //colPERSONEL_MI.Visible = false;

                //GridColumn colMUVEKKIL_MI = new GridColumn();
                //colMUVEKKIL_MI.VisibleIndex = 4;
                //colMUVEKKIL_MI.Caption = "Müvekkil mi";
                //colMUVEKKIL_MI.FieldName = "MuvekkilMi";
                //colMUVEKKIL_MI.Name = "colMUVEKKIL_MI";
                //colMUVEKKIL_MI.Visible = false;

                //GridColumn colFIRMA_MI = new GridColumn();
                //colFIRMA_MI.VisibleIndex = 5;
                //colFIRMA_MI.Caption = "Firma mý";
                //colFIRMA_MI.FieldName = "FirmaMi";
                //colFIRMA_MI.Name = "colFIRMA_MI";
                //colFIRMA_MI.Visible = true;

                //GridColumn colAVUKAT_MI = new GridColumn();
                //colAVUKAT_MI.VisibleIndex = 6;
                //colAVUKAT_MI.Caption = "Avukat mý";
                //colAVUKAT_MI.FieldName = "AvukatMi";
                //colAVUKAT_MI.Name = "colAVUKAT_MI";
                //colAVUKAT_MI.Visible = true;



                //GridColumn colACIKLAMA = new GridColumn();
                //colACIKLAMA.VisibleIndex = 8;
                //colACIKLAMA.Caption = "Açýklama";
                //colACIKLAMA.FieldName = "Aciklama";
                //colACIKLAMA.Name = "colACIKLAMA";
                //colACIKLAMA.ColumnEdit = aciklama;
                //colACIKLAMA.Visible = true;

                //GridColumn colDETAY_ID = new GridColumn();
                //colDETAY_ID.VisibleIndex = 9;
                //colDETAY_ID.Caption = "Detay";
                //colDETAY_ID.FieldName = "DetayId";
                //colDETAY_ID.Name = "colDETAY_ID";
                //colDETAY_ID.Visible = false;

                //GridColumn colDOSYA_MUH_AKTARILDI = new GridColumn();
                //colDOSYA_MUH_AKTARILDI.VisibleIndex = 10;
                //colDOSYA_MUH_AKTARILDI.Caption = "Dosya Muh Aktarýldý";
                //colDOSYA_MUH_AKTARILDI.FieldName = "DosyaMuhAktarildi";
                //colDOSYA_MUH_AKTARILDI.Name = "colDOSYA_MUH_AKTARILDI";
                //colDOSYA_MUH_AKTARILDI.Visible = true;

                //GridColumn colICRA_FOY_ID = new GridColumn();
                //colICRA_FOY_ID.VisibleIndex = 14;
                //colICRA_FOY_ID.FieldName = "IcraFoyId";
                //colICRA_FOY_ID.Name = "colICRA_FOY_ID";
                //colICRA_FOY_ID.Visible = false;

                //GridColumn colICRA_FOY_NO = new GridColumn();
                //colICRA_FOY_NO.VisibleIndex = 15;
                //colICRA_FOY_NO.FieldName = "IcraFoyNo";
                //colICRA_FOY_NO.Name = "colICRA_FOY_NO";
                //colICRA_FOY_NO.Visible = false;

                //GridColumn colDAVA_FOY_ID = new GridColumn();
                //colDAVA_FOY_ID.VisibleIndex = 16;
                //colDAVA_FOY_ID.FieldName = "DavaFoyId";
                //colDAVA_FOY_ID.Name = "colDAVA_FOY_ID";
                //colDAVA_FOY_ID.Visible = false;

                //GridColumn colDAVA_FOY_NO = new GridColumn();
                //colDAVA_FOY_NO.VisibleIndex = 17;
                //colDAVA_FOY_NO.FieldName = "DavaFoyNo";
                //colDAVA_FOY_NO.Name = "colDAVA_FOY_NO";
                //colDAVA_FOY_NO.Visible = false;

                //GridColumn colHAZIRLIK_ID = new GridColumn();
                //colHAZIRLIK_ID.VisibleIndex = 18;
                //colHAZIRLIK_ID.FieldName = "HazirlikId";
                //colHAZIRLIK_ID.Name = "colHAZIRLIK_ID";
                //colHAZIRLIK_ID.Visible = false;

                //GridColumn colHAZIRLIK_NO = new GridColumn();
                //colHAZIRLIK_NO.VisibleIndex = 19;
                //colHAZIRLIK_NO.FieldName = "HazirlikNo";
                //colHAZIRLIK_NO.Name = "colHAZIRLIK_NO";
                //colHAZIRLIK_NO.Visible = false;

                //GridColumn colRUCU_ID = new GridColumn();
                //colRUCU_ID.VisibleIndex = 20;
                //colRUCU_ID.FieldName = "RucuId";
                //colRUCU_ID.Name = "colRUCU_ID";
                //colRUCU_ID.Visible = false;

                //GridColumn colRUCU_NO = new GridColumn();
                //colRUCU_NO.VisibleIndex = 21;
                //colRUCU_NO.FieldName = "RucuNo";
                //colRUCU_NO.Name = "colRUCU_NO";
                //colRUCU_NO.Visible = false;

                //GridColumn colTARIH = new GridColumn();
                //colTARIH.VisibleIndex = 22;
                //colTARIH.Caption = "Tarih";
                //colTARIH.FieldName = "Tarih";
                //colTARIH.Name = "colTARIH";
                //colTARIH.Visible = true;

                //GridColumn colKULLANICI_BELGE_NO = new GridColumn();
                //colKULLANICI_BELGE_NO.VisibleIndex = 23;
                //colKULLANICI_BELGE_NO.Caption = "Kullanýcý Belge No";
                //colKULLANICI_BELGE_NO.FieldName = "KullaniciBelgeNo";
                //colKULLANICI_BELGE_NO.Name = "colKULLANICI_BELGE_NO";
                //colKULLANICI_BELGE_NO.Visible = true;

                //GridColumn colDETAY_ACIKLAMA = new GridColumn();
                //colDETAY_ACIKLAMA.VisibleIndex = 30;
                //colDETAY_ACIKLAMA.Caption = "Detay Kayýt";
                //colDETAY_ACIKLAMA.FieldName = "DetayAciklama";
                //colDETAY_ACIKLAMA.Name = "colDETAY_ACIKLAMA";
                //colDETAY_ACIKLAMA.ColumnEdit = aciklama;
                //colDETAY_ACIKLAMA.Visible = true;

                //GridColumn colKAYIT_TARIHI = new GridColumn();
                //colKAYIT_TARIHI.VisibleIndex = 31;
                //colKAYIT_TARIHI.Caption = "Kayýt T";
                //colKAYIT_TARIHI.FieldName = "KayitTarihi";
                //colKAYIT_TARIHI.Name = "colKAYIT_TARIHI";
                //colKAYIT_TARIHI.Visible = true;

                //GridColumn colINCELENDI = new GridColumn();
                //colINCELENDI.VisibleIndex = 32;
                //colINCELENDI.Caption = "Ýncelendi";
                //colINCELENDI.FieldName = "Incelendi";
                //colINCELENDI.Name = "colINCELENDI";
                //colINCELENDI.Visible = true;

                //GridColumn colONAY_TARIHI = new GridColumn();
                //colONAY_TARIHI.VisibleIndex = 33;
                //colONAY_TARIHI.Caption = "Onay T";
                //colONAY_TARIHI.FieldName = "OnayTarihi";
                //colONAY_TARIHI.Name = "colONAY_TARIHI";
                //colONAY_TARIHI.Visible = true;

                //GridColumn colONAY_NO = new GridColumn();
                //colONAY_NO.VisibleIndex = 34;
                //colONAY_NO.Caption = "Onay No";
                //colONAY_NO.FieldName = "OnayNo";
                //colONAY_NO.Name = "colONAY_NO";
                //colONAY_NO.Visible = true;

                //GridColumn colONAY_DURUM = new GridColumn();
                //colONAY_DURUM.VisibleIndex = 35;
                //colONAY_DURUM.Caption = "Onay Durum";
                //colONAY_DURUM.FieldName = "OnayDurum";
                //colONAY_DURUM.Name = "colONAY_DURUM";
                //colONAY_DURUM.Visible = true;

                //GridColumn colSOZLESME_ID = new GridColumn();
                //colSOZLESME_ID.VisibleIndex = 36;
                //colSOZLESME_ID.FieldName = "SozlesmeId";
                //colSOZLESME_ID.Name = "colSOZLESME_ID";
                //colSOZLESME_ID.Visible = false;

                //GridColumn colKLASOR_KODU = new GridColumn();
                //colKLASOR_KODU.VisibleIndex = 37;
                //colKLASOR_KODU.Caption = "Klasör Kodu";
                //colKLASOR_KODU.FieldName = "KlasorKodu";
                //colKLASOR_KODU.Name = "colKLASOR_KODU";
                //colKLASOR_KODU.Visible = true;

                //GridColumn colSUBE_KODU = new GridColumn();
                //colSUBE_KODU.VisibleIndex = 38;
                //colSUBE_KODU.Caption = "Þube Kodu";
                //colSUBE_KODU.FieldName = "SubeKodu";
                //colSUBE_KODU.Name = "colSUBE_KODU";
                //colSUBE_KODU.Visible = true;

                //GridColumn colKONTROL_NE_ZAMAN = new GridColumn();
                //colKONTROL_NE_ZAMAN.VisibleIndex = 39;
                //colKONTROL_NE_ZAMAN.Caption = "Kontrol Ne Zaman";
                //colKONTROL_NE_ZAMAN.FieldName = "KontrolNezaman";
                //colKONTROL_NE_ZAMAN.Name = "colKONTROL_NE_ZAMAN";
                //colKONTROL_NE_ZAMAN.Visible = true;

                //GridColumn colKONTROL_KIM = new GridColumn();
                //colKONTROL_KIM.VisibleIndex = 40;
                //colKONTROL_KIM.FieldName = "KontrolKim";
                //colKONTROL_KIM.Name = "colKONTROL_KIM";
                //colKONTROL_KIM.Visible = false;

                //GridColumn colKONTROL_VERSIYON = new GridColumn();
                //colKONTROL_VERSIYON.VisibleIndex = 41;
                //colKONTROL_VERSIYON.Caption = "Kontrol Versiyon";
                //colKONTROL_VERSIYON.FieldName = "KontrolVersiyon";
                //colKONTROL_VERSIYON.Name = "colKONTROL_VERSIYON";
                //colKONTROL_VERSIYON.Visible = true;

                //GridColumn colKONTROL_KIM_ID = new GridColumn();
                //colKONTROL_KIM_ID.VisibleIndex = 42;
                //colKONTROL_KIM_ID.Caption = "Ýþlem Yapan";
                //colKONTROL_KIM_ID.FieldName = "KontrolKimId";
                //colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
                //colKONTROL_KIM_ID.Visible = true;

                //GridColumn colSUBE_KOD_ID = new GridColumn();
                //colSUBE_KOD_ID.VisibleIndex = 43;
                //colSUBE_KOD_ID.Caption = "Þube Kodu";
                //colSUBE_KOD_ID.FieldName = "SubeKodId";
                //colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
                //colSUBE_KOD_ID.Visible = true;

                //GridColumn colSTAMP = new GridColumn();
                //colSTAMP.VisibleIndex = 44;
                //colSTAMP.Caption = "Stamp";
                //colSTAMP.FieldName = "Stamp";
                //colSTAMP.Name = "colSTAMP";
                //colSTAMP.Visible = true;

                //GridColumn colKOD = new GridColumn();
                //colKOD.VisibleIndex = 45;
                //colKOD.Caption = "Kod";
                //colKOD.FieldName = "Kod";
                //colKOD.Name = "colKOD";
                //colKOD.Visible = true;

                #endregion

                #region Summary

                StyleFormatCondition c1 = new StyleFormatCondition(FormatConditionEnum.Greater, colBIRIM_FIYAT, "", 0, 0, true);
                c1.Appearance.BackColor = System.Drawing.Color.LimeGreen;

                StyleFormatCondition c2 = new StyleFormatCondition(FormatConditionEnum.Less, colBIRIM_FIYAT, "", 0, 0, true);
                c2.Appearance.BackColor = System.Drawing.Color.Orange;

                colGENEL_TOPLAM.SummaryItem.Assign(Util.GetSummaryItemByField(colGENEL_TOPLAM));
                colTOPLAM_TUTAR.SummaryItem.Assign(Util.GetSummaryItemByField(colTOPLAM_TUTAR));
                colKDV_TUTAR.SummaryItem.Assign(Util.GetSummaryItemByField(colKDV_TUTAR));
                colSTOPAJ_SSDF_TUTAR.SummaryItem.Assign(Util.GetSummaryItemByField(colSTOPAJ_SSDF_TUTAR));
                colADET.SummaryItem.Assign(Util.GetSummaryItemByFieldNumeric(colADET));

                #endregion Summary

                #region []

                GridColumn[] dizi = new[]
                                            {
                                                colID,
                                                colCARI_ID ,
                                                colSegmentId ,
                                                colCARI_HESAP_HEDEF_TIP ,
                                                colMASRAF_AVANS_ID ,
                                                colBORC_ALACAK_ID ,
                                                colTarih,
                                                colAciklama,
                                                colADET ,
                                                colBIRIM_FIYAT ,
                                                colBIRIM_FIYAT_DOVIZ_ID,                                                
                                                colTOPLAM_TUTAR ,
                                                colKDV_TUTAR ,
                                                colSTOPAJ_SSDF_TUTAR ,
                                                colGENEL_TOPLAM ,
                                                colBankaDekontNo ,
                                                colEFTReferansNo ,
                                                colREFERANS_NO ,
                                                colODEME_TIP_ID ,
                                                colHAREKET_ALT_KAREGORI_ID ,
                                                colFOY_NO,
                                                colADLI_BIRIM_ADLIYE_ID ,
                                                colADLI_BIRIM_NO_ID ,
                                                colADLI_BIRIM_GOREV_ID,
                                                colESAS_NO ,
                                                colINCELENDI,
                                                colONAY_DURUM ,
                                                colONAY_TARIHI ,
                                                colONAY_NO,
                                                colHAREKET_ANA_KATEGORI_ID ,
                                                colKasaHesapId ,
                                                colMuhatapHesapId ,
                                                colKiymetliEvrakId,
                                                colKAYIT_TARIHI
                                            };

                #endregion

                foreach (var item in dizi)
                {
                    item.OptionsColumn.ReadOnly = true;
                    item.OptionsColumn.AllowEdit = false;
                }
                return dizi;
            }
        }

        public class MuvekkilCariHesap
        {

            public GridColumn[] GetCariColumns()
            {
                #region RepositoryItem

                //RepositoryItemLookUpEdit rlueMasAvansTip = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueCari = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueBorcAlacak = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueOdemeTipi = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueHarAnaKat = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueHarAltKat = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueDoviz = new RepositoryItemLookUpEdit();

                #endregion

                #region InitsData

                BelgeUtil.Inits.ModulGetir(rlueDosyaTipi);
                //BelgeUtil.Inits.MasrafAvansTipGetir(rlueMasAvansTip);
                BelgeUtil.Inits.perCariGetir(rlueCari);
                BelgeUtil.Inits.BorcAlacakGetir(rlueBorcAlacak);
                BelgeUtil.Inits.OdemeTipiGetir(rlueOdemeTipi);
                BelgeUtil.Inits.MuhasebeHareketAltKategori(rlueHarAltKat);
                BelgeUtil.Inits.HareketAnaKategoriGetir(rlueHarAnaKat);
                BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
                BelgeUtil.Inits.ParaBicimiAyarla(rlueTutar);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliye);
                BelgeUtil.Inits.AdliBirimNoGetir(rlueAdliNo);
                BelgeUtil.Inits.AdliBirimGorevGetir(rlueAdliGorev);
                AvukatPro.Services.Implementations.DevExpressService.SegmentDoldur(rlueSegment);

                #endregion

                #region Field & Properties

                GridColumn colID = new GridColumn();
                GridColumn colCARI_ID = new GridColumn();
                GridColumn colSegmentId = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colCARI_HESAP_HEDEF_TIP = new GridColumn();
                GridColumn colMASRAF_AVANS_ID = new GridColumn();
                GridColumn colBORC_ALACAK_ID = new GridColumn();
                GridColumn colTarih = new GridColumn();
                GridColumn colADET = new GridColumn();
                GridColumn colBIRIM_FIYAT = new GridColumn();
                GridColumn colBIRIM_FIYAT_DOVIZ_ID = new GridColumn();
                GridColumn colGENEL_TOPLAM = new GridColumn();
                GridColumn colTOPLAM_TUTAR = new GridColumn();
                GridColumn colKDV_TUTAR = new GridColumn();
                GridColumn colSTOPAJ_SSDF_TUTAR = new GridColumn();
                GridColumn colBankaDekontNo = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colEFTReferansNo = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colREFERANS_NO = new GridColumn();
                GridColumn colODEME_TIP_ID = new GridColumn();
                GridColumn colHAREKET_ALT_KAREGORI_ID = new GridColumn();
                GridColumn colFOY_NO = new GridColumn();
                GridColumn colADLI_BIRIM_ADLIYE_ID = new GridColumn();
                GridColumn colADLI_BIRIM_NO_ID = new GridColumn();
                GridColumn colADLI_BIRIM_GOREV_ID = new GridColumn();
                GridColumn colESAS_NO = new GridColumn();
                GridColumn colAciklama = new GridColumn();

                GridColumn colHAREKET_ANA_KATEGORI_ID = new GridColumn();
                GridColumn colKasaHesapId = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colMuhatapHesapId = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colKiymetliEvrakId = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colKAYIT_TARIHI = new GridColumn();

                //
                //colID
                //
                colID.VisibleIndex = -1;
                colID.FieldName = "Id";
                colID.Name = "colID";
                colID.Visible = false;
                //
                //colCARI_ID
                //
                colCARI_ID.VisibleIndex = 0;
                colCARI_ID.Caption = "Personel";
                colCARI_ID.FieldName = "CariId";
                colCARI_ID.Name = "colCARI_ID";
                colCARI_ID.ColumnEdit = rlueCari;
                colCARI_ID.Visible = true;
                //
                //colSegmentId
                //
                colSegmentId.Caption = "Bölüm";
                colSegmentId.ColumnEdit = rlueSegment;
                colSegmentId.FieldName = "SegmentId";
                colSegmentId.Name = "colSegmentId";
                colSegmentId.Visible = true;
                colSegmentId.VisibleIndex = 1;
                //
                //colCARI_HESAP_HEDEF_TIP
                //
                colCARI_HESAP_HEDEF_TIP.VisibleIndex = 2;
                colCARI_HESAP_HEDEF_TIP.Caption = "Hesap Hedef Tip";
                colCARI_HESAP_HEDEF_TIP.FieldName = "CariHesapHedefTip";
                colCARI_HESAP_HEDEF_TIP.Name = "colCARI_HESAP_HEDEF_TIP";
                colCARI_HESAP_HEDEF_TIP.Visible = true;
                colCARI_HESAP_HEDEF_TIP.ColumnEdit = rlueDosyaTipi;
                //
                //colMASRAF_AVANS_ID
                //
                colMASRAF_AVANS_ID.VisibleIndex = 0;
                colMASRAF_AVANS_ID.Caption = "Masraf Avans";
                colMASRAF_AVANS_ID.FieldName = "MASRAF_AVANS_ID";
                colMASRAF_AVANS_ID.Name = "colMASRAF_AVANS_ID";
                //colMASRAF_AVANS_ID.ColumnEdit = rlueMasAvansTip;
                colMASRAF_AVANS_ID.Visible = false;
                //
                //colTarih
                //
                colTarih.VisibleIndex = 4;
                colTarih.Caption = "Hareket T.";
                colTarih.FieldName = "Tarih";
                colTarih.Name = "colTarih";
                colTarih.Visible = true;
                //
                //colAciklama
                //
                colAciklama.VisibleIndex = 4;
                colAciklama.Caption = "Açýklama";
                colAciklama.FieldName = "Aciklama";
                colAciklama.Name = "colAciklama";
                colAciklama.OptionsColumn.AllowEdit = false;
                colAciklama.Visible = false;
                //
                //colBORC_ALACAK_ID
                //
                colBORC_ALACAK_ID.VisibleIndex = 4;
                colBORC_ALACAK_ID.Caption = "B/A";
                colBORC_ALACAK_ID.FieldName = "BorcAlacakId";
                colBORC_ALACAK_ID.Name = "colBORC_ALACAK_ID";
                colBORC_ALACAK_ID.ColumnEdit = rlueBorcAlacak;
                colBORC_ALACAK_ID.Visible = true;
                //
                //colADET  
                //
                colADET.VisibleIndex = 5;
                colADET.Caption = "Adet";
                colADET.FieldName = "Adet";
                colADET.Name = "colADET";
                colADET.Visible = true;
                //
                //colBIRIM_FIYAT
                //
                colBIRIM_FIYAT.VisibleIndex = 6;
                colBIRIM_FIYAT.Caption = "Birim Fiyat";
                colBIRIM_FIYAT.FieldName = "BirimFiyat";
                colBIRIM_FIYAT.Name = "colBIRIM_FIYAT";
                colBIRIM_FIYAT.ColumnEdit = rlueTutar;
                colBIRIM_FIYAT.Visible = true;
                //
                //colBIRIM_FIYAT_DOVIZ_ID
                //
                colBIRIM_FIYAT_DOVIZ_ID.VisibleIndex = 7;
                colBIRIM_FIYAT_DOVIZ_ID.Caption = "Brm.";
                colBIRIM_FIYAT_DOVIZ_ID.FieldName = "BirimFiyatDovizId";
                colBIRIM_FIYAT_DOVIZ_ID.Name = "colBIRIM_FIYAT_DOVIZ_ID";
                colBIRIM_FIYAT_DOVIZ_ID.CustomizationCaption = "Birim Fiyat Döviz Tip";
                colBIRIM_FIYAT_DOVIZ_ID.ColumnEdit = rlueDoviz;
                colBIRIM_FIYAT_DOVIZ_ID.Visible = true;
                //
                // colTOPLAM_TUTAR
                //
                colTOPLAM_TUTAR.Caption = "Toplam Tutar";
                colTOPLAM_TUTAR.FieldName = "ToplamTutar";
                colTOPLAM_TUTAR.Name = "colTOPLAM_TUTAR";
                colTOPLAM_TUTAR.ColumnEdit = rlueTutar;
                colTOPLAM_TUTAR.Visible = true;
                colTOPLAM_TUTAR.VisibleIndex = 8;
                //
                // colKDV_TUTAR
                //
                colKDV_TUTAR.Caption = "KDV Tutar";
                colKDV_TUTAR.FieldName = "KdvTutar";
                colKDV_TUTAR.Name = "colKDV_TUTAR";
                colKDV_TUTAR.ColumnEdit = rlueTutar;
                colKDV_TUTAR.Visible = true;
                colKDV_TUTAR.VisibleIndex = 9;
                //
                // colSTOPAJ_SSDF_TUTAR
                //
                colSTOPAJ_SSDF_TUTAR.Caption = "Stopaj SSDF Tutarý";
                colSTOPAJ_SSDF_TUTAR.FieldName = "StopajSsdfTutar";
                colSTOPAJ_SSDF_TUTAR.Name = "colSTOPAJ_SSDF_TUTAR";
                colSTOPAJ_SSDF_TUTAR.ColumnEdit = rlueTutar;
                colSTOPAJ_SSDF_TUTAR.Visible = true;
                colSTOPAJ_SSDF_TUTAR.VisibleIndex = 10;
                //
                //colGENEL_TOPLAM
                //
                colGENEL_TOPLAM.VisibleIndex = 11;
                colGENEL_TOPLAM.Caption = "Genel Toplam";
                colGENEL_TOPLAM.FieldName = "GenelToplam";
                colGENEL_TOPLAM.Name = "colGENEL_TOPLAM";
                colGENEL_TOPLAM.ColumnEdit = rlueTutar;
                colGENEL_TOPLAM.Visible = true;
                //
                // colBankaDekontNo
                //
                colBankaDekontNo.Caption = "Dekont No";
                colBankaDekontNo.FieldName = "BankaDekontNo";
                colBankaDekontNo.Name = "colBankaDekontNo";
                colBankaDekontNo.Visible = true;
                colBankaDekontNo.VisibleIndex = 12;
                //
                // colEFTReferansNo
                //
                colEFTReferansNo.Caption = "Eft Referans";
                colEFTReferansNo.FieldName = "EftReferansNo";
                colEFTReferansNo.Name = "colEFTReferansNo";
                colEFTReferansNo.Visible = true;
                colEFTReferansNo.VisibleIndex = 13;
                //
                // colREFERANS_NO
                //
                colREFERANS_NO.Caption = "Referans";
                colREFERANS_NO.FieldName = "ReferansNo";
                colREFERANS_NO.Name = "colREFERANS_NO";
                colREFERANS_NO.Visible = true;
                colREFERANS_NO.VisibleIndex = 14;
                //
                //colODEME_TIP_ID
                //
                colODEME_TIP_ID.VisibleIndex = 15;
                colODEME_TIP_ID.Caption = "Ödeme Tip";
                colODEME_TIP_ID.FieldName = "OdemeTipId";
                colODEME_TIP_ID.Name = "colODEME_TIP_ID";
                colODEME_TIP_ID.ColumnEdit = rlueOdemeTipi;
                colODEME_TIP_ID.Visible = true;
                //
                //colHAREKET_ALT_KAREGORI_ID
                //
                colHAREKET_ALT_KAREGORI_ID.VisibleIndex = 16;
                colHAREKET_ALT_KAREGORI_ID.Caption = "Har. Alt Kat";
                colHAREKET_ALT_KAREGORI_ID.FieldName = "HareketAltKaregoriId";
                colHAREKET_ALT_KAREGORI_ID.Name = "colHAREKET_ALT_KAREGORI_ID";
                colHAREKET_ALT_KAREGORI_ID.ColumnEdit = rlueHarAltKat;
                colHAREKET_ALT_KAREGORI_ID.Visible = true;
                //
                // colFOY_NO
                //
                colFOY_NO.Caption = "Dosya No";
                colFOY_NO.FieldName = "FoyNo";
                colFOY_NO.Name = "colFOY_NO";
                colFOY_NO.Visible = true;
                colFOY_NO.VisibleIndex = 17;
                //
                // colADLI_BIRIM_ADLIYE_ID
                //
                colADLI_BIRIM_ADLIYE_ID.Caption = "Adliye";
                colADLI_BIRIM_ADLIYE_ID.FieldName = "AdliBirimAdliyeId";
                colADLI_BIRIM_ADLIYE_ID.Name = "colADLI_BIRIM_ADLIYE_ID";
                colADLI_BIRIM_ADLIYE_ID.ColumnEdit = rlueAdliye;
                colADLI_BIRIM_ADLIYE_ID.Visible = true;
                colADLI_BIRIM_ADLIYE_ID.VisibleIndex = 18;
                //
                // colADLI_BIRIM_NO_ID
                //
                colADLI_BIRIM_NO_ID.Caption = "No";
                colADLI_BIRIM_NO_ID.FieldName = "AdliBirimNoId";
                colADLI_BIRIM_NO_ID.Name = "colADLI_BIRIM_NO_ID";
                colADLI_BIRIM_NO_ID.ColumnEdit = rlueAdliNo;
                colADLI_BIRIM_NO_ID.Visible = true;
                colADLI_BIRIM_NO_ID.VisibleIndex = 19;
                //
                // colADLI_BIRIM_GOREV_ID
                //
                colADLI_BIRIM_GOREV_ID.Caption = "Görev";
                colADLI_BIRIM_GOREV_ID.FieldName = "AdliBirimGorevId";
                colADLI_BIRIM_GOREV_ID.Name = "colADLI_BIRIM_GOREV_ID";
                colADLI_BIRIM_GOREV_ID.ColumnEdit = rlueAdliGorev;
                colADLI_BIRIM_GOREV_ID.Visible = true;
                colADLI_BIRIM_GOREV_ID.VisibleIndex = 20;
                //
                // colESAS_NO
                //
                colESAS_NO.Caption = "Esas No";
                colESAS_NO.FieldName = "EsasNo";
                colESAS_NO.Name = "colESAS_NO";
                colESAS_NO.Visible = true;
                colESAS_NO.VisibleIndex = 21;
                //
                // colKasaHesapId
                //
                colKasaHesapId.Caption = "Kasa Hesap";
                colKasaHesapId.FieldName = "KasaHesapSahibiCariBankaId";
                colKasaHesapId.Name = "colKasaHesapId";
                colKasaHesapId.Visible = false;
                colKasaHesapId.VisibleIndex = -1;
                //
                // colMuhatapHesapId
                //
                colMuhatapHesapId.Caption = "Muhatap Hesap";
                colMuhatapHesapId.FieldName = "MuhatapHesapSahibiCariBankaId";
                colMuhatapHesapId.Name = "colMuhatapHesapId";
                colMuhatapHesapId.Visible = false;
                colMuhatapHesapId.VisibleIndex = -1;
                //
                // colKiymetliEvrakId
                //
                colKiymetliEvrakId.Caption = "";
                colKiymetliEvrakId.FieldName = "KiymetliEvrakId";
                colKiymetliEvrakId.Name = "colKiymetliEvrakId";
                colKiymetliEvrakId.Visible = false;
                colKiymetliEvrakId.VisibleIndex = -1;
                //
                //colHAREKET_ANA_KATEGORI_ID
                //
                colHAREKET_ANA_KATEGORI_ID.VisibleIndex = -1;
                colHAREKET_ANA_KATEGORI_ID.Caption = "Har.Ana Kat.";
                colHAREKET_ANA_KATEGORI_ID.FieldName = "HareketAnaKategoriId";
                colHAREKET_ANA_KATEGORI_ID.Name = "colHAREKET_ANA_KATEGORI_ID";
                colHAREKET_ANA_KATEGORI_ID.ColumnEdit = rlueHarAnaKat;
                colHAREKET_ANA_KATEGORI_ID.Visible = false;
                //
                //colKAYIT_TARIHI
                //
                colKAYIT_TARIHI.VisibleIndex = 22;
                colKAYIT_TARIHI.Caption = "Kayýt Tarihi";
                colKAYIT_TARIHI.FieldName = "KayitTarihi";
                colKAYIT_TARIHI.Name = "colKAYIT_TARIHI";
                colKAYIT_TARIHI.Visible = true;

                #endregion

                #region Summary

                StyleFormatCondition c1 = new StyleFormatCondition(FormatConditionEnum.Greater, colBIRIM_FIYAT, "", 0, 0, true);
                c1.Appearance.BackColor = System.Drawing.Color.LimeGreen;

                StyleFormatCondition c2 = new StyleFormatCondition(FormatConditionEnum.Less, colBIRIM_FIYAT, "", 0, 0, true);
                c2.Appearance.BackColor = System.Drawing.Color.Orange;

                colGENEL_TOPLAM.SummaryItem.Assign(Util.GetSummaryItemByField(colGENEL_TOPLAM));
                colTOPLAM_TUTAR.SummaryItem.Assign(Util.GetSummaryItemByField(colTOPLAM_TUTAR));
                colKDV_TUTAR.SummaryItem.Assign(Util.GetSummaryItemByField(colKDV_TUTAR));
                colSTOPAJ_SSDF_TUTAR.SummaryItem.Assign(Util.GetSummaryItemByField(colSTOPAJ_SSDF_TUTAR));
                colADET.SummaryItem.Assign(Util.GetSummaryItemByFieldNumeric(colADET));

                #endregion Summary

                #region []

                GridColumn[] dizi = new[]
                                            {
                                                colID,
                                                colCARI_ID ,
                                                colSegmentId ,
                                                colCARI_HESAP_HEDEF_TIP ,
                                                colMASRAF_AVANS_ID ,
                                                colBORC_ALACAK_ID ,
                                                colTarih,
                                                colAciklama,
                                                colADET ,
                                                colBIRIM_FIYAT ,
                                                colBIRIM_FIYAT_DOVIZ_ID,                                            
                                                colTOPLAM_TUTAR ,
                                                colKDV_TUTAR ,
                                                colSTOPAJ_SSDF_TUTAR ,
                                                colGENEL_TOPLAM ,
                                                colBankaDekontNo ,
                                                colEFTReferansNo ,
                                                colREFERANS_NO ,
                                                colODEME_TIP_ID ,
                                                colHAREKET_ALT_KAREGORI_ID ,
                                                colFOY_NO,
                                                colADLI_BIRIM_ADLIYE_ID ,
                                                colADLI_BIRIM_NO_ID ,
                                                colADLI_BIRIM_GOREV_ID,
                                                colESAS_NO ,                                             
                                                colHAREKET_ANA_KATEGORI_ID ,
                                                colKasaHesapId ,
                                                colMuhatapHesapId ,
                                                colKiymetliEvrakId,
                                                colKAYIT_TARIHI
                                            };

                #endregion

                foreach (var item in dizi)
                {
                    item.OptionsColumn.ReadOnly = true;
                    item.OptionsColumn.AllowEdit = false;
                }

                return dizi;
            }
        }

        public class MuvekkilHesap
        {

            public GridColumn[] GetHesapColumn()
            {
                #region RepositoryItem

                RepositoryItemLookUpEdit rlueFoyDurum = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueOzelKod1 = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueOzelKod2 = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueOzelKod3 = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueOzelKod4 = new RepositoryItemLookUpEdit();

                #endregion

                #region InitsData

                BelgeUtil.Inits.perCariGetir(rlueCari);
                BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
                BelgeUtil.Inits.FoyDurumGetir(rlueFoyDurum);
                BelgeUtil.Inits.ParaBicimiAyarla(rlueTutar);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliye);
                BelgeUtil.Inits.AdliBirimNoGetir(rlueAdliNo);
                BelgeUtil.Inits.AdliBirimGorevGetir(rlueAdliGorev);
                AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rlueOzelKod1, 1, AvukatProLib.Extras.Modul.Icra);
                AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rlueOzelKod2, 2, AvukatProLib.Extras.Modul.Icra);
                AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rlueOzelKod3, 3, AvukatProLib.Extras.Modul.Icra);
                AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rlueOzelKod4, 4, AvukatProLib.Extras.Modul.Icra);


                #endregion

                #region Field & Properties

                GridColumn colId = new GridColumn();
                GridColumn colIcraFoyId = new GridColumn();
                GridColumn colCariId = new GridColumn();
                GridColumn colBorcluId = new GridColumn();
                GridColumn colRiskMiktari = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colRiskMiktariDovizId = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colAlinanAvans = new GridColumn();
                GridColumn colIadeAvans = new GridColumn();
                GridColumn colMuvekkilTahsilati = new GridColumn();
                GridColumn colAvukatTahsilati = new GridColumn();
                GridColumn colResmiMasrafToplami = new GridColumn();
                GridColumn colDigerMasraflar = new GridColumn();
                GridColumn colDonmeyenGiderler = new GridColumn();
                //GridColumn colVekUcretiToplami = new GridColumn();
                //GridColumn colVekUcretiToplamiDovizId = new GridColumn();
                GridColumn colSozlesmeVekaletUcreti = new GridColumn();
                GridColumn colTakipVekaletUcreti = new GridColumn();
                GridColumn colTakipVekaletUcretiKdv = new GridColumn();
                GridColumn colTakipVekaletUcretiStopaj = new GridColumn();
                GridColumn colSozlesmeVekUcretiToplamiKdv = new GridColumn();
                GridColumn colSozlesmeVekUcretiToplamiStopaj = new GridColumn();
                GridColumn colMuvekkileOdemeToplami = new GridColumn();
                GridColumn colIndirim = new GridColumn();
                GridColumn colKalan = new GridColumn();
                GridColumn coFoyNo = new GridColumn();
                GridColumn colDurum = new GridColumn();
                GridColumn colAdliyeId = new GridColumn();
                GridColumn colAdliyeNoId = new GridColumn();
                GridColumn colGorev = new GridColumn();
                GridColumn colEsasNo = new GridColumn();
                GridColumn colTakipTarihi = new GridColumn();
                GridColumn colOzelKod1 = new GridColumn();
                GridColumn colOzelKod2 = new GridColumn();
                GridColumn colOzelKod3 = new GridColumn();
                GridColumn colOzelKod4 = new GridColumn();
                GridColumn colReferans1 = new GridColumn();
                GridColumn colReferans2 = new GridColumn();
                GridColumn colReferans3 = new GridColumn();
                GridColumn colSorumlu = new GridColumn();
                GridColumn colIzleyen = new GridColumn();
                GridColumn colSonHesapTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
                GridColumn colHesapKapamaTarihi = new DevExpress.XtraGrid.Columns.GridColumn();

                #region Column Properties

                //
                //colId
                //
                colId.Caption = "ID";
                colId.FieldName = "Id";
                colId.Name = "colId";
                colId.Visible = false;
                colId.VisibleIndex = -1;
                //
                //colIcraFoyId
                //
                colIcraFoyId.Caption = "";
                colIcraFoyId.FieldName = "IcraFoyId";
                colIcraFoyId.Name = "colIcraFoyId";
                colIcraFoyId.Visible = false;
                colIcraFoyId.VisibleIndex = -1;
                //
                //colCariId
                //
                colCariId.Caption = "Müvekkil";
                colCariId.FieldName = "TakipEdenCariId";
                colCariId.Name = "colCariId";
                colCariId.ColumnEdit = rlueCari;
                colCariId.Visible = true;
                colCariId.VisibleIndex = 0;
                //
                //colBorcluId
                //
                colBorcluId.Caption = "Borçlu";
                colBorcluId.FieldName = "TakipEdilenCariId";
                colBorcluId.Name = "colBorcluId";
                colBorcluId.ColumnEdit = rlueCari;
                colBorcluId.Visible = true;
                colBorcluId.VisibleIndex = 1;

                //
                //colAlinanAvans
                //
                colAlinanAvans.Caption = "Alýnan Avans";
                colAlinanAvans.FieldName = "AlinanAvans";
                colAlinanAvans.Name = "colAlinanAvans";
                colAlinanAvans.ColumnEdit = rlueTutar;
                colAlinanAvans.Visible = true;
                colAlinanAvans.VisibleIndex = 2;
                //
                //colIadeAvans
                //
                colIadeAvans.Caption = "Ýade Avans";
                colIadeAvans.FieldName = "IadeAvans";
                colIadeAvans.Name = "colIadeAvans";
                colIadeAvans.ColumnEdit = rlueTutar;
                colIadeAvans.Visible = true;
                colIadeAvans.VisibleIndex = 3;
                //
                //colMuvekkilTahsilati
                //
                colMuvekkilTahsilati.Caption = "Müv. Tah.";
                colMuvekkilTahsilati.FieldName = "MuvekkilTahsilati";
                colMuvekkilTahsilati.Name = "colMuvekkilTahsilati";
                colMuvekkilTahsilati.ColumnEdit = rlueTutar;
                colMuvekkilTahsilati.Visible = true;
                colMuvekkilTahsilati.VisibleIndex = 4;
                //
                //colAvukatTahsilati
                //
                colAvukatTahsilati.Caption = "Av. Tah.";
                colAvukatTahsilati.FieldName = "AvukatTahsilati";
                colAvukatTahsilati.Name = "colAvukatTahsilati";
                colAvukatTahsilati.ColumnEdit = rlueTutar;
                colAvukatTahsilati.Visible = true;
                colAvukatTahsilati.VisibleIndex = 5;
                //
                //colResmiMasrafToplami
                //
                colResmiMasrafToplami.Caption = "Resmi Masraf";
                colResmiMasrafToplami.FieldName = "ResmiMasrafToplami";
                colResmiMasrafToplami.Name = "colResmiMasrafToplami";
                colResmiMasrafToplami.ColumnEdit = rlueTutar;
                colResmiMasrafToplami.Visible = true;
                colResmiMasrafToplami.VisibleIndex = 6;
                //
                //colDigerMasraflar
                //
                colDigerMasraflar.Caption = "Resmi Olmayan G.";
                colDigerMasraflar.FieldName = "DigerMasrafToplami";
                colDigerMasraflar.Name = "colDigerMasraflar";
                colDigerMasraflar.ColumnEdit = rlueTutar;
                colDigerMasraflar.Visible = true;
                colDigerMasraflar.VisibleIndex = 7;
                //
                //colDonmeyenGiderler
                //
                colDonmeyenGiderler.Caption = "Dönmeyen G.";
                colDonmeyenGiderler.FieldName = "DonmeyenGiderToplami";
                colDonmeyenGiderler.Name = "colDonmeyenGiderler";
                colDonmeyenGiderler.ColumnEdit = rlueTutar;
                colDonmeyenGiderler.Visible = true;
                colDonmeyenGiderler.VisibleIndex = 8;
                //
                //colTakipVekaletUcretio
                //
                colTakipVekaletUcreti.Caption = "Tak. Vek.";
                colTakipVekaletUcreti.FieldName = "TakipVekaletUcreti";
                colTakipVekaletUcreti.Name = "colTakipVekaletUcreti";
                colTakipVekaletUcreti.ColumnEdit = rlueTutar;
                colTakipVekaletUcreti.Visible = true;
                colTakipVekaletUcreti.VisibleIndex = 9;
                //
                //colTakipVekaletUcretiKdv
                //
                colTakipVekaletUcretiKdv.Caption = "Tak. Vek. Kdv";
                colTakipVekaletUcretiKdv.FieldName = "TakipVekaletUcretleriKdv";
                colTakipVekaletUcretiKdv.Name = "colTakipVekaletUcretiKdv";
                colTakipVekaletUcretiKdv.ColumnEdit = rlueTutar;
                colTakipVekaletUcretiKdv.Visible = true;
                colTakipVekaletUcretiKdv.VisibleIndex = 10;
                //
                //colTakipVekaletUcretiStopaj
                //
                colTakipVekaletUcretiStopaj.Caption = "Tak. Vek. Stopaj";
                colTakipVekaletUcretiStopaj.FieldName = "TakipVekaletUcretleriStopaj";
                colTakipVekaletUcretiStopaj.Name = "colTakipVekaletUcretiStopaj";
                colTakipVekaletUcretiStopaj.ColumnEdit = rlueTutar;
                colTakipVekaletUcretiStopaj.Visible = true;
                colTakipVekaletUcretiStopaj.VisibleIndex = 11;
                //
                //colSozlesmeVekaletUcreti
                //
                colSozlesmeVekaletUcreti.Caption = "Söz. Vek.";
                colSozlesmeVekaletUcreti.FieldName = "ToplamSozlesmeVekaletUcreti";
                colSozlesmeVekaletUcreti.Name = "colBankaDekontNo";
                colSozlesmeVekaletUcreti.ColumnEdit = rlueTutar;
                colSozlesmeVekaletUcreti.Visible = true;
                colSozlesmeVekaletUcreti.VisibleIndex = 12;
                //
                //colVekUcretiToplamiKdv
                //
                colSozlesmeVekUcretiToplamiKdv.Caption = "Soz. Vek. Kdv";
                colSozlesmeVekUcretiToplamiKdv.FieldName = "ToplamSozlesmeVekaletUcretiKdvTutari";
                colSozlesmeVekUcretiToplamiKdv.Name = "colVekUcretiToplamiKdv";
                colSozlesmeVekUcretiToplamiKdv.ColumnEdit = rlueTutar;
                colSozlesmeVekUcretiToplamiKdv.Visible = true;
                colSozlesmeVekUcretiToplamiKdv.VisibleIndex = 13;
                //
                //colVekUcretiToplamiStopaj
                //
                colSozlesmeVekUcretiToplamiStopaj.Caption = "Soz. Vek. Stopaj";
                colSozlesmeVekUcretiToplamiStopaj.FieldName = "ToplamSozlesmeVekaletUcretiStopajTutari";
                colSozlesmeVekUcretiToplamiStopaj.Name = "colVekUcretiToplamiStopaj";
                colSozlesmeVekUcretiToplamiStopaj.ColumnEdit = rlueTutar;
                colSozlesmeVekUcretiToplamiStopaj.Visible = true;
                colSozlesmeVekUcretiToplamiStopaj.VisibleIndex = 14;
                //
                //colMuvekkileOdemeToplami
                //
                colMuvekkileOdemeToplami.Caption = "Müv. Ödeme";
                colMuvekkileOdemeToplami.FieldName = "MuvekkileOdemeToplami";
                colMuvekkileOdemeToplami.Name = "colMuvekkileOdemeToplami";
                colMuvekkileOdemeToplami.ColumnEdit = rlueTutar;
                colMuvekkileOdemeToplami.Visible = true;
                colMuvekkileOdemeToplami.VisibleIndex = 15;
                //
                //colIndirim
                //
                colIndirim.Caption = "Indirim";
                colIndirim.FieldName = "IndirimMiktari";
                colIndirim.Name = "colIndirim";
                colIndirim.ColumnEdit = rlueTutar;
                colIndirim.Visible = true;
                colIndirim.VisibleIndex = 16;
                //
                //colKalan
                //               
                colKalan.Caption = "Kalan";
                colKalan.FieldName = "KalanTutar";
                colKalan.Name = "colKalan";
                colKalan.ColumnEdit = rlueTutar;
                colKalan.Visible = true;
                colKalan.VisibleIndex = 17;
                //
                // coFoyNo
                //
                coFoyNo.Caption = "Dosya No";
                coFoyNo.FieldName = "FoyNo";
                coFoyNo.Name = "coFoyNo";
                coFoyNo.Visible = true;
                coFoyNo.VisibleIndex = 18;
                //
                // colDurum
                //
                colDurum.Caption = "Durum";
                colDurum.FieldName = "FoyDurumId";
                colDurum.Name = "colDurum";
                colDurum.ColumnEdit = rlueFoyDurum;
                colDurum.Visible = true;
                colDurum.VisibleIndex = 19;
                //
                // colAdliyeId
                //
                colAdliyeId.Caption = "Müdürlük";
                colAdliyeId.FieldName = "AdliBirimAdliyeId";
                colAdliyeId.Name = "colAdliyeId";
                colAdliyeId.ColumnEdit = rlueAdliye;
                colAdliyeId.Visible = true;
                colAdliyeId.VisibleIndex = 20;
                //
                // colAdliyeNoId
                //
                colAdliyeNoId.Caption = "No";
                colAdliyeNoId.FieldName = "AdliBirimNoId";
                colAdliyeNoId.Name = "colAdliyeNoId";
                colAdliyeNoId.ColumnEdit = rlueAdliNo;
                colAdliyeNoId.Visible = true;
                colAdliyeNoId.VisibleIndex = 21;
                //
                // colGorev
                //
                colGorev.Caption = "Gorev";
                colGorev.FieldName = "Gorev";
                colGorev.Name = "colGorev";
                colGorev.Visible = true;
                colGorev.VisibleIndex = 22;
                //
                // colEsasNo
                //
                colEsasNo.Caption = "Esas No";
                colEsasNo.FieldName = "EsasNo";
                colEsasNo.Name = "colEsasNo";
                colEsasNo.Visible = true;
                colEsasNo.VisibleIndex = 23;
                //
                // colTakipTarihi
                //
                colTakipTarihi.Caption = "Takip T.";
                colTakipTarihi.FieldName = "TakipTarihi";
                colTakipTarihi.Name = "colTakipTarihi";
                colTakipTarihi.Visible = true;
                colTakipTarihi.VisibleIndex = 24;
                //
                //colReferans1
                //
                colReferans1.Caption = Kimlikci.Kimlik.IcraReferans.Referans1;
                colReferans1.FieldName = "ReferansNo";
                colReferans1.Name = "colReferans1";
                colReferans1.Visible = false;
                colReferans1.VisibleIndex = -1;
                //
                //colReferans2
                //
                colReferans2.Caption = Kimlikci.Kimlik.IcraReferans.Referans2;
                colReferans2.FieldName = "ReferansNo2";
                colReferans2.Name = "colReferans2";
                colReferans2.Visible = false;
                colReferans2.VisibleIndex = -1;
                //
                //colReferans3
                //
                colReferans3.Caption = Kimlikci.Kimlik.IcraReferans.Referans3;
                colReferans3.FieldName = "ReferansNo3";
                colReferans3.Name = "colReferans3";
                colReferans3.Visible = false;
                colReferans3.VisibleIndex = -1;
                //
                //colSorumlu
                //
                colSorumlu.Caption = "Sorumlu";
                colSorumlu.FieldName = "SorumluAvukatCariId";
                colSorumlu.Name = "colSorumlu";
                colSorumlu.Visible = false;
                colSorumlu.ColumnEdit = rlueCari;
                colSorumlu.VisibleIndex = -1;
                //
                //colIzleyen
                //
                colIzleyen.Caption = "Ýzleyen";
                colIzleyen.FieldName = "IzleyenCariId";
                colIzleyen.Name = "colIzleyen";
                colIzleyen.Visible = false;
                colIzleyen.ColumnEdit = rlueCari;
                colIzleyen.VisibleIndex = -1;
                //
                //colSonHesapTarihi
                //
                colSonHesapTarihi.Caption = "Hesap T.";
                colSonHesapTarihi.FieldName = "SonHesapTarihi";
                colSonHesapTarihi.Name = "colSonHesapTarihi";
                colSonHesapTarihi.Visible = true;
                colSonHesapTarihi.VisibleIndex = 25;
                //
                //colHesapKapamaTarihi
                //                 
                colHesapKapamaTarihi.Caption = "H. Kapama T.";
                colHesapKapamaTarihi.FieldName = "HesapKapamaTarihi";
                colHesapKapamaTarihi.Name = "colHesapKapamaTarihi";
                colHesapKapamaTarihi.Visible = true;
                colHesapKapamaTarihi.VisibleIndex = 26;
                //
                // colOzelKod1
                //
                colOzelKod1.Caption = Kimlikci.Kimlik.IcraOzelKod.OzelKod1;
                colOzelKod1.FieldName = "IcraOzelKod1Id";
                colOzelKod1.Name = "colOzelKod1";
                colOzelKod1.ColumnEdit = rlueOzelKod1;
                colOzelKod1.Visible = true;
                colOzelKod1.VisibleIndex = 27;
                //
                // colOzelKod2
                //
                colOzelKod2.Caption = Kimlikci.Kimlik.IcraOzelKod.OzelKod2;
                colOzelKod2.FieldName = "IcraOzelKod2Id";
                colOzelKod2.Name = "colOzelKod2";
                colOzelKod2.ColumnEdit = rlueOzelKod2;
                colOzelKod2.Visible = true;
                colOzelKod2.VisibleIndex = 28;
                //
                // colOzelKod3
                //
                colOzelKod3.Caption = Kimlikci.Kimlik.IcraOzelKod.OzelKod3;
                colOzelKod3.FieldName = "IcraOzelKod3Id";
                colOzelKod3.Name = "colOzelKod3";
                colOzelKod3.ColumnEdit = rlueOzelKod3;
                colOzelKod3.Visible = true;
                colOzelKod3.VisibleIndex = 29;
                //
                // colOzelKod4
                //
                colOzelKod4.Caption = Kimlikci.Kimlik.IcraOzelKod.OzelKod4;
                colOzelKod4.FieldName = "IcraOzelKod4Id";
                colOzelKod4.Name = "colOzelKod4";
                colOzelKod4.ColumnEdit = rlueOzelKod4;
                colOzelKod4.Visible = true;
                colOzelKod4.VisibleIndex = 30;
                //
                // colRiskMiktari
                //
                colRiskMiktari.Caption = "Risk Miktarý";
                colRiskMiktari.FieldName = "RiskMiktari";
                colRiskMiktari.Name = "colRiskMiktari";
                colRiskMiktari.ColumnEdit = rlueTutar;
                colRiskMiktari.Visible = true;
                colRiskMiktari.VisibleIndex = 31;
                //
                // colRiskMiktariDovizId
                //
                colRiskMiktariDovizId.Caption = "RMD";
                colRiskMiktariDovizId.FieldName = "RiskMiktariDovizId";
                colRiskMiktariDovizId.Name = "colRiskMiktariDovizId";
                colRiskMiktariDovizId.ColumnEdit = rlueDoviz;
                colRiskMiktariDovizId.Visible = false;
                colRiskMiktariDovizId.VisibleIndex = -1;


                #endregion

                #endregion

                #region Summary

                colRiskMiktari.SummaryItem.Assign(Util.GetSummaryItemByField(colRiskMiktari));
                colAlinanAvans.SummaryItem.Assign(Util.GetSummaryItemByField(colAlinanAvans));
                colIadeAvans.SummaryItem.Assign(Util.GetSummaryItemByField(colIadeAvans));
                colMuvekkilTahsilati.SummaryItem.Assign(Util.GetSummaryItemByField(colMuvekkilTahsilati));
                colAvukatTahsilati.SummaryItem.Assign(Util.GetSummaryItemByField(colAvukatTahsilati));
                colResmiMasrafToplami.SummaryItem.Assign(Util.GetSummaryItemByField(colResmiMasrafToplami));
                colDigerMasraflar.SummaryItem.Assign(Util.GetSummaryItemByField(colDigerMasraflar));
                colResmiMasrafToplami.SummaryItem.Assign(Util.GetSummaryItemByField(colResmiMasrafToplami));
                colDonmeyenGiderler.SummaryItem.Assign(Util.GetSummaryItemByField(colDonmeyenGiderler));
                colSozlesmeVekaletUcreti.SummaryItem.Assign(Util.GetSummaryItemByField(colSozlesmeVekaletUcreti));
                colSozlesmeVekUcretiToplamiKdv.SummaryItem.Assign(Util.GetSummaryItemByField(colSozlesmeVekUcretiToplamiKdv));
                colSozlesmeVekUcretiToplamiStopaj.SummaryItem.Assign(Util.GetSummaryItemByField(colSozlesmeVekUcretiToplamiStopaj));
                colTakipVekaletUcreti.SummaryItem.Assign(Util.GetSummaryItemByField(colTakipVekaletUcreti));
                colTakipVekaletUcretiKdv.SummaryItem.Assign(Util.GetSummaryItemByField(colTakipVekaletUcretiKdv));
                colTakipVekaletUcretiStopaj.SummaryItem.Assign(Util.GetSummaryItemByField(colTakipVekaletUcretiStopaj));
                colMuvekkileOdemeToplami.SummaryItem.Assign(Util.GetSummaryItemByField(colMuvekkileOdemeToplami));
                colIndirim.SummaryItem.Assign(Util.GetSummaryItemByField(colIndirim));
                colKalan.SummaryItem.Assign(Util.GetSummaryItemByField(colKalan));



                #endregion Summary

                #region []

                GridColumn[] dizi = new[]
                    {
                        colId,
                        colIcraFoyId,
                        colCariId,
                        colBorcluId,
                        colRiskMiktari,
                        colRiskMiktariDovizId,
                        colAlinanAvans,
                        colIadeAvans,
                        colMuvekkilTahsilati,
                        colAvukatTahsilati,
                        colResmiMasrafToplami,
                        colDigerMasraflar,
                        colDonmeyenGiderler,                 
                        colSozlesmeVekaletUcreti,
                        colSozlesmeVekUcretiToplamiKdv,
                        colSozlesmeVekUcretiToplamiStopaj,
                        colTakipVekaletUcreti,
                        colTakipVekaletUcretiKdv,
                        colTakipVekaletUcretiStopaj,
                        colMuvekkileOdemeToplami,
                        colIndirim,
                        colKalan,
                        coFoyNo,
                        colDurum,
                        colAdliyeId,
                        colAdliyeNoId,
                        colGorev,
                        colEsasNo,
                        colTakipTarihi,
                        colOzelKod1,
                        colOzelKod2,
                        colOzelKod3,
                        colOzelKod4,
                        colReferans1,
                        colReferans2, 
                        colReferans3,
                        colSorumlu,
                        colIzleyen,
                        colSonHesapTarihi,
                        colHesapKapamaTarihi                      
                    };

                #endregion

                foreach (var item in dizi)
                {
                    item.OptionsColumn.ReadOnly = true;
                    item.OptionsColumn.AllowEdit = false;
                }

                return dizi;
            }
        }

        public class MuhasebeBirlesikDetayli
        {
            public Dictionary<string, string> GetColumnCaptionDictinory()
            {
                Dictionary<string, string> dicFieldCaption = new Dictionary<string, string>();

                #region Caption Edit

                dicFieldCaption.Add("ID", "Id");
                dicFieldCaption.Add("MUHASEBE_HEDEF_TIP", "Muhasebe Hedef Tip");
                dicFieldCaption.Add("MASRAF_AVANS_ID", "Masraf Avans");
                dicFieldCaption.Add("REFERANS_NO", "Referans No");
                dicFieldCaption.Add("OTOMATIK_HESAPLANDI", "Otomatik Hesaplandý");
                dicFieldCaption.Add("ACIKLAMA", "Açýklama");
                dicFieldCaption.Add("KLASOR_KODU", "Klasör Kodu");
                dicFieldCaption.Add("SUBE_KODU", "Þube Kodu");
                dicFieldCaption.Add("KONTROL_NE_ZAMAN", "Kontrol Ne Zaman");
                dicFieldCaption.Add("KONTROL_KIM", "Kontrol Kim");
                dicFieldCaption.Add("KONTROL_VERSIYON", "Kontrol Versiyon");
                dicFieldCaption.Add("STAMP", "Stamp");
                dicFieldCaption.Add("ASAMA_ID", "Aþama");
                dicFieldCaption.Add("KONTROL_KIM_ID", "Kontrol Kim");
                dicFieldCaption.Add("SUBE_KOD_ID", "Þube Kod");
                dicFieldCaption.Add("DETAY_ID", "Detay");
                dicFieldCaption.Add("YENIDEN_HESAPLANABILIR", "Yeniden Hesaplanabilir");
                dicFieldCaption.Add("TARIH", "Tarih");
                dicFieldCaption.Add("HAREKET_ANA_KATEGORI_ID", "Hareket Ana Kategori");
                dicFieldCaption.Add("HAREKET_ALT_KATEGORI_ID", "Hareket Alt Kategori");
                dicFieldCaption.Add("ADET", "Adet");
                dicFieldCaption.Add("BIRIM_FIYAT", "Birim Fiyat");
                dicFieldCaption.Add("KDV_DAHIL", "KDV Dahil");
                dicFieldCaption.Add("KDV_ORAN", "KDV Oraný");
                dicFieldCaption.Add("KDV_TUTAR", "KDV Tutarý");
                dicFieldCaption.Add("STOPAJ_SSDF_DAHIL", "SSDF Dahil");
                dicFieldCaption.Add("STOPAJ_ORAN", "Stopaj Oraný");
                dicFieldCaption.Add("SSDF_ORAN", "SSDF Oran");
                dicFieldCaption.Add("STOPAJ_SSDF_TUTAR", "Stopaj SSDF Tutarý");
                dicFieldCaption.Add("TOPLAM_TUTAR", "Toplam Tutar");
                dicFieldCaption.Add("GENEL_TOPLAM", "Genel Toplam");
                dicFieldCaption.Add("DETAY_ACIKLAMA", "Detay Açýklama");
                dicFieldCaption.Add("KAYIT_ID", "Kayýt Id");
                dicFieldCaption.Add("KAYIT_TIP", "Kayýt Tipi");
                dicFieldCaption.Add("FOY_NO", "Dosya No");
                dicFieldCaption.Add("ADLI_BIRIM_ADLIYE_ID", "Müdürlük");
                dicFieldCaption.Add("ADLI_BIRIM_NO_ID", "No");
                dicFieldCaption.Add("ADLI_BIRIM_GOREV_ID", "Görev");
                dicFieldCaption.Add("ESAS_NO", "Esas No");
                dicFieldCaption.Add("TAKIP_TARIHI", "Takip Tarihi");
                dicFieldCaption.Add("INTIKAL_TARIHI", "Ýntikal Tarihi");

                #endregion

                return dicFieldCaption;
            }

            public Dictionary<string, RepositoryItem> GetRepositoryItemByFieldName()
            {
                RepositoryItemLookUpEdit rlueDoviz = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueHareketAnaKat = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueHareketAltKat = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueAdliye = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueAdliyeNo = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueAdliyeGorev = new RepositoryItemLookUpEdit();

                BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
                BelgeUtil.Inits.HareketAnaKategoriGetir(rlueHareketAnaKat);
                BelgeUtil.Inits.MuhasebeHareketAltKategori(rlueHareketAltKat);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliye);
                BelgeUtil.Inits.AdliBirimGorevGetir(rlueAdliyeGorev);
                BelgeUtil.Inits.AdliBirimNoGetir(rlueAdliyeNo);

                Dictionary<string, RepositoryItem> sozluk = new Dictionary<string, RepositoryItem>();

                #region Add item

                sozluk.Add("DovizId", rlueDoviz);
                //sozluk.Add("KAYIT_ID", Item);
                //sozluk.Add("MASRAF_AVANS_ID", Item);
                //sozluk.Add("ASAMA_ID", Item);
                //sozluk.Add("KONTROL_KIM_ID", Item);
                //sozluk.Add("SUBE_KOD_ID", Item);
                //sozluk.Add("DETAY_ID", Item);
                sozluk.Add("HAREKET_ANA_KATEGORI_ID", rlueHareketAnaKat);
                sozluk.Add("HAREKET_ALT_KATEGORI_ID", rlueHareketAltKat);
                sozluk.Add("ADLI_BIRIM_ADLIYE_ID", rlueAdliye);
                sozluk.Add("ADLI_BIRIM_NO_ID", rlueAdliyeNo);
                sozluk.Add("ADLI_BIRIM_GOREV_ID", rlueAdliyeGorev);

                #endregion

                return sozluk;
            }

            public GridColumn[] GetColumn()
            {
                #region RepositoryItem

                RepositoryItemLookUpEdit rlueMuhHesapTip = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueHarAnaKat = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueHarAltKat = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueDoviz = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueAdliye = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueAdliNo = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueAdliGorev = new RepositoryItemLookUpEdit();
                RepositoryItemSpinEdit rSpinTutar = new RepositoryItemSpinEdit();
                RepositoryItemSpinEdit rSpinOran = new RepositoryItemSpinEdit();
                RepositoryItemMemoExEdit aciklama = new RepositoryItemMemoExEdit();
                RepositoryItemLookUpEdit rlueMasAvansTip = new RepositoryItemLookUpEdit();

                #endregion

                #region InitsData

                BelgeUtil.Inits.MasrafAvansTipGetir(rlueMasAvansTip);
                BelgeUtil.Inits.HesapTipiGetir(rlueMuhHesapTip);
                BelgeUtil.Inits.MuhasebeHareketAltKategori(rlueHarAltKat);
                BelgeUtil.Inits.HareketAnaKategoriGetir(rlueHarAnaKat);
                BelgeUtil.Inits.DovizIslemTipiGetir(rlueDoviz);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliye);
                BelgeUtil.Inits.AdliBirimGorevGetir(rlueAdliGorev);
                BelgeUtil.Inits.AdliBirimNoGetir(rlueAdliNo);
                BelgeUtil.Inits.ParaBicimiAyarla(rSpinTutar);
                BelgeUtil.Inits.YuzdeBicimiAyarla(rSpinOran);

                #endregion

                #region Field & Properties

                GridColumn colID = new GridColumn();
                colID.VisibleIndex = 0;
                colID.FieldName = "ID";
                colID.Name = "colID";
                colID.Visible = true;

                GridColumn colMUHASEBE_HEDEF_TIP = new GridColumn();
                colMUHASEBE_HEDEF_TIP.VisibleIndex = 1;
                colMUHASEBE_HEDEF_TIP.Caption = "Muhasebe Hedef Tip";
                colMUHASEBE_HEDEF_TIP.FieldName = "MUHASEBE_HEDEF_TIP";
                colMUHASEBE_HEDEF_TIP.Name = "colMUHASEBE_HEDEF_TIP";
                colMUHASEBE_HEDEF_TIP.Visible = true;

                GridColumn colMASRAF_AVANS_ID = new GridColumn();
                colMASRAF_AVANS_ID.VisibleIndex = 2;
                colMASRAF_AVANS_ID.Caption = "Masraf Avans";
                colMASRAF_AVANS_ID.FieldName = "MASRAF_AVANS_ID";
                colMASRAF_AVANS_ID.Name = "colMASRAF_AVANS_ID";
                colMASRAF_AVANS_ID.ColumnEdit = rlueMasAvansTip;
                colMASRAF_AVANS_ID.Visible = true;

                GridColumn colREFERANS_NO = new GridColumn();
                colREFERANS_NO.VisibleIndex = 3;
                colREFERANS_NO.Caption = "Referans No";
                colREFERANS_NO.FieldName = "REFERANS_NO";
                colREFERANS_NO.Name = "colREFERANS_NO";
                colREFERANS_NO.Visible = true;

                GridColumn colOTOMATIK_HESAPLANDI = new GridColumn();
                colOTOMATIK_HESAPLANDI.VisibleIndex = 4;
                colOTOMATIK_HESAPLANDI.Caption = "Otomatik Hesaplandý";
                colOTOMATIK_HESAPLANDI.FieldName = "OTOMATIK_HESAPLANDI";
                colOTOMATIK_HESAPLANDI.Name = "colOTOMATIK_HESAPLANDI";
                colOTOMATIK_HESAPLANDI.Visible = true;

                GridColumn colACIKLAMA = new GridColumn();
                colACIKLAMA.VisibleIndex = 5;
                colACIKLAMA.Caption = "Açýklama";
                colACIKLAMA.FieldName = "ACIKLAMA";
                colACIKLAMA.Name = "colACIKLAMA";
                colACIKLAMA.ColumnEdit = aciklama;
                colACIKLAMA.Visible = true;

                GridColumn colKLASOR_KODU = new GridColumn();
                colKLASOR_KODU.VisibleIndex = 6;
                colKLASOR_KODU.Caption = "Klasör Kodu";
                colKLASOR_KODU.FieldName = "KLASOR_KODU";
                colKLASOR_KODU.Name = "colKLASOR_KODU";
                colKLASOR_KODU.Visible = true;

                GridColumn colSUBE_KODU = new GridColumn();
                colSUBE_KODU.VisibleIndex = 7;
                colSUBE_KODU.Caption = "Þube Kodu";
                colSUBE_KODU.FieldName = "SUBE_KODU";
                colSUBE_KODU.Name = "colSUBE_KODU";
                colSUBE_KODU.Visible = true;

                GridColumn colKONTROL_NE_ZAMAN = new GridColumn();
                colKONTROL_NE_ZAMAN.VisibleIndex = 8;
                colKONTROL_NE_ZAMAN.Caption = "Kontrol Ne Zaman";
                colKONTROL_NE_ZAMAN.FieldName = "KONTROL_NE_ZAMAN";
                colKONTROL_NE_ZAMAN.Name = "colKONTROL_NE_ZAMAN";
                colKONTROL_NE_ZAMAN.Visible = true;

                GridColumn colKONTROL_KIM = new GridColumn();
                colKONTROL_KIM.VisibleIndex = 9;
                colKONTROL_KIM.Caption = "Kontrol Kim";
                colKONTROL_KIM.FieldName = "KONTROL_KIM";
                colKONTROL_KIM.Name = "colKONTROL_KIM";
                colKONTROL_KIM.Visible = true;

                GridColumn colKONTROL_VERSIYON = new GridColumn();
                colKONTROL_VERSIYON.VisibleIndex = 10;
                colKONTROL_VERSIYON.Caption = "Kontrol Versiyon";
                colKONTROL_VERSIYON.FieldName = "KONTROL_VERSIYON";
                colKONTROL_VERSIYON.Name = "colKONTROL_VERSIYON";
                colKONTROL_VERSIYON.Visible = true;

                GridColumn colSTAMP = new GridColumn();
                colSTAMP.VisibleIndex = 11;
                colSTAMP.Caption = "Stamp";
                colSTAMP.FieldName = "STAMP";
                colSTAMP.Name = "colSTAMP";
                colSTAMP.Visible = true;

                GridColumn colASAMA_ID = new GridColumn();
                colASAMA_ID.VisibleIndex = 12;
                colASAMA_ID.Caption = "Aþama";
                colASAMA_ID.FieldName = "ASAMA_ID";
                colASAMA_ID.Name = "colASAMA_ID";
                colASAMA_ID.Visible = true;

                GridColumn colKONTROL_KIM_ID = new GridColumn();
                colKONTROL_KIM_ID.VisibleIndex = 13;
                colKONTROL_KIM_ID.Caption = "Ýþlem Yapan";
                colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
                colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
                colKONTROL_KIM_ID.Visible = false;

                GridColumn colSUBE_KOD_ID = new GridColumn();
                colSUBE_KOD_ID.VisibleIndex = 14;
                colSUBE_KOD_ID.Caption = "Þube Kodu";
                colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
                colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
                colSUBE_KOD_ID.Visible = true;

                GridColumn colDETAY_ID = new GridColumn();
                colDETAY_ID.VisibleIndex = 15;
                colDETAY_ID.Caption = "Detay";
                colDETAY_ID.FieldName = "DETAY_ID";
                colDETAY_ID.Name = "colDETAY_ID";
                colDETAY_ID.Visible = false;

                GridColumn colYENIDEN_HESAPLANABILIR = new GridColumn();
                colYENIDEN_HESAPLANABILIR.VisibleIndex = 16;
                colYENIDEN_HESAPLANABILIR.Caption = "Yeniden Hesaplanabilir";
                colYENIDEN_HESAPLANABILIR.FieldName = "YENIDEN_HESAPLANABILIR";
                colYENIDEN_HESAPLANABILIR.Name = "colYENIDEN_HESAPLANABILIR";
                colYENIDEN_HESAPLANABILIR.Visible = true;

                GridColumn colTARIH = new GridColumn();
                colTARIH.VisibleIndex = 17;
                colTARIH.Caption = "Tarih";
                colTARIH.FieldName = "TARIH";
                colTARIH.Name = "colTARIH";
                colTARIH.Visible = true;

                GridColumn colHAREKET_ANA_KATEGORI_ID = new GridColumn();
                colHAREKET_ANA_KATEGORI_ID.VisibleIndex = 18;
                colHAREKET_ANA_KATEGORI_ID.Caption = "Har.Ana Kat.";
                colHAREKET_ANA_KATEGORI_ID.FieldName = "HAREKET_ANA_KATEGORI_ID";
                colHAREKET_ANA_KATEGORI_ID.Name = "colHAREKET_ANA_KATEGORI_ID";
                colHAREKET_ANA_KATEGORI_ID.ColumnEdit = rlueHarAnaKat;
                colHAREKET_ANA_KATEGORI_ID.Visible = true;

                GridColumn colHAREKET_ALT_KATEGORI_ID = new GridColumn();
                colHAREKET_ALT_KATEGORI_ID.VisibleIndex = 19;
                colHAREKET_ALT_KATEGORI_ID.Caption = "Har. Alt. Kat";
                colHAREKET_ALT_KATEGORI_ID.FieldName = "HAREKET_ALT_KATEGORI_ID";
                colHAREKET_ALT_KATEGORI_ID.Name = "colHAREKET_ALT_KATEGORI_ID";
                colHAREKET_ALT_KATEGORI_ID.ColumnEdit = rlueHarAltKat;
                colHAREKET_ALT_KATEGORI_ID.Visible = true;

                GridColumn colADET = new GridColumn();
                colADET.VisibleIndex = 20;
                colADET.Caption = "Adet";
                colADET.FieldName = "ADET";
                colADET.Name = "colADET";
                colADET.Visible = true;

                GridColumn colBIRIM_FIYAT_DOVIZ_ID = new GridColumn();
                colBIRIM_FIYAT_DOVIZ_ID.VisibleIndex = 22;
                colBIRIM_FIYAT_DOVIZ_ID.Caption = "Brm.";
                colBIRIM_FIYAT_DOVIZ_ID.CustomizationCaption = "Birim Fiyatý Döviz Tipi";
                colBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
                colBIRIM_FIYAT_DOVIZ_ID.Name = "colBIRIM_FIYAT_DOVIZ_ID";
                colBIRIM_FIYAT_DOVIZ_ID.ColumnEdit = rlueDoviz;
                colBIRIM_FIYAT_DOVIZ_ID.Visible = true;

                GridColumn colBIRIM_FIYAT = new GridColumn();
                colBIRIM_FIYAT.VisibleIndex = 21;
                colBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
                colBIRIM_FIYAT.Caption = "Birim Fiyat";
                colBIRIM_FIYAT.Name = "colBIRIM_FIYAT";
                colBIRIM_FIYAT.ColumnEdit = rSpinTutar;
                colBIRIM_FIYAT.Visible = true;

                GridColumn colKDV_DAHIL = new GridColumn();
                colKDV_DAHIL.VisibleIndex = 23;
                colKDV_DAHIL.Caption = "KDV Dahil";
                colKDV_DAHIL.FieldName = "KDV_DAHIL";
                colKDV_DAHIL.Name = "colKDV_DAHIL";
                colKDV_DAHIL.Visible = true;

                GridColumn colKDV_ORAN = new GridColumn();
                colKDV_ORAN.VisibleIndex = 24;
                colKDV_ORAN.Caption = "KDV Oran";
                colKDV_ORAN.FieldName = "KDV_ORAN";
                colKDV_ORAN.Name = "colKDV_ORAN";
                colKDV_ORAN.ColumnEdit = rSpinOran;
                colKDV_ORAN.Visible = true;

                GridColumn colKDV_TUTAR = new GridColumn();
                colKDV_TUTAR.VisibleIndex = 25;
                colKDV_TUTAR.Caption = "KDV Tutar";
                colKDV_TUTAR.ColumnEdit = rSpinTutar;
                colKDV_TUTAR.FieldName = "KDV_TUTAR";
                colKDV_TUTAR.Name = "colKDV_TUTAR";
                colKDV_TUTAR.Visible = true;

                GridColumn colSTOPAJ_SSDF_DAHIL = new GridColumn();
                colSTOPAJ_SSDF_DAHIL.VisibleIndex = 26;
                colSTOPAJ_SSDF_DAHIL.Caption = "Stopaj SSDF Dahil";
                colSTOPAJ_SSDF_DAHIL.FieldName = "STOPAJ_SSDF_DAHIL";
                colSTOPAJ_SSDF_DAHIL.Name = "colSTOPAJ_SSDF_DAHIL";
                colSTOPAJ_SSDF_DAHIL.Visible = true;

                GridColumn colSTOPAJ_ORAN = new GridColumn();
                colSTOPAJ_ORAN.VisibleIndex = 27;
                colSTOPAJ_ORAN.Caption = "Stopaj Oran";
                colSTOPAJ_ORAN.ColumnEdit = rSpinOran;
                colSTOPAJ_ORAN.FieldName = "STOPAJ_ORAN";
                colSTOPAJ_ORAN.Name = "colSTOPAJ_ORAN";
                colSTOPAJ_ORAN.Visible = true;

                GridColumn colSSDF_ORAN = new GridColumn();
                colSSDF_ORAN.VisibleIndex = 28;
                colSSDF_ORAN.Caption = "SSDF Oran";
                colSSDF_ORAN.FieldName = "SSDF_ORAN";
                colSSDF_ORAN.Name = "colSSDF_ORAN";
                colSSDF_ORAN.ColumnEdit = rSpinOran;
                colSSDF_ORAN.Visible = true;

                GridColumn colSTOPAJ_SSDF_TUTAR = new GridColumn();
                colSTOPAJ_SSDF_TUTAR.VisibleIndex = 29;
                colSTOPAJ_SSDF_TUTAR.Caption = "Stopaj SSDF Tutar";
                colSTOPAJ_SSDF_TUTAR.FieldName = "STOPAJ_SSDF_TUTAR";
                colSTOPAJ_SSDF_TUTAR.Name = "colSTOPAJ_SSDF_TUTAR";
                colSTOPAJ_SSDF_TUTAR.ColumnEdit = rSpinTutar;
                colSTOPAJ_SSDF_TUTAR.Visible = true;

                GridColumn colTOPLAM_TUTAR = new GridColumn();
                colTOPLAM_TUTAR.VisibleIndex = 30;
                colTOPLAM_TUTAR.Caption = "Toplam Tutar";
                colTOPLAM_TUTAR.FieldName = "TOPLAM_TUTAR";
                colTOPLAM_TUTAR.Name = "colTOPLAM_TUTAR";
                colTOPLAM_TUTAR.ColumnEdit = rSpinTutar;
                colTOPLAM_TUTAR.Visible = true;

                GridColumn colGENEL_TOPLAM = new GridColumn();
                colGENEL_TOPLAM.VisibleIndex = 31;
                colGENEL_TOPLAM.Caption = "Genel Toplam";
                colGENEL_TOPLAM.FieldName = "GENEL_TOPLAM";
                colGENEL_TOPLAM.Name = "colGENEL_TOPLAM";
                colGENEL_TOPLAM.Visible = true;

                GridColumn colDETAY_ACIKLAMA = new GridColumn();
                colDETAY_ACIKLAMA.VisibleIndex = 32;
                colDETAY_ACIKLAMA.Caption = "Detay Açýklama";
                colDETAY_ACIKLAMA.FieldName = "DETAY_ACIKLAMA";
                colDETAY_ACIKLAMA.Name = "colDETAY_ACIKLAMA";
                colDETAY_ACIKLAMA.ColumnEdit = aciklama;
                colDETAY_ACIKLAMA.Visible = true;

                GridColumn colKAYIT_ID = new GridColumn();
                colKAYIT_ID.VisibleIndex = 33;
                colKAYIT_ID.Caption = "Kayýt";
                colKAYIT_ID.FieldName = "KAYIT_ID";
                colKAYIT_ID.Name = "colKAYIT_ID";
                colKAYIT_ID.Visible = false;

                GridColumn colKAYIT_TIP = new GridColumn();
                colKAYIT_TIP.VisibleIndex = 34;
                colKAYIT_TIP.Caption = "Kayýt Tip";
                colKAYIT_TIP.FieldName = "KAYIT_TIP";
                colKAYIT_TIP.Name = "colKAYIT_TIP";
                colKAYIT_TIP.Visible = true;

                GridColumn colFOY_NO = new GridColumn();
                colFOY_NO.VisibleIndex = 35;
                colFOY_NO.Caption = "Foy No";
                colFOY_NO.FieldName = "FOY_NO";
                colFOY_NO.Name = "colFOY_NO";
                colFOY_NO.Visible = false;

                GridColumn colADLI_BIRIM_ADLIYE_ID = new GridColumn();
                colADLI_BIRIM_ADLIYE_ID.VisibleIndex = 36;
                colADLI_BIRIM_ADLIYE_ID.Caption = "Adliye";
                colADLI_BIRIM_ADLIYE_ID.FieldName = "ADLI_BIRIM_ADLIYE_ID";
                colADLI_BIRIM_ADLIYE_ID.Name = "colADLI_BIRIM_ADLIYE_ID";
                colADLI_BIRIM_ADLIYE_ID.ColumnEdit = rlueAdliye;
                colADLI_BIRIM_ADLIYE_ID.Visible = true;

                GridColumn colADLI_BIRIM_NO_ID = new GridColumn();
                colADLI_BIRIM_NO_ID.VisibleIndex = 37;
                colADLI_BIRIM_NO_ID.Caption = "No";
                colADLI_BIRIM_NO_ID.FieldName = "ADLI_BIRIM_NO_ID";
                colADLI_BIRIM_NO_ID.Name = "colADLI_BIRIM_NO_ID";
                colADLI_BIRIM_NO_ID.ColumnEdit = rlueAdliNo;
                colADLI_BIRIM_NO_ID.Visible = true;

                GridColumn colADLI_BIRIM_GOREV_ID = new GridColumn();
                colADLI_BIRIM_GOREV_ID.VisibleIndex = 38;
                colADLI_BIRIM_GOREV_ID.Caption = "Görev";
                colADLI_BIRIM_GOREV_ID.FieldName = "ADLI_BIRIM_GOREV_ID";
                colADLI_BIRIM_GOREV_ID.Name = "colADLI_BIRIM_GOREV_ID";
                colADLI_BIRIM_GOREV_ID.ColumnEdit = rlueAdliGorev;
                colADLI_BIRIM_GOREV_ID.Visible = true;

                GridColumn colESAS_NO = new GridColumn();
                colESAS_NO.VisibleIndex = 39;
                colESAS_NO.Caption = "Esas No";
                colESAS_NO.FieldName = "ESAS_NO";
                colESAS_NO.Name = "colESAS_NO";
                colESAS_NO.Visible = true;

                GridColumn colTAKIP_TARIHI = new GridColumn();
                colTAKIP_TARIHI.VisibleIndex = 40;
                colTAKIP_TARIHI.Caption = "Takip T";
                colTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
                colTAKIP_TARIHI.Name = "colTAKIP_TARIHI";
                colTAKIP_TARIHI.Visible = true;

                GridColumn colINTIKAL_TARIHI = new GridColumn();
                colINTIKAL_TARIHI.VisibleIndex = 41;
                colINTIKAL_TARIHI.Caption = "Ýntikal T";
                colINTIKAL_TARIHI.FieldName = "INTIKAL_TARIHI";
                colINTIKAL_TARIHI.Name = "colINTIKAL_TARIHI";
                colINTIKAL_TARIHI.Visible = true;

                #endregion

                #region []

                GridColumn[] dizi = new[]
                                            {
                                                // colID,
                                                colMUHASEBE_HEDEF_TIP,
                                                //colMASRAF_AVANS_ID,
                                                colREFERANS_NO,
                                                colOTOMATIK_HESAPLANDI,
                                                colACIKLAMA,
                                                // colKLASOR_KODU,
                                                // colSUBE_KODU,
                                                // colKONTROL_NE_ZAMAN,
                                                // colKONTROL_KIM,
                                                // colKONTROL_VERSIYON,
                                                // colSTAMP,
                                                //  colASAMA_ID,
                                                //  colKONTROL_KIM_ID,
                                                //  colSUBE_KOD_ID,
                                                //  colDETAY_ID,
                                                colYENIDEN_HESAPLANABILIR,
                                                colTARIH,
                                                colHAREKET_ANA_KATEGORI_ID,
                                                colHAREKET_ALT_KATEGORI_ID,
                                                colADET,
                                                colBIRIM_FIYAT,
                                                colBIRIM_FIYAT_DOVIZ_ID,
                                                colKDV_DAHIL,
                                                colKDV_ORAN,
                                                colKDV_TUTAR,
                                                colSTOPAJ_SSDF_DAHIL,
                                                colSTOPAJ_ORAN,
                                                colSSDF_ORAN,
                                                colSTOPAJ_SSDF_TUTAR,
                                                colTOPLAM_TUTAR,
                                                colGENEL_TOPLAM,
                                                colDETAY_ACIKLAMA,
                                                //colKAYIT_ID,
                                                colKAYIT_TIP,
                                                colFOY_NO,
                                                colADLI_BIRIM_ADLIYE_ID,
                                                colADLI_BIRIM_NO_ID,
                                                colADLI_BIRIM_GOREV_ID,
                                                colESAS_NO,
                                                colTAKIP_TARIHI,
                                                colINTIKAL_TARIHI
                                            };

                #endregion

                #region Column Caption

                Dictionary<string, string> captionlar = GetColumnCaptionDictinory();
                Dictionary<string, RepositoryItem> editler = GetRepositoryItemByFieldName();

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

                #endregion

                return dizi;
            }
        }

        public class CariHesapBirlesik
        {
            public Dictionary<string, string> GetColumnCaptionDictinory()
            {
                Dictionary<string, string> dicFieldCaption = new Dictionary<string, string>();

                #region Caption Edit

                dicFieldCaption.Add("ID", "");
                dicFieldCaption.Add("CARI_ID", "");
                dicFieldCaption.Add("AD", "Ad");
                dicFieldCaption.Add("PERSONEL_MI", "Personel");
                dicFieldCaption.Add("MUVEKKIL_MI", "Müvekkil");
                dicFieldCaption.Add("FIRMA_MI", "Firma");
                dicFieldCaption.Add("AVUKAT_MI", "Avukat");
                dicFieldCaption.Add("REFERANS_NO", "Referans");
                dicFieldCaption.Add("ACIKLAMA", "Açýklama");
                dicFieldCaption.Add("DETAY_ID", "Detay");
                dicFieldCaption.Add("DOSYA_MUH_AKTARILDI", "");
                dicFieldCaption.Add("BORC_ALACAK_ID", "");
                dicFieldCaption.Add("ODEME_TIP_ID", "");
                dicFieldCaption.Add("CARI_HESAP_HEDEF_TIP", "");
                dicFieldCaption.Add("ICRA_FOY_ID", "");
                dicFieldCaption.Add("ICRA_FOY_NO", "");
                dicFieldCaption.Add("DAVA_FOY_ID", "");
                dicFieldCaption.Add("DAVA_FOY_NO", "");
                dicFieldCaption.Add("HAZIRLIK_ID", "");
                dicFieldCaption.Add("HAZIRLIK_NO", "");
                dicFieldCaption.Add("RUCU_ID", "");
                dicFieldCaption.Add("RUCU_NO", "");
                dicFieldCaption.Add("TARIH", "");
                dicFieldCaption.Add("KULLANICI_BELGE_NO", "");
                dicFieldCaption.Add("HAREKET_ANA_KATEGORI_ID", "");
                dicFieldCaption.Add("HAREKET_ALT_KAREGORI_ID", "");
                dicFieldCaption.Add("ADET", "");
                dicFieldCaption.Add("BIRIM_FIYAT", "");
                dicFieldCaption.Add("GENEL_TOPLAM", "");
                dicFieldCaption.Add("DETAY_ACIKLAMA", "");
                dicFieldCaption.Add("KAYIT_TARIHI", "");
                dicFieldCaption.Add("INCELENDI", "");
                dicFieldCaption.Add("ONAY_TARIHI", "");
                dicFieldCaption.Add("ONAY_NO", "");
                dicFieldCaption.Add("ONAY_DURUM", "");
                dicFieldCaption.Add("SOZLESME_ID", "");
                dicFieldCaption.Add("KLASOR_KODU", "");
                dicFieldCaption.Add("SUBE_KODU", "");
                dicFieldCaption.Add("KONTROL_NE_ZAMAN", "");
                dicFieldCaption.Add("KONTROL_KIM", "");
                dicFieldCaption.Add("KONTROL_VERSIYON", "");
                dicFieldCaption.Add("KONTROL_KIM_ID", "");
                dicFieldCaption.Add("SUBE_KOD_ID", "");
                dicFieldCaption.Add("STAMP", "");
                dicFieldCaption.Add("KOD", "");

                #endregion

                return dicFieldCaption;
            }

            public Dictionary<string, RepositoryItem> GetRepositoryItemByFieldName()
            {
                RepositoryItemLookUpEdit rlueDoviz = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueBorcAlacak = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueOdemeTip = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueHareketAnaKat = new RepositoryItemLookUpEdit();
                RepositoryItemImageComboBox rlueHareketAltKat = new RepositoryItemImageComboBox();

                BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
                BelgeUtil.Inits.BorcAlacakGetir(rlueBorcAlacak);
                BelgeUtil.Inits.HareketAnaKategoriGetir(rlueHareketAnaKat);
                BelgeUtil.Inits.MuhasebeHareketAltKategoriGetir(rlueHareketAltKat);
                BelgeUtil.Inits.OdemeTipiGetir(rlueOdemeTip);

                Dictionary<string, RepositoryItem> sozluk = new Dictionary<string, RepositoryItem>();

                #region Add item

                sozluk.Add("DovizId", rlueDoviz);

                //  sozluk.Add("CARI_ID", Item);
                // sozluk.Add("DETAY_ID", Item);
                sozluk.Add("BORC_ALACAK_ID", rlueBorcAlacak);
                sozluk.Add("ODEME_TIP_ID", rlueOdemeTip);
                //   sozluk.Add("ICRA_FOY_ID", Item);
                //   sozluk.Add("DAVA_FOY_ID", Item);
                //    sozluk.Add("HAZIRLIK_ID", Item);
                //   sozluk.Add("RUCU_ID", Item);
                sozluk.Add("HAREKET_ANA_KATEGORI_ID", rlueHareketAnaKat);
                sozluk.Add("HAREKET_ALT_KAREGORI_ID", rlueHareketAltKat);
                //   sozluk.Add("SOZLESME_ID", Item);
                //      sozluk.Add("KONTROL_KIM_ID", Item);
                //     sozluk.Add("SUBE_KOD_ID", Item);

                #endregion

                return sozluk;
            }

            public GridColumn[] GetColumn()
            {
                #region RepositoryItem

                RepositoryItemLookUpEdit rlueCari = new RepositoryItemLookUpEdit();
                RepositoryItemMemoExEdit aciklama = new RepositoryItemMemoExEdit();
                RepositoryItemLookUpEdit rlueBorcAlacak = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueOdemeTipi = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueHarAnaKat = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueHarAltKat = new RepositoryItemLookUpEdit();
                RepositoryItemLookUpEdit rlueDoviz = new RepositoryItemLookUpEdit();
                RepositoryItemSpinEdit tutar = new RepositoryItemSpinEdit();

                #endregion

                #region InitsData

                BelgeUtil.Inits.perCariGetir(rlueCari);
                BelgeUtil.Inits.BorcAlacakGetir(rlueBorcAlacak);
                BelgeUtil.Inits.OdemeTipiGetir(rlueOdemeTipi);
                BelgeUtil.Inits.MuhasebeHareketAltKategori(rlueHarAltKat);
                BelgeUtil.Inits.HareketAnaKategoriGetir(rlueHarAnaKat);
                BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
                BelgeUtil.Inits.ParaBicimiAyarla(tutar);

                #endregion

                #region Field & Properties

                GridColumn colID = new GridColumn();
                colID.VisibleIndex = 0;
                colID.FieldName = "ID";
                colID.Name = "colID";
                colID.Visible = false;

                GridColumn colCARI_ID = new GridColumn();
                colCARI_ID.VisibleIndex = 1;
                colCARI_ID.Caption = "Þahýs";
                colCARI_ID.FieldName = "CARI_ID";
                colCARI_ID.Name = "colCARI_ID";
                colCARI_ID.ColumnEdit = rlueCari;
                colCARI_ID.Visible = true;

                GridColumn colAD = new GridColumn();
                colAD.VisibleIndex = 2;
                colAD.FieldName = "AD";
                colAD.Name = "colAD";
                colAD.Visible = false;

                GridColumn colPERSONEL_MI = new GridColumn();
                colPERSONEL_MI.VisibleIndex = 3;
                colPERSONEL_MI.Caption = "Personel mi";
                colPERSONEL_MI.FieldName = "PERSONEL_MI";
                colPERSONEL_MI.Name = "colPERSONEL_MI";
                colPERSONEL_MI.Visible = false;

                GridColumn colMUVEKKIL_MI = new GridColumn();
                colMUVEKKIL_MI.VisibleIndex = 4;
                colMUVEKKIL_MI.Caption = "Müvekkil mi";
                colMUVEKKIL_MI.FieldName = "MUVEKKIL_MI";
                colMUVEKKIL_MI.Name = "colMUVEKKIL_MI";
                colMUVEKKIL_MI.Visible = false;

                GridColumn colFIRMA_MI = new GridColumn();
                colFIRMA_MI.VisibleIndex = 5;
                colFIRMA_MI.Caption = "Firma mý";
                colFIRMA_MI.FieldName = "FIRMA_MI";
                colFIRMA_MI.Name = "colFIRMA_MI";
                colFIRMA_MI.Visible = true;

                GridColumn colAVUKAT_MI = new GridColumn();
                colAVUKAT_MI.VisibleIndex = 6;
                colAVUKAT_MI.Caption = "Avukat mý";
                colAVUKAT_MI.FieldName = "AVUKAT_MI";
                colAVUKAT_MI.Name = "colAVUKAT_MI";
                colAVUKAT_MI.Visible = true;

                GridColumn colREFERANS_NO = new GridColumn();
                colREFERANS_NO.VisibleIndex = 7;
                colREFERANS_NO.Caption = "Referans No";
                colREFERANS_NO.FieldName = "REFERANS_NO";
                colREFERANS_NO.Name = "colREFERANS_NO";
                colREFERANS_NO.Visible = true;

                GridColumn colACIKLAMA = new GridColumn();
                colACIKLAMA.VisibleIndex = 8;
                colACIKLAMA.Caption = "Açýklama";
                colACIKLAMA.FieldName = "ACIKLAMA";
                colACIKLAMA.Name = "colACIKLAMA";
                colACIKLAMA.ColumnEdit = aciklama;
                colACIKLAMA.Visible = true;

                GridColumn colDETAY_ID = new GridColumn();
                colDETAY_ID.VisibleIndex = 9;
                colDETAY_ID.Caption = "Detay";
                colDETAY_ID.FieldName = "DETAY_ID";
                colDETAY_ID.Name = "colDETAY_ID";
                colDETAY_ID.Visible = false;

                GridColumn colDOSYA_MUH_AKTARILDI = new GridColumn();
                colDOSYA_MUH_AKTARILDI.VisibleIndex = 10;
                colDOSYA_MUH_AKTARILDI.Caption = "Dosya Muh Aktarýldý";
                colDOSYA_MUH_AKTARILDI.FieldName = "DOSYA_MUH_AKTARILDI";
                colDOSYA_MUH_AKTARILDI.Name = "colDOSYA_MUH_AKTARILDI";
                colDOSYA_MUH_AKTARILDI.Visible = true;

                GridColumn colBORC_ALACAK_ID = new GridColumn();
                colBORC_ALACAK_ID.VisibleIndex = 11;
                colBORC_ALACAK_ID.Caption = "B/A";
                colBORC_ALACAK_ID.FieldName = "BORC_ALACAK_ID";
                colBORC_ALACAK_ID.Name = "colBORC_ALACAK_ID";
                colBORC_ALACAK_ID.ColumnEdit = rlueBorcAlacak;
                colBORC_ALACAK_ID.Visible = true;

                GridColumn colODEME_TIP_ID = new GridColumn();
                colODEME_TIP_ID.VisibleIndex = 12;
                colODEME_TIP_ID.Caption = "Ödeme Tip";
                colODEME_TIP_ID.FieldName = "ODEME_TIP_ID";
                colODEME_TIP_ID.Name = "colODEME_TIP_ID";
                colODEME_TIP_ID.ColumnEdit = rlueOdemeTipi;
                colODEME_TIP_ID.Visible = true;

                GridColumn colCARI_HESAP_HEDEF_TIP = new GridColumn();
                colCARI_HESAP_HEDEF_TIP.VisibleIndex = 13;
                colCARI_HESAP_HEDEF_TIP.Caption = "Hesap Hedef Tip";
                colCARI_HESAP_HEDEF_TIP.FieldName = "CARI_HESAP_HEDEF_TIP";
                colCARI_HESAP_HEDEF_TIP.Name = "colCARI_HESAP_HEDEF_TIP";
                colCARI_HESAP_HEDEF_TIP.Visible = true;

                GridColumn colICRA_FOY_ID = new GridColumn();
                colICRA_FOY_ID.VisibleIndex = 14;
                colICRA_FOY_ID.FieldName = "ICRA_FOY_ID";
                colICRA_FOY_ID.Name = "colICRA_FOY_ID";
                colICRA_FOY_ID.Visible = false;

                GridColumn colICRA_FOY_NO = new GridColumn();
                colICRA_FOY_NO.VisibleIndex = 15;
                colICRA_FOY_NO.FieldName = "ICRA_FOY_NO";
                colICRA_FOY_NO.Name = "colICRA_FOY_NO";
                colICRA_FOY_NO.Visible = false;

                GridColumn colDAVA_FOY_ID = new GridColumn();
                colDAVA_FOY_ID.VisibleIndex = 16;
                colDAVA_FOY_ID.FieldName = "DAVA_FOY_ID";
                colDAVA_FOY_ID.Name = "colDAVA_FOY_ID";
                colDAVA_FOY_ID.Visible = false;

                GridColumn colDAVA_FOY_NO = new GridColumn();
                colDAVA_FOY_NO.VisibleIndex = 17;
                colDAVA_FOY_NO.FieldName = "DAVA_FOY_NO";
                colDAVA_FOY_NO.Name = "colDAVA_FOY_NO";
                colDAVA_FOY_NO.Visible = false;

                GridColumn colHAZIRLIK_ID = new GridColumn();
                colHAZIRLIK_ID.VisibleIndex = 18;
                colHAZIRLIK_ID.FieldName = "HAZIRLIK_ID";
                colHAZIRLIK_ID.Name = "colHAZIRLIK_ID";
                colHAZIRLIK_ID.Visible = false;

                GridColumn colHAZIRLIK_NO = new GridColumn();
                colHAZIRLIK_NO.VisibleIndex = 19;
                colHAZIRLIK_NO.FieldName = "HAZIRLIK_NO";
                colHAZIRLIK_NO.Name = "colHAZIRLIK_NO";
                colHAZIRLIK_NO.Visible = false;

                GridColumn colRUCU_ID = new GridColumn();
                colRUCU_ID.VisibleIndex = 20;
                colRUCU_ID.FieldName = "RUCU_ID";
                colRUCU_ID.Name = "colRUCU_ID";
                colRUCU_ID.Visible = false;

                GridColumn colRUCU_NO = new GridColumn();
                colRUCU_NO.VisibleIndex = 21;
                colRUCU_NO.FieldName = "RUCU_NO";
                colRUCU_NO.Name = "colRUCU_NO";
                colRUCU_NO.Visible = false;

                GridColumn colTARIH = new GridColumn();
                colTARIH.VisibleIndex = 22;
                colTARIH.Caption = "Tarih";
                colTARIH.FieldName = "TARIH";
                colTARIH.Name = "colTARIH";
                colTARIH.Visible = true;

                GridColumn colKULLANICI_BELGE_NO = new GridColumn();
                colKULLANICI_BELGE_NO.VisibleIndex = 23;
                colKULLANICI_BELGE_NO.Caption = "Kullanýcý Belge No";
                colKULLANICI_BELGE_NO.FieldName = "KULLANICI_BELGE_NO";
                colKULLANICI_BELGE_NO.Name = "colKULLANICI_BELGE_NO";
                colKULLANICI_BELGE_NO.Visible = true;

                GridColumn colHAREKET_ANA_KATEGORI_ID = new GridColumn();
                colHAREKET_ANA_KATEGORI_ID.VisibleIndex = 24;
                colHAREKET_ANA_KATEGORI_ID.Caption = "Har.Ana Kat.";
                colHAREKET_ANA_KATEGORI_ID.FieldName = "HAREKET_ANA_KATEGORI_ID";
                colHAREKET_ANA_KATEGORI_ID.Name = "colHAREKET_ANA_KATEGORI_ID";
                colHAREKET_ANA_KATEGORI_ID.ColumnEdit = rlueHarAnaKat;
                colHAREKET_ANA_KATEGORI_ID.Visible = true;

                GridColumn colHAREKET_ALT_KAREGORI_ID = new GridColumn();
                colHAREKET_ALT_KAREGORI_ID.VisibleIndex = 25;
                colHAREKET_ALT_KAREGORI_ID.Caption = "Har. Alt Kat";
                colHAREKET_ALT_KAREGORI_ID.FieldName = "HAREKET_ALT_KAREGORI_ID";
                colHAREKET_ALT_KAREGORI_ID.Name = "colHAREKET_ALT_KAREGORI_ID";
                colHAREKET_ALT_KAREGORI_ID.ColumnEdit = rlueHarAltKat;
                colHAREKET_ALT_KAREGORI_ID.Visible = true;

                GridColumn colADET = new GridColumn();
                colADET.VisibleIndex = 26;
                colADET.Caption = "Adet";
                colADET.FieldName = "ADET";
                colADET.Name = "colADET";
                colADET.Visible = true;

                GridColumn colBIRIM_FIYAT_DOVIZ_ID = new GridColumn();
                colBIRIM_FIYAT_DOVIZ_ID.VisibleIndex = 28;
                colBIRIM_FIYAT_DOVIZ_ID.Caption = "Brm.";
                colBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
                colBIRIM_FIYAT_DOVIZ_ID.Name = "colBIRIM_FIYAT_DOVIZ_ID";
                colBIRIM_FIYAT_DOVIZ_ID.CustomizationCaption = "Birim Fiyat Döviz Tip";
                colBIRIM_FIYAT_DOVIZ_ID.ColumnEdit = rlueDoviz;
                colBIRIM_FIYAT_DOVIZ_ID.Visible = true;

                GridColumn colBIRIM_FIYAT = new GridColumn();
                colBIRIM_FIYAT.VisibleIndex = 27;
                colBIRIM_FIYAT.Caption = "Birim Fiyat";
                colBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
                colBIRIM_FIYAT.Name = "colBIRIM_FIYAT";
                colBIRIM_FIYAT.ColumnEdit = tutar;
                colBIRIM_FIYAT.Visible = true;

                GridColumn colGENEL_TOPLAM = new GridColumn();
                colGENEL_TOPLAM.VisibleIndex = 29;
                colGENEL_TOPLAM.Caption = "Genel Toplam";
                colGENEL_TOPLAM.FieldName = "GENEL_TOPLAM";
                colGENEL_TOPLAM.Name = "colGENEL_TOPLAM";
                colGENEL_TOPLAM.ColumnEdit = tutar;
                colGENEL_TOPLAM.Visible = true;

                GridColumn colDETAY_ACIKLAMA = new GridColumn();
                colDETAY_ACIKLAMA.VisibleIndex = 30;
                colDETAY_ACIKLAMA.Caption = "Detay Kayýt";
                colDETAY_ACIKLAMA.FieldName = "DETAY_ACIKLAMA";
                colDETAY_ACIKLAMA.Name = "colDETAY_ACIKLAMA";
                colDETAY_ACIKLAMA.ColumnEdit = aciklama;
                colDETAY_ACIKLAMA.Visible = true;

                GridColumn colKAYIT_TARIHI = new GridColumn();
                colKAYIT_TARIHI.VisibleIndex = 31;
                colKAYIT_TARIHI.Caption = "Kayýt T";
                colKAYIT_TARIHI.FieldName = "KAYIT_TARIHI";
                colKAYIT_TARIHI.Name = "colKAYIT_TARIHI";
                colKAYIT_TARIHI.Visible = true;

                GridColumn colINCELENDI = new GridColumn();
                colINCELENDI.VisibleIndex = 32;
                colINCELENDI.Caption = "Ýncelendi";
                colINCELENDI.FieldName = "INCELENDI";
                colINCELENDI.Name = "colINCELENDI";
                colINCELENDI.Visible = true;

                GridColumn colONAY_TARIHI = new GridColumn();
                colONAY_TARIHI.VisibleIndex = 33;
                colONAY_TARIHI.Caption = "Onay T";
                colONAY_TARIHI.FieldName = "ONAY_TARIHI";
                colONAY_TARIHI.Name = "colONAY_TARIHI";
                colONAY_TARIHI.Visible = true;

                GridColumn colONAY_NO = new GridColumn();
                colONAY_NO.VisibleIndex = 34;
                colONAY_NO.Caption = "Onay No";
                colONAY_NO.FieldName = "ONAY_NO";
                colONAY_NO.Name = "colONAY_NO";
                colONAY_NO.Visible = true;

                GridColumn colONAY_DURUM = new GridColumn();
                colONAY_DURUM.VisibleIndex = 35;
                colONAY_DURUM.Caption = "Onay Durum";
                colONAY_DURUM.FieldName = "ONAY_DURUM";
                colONAY_DURUM.Name = "colONAY_DURUM";
                colONAY_DURUM.Visible = true;

                GridColumn colSOZLESME_ID = new GridColumn();
                colSOZLESME_ID.VisibleIndex = 36;
                colSOZLESME_ID.FieldName = "SOZLESME_ID";
                colSOZLESME_ID.Name = "colSOZLESME_ID";
                colSOZLESME_ID.Visible = false;

                GridColumn colKLASOR_KODU = new GridColumn();
                colKLASOR_KODU.VisibleIndex = 37;
                colKLASOR_KODU.Caption = "Klasör Kodu";
                colKLASOR_KODU.FieldName = "KLASOR_KODU";
                colKLASOR_KODU.Name = "colKLASOR_KODU";
                colKLASOR_KODU.Visible = true;

                GridColumn colSUBE_KODU = new GridColumn();
                colSUBE_KODU.VisibleIndex = 38;
                colSUBE_KODU.Caption = "Þube Kodu";
                colSUBE_KODU.FieldName = "SUBE_KODU";
                colSUBE_KODU.Name = "colSUBE_KODU";
                colSUBE_KODU.Visible = true;

                GridColumn colKONTROL_NE_ZAMAN = new GridColumn();
                colKONTROL_NE_ZAMAN.VisibleIndex = 39;
                colKONTROL_NE_ZAMAN.Caption = "Kontrol Ne Zaman";
                colKONTROL_NE_ZAMAN.FieldName = "KONTROL_NE_ZAMAN";
                colKONTROL_NE_ZAMAN.Name = "colKONTROL_NE_ZAMAN";
                colKONTROL_NE_ZAMAN.Visible = true;

                GridColumn colKONTROL_KIM = new GridColumn();
                colKONTROL_KIM.VisibleIndex = 40;
                colKONTROL_KIM.FieldName = "KONTROL_KIM";
                colKONTROL_KIM.Name = "colKONTROL_KIM";
                colKONTROL_KIM.Visible = false;

                GridColumn colKONTROL_VERSIYON = new GridColumn();
                colKONTROL_VERSIYON.VisibleIndex = 41;
                colKONTROL_VERSIYON.Caption = "Kontrol Versiyon";
                colKONTROL_VERSIYON.FieldName = "KONTROL_VERSIYON";
                colKONTROL_VERSIYON.Name = "colKONTROL_VERSIYON";
                colKONTROL_VERSIYON.Visible = true;

                GridColumn colKONTROL_KIM_ID = new GridColumn();
                colKONTROL_KIM_ID.VisibleIndex = 42;
                colKONTROL_KIM_ID.Caption = "Ýþlem Yapan";
                colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
                colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
                colKONTROL_KIM_ID.Visible = true;

                GridColumn colSUBE_KOD_ID = new GridColumn();
                colSUBE_KOD_ID.VisibleIndex = 43;
                colSUBE_KOD_ID.Caption = "Þube Kodu";
                colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
                colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
                colSUBE_KOD_ID.Visible = true;

                GridColumn colSTAMP = new GridColumn();
                colSTAMP.VisibleIndex = 44;
                colSTAMP.Caption = "Stamp";
                colSTAMP.FieldName = "STAMP";
                colSTAMP.Name = "colSTAMP";
                colSTAMP.Visible = true;

                GridColumn colKOD = new GridColumn();
                colKOD.VisibleIndex = 45;
                colKOD.Caption = "Kod";
                colKOD.FieldName = "KOD";
                colKOD.Name = "colKOD";
                colKOD.Visible = true;

                #endregion

                #region []

                GridColumn[] dizi = new[]
                                            {
                                                //colID,
                                                //colCARI_ID,
                                                colAD,
                                                colPERSONEL_MI,
                                                colMUVEKKIL_MI,
                                                colFIRMA_MI,
                                                colAVUKAT_MI,
                                                colREFERANS_NO,
                                                colACIKLAMA,
                                                //colDETAY_ID,
                                                colDOSYA_MUH_AKTARILDI,
                                                colBORC_ALACAK_ID,
                                                colODEME_TIP_ID,
                                                colCARI_HESAP_HEDEF_TIP,
                                                //colICRA_FOY_ID,
                                                //colICRA_FOY_NO,
                                                //colDAVA_FOY_ID,
                                                //colDAVA_FOY_NO,
                                                //colHAZIRLIK_ID,
                                                //colHAZIRLIK_NO,
                                                //colRUCU_ID,
                                                //colRUCU_NO,
                                                colTARIH,
                                                colKULLANICI_BELGE_NO,
                                                colHAREKET_ANA_KATEGORI_ID,
                                                colHAREKET_ALT_KAREGORI_ID,
                                                colADET,
                                                colBIRIM_FIYAT,
                                                colBIRIM_FIYAT_DOVIZ_ID,
                                                colGENEL_TOPLAM,
                                                colDETAY_ACIKLAMA,
                                                colKAYIT_TARIHI,
                                                colINCELENDI,
                                                colONAY_TARIHI,
                                                colONAY_NO,
                                                colONAY_DURUM,
                                                //colSOZLESME_ID,
                                                //colKLASOR_KODU,
                                                //colSUBE_KODU,
                                                //colKONTROL_NE_ZAMAN,
                                                //colKONTROL_KIM,
                                                //colKONTROL_VERSIYON,
                                                //colKONTROL_KIM_ID,
                                                //colSUBE_KOD_ID,
                                                //colSTAMP,
                                                colKOD,
                                            };

                #endregion

                #region Column Caption

                Dictionary<string, string> captionlar = GetColumnCaptionDictinory();
                Dictionary<string, RepositoryItem> editler = GetRepositoryItemByFieldName();

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

                #endregion

                foreach (var item in dizi)
                {
                    item.OptionsColumn.ReadOnly = true;
                    item.OptionsColumn.AllowEdit = false;
                }
                return dizi;
            }
        }

        public class CARIHESAPDETAYLÝNQ
        {
            public GridColumn[] GetColumn()
            {
                #region RepositoryItem

                RepositoryItemLookUpEdit rlueDoviz = new RepositoryItemLookUpEdit();
                RepositoryItemSpinEdit tutar = new RepositoryItemSpinEdit();
                BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
                BelgeUtil.Inits.ParaBicimiAyarla(tutar);

                #endregion

                #region Field Properties

                GridColumn colID = new GridColumn();
                colID.FieldName = "ID";
                colID.Name = "colID";
                colID.Visible = true;
                colID.VisibleIndex = 0;

                GridColumn colDOSYA_MUH_AKTARILDI = new GridColumn();
                colDOSYA_MUH_AKTARILDI.FieldName = "DOSYA_MUH_AKTARILDI";
                colDOSYA_MUH_AKTARILDI.Name = "colDOSYA_MUH_AKTARILDI";
                colDOSYA_MUH_AKTARILDI.Visible = true;
                colDOSYA_MUH_AKTARILDI.Caption = "Muh. Aktarýldý";
                colDOSYA_MUH_AKTARILDI.VisibleIndex = 2;

                GridColumn colCARI_HESAP_HEDEF_TIP = new GridColumn();
                colCARI_HESAP_HEDEF_TIP.FieldName = "CARI_HESAP_HEDEF_TIP";
                colCARI_HESAP_HEDEF_TIP.Name = "colCARI_HESAP_HEDEF_TIP";
                colCARI_HESAP_HEDEF_TIP.Caption = "Hesap Hedef Tipi";
                colCARI_HESAP_HEDEF_TIP.Visible = true;
                colCARI_HESAP_HEDEF_TIP.VisibleIndex = 7;

                GridColumn colTARIH = new GridColumn();
                colTARIH.FieldName = "TARIH";
                colTARIH.Name = "colTARIH";
                colTARIH.Caption = "Tarih";
                colTARIH.Visible = true;
                colTARIH.VisibleIndex = 16;

                GridColumn colKULLANICI_BELGE_NO = new GridColumn();
                colKULLANICI_BELGE_NO.FieldName = "KULLANICI_BELGE_NO";
                colKULLANICI_BELGE_NO.Name = "colKULLANICI_BELGE_NO";
                colKULLANICI_BELGE_NO.Caption = "Kullanýcý Belge No";
                colKULLANICI_BELGE_NO.Visible = true;
                colKULLANICI_BELGE_NO.VisibleIndex = 17;

                GridColumn colADET = new GridColumn();
                colADET.FieldName = "ADET";
                colADET.Name = "colADET";
                colADET.Caption = "Adet";
                colADET.Visible = true;
                colADET.VisibleIndex = 21;

                GridColumn colBIRIM_FIYAT_DOVIZ_ID = new GridColumn();
                colBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
                colBIRIM_FIYAT_DOVIZ_ID.Name = "colBIRIM_FIYAT_DOVIZ_ID";
                colBIRIM_FIYAT_DOVIZ_ID.Visible = true;
                colBIRIM_FIYAT_DOVIZ_ID.Caption = " ";
                colBIRIM_FIYAT_DOVIZ_ID.ColumnEdit = rlueDoviz;
                colBIRIM_FIYAT_DOVIZ_ID.CustomizationCaption = "Birim Fiyat Brm";
                colBIRIM_FIYAT_DOVIZ_ID.VisibleIndex = 26;

                GridColumn colBIRIM_FIYAT = new GridColumn();
                colBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
                colBIRIM_FIYAT.Name = "colBIRIM_FIYAT";
                colBIRIM_FIYAT.Caption = "Birim Fiyat";
                colBIRIM_FIYAT.ColumnEdit = tutar;
                colBIRIM_FIYAT.Visible = true;
                colBIRIM_FIYAT.VisibleIndex = 25;

                GridColumn colALINAN_DOVIZ_ID = new GridColumn();
                colALINAN_DOVIZ_ID.FieldName = "ALINAN_DOVIZ_ID";
                colALINAN_DOVIZ_ID.Name = "colODENEN_FIYAT_DOVIZ_ID";
                colALINAN_DOVIZ_ID.Visible = true;
                colALINAN_DOVIZ_ID.Caption = " ";
                colALINAN_DOVIZ_ID.ColumnEdit = rlueDoviz;
                colALINAN_DOVIZ_ID.VisibleIndex = 0;
                colALINAN_DOVIZ_ID.CustomizationCaption = "Alýnan Brm";

                GridColumn colALINAN = new GridColumn();
                colALINAN.FieldName = "ALINAN";
                colALINAN.Name = "colALINAN";
                colALINAN.Caption = "Alýnan";
                colALINAN.ColumnEdit = tutar;
                colALINAN.VisibleIndex = 0;
                colALINAN.Visible = true;

                GridColumn colKALAN = new GridColumn();
                colKALAN.FieldName = "KALAN";
                colKALAN.Name = "colKALAN";
                colKALAN.Caption = "Kalan";
                colKALAN.ColumnEdit = tutar;
                colKALAN.VisibleIndex = 0;
                colKALAN.Visible = true;
                GridSummaryItem gsi = new GridSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KALAN", "");
                colKALAN.SummaryItem.Assign(gsi);

                GridColumn colKALAN_DOVIZ_ID = new GridColumn();
                colKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
                colKALAN_DOVIZ_ID.Name = "colKALAN_DOVIZ_ID";
                colKALAN_DOVIZ_ID.Caption = " ";
                colKALAN_DOVIZ_ID.ColumnEdit = rlueDoviz;
                colKALAN_DOVIZ_ID.VisibleIndex = 0;
                colKALAN_DOVIZ_ID.Visible = true;

                GridColumn colODENEN_DOVIZ_ID = new GridColumn();
                colODENEN_DOVIZ_ID.FieldName = "ODENEN_DOVIZ_ID";
                colODENEN_DOVIZ_ID.Name = "colODENEN_DOVIZ_ID";
                colODENEN_DOVIZ_ID.Visible = true;
                colODENEN_DOVIZ_ID.Caption = " ";
                colODENEN_DOVIZ_ID.ColumnEdit = rlueDoviz;
                colODENEN_DOVIZ_ID.VisibleIndex = 0;
                colODENEN_DOVIZ_ID.CustomizationCaption = "Ödenen Brm";

                GridColumn colODENEN = new GridColumn();
                colODENEN.FieldName = "ODENEN";
                colODENEN.Name = "colODENEN";
                colODENEN.Caption = "Ödenen";
                colODENEN.ColumnEdit = tutar;
                colODENEN.VisibleIndex = 0;
                colODENEN.Visible = true;

                GridColumn colGENEL_TOPLAM = new GridColumn();
                colGENEL_TOPLAM.FieldName = "GENEL_TOPLAM";
                colGENEL_TOPLAM.Caption = "Genel Toplam";
                colGENEL_TOPLAM.Name = "colGENEL_TOPLAM";
                colGENEL_TOPLAM.ColumnEdit = tutar;
                colGENEL_TOPLAM.Visible = true;
                colGENEL_TOPLAM.VisibleIndex = 27;

                GridColumn colACIKLAMA = new GridColumn();
                colACIKLAMA.FieldName = "ACIKLAMA";
                colACIKLAMA.Name = "colACIKLAMA";
                colACIKLAMA.Caption = "Açýklama";
                colACIKLAMA.Visible = true;
                colACIKLAMA.VisibleIndex = 28;

                GridColumn colINCELENDI = new GridColumn();
                colINCELENDI.FieldName = "INCELENDI";
                colINCELENDI.Name = "colINCELENDI";
                colINCELENDI.Caption = "Ýncelendi";
                colINCELENDI.Visible = true;
                colINCELENDI.VisibleIndex = 35;

                GridColumn colONAY_TARIHI = new GridColumn();
                colONAY_TARIHI.FieldName = "ONAY_TARIHI";
                colONAY_TARIHI.Name = "colONAY_TARIHI";
                colONAY_TARIHI.Caption = "Onay T.";
                colONAY_TARIHI.Visible = true;
                colONAY_TARIHI.VisibleIndex = 36;

                GridColumn colONAY_NO = new GridColumn();
                colONAY_NO.FieldName = "ONAY_NO";
                colONAY_NO.Name = "colONAY_NO";
                colONAY_NO.Caption = "Onay No";
                colONAY_NO.Visible = true;
                colONAY_NO.VisibleIndex = 37;

                GridColumn colONAY_DURUM = new GridColumn();
                colONAY_DURUM.FieldName = "ONAY_DURUM";
                colONAY_DURUM.Name = "colONAY_DURUM";
                colONAY_DURUM.Caption = "Onay Durum";
                colONAY_DURUM.Visible = true;
                colONAY_DURUM.VisibleIndex = 38;

                GridColumn colCARI_AD = new GridColumn();
                colCARI_AD.FieldName = "CARI_AD";
                colCARI_AD.Name = "colCARI_AD";
                colCARI_AD.Caption = "Þahýs";
                colCARI_AD.OptionsColumn.ReadOnly = true;
                colCARI_AD.Visible = true;
                colCARI_AD.VisibleIndex = 56;

                GridColumn colCARI_KOD = new GridColumn();
                colCARI_KOD.FieldName = "CARI_KOD";
                colCARI_KOD.Caption = "Þahýs Kod";
                colCARI_KOD.Name = "colCARI_KOD";
                colCARI_KOD.OptionsColumn.ReadOnly = true;
                colCARI_KOD.Visible = true;
                colCARI_KOD.VisibleIndex = 57;

                GridColumn colCARI_PERSONEL = new GridColumn();
                colCARI_PERSONEL.FieldName = "CARI_PERSONEL";
                colCARI_PERSONEL.Caption = "Personel";
                colCARI_PERSONEL.Name = "colCARI_PERSONEL";
                colCARI_PERSONEL.OptionsColumn.ReadOnly = true;
                colCARI_PERSONEL.Visible = true;
                colCARI_PERSONEL.VisibleIndex = 58;

                GridColumn colCARI_MUVEKKIL = new GridColumn();
                colCARI_MUVEKKIL.FieldName = "CARI_MUVEKKIL";
                colCARI_MUVEKKIL.Name = "colCARI_MUVEKKIL";
                colCARI_MUVEKKIL.Caption = "Müvekkil";
                colCARI_MUVEKKIL.OptionsColumn.ReadOnly = true;
                colCARI_MUVEKKIL.Visible = true;
                colCARI_MUVEKKIL.VisibleIndex = 59;

                GridColumn colCARI_FIRMA = new GridColumn();
                colCARI_FIRMA.FieldName = "CARI_FIRMA";
                colCARI_FIRMA.Caption = "Firma";
                colCARI_FIRMA.Name = "colCARI_FIRMA";
                colCARI_FIRMA.OptionsColumn.ReadOnly = true;
                colCARI_FIRMA.Visible = true;
                colCARI_FIRMA.VisibleIndex = 60;

                GridColumn colCARI_AVUKAT = new GridColumn();
                colCARI_AVUKAT.FieldName = "CARI_AVUKAT";
                colCARI_AVUKAT.Name = "colCARI_AVUKAT";
                colCARI_AVUKAT.Caption = "Avukat";
                colCARI_AVUKAT.OptionsColumn.ReadOnly = true;
                colCARI_AVUKAT.Visible = true;
                colCARI_AVUKAT.VisibleIndex = 61;

                GridColumn colHESAP_ID = new GridColumn();
                colHESAP_ID.FieldName = "HESAP_ID";
                colHESAP_ID.Name = "colHESAP_ID";
                colHESAP_ID.OptionsColumn.ReadOnly = true;
                colHESAP_ID.Visible = true;
                colHESAP_ID.VisibleIndex = 62;

                GridColumn colREFERANS_NO = new GridColumn();
                colREFERANS_NO.FieldName = "REFERANS_NO";
                colREFERANS_NO.Caption = "Referans No";
                colREFERANS_NO.Name = "colREFERANS_NO";
                colREFERANS_NO.OptionsColumn.ReadOnly = true;
                colREFERANS_NO.Visible = true;
                colREFERANS_NO.VisibleIndex = 64;

                GridColumn colHESAP_ACIKLAMA = new GridColumn();
                colHESAP_ACIKLAMA.FieldName = "HESAP_ACIKLAMA";
                colHESAP_ACIKLAMA.Caption = "Hesap Açýklama";
                colHESAP_ACIKLAMA.Name = "colHESAP_ACIKLAMA";
                colHESAP_ACIKLAMA.OptionsColumn.ReadOnly = true;
                colHESAP_ACIKLAMA.Visible = true;
                colHESAP_ACIKLAMA.VisibleIndex = 65;

                GridColumn colKULLANICI = new GridColumn();
                colKULLANICI.FieldName = "KULLANICI";
                colKULLANICI.Caption = "Kullanýcý";
                colKULLANICI.Name = "colKULLANICI";
                colKULLANICI.OptionsColumn.ReadOnly = true;
                colKULLANICI.Visible = true;
                colKULLANICI.VisibleIndex = 66;

                GridColumn colBURO = new GridColumn();
                colBURO.FieldName = "BURO";
                colBURO.Caption = "Büro";
                colBURO.Name = "colBURO";
                colBURO.OptionsColumn.ReadOnly = true;
                colBURO.Visible = true;
                colBURO.VisibleIndex = 67;

                GridColumn colBORC_ALACAK_ADI = new GridColumn();
                colBORC_ALACAK_ADI.FieldName = "BORC_ALACAK_ADI";
                colBORC_ALACAK_ADI.Caption = "Borç Alacak";
                colBORC_ALACAK_ADI.Name = "colBORC_ALACAK_ADI";
                colBORC_ALACAK_ADI.OptionsColumn.ReadOnly = true;
                colBORC_ALACAK_ADI.Visible = true;
                colBORC_ALACAK_ADI.VisibleIndex = 68;

                GridColumn colODEME_TIP_ADI = new GridColumn();
                colODEME_TIP_ADI.FieldName = "ODEME_TIP_ADI";
                colODEME_TIP_ADI.Caption = "Ödeme Tipi";
                colODEME_TIP_ADI.Name = "colODEME_TIP_ADI";
                colODEME_TIP_ADI.OptionsColumn.ReadOnly = true;
                colODEME_TIP_ADI.Visible = true;
                colODEME_TIP_ADI.VisibleIndex = 69;

                GridColumn colDosya_No = new GridColumn();
                colDosya_No.FieldName = "Dosya_No";
                colDosya_No.Caption = "Dosya No";
                colDosya_No.Name = "colDosya_No";
                colDosya_No.OptionsColumn.ReadOnly = true;
                colDosya_No.Visible = true;
                colDosya_No.VisibleIndex = 70;

                GridColumn colFOY_ADLIYE = new GridColumn();
                colFOY_ADLIYE.FieldName = "FOY_ADLIYE";
                colFOY_ADLIYE.Caption = "Adliye";
                colFOY_ADLIYE.Name = "colFOY_ADLIYE";
                colFOY_ADLIYE.OptionsColumn.ReadOnly = true;
                colFOY_ADLIYE.Visible = true;
                colFOY_ADLIYE.VisibleIndex = 71;

                GridColumn colFOY_GOREV = new GridColumn();
                colFOY_GOREV.FieldName = "FOY_GOREV";
                colFOY_GOREV.Caption = "Görev";
                colFOY_GOREV.Name = "colFOY_GOREV";
                colFOY_GOREV.OptionsColumn.ReadOnly = true;
                colFOY_GOREV.Visible = true;
                colFOY_GOREV.VisibleIndex = 72;

                GridColumn colFOY_ADLI_BIRIM_NO = new GridColumn();
                colFOY_ADLI_BIRIM_NO.FieldName = "FOY_ADLI_BIRIM_NO";
                colFOY_ADLI_BIRIM_NO.Caption = "No";
                colFOY_ADLI_BIRIM_NO.Name = "colFOY_ADLI_BIRIM_NO";
                colFOY_ADLI_BIRIM_NO.OptionsColumn.ReadOnly = true;
                colFOY_ADLI_BIRIM_NO.Visible = true;
                colFOY_ADLI_BIRIM_NO.VisibleIndex = 73;

                GridColumn colEsas_No = new GridColumn();
                colEsas_No.FieldName = "Esas_No";
                colEsas_No.Caption = "Dosya Esas No";
                colEsas_No.Name = "colEsas_No";
                colEsas_No.OptionsColumn.ReadOnly = true;
                colEsas_No.Visible = true;
                colEsas_No.VisibleIndex = 74;

                GridColumn colTakip_T = new GridColumn();
                colTakip_T.FieldName = "Takip_T";
                colTakip_T.Caption = "Dosya Takip T";
                colTakip_T.Name = "colTakip_T";
                colTakip_T.OptionsColumn.ReadOnly = true;
                colTakip_T.Visible = true;
                colTakip_T.VisibleIndex = 75;

                GridColumn colTakip_Konusu = new GridColumn();
                colTakip_Konusu.FieldName = "Takip_Konusu";
                colTakip_Konusu.Caption = "Dosya Takip Konusu";
                colTakip_Konusu.Name = "colTakip_Konusu";
                colTakip_Konusu.OptionsColumn.ReadOnly = true;
                colTakip_Konusu.Visible = true;
                colTakip_Konusu.VisibleIndex = 76;

                GridColumn colDURUM = new GridColumn();
                colDURUM.FieldName = "DURUM";
                colDURUM.Caption = "Dosya Durum";
                colDURUM.Name = "colDURUM";
                colDURUM.OptionsColumn.ReadOnly = true;
                colDURUM.Visible = true;
                colDURUM.VisibleIndex = 77;

                GridColumn colHESAP_HAREKET_ANA_KATEGORI = new GridColumn();
                colHESAP_HAREKET_ANA_KATEGORI.FieldName = "HESAP_HAREKET_ANA_KATEGORI";
                colHESAP_HAREKET_ANA_KATEGORI.Caption = "Hesap Hareket Ana Kat";
                colHESAP_HAREKET_ANA_KATEGORI.Name = "colHESAP_HAREKET_ANA_KATEGORI";
                colHESAP_HAREKET_ANA_KATEGORI.OptionsColumn.ReadOnly = true;
                colHESAP_HAREKET_ANA_KATEGORI.Visible = true;
                colHESAP_HAREKET_ANA_KATEGORI.VisibleIndex = 78;

                GridColumn colHESAP_HAREKET_ALT_KAREGORI = new GridColumn();
                colHESAP_HAREKET_ALT_KAREGORI.FieldName = "HESAP_HAREKET_ALT_KAREGORI";
                colHESAP_HAREKET_ALT_KAREGORI.Name = "colHESAP_HAREKET_ALT_KAREGORI";
                colHESAP_HAREKET_ALT_KAREGORI.Caption = "Hesap Hareket Alt Kat";
                colHESAP_HAREKET_ALT_KAREGORI.OptionsColumn.ReadOnly = true;
                colHESAP_HAREKET_ALT_KAREGORI.Visible = true;
                colHESAP_HAREKET_ALT_KAREGORI.VisibleIndex = 79;

                #endregion

                #region []

                GridColumn[] dizi = new[]
                                            {
                                                colDOSYA_MUH_AKTARILDI,
                                                colCARI_HESAP_HEDEF_TIP,
                                                colTARIH,
                                                colKULLANICI_BELGE_NO,
                                                colADET,
                                                colBIRIM_FIYAT,
                                                colBIRIM_FIYAT_DOVIZ_ID,
                                                colGENEL_TOPLAM,
                                                colKALAN_DOVIZ_ID,
                                                colKALAN,
                                                colODENEN_DOVIZ_ID,
                                                colODENEN,
                                                colALINAN_DOVIZ_ID,
                                                colALINAN,
                                                colACIKLAMA,
                                                colINCELENDI,
                                                colONAY_TARIHI,
                                                colONAY_NO,
                                                colONAY_DURUM,
                                                colCARI_AD,
                                                colCARI_KOD,
                                                colCARI_PERSONEL,
                                                colCARI_MUVEKKIL,
                                                colCARI_FIRMA,
                                                colCARI_AVUKAT,
                                                //colHESAP_ID,
                                                colREFERANS_NO,
                                                colHESAP_ACIKLAMA,
                                                colKULLANICI,
                                                colBURO,
                                                colBORC_ALACAK_ADI,
                                                colODEME_TIP_ADI,
                                                colDosya_No,
                                                colFOY_ADLIYE,
                                                colFOY_GOREV,
                                                colFOY_ADLI_BIRIM_NO,
                                                colEsas_No,
                                                colTakip_T,
                                                colTakip_Konusu,
                                                colDURUM,
                                                colHESAP_HAREKET_ANA_KATEGORI,
                                                colHESAP_HAREKET_ALT_KAREGORI
                                            };

                #endregion

                foreach (var item in dizi)
                {
                    item.OptionsColumn.ReadOnly = true;
                    item.OptionsColumn.AllowEdit = false;
                }

                return dizi;
            }
        }
    }

    public static class MuhasebePivot
    {
        public class MasrafAvansMuhasebe
        {
            private RepositoryItemLookUpEdit rlueCari = new RepositoryItemLookUpEdit();
            private RepositoryItemLookUpEdit rlueBorcAlacak = new RepositoryItemLookUpEdit();
            private RepositoryItemLookUpEdit rlueOdemeTipi = new RepositoryItemLookUpEdit();
            private RepositoryItemLookUpEdit rlueHarketAna = new RepositoryItemLookUpEdit();
            private RepositoryItemLookUpEdit rlueHarketAlt = new RepositoryItemLookUpEdit();
            private RepositoryItemLookUpEdit rlueAdliye = new RepositoryItemLookUpEdit();
            private RepositoryItemLookUpEdit rlueSegment = new RepositoryItemLookUpEdit();

            private RepositoryItemLookUpEdit rlueModul = new RepositoryItemLookUpEdit();

            public Dictionary<string, RepositoryItem> GetRepositoryItemByFieldName()
            {
                BelgeUtil.Inits.perCariGetir(rlueCari);
                BelgeUtil.Inits.ModulGetir(rlueModul);
                BelgeUtil.Inits.BorcAlacakGetir(rlueBorcAlacak);
                BelgeUtil.Inits.OdemeTipiGetir(rlueOdemeTipi);
                BelgeUtil.Inits.MuhasebeHareketAltKategori(rlueHarketAlt);
                BelgeUtil.Inits.HareketAnaKategoriGetir(rlueHarketAna);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliye);

                Dictionary<string, RepositoryItem> sozluk = new Dictionary<string, RepositoryItem>();

                #region Add item

                sozluk.Add("MuvekkilCariId", rlueCari);
                sozluk.Add("CariId", rlueCari);
                sozluk.Add("BorcluCariId", rlueCari);
                sozluk.Add("ModulId", rlueModul);
                sozluk.Add("BorcAlacakId", rlueBorcAlacak);
                sozluk.Add("OdemeTipId", rlueOdemeTipi);
                sozluk.Add("HareketAnaKategoriId", rlueHarketAna);
                sozluk.Add("HareketAltKategoriId", rlueHarketAlt);
                sozluk.Add("AdliBirimAdliyeId", rlueAdliye);
                sozluk.Add("SegmentId", rlueSegment);

                #endregion

                return sozluk;
            }

            public PivotGridField[] GetFields()
            {
                #region Field & Properties

                PivotGridField fieldMUVEKKILCARIID = new DevExpress.XtraPivotGrid.PivotGridField();
                fieldMUVEKKILCARIID.AreaIndex = 0;
                fieldMUVEKKILCARIID.Caption = "Müvekkil";
                fieldMUVEKKILCARIID.FieldName = "MuvekkilCariId";
                fieldMUVEKKILCARIID.Name = "fieldMUVEKKILCARIID";

                PivotGridField fieldTOPLAMTUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
                fieldTOPLAMTUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
                fieldTOPLAMTUTAR.AreaIndex = 0;
                fieldTOPLAMTUTAR.Caption = "Toplam Tutar";
                fieldTOPLAMTUTAR.FieldName = "ToplamTutar";
                fieldTOPLAMTUTAR.Name = "fieldTOPLAMTUTAR";

                PivotGridField fieldONAYTARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
                fieldONAYTARIHI.AreaIndex = 1;
                fieldONAYTARIHI.Caption = "Onay T";
                fieldONAYTARIHI.FieldName = "OnayTarihi";
                fieldONAYTARIHI.Name = "fieldONAYTARIHI";

                PivotGridField fieldCARIID = new DevExpress.XtraPivotGrid.PivotGridField();
                fieldCARIID.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                fieldCARIID.AreaIndex = 2;
                fieldCARIID.Caption = "Sorumlu Adý";
                fieldCARIID.FieldName = "CariId";
                fieldCARIID.Name = "fieldCARIID";

                PivotGridField fieldMASRAFAVANSTIP = new DevExpress.XtraPivotGrid.PivotGridField();
                fieldMASRAFAVANSTIP.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                fieldMASRAFAVANSTIP.AreaIndex = 3;
                fieldMASRAFAVANSTIP.Caption = "Masraf Avans Tip";
                fieldMASRAFAVANSTIP.FieldName = "MasrafAvansTip";
                fieldMASRAFAVANSTIP.Name = "fieldMASRAFAVANSTIP";

                PivotGridField fieldBORCLUCARIID = new DevExpress.XtraPivotGrid.PivotGridField();
                fieldBORCLUCARIID.AreaIndex = 4;
                fieldBORCLUCARIID.Caption = "Borçlu Adý";
                fieldBORCLUCARIID.FieldName = "BorcluCariId";
                fieldBORCLUCARIID.Name = "fieldBORCLUCARIID";

                PivotGridField fieldMODULID = new DevExpress.XtraPivotGrid.PivotGridField();
                fieldMODULID.AreaIndex = 5;
                fieldMODULID.Caption = "Modül";
                fieldMODULID.FieldName = "M";
                fieldMODULID.Name = "fieldMODULID";

                PivotGridField fieldTARIH = new DevExpress.XtraPivotGrid.PivotGridField();
                fieldTARIH.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                fieldTARIH.GroupInterval = PivotGroupInterval.DateYear;
                fieldTARIH.AreaIndex = 0;
                fieldTARIH.Caption = "Yýl";
                fieldTARIH.FieldName = "Tarih";
                fieldTARIH.Name = "fieldTARIH";

                PivotGridField fieldTARIH2 = new DevExpress.XtraPivotGrid.PivotGridField();
                fieldTARIH2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                fieldTARIH2.GroupInterval = PivotGroupInterval.DateMonth;
                fieldTARIH2.AreaIndex = 1;
                fieldTARIH2.Caption = "Ay";
                fieldTARIH2.FieldName = "Tarih";
                fieldTARIH2.Name = "fieldTARIH2";

                PivotGridField fieldTARIH3 = new DevExpress.XtraPivotGrid.PivotGridField();
                fieldTARIH3.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                fieldTARIH3.GroupInterval = PivotGroupInterval.DateDay;
                fieldTARIH3.AreaIndex = 0;
                fieldTARIH3.Caption = "Gün";
                fieldTARIH3.FieldName = "Tarih";
                fieldTARIH3.Name = "fieldTARIH3";
                fieldTARIH3.Visible = false;

                PivotGridField fieldBORCALACAKID = new DevExpress.XtraPivotGrid.PivotGridField();
                fieldBORCALACAKID.AreaIndex = 6;
                fieldBORCALACAKID.Caption = "B/A";
                fieldBORCALACAKID.FieldName = "BorcAlacakId";
                fieldBORCALACAKID.Name = "fieldBORCALACAKID";

                PivotGridField fieldODEMETIPID = new DevExpress.XtraPivotGrid.PivotGridField();
                fieldODEMETIPID.AreaIndex = 7;
                fieldODEMETIPID.Caption = "Ödeme Tipi";
                fieldODEMETIPID.FieldName = "OdemeTipId";
                fieldODEMETIPID.Name = "fieldODEMETIPID";

                PivotGridField fieldHAREKETANAKATEGORIID = new DevExpress.XtraPivotGrid.PivotGridField();
                fieldHAREKETANAKATEGORIID.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                fieldHAREKETANAKATEGORIID.AreaIndex = 2;
                fieldHAREKETANAKATEGORIID.Caption = "Ana Kategori";
                fieldHAREKETANAKATEGORIID.FieldName = "HareketAnaKategoriId";
                fieldHAREKETANAKATEGORIID.Name = "fieldHAREKETANAKATEGORIID";

                PivotGridField fieldHAREKETALTKATEGORIID = new DevExpress.XtraPivotGrid.PivotGridField();
                fieldHAREKETALTKATEGORIID.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                fieldHAREKETALTKATEGORIID.AreaIndex = 3;
                fieldHAREKETALTKATEGORIID.Caption = "Alt Kategori";
                fieldHAREKETALTKATEGORIID.FieldName = "HareketAltKategoriId";
                fieldHAREKETALTKATEGORIID.Name = "fieldHAREKETALTKATEGORIID";

                PivotGridField fieldFOYNO = new DevExpress.XtraPivotGrid.PivotGridField();
                fieldFOYNO.AreaIndex = 8;
                fieldFOYNO.Caption = "Dosya No";
                fieldFOYNO.FieldName = "FoyNo";
                fieldFOYNO.Name = "fieldFOYNO";

                PivotGridField fieldADLIBIRIMADLIYEID = new DevExpress.XtraPivotGrid.PivotGridField();
                fieldADLIBIRIMADLIYEID.AreaIndex = 9;
                fieldADLIBIRIMADLIYEID.Caption = "Adliye";
                fieldADLIBIRIMADLIYEID.FieldName = "AdliBirimAdliyeId";
                fieldADLIBIRIMADLIYEID.Name = "fieldADLIBIRIMADLIYEID";

                PivotGridField fieldSegmentId = new DevExpress.XtraPivotGrid.PivotGridField();
                fieldADLIBIRIMADLIYEID.AreaIndex = 10;
                fieldADLIBIRIMADLIYEID.Caption = "Bölüm";
                fieldADLIBIRIMADLIYEID.FieldName = "SegmentId";
                fieldADLIBIRIMADLIYEID.Name = "fieldSegmentId";

                PivotGridField fieldID = new DevExpress.XtraPivotGrid.PivotGridField();
                fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
                fieldID.AreaIndex = 0;
                fieldID.Caption = "Kayýt Sayýsý";
                fieldID.FieldName = "Id";
                fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
                fieldID.Name = "fieldID";

                #endregion

                #region []

                PivotGridField[] dizi = new[]
                                                {
                                                    fieldMUVEKKILCARIID,
                                                    fieldTOPLAMTUTAR,
                                                    fieldONAYTARIHI,
                                                    fieldCARIID,
                                                    fieldMASRAFAVANSTIP,
                                                    fieldMODULID,
                                                    fieldTARIH,
                                                    fieldTARIH2,
                                                    fieldTARIH3,
                                                    fieldBORCALACAKID,
                                                    fieldBORCLUCARIID,
                                                    fieldODEMETIPID,
                                                    fieldHAREKETANAKATEGORIID,
                                                    fieldHAREKETALTKATEGORIID,
                                                    fieldADLIBIRIMADLIYEID,
                                                    fieldFOYNO,
                                                    fieldID,
                                                    fieldSegmentId
                                                };

                #endregion

                #region Field Caption

                Dictionary<string, RepositoryItem> editler = GetRepositoryItemByFieldName();
                for (int i = 0; i < dizi.Length; i++)
                {
                    if (editler.ContainsKey(dizi[i].FieldName))
                        dizi[i].FieldEdit = editler[dizi[i].FieldName];
                }

                #endregion

                return dizi;
            }
        }

        public class CariHesapMuhasebe
        {
            private RepositoryItemLookUpEdit rlueDoviz = new RepositoryItemLookUpEdit();

            public Dictionary<string, RepositoryItem> GetRepositoryItemByFieldName()
            {
                BelgeUtil.Inits.DovizTipGetir(rlueDoviz);

                Dictionary<string, RepositoryItem> sozluk = new Dictionary<string, RepositoryItem>();

                #region Add item

                sozluk.Add("BIRIM_FIYAT_DOVIZ_ID", rlueDoviz);

                #endregion

                return sozluk;
            }

            public PivotGridField[] GetFields()
            {
                #region Field & Properties

                PivotGridField fieldCARIAD = new PivotGridField();
                fieldCARIAD.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                fieldCARIAD.AreaIndex = 0;
                fieldCARIAD.Caption = "Personel";
                fieldCARIAD.FieldName = "CARI_AD";
                fieldCARIAD.Name = "fieldCARIAD";

                PivotGridField fieldBURO = new PivotGridField();
                fieldBURO.AreaIndex = 0;
                fieldBURO.Caption = "Büro";
                fieldBURO.FieldName = "BURO";
                fieldBURO.Name = "fieldBURO";

                PivotGridField fieldBORCALACAKADI = new PivotGridField();
                fieldBORCALACAKADI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                fieldBORCALACAKADI.AreaIndex = 1;
                fieldBORCALACAKADI.Caption = "B/A";
                fieldBORCALACAKADI.FieldName = "BORC_ALACAK_ADI";
                fieldBORCALACAKADI.Name = "fieldBORCALACAKADI";

                PivotGridField fieldODEMETIPADI = new PivotGridField();
                fieldODEMETIPADI.AreaIndex = 1;
                fieldODEMETIPADI.Caption = "Ödeme Tipi";
                fieldODEMETIPADI.FieldName = "ODEME_TIP_ADI";
                fieldODEMETIPADI.Name = "fieldODEMETIPADI";

                PivotGridField fieldDosyaNo = new PivotGridField();
                fieldDosyaNo.AreaIndex = 2;
                fieldDosyaNo.Caption = "Dosya No";
                fieldDosyaNo.FieldName = "Dosya_No";
                fieldDosyaNo.Name = "fieldDosyaNo";

                PivotGridField fieldFOYADLIYE = new PivotGridField();
                fieldFOYADLIYE.AreaIndex = 3;
                fieldFOYADLIYE.Caption = "Adliye";
                fieldFOYADLIYE.FieldName = "FOY_ADLIYE";
                fieldFOYADLIYE.Name = "fieldFOYADLIYE";

                PivotGridField fieldHESAPHAREKETANAKATEGORI = new PivotGridField();
                fieldHESAPHAREKETANAKATEGORI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                fieldHESAPHAREKETANAKATEGORI.AreaIndex = 3;
                fieldHESAPHAREKETANAKATEGORI.Caption = "Hesap Ana KAt";
                fieldHESAPHAREKETANAKATEGORI.FieldName = "HESAP_HAREKET_ANA_KATEGORI";
                fieldHESAPHAREKETANAKATEGORI.Name = "fieldHESAPHAREKETANAKATEGORI";

                PivotGridField fieldHESAPHAREKETALTKAREGORI = new PivotGridField();
                fieldHESAPHAREKETALTKAREGORI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                fieldHESAPHAREKETALTKAREGORI.AreaIndex = 4;
                fieldHESAPHAREKETALTKAREGORI.Caption = "Hesap Alt Kat";
                fieldHESAPHAREKETALTKAREGORI.FieldName = "HESAP_HAREKET_ALT_KAREGORI";
                fieldHESAPHAREKETALTKAREGORI.Name = "fieldHESAPHAREKETALTKAREGORI";

                PivotGridField fieldID = new PivotGridField();
                fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
                fieldID.AreaIndex = 0;
                fieldID.Caption = "Kayýt Sayýsý";
                fieldID.FieldName = "ID";
                fieldID.Name = "fieldID";
                fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;

                PivotGridField fieldCARIHESAPHEDEFTIP = new PivotGridField();
                fieldCARIHESAPHEDEFTIP.AreaIndex = 4;
                fieldCARIHESAPHEDEFTIP.Caption = "Hesap Hedef Tip";
                fieldCARIHESAPHEDEFTIP.FieldName = "CARI_HESAP_HEDEF_TIP";
                fieldCARIHESAPHEDEFTIP.Name = "fieldCARIHESAPHEDEFTIP";

                PivotGridField fieldTARIH = new PivotGridField();
                fieldTARIH.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                fieldTARIH.GroupInterval = PivotGroupInterval.DateYear;
                fieldTARIH.AreaIndex = 1;
                fieldTARIH.Caption = "Yýl";
                fieldTARIH.FieldName = "TARIH";
                fieldTARIH.Name = "fieldTARIH";

                PivotGridField fieldTARIH2 = new PivotGridField();
                fieldTARIH2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                fieldTARIH2.GroupInterval = PivotGroupInterval.DateMonth;
                fieldTARIH2.AreaIndex = 2;
                fieldTARIH2.Caption = "Ay";
                fieldTARIH2.FieldName = "TARIH";
                fieldTARIH2.Name = "fieldTARIH2";

                PivotGridField fieldTARIH3 = new PivotGridField();
                fieldTARIH3.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                fieldTARIH3.GroupInterval = PivotGroupInterval.DateDay;
                fieldTARIH3.AreaIndex = 2;
                fieldTARIH3.Caption = "Gün";
                fieldTARIH3.FieldName = "TARIH";
                fieldTARIH3.Name = "fieldTARIH3";
                fieldTARIH3.Visible = false;

                PivotGridField fieldGENEL_TOPLAM = new PivotGridField();
                fieldGENEL_TOPLAM.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
                fieldGENEL_TOPLAM.AreaIndex = 1;
                fieldGENEL_TOPLAM.Caption = "Genel Toplam";
                fieldGENEL_TOPLAM.FieldName = "GENEL_TOPLAM";
                fieldGENEL_TOPLAM.Name = "fieldGENEL_TOPLAM";

                PivotGridField fieldONAYTARIHI = new PivotGridField();
                fieldONAYTARIHI.AreaIndex = 5;
                fieldONAYTARIHI.Caption = "Onay T";
                fieldONAYTARIHI.FieldName = "ONAY_TARIHI";
                fieldONAYTARIHI.Name = "fieldONAYTARIHI";

                PivotGridField fieldONAYDURUM = new PivotGridField();
                fieldONAYDURUM.AreaIndex = 6;
                fieldONAYDURUM.Caption = "Onay Durum";
                fieldONAYDURUM.FieldName = "ONAY_DURUM";
                fieldONAYDURUM.Name = "fieldONAYDURUM";

                PivotGridField fieldPROJEID = new PivotGridField();
                fieldPROJEID.AreaIndex = 7;
                fieldPROJEID.Caption = "Klasör";
                fieldPROJEID.FieldName = "PROJE_ID";
                fieldPROJEID.Name = "fieldPROJEID";

                PivotGridField fieldBIRIM_FIYAT_DOVIZ_ID = new PivotGridField();
                fieldBIRIM_FIYAT_DOVIZ_ID.AreaIndex = 8;
                fieldBIRIM_FIYAT_DOVIZ_ID.Caption = "Brm";
                fieldBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
                fieldBIRIM_FIYAT_DOVIZ_ID.Name = "fieldBIRIM_FIYAT_DOVIZ_ID";

                #endregion

                #region []

                PivotGridField[] dizi = new[]
                                                {
                                                    fieldCARIAD,
                                                    fieldBURO,
                                                    fieldBORCALACAKADI,
                                                    fieldODEMETIPADI,
                                                    fieldDosyaNo,
                                                    fieldFOYADLIYE,
                                                    fieldHESAPHAREKETANAKATEGORI,
                                                    fieldHESAPHAREKETALTKAREGORI,
                                                    fieldID,
                                                    fieldCARIHESAPHEDEFTIP,
                                                    fieldTARIH,
                                                    fieldTARIH2,
                                                    fieldTARIH3,
                                                    fieldGENEL_TOPLAM,
                                                    fieldONAYTARIHI,
                                                    fieldONAYDURUM,
                                                    fieldPROJEID,
                                                    fieldBIRIM_FIYAT_DOVIZ_ID
                                                };

                #endregion

                #region Field Caption

                Dictionary<string, RepositoryItem> editler = GetRepositoryItemByFieldName();
                for (int i = 0; i < dizi.Length; i++)
                {
                    if (editler.ContainsKey(dizi[i].FieldName))
                        dizi[i].FieldEdit = editler[dizi[i].FieldName];
                }

                #endregion

                return dizi;
            }
        }

        public class KasaHesapMuhasebe
        {
            private RepositoryItemLookUpEdit rlueDoviz = new RepositoryItemLookUpEdit();
            private RepositoryItemLookUpEdit rlueCari = new RepositoryItemLookUpEdit();
            private RepositoryItemLookUpEdit rlueBorcAlacak = new RepositoryItemLookUpEdit();
            private RepositoryItemLookUpEdit rluehareketAnaTur = new RepositoryItemLookUpEdit();
            private RepositoryItemLookUpEdit rlueBuro = new RepositoryItemLookUpEdit();
            private RepositoryItemLookUpEdit rLueOdemeTip = new RepositoryItemLookUpEdit();

            public Dictionary<string, RepositoryItem> GetRepositoryItemByFieldName()
            {
                BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
                BelgeUtil.Inits.perCariGetir(rlueCari);
                BelgeUtil.Inits.BorcAlacakGetir(rlueBorcAlacak);
                BelgeUtil.Inits.HareketAnaKategoriGetir(rluehareketAnaTur);
                BelgeUtil.Inits.SubeKodGetir(rlueBuro);
                BelgeUtil.Inits.OdemeTipiGetir(rLueOdemeTip);

                Dictionary<string, RepositoryItem> sozluk = new Dictionary<string, RepositoryItem>();

                #region Add item

                sozluk.Add("BIRIM_FIYAT_DOVIZ_ID", rlueDoviz);
                sozluk.Add("HAREKET_CARI_ID", rlueCari);
                sozluk.Add("BORC_ALACAK_ID", rlueBorcAlacak);
                sozluk.Add("ODEME_TIP_ID", rLueOdemeTip);
                sozluk.Add("HAREKET_ANA_KATEGORI_ID", rluehareketAnaTur);
                sozluk.Add("SUBE_KOD_ID", rlueBuro);

                #endregion

                return sozluk;
            }

            public PivotGridField[] GetFields()
            {
                #region Field & Properties

                PivotGridField fieldID = new PivotGridField();
                fieldID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
                fieldID.AreaIndex = 0;
                fieldID.Caption = "Kayýt Sayýsý";
                fieldID.FieldName = "ID";
                fieldID.Name = "fieldID";
                fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;

                PivotGridField fieldHAREKETCARIID = new PivotGridField();
                fieldHAREKETCARIID.AreaIndex = 2;
                fieldHAREKETCARIID.Caption = "Þahýs";
                fieldHAREKETCARIID.FieldName = "HAREKET_CARI_ID";
                fieldHAREKETCARIID.Name = "fieldHAREKETCARIID";

                PivotGridField fieldBORCALACAKID = new PivotGridField();
                fieldBORCALACAKID.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                fieldBORCALACAKID.AreaIndex = 4;
                fieldBORCALACAKID.Caption = "B/A";
                fieldBORCALACAKID.FieldName = "BORC_ALACAK_ID";
                fieldBORCALACAKID.Name = "fieldBORCALACAKID";

                PivotGridField fieldODEMETIPID = new PivotGridField();
                fieldODEMETIPID.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                fieldODEMETIPID.AreaIndex = 5;
                fieldODEMETIPID.Caption = "Ödeme Tip";
                fieldODEMETIPID.FieldName = "ODEME_TIP_ID";
                fieldODEMETIPID.Name = "fieldODEMETIPID";

                PivotGridField fieldTARIH = new PivotGridField();
                fieldTARIH.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                fieldTARIH.AreaIndex = 0;
                fieldTARIH.Caption = "Yýl";
                fieldTARIH.FieldName = "TARIH";
                fieldTARIH.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateYear;
                fieldTARIH.Name = "fieldTARIH";

                PivotGridField fieldHAREKETANAKATEGORIID = new PivotGridField();
                fieldHAREKETANAKATEGORIID.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                fieldHAREKETANAKATEGORIID.AreaIndex = 3;
                fieldHAREKETANAKATEGORIID.Caption = "Ana Kat";
                fieldHAREKETANAKATEGORIID.FieldName = "HAREKET_ANA_KATEGORI_ID";
                fieldHAREKETANAKATEGORIID.Name = "fieldHAREKETANAKATEGORIID";

                PivotGridField fieldBIRIMFIYATDOVIZID = new PivotGridField();
                fieldBIRIMFIYATDOVIZID.AreaIndex = 0;
                fieldBIRIMFIYATDOVIZID.Caption = "Brm";
                fieldBIRIMFIYATDOVIZID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
                fieldBIRIMFIYATDOVIZID.Name = "fieldBIRIMFIYATDOVIZID";

                PivotGridField fieldGENELTOPLAM = new PivotGridField();
                fieldGENELTOPLAM.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
                fieldGENELTOPLAM.AreaIndex = 1;
                fieldGENELTOPLAM.Caption = "Genel Toplam";
                fieldGENELTOPLAM.FieldName = "GENEL_TOPLAM";
                fieldGENELTOPLAM.Name = "fieldGENELTOPLAM";

                PivotGridField fieldSUBEKODID = new PivotGridField();
                fieldSUBEKODID.AreaIndex = 1;
                fieldSUBEKODID.Caption = "Büro";
                fieldSUBEKODID.FieldName = "SUBE_KOD_ID";
                fieldSUBEKODID.Name = "fieldSUBEKODID";

                PivotGridField fieldTARIH2 = new PivotGridField();
                fieldTARIH2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                fieldTARIH2.AreaIndex = 1;
                fieldTARIH2.Caption = "Ay";
                fieldTARIH2.FieldName = "TARIH";
                fieldTARIH2.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateMonth;
                fieldTARIH2.Name = "fieldTARIH2";

                PivotGridField fieldTARIH3 = new PivotGridField();
                fieldTARIH3.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                fieldTARIH3.AreaIndex = 2;
                fieldTARIH3.Caption = "Gün";
                fieldTARIH3.FieldName = "TARIH";
                fieldTARIH3.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateDay;
                fieldTARIH3.Name = "fieldTARIH3";

                #endregion

                #region []

                PivotGridField[] dizi = new[]
                                                {
                                                    fieldID,
                                                    fieldHAREKETCARIID,
                                                    fieldBORCALACAKID,
                                                    fieldODEMETIPID,
                                                    fieldTARIH,
                                                    fieldHAREKETANAKATEGORIID,
                                                    fieldBIRIMFIYATDOVIZID,
                                                    fieldGENELTOPLAM,
                                                    fieldSUBEKODID,
                                                    fieldTARIH2,
                                                    fieldTARIH3
                                                };

                #endregion

                #region Field Caption

                Dictionary<string, RepositoryItem> editler = GetRepositoryItemByFieldName();
                for (int i = 0; i < dizi.Length; i++)
                {
                    if (editler.ContainsKey(dizi[i].FieldName))
                        dizi[i].FieldEdit = editler[dizi[i].FieldName];
                }

                #endregion

                return dizi;
            }
        }

        public class DavaFoy
        {
            #region Repository Items

            private RepositoryItemLookUpEdit rlueDoviz = new RepositoryItemLookUpEdit();
            private RepositoryItemLookUpEdit rlueFoyDurum = new RepositoryItemLookUpEdit();
            private RepositoryItemLookUpEdit rlueTarafKodu = new RepositoryItemLookUpEdit();
            private RepositoryItemLookUpEdit rlueAsama = new RepositoryItemLookUpEdit();
            private RepositoryItemLookUpEdit rlueCari = new RepositoryItemLookUpEdit();

            #endregion

            public PivotGridField[] GetFields()
            {
                #region Bind RepositoryItems

                BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
                BelgeUtil.Inits.FoyDurumGetir(rlueFoyDurum);
                BelgeUtil.Inits.TarafKoduGetir(rlueTarafKodu);
                BelgeUtil.Inits.AsamaKodGetir(rlueAsama);
                //BelgeUtil.Inits.CariHesapGetir(rlueCari); 
                BelgeUtil.Inits.perCariGetir(rlueCari);

                #endregion

                #region fields & properties

                //fieldFOY_NO
                PivotGridField fieldID = new PivotGridField();
                fieldID.Area = PivotArea.DataArea;
                fieldID.AreaIndex = 1;
                fieldID.Caption = "Dosya Sayýsý";
                fieldID.FieldName = "ID";
                fieldID.Name = "fieldID";
                fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;

                PivotGridField fieldFOY_DURUM_ID = new PivotGridField();
                fieldFOY_DURUM_ID.Area = PivotArea.RowArea;
                fieldFOY_DURUM_ID.AreaIndex = 0;
                fieldFOY_DURUM_ID.Caption = "Durum";
                fieldFOY_DURUM_ID.FieldName = "FOY_DURUM_ID";
                fieldFOY_DURUM_ID.Name = "fieldFOY_DURUM_ID";
                fieldFOY_DURUM_ID.FieldEdit = rlueFoyDurum;

                PivotGridField fieldDAVA_TARIHI = new PivotGridField();
                fieldDAVA_TARIHI.Area = PivotArea.RowArea;
                fieldDAVA_TARIHI.AreaIndex = 2;
                fieldDAVA_TARIHI.Caption = "Dava T.";
                fieldDAVA_TARIHI.FieldName = "DAVA_TARIHI";
                fieldDAVA_TARIHI.Name = "fieldDAVA_TARIHI";
                fieldDAVA_TARIHI.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateYear;

                //fieldESAS_NO
                PivotGridField fieldAVUKATA_INTIKAL_TARIHI = new PivotGridField();
                //fieldAVUKATA_INTIKAL_TARIHI.AreaIndex = 2;
                fieldAVUKATA_INTIKAL_TARIHI.Caption = "Esas No";
                fieldAVUKATA_INTIKAL_TARIHI.FieldName = "AVUKATA_INTIKAL_TARIHI";
                fieldAVUKATA_INTIKAL_TARIHI.Name = "fieldAVUKATA_INTIKAL_TARIHI";
                fieldAVUKATA_INTIKAL_TARIHI.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateYear;
                fieldAVUKATA_INTIKAL_TARIHI.Visible = false;

                //fieldMAKBUZ_NO
                //fieldACIKLAMA

                PivotGridField fieldKAYIT_TARIHI = new PivotGridField();
                fieldKAYIT_TARIHI.Area = PivotArea.FilterArea;
                fieldKAYIT_TARIHI.AreaIndex = 4;
                fieldKAYIT_TARIHI.Caption = "Kayýt T.";
                fieldKAYIT_TARIHI.FieldName = "KAYIT_TARIHI";
                fieldKAYIT_TARIHI.Name = "fieldKAYIT_TARIHI";
                fieldKAYIT_TARIHI.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateYear;

                PivotGridField fieldDAVA_DEGERI = new PivotGridField();
                fieldDAVA_DEGERI.Area = PivotArea.DataArea;
                fieldDAVA_DEGERI.AreaIndex = 0;
                fieldDAVA_DEGERI.Caption = "Deðeri";
                fieldDAVA_DEGERI.FieldName = "DAVA_DEGERI";
                fieldDAVA_DEGERI.Name = "fieldDAVA_DEGERI";

                PivotGridField fieldDAVA_DEGERI_DOVIZ_ID = new PivotGridField();
                //fieldDAVA_DEGERI_DOVIZ_ID.AreaIndex = 5;
                fieldDAVA_DEGERI_DOVIZ_ID.Caption = " ";
                fieldDAVA_DEGERI_DOVIZ_ID.FieldName = "DAVA_DEGERI_DOVIZ_ID";
                fieldDAVA_DEGERI_DOVIZ_ID.Name = "fieldDAVA_DEGERI_DOVIZ_ID";
                fieldDAVA_DEGERI_DOVIZ_ID.FieldEdit = rlueDoviz;
                fieldDAVA_DEGERI_DOVIZ_ID.Visible = false;

                PivotGridField fieldCezaiSartToplami = new PivotGridField();
                //fieldCezaiSartToplami.AreaIndex = 6;
                fieldCezaiSartToplami.Caption = "Dava Edilen T.";
                fieldCezaiSartToplami.FieldName = "CEZAI_SART_TOPLAMI";
                fieldCezaiSartToplami.Name = "fieldCezaiSartToplami";
                fieldCezaiSartToplami.Visible = false;

                PivotGridField fieldCezaiSartToplamiDovizId = new PivotGridField();
                //fieldCezaiSartToplamiDovizId.AreaIndex = 7;
                fieldCezaiSartToplamiDovizId.Caption = " ";
                fieldCezaiSartToplamiDovizId.FieldName = "CEZAI_SART_TOPLAMI_DOVIZ_ID";
                fieldCezaiSartToplamiDovizId.Name = "fieldCezaiSartToplamiDovizId";
                fieldCezaiSartToplamiDovizId.FieldEdit = rlueDoviz;
                fieldCezaiSartToplamiDovizId.Visible = false;

                PivotGridField fieldISLEMIS_FAIZ = new PivotGridField();
                //fieldISLEMIS_FAIZ.AreaIndex = 8;
                fieldISLEMIS_FAIZ.Caption = "Ýþlemiþ Faiz";
                fieldISLEMIS_FAIZ.FieldName = "ISLEMIS_FAIZ";
                fieldISLEMIS_FAIZ.Name = "fieldISLEMIS_FAIZ";
                fieldISLEMIS_FAIZ.Visible = false;

                PivotGridField fieldISLEMIS_FAIZ_DOVIZ_ID = new PivotGridField();
                //fieldISLEMIS_FAIZ_DOVIZ_ID.AreaIndex = 9;
                fieldISLEMIS_FAIZ_DOVIZ_ID.Caption = " ";
                fieldISLEMIS_FAIZ_DOVIZ_ID.FieldName = "ISLEMIS_FAIZ_DOVIZ_ID";
                fieldISLEMIS_FAIZ_DOVIZ_ID.Name = "fieldISLEMIS_FAIZ_DOVIZ_ID";
                fieldISLEMIS_FAIZ_DOVIZ_ID.FieldEdit = rlueDoviz;
                fieldISLEMIS_FAIZ_DOVIZ_ID.Visible = false;

                PivotGridField fieldDAVA_ONCESI_ODEME_TOPLAM = new PivotGridField();
                //fieldDAVA_ONCESI_ODEME_TOPLAM.AreaIndex = 42;
                fieldDAVA_ONCESI_ODEME_TOPLAM.Caption = "Dava Öncesi Ödeme T.";
                fieldDAVA_ONCESI_ODEME_TOPLAM.FieldName = "DAVA_ONCESI_ODEME_TOPLAM";
                fieldDAVA_ONCESI_ODEME_TOPLAM.Name = "fieldDAVA_ONCESI_ODEME_TOPLAM";
                fieldDAVA_ONCESI_ODEME_TOPLAM.Visible = false;

                PivotGridField fieldDAVA_ONCESI_TOPLAM_DOVIZ_ID = new PivotGridField();
                //fieldDAVA_ONCESI_TOPLAM_DOVIZ_ID.AreaIndex = 10;
                fieldDAVA_ONCESI_TOPLAM_DOVIZ_ID.Caption = " ";
                fieldDAVA_ONCESI_TOPLAM_DOVIZ_ID.FieldName = "DAVA_ONCESI_TOPLAM_DOVIZ_ID";
                fieldDAVA_ONCESI_TOPLAM_DOVIZ_ID.Name = "fieldDAVA_ONCESI_TOPLAM_DOVIZ_ID";
                fieldDAVA_ONCESI_TOPLAM_DOVIZ_ID.FieldEdit = rlueDoviz;
                fieldDAVA_ONCESI_TOPLAM_DOVIZ_ID.Visible = false;

                PivotGridField fieldSONRAKI_FAIZ = new PivotGridField();
                //fieldSONRAKI_FAIZ.AreaIndex = 11;
                fieldSONRAKI_FAIZ.Caption = "Sonraki Faiz";
                fieldSONRAKI_FAIZ.FieldName = "SONRAKI_FAIZ";
                fieldSONRAKI_FAIZ.Name = "fieldSONRAKI_FAIZ";
                fieldSONRAKI_FAIZ.Visible = false;

                PivotGridField fieldSONRAKI_FAIZ_DOVIZ_ID = new PivotGridField();
                //fieldSONRAKI_FAIZ_DOVIZ_ID.AreaIndex = 12;
                fieldSONRAKI_FAIZ_DOVIZ_ID.Caption = " ";
                fieldSONRAKI_FAIZ_DOVIZ_ID.FieldName = "SONRAKI_FAIZ_DOVIZ_ID";
                fieldSONRAKI_FAIZ_DOVIZ_ID.Name = "fieldSONRAKI_FAIZ_DOVIZ_ID";
                fieldSONRAKI_FAIZ_DOVIZ_ID.FieldEdit = rlueDoviz;
                fieldSONRAKI_FAIZ_DOVIZ_ID.Visible = false;

                PivotGridField fieldTOPLAM_ALACAK = new PivotGridField();
                //fieldTOPLAM_ALACAK.AreaIndex = 13;
                fieldTOPLAM_ALACAK.Caption = "Toplam Alacak";
                fieldTOPLAM_ALACAK.FieldName = "TOPLAM_ALACAK";
                fieldTOPLAM_ALACAK.Name = "fieldTOPLAM_ALACAK";
                fieldTOPLAM_ALACAK.Visible = false;

                PivotGridField fieldTOPLAM_ALACAK_DOVIZ_ID = new PivotGridField();
                //fieldTOPLAM_ALACAK_DOVIZ_ID.AreaIndex = 14;
                fieldTOPLAM_ALACAK_DOVIZ_ID.Caption = " ";
                fieldTOPLAM_ALACAK_DOVIZ_ID.FieldName = "TOPLAM_ALACAK_DOVIZ_ID";
                fieldTOPLAM_ALACAK_DOVIZ_ID.Name = "fieldTOPLAM_ALACAK_DOVIZ_ID";
                fieldTOPLAM_ALACAK_DOVIZ_ID.FieldEdit = rlueDoviz;
                fieldTOPLAM_ALACAK_DOVIZ_ID.Visible = false;

                PivotGridField fieldKALAN_ALACAK = new PivotGridField();
                //fieldKALAN_ALACAK.AreaIndex = 15;
                fieldKALAN_ALACAK.Caption = "Kalan Alacak";
                fieldKALAN_ALACAK.FieldName = "KALAN_ALACAK";
                fieldKALAN_ALACAK.Name = "fieldKALAN_ALACAK";
                fieldKALAN_ALACAK.Visible = false;

                PivotGridField fieldKALAN_ALACAK_DOVIZ_ID = new PivotGridField();
                //fieldKALAN_ALACAK_DOVIZ_ID.AreaIndex = 16;
                fieldKALAN_ALACAK_DOVIZ_ID.Caption = " ";
                fieldKALAN_ALACAK_DOVIZ_ID.FieldName = "KALAN_ALACAK_DOVIZ_ID";
                fieldKALAN_ALACAK_DOVIZ_ID.Name = "fieldKALAN_ALACAK_DOVIZ_ID";
                fieldKALAN_ALACAK_DOVIZ_ID.FieldEdit = rlueDoviz;
                fieldKALAN_ALACAK_DOVIZ_ID.Visible = false;

                PivotGridField fieldDEPARTMANA_INTIKAL_TARIHI = new PivotGridField();
                //fieldDEPARTMANA_INTIKAL_TARIHI.AreaIndex = 17;
                fieldDEPARTMANA_INTIKAL_TARIHI.Caption = "Departmana Ýntikal T.";
                fieldDEPARTMANA_INTIKAL_TARIHI.FieldName = "DEPARTMANA_INTIKAL_TARIHI";
                fieldDEPARTMANA_INTIKAL_TARIHI.Name = "fieldDEPARTMANA_INTIKAL_TARIHI";
                fieldDEPARTMANA_INTIKAL_TARIHI.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateYear;
                fieldDEPARTMANA_INTIKAL_TARIHI.Visible = false;

                PivotGridField fieldSORUMLU = new PivotGridField();
                fieldSORUMLU.Area = PivotArea.RowArea;
                fieldSORUMLU.AreaIndex = 6;
                fieldSORUMLU.Caption = "Sorumlu";
                fieldSORUMLU.FieldName = "SORUMLU";
                fieldSORUMLU.Name = "fieldSORUMLU";

                PivotGridField fieldIZLEYEN = new PivotGridField();
                //fieldIZLEYEN.AreaIndex = 19;
                fieldIZLEYEN.Caption = "Ýzleyen";
                fieldIZLEYEN.FieldName = "IZLEYEN";
                fieldIZLEYEN.Name = "fieldIZLEYEN";
                fieldIZLEYEN.Visible = false;

                PivotGridField fieldDAVA_EDEN_SIFAT = new PivotGridField();
                fieldDAVA_EDEN_SIFAT.Area = PivotArea.FilterArea;
                fieldDAVA_EDEN_SIFAT.AreaIndex = 10;
                fieldDAVA_EDEN_SIFAT.Caption = "Dava Eden Sýfat";
                fieldDAVA_EDEN_SIFAT.FieldName = "DAVA_EDEN_SIFAT";
                fieldDAVA_EDEN_SIFAT.Name = "fieldDAVA_EDEN_SIFAT";

                PivotGridField fieldDAVA_EDEN_TK = new PivotGridField();
                fieldDAVA_EDEN_TK.Area = PivotArea.FilterArea;
                fieldDAVA_EDEN_TK.AreaIndex = 9;
                fieldDAVA_EDEN_TK.Caption = "D.Ed T.K";
                fieldDAVA_EDEN_TK.FieldName = "DAVA_EDEN_TK";
                fieldDAVA_EDEN_TK.Name = "fieldDAVA_EDEN_TK";
                fieldDAVA_EDEN_TK.FieldEdit = rlueTarafKodu;

                PivotGridField fieldDAVA_EDEN = new PivotGridField();
                fieldDAVA_EDEN.Area = PivotArea.FilterArea;
                fieldDAVA_EDEN.AreaIndex = 8;
                fieldDAVA_EDEN.Caption = "Dava Eden";
                fieldDAVA_EDEN.FieldName = "DAVA_EDEN_CARI_ID";
                fieldDAVA_EDEN.FieldEdit = rlueCari;
                fieldDAVA_EDEN.Name = "fieldDAVA_EDEN";

                PivotGridField fieldDAVA_EDILEN_SIFAT = new PivotGridField();
                fieldDAVA_EDILEN_SIFAT.Area = PivotArea.FilterArea;
                fieldDAVA_EDILEN_SIFAT.AreaIndex = 7;
                fieldDAVA_EDILEN_SIFAT.Caption = "Dava Edilen Sýfat";
                fieldDAVA_EDILEN_SIFAT.FieldName = "DAVA_EDILEN_SIFAT";
                fieldDAVA_EDILEN_SIFAT.Name = "fieldDAVA_EDILEN_SIFAT";

                PivotGridField fieldDAVA_EDILEN_TK = new PivotGridField();
                fieldDAVA_EDILEN_TK.Area = PivotArea.FilterArea;
                fieldDAVA_EDILEN_TK.AreaIndex = 6;
                fieldDAVA_EDILEN_TK.Caption = "D.Edl T.K";
                fieldDAVA_EDILEN_TK.FieldName = "DAVA_EDILEN_TK";
                fieldDAVA_EDILEN_TK.Name = "fieldDAVA_EDILEN_TK";
                fieldDAVA_EDILEN_TK.FieldEdit = rlueTarafKodu;

                PivotGridField fieldDAVA_EDILEN = new PivotGridField();
                fieldDAVA_EDILEN.Area = PivotArea.FilterArea;
                fieldDAVA_EDILEN.AreaIndex = 5;
                fieldDAVA_EDILEN.Caption = "Dava Edilen";
                fieldDAVA_EDILEN.FieldName = "DAVA_EDILEN_CARI_ID";
                fieldDAVA_EDILEN.FieldEdit = rlueCari;
                fieldDAVA_EDILEN.Name = "fieldDAVA_EDILEN";

                //fieldREFERANS_NO,
                //fieldREFERANS_NO2,
                //fieldREFERANS_NO3,

                PivotGridField fieldDURUSMA_TARIHI = new PivotGridField();
                //fieldDURUSMA_TARIHI.AreaIndex = 26;
                fieldDURUSMA_TARIHI.Caption = "Duruþma T.";
                fieldDURUSMA_TARIHI.FieldName = "DURUSMA_TARIHI";
                fieldDURUSMA_TARIHI.Name = "fieldDURUSMA_TARIHI";
                fieldDURUSMA_TARIHI.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateYear;
                fieldDURUSMA_TARIHI.Visible = false;

                PivotGridField fieldKESIF_TARIHI = new PivotGridField();
                //fieldKESIF_TARIHI.AreaIndex = 27;
                fieldKESIF_TARIHI.Caption = "Keþif T.";
                fieldKESIF_TARIHI.FieldName = "KESIF_TARIHI";
                fieldKESIF_TARIHI.Name = "fieldKESIF_TARIHI";
                fieldKESIF_TARIHI.Visible = false;

                PivotGridField fieldGASAMA_KONU = new PivotGridField();
                //fieldGASAMA_KONU.AreaIndex = 28;
                fieldGASAMA_KONU.Caption = "Aþama Konu";
                fieldGASAMA_KONU.FieldName = "GASAMA_KONU";
                fieldGASAMA_KONU.Name = "fieldGASAMA_KONU";

                PivotGridField fieldGASAMA_ADI = new PivotGridField();
                fieldGASAMA_ADI.Area = PivotArea.FilterArea;
                fieldGASAMA_ADI.AreaIndex = 7;
                fieldGASAMA_ADI.Caption = "Aþama";
                fieldGASAMA_ADI.FieldName = "GASAMA_ADI";
                fieldGASAMA_ADI.Name = "fieldGASAMA_ADI";
                fieldGASAMA_ADI.FieldEdit = rlueAsama;

                PivotGridField fieldADLI_BIRIM_ADLIYE = new PivotGridField();
                fieldADLI_BIRIM_ADLIYE.Area = PivotArea.RowArea;
                fieldADLI_BIRIM_ADLIYE.AreaIndex = 2;
                fieldADLI_BIRIM_ADLIYE.Caption = "Mahkeme";
                fieldADLI_BIRIM_ADLIYE.FieldName = "ADLI_BIRIM_ADLIYE";
                fieldADLI_BIRIM_ADLIYE.Name = "fieldADLI_BIRIM_ADLIYE";

                PivotGridField fieldADLI_BIRIM_GOREV = new PivotGridField();
                fieldADLI_BIRIM_GOREV.Area = PivotArea.RowArea;
                fieldADLI_BIRIM_GOREV.AreaIndex = 3;
                fieldADLI_BIRIM_GOREV.Caption = "Görev";
                fieldADLI_BIRIM_GOREV.FieldName = "ADLI_BIRIM_GOREV";
                fieldADLI_BIRIM_GOREV.Name = "fieldADLI_BIRIM_GOREV";

                PivotGridField fieldADLI_BIRIM_NO = new PivotGridField();
                //fieldADLI_BIRIM_NO.AreaIndex = 32;
                fieldADLI_BIRIM_NO.Caption = "No";
                fieldADLI_BIRIM_NO.FieldName = "ADLI_BIRIM_NO";
                fieldADLI_BIRIM_NO.Name = "fieldADLI_BIRIM_NO";
                fieldADLI_BIRIM_NO.Visible = false;

                PivotGridField fieldGOZEL_KOD1 = new PivotGridField();
                fieldGOZEL_KOD1.Area = PivotArea.FilterArea;
                fieldGOZEL_KOD1.AreaIndex = 0;
                fieldGOZEL_KOD1.Caption = Kimlikci.Kimlik.DavaOzelKod.OzelKod1;
                fieldGOZEL_KOD1.FieldName = "GOZEL_KOD1";
                fieldGOZEL_KOD1.Name = "fieldGOZEL_KOD1";

                PivotGridField fieldGOZEL_KOD2 = new PivotGridField();
                fieldGOZEL_KOD2.Area = PivotArea.FilterArea;
                fieldGOZEL_KOD2.AreaIndex = 1;
                fieldGOZEL_KOD2.Caption = Kimlikci.Kimlik.DavaOzelKod.OzelKod2;
                fieldGOZEL_KOD2.FieldName = "GOZEL_KOD2";
                fieldGOZEL_KOD2.Name = "fieldGOZEL_KOD2";

                PivotGridField fieldGOZEL_KOD3 = new PivotGridField();
                fieldGOZEL_KOD3.Area = PivotArea.FilterArea;
                fieldGOZEL_KOD3.AreaIndex = 2;
                fieldGOZEL_KOD3.Caption = Kimlikci.Kimlik.DavaOzelKod.OzelKod3;
                fieldGOZEL_KOD3.FieldName = "GOZEL_KOD3";
                fieldGOZEL_KOD3.Name = "fieldGOZEL_KOD3";

                PivotGridField fieldGOZEL_KOD4 = new PivotGridField();
                fieldGOZEL_KOD4.Area = PivotArea.FilterArea;
                fieldGOZEL_KOD4.AreaIndex = 3;
                fieldGOZEL_KOD4.Caption = Kimlikci.Kimlik.DavaOzelKod.OzelKod4;
                fieldGOZEL_KOD4.FieldName = "GOZEL_KOD4";
                fieldGOZEL_KOD4.Name = "fieldGOZEL_KOD4";

                PivotGridField fieldGDAVA_TALEP = new PivotGridField();
                fieldGDAVA_TALEP.Area = PivotArea.RowArea;
                fieldGDAVA_TALEP.AreaIndex = 4;
                fieldGDAVA_TALEP.Caption = "Dava Talep";
                fieldGDAVA_TALEP.FieldName = "GDAVA_TALEP";
                fieldGDAVA_TALEP.Name = "fieldGDAVA_TALEP";

                PivotGridField fieldGDAVA_TIP = new PivotGridField();
                fieldGDAVA_TIP.Area = PivotArea.RowArea;
                fieldGDAVA_TIP.AreaIndex = 5;
                fieldGDAVA_TIP.Caption = "Dava Tip";
                fieldGDAVA_TIP.FieldName = "GDAVA_TIP";
                fieldGDAVA_TIP.Name = "fieldGDAVA_TIP";

                PivotGridField fieldKULLANICI = new PivotGridField();
                //fieldKULLANICI.AreaIndex = 39;
                fieldKULLANICI.Caption = "Kullanýcý";
                fieldKULLANICI.FieldName = "KULLANICI";
                fieldKULLANICI.Name = "fieldKULLANICI";
                fieldKULLANICI.Visible = false;

                PivotGridField fieldBURO = new PivotGridField();
                //fieldBURO.AreaIndex = 40;
                fieldBURO.Caption = "Büro";
                fieldBURO.FieldName = "BURO";
                fieldBURO.Name = "fieldBURO";
                fieldBURO.Visible = false;

                PivotGridField fieldBOLUM = new PivotGridField();
                //fieldBOLUM.AreaIndex = 41;
                fieldBOLUM.Caption = "Bölüm";
                fieldBOLUM.FieldName = "BOLUM";
                fieldBOLUM.Name = "fieldBOLUM";
                fieldBOLUM.Visible = false;

                #endregion

                #region []

                PivotGridField[] dizi = new[]
                        {
                            fieldID,                    
                            fieldFOY_DURUM_ID,
                            fieldDAVA_TARIHI,
                            fieldAVUKATA_INTIKAL_TARIHI,
                            fieldKAYIT_TARIHI,
                            fieldDAVA_DEGERI,
                            fieldDAVA_DEGERI_DOVIZ_ID,
                            fieldCezaiSartToplami,
                            fieldCezaiSartToplamiDovizId,
                            fieldISLEMIS_FAIZ,
                            fieldISLEMIS_FAIZ_DOVIZ_ID,
                            fieldDAVA_ONCESI_TOPLAM_DOVIZ_ID,
                            fieldSONRAKI_FAIZ,
                            fieldSONRAKI_FAIZ_DOVIZ_ID,
                            fieldTOPLAM_ALACAK,
                            fieldTOPLAM_ALACAK_DOVIZ_ID,
                            fieldKALAN_ALACAK,
                            fieldKALAN_ALACAK_DOVIZ_ID,
                            fieldDEPARTMANA_INTIKAL_TARIHI,
                            fieldSORUMLU,
                            fieldIZLEYEN,
                            fieldDAVA_EDEN_SIFAT,
                            fieldDAVA_EDEN_TK,
                            fieldDAVA_EDEN,
                            fieldDAVA_EDILEN_SIFAT,
                            fieldDAVA_EDILEN_TK,
                            fieldDAVA_EDILEN,
                            fieldDURUSMA_TARIHI,
                            fieldKESIF_TARIHI,
                            fieldGASAMA_KONU,
                            fieldGASAMA_ADI,
                            fieldADLI_BIRIM_ADLIYE,
                            fieldADLI_BIRIM_GOREV,
                            fieldADLI_BIRIM_NO,
                            fieldGOZEL_KOD1,
                            fieldGOZEL_KOD2,
                            fieldGOZEL_KOD3,
                            fieldGOZEL_KOD4,
                            fieldGDAVA_TALEP,
                            fieldGDAVA_TIP,
                            fieldKULLANICI,
                            fieldBURO,
                            fieldBOLUM,
                            fieldDAVA_ONCESI_ODEME_TOPLAM
                    };

                #endregion

                return dizi;
            }
        }

        public class IcraFoy
        {
            #region Repository Items

            private RepositoryItemLookUpEdit rlueDoviz = new RepositoryItemLookUpEdit();
            private RepositoryItemLookUpEdit rlueFoyDurum = new RepositoryItemLookUpEdit();
            private RepositoryItemLookUpEdit rlueTarafKodu = new RepositoryItemLookUpEdit();
            private RepositoryItemLookUpEdit rlueAsama = new RepositoryItemLookUpEdit();

            #endregion

            public PivotGridField[] GetFields()
            {
                #region Bind Repositories

                BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
                BelgeUtil.Inits.FoyDurumGetir(rlueFoyDurum);
                BelgeUtil.Inits.TarafKoduGetir(rlueTarafKodu);
                BelgeUtil.Inits.AsamaKodGetir(rlueAsama);

                #endregion

                #region fields & properties

                PivotGridField fieldID = new PivotGridField();
                fieldID.Area = PivotArea.DataArea;
                fieldID.AreaIndex = 1;
                fieldID.Caption = "Dosya Sayýsý";
                fieldID.FieldName = "ID";
                fieldID.Name = "fieldID";
                fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;

                PivotGridField fieldTAKIP_EDEN_SIFAT = new PivotGridField();
                fieldTAKIP_EDEN_SIFAT.Area = PivotArea.FilterArea;
                fieldTAKIP_EDEN_SIFAT.AreaIndex = 4;
                fieldTAKIP_EDEN_SIFAT.Caption = "Takip Eden Sýfat";
                fieldTAKIP_EDEN_SIFAT.FieldName = "TAKIP_EDEN_SIFAT";
                fieldTAKIP_EDEN_SIFAT.Name = "fieldTAKIP_EDEN_SIFAT";

                PivotGridField fieldTAKIP_EDEN_TK = new PivotGridField();
                fieldTAKIP_EDEN_TK.Area = PivotArea.FilterArea;
                fieldTAKIP_EDEN_TK.AreaIndex = 5;
                fieldTAKIP_EDEN_TK.Caption = "T.Ed. T.K";
                fieldTAKIP_EDEN_TK.FieldName = "TAKIP_EDEN_TK";
                fieldTAKIP_EDEN_TK.Name = "fieldTAKIP_EDEN_TK";
                fieldTAKIP_EDEN_TK.FieldEdit = rlueTarafKodu;

                PivotGridField fieldTAKIP_EDEN = new PivotGridField();
                fieldTAKIP_EDEN.Area = PivotArea.FilterArea;
                fieldTAKIP_EDEN.AreaIndex = 6;
                fieldTAKIP_EDEN.Caption = "Takip Eden";
                fieldTAKIP_EDEN.FieldName = "TAKIP_EDEN";
                fieldTAKIP_EDEN.Name = "fieldTAKIP_EDEN";

                PivotGridField fieldTAKIP_EDILEN_SIFAT = new PivotGridField();
                fieldTAKIP_EDILEN_SIFAT.Area = PivotArea.FilterArea;
                fieldTAKIP_EDILEN_SIFAT.AreaIndex = 7;
                fieldTAKIP_EDILEN_SIFAT.Caption = "Takip Edilen Sýfat";
                fieldTAKIP_EDILEN_SIFAT.FieldName = "TAKIP_EDILEN_SIFAT";
                fieldTAKIP_EDILEN_SIFAT.Name = "fieldTAKIP_EDILEN_SIFAT";

                PivotGridField fieldTAKIP_EDILEN_TK = new PivotGridField();
                fieldTAKIP_EDILEN_TK.Area = PivotArea.FilterArea;
                fieldTAKIP_EDILEN_TK.AreaIndex = 8;
                fieldTAKIP_EDILEN_TK.Caption = "T.Edl T.K";
                fieldTAKIP_EDILEN_TK.FieldName = "TAKIP_EDILEN_TK";
                fieldTAKIP_EDILEN_TK.Name = "fieldTAKIP_EDILEN_TK";
                fieldTAKIP_EDILEN_TK.FieldEdit = rlueTarafKodu;

                PivotGridField fieldTAKIP_EDILEN = new PivotGridField();
                fieldTAKIP_EDILEN.Area = PivotArea.FilterArea;
                fieldTAKIP_EDILEN.AreaIndex = 9;
                fieldTAKIP_EDILEN.Caption = "Takip Edilen";
                fieldTAKIP_EDILEN.FieldName = "TAKIP_EDILEN";
                fieldTAKIP_EDILEN.Name = "fieldTAKIP_EDILEN";

                PivotGridField fieldSORUMLU = new PivotGridField();
                fieldSORUMLU.Area = PivotArea.FilterArea;
                fieldSORUMLU.AreaIndex = 10;
                fieldSORUMLU.Caption = "Sorumlu";
                fieldSORUMLU.FieldName = "SORUMLU";
                fieldSORUMLU.Name = "fieldSORUMLU";

                PivotGridField fieldIZLEYEN = new PivotGridField();
                //fieldIZLEYEN.AreaIndex = 19;
                fieldIZLEYEN.Caption = "Ýzleyen";
                fieldIZLEYEN.FieldName = "IZLEYEN";
                fieldIZLEYEN.Name = "fieldIZLEYEN";
                fieldIZLEYEN.Visible = false;

                PivotGridField fieldGDURUM = new PivotGridField();
                fieldGDURUM.Area = PivotArea.RowArea;
                fieldGDURUM.AreaIndex = 0;
                fieldGDURUM.Caption = "Durum";
                fieldGDURUM.FieldName = "GDURUM";
                fieldGDURUM.Name = "fieldGDURUM";

                PivotGridField fieldTAKIP_TARIHI = new PivotGridField();
                fieldTAKIP_TARIHI.Area = PivotArea.RowArea;
                fieldTAKIP_TARIHI.AreaIndex = 1;
                fieldTAKIP_TARIHI.Caption = "Takip T.";
                fieldTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
                fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
                fieldTAKIP_TARIHI.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateYear;

                PivotGridField fieldADLI_BIRIM_ADLIYE = new PivotGridField();
                fieldADLI_BIRIM_ADLIYE.Area = PivotArea.RowArea;
                fieldADLI_BIRIM_ADLIYE.AreaIndex = 4;
                fieldADLI_BIRIM_ADLIYE.Caption = "Müdürlük";
                fieldADLI_BIRIM_ADLIYE.FieldName = "ADLI_BIRIM_ADLIYE";
                fieldADLI_BIRIM_ADLIYE.Name = "fieldADLI_BIRIM_ADLIYE";

                PivotGridField fieldADLI_BIRIM_GOREV = new PivotGridField();
                fieldADLI_BIRIM_GOREV.Caption = "Görev";
                fieldADLI_BIRIM_GOREV.FieldName = "ADLI_BIRIM_GOREV";
                fieldADLI_BIRIM_GOREV.Name = "fieldADLI_BIRIM_GOREV";
                fieldADLI_BIRIM_GOREV.Visible = false;

                PivotGridField fieldADLI_BIRIM_NO = new PivotGridField();
                //fieldADLI_BIRIM_NO.AreaIndex = 32;
                fieldADLI_BIRIM_NO.Caption = "No";
                fieldADLI_BIRIM_NO.FieldName = "ADLI_BIRIM_NO";
                fieldADLI_BIRIM_NO.Name = "fieldADLI_BIRIM_NO";
                fieldADLI_BIRIM_NO.Visible = false;

                PivotGridField fieldGOZEL_KOD1 = new PivotGridField();
                fieldGOZEL_KOD1.Area = PivotArea.FilterArea;
                fieldGOZEL_KOD1.AreaIndex = 0;
                fieldGOZEL_KOD1.Caption = Kimlikci.Kimlik.IcraOzelKod.OzelKod1;
                fieldGOZEL_KOD1.FieldName = "GOZEL_KOD1";
                fieldGOZEL_KOD1.Name = "fieldGOZEL_KOD1";

                PivotGridField fieldGOZEL_KOD2 = new PivotGridField();
                fieldGOZEL_KOD2.Area = PivotArea.FilterArea;
                fieldGOZEL_KOD2.AreaIndex = 1;
                fieldGOZEL_KOD2.Caption = Kimlikci.Kimlik.IcraOzelKod.OzelKod2;
                fieldGOZEL_KOD2.FieldName = "GOZEL_KOD2";
                fieldGOZEL_KOD2.Name = "fieldGOZEL_KOD2";

                PivotGridField fieldGOZEL_KOD3 = new PivotGridField();
                fieldGOZEL_KOD3.Area = PivotArea.FilterArea;
                fieldGOZEL_KOD3.AreaIndex = 2;
                fieldGOZEL_KOD3.Caption = Kimlikci.Kimlik.IcraOzelKod.OzelKod3;
                fieldGOZEL_KOD3.FieldName = "GOZEL_KOD3";
                fieldGOZEL_KOD3.Name = "fieldGOZEL_KOD3";

                PivotGridField fieldGOZEL_KOD4 = new PivotGridField();
                fieldGOZEL_KOD4.Area = PivotArea.FilterArea;
                fieldGOZEL_KOD4.AreaIndex = 3;
                fieldGOZEL_KOD4.Caption = Kimlikci.Kimlik.IcraOzelKod.OzelKod4;
                fieldGOZEL_KOD4.FieldName = "GOZEL_KOD4";
                fieldGOZEL_KOD4.Name = "fieldGOZEL_KOD4";

                PivotGridField fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI = new PivotGridField();
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.AreaIndex = 11;
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Area = PivotArea.FilterArea;
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Caption = "Ýntikal T.";
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.FieldName = "TAKIBIN_AVUKATA_INTIKAL_TARIHI";
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.Name = "fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI";
                fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateYear;

                PivotGridField fieldASIL_ALACAK = new PivotGridField();
                fieldASIL_ALACAK.Area = PivotArea.DataArea;
                fieldASIL_ALACAK.AreaIndex = 1;
                fieldASIL_ALACAK.Caption = "Asýl Alacak";
                fieldASIL_ALACAK.FieldName = "ASIL_ALACAK";
                fieldASIL_ALACAK.Name = "fieldASIL_ALACAKI";

                PivotGridField fieldASIL_ALACAK_DOVIZ_ID = new PivotGridField();
                //fieldDAVA_DEGERI_DOVIZ_ID.AreaIndex = 5;
                fieldASIL_ALACAK_DOVIZ_ID.Caption = " ";
                fieldASIL_ALACAK_DOVIZ_ID.FieldName = "ASIL_ALACAK_DOVIZ_ID";
                fieldASIL_ALACAK_DOVIZ_ID.Name = "fieldASIL_ALACAK_DOVIZ_ID";
                fieldASIL_ALACAK_DOVIZ_ID.FieldEdit = rlueDoviz;
                fieldASIL_ALACAK_DOVIZ_ID.Visible = false;

                PivotGridField fieldISLEMIS_FAIZ = new PivotGridField();
                //fieldISLEMIS_FAIZ.AreaIndex = 8;
                fieldISLEMIS_FAIZ.Caption = "Ýþlemiþ Faiz";
                fieldISLEMIS_FAIZ.FieldName = "ISLEMIS_FAIZ";
                fieldISLEMIS_FAIZ.Name = "fieldISLEMIS_FAIZ";
                fieldISLEMIS_FAIZ.Visible = false;

                PivotGridField fieldISLEMIS_FAIZ_DOVIZ_ID = new PivotGridField();
                //fieldISLEMIS_FAIZ_DOVIZ_ID.AreaIndex = 9;
                fieldISLEMIS_FAIZ_DOVIZ_ID.Caption = " ";
                fieldISLEMIS_FAIZ_DOVIZ_ID.FieldName = "ISLEMIS_FAIZ_DOVIZ_ID";
                fieldISLEMIS_FAIZ_DOVIZ_ID.Name = "fieldISLEMIS_FAIZ_DOVIZ_ID";
                fieldISLEMIS_FAIZ_DOVIZ_ID.FieldEdit = rlueDoviz;
                fieldISLEMIS_FAIZ_DOVIZ_ID.Visible = false;

                PivotGridField fieldTAKIP_CIKISI = new PivotGridField();
                fieldTAKIP_CIKISI.Area = PivotArea.DataArea;
                fieldTAKIP_CIKISI.AreaIndex = 3;
                fieldTAKIP_CIKISI.Caption = "Takip Çýkýþý";
                fieldTAKIP_CIKISI.FieldName = "TAKIP_CIKISI";
                fieldTAKIP_CIKISI.Name = "fieldTAKIP_CIKISI";

                PivotGridField fieldTAKIP_CIKISI_DOVIZ_ID = new PivotGridField();
                //fieldDAVA_DEGERI_DOVIZ_ID.AreaIndex = 5;
                fieldTAKIP_CIKISI_DOVIZ_ID.Caption = " ";
                fieldTAKIP_CIKISI_DOVIZ_ID.FieldName = "TAKIP_CIKISI_DOVIZ_I";
                fieldTAKIP_CIKISI_DOVIZ_ID.Name = "fieldTAKIP_CIKISI_DOVIZ_ID";
                fieldTAKIP_CIKISI_DOVIZ_ID.FieldEdit = rlueDoviz;
                fieldTAKIP_CIKISI_DOVIZ_ID.Visible = false;

                PivotGridField fieldSONRAKI_FAIZ = new PivotGridField();
                //fieldSONRAKI_FAIZ.AreaIndex = 11;
                fieldSONRAKI_FAIZ.Caption = "Sonraki Faiz";
                fieldSONRAKI_FAIZ.FieldName = "SONRAKI_FAIZ";
                fieldSONRAKI_FAIZ.Name = "fieldSONRAKI_FAIZ";
                fieldSONRAKI_FAIZ.Visible = false;

                PivotGridField fieldSONRAKI_FAIZ_DOVIZ_ID = new PivotGridField();
                //fieldSONRAKI_FAIZ_DOVIZ_ID.AreaIndex = 12;
                fieldSONRAKI_FAIZ_DOVIZ_ID.Caption = " ";
                fieldSONRAKI_FAIZ_DOVIZ_ID.FieldName = "SONRAKI_FAIZ_DOVIZ_ID";
                fieldSONRAKI_FAIZ_DOVIZ_ID.Name = "fieldSONRAKI_FAIZ_DOVIZ_ID";
                fieldSONRAKI_FAIZ_DOVIZ_ID.FieldEdit = rlueDoviz;
                fieldSONRAKI_FAIZ_DOVIZ_ID.Visible = false;

                PivotGridField fieldODEME_TOPLAMI = new PivotGridField();
                fieldODEME_TOPLAMI.AreaIndex = 4;
                fieldODEME_TOPLAMI.Area = PivotArea.DataArea;
                fieldODEME_TOPLAMI.Caption = "Ödeme Toplamý";
                fieldODEME_TOPLAMI.FieldName = "ODEME_TOPLAMI";
                fieldODEME_TOPLAMI.Name = "fieldODEME_TOPLAMI";

                PivotGridField fieldODEME_TOPLAMI_DOVIZ_ID = new PivotGridField();
                //fieldSONRAKI_FAIZ_DOVIZ_ID.AreaIndex = 12;
                fieldODEME_TOPLAMI_DOVIZ_ID.Caption = " ";
                fieldODEME_TOPLAMI_DOVIZ_ID.FieldName = "ODEME_TOPLAMI_DOVIZ_ID";
                fieldODEME_TOPLAMI_DOVIZ_ID.Name = "fieldODEME_TOPLAMI_DOVIZ_ID";
                fieldODEME_TOPLAMI_DOVIZ_ID.FieldEdit = rlueDoviz;
                fieldODEME_TOPLAMI_DOVIZ_ID.Visible = false;

                PivotGridField fieldTO_ODEME_TOPLAMI = new PivotGridField();
                //fieldSONRAKI_FAIZ.AreaIndex = 11;
                fieldTO_ODEME_TOPLAMI.Caption = "T.Ö Ödeme T.";
                fieldTO_ODEME_TOPLAMI.FieldName = "TO_ODEME_TOPLAMI";
                fieldTO_ODEME_TOPLAMI.Name = "fieldTO_ODEME_TOPLAMI";
                fieldTO_ODEME_TOPLAMI.Visible = false;

                PivotGridField fieldTO_ODEME_TOPLAMI_DOVIZ_ID = new PivotGridField();
                //fieldSONRAKI_FAIZ_DOVIZ_ID.AreaIndex = 12;
                fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Caption = " ";
                fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
                fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Name = "fieldTO_ODEME_TOPLAMI_DOVIZ_ID";
                fieldTO_ODEME_TOPLAMI_DOVIZ_ID.FieldEdit = rlueDoviz;
                fieldTO_ODEME_TOPLAMI_DOVIZ_ID.Visible = false;

                PivotGridField fieldKALAN = new PivotGridField();
                fieldKALAN.AreaIndex = 5;
                fieldKALAN.Area = PivotArea.DataArea;
                fieldKALAN.Caption = "Kalan";
                fieldKALAN.FieldName = "KALAN";
                fieldKALAN.Name = "fieldKALAN";

                PivotGridField fieldKALAN_DOVIZ_ID = new PivotGridField();
                //fieldKALAN_DOVIZ_ID.AreaIndex = 16;
                fieldKALAN_DOVIZ_ID.Caption = " ";
                fieldKALAN_DOVIZ_ID.FieldName = "KALAN_DOVIZ_ID";
                fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
                fieldKALAN_DOVIZ_ID.FieldEdit = rlueDoviz;
                fieldKALAN_DOVIZ_ID.Visible = false;

                PivotGridField fieldKAPAMA_TARIHI = new PivotGridField();
                fieldKAPAMA_TARIHI.AreaIndex = 2;
                fieldKAPAMA_TARIHI.Area = PivotArea.RowArea;
                fieldKAPAMA_TARIHI.Caption = "Kapama T.";
                fieldKAPAMA_TARIHI.FieldName = "KAPAMA_TARIHI";
                fieldKAPAMA_TARIHI.Name = "fieldKAPAMA_TARIHI";
                fieldKAPAMA_TARIHI.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateYear;

                PivotGridField fieldBURO = new PivotGridField();
                //fieldBURO.AreaIndex = 40;
                fieldBURO.Caption = "Büro";
                fieldBURO.FieldName = "BURO";
                fieldBURO.Name = "fieldBURO";
                fieldBURO.Visible = false;

                PivotGridField fieldBOLUM = new PivotGridField();
                //fieldBOLUM.AreaIndex = 41;
                fieldBOLUM.Caption = "Bölüm";
                fieldBOLUM.FieldName = "BOLUM";
                fieldBOLUM.Name = "fieldBOLUM";
                fieldBOLUM.Visible = false;

                PivotGridField fieldTAKIP_TALEP = new PivotGridField();
                fieldTAKIP_TALEP.AreaIndex = 3;
                fieldTAKIP_TALEP.Area = PivotArea.RowArea;
                fieldTAKIP_TALEP.Caption = "Takip Talep";
                fieldTAKIP_TALEP.FieldName = "GTAKIP_TALEP";
                fieldTAKIP_TALEP.Name = "fieldTAKIP_TALEP";

                PivotGridField fieldFORM_ORNEK_NO = new PivotGridField();
                //fieldBOLUM.AreaIndex = 41;
                fieldFORM_ORNEK_NO.Caption = "Form Tipi";
                fieldFORM_ORNEK_NO.FieldName = "FORM_ADI";
                fieldFORM_ORNEK_NO.Name = "fieldFORM_ORNEK_NO";
                fieldFORM_ORNEK_NO.Visible = false;

                PivotGridField fieldRISK_MIKTARI = new PivotGridField();
                fieldRISK_MIKTARI.AreaIndex = 2;
                fieldRISK_MIKTARI.Area = PivotArea.DataArea;
                fieldRISK_MIKTARI.Caption = "Risk Miktarý";
                fieldRISK_MIKTARI.FieldName = "RISK_MIKTARI";
                fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";

                PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new PivotGridField();
                //fieldKALAN_ALACAK_DOVIZ_ID.AreaIndex = 16;
                fieldRISK_MIKTARI_DOVIZ_ID.Caption = " ";
                fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RISK_MIKTARI_DOVIZ_ID";
                fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
                fieldRISK_MIKTARI_DOVIZ_ID.FieldEdit = rlueDoviz;
                fieldRISK_MIKTARI_DOVIZ_ID.Visible = false;

                PivotGridField fieldASAMA_ID = new PivotGridField();
                fieldASAMA_ID.Caption = "Aþama";
                fieldASAMA_ID.FieldName = "ASAMA_ID";
                fieldASAMA_ID.Name = "fieldASAMA_ID";
                fieldASAMA_ID.FieldEdit = rlueAsama;
                fieldASAMA_ID.Visible = false;

                PivotGridField fieldDEPARTMANA_INTIKAL_TARIHI = new PivotGridField();
                //fieldDEPARTMANA_INTIKAL_TARIHI.AreaIndex = 17;
                fieldDEPARTMANA_INTIKAL_TARIHI.Caption = "Departmana Ýntikal T.";
                fieldDEPARTMANA_INTIKAL_TARIHI.FieldName = "DEPARTMANA_INTIKAL_TARIHI";
                fieldDEPARTMANA_INTIKAL_TARIHI.Name = "fieldDEPARTMANA_INTIKAL_TARIHI";
                fieldDEPARTMANA_INTIKAL_TARIHI.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateYear;
                fieldDEPARTMANA_INTIKAL_TARIHI.Visible = false;

                #endregion

                #region []

                PivotGridField[] dizi = new[]
                        {
                            fieldID,
                            fieldTAKIP_EDEN_SIFAT,        
                            fieldTAKIP_EDEN_TK,
                            fieldTAKIP_EDEN,
                            fieldTAKIP_EDILEN_SIFAT,
                            fieldTAKIP_EDILEN_TK,
                            fieldTAKIP_EDILEN,
                            fieldSORUMLU,
                            fieldIZLEYEN,
                            fieldGDURUM,
                            fieldTAKIP_TARIHI,
                            fieldADLI_BIRIM_ADLIYE,
                            fieldADLI_BIRIM_GOREV,
                            fieldADLI_BIRIM_NO,
                            fieldGOZEL_KOD1,
                            fieldGOZEL_KOD2,
                            fieldGOZEL_KOD3,
                            fieldGOZEL_KOD4,
                            fieldTAKIBIN_AVUKATA_INTIKAL_TARIHI,
                            fieldASIL_ALACAK,
                            fieldASIL_ALACAK_DOVIZ_ID,
                            fieldISLEMIS_FAIZ,
                            fieldISLEMIS_FAIZ_DOVIZ_ID,
                            fieldTAKIP_CIKISI,
                            fieldTAKIP_CIKISI_DOVIZ_ID,
                            fieldSONRAKI_FAIZ,
                            fieldSONRAKI_FAIZ_DOVIZ_ID,
                            fieldODEME_TOPLAMI,
                            fieldODEME_TOPLAMI_DOVIZ_ID,
                            fieldTO_ODEME_TOPLAMI,
                            fieldTO_ODEME_TOPLAMI_DOVIZ_ID,
                            fieldKALAN,
                            fieldKALAN_DOVIZ_ID,
                            fieldKAPAMA_TARIHI,
                            fieldBURO,
                            fieldBOLUM,
                            fieldTAKIP_TALEP,
                            fieldFORM_ORNEK_NO,
                            fieldRISK_MIKTARI,
                            fieldRISK_MIKTARI_DOVIZ_ID,
                            fieldASAMA_ID,
                            fieldDEPARTMANA_INTIKAL_TARIHI
                        };
                #endregion

                return dizi;
            }
        }

        public class Durusma
        {
            #region Repository Items

            private RepositoryItemLookUpEdit rLueCariID = new RepositoryItemLookUpEdit();
            private RepositoryItemLookUpEdit rLueAdliBirimAdliye = new RepositoryItemLookUpEdit();
            private RepositoryItemLookUpEdit rLueAdliBirimNo = new RepositoryItemLookUpEdit();
            private RepositoryItemLookUpEdit rLueAdliBirimGorev = new RepositoryItemLookUpEdit();
            private RepositoryItemLookUpEdit rLueIncelemeTur = new RepositoryItemLookUpEdit();
            //private RepositoryItemDateEdit rlueTarih = new RepositoryItemDateEdit();
            //private RepositoryItemTimeEdit rlueSaati = new RepositoryItemTimeEdit();

            #endregion

            public PivotGridField[] GetFields()
            {
                #region Bind Repositories

                BelgeUtil.Inits.perCariGetir(rLueCariID);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
                BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNo);
                BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
                BelgeUtil.Inits.IncelemeTurGetir(rLueIncelemeTur);
                //rlueTarih.DisplayFormat.FormatString = "{0:dd.MM.yyyy}";
                //rlueSaati.DisplayFormat.FormatString = "{0: HH:mm}";

                #endregion

                #region fields & properties

                PivotGridField fieldID = new PivotGridField();
                fieldID.Area = PivotArea.DataArea;
                fieldID.AreaIndex = 0;
                fieldID.Caption = "Dosya Sayýsý";
                fieldID.FieldName = "ID";
                fieldID.Name = "fieldID";
                fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;

                PivotGridField fieldDavaESAS_NO = new PivotGridField();
                fieldDavaESAS_NO.Caption = "Esas No";
                fieldDavaESAS_NO.FieldName = "DavaESAS_NO";
                fieldDavaESAS_NO.Name = "fieldDavaESAS_NO";
                fieldDavaESAS_NO.Area = PivotArea.FilterArea;
                fieldDavaESAS_NO.AreaIndex = 0;

                PivotGridField fieldDavaFOY_NO = new PivotGridField();
                fieldDavaFOY_NO.Caption = "Dosya No";
                fieldDavaFOY_NO.FieldName = "DavaFOY_NO";
                fieldDavaFOY_NO.Name = "fieldDavaFOY_NO";
                fieldDavaFOY_NO.Area = PivotArea.FilterArea;
                fieldDavaFOY_NO.AreaIndex = 1;

                PivotGridField fieldDavaADLI_BIRIM_ADLIYE_ID = new PivotGridField();
                fieldDavaADLI_BIRIM_ADLIYE_ID.Caption = "Adliye";
                fieldDavaADLI_BIRIM_ADLIYE_ID.FieldName = "DavaADLI_BIRIM_ADLIYE_ID";
                fieldDavaADLI_BIRIM_ADLIYE_ID.Name = "fieldDavaADLI_BIRIM_ADLIYE_ID";
                fieldDavaADLI_BIRIM_ADLIYE_ID.FieldEdit = rLueAdliBirimAdliye;
                fieldDavaADLI_BIRIM_ADLIYE_ID.Area = PivotArea.RowArea;
                fieldDavaADLI_BIRIM_ADLIYE_ID.AreaIndex = 0;

                PivotGridField fieldDavaADLI_BIRIM_NO_ID = new PivotGridField();
                fieldDavaADLI_BIRIM_NO_ID.Caption = "No";
                fieldDavaADLI_BIRIM_NO_ID.FieldName = "DavaADLI_BIRIM_NO_ID";
                fieldDavaADLI_BIRIM_NO_ID.Name = " fieldDavaADLI_BIRIM_NO_ID";
                fieldDavaADLI_BIRIM_NO_ID.FieldEdit = rLueAdliBirimNo;
                fieldDavaADLI_BIRIM_NO_ID.Area = PivotArea.RowArea;
                fieldDavaADLI_BIRIM_NO_ID.AreaIndex = 1;

                PivotGridField fieldDavaADLI_BIRIM_GOREV_ID = new PivotGridField();
                fieldDavaADLI_BIRIM_GOREV_ID.Caption = "Görev";
                fieldDavaADLI_BIRIM_GOREV_ID.FieldName = "DavaADLI_BIRIM_GOREV_ID";
                fieldDavaADLI_BIRIM_GOREV_ID.Name = "fieldDavaADLI_BIRIM_GOREV_ID";
                fieldDavaADLI_BIRIM_GOREV_ID.FieldEdit = rLueAdliBirimGorev;
                fieldDavaADLI_BIRIM_GOREV_ID.Area = PivotArea.RowArea;
                fieldDavaADLI_BIRIM_GOREV_ID.AreaIndex = 2;

                PivotGridField fieldDavaDAVA_TARIHI = new PivotGridField();
                fieldDavaDAVA_TARIHI.Caption = "Dava T.";
                fieldDavaDAVA_TARIHI.FieldName = "DavaDAVA_TARIHI";
                fieldDavaDAVA_TARIHI.Name = "fieldDavaDAVA_TARIHI";
                //fieldDavaDAVA_TARIHI.FieldEdit = rlueTarih;
                fieldDavaDAVA_TARIHI.Area = PivotArea.FilterArea;
                fieldDavaDAVA_TARIHI.AreaIndex = 3;


                PivotGridField fieldTARIH = new PivotGridField();
                fieldTARIH.Caption = "Duruþma T.";
                fieldTARIH.FieldName = "TARIH";
                fieldTARIH.Name = "fieldTARIH";
                //fieldTARIH.FieldEdit = rlueTarih;
                fieldTARIH.ValueFormat.FormatString = "{0: dd.MM.yyyy}";
                fieldTARIH.Area = PivotArea.RowArea;
                fieldTARIH.AreaIndex = 3;

                //PivotGridField fieldSAATI = new PivotGridField();
                //fieldSAATI.Caption = "Duruþma S.";
                //fieldSAATI.FieldName = "TARIH";
                //fieldSAATI.Name = "fieldSAATI";
                ////fieldSAATI.FieldEdit = rlueSaati;
                //fieldSAATI.ValueFormat.FormatString = "{0: HH:mm}";
                //fieldSAATI.Area = PivotArea.RowArea;
                //fieldSAATI.AreaIndex = 4;

                PivotGridField fieldSORUMLU_AVUKAT_CARI1_ID = new PivotGridField();
                fieldSORUMLU_AVUKAT_CARI1_ID.Caption = "Sorumlu Avukat";
                fieldSORUMLU_AVUKAT_CARI1_ID.FieldName = "SORUMLU_AVUKAT_CARI1_ID";
                fieldSORUMLU_AVUKAT_CARI1_ID.Name = "fieldSORUMLU_AVUKAT_CARI1_ID";
                fieldSORUMLU_AVUKAT_CARI1_ID.FieldEdit = rLueCariID;
                fieldSORUMLU_AVUKAT_CARI1_ID.Area = PivotArea.FilterArea;
                fieldSORUMLU_AVUKAT_CARI1_ID.AreaIndex = 2;

                PivotGridField fieldSORUMLU_AVUKAT_CARI2_ID = new PivotGridField();
                fieldSORUMLU_AVUKAT_CARI2_ID.Caption = "Duruþma Avukatý";
                fieldSORUMLU_AVUKAT_CARI2_ID.FieldName = "SORUMLU_AVUKAT_CARI2_ID";
                fieldSORUMLU_AVUKAT_CARI2_ID.Name = "fieldSORUMLU_AVUKAT_CARI2_ID";
                fieldSORUMLU_AVUKAT_CARI2_ID.FieldEdit = rLueCariID;
                fieldSORUMLU_AVUKAT_CARI2_ID.Area = PivotArea.FilterArea;
                fieldSORUMLU_AVUKAT_CARI2_ID.AreaIndex = 4;

                PivotGridField fieldHAKIM_CARI1_ID = new PivotGridField();
                fieldHAKIM_CARI1_ID.Caption = "Hakim 1";
                fieldHAKIM_CARI1_ID.FieldName = "HAKIM_CARI1_ID";
                fieldHAKIM_CARI1_ID.Name = "fieldHAKIM_CARI1_ID";
                fieldHAKIM_CARI1_ID.FieldEdit = rLueCariID;
                fieldHAKIM_CARI1_ID.Visible = false;

                PivotGridField fieldHAKIM_CARI2_ID = new PivotGridField();
                fieldHAKIM_CARI2_ID.Caption = "Hakim 2";
                fieldHAKIM_CARI2_ID.FieldName = "HAKIM_CARI2_ID";
                fieldHAKIM_CARI2_ID.Name = "fieldHAKIM_CARI2_ID";
                fieldHAKIM_CARI2_ID.FieldEdit = rLueCariID;
                fieldHAKIM_CARI2_ID.Visible = false;

                PivotGridField fieldHAKIM_CARI3_ID = new PivotGridField();
                fieldHAKIM_CARI3_ID.Caption = "Hakim 3";
                fieldHAKIM_CARI3_ID.FieldName = "HAKIM_CARI3_ID";
                fieldHAKIM_CARI3_ID.Name = "fieldHAKIM_CARI3_ID";
                fieldHAKIM_CARI3_ID.FieldEdit = rLueCariID;
                fieldHAKIM_CARI3_ID.Visible = false;

                PivotGridField fieldSAVCI_CARI_ID = new PivotGridField();
                fieldSAVCI_CARI_ID.Caption = "Savcý";
                fieldSAVCI_CARI_ID.FieldName = "SAVCI_CARI_ID";
                fieldSAVCI_CARI_ID.Name = "fieldSAVCI_CARI_ID";
                fieldSAVCI_CARI_ID.FieldEdit = rLueCariID;
                fieldSAVCI_CARI_ID.Visible = false;

                PivotGridField fieldKATIP_CARI_ID = new PivotGridField();
                fieldKATIP_CARI_ID.Caption = "Katip";
                fieldKATIP_CARI_ID.FieldName = "KATIP_CARI_ID";
                fieldKATIP_CARI_ID.Name = "fieldKATIP_CARI_ID";
                fieldKATIP_CARI_ID.FieldEdit = rLueCariID;
                fieldKATIP_CARI_ID.Visible = false;

                PivotGridField fieldMAZERET_VAR_MI = new PivotGridField();
                fieldMAZERET_VAR_MI.Caption = "Mazeret";
                fieldMAZERET_VAR_MI.FieldName = "colMAZERET_VAR_MI";
                fieldMAZERET_VAR_MI.Name = "fieldMAZERET_VAR_MI";
                fieldMAZERET_VAR_MI.Visible = false;

                PivotGridField fieldMURAFA_MI = new PivotGridField();
                fieldMURAFA_MI.Caption = "Murafa";
                fieldMURAFA_MI.FieldName = "MURAFA_MI";
                fieldMURAFA_MI.Name = "fieldMURAFA_MI";
                fieldMURAFA_MI.Area = PivotArea.FilterArea;
                fieldMURAFA_MI.AreaIndex = 7;

                PivotGridField fieldCELSE_MI = new PivotGridField();
                fieldCELSE_MI.Caption = "Duruþma mý";
                fieldCELSE_MI.FieldName = "CELSE_MI";
                fieldCELSE_MI.Name = "fieldCELSE_MI";
                fieldCELSE_MI.Area = PivotArea.FilterArea;
                fieldCELSE_MI.AreaIndex = 4;

                PivotGridField fieldCELSE_HARCI_ALINACAK_MI = new PivotGridField();
                fieldCELSE_HARCI_ALINACAK_MI.Caption = "Celse Harcý";
                fieldCELSE_HARCI_ALINACAK_MI.FieldName = "CELSE_HARCI_ALINACAK_MI";
                fieldCELSE_HARCI_ALINACAK_MI.Name = "fieldCELSE_HARCI_ALINACAK_MI";
                fieldCELSE_HARCI_ALINACAK_MI.Visible = false;

                PivotGridField fieldINCELEME_TUR_ID = new PivotGridField();
                fieldINCELEME_TUR_ID.Caption = "Ýnceleme T.";
                fieldINCELEME_TUR_ID.FieldName = "INCELEME_TUR_ID";
                fieldINCELEME_TUR_ID.Name = "fieldINCELEME_TUR_ID";
                fieldINCELEME_TUR_ID.FieldEdit = rLueIncelemeTur;
                fieldINCELEME_TUR_ID.Area = PivotArea.FilterArea;
                fieldINCELEME_TUR_ID.AreaIndex = 5;

                PivotGridField fieldCELSE_REFERANS_NO = new PivotGridField();
                fieldCELSE_REFERANS_NO.Caption = "Referans";
                fieldCELSE_REFERANS_NO.FieldName = "CELSE_REFERANS_NO";
                fieldCELSE_REFERANS_NO.Name = "fieldCELSE_REFERANS_NO";
                fieldCELSE_REFERANS_NO.Area = PivotArea.FilterArea;
                fieldCELSE_REFERANS_NO.AreaIndex = 8;

                PivotGridField fieldDavaci = new PivotGridField();
                fieldDavaci.Caption = "Davacý";
                fieldDavaci.FieldName = "DavaEdenler";
                fieldDavaci.Name = "fieldDavaci";
                fieldDavaci.Area = PivotArea.FilterArea;
                fieldDavaci.AreaIndex = 5;

                PivotGridField fieldDavali = new PivotGridField();
                fieldDavali.Caption = "Davalý";
                fieldDavali.FieldName = "DavaEdilenler";
                fieldDavali.Name = "fieldDavali";
                fieldDavali.Area = PivotArea.FilterArea;
                fieldDavali.AreaIndex = 6;

                #endregion

                #region []

                PivotGridField[] dizi = new[]
                        {   fieldID,
                            fieldDavaESAS_NO,
                            fieldDavaFOY_NO,
                            fieldDavaADLI_BIRIM_ADLIYE_ID,
                            fieldDavaADLI_BIRIM_NO_ID,
                            fieldDavaADLI_BIRIM_GOREV_ID,
                            fieldDavaDAVA_TARIHI,
                            fieldTARIH,
                            //fieldSAATI,
                            fieldSORUMLU_AVUKAT_CARI1_ID,
                            fieldSORUMLU_AVUKAT_CARI2_ID,
                            fieldHAKIM_CARI1_ID,
                            fieldHAKIM_CARI2_ID,
                            fieldHAKIM_CARI3_ID,
                            fieldSAVCI_CARI_ID,
                            fieldKATIP_CARI_ID,
                            fieldMAZERET_VAR_MI,
                            fieldMURAFA_MI,
                            fieldCELSE_MI,
                            fieldCELSE_HARCI_ALINACAK_MI,
                            fieldINCELEME_TUR_ID,
                            fieldCELSE_REFERANS_NO,
                            fieldDavaci,
                            fieldDavali
                        };

                #endregion

                return dizi;
            }
        }

        public class OdemeExpress
        {

            #region Repository Items

            private RepositoryItemLookUpEdit rlueDovizID = new RepositoryItemLookUpEdit();
            private RepositoryItemLookUpEdit rlueAlacakNedeni = new RepositoryItemLookUpEdit();
            private RepositoryItemLookUpEdit rlueOzelKod1 = new RepositoryItemLookUpEdit();
            private RepositoryItemLookUpEdit rlueOzelKod2 = new RepositoryItemLookUpEdit();
            private RepositoryItemLookUpEdit rlueOzelKod3 = new RepositoryItemLookUpEdit();
            private RepositoryItemLookUpEdit rlueOzelKod4 = new RepositoryItemLookUpEdit();
            private RepositoryItemLookUpEdit rlueSubeKodID = new RepositoryItemLookUpEdit();
            private RepositoryItemLookUpEdit rlueFormTipiID = new RepositoryItemLookUpEdit();
            private RepositoryItemLookUpEdit rlueSegment = new RepositoryItemLookUpEdit();
            private RepositoryItemLookUpEdit rlueCari = new RepositoryItemLookUpEdit();

            #endregion

            public PivotGridField[] GetFields()
            {
                #region Bind Repositories

                AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rlueCari);
                AvukatPro.Services.Implementations.DevExpressService.DovizDoldur(rlueDovizID);
                BelgeUtil.Inits.AlacakNedenByFoy(rlueAlacakNedeni);
                AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rlueOzelKod1, 1, AvukatProLib.Extras.Modul.Icra);
                AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rlueOzelKod2, 2, AvukatProLib.Extras.Modul.Icra);
                AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rlueOzelKod3, 3, AvukatProLib.Extras.Modul.Icra);
                AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rlueOzelKod4, 4, AvukatProLib.Extras.Modul.Icra);
                BelgeUtil.Inits.SubeKodGetir(rlueSubeKodID);
                AvukatPro.Services.Implementations.DevExpressService.FormTipiDoldur(rlueFormTipiID);
                AvukatPro.Services.Implementations.DevExpressService.SegmentDoldur(rlueSegment);

                #endregion

                #region fields & properties

                PivotGridField fieldID = new PivotGridField();
                fieldID.Area = PivotArea.DataArea;
                fieldID.AreaIndex = 0;
                fieldID.Caption = "Kayýt Sayýsý";
                fieldID.FieldName = "Id";
                fieldID.Name = "fieldID";
                fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;

                PivotGridField fieldSegment = new PivotGridField();
                fieldSegment.Area = PivotArea.FilterArea;
                fieldSegment.AreaIndex = 12;
                fieldSegment.Caption = "Bölüm";
                fieldSegment.FieldName = "SegmentId";
                fieldSegment.Name = "fieldSegment";
                fieldSegment.FieldEdit = rlueSegment;

                PivotGridField fieldODEYEN_CARI = new PivotGridField();
                fieldODEYEN_CARI.Area = PivotArea.FilterArea;
                fieldODEYEN_CARI.AreaIndex = 7;
                fieldODEYEN_CARI.Caption = "Borçlu";
                fieldODEYEN_CARI.FieldName = "OdeyenCari";
                fieldODEYEN_CARI.Name = "fieldODEYEN_CARI";
                fieldODEYEN_CARI.FieldEdit = rlueCari;

                PivotGridField fieldODENEN_CARI = new PivotGridField();
                fieldODENEN_CARI.Area = PivotArea.FilterArea;
                fieldODENEN_CARI.AreaIndex = 8;
                fieldODENEN_CARI.Caption = "Alacaklý";
                fieldODENEN_CARI.FieldName = "OdenenCari";
                fieldODENEN_CARI.Name = "fieldODENEN_CARI";
                fieldODENEN_CARI.FieldEdit = rlueCari;

                PivotGridField fieldADLI_BIRIM_ADLIYE = new PivotGridField();
                fieldADLI_BIRIM_ADLIYE.Area = PivotArea.RowArea;
                fieldADLI_BIRIM_ADLIYE.AreaIndex = 5;
                fieldADLI_BIRIM_ADLIYE.Caption = "Adliye";
                fieldADLI_BIRIM_ADLIYE.FieldName = "AdliBirimAdliye";
                fieldADLI_BIRIM_ADLIYE.Name = "fieldADLI_BIRIM_ADLIYE";

                PivotGridField fieldADLI_BIRIM_NO = new PivotGridField();
                fieldADLI_BIRIM_NO.Area = PivotArea.FilterArea;
                fieldADLI_BIRIM_NO.AreaIndex = 14;
                fieldADLI_BIRIM_NO.Caption = "No";
                fieldADLI_BIRIM_NO.FieldName = "AdliBirimNo";
                fieldADLI_BIRIM_NO.Name = "fieldADLI_BIRIM_NO";

                PivotGridField fieldESAS_NO = new PivotGridField();
                fieldESAS_NO.Area = PivotArea.FilterArea;
                fieldESAS_NO.AreaIndex = 15;
                fieldESAS_NO.Caption = "Esas No";
                fieldESAS_NO.FieldName = "EsasNo";
                fieldESAS_NO.Name = "fieldESAS_NO";

                PivotGridField fieldIntikalTarihi = new PivotGridField();
                fieldIntikalTarihi.Area = PivotArea.RowArea;
                fieldIntikalTarihi.AreaIndex = 4;
                fieldIntikalTarihi.Caption = "Ýntikal T.";
                fieldIntikalTarihi.FieldName = "TakibinAvukataIntikalTarihi";
                fieldIntikalTarihi.Name = "fieldIntikalTarihi";

                PivotGridField fieldTAKIP_TARIHI = new PivotGridField();
                fieldTAKIP_TARIHI.Area = PivotArea.RowArea;
                fieldTAKIP_TARIHI.AreaIndex = 5;
                fieldTAKIP_TARIHI.Caption = "Takip T.";
                fieldTAKIP_TARIHI.FieldName = "TakipTarihi";
                fieldTAKIP_TARIHI.Name = "fieldTAKIP_TARIHI";
                fieldTAKIP_TARIHI.GroupInterval = PivotGroupInterval.DateYear;

                PivotGridField fieldODEME_YERI = new PivotGridField();
                fieldODEME_YERI.Caption = "Ödeme Yeri";
                fieldODEME_YERI.FieldName = "OdemeYeri";
                fieldODEME_YERI.Name = "fieldODEME_YERI";
                fieldODEME_YERI.Visible = false;

                PivotGridField fieldODEME_TARIHI = new PivotGridField();
                fieldODEME_TARIHI.Area = PivotArea.RowArea;
                fieldODEME_TARIHI.AreaIndex = 3;
                fieldODEME_TARIHI.Caption = "Ödeme T. (Yýl)";
                fieldODEME_TARIHI.FieldName = "OdemeTarihi";
                fieldODEME_TARIHI.Name = "fieldODEME_TARIHI";
                fieldODEME_TARIHI.GroupInterval = PivotGroupInterval.DateYear;

                PivotGridField fieldODEME_TARIHI2 = new PivotGridField();
                fieldODEME_TARIHI2.Area = PivotArea.RowArea;
                fieldODEME_TARIHI2.AreaIndex = 4;
                fieldODEME_TARIHI2.Caption = "Ödeme T. (Ay)";
                fieldODEME_TARIHI2.FieldName = "OdemeTarihi";
                fieldODEME_TARIHI2.Name = "fieldODEME_TARIHI2";
                fieldODEME_TARIHI2.GroupInterval = PivotGroupInterval.DateMonth;

                PivotGridField fieldODEME_TARIHI3 = new PivotGridField();
                fieldODEME_TARIHI3.Area = PivotArea.RowArea;
                fieldODEME_TARIHI3.AreaIndex = 5;
                fieldODEME_TARIHI3.Caption = "Ödeme T. (Gün)";
                fieldODEME_TARIHI3.FieldName = "OdemeTarihi";
                fieldODEME_TARIHI3.Name = "fieldODEME_TARIHI3";
                fieldODEME_TARIHI3.GroupInterval = PivotGroupInterval.Date;

                PivotGridField fieldICRADAN_CEKILME_TARIHI = new PivotGridField();
                fieldICRADAN_CEKILME_TARIHI.Caption = "Çekilme T.";
                fieldICRADAN_CEKILME_TARIHI.FieldName = "IcradanCekilmeTarihi";
                fieldICRADAN_CEKILME_TARIHI.Name = "fieldICRADAN_CEKILME_TARIHI";
                fieldICRADAN_CEKILME_TARIHI.Visible = false;

                PivotGridField fieldODEME_TIP = new PivotGridField();
                fieldODEME_TIP.Caption = "Ödeme Tipi";
                fieldODEME_TIP.FieldName = "OdemeTip";
                fieldODEME_TIP.Name = "fieldODEME_TIP";
                fieldODEME_TIP.Visible = false;

                PivotGridField fieldODEME_MIKTAR = new PivotGridField();
                fieldODEME_MIKTAR.Area = PivotArea.DataArea;
                fieldODEME_MIKTAR.AreaIndex = 6;
                fieldODEME_MIKTAR.Caption = "Ödeme Miktarý";
                fieldODEME_MIKTAR.FieldName = "OdemeMiktar";
                fieldODEME_MIKTAR.Name = "fieldODEME_MIKTAR";

                PivotGridField fieldODEME_MIKTAR_DOVIZ_ID = new PivotGridField();
                fieldODEME_MIKTAR_DOVIZ_ID.Area = PivotArea.DataArea;
                fieldODEME_MIKTAR_DOVIZ_ID.AreaIndex = 4;
                fieldODEME_MIKTAR_DOVIZ_ID.Caption = "Br.";
                fieldODEME_MIKTAR_DOVIZ_ID.FieldName = "OdemeMiktarDovizId";
                fieldODEME_MIKTAR_DOVIZ_ID.Name = "fieldODEME_MIKTAR_DOVIZ_ID";
                fieldODEME_MIKTAR_DOVIZ_ID.FieldEdit = rlueDovizID;
                fieldODEME_MIKTAR_DOVIZ_ID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Min;

                PivotGridField fieldSUBE_KOD_ID = new PivotGridField();
                fieldSUBE_KOD_ID.Area = PivotArea.RowArea;
                fieldSUBE_KOD_ID.AreaIndex = 7;
                fieldSUBE_KOD_ID.Caption = "Þube";
                fieldSUBE_KOD_ID.FieldName = "SubeKodId";
                fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
                fieldSUBE_KOD_ID.FieldEdit = rlueSubeKodID;

                PivotGridField fieldIZLEYEN = new PivotGridField();
                fieldIZLEYEN.Area = PivotArea.FilterArea;
                fieldIZLEYEN.AreaIndex = 11;
                fieldIZLEYEN.Caption = "Ýzleyen";
                fieldIZLEYEN.FieldName = "Izleyen";
                fieldIZLEYEN.Name = "fieldIZLEYEN";

                PivotGridField fieldSORUMLU = new PivotGridField();
                fieldSORUMLU.Area = PivotArea.RowArea;
                fieldSORUMLU.AreaIndex = 8;
                fieldSORUMLU.Caption = "Sorumlu";
                fieldSORUMLU.FieldName = "Sorumlu";
                fieldSORUMLU.Name = "fieldSORUMLU";

                PivotGridField fieldDURUM = new PivotGridField();
                fieldDURUM.Area = PivotArea.RowArea;
                fieldDURUM.AreaIndex = 0;
                fieldDURUM.Caption = "Durum";
                fieldDURUM.FieldName = "Durum";
                fieldDURUM.Name = "fieldDURUM";

                PivotGridField fieldOzelKod1 = new PivotGridField();
                fieldOzelKod1.Area = PivotArea.FilterArea;
                fieldOzelKod1.AreaIndex = 0;
                fieldOzelKod1.Caption = Kimlikci.Kimlik.IcraOzelKod.OzelKod1;
                fieldOzelKod1.FieldName = "IcraOzelKod1Id";
                fieldOzelKod1.Name = "fieldOzelKod1";
                fieldOzelKod1.FieldEdit = rlueOzelKod1;

                PivotGridField fieldOzelKod2 = new PivotGridField();
                fieldOzelKod2.Area = PivotArea.FilterArea;
                fieldOzelKod2.AreaIndex = 3;
                fieldOzelKod2.Caption = Kimlikci.Kimlik.IcraOzelKod.OzelKod2;
                fieldOzelKod2.FieldName = "IcraOzelKod2Id";
                fieldOzelKod2.Name = "fieldOzelKod2";
                fieldOzelKod2.FieldEdit = rlueOzelKod2;

                PivotGridField fieldOzelKod3 = new PivotGridField();
                fieldOzelKod3.Area = PivotArea.FilterArea;
                fieldOzelKod3.AreaIndex = 5;
                fieldOzelKod3.Caption = Kimlikci.Kimlik.IcraOzelKod.OzelKod3;
                fieldOzelKod3.FieldName = "IcraOzelKod3Id";
                fieldOzelKod3.Name = "fieldOzelKod3";
                fieldOzelKod3.FieldEdit = rlueOzelKod3;

                PivotGridField fieldOzelKod4 = new PivotGridField();
                fieldOzelKod4.Area = PivotArea.FilterArea;
                fieldOzelKod4.AreaIndex = 6;
                fieldOzelKod4.Caption = Kimlikci.Kimlik.IcraOzelKod.OzelKod4;
                fieldOzelKod4.FieldName = "IcraOzelKod4Id";
                fieldOzelKod4.Name = "fieldOzelKod4";
                fieldOzelKod4.FieldEdit = rlueOzelKod4;

                PivotGridField fieldODEME_KIM_ADINA = new PivotGridField();
                fieldODEME_KIM_ADINA.Caption = "Kim Adýna";
                fieldODEME_KIM_ADINA.FieldName = "OdemeKimAdina";
                fieldODEME_KIM_ADINA.Name = "fieldODEME_KIM_ADINA";
                fieldODEME_KIM_ADINA.Visible = false;


                PivotGridField fieldADLI_BIRIM_GOREV = new PivotGridField();
                fieldADLI_BIRIM_GOREV.Caption = "Görev";
                fieldADLI_BIRIM_GOREV.FieldName = "AdliBirimGorev";
                fieldADLI_BIRIM_GOREV.Name = "fieldADLI_BIRIM_GOREV";

                PivotGridField fieldKALAN = new PivotGridField();
                fieldKALAN.Area = PivotArea.DataArea;
                fieldKALAN.AreaIndex = 8;
                fieldKALAN.Caption = "Kalan";
                fieldKALAN.FieldName = "Kalan";
                fieldKALAN.Name = "fieldKALAN";

                PivotGridField fieldKALAN_DOVIZ_ID = new PivotGridField();
                fieldKALAN_DOVIZ_ID.Area = PivotArea.DataArea;
                fieldKALAN_DOVIZ_ID.AreaIndex = 9;
                fieldKALAN_DOVIZ_ID.Caption = "Br.";
                fieldKALAN_DOVIZ_ID.FieldName = "KalanDovizId";
                fieldKALAN_DOVIZ_ID.Name = "fieldKALAN_DOVIZ_ID";
                fieldKALAN_DOVIZ_ID.FieldEdit = rlueDovizID;
                fieldKALAN_DOVIZ_ID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Min;

                PivotGridField fieldRISK_MIKTARI = new PivotGridField();
                fieldRISK_MIKTARI.Area = PivotArea.DataArea;
                fieldRISK_MIKTARI.AreaIndex = 4;
                fieldRISK_MIKTARI.Caption = "Risk Miktarý";
                fieldRISK_MIKTARI.FieldName = "RiskMiktari";
                fieldRISK_MIKTARI.Name = "fieldRISK_MIKTARI";

                PivotGridField fieldRISK_MIKTARI_DOVIZ_ID = new PivotGridField();
                fieldRISK_MIKTARI_DOVIZ_ID.Area = PivotArea.DataArea;
                fieldRISK_MIKTARI_DOVIZ_ID.AreaIndex = 2;
                fieldRISK_MIKTARI_DOVIZ_ID.Caption = "Br.";
                fieldRISK_MIKTARI_DOVIZ_ID.FieldName = "RiskMiktariDovizId";
                fieldRISK_MIKTARI_DOVIZ_ID.Name = "fieldRISK_MIKTARI_DOVIZ_ID";
                fieldRISK_MIKTARI_DOVIZ_ID.FieldEdit = rlueDovizID;
                fieldRISK_MIKTARI_DOVIZ_ID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Min;

                PivotGridField fieldFORM_TIP_ID = new PivotGridField();
                fieldFORM_TIP_ID.Area = PivotArea.FilterArea;
                fieldFORM_TIP_ID.AreaIndex = 13;
                fieldFORM_TIP_ID.Caption = "Form Tipi";
                fieldFORM_TIP_ID.FieldName = "FormTipId";
                fieldFORM_TIP_ID.Name = "fieldFORM_TIP_ID";
                fieldFORM_TIP_ID.FieldEdit = rlueFormTipiID;

                PivotGridField fieldTAKIP_EDEN = new PivotGridField();
                fieldTAKIP_EDEN.Caption = "Takip Eden";
                fieldTAKIP_EDEN.FieldName = "TakipEden";
                fieldTAKIP_EDEN.Name = "fieldTAKIP_EDEN";
                fieldTAKIP_EDEN.Visible = false;

                PivotGridField fieldTAKIP_EDILEN = new PivotGridField();
                fieldTAKIP_EDILEN.Caption = "Takip Edilen";
                fieldTAKIP_EDILEN.FieldName = "TakipEdilen";
                fieldTAKIP_EDILEN.Name = "fieldTAKIP_EDILEN";
                fieldTAKIP_EDILEN.Visible = false;

                PivotGridField fieldKIYMETLI_EVRAKI_BILGILERI_ID = new PivotGridField();
                fieldKIYMETLI_EVRAKI_BILGILERI_ID.Caption = "";
                fieldKIYMETLI_EVRAKI_BILGILERI_ID.FieldName = "KiymetliEvrakiBilgileriId";
                fieldKIYMETLI_EVRAKI_BILGILERI_ID.Name = "fieldKIYMETLI_EVRAKI_BILGILERI_ID";
                fieldKIYMETLI_EVRAKI_BILGILERI_ID.Visible = false;

                PivotGridField fieldKIYMETLI_EVRAK_VADE_TARIHI = new PivotGridField();
                fieldKIYMETLI_EVRAK_VADE_TARIHI.Caption = "Vade T.";
                fieldKIYMETLI_EVRAK_VADE_TARIHI.FieldName = "KiymetliEvrakVadeTarihi";
                fieldKIYMETLI_EVRAK_VADE_TARIHI.Name = "fieldKIYMETLI_EVRAK_VADE_TARIHI";
                fieldKIYMETLI_EVRAK_VADE_TARIHI.Visible = false;

                PivotGridField fieldKIYMETLI_EVRAK_ODENDI_MI = new PivotGridField();
                fieldKIYMETLI_EVRAK_ODENDI_MI.Caption = "Ödendi Mi";
                fieldKIYMETLI_EVRAK_ODENDI_MI.FieldName = "KiymetliEvrakOdendiMi";
                fieldKIYMETLI_EVRAK_ODENDI_MI.Name = "fieldKIYMETLI_EVRAK_ODENDI_MI";
                fieldKIYMETLI_EVRAK_ODENDI_MI.Visible = false;

                PivotGridField fieldMAAS_HACZINDEN_MI = new PivotGridField();
                fieldMAAS_HACZINDEN_MI.Caption = "Maaþ Haczinde Mi";
                fieldMAAS_HACZINDEN_MI.FieldName = "MaasHaczindeMi";
                fieldMAAS_HACZINDEN_MI.Name = "fieldMAAS_HACZINDEN_MI";
                fieldKIYMETLI_EVRAK_ODENDI_MI.Visible = false;

                PivotGridField fieldIHTIYATI_HACIZDE_MI = new PivotGridField();
                fieldIHTIYATI_HACIZDE_MI.Caption = "Ýhyiyati Hacizde Mi";
                fieldIHTIYATI_HACIZDE_MI.FieldName = "IhtiyatiHacizdeMi";
                fieldIHTIYATI_HACIZDE_MI.Name = "fieldIHTIYATI_HACIZDE_MI";

                PivotGridField fieldBORCLU_ADINA_ODEYEN = new PivotGridField();
                fieldBORCLU_ADINA_ODEYEN.Area = PivotArea.FilterArea;
                fieldBORCLU_ADINA_ODEYEN.AreaIndex = 9;
                fieldBORCLU_ADINA_ODEYEN.Caption = "Ödeyen";
                fieldBORCLU_ADINA_ODEYEN.FieldName = "BorcluAdinaOdeyen";
                fieldBORCLU_ADINA_ODEYEN.Name = "fieldBORCLU_ADINA_ODEYEN";

                PivotGridField fieldBORCLU_ADINA_ODENEN = new PivotGridField();
                fieldBORCLU_ADINA_ODENEN.Area = PivotArea.FilterArea;
                fieldBORCLU_ADINA_ODENEN.AreaIndex = 10;
                fieldBORCLU_ADINA_ODENEN.Caption = "Ödenen";
                fieldBORCLU_ADINA_ODENEN.FieldName = "BorcluAdinaOdenen";
                fieldBORCLU_ADINA_ODENEN.Name = "fieldBORCLU_ADINA_ODENEN";

                PivotGridField fieldALACAK_NEDEN_ID = new PivotGridField();
                fieldALACAK_NEDEN_ID.Caption = "Alacak Nedeni";
                fieldALACAK_NEDEN_ID.FieldName = "AlacakNedenId";
                fieldALACAK_NEDEN_ID.Name = "fieldALACAK_NEDEN_ID";
                fieldALACAK_NEDEN_ID.FieldEdit = rlueAlacakNedeni;
                fieldALACAK_NEDEN_ID.Visible = false;

                #endregion

                #region []

                PivotGridField[] dizi = new[]
                    {
                        fieldID,
                        fieldSegment,
                        fieldODEYEN_CARI,
                        fieldODENEN_CARI,
                        fieldADLI_BIRIM_ADLIYE,
                        fieldADLI_BIRIM_NO,
                        fieldESAS_NO,
                        fieldIntikalTarihi,
                        fieldTAKIP_TARIHI,
                        fieldODEME_YERI,
                        fieldODEME_TARIHI,
                        fieldODEME_TARIHI2,
                        fieldODEME_TARIHI3,
                        fieldICRADAN_CEKILME_TARIHI,
                        fieldODEME_TIP,
                        fieldODEME_MIKTAR,
                        fieldODEME_MIKTAR_DOVIZ_ID,
                        fieldSUBE_KOD_ID,
                        fieldIZLEYEN,
                        fieldSORUMLU,
                        fieldDURUM,
                        fieldOzelKod1,
                        fieldOzelKod2,
                        fieldOzelKod3,
                        fieldOzelKod4,
                        fieldODEME_KIM_ADINA,
                        fieldADLI_BIRIM_GOREV,
                        fieldKALAN,
                        fieldKALAN_DOVIZ_ID,
                        fieldRISK_MIKTARI,
                        fieldRISK_MIKTARI_DOVIZ_ID,
                        fieldFORM_TIP_ID,
                        fieldTAKIP_EDEN,
                        fieldTAKIP_EDILEN,
                        fieldKIYMETLI_EVRAKI_BILGILERI_ID,
                        fieldKIYMETLI_EVRAK_VADE_TARIHI,
                        fieldKIYMETLI_EVRAK_ODENDI_MI,
                        fieldMAAS_HACZINDEN_MI,
                        fieldIHTIYATI_HACIZDE_MI,
                        fieldBORCLU_ADINA_ODEYEN,
                        fieldBORCLU_ADINA_ODENEN,
                        fieldALACAK_NEDEN_ID
                    };

                #endregion

                return dizi;

            }
        }

        //Semih Soruþturma Pivot
        public class R_SORUSTURMA_PIVOT
        {
            public PivotGridField[] GetFields()
            {
                #region fields & properties

                PivotGridField fieldID = new PivotGridField();
                fieldID.Area = PivotArea.DataArea;
                fieldID.AreaIndex = 0;
                fieldID.Caption = "Dosya Sayýsý";
                fieldID.FieldName = "ID";
                fieldID.Name = "fieldID";
                fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;

                PivotGridField fieldFOY_NO = new PivotGridField();
                fieldFOY_NO.Area = PivotArea.FilterArea;
                fieldFOY_NO.AreaIndex = 1;
                fieldFOY_NO.Caption = "Föy No";
                fieldFOY_NO.FieldName = "FOY_NO";
                fieldFOY_NO.Name = "fieldFOY_NO";

                PivotGridField fieldDURUM = new PivotGridField();
                fieldDURUM.Area = PivotArea.FilterArea;
                fieldDURUM.AreaIndex = 2;
                fieldDURUM.Caption = "Dava Durumu";
                fieldDURUM.FieldName = "DURUM";
                fieldDURUM.Name = "fieldDURUM";

                PivotGridField fieldSavcilik = new PivotGridField();
                fieldSavcilik.Area = PivotArea.RowArea;
                fieldSavcilik.AreaIndex = 3;
                fieldSavcilik.Caption = "Savcýlýk";
                fieldSavcilik.FieldName = "Savcýlýk";
                fieldSavcilik.Name = "fieldSavcilik";

                PivotGridField fieldGorev = new PivotGridField();
                fieldGorev.Area = PivotArea.FilterArea;
                fieldGorev.AreaIndex = 4;
                fieldGorev.Caption = "Görev";
                fieldGorev.FieldName = "Görev";
                fieldGorev.Name = "fieldGorev";

                PivotGridField fieldEsasNo = new PivotGridField();
                fieldEsasNo.Area = PivotArea.FilterArea;
                fieldEsasNo.AreaIndex = 5;
                fieldEsasNo.Caption = "Esas No";
                fieldEsasNo.FieldName = "Esas No";
                fieldEsasNo.Name = "fieldEsasNo";

                PivotGridField fieldSikayetTarihiAy = new PivotGridField();
                fieldSikayetTarihiAy.Area = PivotArea.RowArea;
                fieldSikayetTarihiAy.AreaIndex = 6;
                fieldSikayetTarihiAy.Caption = "Þikayet Tarihi (Ay)";
                fieldSikayetTarihiAy.FieldName = "Þikayet Tarihi";
                fieldSikayetTarihiAy.Name = "fieldSikayetTarihiAy";
                fieldSikayetTarihiAy.GroupInterval = PivotGroupInterval.DateMonth;

                PivotGridField fieldSikayetTarihiYil = new PivotGridField();
                fieldSikayetTarihiYil.Area = PivotArea.RowArea;
                fieldSikayetTarihiYil.AreaIndex = 6;
                fieldSikayetTarihiYil.Caption = "Þikayet Tarihi (Yýl)";
                fieldSikayetTarihiYil.FieldName = "Þikayet Tarihi";
                fieldSikayetTarihiYil.Name = "fieldSikayetTarihiYil";
                fieldSikayetTarihiYil.GroupInterval = PivotGroupInterval.DateYear;

                PivotGridField fieldHazirlikTarihi = new PivotGridField();
                fieldHazirlikTarihi.Area = PivotArea.FilterArea;
                fieldHazirlikTarihi.AreaIndex = 7;
                fieldHazirlikTarihi.Caption = "Hazýrlýk Tarihi";
                fieldHazirlikTarihi.FieldName = "Hazýrlýk Tarihi";
                fieldHazirlikTarihi.Name = "fieldHazirlikTarihi";
                fieldHazirlikTarihi.GroupInterval = PivotGroupInterval.DateYear;

                PivotGridField fieldSikayetEden = new PivotGridField();
                fieldSikayetEden.Area = PivotArea.FilterArea;
                fieldSikayetEden.AreaIndex = 8;
                fieldSikayetEden.Caption = "Þikayet Eden";
                fieldSikayetEden.FieldName = "Þikayet Eden";
                fieldSikayetEden.Name = "fieldSikayetEden";

                PivotGridField fieldSikayetEdilen = new PivotGridField();
                fieldSikayetEdilen.Area = PivotArea.FilterArea;
                fieldSikayetEdilen.AreaIndex = 9;
                fieldSikayetEdilen.Caption = "Þikayet Edilen";
                fieldSikayetEdilen.FieldName = "Þikayet Edilen";
                fieldSikayetEdilen.Name = "fieldSikayetEdilen";

                PivotGridField fieldSuc = new PivotGridField();
                fieldSuc.Area = PivotArea.RowArea;
                fieldSuc.AreaIndex = 10;
                fieldSuc.Caption = "Suç";
                fieldSuc.FieldName = "Suç";
                fieldSuc.Name = "fieldSuc";

                PivotGridField fieldSorusturmaSafhasi = new PivotGridField();
                fieldSorusturmaSafhasi.Area = PivotArea.RowArea;
                fieldSorusturmaSafhasi.AreaIndex = 11;
                fieldSorusturmaSafhasi.Caption = "Soruþturma Safhasý";
                fieldSorusturmaSafhasi.FieldName = "Soruþturma Safhasý";
                fieldSorusturmaSafhasi.Name = "fieldSorusturmaSafhasi";

                PivotGridField fieldMahkeme = new PivotGridField();
                fieldMahkeme.Area = PivotArea.FilterArea;
                fieldMahkeme.AreaIndex = 12;
                fieldMahkeme.Caption = "Mahkeme";
                fieldMahkeme.FieldName = "Mahkeme";
                fieldMahkeme.Name = "fieldMahkeme";

                PivotGridField fieldBIRIM_NO = new PivotGridField();
                fieldBIRIM_NO.Area = PivotArea.FilterArea;
                fieldBIRIM_NO.AreaIndex = 13;
                fieldBIRIM_NO.Caption = "Dava Birim";
                fieldBIRIM_NO.FieldName = "BIRIM_NO";
                fieldBIRIM_NO.Name = "fieldBIRIM_NO";

                PivotGridField fieldGOREV = new PivotGridField();
                fieldGOREV.Area = PivotArea.FilterArea;
                fieldGOREV.AreaIndex = 14;
                fieldGOREV.Caption = "Dava Görev";
                fieldGOREV.FieldName = "GOREV";
                fieldGOREV.Name = "fieldGOREV";

                PivotGridField fieldESAS_NO = new PivotGridField();
                fieldESAS_NO.Area = PivotArea.FilterArea;
                fieldESAS_NO.AreaIndex = 15;
                fieldESAS_NO.Caption = "Dava Esas";
                fieldESAS_NO.FieldName = "ESAS_NO";
                fieldESAS_NO.Name = "fieldESAS_NO";

                PivotGridField fieldDAVA_TARIHI = new PivotGridField();
                fieldDAVA_TARIHI.Area = PivotArea.RowArea;
                fieldDAVA_TARIHI.AreaIndex = 16;
                fieldDAVA_TARIHI.Caption = "Dava Tarihi";
                fieldDAVA_TARIHI.FieldName = "DAVA_TARIHI";
                fieldDAVA_TARIHI.Name = "fieldDAVA_TARIHI";
                fieldDAVA_TARIHI.GroupInterval = PivotGroupInterval.DateYear;

                PivotGridField fieldHUKUM_TARIHI = new PivotGridField();
                fieldHUKUM_TARIHI.Area = PivotArea.RowArea;
                fieldHUKUM_TARIHI.AreaIndex = 17;
                fieldHUKUM_TARIHI.Caption = "Hüküm Tarihi";
                fieldHUKUM_TARIHI.FieldName = "HUKUM_TARIHI";
                fieldHUKUM_TARIHI.Name = "fieldHUKUM_TARIHI";
                fieldHUKUM_TARIHI.GroupInterval = PivotGroupInterval.DateYear;

                PivotGridField fieldHUKUM = new PivotGridField();
                fieldHUKUM.Area = PivotArea.RowArea;
                fieldHUKUM.AreaIndex = 18;
                fieldHUKUM.Caption = "Hüküm";
                fieldHUKUM.FieldName = "HUKUM";
                fieldHUKUM.Name = "fieldHUKUM";

                PivotGridField fieldTEMYIZ_TARIHI = new PivotGridField();
                fieldTEMYIZ_TARIHI.Area = PivotArea.RowArea;
                fieldTEMYIZ_TARIHI.AreaIndex = 19;
                fieldTEMYIZ_TARIHI.Caption = "Temyiz Tarihi";
                fieldTEMYIZ_TARIHI.FieldName = "TEMYIZ_TARIHI";
                fieldTEMYIZ_TARIHI.Name = "fieldTEMYIZ_TARIHI";
                fieldTEMYIZ_TARIHI.GroupInterval = PivotGroupInterval.DateYear;

                PivotGridField fieldKARAR_TARIHI = new PivotGridField();
                fieldKARAR_TARIHI.Area = PivotArea.RowArea;
                fieldKARAR_TARIHI.AreaIndex = 20;
                fieldKARAR_TARIHI.Caption = "Karar Tarihi";
                fieldKARAR_TARIHI.FieldName = "KARAR_TARIHI";
                fieldKARAR_TARIHI.Name = "fieldKARAR_TARIHI";
                fieldKARAR_TARIHI.GroupInterval = PivotGroupInterval.DateYear;

                PivotGridField fieldKARAR_TIP = new PivotGridField();
                fieldKARAR_TIP.Area = PivotArea.RowArea;
                fieldKARAR_TIP.AreaIndex = 21;
                fieldKARAR_TIP.Caption = "Karar Tipi";
                fieldKARAR_TIP.FieldName = "KARAR_TIP";
                fieldKARAR_TIP.Name = "fieldKARAR_TIP";

                PivotGridField fieldREFERANS_NO = new PivotGridField();
                fieldREFERANS_NO.Area = PivotArea.FilterArea;
                fieldREFERANS_NO.AreaIndex = 22;
                fieldREFERANS_NO.Caption = "Referans No 1";
                fieldREFERANS_NO.FieldName = "REFERANS_NO";
                fieldREFERANS_NO.Name = "fieldREFERANS_NO";

                PivotGridField fieldREFERANS_NO2 = new PivotGridField();
                fieldREFERANS_NO2.Area = PivotArea.FilterArea;
                fieldREFERANS_NO2.AreaIndex = 23;
                fieldREFERANS_NO2.Caption = "Referans No 2";
                fieldREFERANS_NO2.FieldName = "REFERANS_NO2";
                fieldREFERANS_NO2.Name = "fieldREFERANS_NO2";

                PivotGridField fieldREFERANS_NO3 = new PivotGridField();
                fieldREFERANS_NO3.Area = PivotArea.FilterArea;
                fieldREFERANS_NO3.AreaIndex = 24;
                fieldREFERANS_NO3.Caption = "Referans No 3";
                fieldREFERANS_NO3.FieldName = "REFERANS_NO3";
                fieldREFERANS_NO3.Name = "fieldREFERANS_NO3";

                PivotGridField fieldOZEL_KOD1 = new PivotGridField();
                fieldOZEL_KOD1.Area = PivotArea.FilterArea;
                fieldOZEL_KOD1.AreaIndex = 25;
                fieldOZEL_KOD1.Caption = "Özel Kod 1";
                fieldOZEL_KOD1.FieldName = "OZEL_KOD1";
                fieldOZEL_KOD1.Name = "fieldOZEL_KOD1";

                PivotGridField fieldOZEL_KOD2 = new PivotGridField();
                fieldOZEL_KOD2.Area = PivotArea.FilterArea;
                fieldOZEL_KOD2.AreaIndex = 25;
                fieldOZEL_KOD2.Caption = "Özel Kod 2";
                fieldOZEL_KOD2.FieldName = "OZEL_KOD2";
                fieldOZEL_KOD2.Name = "fieldOZEL_KOD2";

                PivotGridField fieldOZEL_KOD3 = new PivotGridField();
                fieldOZEL_KOD3.Area = PivotArea.FilterArea;
                fieldOZEL_KOD3.AreaIndex = 25;
                fieldOZEL_KOD3.Caption = "Özel Kod 3";
                fieldOZEL_KOD3.FieldName = "OZEL_KOD3";
                fieldOZEL_KOD3.Name = "fieldOZEL_KOD3";

                PivotGridField fieldOZEL_KOD4 = new PivotGridField();
                fieldOZEL_KOD4.Area = PivotArea.FilterArea;
                fieldOZEL_KOD4.AreaIndex = 25;
                fieldOZEL_KOD4.Caption = "Özel Kod 4";
                fieldOZEL_KOD4.FieldName = "OZEL_KOD4";
                fieldOZEL_KOD4.Name = "fieldOZEL_KOD4";

                #endregion

                #region []

                PivotGridField[] dizi = new[]
                        {
                            fieldID,
                            fieldFOY_NO,
                            fieldDURUM,
                            fieldSavcilik,
                            fieldGorev,
                            fieldEsasNo,
                            fieldSikayetTarihiYil,
                            fieldSikayetTarihiAy,
                            fieldHazirlikTarihi,
                            fieldSikayetEden,
                            fieldSikayetEdilen,
                            fieldSuc,
                            fieldSorusturmaSafhasi,
                            fieldMahkeme,
                            fieldBIRIM_NO,
                            fieldGOREV,
                            fieldESAS_NO,
                            fieldDAVA_TARIHI,
                            fieldHUKUM_TARIHI,
                            fieldHUKUM,
                            fieldTEMYIZ_TARIHI,
                            fieldKARAR_TARIHI,
                            fieldKARAR_TIP,
                            fieldREFERANS_NO,
                            fieldREFERANS_NO2,
                            fieldREFERANS_NO3,
                            fieldOZEL_KOD1,
                            fieldOZEL_KOD2,
                            fieldOZEL_KOD3,
                            fieldOZEL_KOD4
                        };
                #endregion

                return dizi;
            }
        }

        //Semih Proje
        public class Proje
        {
            public PivotGridField[] GetFields()
            {
                #region fields & properties

                PivotGridField fieldID = new PivotGridField();
                fieldID.Area = PivotArea.DataArea;
                fieldID.AreaIndex = 0;
                fieldID.Caption = "Dosya Sayýsý";
                fieldID.FieldName = "ID";
                fieldID.Name = "fieldID";
                fieldID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;

                PivotGridField fieldKOD = new PivotGridField();
                fieldKOD.Area = PivotArea.FilterArea;
                fieldKOD.AreaIndex = 1;
                fieldKOD.Caption = "Kod";
                fieldKOD.FieldName = "KOD";
                fieldKOD.Name = "fieldKOD";

                PivotGridField fieldADI = new PivotGridField();
                fieldADI.Area = PivotArea.FilterArea;
                fieldADI.AreaIndex = 2;
                fieldADI.Caption = "Adý";
                fieldADI.FieldName = "ADI";
                fieldADI.Name = "fieldADI";

                PivotGridField fieldBASLANGIC_TARIHI = new PivotGridField();
                fieldBASLANGIC_TARIHI.Area = PivotArea.RowArea;
                fieldBASLANGIC_TARIHI.AreaIndex = 3;
                fieldBASLANGIC_TARIHI.Caption = "Takip Tarihi(Yýl)";
                fieldBASLANGIC_TARIHI.FieldName = "BASLANGIC_TARIHI";
                fieldBASLANGIC_TARIHI.Name = "fieldBASLANGIC_TARIHI";
                fieldBASLANGIC_TARIHI.GroupInterval = PivotGroupInterval.DateYear;

                PivotGridField fieldBASLANGIC_TARIHI2 = new PivotGridField();
                fieldBASLANGIC_TARIHI2.Area = PivotArea.RowArea;
                fieldBASLANGIC_TARIHI2.AreaIndex = 3;
                fieldBASLANGIC_TARIHI2.Caption = "Takip Tarihi(Ay)";
                fieldBASLANGIC_TARIHI2.FieldName = "BASLANGIC_TARIHI";
                fieldBASLANGIC_TARIHI2.Name = "fieldBASLANGIC_TARIHI2";
                fieldBASLANGIC_TARIHI2.GroupInterval = PivotGroupInterval.DateMonth;

                PivotGridField fieldBITIS_TARIHI = new PivotGridField();
                fieldBITIS_TARIHI.Area = PivotArea.RowArea;
                fieldBITIS_TARIHI.AreaIndex = 4;
                fieldBITIS_TARIHI.Caption = "Kapanma Tarihi (Yýl)";
                fieldBITIS_TARIHI.FieldName = "BITIS_TARIHI";
                fieldBITIS_TARIHI.Name = "fieldBITIS_TARIHI";
                fieldBITIS_TARIHI.GroupInterval = PivotGroupInterval.DateYear;

                PivotGridField fieldBITIS_TARIHI2 = new PivotGridField();
                fieldBITIS_TARIHI2.Area = PivotArea.RowArea;
                fieldBITIS_TARIHI2.AreaIndex = 4;
                fieldBITIS_TARIHI2.Caption = "Kapanma Tarihi (Ay)";
                fieldBITIS_TARIHI2.FieldName = "BITIS_TARIHI";
                fieldBITIS_TARIHI2.Name = "fieldBITIS_TARIHI2";
                fieldBITIS_TARIHI2.GroupInterval = PivotGroupInterval.DateMonth;

                PivotGridField fieldDURUM = new PivotGridField();
                fieldDURUM.Area = PivotArea.RowArea;
                fieldDURUM.AreaIndex = 5;
                fieldDURUM.Caption = "Durum";
                fieldDURUM.FieldName = "DURUM";
                fieldDURUM.Name = "fieldDURUM";

                PivotGridField fieldOZEL_KOD1 = new PivotGridField();
                fieldOZEL_KOD1.Area = PivotArea.FilterArea;
                fieldOZEL_KOD1.AreaIndex = 6;
                fieldOZEL_KOD1.Caption = "Özel kod 1";
                fieldOZEL_KOD1.FieldName = "OZEL_KOD1";
                fieldOZEL_KOD1.Name = "fieldOZEL_KOD1";

                PivotGridField fieldOZEL_KOD2 = new PivotGridField();
                fieldOZEL_KOD2.Area = PivotArea.FilterArea;
                fieldOZEL_KOD2.AreaIndex = 7;
                fieldOZEL_KOD2.Caption = "Özel kod 2";
                fieldOZEL_KOD2.FieldName = "OZEL_KOD2";
                fieldOZEL_KOD2.Name = "fieldOZEL_KOD2";

                PivotGridField fieldOZEL_KOD3 = new PivotGridField();
                fieldOZEL_KOD3.Area = PivotArea.FilterArea;
                fieldOZEL_KOD3.AreaIndex = 8;
                fieldOZEL_KOD3.Caption = "Özel kod 3";
                fieldOZEL_KOD3.FieldName = "OZEL_KOD3";
                fieldOZEL_KOD3.Name = "fieldOZEL_KOD3";

                PivotGridField fieldOZEL_KOD4 = new PivotGridField();
                fieldOZEL_KOD4.Area = PivotArea.FilterArea;
                fieldOZEL_KOD4.AreaIndex = 9;
                fieldOZEL_KOD4.Caption = "Özel kod 4";
                fieldOZEL_KOD4.FieldName = "OZEL_KOD4";
                fieldOZEL_KOD4.Name = "fieldOZEL_KOD4";

                PivotGridField fieldREFERANS_NO1 = new PivotGridField();
                fieldREFERANS_NO1.Area = PivotArea.FilterArea;
                fieldREFERANS_NO1.AreaIndex = 10;
                fieldREFERANS_NO1.Caption = "Referans No 1";
                fieldREFERANS_NO1.FieldName = "REFERANS_NO1";
                fieldREFERANS_NO1.Name = "fieldREFERANS_NO1";

                PivotGridField fieldREFERANS_NO2 = new PivotGridField();
                fieldREFERANS_NO2.Area = PivotArea.FilterArea;
                fieldREFERANS_NO2.AreaIndex = 11;
                fieldREFERANS_NO2.Caption = "Referans No 2";
                fieldREFERANS_NO2.FieldName = "REFERANS_NO2";
                fieldREFERANS_NO2.Name = "fieldREFERANS_NO2";

                PivotGridField fieldREFERANS_NO3 = new PivotGridField();
                fieldREFERANS_NO3.Area = PivotArea.FilterArea;
                fieldREFERANS_NO3.AreaIndex = 12;
                fieldREFERANS_NO3.Caption = "Referans No 3";
                fieldREFERANS_NO3.FieldName = "REFERANS_NO3";
                fieldREFERANS_NO3.Name = "fieldREFERANS_NO3";

                PivotGridField fieldBOLUM = new PivotGridField();
                fieldBOLUM.Area = PivotArea.FilterArea;
                fieldBOLUM.AreaIndex = 13;
                fieldBOLUM.Caption = "Bolum";
                fieldBOLUM.FieldName = "BOLUM";
                fieldBOLUM.Name = "fieldBOLUM";

                PivotGridField fieldPROJE_TARAFI = new PivotGridField();
                fieldPROJE_TARAFI.Area = PivotArea.FilterArea;
                fieldPROJE_TARAFI.AreaIndex = 14;
                fieldPROJE_TARAFI.Caption = "Proje Tarafý";
                fieldPROJE_TARAFI.FieldName = "PROJE_TARAFI";
                fieldPROJE_TARAFI.Name = "fieldPROJE_TARAFI";

                PivotGridField fieldPROJE_SORUMLU = new PivotGridField();
                fieldPROJE_SORUMLU.Area = PivotArea.FilterArea;
                fieldPROJE_SORUMLU.AreaIndex = 15;
                fieldPROJE_SORUMLU.Caption = "Proje Yetkili";
                fieldPROJE_SORUMLU.FieldName = "PROJE_SORUMLU";
                fieldPROJE_SORUMLU.Name = "fieldPROJE_SORUMLU";

                PivotGridField fieldTUTAR_ANAPARA = new PivotGridField();
                fieldTUTAR_ANAPARA.Area = PivotArea.DataArea;
                fieldTUTAR_ANAPARA.AreaIndex = 16;
                fieldTUTAR_ANAPARA.Caption = "Anapara";
                fieldTUTAR_ANAPARA.FieldName = "TUTAR_ANAPARA";
                fieldTUTAR_ANAPARA.Name = "fieldTUTAR_ANAPARA";

                PivotGridField fieldTUTAR_FAIZ = new PivotGridField();
                fieldTUTAR_FAIZ.Area = PivotArea.DataArea;
                fieldTUTAR_FAIZ.AreaIndex = 18;
                fieldTUTAR_FAIZ.Caption = "Faiz";
                fieldTUTAR_FAIZ.FieldName = "TUTAR_FAIZ";
                fieldTUTAR_FAIZ.Name = "fieldTUTAR_FAIZ";

                PivotGridField fieldTUTAR_GIDER_VERGISI = new PivotGridField();
                fieldTUTAR_GIDER_VERGISI.Area = PivotArea.DataArea;
                fieldTUTAR_GIDER_VERGISI.AreaIndex = 19;
                fieldTUTAR_GIDER_VERGISI.Caption = "Gider Vergisi";
                fieldTUTAR_GIDER_VERGISI.FieldName = "TUTAR_GIDER_VERGISI";
                fieldTUTAR_GIDER_VERGISI.Name = "fieldTUTAR_GIDER_VERGISI";

                PivotGridField fieldTUTAR_MASRAF = new PivotGridField();
                fieldTUTAR_MASRAF.Area = PivotArea.DataArea;
                fieldTUTAR_MASRAF.AreaIndex = 22;
                fieldTUTAR_MASRAF.Caption = "Masraflar";
                fieldTUTAR_MASRAF.FieldName = "TUTAR_MASRAF";
                fieldTUTAR_MASRAF.Name = "fieldTUTAR_MASRAF";

                PivotGridField fieldTUTAR_VEKALET_UCRETI = new PivotGridField();
                fieldTUTAR_VEKALET_UCRETI.Area = PivotArea.DataArea;
                fieldTUTAR_VEKALET_UCRETI.AreaIndex = 23;
                fieldTUTAR_VEKALET_UCRETI.Caption = "Vekalet Ucreti";
                fieldTUTAR_VEKALET_UCRETI.FieldName = "TUTAR_VEKALET_UCRETI";
                fieldTUTAR_VEKALET_UCRETI.Name = "fieldTUTAR_VEKALET_UCRETI";

                PivotGridField fieldOdeme_Kalan = new PivotGridField();
                fieldOdeme_Kalan.Area = PivotArea.DataArea;
                fieldOdeme_Kalan.AreaIndex = 24;
                fieldOdeme_Kalan.Caption = "Ödemeler";
                fieldOdeme_Kalan.FieldName = "Odeme_Kalan";
                fieldOdeme_Kalan.Name = "fieldOdeme_Kalan";

                PivotGridField fieldTUTAR_KALAN = new PivotGridField();
                fieldTUTAR_KALAN.Area = PivotArea.DataArea;
                fieldTUTAR_KALAN.AreaIndex = 20;
                fieldTUTAR_KALAN.Caption = "Kalan";
                fieldTUTAR_KALAN.FieldName = "TUTAR_KALAN";
                fieldTUTAR_KALAN.Name = "fieldTUTAR_KALAN";

                PivotGridField fieldRISK_TOPLAMI = new PivotGridField();
                fieldRISK_TOPLAMI.Area = PivotArea.DataArea;
                fieldRISK_TOPLAMI.AreaIndex = 25;
                fieldRISK_TOPLAMI.Caption = "Risk Toplamý";
                fieldRISK_TOPLAMI.FieldName = "RISK_TOPLAMI";
                fieldRISK_TOPLAMI.Name = "fieldRISK_TOPLAMI";

                PivotGridField fieldTUTAR_BANKA_BAKIYESI = new PivotGridField();
                fieldTUTAR_BANKA_BAKIYESI.Area = PivotArea.FilterArea;
                fieldTUTAR_BANKA_BAKIYESI.AreaIndex = 17;
                fieldTUTAR_BANKA_BAKIYESI.Caption = "Þirket Banka Bakiyesi";
                fieldTUTAR_BANKA_BAKIYESI.FieldName = "TUTAR_BANKA_BAKIYESI";
                fieldTUTAR_BANKA_BAKIYESI.Name = "fieldTUTAR_BANKA_BAKIYESI";

                PivotGridField fieldTUTAR_KOM_TAZ = new PivotGridField();
                fieldTUTAR_KOM_TAZ.Area = PivotArea.FilterArea;
                fieldTUTAR_KOM_TAZ.AreaIndex = 21;
                fieldTUTAR_KOM_TAZ.Caption = "Kom Taz";
                fieldTUTAR_KOM_TAZ.FieldName = "TUTAR_KOM_TAZ";
                fieldTUTAR_KOM_TAZ.Name = "fieldTUTAR_KOM_TAZ";

                PivotGridField fieldALACAKLI = new PivotGridField();
                fieldALACAKLI.Area = PivotArea.RowArea;
                fieldALACAKLI.AreaIndex = 26;
                fieldALACAKLI.Caption = "Alacaklý";
                fieldALACAKLI.FieldName = "ALACAKLI";
                fieldALACAKLI.Name = "fieldALACAKLI";

                PivotGridField fieldBORCLU = new PivotGridField();
                fieldBORCLU.Area = PivotArea.RowArea;
                fieldBORCLU.AreaIndex = 27;
                fieldBORCLU.Caption = "Borçlu";
                fieldBORCLU.FieldName = "BORCLU";
                fieldBORCLU.Name = "fieldBORCLU";

                PivotGridField fieldSUBE = new PivotGridField();
                fieldSUBE.Area = PivotArea.RowArea;
                fieldSUBE.AreaIndex = 28;
                fieldSUBE.Caption = "Þube";
                fieldSUBE.FieldName = "SUBE";
                fieldSUBE.Name = "fieldSUBE";


                #endregion

                #region []

                PivotGridField[] dizi = new[]
                        {
                            fieldID,
                            fieldKOD,
                            fieldADI,
                            fieldBASLANGIC_TARIHI,
                            fieldBASLANGIC_TARIHI2,
                            fieldBITIS_TARIHI,
                            fieldBITIS_TARIHI2,
                            fieldDURUM,
                            fieldOZEL_KOD1,
                            fieldOZEL_KOD2,
                            fieldOZEL_KOD3,
                            fieldOZEL_KOD4,
                            fieldREFERANS_NO1,
                            fieldREFERANS_NO2,
                            fieldREFERANS_NO3,
                            fieldBOLUM,
                            fieldPROJE_TARAFI,
                            fieldPROJE_SORUMLU,
                            fieldTUTAR_ANAPARA,
                            fieldTUTAR_FAIZ,
                            fieldTUTAR_GIDER_VERGISI,
                            fieldTUTAR_MASRAF,
                            fieldTUTAR_VEKALET_UCRETI,
                            fieldOdeme_Kalan,
                            fieldTUTAR_KALAN,
                            fieldRISK_TOPLAMI,
                            fieldTUTAR_BANKA_BAKIYESI,
                            fieldTUTAR_KOM_TAZ,
                            fieldALACAKLI,
                            fieldBORCLU,
                            fieldSUBE
                        };
                #endregion

                return dizi;
            }
        }

        //Semih Ticari Risk Raporu
        public class TicariRiskRaporu
        {
            public PivotGridField[] GetFields()
            {
                #region fields & properties

                RepositoryItemLookUpEdit rLueProjeDurum = new RepositoryItemLookUpEdit();
                BelgeUtil.Inits.ProjeDurumGetir(rLueProjeDurum);

                PivotGridField fieldRowID = new PivotGridField();
                fieldRowID.Area = PivotArea.DataArea;
                fieldRowID.AreaIndex = 1;
                fieldRowID.Caption = "Dosya Sayýsý";
                fieldRowID.FieldName = "RowID";
                fieldRowID.Name = "fieldRowID";
                fieldRowID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;

                PivotGridField fieldProjeID = new PivotGridField();
                fieldProjeID.Area = PivotArea.FilterArea;
                fieldProjeID.AreaIndex = 2;
                fieldProjeID.Caption = "Proje Ýd";
                fieldProjeID.FieldName = "ProjeID";
                fieldProjeID.Name = "fieldProjeID";

                PivotGridField fieldPriyotTipi = new PivotGridField();
                fieldPriyotTipi.Area = PivotArea.FilterArea;
                fieldPriyotTipi.AreaIndex = 3;
                fieldPriyotTipi.Caption = "Periyot Tipi";
                fieldPriyotTipi.FieldName = "PriyotTipi";
                fieldPriyotTipi.Name = "fieldPriyotTipi";

                PivotGridField fieldPeriyotYil = new PivotGridField();
                fieldPeriyotYil.Area = PivotArea.RowArea;
                fieldPeriyotYil.AreaIndex = 4;
                fieldPeriyotYil.Caption = "Periyot Yýlý";
                fieldPeriyotYil.FieldName = "PeriyotYil";
                fieldPeriyotYil.Name = "fieldPeriyotYil";
                fieldPeriyotYil.GroupInterval = PivotGroupInterval.DateYear;

                PivotGridField fieldPeriyotAy = new PivotGridField();
                fieldPeriyotAy.Area = PivotArea.RowArea;
                fieldPeriyotAy.AreaIndex = 5;
                fieldPeriyotAy.Caption = "Periyot Ay";
                fieldPeriyotAy.FieldName = "PeriyotAy";
                fieldPeriyotAy.Name = "fieldPeriyotAy";
                fieldPeriyotAy.GroupInterval = PivotGroupInterval.DateMonth;

                PivotGridField fieldProjeDurumID = new PivotGridField();
                fieldProjeDurumID.Area = PivotArea.RowArea;
                fieldProjeDurumID.AreaIndex = 6;
                fieldProjeDurumID.Caption = "Proje Durum Ýd";
                fieldProjeDurumID.FieldName = "ProjeDurumID";
                fieldProjeDurumID.Name = "fieldProjeDurumID";
                fieldProjeDurumID.FieldEdit = rLueProjeDurum;

                PivotGridField fieldProjeTakipTarihi = new PivotGridField();
                fieldProjeTakipTarihi.Area = PivotArea.RowArea;
                fieldProjeTakipTarihi.AreaIndex = 7;
                fieldProjeTakipTarihi.Caption = "Proje Takip Tarihi(Yýl)";
                fieldProjeTakipTarihi.FieldName = "ProjeTakipTarihi";
                fieldProjeTakipTarihi.Name = "fieldProjeTakipTarihi";
                fieldProjeTakipTarihi.GroupInterval = PivotGroupInterval.DateYear;

                PivotGridField fieldProjeTakipTarihi2 = new PivotGridField();
                fieldProjeTakipTarihi2.Area = PivotArea.RowArea;
                fieldProjeTakipTarihi2.AreaIndex = 8;
                fieldProjeTakipTarihi2.Caption = "Proje Takip Tarihi(Ay)";
                fieldProjeTakipTarihi2.FieldName = "ProjeTakipTarihi";
                fieldProjeTakipTarihi2.Name = "fieldProjeTakipTarihi2";
                fieldProjeTakipTarihi2.GroupInterval = PivotGroupInterval.DateMonth;

                PivotGridField fieldProjeTakipTarihi3 = new PivotGridField();
                fieldProjeTakipTarihi3.Area = PivotArea.RowArea;
                fieldProjeTakipTarihi3.AreaIndex = 9;
                fieldProjeTakipTarihi3.Caption = "Proje Takip Tarihi(Dönem)";
                fieldProjeTakipTarihi3.FieldName = "ProjeTakipTarihi";
                fieldProjeTakipTarihi3.Name = "fieldProjeTakipTarihi3";
                fieldProjeTakipTarihi3.GroupInterval = PivotGroupInterval.DateQuarter;

                PivotGridField fieldSirketKodu = new PivotGridField();
                fieldSirketKodu.Area = PivotArea.FilterArea;
                fieldSirketKodu.AreaIndex = 10;
                fieldSirketKodu.Caption = "Þirket Kodu";
                fieldSirketKodu.FieldName = "SirketKodu";
                fieldSirketKodu.Name = "fieldSirketKodu";

                PivotGridField fieldAlacakliSirket = new PivotGridField();
                fieldAlacakliSirket.Area = PivotArea.RowArea;
                fieldAlacakliSirket.AreaIndex = 11;
                fieldAlacakliSirket.Caption = "Alacaklý Þirket";
                fieldAlacakliSirket.FieldName = "AlacakliSirket";
                fieldAlacakliSirket.Name = "fieldAlacakliSirket";

                PivotGridField fieldSAPMusteriKodu = new PivotGridField();
                fieldSAPMusteriKodu.Area = PivotArea.FilterArea;
                fieldSAPMusteriKodu.AreaIndex = 12;
                fieldSAPMusteriKodu.Caption = "Sap Müþteri Kodu";
                fieldSAPMusteriKodu.FieldName = "SAPMusteriKodu";
                fieldSAPMusteriKodu.Name = "fieldSAPMusteriKodu";

                PivotGridField fieldSAPAlacakHesabi = new PivotGridField();
                fieldSAPAlacakHesabi.Area = PivotArea.FilterArea;
                fieldSAPAlacakHesabi.AreaIndex = 13;
                fieldSAPAlacakHesabi.Caption = "Sap Alacak Hesabý";
                fieldSAPAlacakHesabi.FieldName = "SAPAlacakHesabi";
                fieldSAPAlacakHesabi.Name = "fieldSAPAlacakHesabi";

                PivotGridField fieldBorclu = new PivotGridField();
                fieldBorclu.Area = PivotArea.FilterArea;
                fieldBorclu.AreaIndex = 14;
                fieldBorclu.Caption = "Borçlu";
                fieldBorclu.FieldName = "Borclu";
                fieldBorclu.Name = "fieldBorclu";

                PivotGridField fieldSifati = new PivotGridField();
                fieldSifati.Area = PivotArea.FilterArea;
                fieldSifati.AreaIndex = 15;
                fieldSifati.Caption = "Sýfatý";
                fieldSifati.FieldName = "Sifati";
                fieldSifati.Name = "fieldSifati";

                PivotGridField fieldAciklama = new PivotGridField();
                fieldAciklama.Area = PivotArea.FilterArea;
                fieldAciklama.AreaIndex = 16;
                fieldAciklama.Caption = "Açiklama";
                fieldAciklama.FieldName = "Aciklama";
                fieldAciklama.Name = "fieldAciklama";

                PivotGridField fieldSAPAlacakTutari = new PivotGridField();
                fieldSAPAlacakTutari.Area = PivotArea.FilterArea;
                fieldSAPAlacakTutari.AreaIndex = 17;
                fieldSAPAlacakTutari.Caption = "Sap Alacak Tutarý";
                fieldSAPAlacakTutari.FieldName = "SAPAlacakTutari";
                fieldSAPAlacakTutari.Name = "fieldSAPAlacakTutari";

                PivotGridField fieldAlacakAnapara = new PivotGridField();
                fieldAlacakAnapara.Area = PivotArea.DataArea;
                fieldAlacakAnapara.AreaIndex = 18;
                fieldAlacakAnapara.Caption = "Alacak Anapara";
                fieldAlacakAnapara.FieldName = "AlacakAnapara";
                fieldAlacakAnapara.Name = "fieldAlacakAnapara";

                PivotGridField fieldAlacakFaizi = new PivotGridField();
                fieldAlacakFaizi.Area = PivotArea.DataArea;
                fieldAlacakFaizi.AreaIndex = 19;
                fieldAlacakFaizi.Caption = "Alacak Faizi";
                fieldAlacakFaizi.FieldName = "AlacakFaizi";
                fieldAlacakFaizi.Name = "fieldAlacakFaizi";

                PivotGridField fieldGiderVergisi = new PivotGridField();
                fieldGiderVergisi.Area = PivotArea.FilterArea;
                fieldGiderVergisi.AreaIndex = 20;
                fieldGiderVergisi.Caption = "Gider Vergisi";
                fieldGiderVergisi.FieldName = "GiderVergisi";
                fieldGiderVergisi.Name = "fieldGiderVergisi";

                PivotGridField fieldKomisyonTazminat = new PivotGridField();
                fieldKomisyonTazminat.Area = PivotArea.FilterArea;
                fieldKomisyonTazminat.AreaIndex = 21;
                fieldKomisyonTazminat.Caption = "Komisyon Tazminatý";
                fieldKomisyonTazminat.FieldName = "KomisyonTazminat";
                fieldKomisyonTazminat.Name = "fieldKomisyonTazminat";

                PivotGridField fieldMasraflar = new PivotGridField();
                fieldMasraflar.Area = PivotArea.DataArea;
                fieldMasraflar.AreaIndex = 22;
                fieldMasraflar.Caption = "Masraflar";
                fieldMasraflar.FieldName = "Masraflar";
                fieldMasraflar.Name = "fieldMasraflar";

                PivotGridField fieldVekaletUcreti = new PivotGridField();
                fieldVekaletUcreti.Area = PivotArea.DataArea;
                fieldVekaletUcreti.AreaIndex = 23;
                fieldVekaletUcreti.Caption = "Vekalet Ücreti";
                fieldVekaletUcreti.FieldName = "VekaletUcreti";
                fieldVekaletUcreti.Name = "fieldVekaletUcreti";

                PivotGridField fieldToplamAlacak = new PivotGridField();
                fieldToplamAlacak.Area = PivotArea.DataArea;
                fieldToplamAlacak.AreaIndex = 24;
                fieldToplamAlacak.Caption = "Toplam Alacak";
                fieldToplamAlacak.FieldName = "ToplamAlacak";
                fieldToplamAlacak.Name = "fieldToplamAlacak";

                PivotGridField fieldRehinToplami = new PivotGridField();
                fieldRehinToplami.Area = PivotArea.FilterArea;
                fieldRehinToplami.AreaIndex = 25;
                fieldRehinToplami.Caption = "Rehin Toplamý";
                fieldRehinToplami.FieldName = "RehinToplami";
                fieldRehinToplami.Name = "fieldRehinToplami";

                PivotGridField fieldIpotekToplami = new PivotGridField();
                fieldIpotekToplami.Area = PivotArea.FilterArea;
                fieldIpotekToplami.AreaIndex = 26;
                fieldIpotekToplami.Caption = "Ýpotek Toplamý";
                fieldIpotekToplami.FieldName = "IpotekToplami";
                fieldIpotekToplami.Name = "fieldIpotekToplami";

                PivotGridField fieldHacizToplami = new PivotGridField();
                fieldHacizToplami.Area = PivotArea.FilterArea;
                fieldHacizToplami.AreaIndex = 27;
                fieldHacizToplami.Caption = "Haciz Toplamý";
                fieldHacizToplami.FieldName = "HacizToplami";
                fieldHacizToplami.Name = "fieldHacizToplami";

                PivotGridField fieldKefaletToplami = new PivotGridField();
                fieldKefaletToplami.Area = PivotArea.FilterArea;
                fieldKefaletToplami.AreaIndex = 28;
                fieldKefaletToplami.Caption = "Kefalet Toplamý";
                fieldKefaletToplami.FieldName = "KefaletToplami";
                fieldKefaletToplami.Name = "fieldKefaletToplami";

                PivotGridField fieldSenetCekToplami = new PivotGridField();
                fieldSenetCekToplami.Area = PivotArea.FilterArea;
                fieldSenetCekToplami.AreaIndex = 29;
                fieldSenetCekToplami.Caption = "Senet Çek Toplamý";
                fieldSenetCekToplami.FieldName = "SenetCekToplami";
                fieldSenetCekToplami.Name = "fieldSenetCekToplami";

                PivotGridField fieldEkspertizDegeri = new PivotGridField();
                fieldEkspertizDegeri.Area = PivotArea.FilterArea;
                fieldEkspertizDegeri.AreaIndex = 30;
                fieldEkspertizDegeri.Caption = "Ekspertiz Deðeri";
                fieldEkspertizDegeri.FieldName = "EkspertizDegeri";
                fieldEkspertizDegeri.Name = "fieldEkspertizDegeri";

                PivotGridField fieldGuncelKarsilikTutari = new PivotGridField();
                fieldGuncelKarsilikTutari.Area = PivotArea.DataArea;
                fieldGuncelKarsilikTutari.AreaIndex = 31;
                fieldGuncelKarsilikTutari.Caption = "Güncel Karþilik Tutarý";
                fieldGuncelKarsilikTutari.FieldName = "GuncelKarsilikTutari";
                fieldGuncelKarsilikTutari.Name = "fieldGuncelKarsilikTutari";

                PivotGridField fieldTakyidatVergiBorclari = new PivotGridField();
                fieldTakyidatVergiBorclari.Area = PivotArea.FilterArea;
                fieldTakyidatVergiBorclari.AreaIndex = 32;
                fieldTakyidatVergiBorclari.Caption = "Takyidat Vergi Borçlarý";
                fieldTakyidatVergiBorclari.FieldName = "TakyidatVergiBorclari";
                fieldTakyidatVergiBorclari.Name = "fieldTakyidatVergiBorclari";

                PivotGridField fieldReelKarsilikTutari = new PivotGridField();
                fieldReelKarsilikTutari.Area = PivotArea.DataArea;
                fieldReelKarsilikTutari.AreaIndex = 33;
                fieldReelKarsilikTutari.Caption = "Reel Karþilik Tutari";
                fieldReelKarsilikTutari.FieldName = "ReelKarsilikTutari";
                fieldReelKarsilikTutari.Name = "fieldReelKarsilikTutari";

                PivotGridField fieldOncekiDonemKarsilikTarihi = new PivotGridField();
                fieldOncekiDonemKarsilikTarihi.Area = PivotArea.FilterArea;
                fieldOncekiDonemKarsilikTarihi.AreaIndex = 34;
                fieldOncekiDonemKarsilikTarihi.Caption = "Onceki Dönem Karþýlýk Tarihi";
                fieldOncekiDonemKarsilikTarihi.FieldName = "OncekiDonemKarsilikTarihi";
                fieldOncekiDonemKarsilikTarihi.Name = "fieldOncekiDonemKarsilikTarihi";

                PivotGridField fieldOncekiDonemKarsilikTutari = new PivotGridField();
                fieldOncekiDonemKarsilikTutari.Area = PivotArea.FilterArea;
                fieldOncekiDonemKarsilikTutari.AreaIndex = 35;
                fieldOncekiDonemKarsilikTutari.Caption = "Önceki Dönem Karþýlýk Tutarý";
                fieldOncekiDonemKarsilikTutari.FieldName = "OncekiDonemKarsilikTutari";
                fieldOncekiDonemKarsilikTutari.Name = "fieldOncekiDonemKarsilikTutari";

                PivotGridField fieldDonemdeAyrilanEkKarsilikTutari = new PivotGridField();
                fieldDonemdeAyrilanEkKarsilikTutari.Area = PivotArea.FilterArea;
                fieldDonemdeAyrilanEkKarsilikTutari.AreaIndex = 36;
                fieldDonemdeAyrilanEkKarsilikTutari.Caption = "Dönemde Ayrilan Ek Karþýlýk Tutarý";
                fieldDonemdeAyrilanEkKarsilikTutari.FieldName = "DonemdeAyrilanEkKarsilikTutari";
                fieldDonemdeAyrilanEkKarsilikTutari.Name = "fieldDonemdeAyrilanEkKarsilikTutari";

                PivotGridField fieldNakdiTahsilatTutari = new PivotGridField();
                fieldNakdiTahsilatTutari.Area = PivotArea.DataArea;
                fieldNakdiTahsilatTutari.AreaIndex = 37;
                fieldNakdiTahsilatTutari.Caption = "Nakdi Tahsilat Tutarý";
                fieldNakdiTahsilatTutari.FieldName = "NakdiTahsilatTutari";
                fieldNakdiTahsilatTutari.Name = "fieldNakdiTahsilatTutari";

                PivotGridField fieldGayriNakdiTahsilatTutari = new PivotGridField();
                fieldGayriNakdiTahsilatTutari.Area = PivotArea.FilterArea;
                fieldGayriNakdiTahsilatTutari.AreaIndex = 38;
                fieldGayriNakdiTahsilatTutari.Caption = "Gayri Nakdi Tahsilat Tutarý";
                fieldGayriNakdiTahsilatTutari.FieldName = "GayriNakdiTahsilatTutari";
                fieldGayriNakdiTahsilatTutari.Name = "fieldGayriNakdiTahsilatTutari";

                PivotGridField fieldGNEkspertizDegeri = new PivotGridField();
                fieldGNEkspertizDegeri.Area = PivotArea.FilterArea;
                fieldGNEkspertizDegeri.AreaIndex = 38;
                fieldGNEkspertizDegeri.Caption = "GN Ekspertiz Deðeri";
                fieldGNEkspertizDegeri.FieldName = "GNEkspertizDegeri";
                fieldGNEkspertizDegeri.Name = "fieldGNEkspertizDegeri";

                PivotGridField fieldBeklenenBitisTarihi = new PivotGridField();
                fieldBeklenenBitisTarihi.Area = PivotArea.FilterArea;
                fieldBeklenenBitisTarihi.AreaIndex = 39;
                fieldBeklenenBitisTarihi.Caption = "Beklenen Bitiþ Tarihi";
                fieldBeklenenBitisTarihi.FieldName = "BeklenenBitisTarihi";
                fieldBeklenenBitisTarihi.Name = "fieldBeklenenBitisTarihi";

                PivotGridField fieldKazanmaOrani = new PivotGridField();
                fieldKazanmaOrani.Area = PivotArea.FilterArea;
                fieldKazanmaOrani.AreaIndex = 40;
                fieldKazanmaOrani.Caption = "Kazanma Oraný";
                fieldKazanmaOrani.FieldName = "KazanmaOrani";
                fieldKazanmaOrani.Name = "fieldKazanmaOrani";

                PivotGridField fieldSonHesapTarihi = new PivotGridField();
                fieldSonHesapTarihi.Area = PivotArea.FilterArea;
                fieldSonHesapTarihi.AreaIndex = 41;
                fieldSonHesapTarihi.Caption = "Son Hesap Tarihi";
                fieldSonHesapTarihi.FieldName = "SonHesapTarihi";
                fieldSonHesapTarihi.Name = "fieldSonHesapTarihi";

                PivotGridField fieldHesaplayanCariID = new PivotGridField();
                fieldHesaplayanCariID.Area = PivotArea.FilterArea;
                fieldHesaplayanCariID.AreaIndex = 42;
                fieldHesaplayanCariID.Caption = "Hesaplayan Cari Ýd";
                fieldHesaplayanCariID.FieldName = "HesaplayanCariID";
                fieldHesaplayanCariID.Name = "fieldBeklenenBitisTarihi";


                #endregion

                #region []

                PivotGridField[] dizi = new[]
                        {
                            fieldRowID,
                            fieldProjeID,
                            fieldPriyotTipi,
                            fieldPeriyotYil,
                            fieldPeriyotAy,
                            fieldProjeDurumID,
                            fieldProjeTakipTarihi,
                            fieldProjeTakipTarihi2,
                            fieldProjeTakipTarihi3,
                            fieldSirketKodu,
                            fieldAlacakliSirket,
                            fieldSAPMusteriKodu,
                            fieldSAPAlacakHesabi,
                            fieldBorclu,
                            fieldSifati,
                            fieldAciklama,
                            fieldSAPAlacakTutari,
                            fieldAlacakAnapara,
                            fieldAlacakFaizi,
                            fieldGiderVergisi,
                            fieldKomisyonTazminat,
                            fieldMasraflar,
                            fieldVekaletUcreti,
                            fieldToplamAlacak,
                            fieldRehinToplami,
                            fieldIpotekToplami,
                            fieldHacizToplami,
                            fieldKefaletToplami,
                            fieldSenetCekToplami,
                            fieldEkspertizDegeri,
                            fieldGuncelKarsilikTutari,
                            fieldTakyidatVergiBorclari,
                            fieldReelKarsilikTutari,
                            fieldOncekiDonemKarsilikTarihi,
                            fieldOncekiDonemKarsilikTutari,
                            fieldDonemdeAyrilanEkKarsilikTutari,
                            fieldNakdiTahsilatTutari,
                            fieldGayriNakdiTahsilatTutari,
                            fieldGNEkspertizDegeri,
                            fieldBeklenenBitisTarihi,
                            fieldKazanmaOrani,
                            fieldSonHesapTarihi,
                            fieldHesaplayanCariID

                        };
                #endregion

                return dizi;
            }
        }

        //Semih Ticari Risk Raporu Dosya
        public class TicariRiskRaporuDosya
        {
            public PivotGridField[] GetFields()
            {
                #region fields & properties

                RepositoryItemLookUpEdit rLueProjeDurum = new RepositoryItemLookUpEdit();
                BelgeUtil.Inits.ProjeDurumGetir(rLueProjeDurum);

                PivotGridField fieldPeriyotTipi = new PivotGridField();
                fieldPeriyotTipi.Area = PivotArea.FilterArea;
                fieldPeriyotTipi.AreaIndex = 0;
                fieldPeriyotTipi.Caption = "Periyot Tipi";
                fieldPeriyotTipi.FieldName = "PeriyotTipi";
                fieldPeriyotTipi.Name = "fieldPeriyotTipi";


                PivotGridField fieldPeriyotYil = new PivotGridField();
                fieldPeriyotYil.Area = PivotArea.RowArea;
                fieldPeriyotYil.AreaIndex = 1;
                fieldPeriyotYil.Caption = "Periyot Yil";
                fieldPeriyotYil.FieldName = "PeriyotYil";
                fieldPeriyotYil.Name = "fieldPeriyotYil";
                fieldPeriyotYil.GroupInterval = PivotGroupInterval.DateYear;


                PivotGridField fieldPeriyotAy = new PivotGridField();
                fieldPeriyotAy.Area = PivotArea.RowArea;
                fieldPeriyotAy.AreaIndex = 2;
                fieldPeriyotAy.Caption = "Periyot Ay";
                fieldPeriyotAy.FieldName = "PeriyotAy";
                fieldPeriyotAy.Name = "fieldPeriyotAy";
                fieldPeriyotAy.GroupInterval = PivotGroupInterval.DateMonth;


                PivotGridField fieldRowID = new PivotGridField();
                fieldRowID.Area = PivotArea.FilterArea;
                fieldRowID.AreaIndex = 3;
                fieldRowID.Caption = "Dosya Sayýsý";
                fieldRowID.FieldName = "RowID";
                fieldRowID.Name = "fieldRowID";
                fieldRowID.Visible = false;
                fieldRowID.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;


                PivotGridField fieldFoyID = new PivotGridField();
                fieldFoyID.Area = PivotArea.FilterArea;
                fieldFoyID.AreaIndex = 4;
                fieldFoyID.Caption = "Foy ID";
                fieldFoyID.FieldName = "FoyID";
                fieldFoyID.Name = "fieldFoyID";
                fieldFoyID.Visible = false;


                PivotGridField fieldFoyNo = new PivotGridField();
                fieldFoyNo.Area = PivotArea.FilterArea;
                fieldFoyNo.AreaIndex = 5;
                fieldFoyNo.Caption = "Foy No";
                fieldFoyNo.FieldName = "FoyNo";
                fieldFoyNo.Name = "fieldFoyNo";
                fieldFoyNo.Visible = false;


                PivotGridField fieldDurumID = new PivotGridField();
                fieldDurumID.Area = PivotArea.RowArea;
                fieldDurumID.AreaIndex = 6;
                fieldDurumID.Caption = "Durum";
                fieldDurumID.FieldName = "DurumID";
                fieldDurumID.Name = "fieldDurumID";
                fieldDurumID.Visible = false;


                PivotGridField fieldPeriyotTipi1 = new PivotGridField();
                fieldPeriyotTipi1.Area = PivotArea.FilterArea;
                fieldPeriyotTipi1.AreaIndex = 7;
                fieldPeriyotTipi1.Caption = "Periyot Tipi1";
                fieldPeriyotTipi1.FieldName = "PeriyotTipi1";
                fieldPeriyotTipi1.Name = "fieldPeriyotTipi1";


                PivotGridField fieldPeriyotYil1 = new PivotGridField();
                fieldPeriyotYil1.Area = PivotArea.FilterArea;
                fieldPeriyotYil1.AreaIndex = 8;
                fieldPeriyotYil1.Caption = "Periyot Yil1";
                fieldPeriyotYil1.FieldName = "PeriyotYil1";
                fieldPeriyotYil1.Name = "fieldPeriyotYil1";
                fieldPeriyotYil1.GroupInterval = PivotGroupInterval.DateYear;



                PivotGridField fieldPeriyotAy1 = new PivotGridField();
                fieldPeriyotAy1.Area = PivotArea.FilterArea;
                fieldPeriyotAy1.AreaIndex = 9;
                fieldPeriyotAy1.Caption = "Periyot Ay1";
                fieldPeriyotAy1.FieldName = "PeriyotAy1";
                fieldPeriyotAy1.Name = "fieldPeriyotAy1";
                fieldPeriyotAy1.GroupInterval = PivotGroupInterval.DateMonth;


                PivotGridField fieldSirketKodu = new PivotGridField();
                fieldSirketKodu.Area = PivotArea.FilterArea;
                fieldSirketKodu.AreaIndex = 10;
                fieldSirketKodu.Caption = "Sirket Kodu";
                fieldSirketKodu.FieldName = "SirketKodu";
                fieldSirketKodu.Name = "fieldSirketKodu";


                PivotGridField fieldAlacakliSirket = new PivotGridField();
                fieldAlacakliSirket.Area = PivotArea.RowArea;
                fieldAlacakliSirket.AreaIndex = 11;
                fieldAlacakliSirket.Caption = "Alacakli Sirket";
                fieldAlacakliSirket.FieldName = "AlacakliSirket";
                fieldAlacakliSirket.Name = "fieldAlacakliSirket";


                PivotGridField fieldAlacakliSifatiID = new PivotGridField();
                fieldAlacakliSifatiID.Area = PivotArea.FilterArea;
                fieldAlacakliSifatiID.AreaIndex = 12;
                fieldAlacakliSifatiID.Caption = "Alacaklý Sifatý";
                fieldAlacakliSifatiID.FieldName = "AlacakliSifatiID";
                fieldAlacakliSifatiID.Name = "fieldAlacakliSifatiID";


                PivotGridField fieldSAPMusteriKodu = new PivotGridField();
                fieldSAPMusteriKodu.Area = PivotArea.FilterArea;
                fieldSAPMusteriKodu.AreaIndex = 13;
                fieldSAPMusteriKodu.Caption = "SAP Musteri Kodu";
                fieldSAPMusteriKodu.FieldName = "SAPMusteriKodu";
                fieldSAPMusteriKodu.Name = "fieldSAPMusteriKodu";


                PivotGridField fieldBorclu_Davali = new PivotGridField();
                fieldBorclu_Davali.Area = PivotArea.FilterArea;
                fieldBorclu_Davali.AreaIndex = 14;
                fieldBorclu_Davali.Caption = "Borclu Davali";
                fieldBorclu_Davali.FieldName = "Borclu_Davali";
                fieldBorclu_Davali.Name = "fieldBorclu_Davali";


                PivotGridField fieldBorcluSifatiID = new PivotGridField();
                fieldBorcluSifatiID.Area = PivotArea.FilterArea;
                fieldBorcluSifatiID.AreaIndex = 15;
                fieldBorcluSifatiID.Caption = "Borclu Sýfatý";
                fieldBorcluSifatiID.FieldName = "BorcluSifatiID";
                fieldBorcluSifatiID.Name = "fieldBorcluSifatiID";


                PivotGridField fieldTakipTarihi = new PivotGridField();
                fieldTakipTarihi.Area = PivotArea.RowArea;
                fieldTakipTarihi.AreaIndex = 16;
                fieldTakipTarihi.Caption = "Takip Tarihi";
                fieldTakipTarihi.FieldName = "TakipTarihi";
                fieldTakipTarihi.Name = "fieldTakipTarihi";


                PivotGridField fieldAdliBirimAdliyeID = new PivotGridField();
                fieldAdliBirimAdliyeID.Area = PivotArea.FilterArea;
                fieldAdliBirimAdliyeID.AreaIndex = 17;
                fieldAdliBirimAdliyeID.Caption = "Adli Birim Adliye";
                fieldAdliBirimAdliyeID.FieldName = "AdliBirimAdliyeID";
                fieldAdliBirimAdliyeID.Name = "fieldAdliBirimAdliyeID";


                PivotGridField fieldAdliBirimNoID = new PivotGridField();
                fieldAdliBirimNoID.Area = PivotArea.FilterArea;
                fieldAdliBirimNoID.AreaIndex = 18;
                fieldAdliBirimNoID.Caption = "Adli Birim No";
                fieldAdliBirimNoID.FieldName = "AdliBirimNoID";
                fieldAdliBirimNoID.Name = "fieldAdliBirimNoID";


                PivotGridField fieldAdliBirimGorevID = new PivotGridField();
                fieldAdliBirimGorevID.Area = PivotArea.FilterArea;
                fieldAdliBirimGorevID.AreaIndex = 19;
                fieldAdliBirimGorevID.Caption = "Adli Birim Gorev";
                fieldAdliBirimGorevID.FieldName = "AdliBirimGorevID";
                fieldAdliBirimGorevID.Name = "fieldAdliBirimGorevID";


                PivotGridField fieldEsasNo = new PivotGridField();
                fieldEsasNo.Area = PivotArea.FilterArea;
                fieldEsasNo.AreaIndex = 20;
                fieldEsasNo.Caption = "Esas No";
                fieldEsasNo.FieldName = "EsasNo";
                fieldEsasNo.Name = "fieldEsasNo";


                PivotGridField fieldDurusmaTarihi = new PivotGridField();
                fieldDurusmaTarihi.Area = PivotArea.FilterArea;
                fieldDurusmaTarihi.AreaIndex = 21;
                fieldDurusmaTarihi.Caption = "Durusma Tarihi";
                fieldDurusmaTarihi.FieldName = "DurusmaTarihi";
                fieldDurusmaTarihi.Name = "fieldDurusmaTarihi";
                fieldDurusmaTarihi.GroupInterval = PivotGroupInterval.DateYear;

                PivotGridField fieldDurusmaTarihi2 = new PivotGridField();
                fieldDurusmaTarihi2.Area = PivotArea.FilterArea;
                fieldDurusmaTarihi2.AreaIndex = 21;
                fieldDurusmaTarihi2.Caption = "Durusma Tarihi Ay";
                fieldDurusmaTarihi2.FieldName = "DurusmaTarihi";
                fieldDurusmaTarihi2.Name = "fieldDurusmaTarihi2";
                fieldDurusmaTarihi2.GroupInterval = PivotGroupInterval.DateMonth;


                PivotGridField fieldBuroAdi = new PivotGridField();
                fieldBuroAdi.Area = PivotArea.FilterArea;
                fieldBuroAdi.AreaIndex = 22;
                fieldBuroAdi.Caption = "Buro Adi";
                fieldBuroAdi.FieldName = "BuroAdi";
                fieldBuroAdi.Name = "fieldBuroAdi";


                PivotGridField fieldSorumluAvukat = new PivotGridField();
                fieldSorumluAvukat.Area = PivotArea.FilterArea;
                fieldSorumluAvukat.AreaIndex = 23;
                fieldSorumluAvukat.Caption = "Sorumlu Avukat";
                fieldSorumluAvukat.FieldName = "SorumluAvukat";
                fieldSorumluAvukat.Name = "fieldSorumluAvukat";


                PivotGridField fieldLeheAleyhe = new PivotGridField();
                fieldLeheAleyhe.Area = PivotArea.RowArea;
                fieldLeheAleyhe.AreaIndex = 24;
                fieldLeheAleyhe.Caption = "Lehe Aleyhe";
                fieldLeheAleyhe.FieldName = "LeheAleyhe";
                fieldLeheAleyhe.Name = "fieldLeheAleyhe";


                PivotGridField fieldDosyaTipi = new PivotGridField();
                fieldDosyaTipi.Area = PivotArea.FilterArea;
                fieldDosyaTipi.AreaIndex = 25;
                fieldDosyaTipi.Caption = "Dosya Tipi";
                fieldDosyaTipi.FieldName = "DosyaTipi";
                fieldDosyaTipi.Name = "fieldDosyaTipi";


                PivotGridField fieldTakipKonusu = new PivotGridField();
                fieldTakipKonusu.Area = PivotArea.FilterArea;
                fieldTakipKonusu.AreaIndex = 26;
                fieldTakipKonusu.Caption = "Takip Konusu";
                fieldTakipKonusu.FieldName = "TakipKonusu";
                fieldTakipKonusu.Name = "fieldTakipKonusu";


                PivotGridField fieldKazanmaOrani = new PivotGridField();
                fieldKazanmaOrani.Area = PivotArea.FilterArea;
                fieldKazanmaOrani.AreaIndex = 27;
                fieldKazanmaOrani.Caption = "Kazanma Orani";
                fieldKazanmaOrani.FieldName = "KazanmaOrani";
                fieldKazanmaOrani.Name = "fieldKazanmaOrani";


                PivotGridField fieldBeklenenBitisTarihi = new PivotGridField();
                fieldBeklenenBitisTarihi.Area = PivotArea.FilterArea;
                fieldBeklenenBitisTarihi.AreaIndex = 28;
                fieldBeklenenBitisTarihi.Caption = "Beklenen Bitis Tarihi";
                fieldBeklenenBitisTarihi.FieldName = "BeklenenBitisTarihi";
                fieldBeklenenBitisTarihi.Name = "fieldBeklenenBitisTarihi";


                PivotGridField fieldAlacakAnapara = new PivotGridField();
                fieldAlacakAnapara.Area = PivotArea.DataArea;
                fieldAlacakAnapara.AreaIndex = 29;
                fieldAlacakAnapara.Caption = "Alacak Anapara";
                fieldAlacakAnapara.FieldName = "AlacakAnapara";
                fieldAlacakAnapara.Name = "fieldAlacakAnapara";


                PivotGridField fieldAlacakFaiz = new PivotGridField();
                fieldAlacakFaiz.Area = PivotArea.DataArea;
                fieldAlacakFaiz.AreaIndex = 30;
                fieldAlacakFaiz.Caption = "Alacak Faiz";
                fieldAlacakFaiz.FieldName = "AlacakFaiz";
                fieldAlacakFaiz.Name = "fieldAlacakFaiz";


                PivotGridField fieldAlacakDigerKalemler = new PivotGridField();
                fieldAlacakDigerKalemler.Area = PivotArea.DataArea;
                fieldAlacakDigerKalemler.AreaIndex = 31;
                fieldAlacakDigerKalemler.Caption = "Alacak Diger Kalemler";
                fieldAlacakDigerKalemler.FieldName = "AlacakDigerKalemler";
                fieldAlacakDigerKalemler.Name = "fieldAlacakDigerKalemler";


                PivotGridField fieldToplamVergi = new PivotGridField();
                fieldToplamVergi.Area = PivotArea.DataArea;
                fieldToplamVergi.AreaIndex = 32;
                fieldToplamVergi.Caption = "Toplam Vergi";
                fieldToplamVergi.FieldName = "ToplamVergi";
                fieldToplamVergi.Name = "fieldToplamVergi";


                PivotGridField fieldMasraflar = new PivotGridField();
                fieldMasraflar.Area = PivotArea.DataArea;
                fieldMasraflar.AreaIndex = 33;
                fieldMasraflar.Caption = "Masraflar";
                fieldMasraflar.FieldName = "Masraflar";
                fieldMasraflar.Name = "fieldMasraflar";


                PivotGridField fieldToplamVekalet = new PivotGridField();
                fieldToplamVekalet.Area = PivotArea.FilterArea;
                fieldToplamVekalet.AreaIndex = 34;
                fieldToplamVekalet.Caption = "Toplam Vekalet";
                fieldToplamVekalet.FieldName = "ToplamVekalet";
                fieldToplamVekalet.Name = "fieldToplamVekalet";


                PivotGridField fieldToplamAlacak = new PivotGridField();
                fieldToplamAlacak.Area = PivotArea.FilterArea;
                fieldToplamAlacak.AreaIndex = 35;
                fieldToplamAlacak.Caption = "Toplam Alacak";
                fieldToplamAlacak.FieldName = "ToplamAlacak";
                fieldToplamAlacak.Name = "fieldToplamAlacak";


                PivotGridField fieldRiskTutari = new PivotGridField();
                fieldRiskTutari.Area = PivotArea.FilterArea;
                fieldRiskTutari.AreaIndex = 36;
                fieldRiskTutari.Caption = "Risk Tutari";
                fieldRiskTutari.FieldName = "RiskTutari";
                fieldRiskTutari.Name = "fieldRiskTutari";



                PivotGridField fieldGuncelKarsilik = new PivotGridField();
                fieldGuncelKarsilik.Area = PivotArea.DataArea;
                fieldGuncelKarsilik.AreaIndex = 37;
                fieldGuncelKarsilik.Caption = "Guncel Karsilik";
                fieldGuncelKarsilik.FieldName = "GuncelKarsilik";
                fieldGuncelKarsilik.Name = "fieldGuncelKarsilik";



                PivotGridField fieldTakyidatVergiBorclari = new PivotGridField();
                fieldTakyidatVergiBorclari.Area = PivotArea.FilterArea;
                fieldTakyidatVergiBorclari.AreaIndex = 38;
                fieldTakyidatVergiBorclari.Caption = "Takyidat Vergi Borclari";
                fieldTakyidatVergiBorclari.FieldName = "TakyidatVergiBorclari";
                fieldTakyidatVergiBorclari.Name = "fieldTakyidatVergiBorclari";



                PivotGridField fieldReelKarsilik = new PivotGridField();
                fieldReelKarsilik.Area = PivotArea.FilterArea;
                fieldReelKarsilik.AreaIndex = 39;
                fieldReelKarsilik.Caption = "Reel Karsilik";
                fieldReelKarsilik.FieldName = "ReelKarsilik";
                fieldReelKarsilik.Name = "fieldReelKarsilik";


                PivotGridField fieldOncekiDonemKarsilikTarihi = new PivotGridField();
                fieldOncekiDonemKarsilikTarihi.Area = PivotArea.FilterArea;
                fieldOncekiDonemKarsilikTarihi.AreaIndex = 40;
                fieldOncekiDonemKarsilikTarihi.Caption = "Onceki Donem Karsilik Tarihi";
                fieldOncekiDonemKarsilikTarihi.FieldName = "OncekiDonemKarsilikTarihi";
                fieldOncekiDonemKarsilikTarihi.Name = "fieldOncekiDonemKarsilikTarihi";


                PivotGridField fieldOncekiDonemKarsilikTutari = new PivotGridField();
                fieldOncekiDonemKarsilikTutari.Area = PivotArea.FilterArea;
                fieldOncekiDonemKarsilikTutari.AreaIndex = 41;
                fieldOncekiDonemKarsilikTutari.Caption = "Onceki Donem Karsilik Tutari";
                fieldOncekiDonemKarsilikTutari.FieldName = "OncekiDonemKarsilikTutari";
                fieldOncekiDonemKarsilikTutari.Name = "fieldOncekiDonemKarsilikTutari";


                PivotGridField fieldNakitTeminat = new PivotGridField();
                fieldNakitTeminat.Area = PivotArea.FilterArea;
                fieldNakitTeminat.AreaIndex = 42;
                fieldNakitTeminat.Caption = "Nakit Teminat";
                fieldNakitTeminat.FieldName = "NakitTeminat";
                fieldNakitTeminat.Name = "fieldNakitTeminat";


                PivotGridField fieldTeminatMektubu = new PivotGridField();
                fieldTeminatMektubu.Area = PivotArea.FilterArea;
                fieldTeminatMektubu.AreaIndex = 43;
                fieldTeminatMektubu.Caption = "Teminat Mektubu";
                fieldTeminatMektubu.FieldName = "TeminatMektubu";
                fieldTeminatMektubu.Name = "fieldTeminatMektubu";


                PivotGridField fieldIpotekTutari = new PivotGridField();
                fieldIpotekTutari.Area = PivotArea.FilterArea;
                fieldIpotekTutari.AreaIndex = 44;
                fieldIpotekTutari.Caption = "Ipotek Tutari";
                fieldIpotekTutari.FieldName = "IpotekTutari";
                fieldIpotekTutari.Name = "fieldIpotekTutari";


                PivotGridField fieldCekToplami = new PivotGridField();
                fieldCekToplami.Area = PivotArea.FilterArea;
                fieldCekToplami.AreaIndex = 45;
                fieldCekToplami.Caption = "Cek Toplami";
                fieldCekToplami.FieldName = "CekToplami";
                fieldCekToplami.Name = "fieldCekToplami";


                PivotGridField fieldSenetToplami = new PivotGridField();
                fieldSenetToplami.Area = PivotArea.FilterArea;
                fieldSenetToplami.AreaIndex = 46;
                fieldSenetToplami.Caption = "Senet Toplami";
                fieldSenetToplami.FieldName = "SenetToplami";
                fieldSenetToplami.Name = "fieldSenetToplami";


                PivotGridField fieldKefaletToplami = new PivotGridField();
                fieldKefaletToplami.Area = PivotArea.FilterArea;
                fieldKefaletToplami.AreaIndex = 47;
                fieldKefaletToplami.Caption = "Kefalet Toplami";
                fieldKefaletToplami.FieldName = "KefaletToplami";
                fieldKefaletToplami.Name = "fieldKefaletToplami";


                PivotGridField fieldRehinTutari = new PivotGridField();
                fieldRehinTutari.Area = PivotArea.FilterArea;
                fieldRehinTutari.AreaIndex = 48;
                fieldRehinTutari.Caption = "Rehin Tutari";
                fieldRehinTutari.FieldName = "RehinTutari";
                fieldRehinTutari.Name = "fieldRehinTutari";


                PivotGridField field_GrupTeminat1 = new PivotGridField();
                field_GrupTeminat1.Area = PivotArea.FilterArea;
                field_GrupTeminat1.AreaIndex = 49;
                field_GrupTeminat1.Caption = "Grup Teminat1";
                field_GrupTeminat1.FieldName = "GrupTeminat1";
                field_GrupTeminat1.Name = "field_GrupTeminat1";


                PivotGridField field_GrupTeminat2 = new PivotGridField();
                field_GrupTeminat2.Area = PivotArea.FilterArea;
                field_GrupTeminat2.AreaIndex = 50;
                field_GrupTeminat2.Caption = "Grup Teminat2";
                field_GrupTeminat2.FieldName = "GrupTeminat2";
                field_GrupTeminat2.Name = "field_GrupTeminat2";


                PivotGridField fieldToplamEkspertizDegeri = new PivotGridField();
                fieldToplamEkspertizDegeri.Area = PivotArea.FilterArea;
                fieldToplamEkspertizDegeri.AreaIndex = 51;
                fieldToplamEkspertizDegeri.Caption = "Toplam Ekspertiz Degeri";
                fieldToplamEkspertizDegeri.FieldName = "ToplamEkspertizDegeri";
                fieldToplamEkspertizDegeri.Name = "fieldToplamEkspertizDegeri";


                PivotGridField fieldToplamTahsilat = new PivotGridField();
                fieldToplamTahsilat.Area = PivotArea.DataArea;
                fieldToplamTahsilat.AreaIndex = 52;
                fieldToplamTahsilat.Caption = "Toplam Tahsilat";
                fieldToplamTahsilat.FieldName = "ToplamTahsilat";
                fieldToplamTahsilat.Name = "fieldToplamTahsilat";


                PivotGridField fieldTahsilatAnapara = new PivotGridField();
                fieldTahsilatAnapara.Area = PivotArea.FilterArea;
                fieldTahsilatAnapara.AreaIndex = 53;
                fieldTahsilatAnapara.Caption = "Tahsilat Anapara";
                fieldTahsilatAnapara.FieldName = "TahsilatAnapara";
                fieldTahsilatAnapara.Name = "fieldTahsilatAnapara";


                PivotGridField fieldTahsilatFaiz = new PivotGridField();
                fieldTahsilatFaiz.Area = PivotArea.FilterArea;
                fieldTahsilatFaiz.AreaIndex = 54;
                fieldTahsilatFaiz.Caption = "Tahsilat Faiz";
                fieldTahsilatFaiz.FieldName = "TahsilatFaiz";
                fieldTahsilatFaiz.Name = "fieldTahsilatFaiz";


                PivotGridField fieldTahsilatDiger = new PivotGridField();
                fieldTahsilatDiger.Area = PivotArea.FilterArea;
                fieldTahsilatDiger.AreaIndex = 55;
                fieldTahsilatDiger.Caption = "Tahsilat Diger";
                fieldTahsilatDiger.FieldName = "TahsilatDiger";
                fieldTahsilatDiger.Name = "fieldTahsilatDiger";


                PivotGridField fieldAciklama = new PivotGridField();
                fieldAciklama.Area = PivotArea.FilterArea;
                fieldAciklama.AreaIndex = 56;
                fieldAciklama.Caption = "Aciklama";
                fieldAciklama.FieldName = "Aciklama";
                fieldAciklama.Name = "fieldAciklama";

                #endregion

                #region []

                PivotGridField[] dizi = new[]
                        {
                            fieldPeriyotTipi,
                            fieldPeriyotYil,
                            fieldPeriyotAy,
                            fieldRowID,
                            fieldFoyID,
                            fieldFoyNo,
                            fieldDurumID,
                            fieldPeriyotTipi1,
                            fieldPeriyotYil1,
                            fieldPeriyotAy1,
                            fieldSirketKodu,
                            fieldAlacakliSirket,
                            fieldAlacakliSifatiID,
                            fieldSAPMusteriKodu,
                            fieldBorclu_Davali,
                            fieldBorcluSifatiID,
                            fieldTakipTarihi,
                            fieldAdliBirimAdliyeID,
                            fieldAdliBirimNoID,
                            fieldAdliBirimGorevID,
                            fieldEsasNo,
                            fieldDurusmaTarihi,
                            fieldBuroAdi,
                            fieldSorumluAvukat,
                            fieldLeheAleyhe,
                            fieldDosyaTipi,
                            fieldTakipKonusu,
                            fieldKazanmaOrani,
                            fieldBeklenenBitisTarihi,
                            fieldAlacakAnapara,
                            fieldAlacakFaiz,
                            fieldAlacakDigerKalemler,
                            fieldToplamVergi,
                            fieldMasraflar,
                            fieldToplamVekalet,
                            fieldToplamAlacak,
                            fieldRiskTutari,
                            fieldGuncelKarsilik,
                            fieldTakyidatVergiBorclari,
                            fieldReelKarsilik,
                            fieldOncekiDonemKarsilikTarihi,
                            fieldOncekiDonemKarsilikTutari,
                            fieldNakitTeminat,
                            fieldTeminatMektubu,
                            fieldIpotekTutari,
                            fieldCekToplami,
                            fieldSenetToplami,
                            fieldKefaletToplami,
                            fieldRehinTutari,
                            field_GrupTeminat1,
                            field_GrupTeminat2,
                            fieldToplamEkspertizDegeri,
                            fieldToplamTahsilat,
                            fieldTahsilatAnapara,
                            fieldTahsilatFaiz,
                            fieldTahsilatDiger,
                            fieldAciklama
                        };

                #endregion

                return dizi;
            }
        }
    }
}