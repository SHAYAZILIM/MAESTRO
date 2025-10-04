using Microsoft.SqlServer.Management.Smo;
using System;

namespace AvukatProLib.Bakim
{
    public partial class frmVeriTabaniYazilimi : DevExpress.XtraEditors.XtraForm
    {
        public frmVeriTabaniYazilimi()
        {
            InitializeComponent();
        }

        private string ayrac = "\n";

        private void frmVeriTabaniYazilimi_Load(object sender, EventArgs e)
        {
            Server server = new Server();
            try
            {
                lblYazilimBilgisi.Text = Stringler.VeriTabaniYazilimBilgisi1 + server.Information.Product + Stringler.VeriTabaniYazilimBilgisi2 + ayrac + ayrac + Stringler.VeriTabaniYazilimBilgisi3 + server.Information.VersionString + ayrac + ayrac + Stringler.VeriTabaniYazilimBilgisi4 + server.Information.ProductLevel + ayrac + ayrac + Stringler.VeriTabaniYazilimBilgisi5;
            }
            catch
            {
                lblYazilimBilgisi.Text = Stringler.VeriTabaniYazilimBilgisi1 + Stringler.VeriTabaniYazilimBilgisi;
            }
        }
    }
}