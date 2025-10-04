using System;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Editor.Forms
{
    public partial class frmEditoreGonder : Form
    {
        public frmEditoreGonder()
        {
            InitializeComponent();
        }

        public AvukatProLib2.Entities.AV001_TI_BIL_FOY MyFoy { get; set; }

        private void frmEditoreGonder_Load(object sender, EventArgs e)
        {
            if (MyFoy != null)
            {
                ucSablonEditoreGonder1.Foys =
                    new AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TI_BIL_FOY>(new[] { MyFoy });
                ucSablonEditoreGonder1.ModuleGoreDoldur(1);
            }
        }
    }
}