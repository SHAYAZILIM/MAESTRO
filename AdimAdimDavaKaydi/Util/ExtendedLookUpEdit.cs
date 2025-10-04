using System;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace AdimAdimDavaKaydi.Util
{
    public class ExtendedLookUpEdit : LookUpEdit
    {
        public ExtendedLookUpEdit()
        {
            EditValueChanged += ExLookUpEdit_EditValueChanged;
        }

        private EditorButton btn = new EditorButton("Silgi", DevExpress.XtraEditors.Controls.ButtonPredefines.Delete);

        private void ExLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (EditValue != null)
            {
                if (!Properties.Buttons.Contains(btn))
                {
                    Properties.Buttons.Add(btn);
                    Properties.ButtonClick += SilgiClickEvent;
                }
            }
            else if (EditValue == null)
            {
                if (Properties.Buttons.Contains(btn))
                {
                    Properties.Buttons.RemoveAt(Properties.Buttons.IndexOf(btn));
                    Properties.ButtonClick -= SilgiClickEvent;
                }
            }
        }

        private void SilgiClickEvent(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Tag != null)
                if (e.Button.Tag.ToString() == "Silgi")
                {
                    if (sender is LookUpEdit)
                    {
                        (sender as LookUpEdit).EditValue = null;
                    }
                    if (sender is ExtendedLookUpEdit)
                    {
                        (sender as ExtendedLookUpEdit).EditValue = null;
                    }
                }
        }
    }
}