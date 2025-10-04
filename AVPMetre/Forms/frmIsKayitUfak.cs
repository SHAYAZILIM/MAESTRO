using System.ComponentModel;
using System.Windows.Forms;
using AvukatProLib2.Entities;
using System;

namespace AVPMetre.Forms
{
    public partial class frmIsKayitUfak : DevExpress.XtraEditors.XtraForm
    {
        private int _ModulID = 10;

        public frmIsKayitUfak()
        {
            InitializeComponent();
        }

        public int ModulID
        {
            get { return _ModulID; }
            set { _ModulID = value; }
        }

        [Browsable(false)]
        public IEntity Record
        {
            get
            {
                if (DesignMode)
                {
                    return null;
                }
                return ucIsKayitUfak1.Record;
            }
            set
            {
                if (DesignMode || value == null)
                {
                    return;
                }
                ucIsKayitUfak1.Record = value;
            }
        }

        public void SetByTableNameAndId(string tableName, int id)
        {
            //ucIsKayitUfak1.SetByTableNameAndId(tableName, id);
            ucIsKayitUfak1.ModulID = this.ModulID;

            //this.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.ShowDialog();
        }

        private void frmIsKayitUfak_Load(object sender, System.EventArgs e)
        {
            ucIsKayitUfak1.Dock = DockStyle.Fill;
        }
    }
}