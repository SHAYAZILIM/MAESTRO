using DevExpress.XtraScheduler;
using System;

namespace AdimAdimDavaKaydi.Ajanda.Forms.SmallForms
{
    public partial class frmCalismaSaatleri : DevExpress.XtraEditors.XtraForm
    {
        public frmCalismaSaatleri()
        {
            InitializeComponent();
        }

        public SchedulerControl Ajandasi { get; set; }

        public void ShowDialog(SchedulerControl Ajanda)
        {
            this.Ajandasi = Ajanda;
            this.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTamm_Click(object sender, EventArgs e)
        {
            if (this.Ajandasi.ActiveViewType == SchedulerViewType.Timeline)
            {
                this.Ajandasi.TimelineView.WorkTime.Start = (TimeSpan)this.teBaslangic.EditValue;
                this.Ajandasi.TimelineView.WorkTime.End = (TimeSpan)this.teBitis.EditValue;
            }
            else if (this.Ajandasi.ActiveViewType == SchedulerViewType.Day)
            {
                this.Ajandasi.DayView.WorkTime.Start = (TimeSpan)this.teBaslangic.EditValue;
                this.Ajandasi.DayView.WorkTime.End = (TimeSpan)this.teBitis.EditValue;
            }
            else if (this.Ajandasi.ActiveViewType == SchedulerViewType.WorkWeek)
            {
                this.Ajandasi.WorkWeekView.WorkTime.Start = (TimeSpan)this.teBaslangic.EditValue;
                this.Ajandasi.WorkWeekView.WorkTime.End = (TimeSpan)this.teBitis.EditValue;
            }

            this.Close();
        }

        private void frmCalismaSaatleri_Load(object sender, EventArgs e)
        {
            if (this.Ajandasi.ActiveViewType == SchedulerViewType.Timeline)
            {
                this.teBaslangic.EditValue = this.Ajandasi.TimelineView.WorkTime.Start;
                this.teBitis.EditValue = this.Ajandasi.TimelineView.WorkTime.End;
            }
            else if (this.Ajandasi.ActiveViewType == SchedulerViewType.Day)
            {
                this.teBaslangic.EditValue = this.Ajandasi.DayView.WorkTime.Start;
                this.teBitis.EditValue = this.Ajandasi.DayView.WorkTime.End;
            }
            else if (this.Ajandasi.ActiveViewType == SchedulerViewType.WorkWeek)
            {
                this.teBaslangic.EditValue = this.Ajandasi.WorkWeekView.WorkTime.Start;
                this.teBitis.EditValue = this.Ajandasi.WorkWeekView.WorkTime.End;
            }
        }
    }
}