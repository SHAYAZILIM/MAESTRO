using AvukatProLib.Util;
using System;

namespace AvukatProLib.Bakim
{
    public partial class frmVeriTabaniOlustur : DevExpress.XtraEditors.XtraForm
    {
        public frmVeriTabaniOlustur()
        {
            InitializeComponent();
        }

        private ConStringBilesenler constr = new ConStringBilesenler();

        private void frmVeriTabaniOlustur_Load(object sender, EventArgs e)
        {
            //TODO:SMO ILE ILGILI OLARAK COMMENT EDILDI bir altta tek satýr
            //grdVeriTabanlari.DataSource = VeriTabaniKullancilariMetotlar.MevcutVeriTabani("yok");
            rICbHA.CheckedChanged += new EventHandler(rICbHA_CheckedChanged);
            rIcbMK.CheckedChanged += new EventHandler(rIcbMK_CheckedChanged);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.Columns.Count > 0)
            {
                gridView1.GetRowCellDisplayText(e.FocusedRowHandle, gridView1.Columns[0]);
            }
        }

        private void rICbHA_CheckedChanged(object sender, EventArgs e)
        {
            cRHA.Properties.Caption = "Hukuk Ailesi Ýçin Veri Tabaný Oluþturulacak";
        }

        private void rIcbMK_CheckedChanged(object sender, EventArgs e)
        {
            if (rIcbMK.AllowFocused == true)
                crMK.Properties.Caption = "Mevzuat Karar Ýçin Veri Tabaný Oluþturulacak ";
            else
                crMK.Properties.Caption = "Mevzuat Karar Ýçin Veri Tabaný Oluþturulmayacak ";
        }
    }
}