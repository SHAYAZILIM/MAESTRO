using System;
using System.Collections.Generic;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraPivotGrid;

namespace AdimAdimDavaKaydi.Util
{
    internal class ExtendedPivotControl : PivotGridControl
    {
        public ExtendedPivotControl()
        {   //DevExpress v2012 Upgrade
            //this.ShowMenu += ExtendedPivotControl_ShowMenu;
            this.EditValueChanged += ExtendedPivotControl_EditValueChanged;
            this.CustomEditValue += ExtendedPivotControl_CustomEditValue;
            this.FieldValueDisplayText += ExtendedPivotControl_FieldValueDisplayText;

            bar.ShowTitle = true;
            bar.Maximum = 100;
            bar.Minimum = 0;
            bar.Step = 1;
            bar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
        }

        private void ExtendedPivotControl_FieldValueDisplayText(object sender, PivotFieldDisplayTextEventArgs e)
        {
            if (e.Value == null)
                return;
            try
            {
                if (e.Field != null && e.Field.FieldEdit != null && e.Field.FieldEdit is RepositoryItemLookUpEdit)
                {
                    e.DisplayText =
                        (e.Field.FieldEdit as RepositoryItemLookUpEdit).GetDisplayValueByKeyValue(e.Value).ToString();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void ExtendedPivotControl_CustomEditValue(object sender, CustomEditValueEventArgs e)
        {
            if (oranlananlarListesi.Contains(e.DataField))
            {
                e.Value = Convert.ToDouble(e.Value) * 100f;
            }
        }

        private void ExtendedPivotControl_EditValueChanged(object sender, EditValueChangedEventArgs e)
        {
            if (asilOranlananlarListesi.Contains(e.DataField))
            {
                ChangeCellValue(e, Convert.ToDecimal(e.Value), Convert.ToDecimal(e.Editor.EditValue));
            }
            if (oranlananlarListesi.Contains(e.DataField))
            {
                if (e.DataField.Tag is PivotGridField)
                {
                    PivotGridField asilField = e.DataField.Tag as PivotGridField;
                    decimal c0 = Convert.ToDecimal(e.GetCellValue(asilField));
                    decimal p0 = Convert.ToDecimal(e.Value);
                    decimal p1 = Convert.ToDecimal(e.Editor.EditValue);
                    decimal newValue = (p0 == 0m || p1 == 0m) ? 0m : c0 * (100m / p0 - 1m) / (100m / p1 - 1m);

                    ChangeCellValue(e, c0, newValue);
                }
            }
        }

        private void ChangeCellValue(EditValueChangedEventArgs e, decimal oldValue, decimal newValue)
        {
            if (e.DataField.Tag is PivotGridField)
            {
                PivotGridField asilField = e.DataField.Tag as PivotGridField;

                PivotDrillDownDataSource ds = e.CreateDrillDownDataSource();
                decimal differance = newValue - oldValue;
                decimal factor = (differance == newValue) ? (differance / ds.RowCount) : (differance / oldValue);
                for (int i = 0; i < ds.RowCount; i++)
                {
                    decimal value = Convert.ToDecimal(ds[i][asilField]);
                    ds[i][asilField] = value * (1m + factor);
                }
            }
        }

        private RepositoryItemProgressBar bar = new RepositoryItemProgressBar();
        private List<PivotGridField> asilOranlananlarListesi = new List<PivotGridField>();
        private List<PivotGridField> oranlananlarListesi = new List<PivotGridField>();

    }

}