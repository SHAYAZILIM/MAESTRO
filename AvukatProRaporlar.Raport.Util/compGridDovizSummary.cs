using AvukatProRaporlar.Util;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace AvukatProRaporlar.Raport.Util
{
    public partial class compGridDovizSummary : Component
    {
        public compGridDovizSummary()
        {
            InitializeComponent();
        }

        public compGridDovizSummary(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private bool _altToplamlarAktifMi;

        private GridView _myGridView;

        private List<int> DovizListesi = new List<int>();

        private Dictionary<int, decimal> paralar = new Dictionary<int, decimal>();

        public bool AltToplamlarAktifMi
        {
            get { return _altToplamlarAktifMi; }
            set { _altToplamlarAktifMi = value; }
        }

        public GridView MyGridView
        {
            get { return _myGridView; }
            set
            {
                _myGridView = value;
                if (value == null)
                    return;

                SummaryItemEkle(value);
                value.OptionsView.ShowFooter = true;
                _myGridView.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(_myGridView_CustomSummaryCalculate);
            }
        }

        /// <summary>
        /// Alt Toplam alanlarýný yeniler
        /// </summary>
        public void Refresh()
        {
            SummaryItemEkle(_myGridView);
        }

        private void _myGridView_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (!AltToplamlarAktifMi)
                return;

            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            DevExpress.XtraGrid.GridSummaryItem summaryItem = e.Item as DevExpress.XtraGrid.GridSummaryItem;

            if (true) //(summaryItem.Tag is int)
            {
                #region Para

                if (!summaryItem.FieldName.Contains("_DOVIZ_ID"))
                {
                    if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                    {
                        paralar.Clear();
                    }
                    else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                    {
                        if (e.FieldValue != null)
                        {
                            int? dovizId = (int?)view.GetRowCellValue(e.RowHandle, ((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName + "_DOVIZ_ID");
                            if (dovizId != null)
                            {
                                if (paralar.ContainsKey(dovizId.Value))
                                {
                                    paralar[dovizId.Value] += (decimal)e.FieldValue;
                                }
                                else
                                {
                                    paralar.Add(dovizId.Value, (decimal)e.FieldValue);
                                }
                            }
                            else if (dovizId == null)
                            {
                                if (paralar.ContainsKey(1))
                                {
                                    paralar[1] += (decimal)e.FieldValue;
                                }
                                else
                                {
                                    paralar.Add(1, (decimal)e.FieldValue);
                                }
                            }
                            else
                            {
                                //Bir Terslik Var
                            }
                        }
                    }
                    else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                    {
                        decimal toplam = 0;

                        string fieldName = string.Empty;
                        if (paralar.Count > 1)
                        {
                            foreach (KeyValuePair<int, decimal> para in paralar)
                            {
                                try
                                {
                                    //TODO: <TIO - 20090617>
                                    /*
                                     * 17062009 tarihinde Doviz Kur getirirken alýnan hata sonucu
                                     * yýlmadýn dediði doðrultuda try cathe aýndý
                                     *
                                     /*/
                                    decimal kur = DovizHelper.CevirYTL(para.Value, para.Key, DateTime.Today); ;

                                    //double tlTutari = kur * para.Value;
                                    toplam += kur;
                                }
                                catch
                                {
                                    // BelgeUtil.ErrorHandler.Catch(this, ex, false,
                                    // BelgeUtil.Bilesen.Hesap, BelgeUtil.Bilesen.BilesenYok);
                                }

                                //TODO: </TIO - 20090617>
                            }
                        }
                        else if (paralar.Count == 1)
                        {
                            foreach (KeyValuePair<int, decimal> item in paralar)
                            {
                                toplam = item.Value;
                            }
                        }
                        string yazdirilacakAlan = toplam.ToString();
                        e.TotalValue = toplam;
                    }
                }

                #endregion Para

                #region Birim

                else if (summaryItem.FieldName.Contains("_DOVIZ_ID"))
                {
                    if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                    {
                        DovizListesi.Clear();
                    }
                    else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                    {
                        if (e.FieldValue != null)
                        {
                            if (!DovizListesi.Contains(int.Parse(e.FieldValue.ToString())))
                            {
                                DovizListesi.Add(int.Parse(e.FieldValue.ToString()));
                            }
                        }
                        else
                        {
                            if (!DovizListesi.Contains(1))
                            {
                                DovizListesi.Add(1);
                            }
                        }
                    }
                    else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                    {
                        if (DovizListesi.Count > 1)
                        {
                            e.TotalValue = DovizHelper.CevirString(1);
                        }
                        else if (DovizListesi.Count == 1)
                        {
                            e.TotalValue = DovizHelper.CevirString(DovizListesi[0]); //
                                                                                     // ParaBirimiVer(int.Parse(e.FieldValue.ToString()));
                        }
                        else
                        {
                            e.TotalValue = "Bir Terslik Var";
                        }
                    }
                }

                #endregion Birim
            }
        }

        private void SummaryItemEkle(GridView grid)
        {
            if (grid == null)
                return;

            Dictionary<string, GridColumn> columnListesi = new Dictionary<string, GridColumn>();

            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (!string.IsNullOrEmpty(grid.Columns[i].FieldName))
                    columnListesi.Add(grid.Columns[i].FieldName, grid.Columns[i]);
            }
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (grid.Columns[i].FieldName.Contains("_DOVIZ_ID"))
                {
                    string dovizField = grid.Columns[i].FieldName;
                    string tutarAlani = dovizField.Replace("_DOVIZ_ID", "");
                    if (columnListesi.ContainsKey(tutarAlani))
                    {
                        grid.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[]{
                              new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, columnListesi[tutarAlani].FieldName, columnListesi[tutarAlani], "{0:###,###,###,###,##0.00}"),
                              new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, columnListesi[dovizField].FieldName, columnListesi[dovizField], "{0}")});
                        grid.Columns[tutarAlani].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                        grid.Columns[tutarAlani].SummaryItem.DisplayFormat = "{0:###,###,###,###,##0.00}";
                        grid.Columns[tutarAlani].ToolTip = "Toplam";
                        grid.Columns[dovizField].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                        grid.Columns[dovizField].SummaryItem.DisplayFormat = "{0}";
                    }
                }
            }
        }
    }
}