using System;

namespace AvukatProLib.Bakim
{
    public partial class frmVeriTabaniKontrol : DevExpress.XtraEditors.XtraForm
    {
        public frmVeriTabaniKontrol()
        {
            InitializeComponent();
        }

        private void frmVeriTabaniKontrol_Load(object sender, EventArgs e)
        {
            //backgroundWorker1.RunWorkerAsync();
            //DataTable dt = new DataTable();
            //dt.Columns.Add("IncelenecekVeriTabani");
            //dt.NewRow();
            //dataNavigator1.DataSource = vGridControl1.DataSource = dt;

            //TODO:SMO ILE ILGILI OLARAK COMMENT EDILDI bir altta tek satýr
            //rlkDbler.DataSource =  VeriTabaniKullancilariMetotlar.MevcutVeriTabani("");;

            //rlkDbler.DataSource = veriler;
            //rlkDbler.DisplayMember = "Adi";
            //rlkDbler.ValueMember = "Id";
        }

        //private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    Server srv = new Server();
        //    List<Database> dbler = new List<Database>();
        //    foreach (Database db in srv.Databases)
        //    {
        //        dbler.Add(db);
        //    }
        //    e.Result = dbler; ;
        //}

        //private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //}
    }
}