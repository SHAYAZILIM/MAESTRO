using System.ComponentModel;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi
{
    public partial class ucSozlesmeDerece : DevExpress.XtraEditors.XtraUserControl
    {
        public ucSozlesmeDerece()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TDI_BIL_SOZLESME_DERECE> MyDerece
        {
            get
            {
                if (vGridControl1.DataSource is TList<AV001_TDI_BIL_SOZLESME_DERECE>)
                    return (TList<AV001_TDI_BIL_SOZLESME_DERECE>)vGridControl1.DataSource;
                return null;
            }
            set { vGridControl1.DataSource = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy { get; set; }
    }
}