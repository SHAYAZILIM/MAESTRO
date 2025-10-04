using System;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls.Sablon_Ajanda_Belge
{
    public partial class ucSektor : DevExpress.XtraEditors.XtraUserControl
    {
        public ucSektor()
        {
            InitializeComponent();
        }

        public TList<TDIE_KOD_SEKTOR> MyDataSource
        {
            get
            {
                if (gridControl1.DataSource is TList<TDIE_KOD_SEKTOR>)
                    return (TList<TDIE_KOD_SEKTOR>)gridControl1.DataSource;

                return null;
            }
            set { gridControl1.DataSource = value; }
        }

        private TList<TDIE_KOD_SEKTOR> SektorDataSource = new TList<TDIE_KOD_SEKTOR>();

        private void ucSektor_Load(object sender, EventArgs e)
        {
            SektorDataSource = AvukatProLib2.Data.DataRepository.TDIE_KOD_SEKTORProvider.GetAll();
            this.gridControl1.DataSource = SektorDataSource;
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
                    DataRepository.TDIE_KOD_SEKTORProvider.Delete(SektorDataSource);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //SÝl
            DialogResult res = MessageBox.Show("Deðiþiklikler silinsin mi?", "Sil", MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                try
                {
                    DataRepository.TDIE_KOD_SEKTORProvider.Delete(SektorDataSource);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}