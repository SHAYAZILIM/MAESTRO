using System;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls.Sablon_Ajanda_Belge
{
    public partial class ucDavaTalep : DevExpress.XtraEditors.XtraUserControl
    {
        private VList<per_TD_KOD_DAVA_TALEP> DavaTalepDataSource = new VList<per_TD_KOD_DAVA_TALEP>();

        public ucDavaTalep()
        {
            InitializeComponent();
        }

        public TList<TD_KOD_DAVA_TALEP> MyDataSource
        {
            get
            {
                if (gridDavaTalep.DataSource is TList<TD_KOD_DAVA_TALEP>)
                    return (TList<TD_KOD_DAVA_TALEP>)gridDavaTalep.DataSource;

                return null;
            }
            set { gridDavaTalep.DataSource = value; }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //SÝL
            DialogResult res = MessageBox.Show("Deðiþiklikler silinsin mi?", "Sil", MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                try
                {
                    DavaTalepDataSource.Remove((per_TD_KOD_DAVA_TALEP)gwDavaTalep.GetFocusedRow());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //KAYDET
            DialogResult res = MessageBox.Show("Deðiþiklikler kaydedilsin mi?", "Kaydet", MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                try
                {
                    TList<TD_KOD_DAVA_TALEP> lstDavaTaleps = ((TList<TD_KOD_DAVA_TALEP>)gridDavaTalep.DataSource);
                    for (int i = 0; i < lstDavaTaleps.Count; i++)
                    {
                        lstDavaTaleps[i].KONTROL_KIM = "AVUKATPRO";
                    }
                    DataRepository.TD_KOD_DAVA_TALEPProvider.Save(lstDavaTaleps);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ucDavaTalep_Load(object sender, EventArgs e)
        {
            //LOAD
            if (!this.DesignMode)
            {
                //rLueAdliBirimBolumKod
                BelgeUtil.Inits.AdliBirimBolumGetir(rLueAdliBirimBolumKod);

                if (BelgeUtil.Inits._DavaTalepGetir == null) BelgeUtil.Inits._DavaTalepGetir = AvukatProLib2.Data.DataRepository.per_TD_KOD_DAVA_TALEPProvider.GetAll();
                DavaTalepDataSource = BelgeUtil.Inits._DavaTalepGetir;
                gridDavaTalep.DataSource = DavaTalepDataSource;
            }
        }
    }
}

//namespace  AdimAdimDavaKaydi.Sozlesme.Forms
//{
//    public class frmSozlesmeTakip: AdimAdimDavaKaydi.Util.BaseClasses.AvpForm
//    {
//    }
//}

//namespace  AdimAdimDavaKaydi.Forms.Dava
//{
//    public class rFrmDavaKayit : AdimAdimDavaKaydi.Util.BaseClasses.AvpForm
//    {
//    }
//}