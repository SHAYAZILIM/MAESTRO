using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AdimAdimDavaKaydi.KodCetvel.Forms.Kod;
using AvukatPro.Model.EntityClasses;
using AvukatProLib2.Data;
using DevExpress.XtraEditors;

namespace AnaForm
{
    public partial class frmOrtakOzelKodlar : DevExpress.XtraEditors.XtraForm
    {
        #region Fields

        private List<Av001TdiKodFoyOzelEntity> MyDataSourceOzelKod = new List<Av001TdiKodFoyOzelEntity>();

        #endregion Fields

        #region Constructors

        public frmOrtakOzelKodlar()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        public void OzelKodGetir()
        {
            MyDataSourceOzelKod = AvukatPro.Services.Implementations.DosyaService.GetAllOzelKod();
            gridOzelSozlesmeKodlar.DataSource = MyDataSourceOzelKod;
        }

        public void OzelKodKaydet()
        {
            DialogResult dr = XtraMessageBox.Show("Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    AvukatPro.Services.Implementations.DosyaService.OzelKodKaydet(MyDataSourceOzelKod as List<Av001TdiKodFoyOzelEntity>);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    frmCetvel.CatchKontrol(this, ex, tran);
                }
            }
        }

        private void sBtnKaydet_Click(object sender, EventArgs e)
        {
            OzelKodKaydet();
        }

        #endregion Methods
    }
}