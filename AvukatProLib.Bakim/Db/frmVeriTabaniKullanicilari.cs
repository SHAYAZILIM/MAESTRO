using AvukatProLib.Util;
using System;
using System.Data;

namespace AvukatProLib.Bakim
{
    public partial class frmVeriTabaniKullanicilari : DevExpress.XtraEditors.XtraForm
    {
        public frmVeriTabaniKullanicilari()
        {
            InitializeComponent();
        }

        private VeriTabaniKullancilariMetotlar kullanicibilgisi = new VeriTabaniKullancilariMetotlar();

        private VeriTabaniKullanicilari kullanicilar = new VeriTabaniKullanicilari();

        private void frmVeriTabaniKullanicilari_Load(object sender, EventArgs e)
        {
            //gridControl1.DataSource = kullanicibilgisi.KullaniciBilgisi("Yok");
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.Columns.Count > 0)
            {
                kullanicilar.VarsayilanVeriTabani = gridView1.GetRowCellDisplayText(e.FocusedRowHandle, gridView1.Columns[0]);
                DataTable dt = new DataTable();
                dt.Columns.Add("Database");
                dt.Columns.Add("Users");
                dt.Columns.Add("Langurange");
                DataRow dr = dt.NewRow();
                dr["Database"] = gridView1.GetRowCellDisplayText(e.FocusedRowHandle, gridView1.Columns[0]);
                dr["Users"] = gridView1.GetRowCellDisplayText(e.FocusedRowHandle, gridView1.Columns[1]);
                dr["Langurange"] = gridView1.GetRowCellDisplayText(e.FocusedRowHandle, gridView1.Columns[2]);
                dt.Rows.Add(dr);
                vGridControl1.DataSource = dt;

                dataNavigator1.DataSource = dt;
            }
        }
    }
}