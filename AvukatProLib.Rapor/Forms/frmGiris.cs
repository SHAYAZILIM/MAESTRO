using DevExpress.XtraNavBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AvukatProLib.Rapor.Forms
{
    public partial class frmGiris : Util.AvpRaporBase.Forms.AvpRaporBaseForm
    {
        public frmGiris()
        {
            InitializeComponent();
            ucChartDesignerControlPanel1.MyChartControl = this.chartControl1;
            bwSetMyData.DoWork += new DoWorkEventHandler(bwSetMyData_DoWork);
            bwSetMyData.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwSetMyData_RunWorkerCompleted);
            Load += frmGiris_Load;
        }

        private BackgroundWorker bwSetMyData = new BackgroundWorker();

        private List<Util.IRaporSource> RaporListesi = new List<AvukatProLib.Rapor.Util.IRaporSource>();

        private void bwSetMyData_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument is Util.IRaporSource)
            {
                Util.IRaporSource source = e.Argument as Util.IRaporSource;

                //SetMyData(source);
                if (source.EnableGrid)
                {
                    object o = source.ListDataSource;
                }
                if (source.EnablePivot)
                {
                    object o = source.PivotDataSource;
                }
                if (source.EnableChart)
                {
                    object o = source.ChartDataSource;
                }

                e.Result = source;
            }
        }

        private void bwSetMyData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Util.IRaporSource)
            {
                Util.IRaporSource source = e.Result as Util.IRaporSource;
                SetMyData(source);
            }
        }

        private void frmGiris_Load(object sender, EventArgs e)
        {
            RaporListesi.Add(new RaporSource.RSIcraGenel());
            RaporListesi.Add(new RaporSource.RSMasrafAvansDetayli());
            SetChartDataSource();
            SqlConnection con = new SqlConnection("Data Source=192.9.0.199;Initial Catalog=AVP_NHA_NG_BOS;uid=canan;pwd=123");
            DataSet dt = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter("select * from TDI_KOD_RAPOR_MENU", con);
            dap.Fill(dt);

            //ds =(DataSet)DataRepository.Provider.ExecuteDataSet(CommandType.Text, );
            grdRaporMenu.DataSource = dt.Tables[0];

            //SetMyData(new RaporSource.RSIcraGenel());
            SetMyRaporMenu(RaporListesi);
        }

        private void item_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (e.Link.Item.Tag != null && e.Link.Item.Tag is Util.IRaporSource)
            {
                Util.IRaporSource source = e.Link.Item.Tag as Util.IRaporSource;

                if (!bwSetMyData.IsBusy)
                {
                    gridView1.Columns.Clear();
                    pivotGridControl1.Fields.Clear();

                    bwSetMyData.RunWorkerAsync(source);
                }
                else MessageBox.Show("Uygulama Zaten Çalýþýyor..");

                //SetMyData(source);
            }
        }

        private void SetChartDataSource()
        {
            chartControl1.DataSource = pivotGridControl1;
            chartControl1.SeriesDataMember = "Series";
            chartControl1.SeriesTemplate.ArgumentDataMember = "Arguments";
            chartControl1.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Values" });
        }

        private void SetMyData(Util.IRaporSource source)
        {
            if (source.EnableGrid)
            {
                gridView1.Columns.Clear();
                gridView1.Columns.AddRange(source.GetGridColumns());

                gridControl1.DataSource = source.ListDataSource;
            }
            if (source.EnablePivot)
            {
                pivotGridControl1.Fields.Clear();
                pivotGridControl1.Fields.AddRange(source.GetPivotFields());
                pivotGridControl1.DataSource = source.PivotDataSource;
            }
        }

        private void SetMyRaporMenu(List<AvukatProLib.Rapor.Util.IRaporSource> raporListesi)
        {
            foreach (Util.IRaporSource source in raporListesi)
            {
                NavBarItem item = new DevExpress.XtraNavBar.NavBarItem(source.MenuName);
                item.Tag = source;
                item.LinkClicked += item_LinkClicked;

                if (navBarControl1.Groups[source.Groups] != null)
                {
                    navBarControl1.Groups[source.Groups].ItemLinks.Add(item);
                }
                else
                {
                    NavBarGroup group = navBarControl1.Groups.Add(new NavBarGroup(source.Groups));
                    group.ItemLinks.Add(item);
                }
            }
        }
    }
}