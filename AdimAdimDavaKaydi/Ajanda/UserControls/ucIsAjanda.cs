using AdimAdimDavaKaydi.Ajanda.Forms.MainForms;
using AdimAdimDavaKaydi.Ajanda.Util.Base;
using AvukatProLib2.Entities;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Ajanda.UserControls
{
    public partial class ucIsAjanda : BaseUserControl
    {
        public ucIsAjanda()
        {
            InitializeComponent();
        }

        public bool TakipEkranindanAjanda;

        private Dictionary<per_AV001_TDI_BIL_CARI_Asistan, List<AppointmentData>> _Data;

        private IEntity _OpenedRecord;

        public Dictionary<per_AV001_TDI_BIL_CARI_Asistan, List<AppointmentData>> Data
        {
            get { return _Data; }
            set
            {
                _Data = value;
                ucAjanda1.TakipEkranindanAjanda = TakipEkranindanAjanda;
                ucAjanda1.Data = Data;
            }
        }

        public IEntity OpenedRecord
        {
            get { return _OpenedRecord; }
            set
            {
                _OpenedRecord = value;
                ucAjanda1.OpenedRecord = value;
            }
        }

        public override void LoadUserControls()
        {
            base.LoadUserControls();
            if (DesignMode)
            {
                return;
            }
        }

        private void ucIsAjanda_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("asdas");
        }
    }
}