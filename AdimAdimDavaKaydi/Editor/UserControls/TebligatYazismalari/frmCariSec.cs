using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace AdimAdimDavaKaydi.Editor.UserControls.TebligatYazismalari
{
    public partial class frmCariSec : DevExpress.XtraEditors.XtraForm
    {
        public frmCariSec()
        {
            InitializeComponent();
        }

        private void frmCariSec_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            this.ucCariArama1.MyDataSource = BelgeUtil.Inits.context.AV001_TDI_BIL_CARIs;
            //this.ucCariArama1.MyDataSource = BelgeUtil.Inits.context.AV001_TDI_BIL_CARIs.Where(vi => !vi.AVUKAT_MI && !vi.PERSONEL_MI && !vi.MUVEKKIL_MI).ToList();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region <MB-20100405> 89/1 Seçili Carilere Tebligat Oluþturulmasý

        private AV001_TI_BIL_FOY gelenFoy = new AV001_TI_BIL_FOY();
        private TList<AV001_TDI_BIL_TEBLIGAT> gelenTebligat = new TList<AV001_TDI_BIL_TEBLIGAT>();

        public void Show(TList<AV001_TDI_BIL_TEBLIGAT> tebligatHacizIhbarname, AV001_TI_BIL_FOY mFoy)
        {
            gelenTebligat = tebligatHacizIhbarname;
            gelenFoy = mFoy;
            this.Show();
        }

        private void frm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                List<AV001_TDI_BIL_CARI> secilenCariler = new List<AV001_TDI_BIL_CARI>();

                for (int i = 0; i < ucCariArama1.MyDataSource.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(ucCariArama1.MyDataSource.Rows[i]["IsSelected"]))
                    {
                        AV001_TDI_BIL_CARI car = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID((int)ucCariArama1.MyDataSource.Rows[i]["ID"]);
                        secilenCariler.Add(car);
                    }
                }

                List<int> idList = new List<int>();

                if (secilenCariler.Count > 0)
                {
                    IcraTakipForms.frmHacizIhbarnameleri frm = new AdimAdimDavaKaydi.IcraTakipForms.frmHacizIhbarnameleri();

                    secilenCariler.ForEach(item =>
                        {
                            idList.Add(item.ID);
                        });
                    frm.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frm_FormClosed);
                    frm.Show(gelenFoy, idList);
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);

                if (tran.IsOpen)
                    tran.Rollback();
            }
        }

        #endregion <MB-20100405> 89/1 Seçili Carilere Tebligat Oluþturulmasý
    }
}