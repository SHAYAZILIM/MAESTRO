using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using System.ComponentModel;

namespace AdimAdimDavaKaydi.Editor.Forms
{
    public partial class frmCokluSecim : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmCokluSecim()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        public frmEditor Editor
        {
            get { return this.ucBirdenFaziafoyileBirdenFazlaRapor1.SelectedEditor; }
            set { this.ucBirdenFaziafoyileBirdenFazlaRapor1.SelectedEditor = value; }
        }
    }
}