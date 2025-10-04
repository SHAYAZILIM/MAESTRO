using System;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls.Sablon_Ajanda_Belge
{
    public partial class ucDil : DevExpress.XtraEditors.XtraUserControl
    {
        private TList<TDIE_KOD_DIL> DilDataSource = new TList<TDIE_KOD_DIL>();

        public ucDil()
        {
            InitializeComponent();
        }

        public TList<TDIE_KOD_DIL> MyDataSource
        {
            get
            {
                if (gridDil.DataSource is TList<TDIE_KOD_DIL>) return (TList<TDIE_KOD_DIL>)gridDil.DataSource;

                return null;
            }
            set { gridDil.DataSource = value; }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //KAYDET
            DialogResult res = MessageBox.Show("Deðiþiklikler kaydedilsin mi?", "Kaydet", MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                try
                {
                    DataRepository.TDIE_KOD_DILProvider.DeepSave(DilDataSource);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Deðiþiklikler silinsin mi?", "Sil", MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                try
                {
                    DataRepository.TDIE_KOD_DILProvider.Delete(DilDataSource);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ucDil_Load(object sender, EventArgs e)
        {
            //LOAD
            if (!this.DesignMode)
            {
                DilDataSource = AvukatProLib2.Data.DataRepository.TDIE_KOD_DILProvider.GetAll();
                gridDil.DataSource = DilDataSource;
            }
        }
    }
}