using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Generalclass.Forms
{
    public partial class frmFoySec : XtraMessageBoxForm
    {
        public frmFoySec(Modul modul)
        {
            _modul = modul;
            InitializeComponent();
        }

        private AV001_TD_BIL_FOY _DavaFoy;
        private AV001_TI_BIL_FOY _IcraFoy;
        private Modul _modul;

        public AV001_TD_BIL_FOY DavaFoy
        {
            get { return _DavaFoy; }
            set { _DavaFoy = value; }
        }

        public AV001_TI_BIL_FOY IcraFoy
        {
            get { return _IcraFoy; }
            set { _IcraFoy = value; }
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmFoySec_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            if (_modul != null)
            {
                switch (_modul)
                {
                    case Modul.Icra:
                        AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Icra, false);
                        break;

                    case Modul.Dava:
                        AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Dava, false);
                        break;

                    case Modul.Sorusturma:
                        AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Sorusturma, false);
                        break;

                    case Modul.Sozlesme:
                        AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Sozlesme, false);
                        break;

                    default:
                        break;
                }
            }
        }

        private void lueDosya_EditValueChanged(object sender, EventArgs e)
        {
            if (lueDosya.EditValue == null)
            {
                btnGonder.Enabled = false;
                return;
            }

            switch (_modul)
            {
                case Modul.Icra:
                    IcraFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)lueDosya.EditValue);
                    break;

                case Modul.Dava:
                    DavaFoy = DataRepository.AV001_TD_BIL_FOYProvider.GetByID((int)lueDosya.EditValue);
                    break;

                case Modul.Sorusturma:
                    break;

                case Modul.Sozlesme:
                default:
                    break;
            }

            if (IcraFoy != null || DavaFoy != null)
                btnGonder.Enabled = true;
        }
    }
}