using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace ImportExportWithSelection.Import
{
    public partial class frmMaskeler : DevExpress.XtraEditors.XtraForm
    {
        public frmMaskeler()
        {
            InitializeComponent();
        }

        public void Show(Columns kolon, DataTable ExcelData)
        {
            this.bndMask.DataSource = kolon.Maskeler;
            this.Show();
            List<ValueText> values = new List<ValueText>();
            for (int i = 0; i < ExcelData.Rows.Count; i++)
            {
                ValueText vt = new ValueText();
                vt.Text = ExcelData.Rows[i][kolon.Column].ToString();
                vt.Value = ExcelData.Rows[i][kolon.Column].ToString();
                values.Add(vt);
            }
            this.lueDeger.Properties.DataSource = values;
            this.bndMask.AddNew();
            this.gridControl1.DataSource = bndMask.DataSource;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bndMask.MoveNext();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            bndMask.MovePrevious();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            bndMask.RemoveCurrent();
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            this.bndMask.AddNew();
        }

        private void frmMaskeler_Load(object sender, EventArgs e)
        {
            this.bndMask.DataSource = new BindingList<Masks>();
            MyInits.SetLookupByEnum(this.lueMaskeTipi.Properties, typeof(MaskTypes));
        }

        private void lueMaskeTipi_EditValueChanged(object sender, EventArgs e)
        {
            MaskTypes mt = (MaskTypes)Enum.ToObject(typeof(MaskTypes), Convert.ToInt32(lueMaskeTipi.EditValue));

            pnlKolonTablo.Visible = false;
            pnlMaske.Visible = false;
            Masks m = new Masks();
            if (bndMask.Current is Masks)
            {
                m = (Masks)bndMask.Current;
                pnlMaske.Controls.Clear();
            }

            switch (mt)
            {
                case MaskTypes.Dogru_Yanlis_Verisi:

                    pnlMaske.Visible = true;

                    // m.MasksType = MaskTypes.Dogru_Yanlis_Verisi;

                    break;

                case MaskTypes.Karakter_Verisi:
                    pnlMaske.Visible = true;

                    // m.MasksType = MaskTypes.Karakter_Verisi;
                    break;

                case MaskTypes.Sayýsal_Veri:
                    pnlMaske.Visible = true;

                    // m.MasksType = MaskTypes.Sayýsal_Veri;
                    break;

                case MaskTypes.Tarih:
                    pnlMaske.Visible = true;

                    // m.MasksType = MaskTypes.Tarih;
                    break;

                case MaskTypes.TabloVerisi:
                    pnlKolonTablo.Visible = true;

                    // m.MasksType = MaskTypes.TabloVerisi;
                    break;

                default:
                    break;
            }
            Control cnt = m.GetLookUp();
            cnt.Left = lueMaske.Left;
            cnt.Top = lueMaske.Top;

            pnlMaske.Controls.Add(cnt);
        }
    }
}