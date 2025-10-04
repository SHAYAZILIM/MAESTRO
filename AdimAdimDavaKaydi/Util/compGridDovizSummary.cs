using System;
using System.Collections.Generic;
using System.ComponentModel;
using AvukatProLib.Hesap;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace AdimAdimDavaKaydi.Util
{
    public partial class compGridDovizSummary : Component
    {
        public compGridDovizSummary(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private GridView _myGridView;

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
                _myGridView.CustomSummaryCalculate += _myGridView_CustomSummaryCalculate;
            }
        }

        /// <summary>
        /// Alt Toplam alanlarýný yeniler
        /// </summary>
        public void Refresh()
        {
            SummaryItemEkle(_myGridView);
        }

        private void SummaryItemEkle(GridView grid)
        {
            if (grid == null)
                return;
            grid.GroupSummary.Clear();

            Dictionary<string, GridColumn> columnListesi = new Dictionary<string, GridColumn>();

            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (!string.IsNullOrEmpty(grid.Columns[i].FieldName))
                    if (!columnListesi.ContainsKey(grid.Columns[i].FieldName))
                        columnListesi.Add(grid.Columns[i].FieldName, grid.Columns[i]);
            }
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (!this.YasakliAlanlar.Contains(grid.Columns[i].FieldName) && (
                    grid.Columns[i].FieldName.Contains("_DOVIZ_ID") || grid.Columns[i].FieldName.Contains("DovizId")))
                {
                    string dovizField = grid.Columns[i].FieldName;
                    string tutarAlani = dovizField.Replace("_DOVIZ_ID", "");

                    if (columnListesi.ContainsKey(tutarAlani))
                    {
                        grid.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[]
                                                       {
                                                           new DevExpress.XtraGrid.GridGroupSummaryItem(
                                                               DevExpress.Data.SummaryItemType.Custom,
                                                               columnListesi[tutarAlani].FieldName,
                                                               columnListesi[tutarAlani], "{0:###,###,###,###,##0.00}"),
                                                           new DevExpress.XtraGrid.GridGroupSummaryItem(
                                                               DevExpress.Data.SummaryItemType.Custom,
                                                               columnListesi[dovizField].FieldName,
                                                               columnListesi[dovizField], "{0}")
                                                       });
                        grid.Columns[tutarAlani].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                        grid.Columns[tutarAlani].SummaryItem.DisplayFormat = "{0:###,###,###,###,##0.00}";
                        grid.Columns[tutarAlani].ToolTip = "Toplam";
                        grid.Columns[dovizField].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                        grid.Columns[dovizField].SummaryItem.DisplayFormat = "{0}";
                    }
                }
            }

            try
            {
                //for (int i = 0; i < grid.SummaryItem .Count; i++)
                //{
                //    if (grid.GroupSummary[i].FieldName == "TOPLAM_MUV_ODEME")
                //    {
                //        grid.GroupSummary.RemoveAt(i);
                //        break;
                //    }
                //}
                grid.Columns["TOPLAM_MUV_ODEME"].Summary.Clear();
                grid.Columns["TOPLAM_MUV_ODEME"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TOPLAM_MUV_ODEME", "{0:###,###,###,###,##0.00}");
            }
            catch { ;}
        }

        private List<string> _YasakliAlanlar;

        [Browsable(false)]
        public List<string> YasakliAlanlar
        {
            get
            {
                if (_YasakliAlanlar == null) _YasakliAlanlar = new List<string>();
                return _YasakliAlanlar;
            }
            set { _YasakliAlanlar = value; }
        }

        public bool AltToplamlarAktifMi { get; set; }

        private Dictionary<int, decimal> paralar = new Dictionary<int, decimal>();
        private List<int> DovizListesi = new List<int>();

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
                            if (e.FieldValue != DBNull.Value)
                            {
                                int? dovizId = null;
                                try
                                {
                                    dovizId = (int?)view.GetRowCellValue(e.RowHandle, ((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName + "_DOVIZ_ID");
                                }
                                catch
                                {

                                }
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
                                //llblgende patlýyor
                                //else if (dovizId == null)
                                //{
                                //    if (paralar.ContainsKey(1))
                                //    {
                                //        paralar.Add(dovizId.Value, (decimal)e.FieldValue);
                                //        paralar[1] += (decimal)e.FieldValue;
                                //    }
                                //    else
                                //    {
                                //        paralar.Add(dovizId.Value, (decimal)e.FieldValue);
                                //        paralar.Add(1, (decimal)e.FieldValue);
                                //    }
                                //}
                                else
                                {
                                    //Bir Terslik Var
                                } 
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
                                    decimal kur = DovizHelper.CevirYTL(para.Value, para.Key, DateTime.Today);

                                    //double tlTutari = kur * para.Value;
                                    toplam += kur;
                                }
                                catch (Exception ex)
                                {
                                    BelgeUtil.ErrorHandler.Catch(this, ex, false, BelgeUtil.Bilesen.Hesap,
                                                                 BelgeUtil.Bilesen.BilesenYok);
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

                #endregion

                #region Birim

                else if (summaryItem.FieldName.Contains("_DOVIZ_ID"))
                {
                    if (summaryItem.FieldName != "TOPLAM_MUV_ODEME_DOVIZ_ID")
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
                                e.TotalValue = DovizHelper.CevirString(DovizListesi[0]);
                                // ParaBirimiVer(int.Parse(e.FieldValue.ToString()));
                            }
                            else
                            {
                                e.TotalValue = "Bir Terslik Var";
                            }
                        } 
                    }
                }

                #endregion
            }
        }
    }
}