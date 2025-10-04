using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AvukatPro.Database
{
    public partial class frmCetDataGrid : Form
    {
        public DataTable DataTable { get; set; }
        public frmCetDataGrid()
        {
            InitializeComponent();
        }

        private void frmCetDataGrid_Load(object sender, EventArgs e)
        {
            if (DataTable != null)
                dataGridView1.DataSource = DataTable;
        }
    }
}
