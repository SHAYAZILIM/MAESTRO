using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmKrediBorclusuSec : Form
    {
        public frmKrediBorclusuSec()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmKrediBorclusuSec_Load);
        }

        public AV001_TI_BIL_FOY Icra { get; set; }

        public AV001_TDIE_BIL_PROJE Proje { get; set; }

        
        private void frmKrediBorclusuSec_Load(object sender, EventArgs e)
        {
            BelgeUtil.Inits.perCariGetir(rlueCari);

            if (Icra != null)
            {
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(Icra, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_KREDI_BORCLUSU>));

                bndSource.DataSource = Icra;
                bndSource.DataMember = "AV001_TI_BIL_FOY_KREDI_BORCLUSUCollection";
            }
            else if (Proje != null)
            {
                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(Proje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_KREDI_BORCLUSU>));

                bndSource.DataSource = Proje;

                bndSource.DataMember = "AV001_TDIE_BIL_PROJE_KREDI_BORCLUSUCollection";
            }
        }
    }
}