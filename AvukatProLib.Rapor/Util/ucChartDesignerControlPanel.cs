using DevExpress.XtraCharts;
using DevExpress.XtraEditors.Controls;
using System;
using ChartDesigner = AdimAdimDavaKaydi.Util.ChartDesigner;

namespace AdimAdimDavaKaydi.UserControls.ucRapor
{
    public partial class ucChartDesignerControlPanel : DevExpress.XtraEditors.XtraUserControl
    {
        public ucChartDesignerControlPanel()
        {
            InitializeComponent();
            this.Load += new EventHandler(ucChartDesignerControlPanel_Load);
            lueOneCikar.EditValueChanged += new EventHandler(lueOneCikar_EditValueChanged);
            �mageComboBoxEdit1.EditValueChanged += new EventHandler(�mageComboBoxEdit1_EditValueChanged);
            lueRenkler.EditValueChanged += new EventHandler(lueRenkler_EditValueChanged);
        }

        private ChartControl _myChartControl;

        public ChartControl MyChartControl
        {
            get
            {
                return _myChartControl;
            }
            set
            {
                _myChartControl = value;
            }
        }

        private void �mageComboBoxEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (MyChartControl == null)
                return;

            ChartDesigner.SeriesTemplateViewTypeChanger(MyChartControl, (ViewType)�mageComboBoxEdit1.EditValue);
        }

        private void lueOneCikar_EditValueChanged(object sender, EventArgs e)
        {
            ChartDesigner.ExplodedPointChanger(MyChartControl, lueOneCikar.EditValue.ToString());
        }

        private void lueRenkler_EditValueChanged(object sender, EventArgs e)
        {
            if (MyChartControl == null)
                return;
            ChartDesigner.PaletteChanger(MyChartControl, lueRenkler.EditValue.ToString());
        }

        private void MyChartControl_BoundDataChanged(object sender, EventArgs e)
        {
            if (MyChartControl == null)
                return;

            if (MyChartControl.Series.Count > 0)
                lueOneCikar.Properties.DataSource = ChartDesigner.CreateModeList(MyChartControl.Series[0].Points);
        }

        private void ucChartDesignerControlPanel_Load(object sender, EventArgs e)
        {
            //�mageComboBoxEdit1.Properties.Items.AddEnum(typeof(ViewType));
            foreach (ViewType teki in Enum.GetValues(typeof(ViewType)))
            {
                �mageComboBoxEdit1.Properties.Items.Add(new ImageComboBoxItem(teki, (int)teki));
            }
            lueRenkler.Properties.DataSource = ChartDesigner.PalleteNameList();
            �mageComboBoxEdit1.SelectedItem = ViewType.Bar;

            if (MyChartControl == null)
                return;
            MyChartControl.BoundDataChanged += new BoundDataChangedEventHandler(MyChartControl_BoundDataChanged);
            if (MyChartControl.Series.Count > 0)
                lueOneCikar.Properties.DataSource = ChartDesigner.CreateModeList(MyChartControl.Series[0].Points);
        }
    }
}