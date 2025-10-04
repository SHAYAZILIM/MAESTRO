using System;
using System.Drawing;
using DevExpress.XtraScheduler;

namespace AdimAdimDavaKaydi.Is.UserControls
{
    public partial class ucHatirlatmaPeriyot : DevExpress.XtraEditors.XtraUserControl
    {
        private RecurrenceInfo _RecurrenceInfo;

        private DevExpress.XtraScheduler.UI.RecurrenceControlBase selectedPanel;

        public ucHatirlatmaPeriyot()
        {
            InitializeComponent();
        }

        public RecurrenceInfo RecurrenceInfo
        {
            get
            {
                if (selectedPanel != null)
                {
                    selectedPanel.RecurrenceInfo.OccurrenceCount = (int)nmTekrarSayisi.Value;
                    if (rbBitisTarihi.Checked)
                    {
                        selectedPanel.RecurrenceInfo.Range = RecurrenceRange.EndByDate;
                        selectedPanel.RecurrenceInfo.End = (DateTime)dateEdit1.EditValue;
                    }
                    else if (rbTekrarsayisi.Checked)
                    {
                        selectedPanel.RecurrenceInfo.Range = RecurrenceRange.OccurrenceCount;
                        selectedPanel.RecurrenceInfo.OccurrenceCount = (int)nmTekrarSayisi.Value;
                    }
                    else if (rdSonsuz.Checked)
                        selectedPanel.RecurrenceInfo.Range = RecurrenceRange.NoEndDate;

                    return selectedPanel.RecurrenceInfo;
                }
                else
                    return new RecurrenceInfo();
            }
            set { _RecurrenceInfo = value; }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (selectedPanel != null)
                selectedPanel.Visible = false;

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    selectedPanel = dailyRecurrenceControl1;
                    dailyRecurrenceControl1.Location = new Point(0, 30);
                    dailyRecurrenceControl1.Visible = true;
                    break;

                case 1:
                    selectedPanel = weeklyRecurrenceControl1;
                    weeklyRecurrenceControl1.Location = new Point(0, 30);
                    weeklyRecurrenceControl1.Visible = true;
                    break;

                case 2:
                    selectedPanel = monthlyRecurrenceControl1;
                    monthlyRecurrenceControl1.Location = new Point(0, 30);
                    monthlyRecurrenceControl1.Visible = true;
                    break;

                case 3:
                    selectedPanel = yearlyRecurrenceControl1;
                    yearlyRecurrenceControl1.Location = new Point(0, 30);
                    yearlyRecurrenceControl1.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void ucHatirlatmaPeriyot_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            comboBox1.SelectedIndex = 0;
        }
    }
}