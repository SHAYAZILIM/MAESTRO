using AvukatProLib2.Entities;
using System;

namespace ImportExportWithSelection.Import
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm1()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmImportFromExcel<AV001_TDI_BIL_CARI> imp = new frmImportFromExcel<AV001_TDI_BIL_CARI>();
            imp.Show(this.gridControl1);
        }

        private void XtraForm1_Load(object sender, EventArgs e)
        {
            this.gridControl1.DataSource = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.GetAll();
            repositoryItemLookUpEdit1.DisplayMember = "IL";
            repositoryItemLookUpEdit1.ValueMember = "ID";
            repositoryItemLookUpEdit1.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ILProvider.GetAll();
        }
    }
}