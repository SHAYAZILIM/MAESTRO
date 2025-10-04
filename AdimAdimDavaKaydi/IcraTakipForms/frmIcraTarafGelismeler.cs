using AvukatProLib2.Entities;
using System.ComponentModel;

namespace AdimAdimDavaKaydi.IcraTakipForms
{
    public partial class frmIcraTarafGelismeler : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        private AV001_TI_BIL_FOY _MyFoy;

        public frmIcraTarafGelismeler()
        {
            InitializeComponent();
        }

        public int? CurrentCariID { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return _MyFoy; }
            set
            {
                _MyFoy = value;
                if (value != null)
                {
                    if (CurrentCariID.HasValue)
                        ucIcraTarafGelismeleri1.CurrBorcluId = CurrentCariID.Value;
                    ucIcraTarafGelismeleri1.MyFoy = value;
                    UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.GelismeleriGuncelle(MyFoy, null);
                }
            }
        }
    }
}