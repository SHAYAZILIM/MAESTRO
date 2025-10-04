using AvukatProLib;
using AvukatProLib2.Entities;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Editor.Forms
{
    public partial class frmPostaListesiYazdir : Form
    {
        public frmPostaListesiYazdir(List<object> SelectedList)
        {
            InitializeComponent();
            this.SelectedList = SelectedList;
        }

        private string eskiAdliye = "";
        private string eskiBirimNo = "";
        private List<object> SelectedList;

        private void frmPostaListesiYazdir_Load(object sender, EventArgs e)
        {
            string where = "";

            for (int i = 0; i < SelectedList.Count; i++)
            {
                if (SelectedList[i] is DataRow)
                {
                    if (string.IsNullOrEmpty(where))
                        where += ((DataRow)SelectedList[i])["ID"].ToString();
                    else
                        where += "," + ((DataRow)SelectedList[i])["ID"].ToString();
                }
                else if (SelectedList[i] is AV001_TI_BIL_FOY)
                {
                    if (string.IsNullOrEmpty(where))
                        where += ((AV001_TI_BIL_FOY)SelectedList[i]).ID.ToString();
                    else
                        where += "," + ((AV001_TI_BIL_FOY)SelectedList[i]).ID.ToString();
                }
            }

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;

            DataTable dt = cn.GetDataTable("SELECT row_number() over(order by Adliye, [Birim No]) as SN, Adliye, [Birim No], [Görev], [Esas No], Muhatap, [Gideceği Yer], [Ücreti], [Barkod No] FROM dbo.PostaGiderleri WHERE ID IN (" + where + ") ORDER BY Adliye, [Birim No]");

            string oncekiAdliye = "";
            string oncekiBirimNo = "";

            int SiraNo = 0;

            foreach (DataRow row in dt.Rows)
            {
                SiraNo++;
                row["SN"] = SiraNo;
                if (row["Adliye"] != null & row["Birim No"] != null)
                {
                    if (row["Adliye"] != DBNull.Value & row["Birim No"] != DBNull.Value)
                    {
                        if (oncekiAdliye != row["Adliye"].ToString() || oncekiBirimNo != row["Birim No"].ToString())
                        {
                            SiraNo = 1;
                            oncekiAdliye = row["Adliye"].ToString();
                            oncekiBirimNo = row["Birim No"].ToString();
                            row["SN"] = SiraNo;
                        }
                    }
                }
            }

            gridControl2.DataSource = dt;
            printControl1.PrintingSystem = printingSystem1;
            printableComponentLink1.CreateDocument();
        }

        private void gridView3_AfterPrintRow(object sender, DevExpress.XtraGrid.Views.Printing.PrintRowEventArgs e)
        {
        }

        private void gridView3_BeforePrintRow(object sender, DevExpress.XtraGrid.Views.Printing.CancelPrintRowEventArgs e)
        {
            if (gridView3.GetRowCellValue(e.RowHandle, "Adliye") != null & gridView3.GetRowCellValue(e.RowHandle, "Birim No") != null)
            {
                if (gridView3.GetRowCellValue(e.RowHandle, "Adliye") != DBNull.Value & gridView3.GetRowCellValue(e.RowHandle, "Birim No") != DBNull.Value)
                {
                    if (eskiAdliye != gridView3.GetRowCellValue(e.RowHandle, "Adliye").ToString() || eskiBirimNo != gridView3.GetRowCellValue(e.RowHandle, "Birim No").ToString())
                    {
                        if (!string.IsNullOrEmpty(eskiAdliye) & !string.IsNullOrEmpty(eskiBirimNo))
                            e.PS.InsertPageBreak(e.Y + 20);

                        eskiAdliye = gridView3.GetRowCellValue(e.RowHandle, "Adliye").ToString();
                        eskiBirimNo = gridView3.GetRowCellValue(e.RowHandle, "Birim No").ToString();
                    }
                }
            }
        }

        private void printableComponentLink1_CreateDetailHeaderArea(object sender, CreateAreaEventArgs e)
        {
        }

        private void printableComponentLink1_CreateInnerPageHeaderArea(object sender, CreateAreaEventArgs e)
        {
        }

        private void printableComponentLink1_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Center);
            e.Graph.Font = new Font("Tahoma", 14, FontStyle.Bold);
            RectangleF rec = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50);
            e.Graph.DrawString("Posta Listesi" + "  (" + DateTime.Today.ToShortDateString() + ")", Color.Black, rec, BorderSide.None);
        }

        private void printableComponentLink1_CreateReportHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e)
        {
            //e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Far);
            //e.Graph.Font = new Font("Tahoma", 10, FontStyle.Regular);
            //RectangleF rec2 = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50);
            //e.Graph.DrawString(DateTime.Today.ToShortDateString(), Color.Black, rec2, BorderSide.None);
        }
    }
}