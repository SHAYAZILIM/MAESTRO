using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Exchange;
using DevExpress.XtraScheduler.Outlook;
using System;

namespace AdimAdimDavaKaydi.Ajanda.UserControls
{
    public partial class ucAjandaOutlookExport : DevExpress.XtraEditors.XtraUserControl
    {
        public ucAjandaOutlookExport()
        {
            InitializeComponent();
        }

        public string[] OutlookCalendarPaths
        {
            get
            {
                if (DesignMode)
                {
                    return null;
                }
                try
                {
                    return DevExpress.XtraScheduler.Outlook.OutlookExchangeHelper.GetOutlookCalendarPaths();
                }
                catch
                {
                }
                return null;
            }
        }

        public SchedulerStorage Storage { get; set; }

        private void btnOutlookaGonder_Click(object sender, EventArgs e)
        {
            try
            {
                AppointmentExportSynchronizer ais = this.Storage.CreateOutlookExportSynchronizer();
                ((ISupportCalendarFolders)ais).CalendarFolderName = lookUpEdit1.EditValue.ToString();
                ais.ForeignIdFieldName = "EntryID";
                ais.Synchronize();
            }
            catch
            {
            }
        }

        private void btnOutlooklaSenk_Click(object sender, EventArgs e)
        {
            Storage.SynchronizeStorageWithOutlook("EntryID");
        }

        private void btnOutlookuSenkron_Click(object sender, EventArgs e)
        {
            Storage.SynchronizeOutlookWithStorage("EntryID");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                AppointmentImportSynchronizer ais = this.Storage.CreateOutlookImportSynchronizer();
                ((ISupportCalendarFolders)ais).CalendarFolderName = lookUpEdit1.EditValue.ToString();
                ais.ForeignIdFieldName = "EntryID";
                ais.Synchronize();
            }
            catch 
            {
            }
        }

        private void ucAjandaOutlookExport_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            lookUpEdit1.Properties.DataSource = OutlookCalendarPaths;
        }
    }
}