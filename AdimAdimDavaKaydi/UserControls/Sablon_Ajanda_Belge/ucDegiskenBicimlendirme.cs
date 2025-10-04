using System;
using System.Drawing;
using TXTextControl;

namespace AdimAdimDavaKaydi.UserControls.Sablon_Ajanda_Belge
{
    public partial class ucDegiskenBicimlendirme : DevExpress.XtraEditors.XtraUserControl
    {
        private TextField selected;

        public ucDegiskenBicimlendirme()
        {
            InitializeComponent();
            this.Deleted += ucDegiskenBicimlendirme_Deleted;
        }

        public delegate void OnDeleted(object sender, TextField deletedItem);

        public event OnDeleted Deleted;

        public TextField Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        public void SelectField(TextField pselected, Point position)
        {
            selected = pselected;
            this.Show();
            this.Visible = true;
            this.Location = position;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            selected.Editable = true;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Deleted(this, selected);
        }

        private void ucDegiskenBicimlendirme_Deleted(object sender, TextField deletedItem)
        {
        }
    }
}