using System;
using System.Drawing;
using System.Windows.Forms;
using TXTextControl;

namespace AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge
{
    public partial class frmSablonTabloEkle : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmSablonTabloEkle()
        {
            InitializeComponent();
        }

        private static int tableCounter;

        private TextControl document;
        
        public void DikDortgenCiz(float genislik, float cerceve, Color clr, PictureBox pbox)
        {
            double gens = Tools.CmToPixcel(21, true);
            double yukseklik = Tools.CmToPixcel(29.7, false);
            float d = genislik / 102;
            float genSonuc = genislik * d;

            Graphics g = pbox.CreateGraphics();

            g.DrawRectangle(new Pen(Color.Black, cerceve), 3, 3, genSonuc, 10);
            pbox.BackColor = clr;
        }

        public void ShowTableAddDialog(TextControl _document)
        {
            document = _document;

            //this.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.ShowDialog();
        }

        private void c_spnSutun_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void frmSablonTabloEkle_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            DikDortgenCiz((float)c_spnGenislik.Value, (float)c_spnCerceve.Value, c_clrTabloArkaplan.Color, pictureBox1);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            tableCounter = document.Tables.Count + 200;
            string seltxt = document.Selection.Text;
            if (!string.IsNullOrEmpty(document.Selection.Text))
            {
                int sind = document.Selection.Start;

                //  document.Selection.Length = 0;
            }

            document.Tables.Add(Convert.ToInt32(c_spnSatir.Value), Convert.ToInt32(c_spnSutun.Value), tableCounter);
            Table tbl = document.Tables.GetItem(tableCounter);
            if (tbl.Columns.Count == 1 && tbl.Rows.Count == 1)
            {
                tbl.Cells.GetItem(1, 1).Text = seltxt;
            }
            for (int i = 1; i < tbl.Columns.Count; i++)
            {
                for (int y = 1; y < tbl.Rows.Count; y++)
                {
                    TXTextControl.TableCellFormat tblCellFrmt = new TableCellFormat();
                    tblCellFrmt.BottomBorderWidth = Convert.ToInt32(c_spnGenislik.Value);
                    tblCellFrmt.TopBorderWidth = Convert.ToInt32(c_spnGenislik.Value);
                    tblCellFrmt.LeftBorderWidth = Convert.ToInt32(c_spnGenislik.Value);
                    tblCellFrmt.RightBorderWidth = Convert.ToInt32(c_spnGenislik.Value);
                    tblCellFrmt.BackColor = c_clrTabloArkaplan.Color;
                    tbl.Cells.GetItem(i, y).CellFormat = tblCellFrmt;

                    //tbl.Cells.GetItem(i, y).CellFormat.BackColor = c_clrTabloArkaplan.Color;
                    //tbl.Cells.GetItem(i, y).CellFormat.BackColor = Color.White;
                    //tbl.Cells.GetItem(i, y).CellFormat.BottomBorderWidth = Convert.ToInt32(c_spnGenislik.Value);
                    //tbl.Cells.GetItem(i, y).CellFormat.TopBorderWidth = Convert.ToInt32(c_spnGenislik.Value);
                    //tbl.Cells.GetItem(i, y).CellFormat.LeftBorderWidth = Convert.ToInt32(c_spnGenislik.Value);
                    //tbl.Cells.GetItem(i, y).CellFormat.RightBorderWidth = Convert.ToInt32(c_spnGenislik.Value);
                }
            }
            this.Close();
        }
    }
}