using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPivotGrid;
using AvukatProLib;
using AvukatProRaporlar.Lib;

namespace AdimAdimDavaKaydi.Raporlama
{
    public partial class frmKararaCikanDosyalar : Form
    {
        public frmKararaCikanDosyalar()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        private void frmKararaCikanDosyalar_Load(object sender, EventArgs e)
        {
            extendedPivotControl1.Fields.Clear();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            dt = cn.GetDataTable("SELECT * FROM R_HUKUM_TAKIP_RAPOR_YENI");

            gridListeControl.DataSource = dt;
            gridListeView.Columns["TARAF_CARI_ID"].Visible = false;
            gridListeView.Columns["DAVAPOZISYONU"].Visible = false;
        }

        Enums.KayitTipi hangisi = Enums.KayitTipi.Excel;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            popupContainerControl1.Top = (this.Height / 2) - (popupContainerControl1.Height / 2);
            popupContainerControl1.Left = (this.Width / 2) - (popupContainerControl1.Width / 2);
            popupContainerControl1.Show();
            hangisi = Enums.KayitTipi.Excel;
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            popupContainerControl1.Top = (this.Height / 2) - (popupContainerControl1.Height / 2);
            popupContainerControl1.Left = (this.Width / 2) - (popupContainerControl1.Width / 2);
            popupContainerControl1.Show();
            hangisi = Enums.KayitTipi.Pdf;
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            popupContainerControl1.Top = (this.Height / 2) - (popupContainerControl1.Height / 2);
            popupContainerControl1.Left = (this.Width / 2) - (popupContainerControl1.Width / 2);
            popupContainerControl1.Show();
            hangisi = Enums.KayitTipi.Html;
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            popupContainerControl1.Top = (this.Height / 2) - (popupContainerControl1.Height / 2);
            popupContainerControl1.Left = (this.Width / 2) - (popupContainerControl1.Width / 2);
            popupContainerControl1.Show();
            hangisi = Enums.KayitTipi.Print;
        }

        private void btnListeSecti_Click(object sender, EventArgs e)
        {
            SaveFileTools.Exporter(extendedPivotControl1, hangisi);
            popupContainerControl1.Hide();
        }

        private void btnGrafikSecti_Click(object sender, EventArgs e)
        {
            SaveFileTools.Exporter(chartControl1, hangisi);
            popupContainerControl1.Hide();
        }

        private void btnPopupKapat_Click(object sender, EventArgs e)
        {
            popupContainerControl1.Hide();
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 1 & extendedPivotControl1.Fields.Count == 0)
            {
                chartControl1.DataSource = extendedPivotControl1;
                chartControl1.SeriesDataMember = "Series";
                chartControl1.SeriesTemplate.ArgumentDataMember = "Arguments";

                chartControl1.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Values" });

                chartControl1.SeriesTemplate.LegendPointOptions.PointView = DevExpress.XtraCharts.PointView.ArgumentAndValues;
                foreach (DataColumn col in dt.Columns)
                {
                    if (col.ColumnName == "Mahkeme" || col.ColumnName == "No" || col.ColumnName == "Görev" || col.ColumnName == "Dava Nedeni" || col.ColumnName == "Dava Tarafı" || col.ColumnName == "Sorumlu" || col.ColumnName == "Karşı Taraf Adı" || col.ColumnName == "Müvekkil Adı")
                        extendedPivotControl1.Fields.Add(col.ColumnName, PivotArea.FilterArea);
                    else if (col.ColumnName == "Dava Tutar" || col.ColumnName == "Tutar" || col.ColumnName == "Hüküm Değeri")
                        extendedPivotControl1.Fields.Add(col.ColumnName, PivotArea.DataArea);
                    else if (col.ColumnName == "Dava Tip" || col.ColumnName == "Anlam" || col.ColumnName == "Hüküm T." || col.ColumnName == "Hüküm Tipi" || col.ColumnName == "Dava Konusu" || col.ColumnName == "Durum" || col.ColumnName == "Hüküm")
                        extendedPivotControl1.Fields.Add(col.ColumnName, PivotArea.RowArea);
                    else
                    {
                        extendedPivotControl1.Fields.Add(col.ColumnName, PivotArea.FilterArea);
                        extendedPivotControl1.Fields[extendedPivotControl1.Fields.Count - 1].Visible = false;

                        if (col.ColumnName == "TARAF_CARI_ID")
                        {
                            extendedPivotControl1.Fields[extendedPivotControl1.Fields.Count - 1].SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
                            extendedPivotControl1.Fields[extendedPivotControl1.Fields.Count - 1].Caption = "Dosya Sayısı";
                            extendedPivotControl1.Fields[extendedPivotControl1.Fields.Count - 1].Visible = true;
                            extendedPivotControl1.Fields[extendedPivotControl1.Fields.Count - 1].Area = PivotArea.DataArea;
                        }
                    }
                }
                extendedPivotControl1.DataSource = dt; 
            }
        }
    }
}
