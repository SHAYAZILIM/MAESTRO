using System.Windows.Forms;
using AvukatProLib.Extras;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Printing;
using DevExpress.XtraGrid;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPrinting;
using DevExpress.LookAndFeel;

namespace AdimAdimDavaKaydi.Util.PivotOfisAcma
{
    public static class SaveFileTools
    {
        public static void Exporter(ChartControl chartControl, KayitTipiOfis kayitTipi)
        {
            if (kayitTipi != null)
            {
                string filitre = string.Empty;
                switch (kayitTipi)
                {
                    case KayitTipiOfis.Excel:
                        filitre = "Excel (*.xls)|*.XLS";
                        break;
                    case KayitTipiOfis.Pdf:
                        filitre = "Adobe Reader (*.pdf)|*.PDF";
                        break;
                    case KayitTipiOfis.Html:
                        filitre = "Web Sayfası (*.html)|*.HTML";
                        break;
                    case KayitTipiOfis.Word:
                        //
                        break;
                    case KayitTipiOfis.Print:
                        break;
                    default:
                        break;
                }
                if (kayitTipi == KayitTipiOfis.Print)
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
                    case KayitTipiOfis.Excel:
                        chartControl.ExportToXls(sfd.FileName);
                        break;
                    case KayitTipiOfis.Pdf:
                        chartControl.ExportToPdf(sfd.FileName);
                        break;
                    case KayitTipiOfis.Html:
                        chartControl.ExportToHtml(sfd.FileName);
                        break;
                    case KayitTipiOfis.Word:
                        //
                        break;
                    case KayitTipiOfis.Print:

                        break;
                    default:
                        break;
                }
            }
        }

        public static void Exporter(PivotGridControl pivotGridControl, KayitTipiOfis kayitTipi)
        {
            if (kayitTipi != null)
            {
                string filitre = string.Empty;
                switch (kayitTipi)
                {
                    case KayitTipiOfis.Excel:
                        filitre = "Excel (*.xls)|*.XLS";
                        break;
                    case KayitTipiOfis.Pdf:
                        filitre = "Adobe Reader (*.pdf)|*.PDF";
                        break;
                    case KayitTipiOfis.Html:
                        filitre = "Web Sayfası (*.html)|*.HTML";
                        break;
                    case KayitTipiOfis.Print:
                        break;
                    default:
                        break;
                }
                if (kayitTipi == KayitTipiOfis.Print)
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
                    case KayitTipiOfis.Excel:
                        pivotGridControl.ExportToXls(sfd.FileName);
                        break;
                    case KayitTipiOfis.Pdf:
                        pivotGridControl.ExportToPdf(sfd.FileName);
                        break;
                    case KayitTipiOfis.Html:
                        pivotGridControl.ExportToHtml(sfd.FileName);
                        break;
                    case KayitTipiOfis.Print:

                        break;
                    default:
                        break;
                }
            }
        }
    }
}