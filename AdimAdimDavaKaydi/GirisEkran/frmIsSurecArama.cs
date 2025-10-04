using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using AvukatProLib.Extras;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace AdimAdimDavaKaydi.GirisEkran
{
    public partial class frmIsSurecArama : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        private List<AvukatProLib.Arama.AV001_TDI_BIL_IS_TAMAMLANMA_SURE> _MyDataSource;

        public frmIsSurecArama()
        {
            InitializeComponent();
            chartControl1.DataSource = pivotGridControl1;
            chartControl1.SeriesDataMember = "Series";
            chartControl1.SeriesTemplate.ArgumentDataMember = "Arguments";

            chartControl1.SeriesTemplate.ValueDataMembers.AddRange(new[] { "Values" });

            chartControl1.SeriesTemplate.LegendPointOptions.PointView =
                DevExpress.XtraCharts.PointView.ArgumentAndValues;
        }

        #region AramaKriterler

        private int? Adliye;
        private int? BirimGorev;
        private int? BirimNo;
        private DateTime? DetayBaslangicZmn;
        private DateTime? DetayBitisZmn;
        private int? DetayIsSozlesme;
        private int? DetayIsSurec;
        private int? Dosya;
        private string EsasNo;
        private DateTime? IsBaslangicTrh;

        private DateTime? IsBitisTrh;

        private bool? IsDurum;

        private int? IsKategori;

        private int? IsMuhatab;

        private int? IsPlanlayan;

        private Modul? mod;

        private bool? Muhasebelestirlmis;

        private DateTime? OnGrlnBitisTrh;

        private int? SorumluCari;

        private void chIsDurum_CheckedChanged(object sender, EventArgs e)
        {
            if (chIsDurum.Checked)
                IsDurum = chIsDurum.Checked;
            else
                IsDurum = false;
        }

        private void chMuhasebelestirlmis_CheckedChanged(object sender, EventArgs e)
        {
            if (chMuhasebelestirlmis.Checked)
                Muhasebelestirlmis = chMuhasebelestirlmis.Checked;
            else
                Muhasebelestirlmis = false;
        }

        private void dtBaslangic_EditValueChanged(object sender, EventArgs e)
        {
            if (dtBaslangic.EditValue != null)
                DetayBaslangicZmn = (DateTime?)dtBaslangic.EditValue;
            else
                DetayBaslangicZmn = null;
        }

        private void dtBitisZmn_EditValueChanged(object sender, EventArgs e)
        {
            if (dtBitisZmn.EditValue != null)
                DetayBitisZmn = (DateTime?)dtBitisZmn.EditValue;
            else
                DetayBitisZmn = null;
        }

        private void dtIsBaslangicT_EditValueChanged(object sender, EventArgs e)
        {
            if (dtIsBaslangicT.EditValue != null)
                IsBaslangicTrh = (DateTime?)dtIsBaslangicT.EditValue;
            else
                IsBaslangicTrh = null;
        }

        private void dtIsBitisT_EditValueChanged(object sender, EventArgs e)
        {
            if (dtIsBitisT.EditValue != null)
                IsBitisTrh = (DateTime?)dtIsBitisT.EditValue;
            else
                IsBitisTrh = null;
        }

        private void dtIsOngorulenBitisT_EditValueChanged(object sender, EventArgs e)
        {
            if (dtIsOngorulenBitisT.EditValue != null)
                OnGrlnBitisTrh = (DateTime?)dtIsOngorulenBitisT.EditValue;
            else
                OnGrlnBitisTrh = null;
        }

        private void lueAdliye_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAdliye.EditValue != null)
                Adliye = (int?)lueAdliye.EditValue;
            else
                Adliye = null;
        }

        private void lueDosya_EditValueChanged(object sender, EventArgs e)
        {
            if (lueDosya.EditValue != null)
                Dosya = (int?)lueDosya.EditValue;
            else
                Dosya = null;
        }

        private void lueGorev_EditValueChanged(object sender, EventArgs e)
        {
            if (lueGorev.EditValue != null)
                BirimGorev = (int?)lueGorev.EditValue;
            else
                BirimGorev = null;
        }

        private void lueIsSozlesme_EditValueChanged(object sender, EventArgs e)
        {
            if (lueIsSozlesme.EditValue != null)
                DetayIsSozlesme = Convert.ToInt32(lueIsSozlesme.EditValue);
            else
                DetayIsSozlesme = null;
        }

        private void lueIsSurec_EditValueChanged(object sender, EventArgs e)
        {
            if (lueIsSurec.EditValue != null)
                DetayIsSurec = (int?)lueIsSurec.EditValue;
            else
                DetayIsSurec = null;
        }

        private void lueKategori_EditValueChanged(object sender, EventArgs e)
        {
            if (lueKategori.EditValue != null)
                IsKategori = (int?)lueKategori.EditValue;
            else
                IsKategori = null;
        }

        private void lueModul_EditValueChanged(object sender, EventArgs e)
        {
            if (lueModul.EditValue != null)
                mod = (Modul?)Convert.ToInt32(lueModul.EditValue);
            else
                mod = null;

            lueDosya.Properties.DataSource = BelgeUtil.Inits.DosyaDoldur(lueModul.Text);
            lueDosya.Properties.DisplayMember = "FOY_NO";
            lueDosya.Properties.ValueMember = "ID";
        }

        private void lueMuhatab_EditValueChanged(object sender, EventArgs e)
        {
            if (lueMuhatab.EditValue != null)
                IsMuhatab = (int?)lueMuhatab.EditValue;
            else
                IsMuhatab = null;
        }

        private void lueNo_EditValueChanged(object sender, EventArgs e)
        {
            if (lueNo.EditValue != null)
                BirimNo = (int?)lueNo.EditValue;
            else
                BirimNo = null;
        }

        private void luePlanlayan_EditValueChanged(object sender, EventArgs e)
        {
            if (luePlanlayan.EditValue != null)
                IsPlanlayan = (int?)luePlanlayan.EditValue;
            else
                IsPlanlayan = null;
        }

        private void lueSorumlu_EditValueChanged(object sender, EventArgs e)
        {
            if (lueSorumlu.EditValue != null)
                SorumluCari = (int?)lueSorumlu.EditValue;
            else
                SorumluCari = null;
        }

        private void txtEsasNo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEsasNo.Text))
                EsasNo = txtEsasNo.Text;
            else
                EsasNo = null;
        }

        #endregion AramaKriterler

        public List<AvukatProLib.Arama.AV001_TDI_BIL_IS_TAMAMLANMA_SURE> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                gridControl1.DataSource = value;
            }
        }

        public void DurumAciklamaGetir(RepositoryItemLookUpEdit lue)
        {
            DataTable dt = new DataTable("HacizChildTip");
            dt.Columns.Add("DEGER");
            dt.Columns.Add("ACIKLAMA");
            foreach (DurumAciklama tipi in Enum.GetValues(typeof(DurumAciklama)))
            {
                dt.Rows.Add(tipi, tipi.ToString().Replace("_", " "));
            }
            lue.DataSource = dt;
            lue.DisplayMember = "ACIKLAMA";
            lue.NullText = "Seç";
            lue.ValueMember = "DEGER";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Durum Açıklama"));
        }

        private static void FormlariTemizle(Control.ControlCollection coll)
        {
            try
            {
                foreach (Control con in coll)
                {
                    if (con is LookUpEdit)
                    {
                        (con as LookUpEdit).EditValue = null;
                    }
                    else if (con is DateEdit)
                    {
                        (con).ResetText();
                    }

                    else if (con is SpinEdit)
                    {
                        ((SpinEdit)con).EditValue = null;
                    }
                    else if (con is CheckEdit)
                    {
                        ((CheckEdit)con).Checked = false;
                    }
                    else if (con is TextEdit)
                    {
                        con.Text = string.Empty;
                    }
                }
            }
            catch
            {
            }
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            MyDataSource = AvukatProLib.Arama.R_IS_ARAMA_SURECSorgu.GetByFiltreView(IsDurum, IsBaslangicTrh,
                                                                                    OnGrlnBitisTrh, IsBitisTrh,
                                                                                    IsKategori, SorumluCari,
                                                                                    DetayBitisZmn, DetayBaslangicZmn,
                                                                                    DetayIsSurec, DetayIsSozlesme,
                                                                                    Muhasebelestirlmis, mod, Dosya,
                                                                                    Adliye, BirimGorev, BirimNo, EsasNo,
                                                                                    IsMuhatab, IsPlanlayan,
                                                                                    AvukatProLib.Kimlik.SirketBilgisi.
                                                                                        ConStr);
            pivotGridControl1.DataSource = null;
            pivotGridControl1.Fields.Clear();
            pivotGridControl1.Fields.AddRange(PivotGridColumns.GetPivotFields());
            pivotGridControl1.DataSource = MyDataSource;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            FormlariTemizle(layoutControl1.Controls);
            gridControl1.DataSource = null;
        }

        private void frmIsSurecArama_Load(object sender, EventArgs e)
        {
            InitsDoldur();
        }

        private void InitsDoldur()
        {
            lueAdliye.Properties.NullText = "Seç";
            lueModul.Properties.NullText = "Seç";
            lueGorev.Properties.NullText = "Seç";
            lueIsSurec.Properties.NullText = "Seç";
            lueKategori.Properties.NullText = "Seç";
            lueMuhatab.Properties.NullText = "Seç";
            lueNo.Properties.NullText = "Seç";
            luePlanlayan.Properties.NullText = "Seç";
            lueSorumlu.Properties.NullText = "Seç";
            rspFiyat.NullText = "Seç";
            rLueadliBirimNo.NullText = "Seç";
            rLueAdliye.NullText = "Seç";
            rLueBuro.NullText = "Seç";
            rLueDoviz.NullText = "Seç";
            rLueGorev.NullText = "Seç";
            rLueDurmaNeden.NullText = "Seç";
            rLueKlasor.NullText = "Seç";
            rLueKullanıcı.NullText = "Seç";
            lueIsSozlesme.Properties.NullText = "Seç";
            lueAdliye.Enter += BelgeUtil.Inits.AdliBirimAdliyeGetir_Enter;
            lueModul.Enter += BelgeUtil.Inits.ModulKodGetir_Enter;
            lueGorev.Enter += BelgeUtil.Inits.AdliBirimGorevGetir_Enter;
            BelgeUtil.Inits.IsSozlesmeGetir(lueIsSozlesme);
            lueIsSurec.Enter += BelgeUtil.Inits.IsSurecGetir_Enter;
            lueKategori.Enter += BelgeUtil.Inits.MuhasebeHareketAltKategori_Enter;
            lueMuhatab.Enter += BelgeUtil.Inits.perCariGetir_Enter;
            lueNo.Enter += BelgeUtil.Inits.AdliBirimGorevGetir_Enter;
            luePlanlayan.Enter += BelgeUtil.Inits.perCariGetir_Enter;
            lueSorumlu.Enter += BelgeUtil.Inits.perCariGetir_Enter;
            BelgeUtil.Inits.ParaBicimiAyarla(rspFiyat);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueadliBirimNo);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliye);
            BelgeUtil.Inits.SubeKodGetir(rLueBuro);
            BelgeUtil.Inits.DovizTipGetir(rLueDoviz);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueGorev);
            DurumAciklamaGetir(rLueDurmaNeden);
            BelgeUtil.Inits.ProjeAdGetir(rLueKlasor);
            BelgeUtil.Inits.KontrolKimGetir(rLueKullanıcı);
        }

        private void lookGrafikSecimi_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                chartControl1.SeriesTemplate.ChangeView((DevExpress.XtraCharts.ViewType)lookGrafikSecimi.EditValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int suremili = 0;
        private void gridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            //SURE_ST
            GridColumnSummaryItem item = e.Item as GridColumnSummaryItem;
            GridView view = sender as GridView;
            if (Equals("SURE_ST", item.FieldName))
            {
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    try
                    {
                        var splt = view.GetRowCellValue(e.RowHandle, "SURE_ST").ToString().Split(':');
                        var saat = 0;
                        var dak = 0;
                        var saniye = 0;
                        int.TryParse(splt[0], out saat);
                        int.TryParse(splt[1], out dak);
                        int.TryParse(splt[2], out saniye);
                        DateTime tm = new DateTime(2000, 01, 01, saat, dak, saniye);
                        suremili += Convert.ToInt32(tm.TimeOfDay.TotalMilliseconds);
                    }
                    catch
                    {
                    }
                }
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    TimeSpan c = new TimeSpan();
                    c = TimeSpan.FromMilliseconds(suremili);
                    e.TotalValue = string.Format("{0:00}:{1:00}:{2:00}", c.Hours, c.Minutes, c.Seconds);
                }
            }
        }

        private void pivotGridControl1_CustomSummary(object sender, PivotGridCustomSummaryEventArgs e)
        {
            //SURE_ST
            if (e.DataField != null && e.DataField.FieldName == "SURE_ST")
            {
                double Sum = 0;
                PivotDrillDownDataSource ds = e.CreateDrillDownDataSource();
                if (ds != null)
                {
                    for (int i = 0; i < ds.RowCount; i++)
                    {
                        PivotDrillDownDataRow row = ds[i];
                        if (row != null)
                        {
                            if (row[e.DataField] != null)
                            {
                                var splt = row[e.DataField].ToString().Split(':');
                                var saat = 0;
                                var dak = 0;
                                var saniye = 0;
                                try
                                {
                                    int.TryParse(splt[0], out saat);
                                    int.TryParse(splt[1], out dak);
                                    int.TryParse(splt[2], out saniye);
                                }
                                catch { }
                                DateTime tm = new DateTime(2000, 01, 01, saat, dak, saniye);
                                Sum += Convert.ToInt32(tm.TimeOfDay.TotalMilliseconds);
                            }
                        }
                        e.CustomValue = Sum;
                    }
                }
            }
        }
    }

    public class PivotGridColumns
    {
        public static PivotGridField[] GetPivotFields()
        {
            #region EditItem

            RepositoryItemLookUpEdit rLueKategori = new RepositoryItemLookUpEdit();
            RepositoryItemLookUpEdit rLueKlasor = new RepositoryItemLookUpEdit();
            RepositoryItemLookUpEdit rLueAdliye = new RepositoryItemLookUpEdit();
            RepositoryItemLookUpEdit rLueadliBirimNo = new RepositoryItemLookUpEdit();
            RepositoryItemSpinEdit rspFiyat = new RepositoryItemSpinEdit();
            RepositoryItemLookUpEdit rLueDoviz = new RepositoryItemLookUpEdit();
            RepositoryItemLookUpEdit rLueKullanıcı = new RepositoryItemLookUpEdit();
            RepositoryItemLookUpEdit rLueBuro = new RepositoryItemLookUpEdit();
            RepositoryItemLookUpEdit rLueGorev = new RepositoryItemLookUpEdit();
            BelgeUtil.Inits.ParaBicimiAyarla(rspFiyat);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueadliBirimNo);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliye);
            BelgeUtil.Inits.SubeKodGetir(rLueBuro);
            BelgeUtil.Inits.DovizTipGetir(rLueDoviz);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueGorev);
            BelgeUtil.Inits.MuhasebeHareketAltKategori(rLueKategori);
            BelgeUtil.Inits.ProjeAdGetir(rLueKlasor);
            BelgeUtil.Inits.KontrolKimGetir(rLueKullanıcı);

            #endregion EditItem

            #region Properties

            PivotGridField fieldISSORUMLU = new PivotGridField();
            fieldISSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldISSORUMLU.AreaIndex = 2;
            fieldISSORUMLU.Caption = "Sorumlu";
            fieldISSORUMLU.FieldName = "IS_SORUMLU";
            fieldISSORUMLU.Name = "fieldISSORUMLU";

            PivotGridField fieldISSUREC = new PivotGridField();
            fieldISSUREC.AreaIndex = 2;
            fieldISSUREC.Caption = "Süreç";
            fieldISSUREC.FieldName = "IS_SUREC";
            fieldISSUREC.Name = "fieldISSUREC";

            PivotGridField fieldISSOZLESME = new PivotGridField();
            fieldISSOZLESME.AreaIndex = 3;
            fieldISSOZLESME.Caption = "Sözleşme";
            fieldISSOZLESME.FieldName = "IS_SOZLESME";
            fieldISSOZLESME.Name = "fieldISSOZLESME";

            PivotGridField fieldMADDEKALEM = new PivotGridField();
            fieldMADDEKALEM.AreaIndex = 4;
            fieldMADDEKALEM.Caption = "Madde Kalem";
            fieldMADDEKALEM.FieldName = "MADDE_KALEM";
            fieldMADDEKALEM.Name = "fieldMADDEKALEM";

            PivotGridField fieldISDURUM = new PivotGridField();
            fieldISDURUM.AreaIndex = 0;
            fieldISDURUM.Caption = "Durum";
            fieldISDURUM.FieldName = "IS_DURUM";
            fieldISDURUM.Name = "fieldISDURUM";
            fieldISDURUM.Visible = false;

            PivotGridField fieldISBASLANGICTARIHI = new PivotGridField();
            fieldISBASLANGICTARIHI.AreaIndex = 5;
            fieldISBASLANGICTARIHI.Caption = "Planlama T";
            fieldISBASLANGICTARIHI.FieldName = "IS_BASLANGIC_TARIHI";
            fieldISBASLANGICTARIHI.Name = "fieldISBASLANGICTARIHI";

            PivotGridField fieldISONGORULENBITISTARIHI = new PivotGridField();
            fieldISONGORULENBITISTARIHI.AreaIndex = 6;
            fieldISONGORULENBITISTARIHI.Caption = "Ön Görülen Bitiş T";
            fieldISONGORULENBITISTARIHI.FieldName = "IS_ON_GORULEN_BITIS_TARIHI";
            fieldISONGORULENBITISTARIHI.Name = "fieldISONGORULENBITISTARIHI";

            PivotGridField fieldISBITISTARIHI = new PivotGridField();
            fieldISBITISTARIHI.AreaIndex = 8;
            fieldISBITISTARIHI.Caption = "Kapama T";
            fieldISBITISTARIHI.FieldName = "IS_BITIS_TARIHI";
            fieldISBITISTARIHI.Name = "fieldISBITISTARIHI";

            PivotGridField fieldISKATEGORIID = new PivotGridField();
            fieldISKATEGORIID.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldISKATEGORIID.AreaIndex = 4;

            //fieldISKATEGORIID.FieldEdit = rLueKategori;
            fieldISKATEGORIID.Caption = "Kategori";
            fieldISKATEGORIID.FieldName = "IS_KATEGORI_ID";
            fieldISKATEGORIID.Name = "fieldISKATEGORIID";

            PivotGridField fieldISPLANLAYAN = new PivotGridField();
            fieldISPLANLAYAN.AreaIndex = 1;
            fieldISPLANLAYAN.Caption = "Planlayan";
            fieldISPLANLAYAN.FieldName = "IS_PLANLAYAN";
            fieldISPLANLAYAN.Name = "fieldISPLANLAYAN";

            PivotGridField fieldISMUHATABI = new PivotGridField();
            fieldISMUHATABI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldISMUHATABI.AreaIndex = 3;
            fieldISMUHATABI.Caption = "Muhatab";
            fieldISMUHATABI.FieldName = "IS_MUHATABI";
            fieldISMUHATABI.Name = "fieldISMUHATABI";

            PivotGridField fieldISKLASORID = new PivotGridField();
            fieldISKLASORID.AreaIndex = 0;
            fieldISKATEGORIID.FieldEdit = rLueKlasor;
            fieldISKLASORID.Caption = "Klasor";
            fieldISKLASORID.FieldName = "IS_KLASOR_ID";
            fieldISKLASORID.Name = "fieldISKLASORID";

            PivotGridField fieldISADLIBIRIMADLIYE = new PivotGridField();
            fieldISADLIBIRIMADLIYE.AreaIndex = 8;
            fieldISADLIBIRIMADLIYE.FieldEdit = rLueAdliye;
            fieldISADLIBIRIMADLIYE.Caption = "Adliye";
            fieldISADLIBIRIMADLIYE.FieldName = "IS_ADLI_BIRIM_ADLIYE";
            fieldISADLIBIRIMADLIYE.Name = "fieldISADLIBIRIMADLIYE";
            fieldISADLIBIRIMADLIYE.Visible = false;

            PivotGridField fieldISADLIBIRIMGOREV = new PivotGridField();
            fieldISADLIBIRIMGOREV.AreaIndex = 9;
            fieldISADLIBIRIMGOREV.FieldEdit = rLueGorev;
            fieldISADLIBIRIMGOREV.Caption = "Gorev";
            fieldISADLIBIRIMGOREV.FieldName = "IS_ADLI_BIRIM_GOREV";
            fieldISADLIBIRIMGOREV.Name = "fieldISADLIBIRIMGOREV";
            fieldISADLIBIRIMGOREV.Visible = false;

            PivotGridField fieldISADLIBIRIMNO = new PivotGridField();
            fieldISADLIBIRIMNO.AreaIndex = 10;
            fieldISADLIBIRIMNO.Caption = "No";
            fieldISADLIBIRIMNO.FieldEdit = rLueadliBirimNo;
            fieldISADLIBIRIMNO.FieldName = "IS_ADLI_BIRIM_NO";
            fieldISADLIBIRIMNO.Name = "fieldISADLIBIRIMNO";
            fieldISADLIBIRIMNO.Visible = false;

            PivotGridField fieldISESASNO = new PivotGridField();
            fieldISESASNO.AreaIndex = 11;
            fieldISESASNO.Caption = "Esas No";
            fieldISESASNO.FieldName = "IS_ESAS_NO";
            fieldISESASNO.Name = "fieldISESASNO";
            fieldISESASNO.Visible = false;

            PivotGridField fieldID = new PivotGridField();
            fieldID.AreaIndex = 7;
            fieldID.Caption = "Dosya Sayısı";
            fieldID.FieldName = "ID";
            fieldID.Name = "fieldID";

            PivotGridField fieldISID = new PivotGridField();
            fieldISID.AreaIndex = 13;
            fieldISID.Caption = "İş Dosya Sayısı";
            fieldISID.FieldName = "IS_ID";
            fieldISID.Name = "fieldISID";
            fieldISID.Visible = false;

            PivotGridField fieldBASLANGICZAMANI = new PivotGridField();
            fieldBASLANGICZAMANI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldBASLANGICZAMANI.AreaIndex = 0;
            fieldBASLANGICZAMANI.Caption = "Başlangıç Zamanı";
            fieldBASLANGICZAMANI.FieldName = "BASLANGIC_ZAMANI";
            fieldBASLANGICZAMANI.Name = "fieldBASLANGICZAMANI";

            PivotGridField fieldBITISZAMANI = new PivotGridField();
            fieldBITISZAMANI.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldBITISZAMANI.AreaIndex = 1;
            fieldBITISZAMANI.Caption = "Bitiş Zamanı";
            fieldBITISZAMANI.FieldName = "BITIS_ZAMANI";
            fieldBITISZAMANI.Name = "fieldBITISZAMANI";

            PivotGridField fieldSURECACIKLAMA = new PivotGridField();
            fieldSURECACIKLAMA.AreaIndex = 8;
            fieldSURECACIKLAMA.Caption = "Açıklama ";
            fieldSURECACIKLAMA.FieldName = "SUREC_ACIKLAMA";
            fieldSURECACIKLAMA.Name = "fieldSURECACIKLAMA";
            fieldSURECACIKLAMA.Visible = false;

            PivotGridField fieldMUHASEBELESTILMISMI = new PivotGridField();
            fieldMUHASEBELESTILMISMI.AreaIndex = 8;
            fieldMUHASEBELESTILMISMI.Caption = "Muhasebeleştirilmiş";
            fieldMUHASEBELESTILMISMI.FieldName = "MUHASEBELESTILMIS_MI";
            fieldMUHASEBELESTILMISMI.Name = "fieldMUHASEBELESTILMISMI";
            fieldMUHASEBELESTILMISMI.Visible = false;

            PivotGridField fieldSURE = new PivotGridField();
            fieldSURE.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldSURE.AreaIndex = 0;
            fieldSURE.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Custom;
            fieldSURE.Caption = "Süre";
            fieldSURE.FieldName = "SURE_ST";
            fieldSURE.Name = "fieldSURE";

            PivotGridField fieldBIRIMFIYAT = new PivotGridField();
            fieldBIRIMFIYAT.AreaIndex = 17;
            fieldBIRIMFIYAT.Caption = "Birim Fiyat ";
            fieldBIRIMFIYAT.FieldEdit = rspFiyat;
            fieldBIRIMFIYAT.FieldName = "BIRIM_FIYAT";
            fieldBIRIMFIYAT.Name = "fieldBIRIMFIYAT";
            fieldBIRIMFIYAT.Visible = false;

            PivotGridField fieldTOPLAMFIYAT = new PivotGridField();
            fieldTOPLAMFIYAT.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldTOPLAMFIYAT.AreaIndex = 1;
            fieldTOPLAMFIYAT.FieldEdit = rspFiyat;
            fieldTOPLAMFIYAT.Caption = "Toplam Fiyat";
            fieldTOPLAMFIYAT.FieldName = "TOPLAM_FIYAT";
            fieldTOPLAMFIYAT.Name = "fieldTOPLAMFIYAT";

            PivotGridField fieldBIRIMFIYATDOVIZID = new PivotGridField();
            fieldBIRIMFIYATDOVIZID.AreaIndex = 18;
            fieldBIRIMFIYATDOVIZID.FieldEdit = rLueDoviz;
            fieldBIRIMFIYATDOVIZID.Caption = "Birim Fiyat Birim";
            fieldBIRIMFIYATDOVIZID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            fieldBIRIMFIYATDOVIZID.Name = "fieldBIRIMFIYATDOVIZID";
            fieldBIRIMFIYATDOVIZID.Visible = false;

            PivotGridField fieldTOPLAMFIYATDOVIZID = new PivotGridField();
            fieldTOPLAMFIYATDOVIZID.AreaIndex = 8;
            fieldTOPLAMFIYATDOVIZID.FieldEdit = rLueDoviz;
            fieldTOPLAMFIYATDOVIZID.Caption = "Toplam Fiyat Birim";
            fieldTOPLAMFIYATDOVIZID.FieldName = "TOPLAM_FIYAT_DOVIZ_ID";
            fieldTOPLAMFIYATDOVIZID.Name = "fieldTOPLAMFIYATDOVIZID";
            fieldTOPLAMFIYATDOVIZID.Visible = false;

            PivotGridField fieldKONTROLKIMID = new PivotGridField();
            fieldKONTROLKIMID.AreaIndex = 19;
            fieldKONTROLKIMID.FieldEdit = rLueKullanıcı;
            fieldKONTROLKIMID.Caption = "Kullanıcı";
            fieldKONTROLKIMID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROLKIMID.Name = "fieldKONTROLKIMID";
            fieldKONTROLKIMID.Visible = false;

            PivotGridField fieldSUBEKODID = new PivotGridField();
            fieldSUBEKODID.AreaIndex = 20;
            fieldSUBEKODID.FieldEdit = rLueBuro;
            fieldSUBEKODID.Caption = "Büro";
            fieldSUBEKODID.FieldName = "SUBE_KOD_ID";
            fieldSUBEKODID.Name = "fieldSUBEKODID";
            fieldSUBEKODID.Visible = false;

            #endregion Properties

            #region Dizi

            PivotGridField[] dizi = new[]
                                        {
                                            fieldISSORUMLU,
                                            fieldISSUREC,
                                            fieldISSOZLESME,
                                            fieldMADDEKALEM,
                                            fieldISDURUM,
                                            fieldISBASLANGICTARIHI,
                                            fieldISONGORULENBITISTARIHI,
                                            fieldISBITISTARIHI,
                                            fieldISKATEGORIID,
                                            fieldISPLANLAYAN,
                                            fieldISMUHATABI,
                                            fieldISKLASORID,
                                            fieldISADLIBIRIMADLIYE,
                                            fieldISADLIBIRIMGOREV,
                                            fieldISADLIBIRIMNO,
                                            fieldISESASNO,
                                            fieldID,
                                            fieldISID,
                                            fieldBASLANGICZAMANI,
                                            fieldBITISZAMANI,
                                            fieldSURECACIKLAMA,
                                            fieldMUHASEBELESTILMISMI,
                                            fieldSURE,
                                            fieldBIRIMFIYAT,
                                            fieldTOPLAMFIYAT,
                                            fieldBIRIMFIYATDOVIZID,
                                            fieldTOPLAMFIYATDOVIZID,
                                            fieldKONTROLKIMID,
                                            fieldSUBEKODID
                                        };

            #endregion Dizi

            return dizi;
        }
    }
}