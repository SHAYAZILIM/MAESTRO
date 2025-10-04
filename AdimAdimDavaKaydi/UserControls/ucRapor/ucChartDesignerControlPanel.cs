using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors.Controls;

namespace AdimAdimDavaKaydi.UserControls.ucRapor
{
    public partial class ucChartDesignerControlPanel : DevExpress.XtraEditors.XtraUserControl
    {
        public ucChartDesignerControlPanel()
        {
            InitializeComponent();
            this.Load += ucChartDesignerControlPanel_Load;
            lueOneCikar.EditValueChanged += lueOneCikar_EditValueChanged;
            //ýmageComboBoxEdit1.EditValueChanged += ýmageComboBoxEdit1_EditValueChanged;
            lueRenkler.EditValueChanged += lueRenkler_EditValueChanged;

        }

        private void lueRenkler_EditValueChanged(object sender, EventArgs e)
        {
            if (MyChartControl == null)
                return;
            ChartDesigner.PaletteChanger(MyChartControl, lueRenkler.EditValue.ToString());
        }

        //private void ýmageComboBoxEdit1_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (MyChartControl == null)
        //        return;

        //    //ChartDesigner.SeriesTemplateViewTypeChanger(MyChartControl, (ViewType)ýmageComboBoxEdit1.EditValue);
        //}

        private void MyChartControl_BoundDataChanged(object sender, EventArgs e)
        {
            if (MyChartControl == null)
                return;

            if (MyChartControl.Series.Count > 0)
                lueOneCikar.Properties.DataSource = ChartDesigner.CreateModeList(MyChartControl.Series[0].Points);
        }

        public ChartControl MyChartControl { get; set; }

        private void lueOneCikar_EditValueChanged(object sender, EventArgs e)
        {
            ChartDesigner.ExplodedPointChanger(MyChartControl, lueOneCikar.EditValue.ToString());
        }

        private void ucChartDesignerControlPanel_Load(object sender, EventArgs e)
        {
            //ýmageComboBoxEdit1.Properties.Items.AddEnum(typeof(ViewType));
            //foreach (ViewType teki in Enum.GetValues(typeof(ViewType)))
            //{
            //    ýmageComboBoxEdit1.Properties.Items.Add(new ImageComboBoxItem(teki, (int)teki));
            //}
            lookGrafikSecimi.Properties.DataSource = Enum.GetValues(typeof(DevExpress.XtraCharts.ViewType));

            //chBoxSutunToplami.Checked = extendedPivotControl1.OptionsChartDataSource.ShowColumnGrandTotals;
            //chBoxSatirToplami.Checked = extendedPivotControl1.OptionsChartDataSource.ShowRowGrandTotals;
            // chBoxYonDegis.Checked = extendedPivotControl1.OptionsChartDataSource.ChartDataVertical ;

            lookGrafikSecimi.SelectedText = "Full-Stacked Bar";

            // dataNavigatorExtended2.MyChartControl = this.chartControl1;

            lueRenkler.Properties.DataSource = ChartDesigner.PalleteNameList();
            //ýmageComboBoxEdit1.SelectedItem = ViewType.Bar;

            if (MyChartControl == null)
                return;
            MyChartControl.BoundDataChanged += new BoundDataChangedEventHandler(MyChartControl_BoundDataChanged);
            if (MyChartControl.Series.Count > 0)
                lueOneCikar.Properties.DataSource = ChartDesigner.CreateModeList(MyChartControl.Series[0].Points);
        }
        private void lookGrafikSecimi_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                MyChartControl.SeriesTemplate.ChangeView((DevExpress.XtraCharts.ViewType)lookGrafikSecimi.EditValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}