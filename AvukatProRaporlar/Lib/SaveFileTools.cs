using DevExpress.LookAndFeel;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Printing;
using DevExpress.XtraGrid;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPrinting;
using System.Windows.Forms;

namespace AvukatProRaporlar.Lib
{
    public static class SaveFileTools
    {
        public static void Exporter(GridControl gridControl, Enums.KayitTipi kayitTipi)
        {
                string filitre = string.Empty;
                switch (kayitTipi)
                {
                    case Enums.KayitTipi.Excel:
                        filitre = "Excel (*.xls)|*.XLS";
                        break;

                    case Enums.KayitTipi.Pdf:
                        filitre = "Adobe Reader (*.pdf)|*.PDF";
                        break;

                    case Enums.KayitTipi.Html:
                        filitre = "Web Sayfası (*.html)|*.HTML";
                        break;

                    case Enums.KayitTipi.Print:
                        break;

                    default:
                        break;
                }

                if (kayitTipi == Enums.KayitTipi.Print)
                {
                    gridControl.ShowPrintPreview();
                    if (ComponentPrinter.IsPrintingAvailable(true))
                    {
                        ComponentPrinter cp = new ComponentPrinter(gridControl);
                        cp.ShowPreview(new DefaultLookAndFeel().LookAndFeel);
                    }   //DevExpress v2012 Upgrade

                    //DevExpress.XtraPrinting.PrintHelper.ShowPreview(gridControl, false);
                    return;
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = filitre;
                DialogResult dr = sfd.ShowDialog();
                if (dr == DialogResult.Cancel)
                {
                    return;
                }

                switch (kayitTipi)
                {
                    case Enums.KayitTipi.Excel:
                        gridControl.ExportToXls(sfd.FileName);
                        break;

                    case Enums.KayitTipi.Pdf:
                        gridControl.ExportToPdf(sfd.FileName);
                        break;

                    case Enums.KayitTipi.Html:
                        gridControl.ExportToHtml(sfd.FileName);
                        break;

                    case Enums.KayitTipi.Print:
                        gridControl.ShowPrintPreview();
                        break;

                    default:
                        break;
            }
        }

        public static void Exporter(ChartControl chartControl, Enums.KayitTipi kayitTipi)
        {
                string filitre = string.Empty;
                switch (kayitTipi)
                {
                    case Enums.KayitTipi.Excel:
                        filitre = "Excel (*.xls)|*.XLS";
                        break;

                    case Enums.KayitTipi.Pdf:
                        filitre = "Adobe Reader (*.pdf)|*.PDF";
                        break;

                    case Enums.KayitTipi.Html:
                        filitre = "Web Sayfası (*.html)|*.HTML";
                        break;

                    case Enums.KayitTipi.Word:

                        //
                        break;

                    case Enums.KayitTipi.Print:
                        break;

                    default:
                        break;
                }
                if (kayitTipi == Enums.KayitTipi.Print)
                {
                    chartControl.ShowPrintPreview(PrintSizeMode.Stretch);
                    return;
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = filitre;
                DialogResult dr = sfd.ShowDialog();
                if (dr == DialogResult.Cancel)
                {
                    return;
                }

                switch (kayitTipi)
                {
                    case Enums.KayitTipi.Excel:
                        chartControl.ExportToXls(sfd.FileName);
                        break;

                    case Enums.KayitTipi.Pdf:
                        chartControl.ExportToPdf(sfd.FileName);
                        break;

                    case Enums.KayitTipi.Html:
                        chartControl.ExportToHtml(sfd.FileName);
                        break;

                    case Enums.KayitTipi.Word:

                        //
                        break;

                    case Enums.KayitTipi.Print:

                        break;

                    default:
                        break;
                }
        }

        public static void Exporter(PivotGridControl pivotGridControl, Enums.KayitTipi kayitTipi)
        {
                string filitre = string.Empty;
                switch (kayitTipi)
                {
                    case Enums.KayitTipi.Excel:
                        filitre = "Excel (*.xls)|*.XLS";
                        break;

                    case Enums.KayitTipi.Pdf:
                        filitre = "Adobe Reader (*.pdf)|*.PDF";
                        break;

                    case Enums.KayitTipi.Html:
                        filitre = "Web Sayfası (*.html)|*.HTML";
                        break;

                    case Enums.KayitTipi.Print:
                        break;

                    default:
                        break;
                }
                if (kayitTipi == Enums.KayitTipi.Print)
                {
                    pivotGridControl.ShowPrintPreview();
                    return;
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = filitre;
                DialogResult dr = sfd.ShowDialog();
                if (dr == DialogResult.Cancel)
                {
                    return;
                }

                switch (kayitTipi)
                {
                    case Enums.KayitTipi.Excel:
                        pivotGridControl.ExportToXls(sfd.FileName);
                        break;

                    case Enums.KayitTipi.Pdf:
                        pivotGridControl.ExportToPdf(sfd.FileName);
                        break;

                    case Enums.KayitTipi.Html:
                        pivotGridControl.ExportToHtml(sfd.FileName);
                        break;

                    case Enums.KayitTipi.Print:

                        break;

                    default:
                        break;
                }
        }
    }
}