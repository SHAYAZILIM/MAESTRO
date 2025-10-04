using DevExpress.XtraScheduler;
using System;

namespace AdimAdimDavaKaydi.Ajanda.Forms.SmallForms
{
    public partial class frmOutlookSenkronizasyon : DevExpress.XtraEditors.XtraForm
    {
        public frmOutlookSenkronizasyon()
        {
            InitializeComponent();
        }

        public SchedulerStorage Storage
        {
            get { return this.ucAjandaOutlookExport1.Storage; }
            set { this.ucAjandaOutlookExport1.Storage = value; }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}