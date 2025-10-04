using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;

namespace AvukatProRaporlar.Raport.Util
{
    public class ChartDesigner
    {
        #region ViewTypeChanger (Grafiði Deðiþtir)

        public static void SeriesTemplateViewTypeChanger(ChartControl chartcontrol, ViewType viewType)
        {
            try
            {
                chartcontrol.SeriesTemplate.ChangeView(viewType);

                if (chartcontrol.Diagram is Diagram3D)
                {
                    Diagram3D diagram = (Diagram3D)chartcontrol.Diagram;
                    diagram.RuntimeRotation = true;
                    diagram.RuntimeZooming = true;
                    diagram.RuntimeScrolling = true;
                }
            }
            catch 
            {
                //
            }
        }

        #endregion ViewTypeChanger (Grafiði Deðiþtir)

        #region ExplodedPointChanger (Öne Çýkar)

        protected const string All = "Hepsi";

        protected const string Custom = "Custom";

        protected const string MaxValue = "En Yüksek";

        protected const string MinValue = "En Düþük";

        protected const string None = "Hiçbiri";

        /// <summary>
        /// "Hiçbiri","Hiçbiri", "En Düþük", "En Yüksek" deðerlerinide ekleyerek verilen
        /// SeriesPointCollection nesnesinin ýn Point'lerinin Argument deðerlerini döndürür.
        /// </summary>
        /// <param name="points">chartControl.Series[0].Points</param>
        /// <returns></returns>
        public static List<string> CreateModeList(SeriesPointCollection points)
        {
            bool supportCustom = false;
            List<string> list = new List<string>();
            list.Add(None);
            list.Add(All);
            list.Add(MinValue);
            list.Add(MaxValue);
            foreach (SeriesPoint point in points)
                list.Add(point.Argument);
            if (supportCustom)
                list.Add(Custom);
            return list;
        }

        /// <summary>
        /// Seçilen Point'in öne çýkarýr
        /// </summary>
        /// <param name="chartControl">ChartControl</param>
        /// <param name="kolon">Point.Argument veya "Hiçbiri","Hiçbiri", "En Düþük", "En Yüksek",
        /// "Custom"</param>
        public static void ExplodedPointChanger(ChartControl chartControl, string kolon)
        {
            if (chartControl.Series.Count == 0)
                return;
            PieSeriesView view = chartControl.Series[0].View as PieSeriesView;
            if (view != null)
            {
                ApplyMode(view, kolon);
            }
        }

        protected static void ApplyFilterMode(PieSeriesViewBase view, string mode)
        {
            view.ExplodedPointsFilters.Clear();
            view.ExplodedPointsFilters.Add(CreateFilter(mode));
            view.ExplodeMode = PieExplodeMode.UseFilters;
        }

        protected static void ApplyMode(PieSeriesViewBase view, string mode)
        {
            switch (mode)
            {
                case Custom:
                    break;

                case None:
                    view.ExplodeMode = PieExplodeMode.None;
                    break;

                case All:
                    view.ExplodeMode = PieExplodeMode.All;
                    break;

                case MinValue:
                    view.ExplodeMode = PieExplodeMode.MinValue;
                    break;

                case MaxValue:
                    view.ExplodeMode = PieExplodeMode.MaxValue;
                    break;

                default:
                    ApplyFilterMode(view, mode);
                    break;
            }
        }

        protected static SeriesPointFilter CreateFilter(string mode)
        {
            return new SeriesPointFilter(SeriesPointKey.Argument, DataFilterCondition.Equal, mode);
        }

        #endregion ExplodedPointChanger (Öne Çýkar)

        #region Rengi Deðiþtir

        public static void PaletteChanger(ChartControl chartcontrol, string paletteName)
        {
            chartcontrol.PaletteName = paletteName;
        }

        public static List<string> PalleteNameList()
        {
            List<string> liste = new List<string>();

            liste.Add(DevExpress.XtraCharts.Palettes.Apex.Name);
            liste.Add(DevExpress.XtraCharts.Palettes.Aspect.Name);
            liste.Add(DevExpress.XtraCharts.Palettes.BlackAndWhite.Name);
            liste.Add(DevExpress.XtraCharts.Palettes.Chameleon.Name);
            liste.Add(DevExpress.XtraCharts.Palettes.Civic.Name);
            liste.Add(DevExpress.XtraCharts.Palettes.Concourse.Name);
            liste.Add(DevExpress.XtraCharts.Palettes.Equity.Name);
            liste.Add(DevExpress.XtraCharts.Palettes.Flow.Name);
            liste.Add(DevExpress.XtraCharts.Palettes.Foundry.Name);
            liste.Add(DevExpress.XtraCharts.Palettes.Grayscale.Name);
            liste.Add(DevExpress.XtraCharts.Palettes.InAFog.Name);
            liste.Add(DevExpress.XtraCharts.Palettes.Median.Name);
            liste.Add(DevExpress.XtraCharts.Palettes.Metro.Name);
            liste.Add(DevExpress.XtraCharts.Palettes.Mixed.Name);
            liste.Add(DevExpress.XtraCharts.Palettes.Module.Name);
            liste.Add(DevExpress.XtraCharts.Palettes.NatureColors.Name);
            liste.Add(DevExpress.XtraCharts.Palettes.NorthernLights.Name);
            liste.Add(DevExpress.XtraCharts.Palettes.Office.Name);
            liste.Add(DevExpress.XtraCharts.Palettes.Opulent.Name);
            liste.Add(DevExpress.XtraCharts.Palettes.Oriel.Name);
            liste.Add(DevExpress.XtraCharts.Palettes.Origin.Name);
            liste.Add(DevExpress.XtraCharts.Palettes.Paper.Name);
            liste.Add(DevExpress.XtraCharts.Palettes.PastelKit.Name);
            liste.Add(DevExpress.XtraCharts.Palettes.Solstice.Name);
            liste.Add(DevExpress.XtraCharts.Palettes.Technic.Name);
            liste.Add(DevExpress.XtraCharts.Palettes.TerracottaPie.Name);
            liste.Add(DevExpress.XtraCharts.Palettes.TheTrees.Name);
            liste.Add(DevExpress.XtraCharts.Palettes.Trek.Name);
            liste.Add(DevExpress.XtraCharts.Palettes.Urban.Name);
            liste.Add(DevExpress.XtraCharts.Palettes.Verve.Name);

            return liste;
        }

        #endregion Rengi Deðiþtir
    }
}