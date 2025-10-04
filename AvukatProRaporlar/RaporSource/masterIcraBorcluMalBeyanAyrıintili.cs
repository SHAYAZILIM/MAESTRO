using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    internal class masterIcraBorcluMalBeyanAyrıintili
    {

        public GridColumn[] GetGridColumns()
        {
            #region Field & Properties

            GridColumn colID = new GridColumn();
            colID.VisibleIndex = 0;
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = true;

            GridColumn colICRA_FOY_NO = new GridColumn();
            colICRA_FOY_NO.VisibleIndex = 1;
            colICRA_FOY_NO.FieldName = "ICRA_FOY_NO";
            colICRA_FOY_NO.Name = "colICRA_FOY_NO";
            colICRA_FOY_NO.Visible = true;

            GridColumn colESAS_NO = new GridColumn();
            colESAS_NO.VisibleIndex = 2;
            colESAS_NO.FieldName = "ESAS_NO";
            colESAS_NO.Name = "colESAS_NO";
            colESAS_NO.Visible = true;

            GridColumn colICRA_ADLIYE = new GridColumn();
            colICRA_ADLIYE.VisibleIndex = 3;
            colICRA_ADLIYE.FieldName = "ICRA_ADLIYE";
            colICRA_ADLIYE.Name = "colICRA_ADLIYE";
            colICRA_ADLIYE.Visible = true;

            GridColumn colICRA_ADLI_BIRIM_NO = new GridColumn();
            colICRA_ADLI_BIRIM_NO.VisibleIndex = 4;
            colICRA_ADLI_BIRIM_NO.FieldName = "ICRA_ADLI_BIRIM_NO";
            colICRA_ADLI_BIRIM_NO.Name = "colICRA_ADLI_BIRIM_NO";
            colICRA_ADLI_BIRIM_NO.Visible = true;

            GridColumn colBORCLU = new GridColumn();
            colBORCLU.VisibleIndex = 5;
            colBORCLU.FieldName = "BORCLU";
            colBORCLU.Name = "colBORCLU";
            colBORCLU.Visible = true;

            GridColumn colMAL_BEYANI_GECERLI_MI = new GridColumn();
            colMAL_BEYANI_GECERLI_MI.VisibleIndex = 6;
            colMAL_BEYANI_GECERLI_MI.FieldName = "MAL_BEYANI_GECERLI_MI";
            colMAL_BEYANI_GECERLI_MI.Name = "colMAL_BEYANI_GECERLI_MI";
            colMAL_BEYANI_GECERLI_MI.Visible = true;

            GridColumn colMAL_BEYAN_TARIHI = new GridColumn();
            colMAL_BEYAN_TARIHI.VisibleIndex = 7;
            colMAL_BEYAN_TARIHI.FieldName = "MAL_BEYAN_TARIHI";
            colMAL_BEYAN_TARIHI.Name = "colMAL_BEYAN_TARIHI";
            colMAL_BEYAN_TARIHI.Visible = true;

            GridColumn colITIRAZDAN_ONCE_SONRA = new GridColumn();
            colITIRAZDAN_ONCE_SONRA.VisibleIndex = 8;
            colITIRAZDAN_ONCE_SONRA.FieldName = "ITIRAZDAN_ONCE_SONRA";
            colITIRAZDAN_ONCE_SONRA.Name = "colITIRAZDAN_ONCE_SONRA";
            colITIRAZDAN_ONCE_SONRA.Visible = true;

            GridColumn colSONRADAN_EDINILEN_MAL_ICIN_EK_BEYAN_MI = new GridColumn();
            colSONRADAN_EDINILEN_MAL_ICIN_EK_BEYAN_MI.VisibleIndex = 9;
            colSONRADAN_EDINILEN_MAL_ICIN_EK_BEYAN_MI.FieldName = "SONRADAN_EDINILEN_MAL_ICIN_EK_BEYAN_MI";
            colSONRADAN_EDINILEN_MAL_ICIN_EK_BEYAN_MI.Name = "colSONRADAN_EDINILEN_MAL_ICIN_EK_BEYAN_MI";
            colSONRADAN_EDINILEN_MAL_ICIN_EK_BEYAN_MI.Visible = true;

            GridColumn colGECIKMIS_MI = new GridColumn();
            colGECIKMIS_MI.VisibleIndex = 10;
            colGECIKMIS_MI.FieldName = "GECIKMIS_MI";
            colGECIKMIS_MI.Name = "colGECIKMIS_MI";
            colGECIKMIS_MI.Visible = true;

            GridColumn colDAVASI_ACILDI_MI = new GridColumn();
            colDAVASI_ACILDI_MI.VisibleIndex = 11;
            colDAVASI_ACILDI_MI.FieldName = "DAVASI_ACILDI_MI";
            colDAVASI_ACILDI_MI.Name = "colDAVASI_ACILDI_MI";
            colDAVASI_ACILDI_MI.Visible = true;

            GridColumn colDAVA_FOY_NO = new GridColumn();
            colDAVA_FOY_NO.VisibleIndex = 12;
            colDAVA_FOY_NO.FieldName = "DAVA_FOY_NO";
            colDAVA_FOY_NO.Name = "colDAVA_FOY_NO";
            colDAVA_FOY_NO.Visible = true;

            GridColumn colDAVA_TARIHI = new GridColumn();
            colDAVA_TARIHI.VisibleIndex = 13;
            colDAVA_TARIHI.FieldName = "DAVA_TARIHI";
            colDAVA_TARIHI.Name = "colDAVA_TARIHI";
            colDAVA_TARIHI.Visible = true;

            GridColumn colMAHKEME = new GridColumn();
            colMAHKEME.VisibleIndex = 14;
            colMAHKEME.FieldName = "MAHKEME";
            colMAHKEME.Name = "colMAHKEME";
            colMAHKEME.Visible = true;

            GridColumn colGÖREV = new GridColumn();
            colGÖREV.VisibleIndex = 15;
            colGÖREV.FieldName = "GÖREV";
            colGÖREV.Name = "colGÖREV";
            colGÖREV.Visible = true;

            GridColumn colDAVA_BIRIM_NO = new GridColumn();
            colDAVA_BIRIM_NO.VisibleIndex = 16;
            colDAVA_BIRIM_NO.FieldName = "DAVA_BIRIM_NO";
            colDAVA_BIRIM_NO.Name = "colDAVA_BIRIM_NO";
            colDAVA_BIRIM_NO.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 17;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 18;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            GridColumn colICRA_BOLUM_ID = new GridColumn();
            colICRA_BOLUM_ID.VisibleIndex = 19;
            colICRA_BOLUM_ID.FieldName = "ICRA_BOLUM_ID";
            colICRA_BOLUM_ID.Name = "colICRA_BOLUM_ID";
            colICRA_BOLUM_ID.Visible = true;

            GridColumn colDAVA_BOLUM_ID = new GridColumn();
            colDAVA_BOLUM_ID.VisibleIndex = 20;
            colDAVA_BOLUM_ID.FieldName = "DAVA_BOLUM_ID";
            colDAVA_BOLUM_ID.Name = "colDAVA_BOLUM_ID";
            colDAVA_BOLUM_ID.Visible = true;

            #endregion Field & Properties

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			colID,
			colICRA_FOY_NO,
			colESAS_NO,
			colICRA_ADLIYE,
			colICRA_ADLI_BIRIM_NO,
			colBORCLU,
			colMAL_BEYANI_GECERLI_MI,
			colMAL_BEYAN_TARIHI,
			colITIRAZDAN_ONCE_SONRA,
			colSONRADAN_EDINILEN_MAL_ICIN_EK_BEYAN_MI,
			colGECIKMIS_MI,
			colDAVASI_ACILDI_MI,
			colDAVA_FOY_NO,
			colDAVA_TARIHI,
			colMAHKEME,
			colGÖREV,
			colDAVA_BIRIM_NO,
			colSUBE_KOD_ID,
			colKONTROL_KIM_ID,
			colICRA_BOLUM_ID,
			colDAVA_BOLUM_ID,
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

            #endregion Column Caption

            return dizi;
        }
        
        private Dictionary<string, string> GetCaptionDictinory()
        {
            Dictionary<string, string> dicFieldCaption = new Dictionary<string, string>();

            #region Caption Edit

            dicFieldCaption.Add("ID", "ID");
            dicFieldCaption.Add("ICRA_FOY_NO", "Foy No");
            dicFieldCaption.Add("ESAS_NO", "Esas No");
            dicFieldCaption.Add("ICRA_ADLIYE", "Adliye");
            dicFieldCaption.Add("ICRA_ADLI_BIRIM_NO", "Birim No");
            dicFieldCaption.Add("BORCLU", "Borclu");
            dicFieldCaption.Add("MAL_BEYANI_GECERLI_MI", "Mal Beyan Geçerli");
            dicFieldCaption.Add("MAL_BEYAN_TARIHI", "Mal Beyan T.");
            dicFieldCaption.Add("ITIRAZDAN_ONCE_SONRA", "İtirazdan Önce");
            dicFieldCaption.Add("SONRADAN_EDINILEN_MAL_ICIN_EK_BEYAN_MI", "Sonradan Edinel Mal İçin Ek Beyan");
            dicFieldCaption.Add("GECIKMIS_MI", "Gecikmiş");
            dicFieldCaption.Add("DAVASI_ACILDI_MI", "Davası Açıldı");
            dicFieldCaption.Add("DAVA_FOY_NO", "Dava Foy No");
            dicFieldCaption.Add("DAVA_TARIHI", "Dava T.");
            dicFieldCaption.Add("MAHKEME", "Mahkeme");
            dicFieldCaption.Add("GÖREV", "Görev");
            dicFieldCaption.Add("DAVA_BIRIM_NO", "Birim No");
            dicFieldCaption.Add("SUBE_KOD_ID", "Büro");
            dicFieldCaption.Add("KONTROL_KIM_ID", "Kullanıcı");
            dicFieldCaption.Add("ICRA_BOLUM_ID", "Dava Bölüm");
            dicFieldCaption.Add("DAVA_BOLUM_ID", "Icra Bölüm");

            #endregion Caption Edit

            return dicFieldCaption;
        }

        private Dictionary<string, RepositoryItem> GetRepositoryItemDictinory()
        {
            RepositoryItemLookUpEdit rlueDoviz = new RepositoryItemLookUpEdit();

            // Inits.DovizTipGetir(rlueDoviz);

            Dictionary<string, RepositoryItem> sozluk = new Dictionary<string, RepositoryItem>();

            #region Add item

            sozluk.Add("DovizId", InitsEx.DovizTipGetir);

            sozluk.Add("SUBE_KOD_ID", InitsEx.SubeKod);
            sozluk.Add("KONTROL_KIM_ID", InitsEx.KontrolKim);
            sozluk.Add("ICRA_BOLUM_ID", InitsEx.SegmnetBolumGetir);
            sozluk.Add("DAVA_BOLUM_ID", InitsEx.SegmnetBolumGetir);

            #endregion Add item

            return sozluk;
        }
    }
}